using AutoMapper;
using Inventories.Services.WarehouseAPI.Models;
using Inventories.Services.WarehouseAPI.Models.WarehouseDto;

namespace Inventories.Services.WarehouseAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<WarehouseDto, Warehouse>();
                config.CreateMap<Warehouse, WarehouseDto>();
            });

            return mappingConfiguration;
        }
    }
}
