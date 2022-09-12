namespace Delivery.API.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public long OrderNum { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
