using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarGo.Application.Features.Mediator.Commands.PricingCommand
{
    public class UpdatePricingCommand : IRequest
    {
        public int PricingId { get; set; }

        public string Name { get; set; }
    }
}
