using AutoMapper;
using Inventories.Services.StockAPI.DbContexts;
using Inventories.Services.StockAPI.Models;
using Inventories.Services.StockAPI.Models.StockDto;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Services.StockAPI.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _applicationDb;
        private IMapper _mapper;

        public StockRepository(ApplicationDbContext applicationDb, IMapper mapper)
        {
            _applicationDb = applicationDb;
            _mapper = mapper;
        }


        public async Task<StockDto> CreateUpdateStock(StockDto stockDto)
        {
            Stock stock = _mapper.Map<StockDto, Stock>(stockDto);

            if (stock.StockId > 0)
            {
                _applicationDb.Stocks.Update(stock);
            }
            else
            {
                _applicationDb.Stocks.Add(stock);
            }

            await _applicationDb.SaveChangesAsync();
            return _mapper.Map<Stock, StockDto>(stock);
        }

        public async Task<bool> DeleteStock(int stockId)
        {
            try
            {
                Stock stock = await _applicationDb.Stocks.FirstOrDefaultAsync(x => x.StockId == stockId);

                if (stock == null)
                {
                    return false;
                }

                _applicationDb.Stocks.Remove(stock);
                await _applicationDb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<StockDto> GetStockById(int stockId)
        {
            Stock stock = await _applicationDb.Stocks.Where(x => x.StockId == stockId).FirstOrDefaultAsync();
            return _mapper.Map<StockDto>(stock);
        }

        public async Task<IEnumerable<StockDto>> GetStocks()
        {
            List<Stock> stockList = await _applicationDb.Stocks.ToListAsync();
            return _mapper.Map<List<StockDto>>(stockList);
        }
    }
}
