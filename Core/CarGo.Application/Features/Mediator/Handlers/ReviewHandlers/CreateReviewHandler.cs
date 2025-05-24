using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.Mediator.Commands.ReviewCommands;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using MediatR;

namespace CarGo.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;
        public CreateReviewHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            
            var utcReviewDate = DateTime.SpecifyKind(request.ReviewDate, DateTimeKind.Utc);

            await _repository.CreateAsync(new Review
            {
                CustomerImage =  request.CustomerImage,
                CarID =  request.CarID,
                Comment =  request.Comment,
                CustomerName =  request.CustomerName,
                RaytingValue =  request.RaytingValue,
                ReviewDate =  utcReviewDate
            });
        }
    }
}
