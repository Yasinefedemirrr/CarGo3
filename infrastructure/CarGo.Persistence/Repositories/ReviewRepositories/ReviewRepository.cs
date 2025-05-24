using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using CarGo.Application.interfaces.Reviewinterfaces;
using CarGo.Persistence.Context;

namespace CarGo.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarGoContext _context;

        public ReviewRepository(CarGoContext context)
        {
            _context = context;
        }

        public List<Review> GetReviewsByCarId(int carId)
        {
            var values = _context.Reviews.Where(x => x.CarID == carId).ToList();
            return values;
        }
    }
}
