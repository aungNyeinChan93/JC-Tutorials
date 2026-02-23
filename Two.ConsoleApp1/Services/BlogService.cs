using Azure.Core;
using Database_02.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Two.ConsoleApp1.Services
{
    public class BlogService
    {

        private readonly string _url = "https://localhost:7026";

        private readonly RestClient _rest;

        public BlogService()
        {
            _rest = new RestClient(this._url);
        }

        public async Task<List<TblBlog>?> GetAllBLogsAsync()
        {
            var request = new RestRequest("/api/blogs", Method.Get);
            var result = await _rest.GetAsync<List<TblBlog>>(request);
            return result;
        }

        public async Task<TblBlog?> GetOneAsync(int id)
        {
            var request = new RestRequest($"/api/blogs/{id}", Method.Get);

            var blog = await _rest.GetAsync<TblBlog>(request);

            return blog;
        }

        public async Task<TblBlog?> CreateAsync(TblBlog blog)
        {
            var req = new RestRequest("/api/blogs", Method.Post);
            req.AddJsonBody(blog);
            var newBlog = await _rest.PostAsync<TblBlog>(req);
            return newBlog;
        }

        public async Task<TblBlog?> UpdateAsync(int id,TblBlog blog)
        {
            var req = new RestRequest($"/api/blogs/{id}", Method.Put);
            req.AddJsonBody(blog);
            var updateBlog = await _rest.PutAsync<TblBlog>(req);
            return updateBlog;
        }

        public async Task<bool> DeleteASync(int id)
        {
            var req = new RestRequest($"/api/blogs/{id}", Method.Delete);
            var result = await _rest.DeleteAsync(req);
            if(result.IsSuccessStatusCode) return true;
            return false;
        }

    }
}
