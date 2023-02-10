using Inventories.Services.StockAPI.Models.StockDto;
using Inventories.Services.StockAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Inventories.Services.StockAPI.Controllers
{
    [Route("api/stocks")]
    public class StockAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IStockRepository _stockRepository;

        public StockAPIController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<StockDto> stockDtos = await _stockRepository.GetStocks();
                _response.Result = stockDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                StockDto stockDto = await _stockRepository.GetStockById(id);
                _response.Result = stockDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] StockDto stockDto)
        {
            try
            {
                StockDto model = await _stockRepository.CreateUpdateStock(stockDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] StockDto stockDto)
        {
            try
            {
                StockDto model = await _stockRepository.CreateUpdateStock(stockDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _stockRepository.DeleteStock(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
