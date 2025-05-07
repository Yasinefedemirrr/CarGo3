using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.CQRS.Commands.BannerCommands;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using CarGo.Application.Features.CQRS.Commands.BrandCommand;

namespace CarGo.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {         
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBrandCommand command)
        {
            await _repository.CreateAsync(new Brand
            {
                   Name = command.Name,              
            });
        }
    }
}

