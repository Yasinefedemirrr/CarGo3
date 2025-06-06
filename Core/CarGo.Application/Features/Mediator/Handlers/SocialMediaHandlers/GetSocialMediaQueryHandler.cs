﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarGo.Application.Features.Mediator.Results.SocialMediaResults;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using MediatR;

namespace CarGo.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSocialMediaQueryResult
            {
               Name = x.Name,
               Icon = x.Icon,
               SocialMediaID = x.SocialMediaID,
               Url = x.Url
               
            }).ToList();
        }
    }

}
