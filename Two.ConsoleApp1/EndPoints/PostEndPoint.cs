using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Two.ConsoleApp1.Models;
using Two.ConsoleApp1.Services;

namespace Two.ConsoleApp1.EndPoints
{
    public class PostEndPoint
    {
        private readonly PostService _service;

        public PostEndPoint()
        {
            _service = new PostService();
        }

        public async Task<Posts?> GetAllPostsAsync()
        {
            var posts = await _service.GetAllAsync();
            return posts;
        }

        public async Task<Post?> GetOnePostAsync(int id)
        {
            var post = await _service.GetOneAsync(id);
            return post;
        }

        public async Task<Post?> CreatePostAsync(Post post)
        {
            var p = await _service.CreateAsync(post);
            return p;
        }


    }
}
