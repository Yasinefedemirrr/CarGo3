using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.CQRS.Results.CarResults;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using CarGo.Application.interfaces.Carinterfaces;

namespace CarGo.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetCarWithBrandQueryResults> Handle()
        {
            var values = _repository.GetCarsListWithBrand();
            return values.Select(x => new GetCarWithBrandQueryResults
            {
                BrandName = x.Brand.Name,
                BrandID = x.BrandID,
                BigİmageUrl = x.BigİmageUrl,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
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
