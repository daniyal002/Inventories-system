using Inventories.Services.StockAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Services.StockAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
    }
}
