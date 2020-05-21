using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Products.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;
        public ProductsController(IProductsProvider productProvider)
        {
            this.productsProvider = productProvider;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await productsProvider.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await productsProvider.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

    }
}