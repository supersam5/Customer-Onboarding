using Customer_Onboarding.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Customer_Onboarding.Repositories
{
    public interface ICustomerRepository
    {
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        IEnumerable<Customer> GetCustomers();

        Task<bool> VerifyCustomer(String Phone);

        Task<HttpResponseMessage>  GetBanks();
        public bool checklga(int stateid, int lgaid);
    }
}
