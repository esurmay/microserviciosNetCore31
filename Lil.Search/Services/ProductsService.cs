using Lil.Search.Interfaces;
using Lil.Search.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class ProductsService : IProductsService
    {

        private readonly IHttpClientFactory httpClientFactory;

        public ProductsService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            var client = httpClientFactory.CreateClient("productsService");

            var response = await client.GetAsync($"api/products");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(content);
                return products;
            }

            return null;
        }

        public async Task<Product> GetProductAsync(string id)
        {
            var client = httpClientFactory.CreateClient("productsService");
            var response = await client.GetAsync($"api/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);
                return product;
            }

            return null;
        }
    }
}
