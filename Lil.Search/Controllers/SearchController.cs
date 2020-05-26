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



        #region Customers
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

        #endregion   

        #region Products
        [HttpGet("products")]
        public async Task<IActionResult> SearchProductsAsync()
        {

            try
            {
                var products = await productsService.GetAllAsync();
                var sales = await salesService.GetAllAsync();

                var result = new
                {
                    Products = products,
                    Sales = sales
                };

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> SearchProductsByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            try
            {
                var product = await productsService.GetProductAsync(id);
                
                var result = new
                {
                    Product = product,
                };                

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Sales
        [HttpGet("sales")]
        public async Task<IActionResult> SearchSalessAsync()
        {

            try
            {
                var sales = await salesService.GetAllAsync();
                var result = new
                {
                    Sales = sales
                };

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("sales/{CustomerId}")]
        public async Task<IActionResult> SearchSalesByIdAsync(string CustomerId)
        {
            if (string.IsNullOrWhiteSpace(CustomerId))
            {
                return BadRequest();
            }

            try
            {
                var sales = await salesService.GetAsync(CustomerId);

                var result = new
                {
                    Sales = sales,
                };

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


    }
}