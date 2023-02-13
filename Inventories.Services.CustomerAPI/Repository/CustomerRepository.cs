using AutoMapper;
using Inventories.Services.CustomerAPI.DbContexts;
using Inventories.Services.CustomerAPI.Models;
using Inventories.Services.CustomerAPI.Models.CustomerDto;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Services.CustomerAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _applicationDb;
        private IMapper _mapper;


        public CustomerRepository(ApplicationDbContext applicationDb, IMapper mapper)
        {
            _applicationDb = applicationDb;
            _mapper = mapper;
        }

        public async Task<CustomerDto> CreateUpdateCustomer(CustomerDto customerDto)
        {
            Customer customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            if (customer.CustomerId > 0)
            {
                _applicationDb.Customers.Update(customer);
            }
            else
            {
                _applicationDb.Customers.Add(customer);
            }

            await _applicationDb.SaveChangesAsync();
            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            try
            {
                Customer customer = await _applicationDb.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);

                if (customer == null)
                {
                    return false;
                }

                _applicationDb.Customers.Remove(customer);
                await _applicationDb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CustomerDto> GetCustomerById(int customerId)
        {
            Customer customer = await _applicationDb.Customers.Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            List<Customer> customerList = await _applicationDb.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDto>>(customerList);
        }
    }
}
