namespace Catalog.API.Services
{
    public interface ICatalogHandler
    {
        Task AddCategory();
        Task AddManufacturer();
        Task AddProduct();

        Task GetCatalog();

        Product SearchProduct(string productName, string manufacturerName);
    }

    public class CatalogHandler : ICatalogHandler
    {
        HttpClient client;

        public CatalogHandler(HttpClient client)
        {
            this.client = client;
        }

        public async Task AddCategory()
        {
            throw new NotImplementedException();
        }

        public async Task AddManufacturer()
        {
            throw new NotImplementedException();
        }

        public async Task AddProduct()
        {
            throw new NotImplementedException();
        }

        public async Task GetCatalog()
        {
            throw new NotImplementedException();
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
