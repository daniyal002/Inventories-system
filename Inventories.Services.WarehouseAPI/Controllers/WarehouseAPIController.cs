using Inventories.Services.WarehouseAPI.Models.WarehouseDto;
using Inventories.Services.WarehouseAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Inventories.Services.WarehouseAPI.Controllers
{
    [Route("api/warehouses")]
    public class WarehouseAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IWarehouseRepository _warehouseRepository;

        public WarehouseAPIController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<WarehouseDto> warehouseDtos = await _warehouseRepository.GetWarehouse();
                _response.Result = warehouseDtos;
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
                WarehouseDto warehouseDto = await _warehouseRepository.GetWarehouseById(id);
                _response.Result = warehouseDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] WarehouseDto warehouseDto) 
        {
            try
            {
                WarehouseDto model = await _warehouseRepository.CreateUpdateWarehouse(warehouseDto);
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
        public async Task<object> Put([FromBody] WarehouseDto warehouseDto)
        {
            try
            {
                WarehouseDto model = await _warehouseRepository.CreateUpdateWarehouse(warehouseDto);
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
        public async Task<object> Delete(int warehouseId)
        {
            try
            {
                bool isSuccess = await _warehouseRepository.DeleteWarehouse(warehouseId);
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
