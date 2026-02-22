using Newtonsoft.Json;
using One.ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace One.ConsoleApp1.EndPoint
{
    public class QuoteEndPoint
    {
        private readonly HttpClient _client = new (); 
        public async Task ReadAsync()
        {
            var response = await _client.GetAsync("https://dummyjson.com/quotes");

            if (!response.IsSuccessStatusCode) return;

            var resultStr = await response.Content.ReadAsStringAsync(); 

            var result = JsonConvert.DeserializeObject<Quotes>(resultStr);

            foreach (var quote in result!.quotes!)
            {
                Console.WriteLine($"Quote  = {quote.quote} \n");
            }

            Console.WriteLine("End ... ");
        }

        public async Task GetOneAsync(int id)
        {
            var response = await _client.GetAsync($"https://dummyjson.com/quotes/{id}");

            if (!response.IsSuccessStatusCode) return;

            var resultStr = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Quote>(resultStr);

            Console.WriteLine(result!.quote!.ToString());
        }

        public async Task CreateAsync(Quote quote)
        {
            var quoteStr = JsonConvert.SerializeObject(quote);
            var content = new StringContent(quoteStr, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://dummyjson.com/quotes", content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                Console.WriteLine("Create success!");
            }
        }
    }
}
