using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.CQRS.Queries.BrandQueries;
using CarGo.Application.Features.CQRS.Results.BrandResults;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using CarGo.Application.Features.CQRS.Results.CarResults;
using CarGo.Application.Features.CQRS.Queries.CarQueries;

namespace CarGo.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {

        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                BrandID = values.BrandID,
                BigİmageUrl = values.BigİmageUrl,
                CarID = values.CarID,
                CoverİmageUrl = values.CoverİmageUrl,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seat = values.Seat,
                Transmission = values.Transmission
            };
        }
    }
}
