using Microsoft.EntityFrameworkCore;

namespace Delivery.API.Database
{
    public class DeliveryContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<ProductsInOrder> ProductsInOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=deliverydb;Trusted_Connection=True;");
        }
    }
}
