using Microsoft.AspNetCore.Mvc;
using Order.API.Models;
using Order.API.Services;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderHandler orderHandler;

        private readonly HttpClient client;

        public OrderController(HttpClient client, IOrderHandler orderHandler)
        {
            this.client = client;
            this.orderHandler = orderHandler;
        }

        [HttpPost("search_product")]
        public async Task<IActionResult> SearchProduct(string productName, string manufacturerName)
        {
            try
            {
                var searchedProduct = orderHandler.SearchProduct(productName, manufacturerName).Result;

                if (searchedProduct != null)
                {
                    using (OrderContext db = new OrderContext())
                    {
                        db.ProductsInBasket.Add(searchedProduct);
                        db.SaveChanges();
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost("new_order")]
        public async Task<IActionResult> NewOrder()
        {
            try
            {
                orderHandler.NewOrder();

                orderHandler.SendOrder();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost("cancel_order")]
        public async Task<IActionResult> CancelOrder(Models.Order order)
        {
            try
            {
                orderHandler.CancelOrder(order);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }


        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                orderHandler.Checkout();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

    }
}
