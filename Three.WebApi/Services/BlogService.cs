using Database_02.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Three.WebApi.Services
{
    public class BlogService // Basiness layer 
    {
        private readonly AppDbContext _db; // <== add db layer 

        public BlogService(AppDbContext db) // Constructor Dependency injection
        {
            this._db = db;
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

        public TblBlog? Create(TblBlog blog)
        {
            _db.Add(blog);
            var res = _db.SaveChanges();
            return res >= 1? blog :null;
        }

        public TblBlog? Update(int id, TblBlog blog)
        {
            var updateBlog = _db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);

            updateBlog!.Title = blog.Title;
            updateBlog!.Description = blog.Description;
            updateBlog!.AuthorName = blog.AuthorName;

            _db.Entry(updateBlog).State = EntityState.Modified;
            var res = _db.SaveChanges();
            return res >= 1 ? updateBlog : null;
        }

        public bool Delete(int id)
        {
            var blog = _db.TblBlogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
            if(blog is null) return false;

            _db.Entry(blog).State = EntityState.Deleted;
            int res = _db.SaveChanges();
            return res >= 1;
        }
    }
}
