using Database_02.Models;
using Microsoft.EntityFrameworkCore;

namespace five.WebApi.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _db;

        public BlogService(AppDbContext db)
        {
            _db = db;
        }

        public List<TblBlog>? GetAllBlogs()
        {
            var blogs = _db.TblBlogs.AsNoTracking().ToList();
            return blogs;
        }


    }
}
