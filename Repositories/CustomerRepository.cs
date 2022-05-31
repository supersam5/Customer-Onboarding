using Customer_Onboarding.Models;
using Customer_Onboarding.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Customer_Onboarding.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly APIDbContext _dbContext;

        public CustomerRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _dbContext.Add(customer);
            _dbContext.SaveChanges();
        }
        public async Task<bool> VerifyCustomer(string Phone)
        {
            Task<bool> result;
            bool success = true;
            await result = success;
            return Task<bool> result;
        }


    }
}
