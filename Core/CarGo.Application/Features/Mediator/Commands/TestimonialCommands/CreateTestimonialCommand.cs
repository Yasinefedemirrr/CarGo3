using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarGo.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class CreateTestimonialCommand : IRequest
    {
        public int TestimonialID { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string ımageUrl { get; set; }
    }
}
