using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.CQRS.Results.BrandResults;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using CarGo.Application.Features.CQRS.Results.CarResults;

namespace CarGo.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {

        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandID = x.BrandID,
                BigİmageUrl = x.BigİmageUrl,
                CarID = x.CarID,
                CoverİmageUrl = x.CoverİmageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }

    }
}
