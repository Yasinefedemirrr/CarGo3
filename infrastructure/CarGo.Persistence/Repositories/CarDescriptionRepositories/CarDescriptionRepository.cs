using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using CarGo.Application.interfaces.CarDescriptioninterfaces;
using CarGo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarGo.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarGoContext _context;

        public CarDescriptionRepository(CarGoContext context)
        {
            _context = context;
        }

        async Task<CarDescription> ICarDescriptionRepository.GetCarDescription(int carId)
        {
            var values = await _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();
            return values;
        }
    }
}
