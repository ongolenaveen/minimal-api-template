namespace Api.Template.Domain.Interfaces
{
    public interface ICustomerDataProvider
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomer(int id);

        Task CreateCustomer(Customer customer);

    }
}
