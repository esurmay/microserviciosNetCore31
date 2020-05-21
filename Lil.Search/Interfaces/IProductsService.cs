using Lil.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Search.Interfaces
{
    public interface IProductsService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetProductAsync(string id);

    }
}
