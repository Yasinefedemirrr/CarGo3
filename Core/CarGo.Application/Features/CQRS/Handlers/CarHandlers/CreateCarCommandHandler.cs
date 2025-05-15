using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.CQRS.Commands.BrandCommand;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using CarGo.Application.Features.CQRS.Commands.CarCommands;

namespace CarGo.Application.Features.CQRS.Handlers.CarHandlers
{
        public class CreateCarCommandHandler
    {

        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BrandID = command.BrandID,
                BigİmageUrl = command.BigİmageUrl,
                CoverImageUrl = command.CoverImageUrl,
                Fuel = command.Fuel,
                Km = command.Km,
                Luggage = command.Luggage,
                Model = command.Model,
                Seat = command.Seat,
                Transmission = command.Transmission


            });
        }
    }
}
