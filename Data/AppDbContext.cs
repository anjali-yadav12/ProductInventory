using Microsoft.EntityFrameworkCore;
using Product_Inventory.Models;

namespace Product_Inventory.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
