using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using MediatR;
using CarGo.Application.Features.Mediator.Commands.LocationCommand;

namespace CarGo.Application.Locations.Mediator.Handlers.LocationHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public CreateBlogCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Location
            {
                Name = request.Name,
            });
        }
    }

}
