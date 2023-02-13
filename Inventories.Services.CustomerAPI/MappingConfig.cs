using AutoMapper;
using Inventories.Services.CustomerAPI.Models;
using Inventories.Services.CustomerAPI.Models.CustomerDto;

namespace Inventories.Services.CustomerAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<CustomerDto, Customer>();
                config.CreateMap<Customer, CustomerDto>();
            });

            return mappingConfiguration;
        }
    }
}
