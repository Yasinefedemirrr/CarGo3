using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using CarGo.Application.Features.CQRS.Results.BrandResults;
using CarGo.Application.Features.Mediator.Queries.FeatureQueries;
using CarGo.Application.Features.Mediator.Results.FeatureResults;
using CarGo.Application.interfaces;
using MediatR;

namespace CarGo.Application.Features.Mediator.Handlers.FeatureHandlers
{
   public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                Name = x.Name,

            }).ToList();
        }
    }
}
