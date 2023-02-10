using AutoMapper;
using Inventories.Services.StockAPI.Models;
using Inventories.Services.StockAPI.Models.StockDto;

namespace Inventories.Services.StockAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<StockDto, Stock>();
                config.CreateMap<Stock, StockDto>();
            });

            return mappingConfiguration;
        }
    }
}
