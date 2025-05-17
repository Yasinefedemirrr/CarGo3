using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.Features.Mediator.Queries.BlogQueries;
using CarGo.Application.Features.Mediator.Results.BlogResults;
using CarGo.Application.interfaces;
using CarGo.Application.interfaces.BlogInterfaces;
using MediatR;

namespace CarGo.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;
        public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlogsWithAuthors();
            return values.Select(x => new GetLast3BlogsWithAuthorsQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.Name
                
            }).ToList();
        }
    }
}
