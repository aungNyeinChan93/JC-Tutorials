using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using One.ConsoleApp1.Models;


namespace One.ConsoleApp1.EndPoint
{
    public class PostEndPoint
    {
        private readonly RestClient _rest;

        private readonly string _url = "https://dummyjson.com";

        public PostEndPoint()
        {
            this._rest = new RestClient(this._url);
        }

        public async Task<Posts?> GetAll()
        {
            var request = new RestRequest("posts",Method.Get);
            var response = await _rest.GetAsync<Posts>(request);
            return response;
        }

        public async Task<Post?> GetOneAsync(int id)
        {
            var response = await _rest.GetAsync<Post>(new RestRequest($"posts/{id}", Method.Get));
            return response;
        }

        public async Task<Post?> CreateAsync(Post post)
        {
            var request = new RestRequest("posts/add", Method.Post);
            request.AddJsonBody(post);
            var response = await _rest.PostAsync<Post>(request);
            //Console.WriteLine(response!.Content);
            return response;

        }

        public async Task UpdateAsync(int id,Post post)
        {
            var request = new RestRequest($"posts/{id}", Method.Patch);
            request.AddJsonBody(post);

            //var response = await _rest.PatchAsync<Post>(request);
            var response = await _rest.ExecuteAsync<Post>(request);
            Console.WriteLine(response.Content);
        }

        public async Task<RestResponse> DeleteAsync(int id)
        {
            var request = new RestRequest($"posts/{id}", Method.Delete);
            var response = await _rest.DeleteAsync(request);
            return response;
        }
    }
}
