using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using CarGo.Application.interfaces.Carinterfaces;
using CarGo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarGo.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarGoContext _context;

        public CarRepository(CarGoContext context)
        {
            _context = context;
        }

        public List<Car> GetCarsListWithBrand()
        {
            var values = _context.Cars.Include(x=> x.Brand).ToList();
            return values;
        }
        public List<Car> GetLast5CarsListWithBrand()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToList();
            return values;
        }



    }
}
