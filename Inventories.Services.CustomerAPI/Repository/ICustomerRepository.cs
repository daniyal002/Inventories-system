using Inventories.Services.CustomerAPI.Models.CustomerDto;

namespace Inventories.Services.CustomerAPI.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task<CustomerDto> GetCustomerById(int customerId);
        Task<CustomerDto> CreateUpdateCustomer(CustomerDto customerDto);
        Task<bool> DeleteCustomer(int customerId);
    }
}
