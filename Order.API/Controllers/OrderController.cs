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

        public OrderController(HttpClient client, IQueryService queryService, ICommandService commandService, IOrderHandler orderHandler)
        {
            //DatabaseCreator.CreateDataBase();
            this.client = client;
            this.queryService = queryService;
            this.commandService = commandService;
            this.orderHandler = orderHandler;
        }
        //$"http://jiktest.orenpay.ru:4010/api/Buffet/get_prod_categories/{vendor}"

        //: Найти товар, Оформить заказ, Отменить заказ, Получить заказ


        //[HttpGet("search_product/{productName}")]
        //[ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> SearchProduct(string productName, string manufacturerName)
        //{
        //    //try
        //    //{
        //    //var prodCategories = await queryService.GetProdCategories(vendor);


        //    var prodToSearch = new Product() {ManufacturerName = man }



        //    using (OrderContext db = new OrderContext())
        //    {
        //        var prodCategories = db.Products.ToList();
        //        return Ok(prodCategories);
        //    }

        //    // TODO ЗАПРОС НА ПРОДАВЦА 

        //    //return Ok(prodCategories);
        //    //}
        //    //catch (BuffetException ex)
        //    //{
        //    //    return BadRequest(new ErrorModel { Message = ex.Message });
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return StatusCode(StatusCodes.Status503ServiceUnavailable, new ErrorModel { Message = ex.Message, StackTrace = ex.StackTrace });
        //    //}
        //}


        [HttpPost("search_product")]
        public async Task<IActionResult> SearchProduct(string productName, string manufacturerName)
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
            // TODO ЗАПРОС ДОСТАВЩИКУ и ЗАПРОС ПРОДАВЦУ ЧТОБЫ АССОРТИМЕНТ ОБНОВИЛ
        }

        [HttpPost("new_order")]
        public async Task<IActionResult> NewOrder()
        {
            //try
            //{
         
            orderHandler.NewOrder();

            orderHandler.SendOrder();

            //if (searchedProduct != null)
            //{
            //    using (OrderContext db = new OrderContext())
            //    {
            //        db.ProductsInBasket.Add(searchedProduct);
            //        db.SaveChanges();
            //    }
            //}

            return Ok();

            // Создается объект order, полю номера присваивается рандом число
            // для всех продуктов в корзине устанавливается этот объект заказа
            // заказ отправляется курьеру

            //}
            //catch (BuffetException ex)
            //{
            //    return BadRequest(new ErrorModel { Message = ex.Message });
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(StatusCodes.Status503ServiceUnavailable, new ErrorModel { Message = ex.Message, StackTrace = ex.StackTrace });
            //}
        }


        //[HttpPost("cancel_order")]
        //public async Task<IActionResult> CancelOrder(List<Products> products)
        //{
        //    //try
        //    //{
        //    //await queueServiceApi.NewOrder(orderData);
        //    //using (OrderContext db = new OrderContext())
        //    //{

        //    //    db.Categories.Add(category);
        //    //    db.SaveChanges();

        //    //    return Ok();
        //    //}

        //    // TODO ЗАКАЗ DTO; отправить отмену на доставщика и на продавца чтобы обновил ассортимент

        //    //return Ok();
        //    //}
        //    //catch (BuffetException ex)
        //    //{
        //    //    return BadRequest(new ErrorModel { Message = ex.Message });
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return StatusCode(StatusCodes.Status503ServiceUnavailable, new ErrorModel { Message = ex.Message, StackTrace = ex.StackTrace });
        //    //}
        //}


        //[HttpPost("receive_order")]
        //public async Task<IActionResult> NewOrder(Product product)
        //{
        //    //try
        //    //{
        //    //    //await queueServiceApi.NewOrder(orderData);
        //    //return Ok();

        //    using (OrderContext db = new OrderContext())
        //    {
        //        db.Products.Add(product);
        //        db.SaveChanges();

        //        return Ok();
        //    }
        //    //}
        //    //catch (BuffetException ex)
        //    //{
        //    //    return BadRequest(new ErrorModel { Message = ex.Message });
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return StatusCode(StatusCodes.Status503ServiceUnavailable, new ErrorModel { Message = ex.Message, StackTrace = ex.StackTrace });
        //    //}
        //}



    }
}
