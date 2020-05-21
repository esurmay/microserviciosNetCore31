using Lil.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Search.Interfaces
{
    public interface ICustomersService
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetCustomerAsync(string id);

    }
}
