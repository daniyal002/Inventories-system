using AutoMapper;
using Inventories.Services.WarehouseAPI.DbContexts;
using Inventories.Services.WarehouseAPI.Models;
using Inventories.Services.WarehouseAPI.Models.WarehouseDto;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Services.WarehouseAPI.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly ApplicationDbContext _applicationDb;
        private IMapper _mapper;

        public WarehouseRepository(ApplicationDbContext applicationDb, IMapper mapper)
        {
            _applicationDb = applicationDb;
            _mapper = mapper;
        }


        public async Task<WarehouseDto> CreateUpdateWarehouse(WarehouseDto warehouseDto)
        {
            Warehouse warehouse = _mapper.Map<WarehouseDto, Warehouse>(warehouseDto);

            if (warehouse.WarehouseId> 0)
            {
                _applicationDb.Warehouses.Update(warehouse);
            }
            else
            {
                _applicationDb.Warehouses.Add(warehouse);
            }

            await _applicationDb.SaveChangesAsync();
            return _mapper.Map<Warehouse, WarehouseDto>(warehouse);
        }

        public async Task<bool> DeleteWarehouse(int warehouseId)
        {
            try
            {
                Warehouse warehouse = await _applicationDb.Warehouses.FirstOrDefaultAsync(x => x.WarehouseId == warehouseId);

                if (warehouse == null)
                {
                    return false;
                }

                _applicationDb.Warehouses.Remove(warehouse);
                await _applicationDb.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<WarehouseDto>> GetWarehouse()
        {
            List<Warehouse> warehouseList = await _applicationDb.Warehouses.ToListAsync();
            return _mapper.Map<List<WarehouseDto>>(warehouseList);
        }

        public async Task<WarehouseDto> GetWarehouseById(int warehouseId)
        {
            Warehouse warehouse = await _applicationDb.Warehouses.Where(x => x.WarehouseId == warehouseId).FirstOrDefaultAsync();
            return _mapper.Map<WarehouseDto>(warehouse);
        }
    }
}
