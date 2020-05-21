using Lil.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Products.DAL
{
    public interface IProductsProvider
    {
        Task<Product> GetAsync(string id);
        Task<List<Product>> GetAllAsync();
    }
}
