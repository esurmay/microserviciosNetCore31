using Lil.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Sales.DAL
{
    public interface ISalesProvider
    {
        Task<ICollection<Order>> GetAllAsync();
        Task<ICollection<Order>> GetAsync(string CustomerId);
    }
}
