using Api.Template.Domain;
using Api.Template.Domain.Interfaces;

namespace Api.Template.Sql.DataProvider.DataProviders
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        public async Task<List<Customer>> GetCustomers()
        {
            var customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "naveen", Email = "naveen.papisetty@outlook.com" }
            };
            return await Task.FromResult(customers);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = new Customer { Id = 1, Name = "naveen", Email = "naveen.papisetty@outlook.com" };
            return await Task.FromResult(customer);
        }

        public async Task CreateCustomer(Customer customer)
        {
            await Task.CompletedTask;
        }
    }
}