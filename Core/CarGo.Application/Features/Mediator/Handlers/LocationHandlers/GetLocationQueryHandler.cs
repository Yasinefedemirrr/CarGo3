using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using MediatR;
using CarGo.Application.Features.Mediator.Results.LocationResults;
using CarGo.Application.Features.Mediator.Queries.LocationQueries;

namespace CarGo.Application.Locations.Mediator.Handlers.LocationHandlers
{
    public class GetTagCloudQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetTagCloudQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationQueryResult
            {
               LocationID = x.LocationID,
               Name = x.Name,

            }).ToList();
        }
    }

}
