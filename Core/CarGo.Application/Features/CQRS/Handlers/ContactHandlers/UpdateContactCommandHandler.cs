﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.CQRS.Commands.ContactCommands;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;

namespace CarGo.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {

        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var values = await _repository.GetByIdAsync(command.ContactId);
            values.Name = command.Name;
            values.Email = command.Email;
            values.Subject = command.Subject;
            values.Message = command.Message;
            values.SendDate = command.SendDate;

            await _repository.UpdateAsync(values);
        }
    }
}
