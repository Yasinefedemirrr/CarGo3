using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;

namespace CarGo.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery : IRequest<GetCarDescriptionQueryResult>
    {
        public int Id { get; set; }

        public GetCarDescriptionByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
