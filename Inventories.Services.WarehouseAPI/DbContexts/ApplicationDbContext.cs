using Inventories.Services.WarehouseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Services.WarehouseAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
