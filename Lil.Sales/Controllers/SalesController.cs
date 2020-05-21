using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Sales.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lil.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesProvider salesProvider;

        public SalesController(ISalesProvider salesProvider)
        {
            this.salesProvider = salesProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {

            var result = await salesProvider.GetAllAsync();
            if (result != null && result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{CustomerId}")]
        public async Task<IActionResult> GetAsync(string CustomerId)
        {

            var result = await salesProvider.GetAsync(CustomerId);
            if (result != null && result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}