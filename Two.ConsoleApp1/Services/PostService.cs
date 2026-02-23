using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Two.ConsoleApp1.Models;

namespace Two.ConsoleApp1.Services
{
    public class PostService
    {
        private readonly string _url = "https://dummyjson.com/posts";

        private HttpClient _client;

        public PostService()
        {
            _client = new HttpClient();
        }

        public async Task<Posts?> GetAllAsync()
        {
            var response = await _client.GetAsync($"{this._url}");
            if (!response.IsSuccessStatusCode) return null;
            var resultStr = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<Posts>(resultStr);
            return posts;
        }

        public async Task<Post?> GetOneAsync(int id)
        {
            var response = await _client.GetAsync($"{this._url}/{id}");
            if (!response.IsSuccessStatusCode) return null;
            var resultStr = await response.Content.ReadAsStringAsync();
            var post = JsonConvert.DeserializeObject<Post>(resultStr);
            return post;

        }

        public async Task<Post?> CreateAsync(Post post)
        {
            var postStr = JsonConvert.SerializeObject(post);
            var contect = new StringContent(postStr, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"https://dummyjson.com/posts/add", contect);
            if (!response.IsSuccessStatusCode) return null;

            var postsStr = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<Post>(postsStr);
            return p;

        }
    }
}
