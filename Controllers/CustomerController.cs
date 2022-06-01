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
        public IActionResult Get()
        {
            var products = _CustomerRepository.GetCustomers();
            return new OkObjectResult(products);
        }


        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult>  Post([FromBody] Customer Customer)
        {
            Task<bool> verified;
            
            
            if (ModelState.IsValid || _CustomerRepository.checklga(Customer.StateId, Customer.LocalGovtId))
            {
                verified = _CustomerRepository.VerifyCustomer(Customer.Phone);
                _CustomerRepository.AddCustomer(Customer);
                if (await verified == true) {
                Customer.IsConfirmed = true;
                _CustomerRepository.UpdateCustomer(Customer);
                }
                return Ok();
            }
            else
            {
                return StatusCode(405);
            }
        }
        

        
    }
}
