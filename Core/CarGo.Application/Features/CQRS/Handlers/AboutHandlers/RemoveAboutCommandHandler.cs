using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using CarGo.Application.Features.CQRS.Commands.AboutCommand;
using CarGo.Application.interfaces;

namespace CarGo.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        
        public async Task Handle(RemoveAboutCommand command)
        {
            var value =await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }



    }
}
