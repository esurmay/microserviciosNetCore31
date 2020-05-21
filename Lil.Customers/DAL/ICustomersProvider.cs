using Lil.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Customers.DAL
{
    public interface ICustomersProvider
    {
        Task<Customer> GetAsync(string id);
        Task<List<Customer>> GetAllAsync();
    } 
}
