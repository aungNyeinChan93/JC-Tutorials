using Database_02.Models;

namespace Three.WebApi.Services
{
    public interface IBlogService
    {
        TblBlog? Create(TblBlog blog);
        bool Delete(int id);
        List<TblBlog>? GetAll();
        TblBlog? GetOne(int id);
        TblBlog? Update(int id, TblBlog blog);
    }
}