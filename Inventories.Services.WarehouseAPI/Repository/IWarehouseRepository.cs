using Inventories.Services.WarehouseAPI.Models.WarehouseDto;

namespace Inventories.Services.WarehouseAPI.Repository
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<WarehouseDto>> GetWarehouse();
        Task<WarehouseDto> GetWarehouseById(int warehouseId);
        Task<WarehouseDto> CreateUpdateWarehouse(WarehouseDto warehouseDto);
        Task<bool> DeleteWarehouse(int warehouseId);
    }
}
