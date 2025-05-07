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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateBlogCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.LocationID);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }

}
