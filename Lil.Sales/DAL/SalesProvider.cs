using Lil.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Sales.DAL
{
    public class SalesProvider : ISalesProvider
    {

        private readonly List<Order> repo = new List<Order>();

        public SalesProvider()
        {
            repo.Add(new Order() { 

                Id = "0001",
                CustomerId = "1",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>() { 
                    new OrderItem() { 
                        OrderId = "0001" , Id =  1, 
                        Price = 50, 
                        ProductId = "23",
                        Quantity = 2
                    }
                }
            
            });

            repo.Add(new Order()
            {

                Id = "0002",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>() {
                    new OrderItem() {
                        OrderId = "0002" , Id =  1,
                        Price = 50,
                        ProductId = "24",
                        Quantity = 2
                    },
                    new OrderItem() {
                        OrderId = "0003" , Id =  1,
                        Price = 50,
                        ProductId = "25",
                        Quantity = 2
                    }
                }

            });

            repo.Add(new Order()
            {

                Id = "0003",
                CustomerId = "3",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>() {
                    new OrderItem() {
                        OrderId = "0004" , Id =  1,
                        Price = 50,
                        ProductId = "26",
                        Quantity = 2
                    },

                }

            });

            repo.Add(new Order()
            {

                Id = "0004",
                CustomerId = "3",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 100,
                Items = new List<OrderItem>() {
                    new OrderItem() {
                        OrderId = "0005" , Id =  1,
                        Price = 50,
                        ProductId = "27",
                        Quantity = 2
                    },
                    new OrderItem() {
                        OrderId = "0006" , Id =  1,
                        Price = 50,
                        ProductId = "28",
                        Quantity = 2
                    }
                }

            });
        }
        public Task<ICollection<Order>> GetAllAsync()
        {
            return Task.FromResult((ICollection<Order>)repo);
        }

        public Task<ICollection<Order>> GetAsync(string CustomerId)
        {
            var result = repo.Where(p => p.CustomerId == CustomerId).ToList();
            return Task.FromResult((ICollection<Order>)result);
        }
    }
}
