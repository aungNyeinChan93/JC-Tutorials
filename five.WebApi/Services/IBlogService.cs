using Database_02.Models;

namespace five.WebApi.Services
{
    public interface IBlogService
    {
        List<TblBlog>? GetAllBlogs();
    }
}