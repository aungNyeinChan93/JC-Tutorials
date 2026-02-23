using Database_02.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Two.ConsoleApp1.Services;

namespace Two.ConsoleApp1.EndPoints
{
    public class BlogEndPoint
    {
        public readonly BlogService _service;

        public BlogEndPoint( )
        {
            _service = new BlogService();
        }

        public async Task<List<TblBlog>?> GetAllAsync()
        {
            var blogs =await _service.GetAllBLogsAsync();
            return blogs;
        }

        public async Task<TblBlog?> GetOneAsync(int id)
        {
            var blog = await _service.GetOneAsync(id);
            return blog;
        }

        public async Task<TblBlog?> CreateAsync(TblBlog blog)
        {
            var newBlog = await _service.CreateAsync(blog);
            return newBlog;
        }
        public async Task<TblBlog?> UpdateAsync(int id,TblBlog blog)
        {
            var updateBlog = await _service.UpdateAsync(id,blog);
            return updateBlog;
        }

        public async Task DeleteAsync(int id)
        {
            var res = await _service.DeleteASync(id);
            Console.WriteLine(res ? "Delete success":"delete fail");
        }
    }
}
