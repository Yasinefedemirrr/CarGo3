using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using MediatR;
using CarGo.Application.Features.Mediator.Results.LocationResults;
using CarGo.Application.Locations.Mediator.Queries.LocationQueries;

namespace CarGo.Application.Locations.Mediator.Handlers.LocationHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetBlogByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResult
            {
                LocationID = request.Id,
                Name = values.Name,
            };
        }
    }
    
    
}
