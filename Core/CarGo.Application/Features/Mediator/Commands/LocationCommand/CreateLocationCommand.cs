using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarGo.Application.Features.Mediator.Commands.LocationCommand
{
    public class CreateLocationCommand : IRequest
    {
        public string Name { get; set; }
    }
}
