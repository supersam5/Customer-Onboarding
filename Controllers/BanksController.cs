using Customer_Onboarding.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer_Onboarding.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly ICustomerRepository _CustomerRepository;

        public BanksController(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        // GET: api/<BanksController>
        [HttpGet]
        public async Task<String>  Get()
        {
            var result = await _CustomerRepository.GetBanks();

            string content = await result.Content.ReadAsStringAsync();

            

            return content;
        }
    }
}
