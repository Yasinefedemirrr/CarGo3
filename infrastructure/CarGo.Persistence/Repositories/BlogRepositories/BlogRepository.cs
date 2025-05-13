using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cargo.Domain.Entities;
using CarGo.Application.interfaces.BlogInterfaces;
using CarGo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarGo.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarGoContext _carGoContext;

        public BlogRepository(CarGoContext carGoContext)
        {
            _carGoContext = carGoContext;
        }

        public List<Blog> GetAllBlogsWithAuthor()
        {
            var values = _carGoContext.Blogs.Include(x => x.Author).ToList();
            return values;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
           var values = _carGoContext.Blogs.Include(x=>x.Author).Where(y=>y.BlogID == id).ToList();
            return values;
        }

        public  List<Blog> GetLast3BlogsWithAuthors()
        {
            var values = _carGoContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
            return values;
        }
    }
}
