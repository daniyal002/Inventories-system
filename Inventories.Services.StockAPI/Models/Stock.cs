using System.ComponentModel.DataAnnotations;

namespace Inventories.Services.StockAPI.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        [Required]
        public string StockName { get; set;}
    }
}
