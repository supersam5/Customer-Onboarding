using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Customer_Onboarding.Models;
using Customer_Onboarding.Repositories;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer_Onboarding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomersController (ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer Customer)
        {

        }

        
    }
}
