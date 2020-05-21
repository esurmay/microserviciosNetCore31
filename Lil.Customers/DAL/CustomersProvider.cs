using Lil.Customers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Customers.DAL
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly List<Customer> repo = new List<Customer>();
        public CustomersProvider()
        {
            repo.Add(new Customer(){ Id = "1", Name = "Roger", City = "Madrid" });
            repo.Add(new Customer(){ Id = "2", Name = "Edward", City = "NY City" });
            repo.Add(new Customer(){ Id = "3", Name = "Surmay", City = "London" });
            repo.Add(new Customer(){ Id = "4", Name = "Arrioja", City = "Caracas" });
        }

        public Task<List<Customer>> GetAllAsync()
        {
            List<Customer> customers = repo;
            return Task.FromResult(customers);
        }

        public Task<Customer> GetAsync(string id)
        {
            var customer = repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(customer);
        }
    }
}
