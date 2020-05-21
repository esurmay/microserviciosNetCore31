using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Search.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICustomersService customersService;
        private readonly IProductsService productsService;
        private readonly ISalesService salesService;
        public SearchController(ICustomersService customersService, IProductsService productsService,
            ISalesService salesService)
        {
            this.customersService = customersService;
            this.productsService = productsService;
            this.salesService = salesService;
        }

        [HttpGet("customers")]
        public async Task<IActionResult> SearchAsync() 
        {
            
            try
            {
                var customer = await customersService.GetAllAsync();
                var sales = await salesService.GetAllAsync();

                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("customers/{CustomerId}")]
        public async Task<IActionResult> SearchByIdAsync(string CustomerID)
        {
            if (string.IsNullOrWhiteSpace(CustomerID))
            {
                return BadRequest();
            }

            try
            {
                var customer = await customersService.GetCustomerAsync(CustomerID);
                var sales = await salesService.GetAsync(CustomerID);

                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };

                foreach (var sale in sales)
                {
                    foreach (var item in sale.Items)
                    {
                        var product = await productsService.GetProductAsync(item.ProductId);
                        item.Product = product;
                    }
                }

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}