﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.Mediator.Results.AppUserResults;
using MediatR;

 namespace CarGo.Application.Features.Mediator.Queries.AppUserQueries
 {
     public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
     {
        public string Username { get; set; }
        public string Password { get; set; }
    }
 }
