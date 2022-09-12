namespace Catalog.API.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}