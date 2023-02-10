using System.ComponentModel.DataAnnotations;

namespace Inventories.Services.WarehouseAPI.Models.WarehouseDto
{
    public class WarehouseDto
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseLocation { get; set; }
    }
}
