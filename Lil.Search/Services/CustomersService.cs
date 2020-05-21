using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CustomersService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            var client = httpClientFactory.CreateClient("customersService");

            var response = await client.GetAsync($"api/customers");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                return customers;
            }

            return null;
        }


        public async Task<Customer> GetCustomerAsync(string id)
        {
            var client = httpClientFactory.CreateClient("customersService");

            var response = await client.GetAsync($"api/customers/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<Customer>(content);
                return customers;
            }

            return null;
        }
    }
}
