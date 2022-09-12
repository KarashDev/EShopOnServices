namespace Order.API.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
