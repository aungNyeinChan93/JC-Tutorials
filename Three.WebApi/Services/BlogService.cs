using Database_02.Models;
using Microsoft.EntityFrameworkCore;

namespace Three.WebApi.Services
{
    public class BlogService
    {
        private readonly AppDbContext _db;

        public BlogService(AppDbContext db) // Constructor Dependency injection
        {
            _db = db;
        }

        public List<TblBlog>? GetAll()
        {
            var blogs = _db.TblBlogs.AsNoTracking().ToList();
            return blogs;
        }

        public TblBlog? GetOne(int id)
        {
            var blog = _db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
            return blog;
        }
    }
}
