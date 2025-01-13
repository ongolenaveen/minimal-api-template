using Api.Template.Domain;

namespace Api.Template.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomer(int id);

        Task CreateCustomer(Customer customer);
    }
}
