using System.ComponentModel.DataAnnotations;

namespace Inventories.Services.WarehouseAPI.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        [Required]
        public string WarehouseName { get; set; }
        [Required]
        public string WarehouseLocation { get; set; }
    }
}
