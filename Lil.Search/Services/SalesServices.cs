using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class SalesServices : ISalesService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public SalesServices(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            var client = httpClientFactory.CreateClient("salesService");

            var response = await client.GetAsync($"api/sales");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var sales = JsonConvert.DeserializeObject<List<Order>>(content);
                return sales;
            }

            return null;
        }

        public async Task<ICollection<Order>> GetAsync(string CustomerId)
        {
            var client = httpClientFactory.CreateClient("salesService");
            var response = await client.GetAsync($"api/sales/{CustomerId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var order = JsonConvert.DeserializeObject<ICollection<Order>>(content);
                return order;
            }

            return null;
        }
    }
}
