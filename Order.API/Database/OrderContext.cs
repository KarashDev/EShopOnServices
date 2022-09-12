using Microsoft.EntityFrameworkCore;
using Order.API.Models;

namespace Order.API.Database
{
    public class OrderContext : DbContext
    {
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Product> ProductsInBasket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ordersdb;Trusted_Connection=True;");
        }
    }
}
