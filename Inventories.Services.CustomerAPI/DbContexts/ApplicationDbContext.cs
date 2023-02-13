using Inventories.Services.CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Services.CustomerAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
