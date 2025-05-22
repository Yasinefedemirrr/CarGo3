using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using CarGo.Application.interfaces.CarPricinginterfaces;
using CarGo.Application.ViewModels;
using CarGo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarGo.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarGoContext _context;

        public CarPricingRepository(CarGoContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricing.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 4).ToList();
            return values;
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
            SELECT 
                b.""Name"" AS ""Brand"",
                c.""Model"",
                c.""CoverImageUrl"",
                SUM(cp.""Amount"") FILTER (WHERE cp.""PricingId"" = 1) AS ""dailyAmount"",
                SUM(cp.""Amount"") FILTER (WHERE cp.""PricingId"" = 3) AS ""weeklyAmount"",
                SUM(cp.""Amount"") FILTER (WHERE cp.""PricingId"" = 4) AS ""monthlyAmount""
            FROM ""CarPricing"" cp
            INNER JOIN ""Cars"" c ON c.""CarID"" = cp.""CarId""
            INNER JOIN ""Brands"" b ON b.""BrandID"" = c.""BrandID""
            GROUP BY b.""Name"", c.""Model"", c.""CoverImageUrl"";";

                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel
                        {
                            Brand = reader["Brand"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                    {
                        reader["dailyAmount"] != DBNull.Value ? Convert.ToDecimal(reader["dailyAmount"]) : 0,
                        reader["weeklyAmount"] != DBNull.Value ? Convert.ToDecimal(reader["weeklyAmount"]) : 0,
                        reader["monthlyAmount"] != DBNull.Value ? Convert.ToDecimal(reader["monthlyAmount"]) : 0
                    }
                        };

                        values.Add(carPricingViewModel);
                    }
                }

                _context.Database.CloseConnection();
            }

            return values;
        }
    }
}
    

