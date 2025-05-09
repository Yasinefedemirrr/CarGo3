using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarGo.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarQuery : IRequest<List<GetCarPricingWithCarQueryResult>>
    {
    }
}
