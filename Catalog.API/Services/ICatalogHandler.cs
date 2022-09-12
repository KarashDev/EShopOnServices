namespace Catalog.API.Services
{
    public interface ICatalogHandler
    {
        Task AddCategory(Category category);
        Task AddManufacturer(Manufacturer manufacturer);
        Task AddProduct(Product product);

        List<Product> GetCatalog();

        Product SearchProduct(string productName, string manufacturerName);
    }

    public class CatalogHandler : ICatalogHandler
    {
        HttpClient client;

        public CatalogHandler(HttpClient client)
        {
            this.client = client;
        }

        public async Task AddCategory(Category category)
        {
            using (CatalogContext db = new CatalogContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public async Task AddManufacturer(Manufacturer manufacturer)
        {
            using (CatalogContext db = new CatalogContext())
            {
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();

            }
        }

        public async Task AddProduct(Product product)
        {
            using (CatalogContext db = new CatalogContext())
            {
                db.Products.Add(product);
                db.SaveChanges();

            }
        }

        public List<Product> GetCatalog()
        {
            using (CatalogContext db = new CatalogContext())
            {
                var products = db.Products.Include(p => p.Manufacturer).Include(p => p.Category).ToList();
                return products;
            }
        }

        public Product SearchProduct(string productName, string manufacturerName)
        {
            using (CatalogContext db = new CatalogContext())
            {

                var matchedProduct = db.Products.FirstOrDefault(p => p.ProductName == productName
                                                                 && p.Manufacturer.ManufacturerName == manufacturerName);
                return matchedProduct;
            }
        }
    }
}
