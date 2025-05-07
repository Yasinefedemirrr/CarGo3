﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.CQRS.Commands.BrandCommand;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using CarGo.Application.Features.CQRS.Commands.CarCommands;
using System.Reflection;

namespace CarGo.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarID);
            values.Fuel = command.Fuel;
            values.Transmission = command.Transmission;
            values.BigİmageUrl = command.BigİmageUrl;
            values.BrandID = command.BrandID;
            values.Km  = command.Km;
            values.CoverİmageUrl = command.CoverİmageUrl;
            values.Luggage = command.Luggage;
            values.Model = command.Model;
            values.Seat = command.Seat;

            await _repository.UpdateAsync(values);
        }
    }
}
