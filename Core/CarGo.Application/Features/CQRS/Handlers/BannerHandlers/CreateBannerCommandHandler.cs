﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using CarGo.Application.Features.CQRS.Commands.AboutCommand;
using CarGo.Application.Features.CQRS.Commands.BannerCommands;
using CarGo.Application.interfaces;

namespace CarGo.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBannerCommand command)
        {
            await _repository.CreateAsync(new Banner
            {
               Description = command.Description,
               Title = command.Title,
               VideoDescription = command.VideoDescription,
               VideoUrl = command.VideoUrl,
               
               
            });
        }

    }
}
