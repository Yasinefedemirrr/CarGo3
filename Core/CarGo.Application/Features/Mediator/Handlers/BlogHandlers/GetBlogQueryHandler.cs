using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarGo.Application.interfaces;
using Cargo.Domain.Entities;
using MediatR;
using CarGo.Application.Features.Mediator.Results.BlogResults;
using CarGo.Application.Features.Mediator.Queries.BlogQueries;

namespace CarGo.Application.Blogs.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogQueryResult
            {
               BlogID = x.BlogID,
               AuthorID = x.AuthorID,
               CategoryID = x.CategoryID,
               CoverImageUrl = x.CoverImageUrl,
               CreatedDate = x.CreatedDate,
               Title = x.Title
            }).ToList();
        }
    }

}
