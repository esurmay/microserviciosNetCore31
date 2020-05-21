using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Customers.DAL;
using Lil.Customers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customerProvider;
        public CustomersController(ICustomersProvider customerProvider)
        {
            this.customerProvider = customerProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await customerProvider.GetAllAsync();
            if (customers != null)
            {
                return Ok(customers);
            }

            return NotFound();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var customers = await customerProvider.GetAsync(id);
            if (customers != null)
            {
                return Ok(customers);
            }

            return NotFound();

        }
    }
}