using Newtonsoft.Json;

namespace Order.API.Services
{
    public interface IOrderHandler
    {
        Task<Product> SearchProduct(string productName, string manufacturerName);

        void NewOrder();

        void SendOrder();

        void Checkout();

        void CancelOrder();
    }

    public class OrderHandler : IOrderHandler
    {
        HttpClient client;

        public OrderHandler(HttpClient client) 
        {
            this.client = client;
        }

        public async Task<Product> SearchProduct(string productName, string manufacturerName)
        {
            //ProductName = "Куртка зимняя", ManufacturerName = "Alden"
            var productToSearch = new Product() { ProductName = productName, ManufacturerName = manufacturerName };

            var webRequest = new HttpRequestMessage(HttpMethod.Post, $"api/Catalog/search_product")
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(productToSearch), Encoding.UTF8, "application/json")
            };

            var response = client.Send(webRequest);
            var responseString = await response.Content.ReadAsStringAsync();

            var product  = JsonConvert.DeserializeObject<Product>(responseString);

            return product;
        }

        public void NewOrder()
        {
            // Создается объект order, полю номера присваивается рандом число
            // для всех продуктов в корзине устанавливается этот объект заказа
            // заказ отправляется курьеру
            Random random = new Random();
           
            using (OrderContext db = new OrderContext()) 
            {
                Models.Order order = new Models.Order()
                {
                    OrderNum = random.Next(1000, 2000),
                    Products = db.ProductsInBasket.ToList()
                };
                db.Orders.Add(order);

                foreach (var product in order.Products)
                {
                    product.OrderId = order.OrderId;
                }
                db.SaveChanges();
            }
        }

        public async void SendOrder()
        {
            //var productToSearch = new Product() { ProductName = productName, ManufacturerName = manufacturerName };

            using (OrderContext db = new OrderContext())
            {
                var order = db.Orders.First();

                var webRequest = new HttpRequestMessage(HttpMethod.Post, $"api/Delivery/prepare_order")
                {
                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(order), Encoding.UTF8, "application/json")
                };

                var response = client.Send(webRequest);
                var responseString = await response.Content.ReadAsStringAsync();


                //var product = JsonConvert.DeserializeObject<Product>(responseString);

            }
        }

        public void CancelOrder()
        {
            throw new NotImplementedException();
        }

        public void Checkout()
        {
            throw new NotImplementedException();
        }

       
    }
}
