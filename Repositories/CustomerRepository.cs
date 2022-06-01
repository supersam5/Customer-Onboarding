using Customer_Onboarding.Models;
using Customer_Onboarding.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Customer_Onboarding.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly APIDbContext _dbContext;

        public CustomerRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer AddCustomer(Customer customer)
        {
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }
        public Customer UpdateCustomer(Customer customer)
        {
            _dbContext.Update(customer);
            _dbContext.SaveChanges();
            return customer;
        }
        public async Task<bool> VerifyCustomer(string Phone)
        {
            bool success = true;
           bool getSuccess(bool input){
                return input;
            };
            await Task.Delay(1000);
            
           
            return await Task.Run(()=> getSuccess(success));
        }
        public async Task<HttpResponseMessage>GetBanks()
        {
            client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cfe1368898bc4dcbbd1ea7f0bfe8f72e");
            var uri = "https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks";

            return await client.GetAsync(uri);
        }

        public bool checklga(int stateid, int lgaid)
        {
            State state= _dbContext.States.Find(stateid);
            if(state == null)
            {
                return false;
            }else
            {
                if (_dbContext.LocalGovtAreas.Find(lgaid) != null)
                {
                    List<State> isValidLga = new List<State>();
                    isValidLga = (List<State>)from lstate in _dbContext.States
                                              join lga in _dbContext.LocalGovtAreas on state.Id equals lga.StateId
                                              select _dbContext.States.ToList<State>();
                    if (isValidLga.Count < 1) return false;
                } else return false;
            }return true;
        }


    }
}
