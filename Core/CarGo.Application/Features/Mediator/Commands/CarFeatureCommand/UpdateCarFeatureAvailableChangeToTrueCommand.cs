using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarGo.Application.Features.Mediator.Commands.CarFeatureCommand
{
    public class UpdateCarFeatureAvailableChangeToTrueCommand : IRequest
    {
        public int Id { get; set; }

        public UpdateCarFeatureAvailableChangeToTrueCommand(int id)
        {
            Id = id;
        }
    }
}
