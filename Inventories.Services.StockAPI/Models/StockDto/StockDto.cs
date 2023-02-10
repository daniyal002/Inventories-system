using System.ComponentModel.DataAnnotations;

namespace Inventories.Services.StockAPI.Models.StockDto
{
    public class StockDto
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
    }
}
