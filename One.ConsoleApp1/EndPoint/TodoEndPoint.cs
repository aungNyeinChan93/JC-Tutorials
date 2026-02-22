using Newtonsoft.Json;
using One.ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace One.ConsoleApp1.EndPoint
{
    public class TodoEndPoint
    {
        private readonly HttpClient _client;

        private readonly string _url = "https://dummyjson.com/todos";

        public TodoEndPoint()
        {
            this._client = new HttpClient();
        }

        public async Task<Todos?> ReadAllAsync()
        {
            var response = await _client.GetAsync(_url);

            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (response.IsSuccessStatusCode)
            {
                var resultStr = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Todos>(resultStr);

                return result;
            }
            return null;
        }

        public async Task<Todo?> GetOneAsync(int id)
        {
            var response = await _client.GetAsync($"{this._url}/{id}");
            var resultStr = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Todo>(resultStr);
            return result;
        }

        public async Task CreateAsync(Todo todo)
        {
            var todoStr = JsonConvert.SerializeObject(todo);
            var content = new StringContent(todoStr, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_url}/add", content);

            if (!response.IsSuccessStatusCode) return;

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }

        public async Task UpdateAsync(int id,Todo todo)
        {
            var todoStr = JsonConvert.SerializeObject(todo);
            var content  = new StringContent(todoStr,Encoding.UTF8, "application/json");

            var response = await _client.PatchAsync($"https://dummyjson.com/todos/{id}", content);
            if (!response.IsSuccessStatusCode) return;

            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_url}/{id}");
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        } 

    }
}
