using Catalog.API.Models;

namespace Catalog.API.Database
{
    public static class DatabaseCreator
    {
        public static void CreateDataBase()
        {
            using (CatalogContext db = new CatalogContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                List<Category> categories = new List<Category>()
                {
                    new Category(){CategoryName = "Одежда"},
                    new Category(){CategoryName = "Обувь"},
                    new Category(){CategoryName = "Головные уборы"},
                    new Category(){CategoryName = "Аксессуары"},
                };

                List<Manufacturer> manufacturers = new List<Manufacturer>()
                {
                    new Manufacturer(){ManufacturerName = "Gucci"},
                    new Manufacturer(){ManufacturerName = "Addidas"},
                    new Manufacturer(){ManufacturerName = "Bitiz"},
                    new Manufacturer(){ManufacturerName = "Alden"},
                };

                db.Categories.AddRange(categories);
                db.Manufacturers.AddRange(manufacturers);
                db.SaveChanges();


                List<Product> products = new List<Product>()
                {
                    new Product(){ ProductName = "Шерстяная бейсболка", CategoryId = 3, ManufacturerId = 1},
                    new Product(){ ProductName = "Бумажник черный", CategoryId = 4, ManufacturerId = 3},
                    new Product(){ ProductName = "Куртка зимняя", CategoryId = 1, ManufacturerId = 4},
                    new Product(){ ProductName = "Кеды спортивные", CategoryId = 3, ManufacturerId = 2},
                };

                db.AddRange(products);
                db.SaveChanges();


                //var x = db.Products.ToList();



            }


        }
    }
}
