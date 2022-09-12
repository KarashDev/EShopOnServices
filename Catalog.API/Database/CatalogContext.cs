using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Database
{
    public class CatalogContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=catalogdb;Trusted_Connection=True;");
        }


    }
}
