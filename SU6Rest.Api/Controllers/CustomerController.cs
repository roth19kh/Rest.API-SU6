using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SU6Rest.Api.Models;
using SU6Rest.Api.Services;

namespace SU6Rest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<List<Customer>> Get()
            => await _service.GetCustomers();

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Customer?> Get(Guid id)
            => await _service.GetCustomer(id);
        // POST: api/Customer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _service.Save(customer);
            if(result == "Success")
            {
                return Created("",customer);
            }
            return BadRequest(result);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
