using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarGo.Application.Features.Mediator.Commands.ServiceCommand
{
    public class UpdateServiceCommand: IRequest
    {
        public int ServiceId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string İconUrl { get; set; }

    }
}
