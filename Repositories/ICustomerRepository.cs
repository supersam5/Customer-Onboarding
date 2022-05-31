using Customer_Onboarding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Onboarding.Repositories
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        IEnumerable<Customer> GetCustomers();

        Task<bool> async VerifyCustomer(String Phone);
    }
}
