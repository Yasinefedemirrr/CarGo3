using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using CarGo.Application.interfaces.CarPricinginterfaces;
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

            
    }
}
