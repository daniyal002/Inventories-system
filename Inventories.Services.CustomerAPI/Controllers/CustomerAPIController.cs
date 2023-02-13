using Inventories.Services.CustomerAPI.Models.CustomerDto;
using Inventories.Services.CustomerAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Inventories.Services.CustomerAPI.Controllers
{
    [Route("api/customers")]
    public class CustomerAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private ICustomerRepository _customerRepository;

        public CustomerAPIController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<CustomerDto> customerDtos = await _customerRepository.GetCustomers();
                _response.Result = customerDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                CustomerDto customerDto = await _customerRepository.GetCustomerById(id);
                _response.Result = customerDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] CustomerDto customerDto)
        {
            try
            {
                CustomerDto model = await _customerRepository.CreateUpdateCustomer(customerDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] CustomerDto customerDto)
        {
            try
            {
                CustomerDto model = await _customerRepository.CreateUpdateCustomer(customerDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        public async Task<object> Delete(int customerId)
        {
            try
            {
                bool isSuccess = await _customerRepository.DeleteCustomer(customerId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }
    }
}
