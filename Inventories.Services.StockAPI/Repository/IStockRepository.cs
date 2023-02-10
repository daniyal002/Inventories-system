using Inventories.Services.StockAPI.Models.StockDto;
using System.Collections;

namespace Inventories.Services.StockAPI.Repository
{
    public interface IStockRepository
    {
        Task<IEnumerable<StockDto>> GetStocks();
        Task<StockDto> GetStockById(int stockId);
        Task<StockDto> CreateUpdateStock(StockDto stockDto);
        Task<bool> DeleteStock(int stockId);
    }
}
