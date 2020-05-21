using Lil.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Search.Interfaces
{
    public interface ISalesService
    {
        Task<ICollection<Order>> GetAllAsync();
        Task<ICollection<Order>> GetAsync(string CustomerId);
    }
}
