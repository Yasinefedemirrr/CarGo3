using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;

namespace CarGo.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery: IRequest<List<GetFooterAddressQueryResult>>
    {

    }
}
