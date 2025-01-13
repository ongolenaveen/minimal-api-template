using Api.Template.Domain;
using Api.Template.Domain.Interfaces;
using Api.Template.Services.Interfaces;

namespace Api.Template.Services
{
    public class CustomerService(ICustomerDataProvider customerDataProvider) : ICustomerService
    {
        public async Task<List<Customer>> GetCustomers()
        {
            return await customerDataProvider.GetCustomers();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await customerDataProvider.GetCustomer(id);
        }

        public async Task CreateCustomer(Customer customer)
        {
            await customerDataProvider.CreateCustomer(customer);
        }
    }
}
