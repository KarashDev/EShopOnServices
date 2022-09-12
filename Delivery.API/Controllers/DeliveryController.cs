using Delivery.API.Database;
using Delivery.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            this.deliveryService = deliveryService;
        }
        //$"http://jiktest.orenpay.ru:4010/api/Buffet/get_prod_categories/{vendor}"


        [HttpPost("prepare_order")]
        public async Task<IActionResult> PrepareOrder()
        {
            //try
            //{
            //await queueServiceApi.NewOrder(orderData);
            //using (DeliveryContext db = new DeliveryContext())
            //{

            //    db.Categories.Add(category);
            //    db.SaveChanges();

            //    return Ok();
            //}

            // TODO проверять координаты покупателя входят ли в координаты курьера, если нет - отправить
            // невозможность доставки (покупателю и в историю?), если есть - запустить таймер на 10 минут и 
            // вызывать метод доставки заказа

            //return Ok();
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

        //[HttpPost("deliver_order")]
        //public async Task<IActionResult> DeliverOrder(Category category)
        //{
        //    //try
        //    //{
        //    //await queueServiceApi.NewOrder(orderData);
        //    //using (DeliveryContext db = new DeliveryContext())
        //    //{

        //    //    db.Categories.Add(category);
        //    //    db.SaveChanges();

        //    //    return Ok();
        //    //}

        //    // TODO отправить статус в историю, можно на покупателя

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

        //[HttpPost("cancel_order")]
        //public async Task<IActionResult> CancelOrder(List<Products> products)
        //{
        //    //try
        //    //{
        //    //await queueServiceApi.NewOrder(orderData);
        //    //using (DeliveryContext db = new DeliveryContext())
        //    //{

        //    //    db.Categories.Add(category);
        //    //    db.SaveChanges();

        //    //    return Ok();
        //    //}

        //    // TODO проверить есть ли заказ в БД, если есть - убрать (статус отмены отправляется покупателем продавцу)

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

        //[HttpGet("get_catalog")]
        //[ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetCatalog()
        //{
        //    //try
        //    //{
        //    //var prodCategories = await queryService.GetProdCategories(vendor);

        //    using (DeliveryContext db = new DeliveryContext())
        //    {
        //        var prodCategories = db.Products.ToList();
        //        return Ok(prodCategories);
        //    }

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

        //[HttpPost("add_manufacturer")]
        //public async Task<IActionResult> AddManufacturer(Manufacturer manufacturer)
        //{
        //    //try
        //    //{
        //    //await queueServiceApi.NewOrder(orderData);

        //    using (DeliveryContext db = new DeliveryContext())
        //    {
        //        db.Manufacturers.Add(manufacturer);
        //        db.SaveChanges();

        //        return Ok();
        //    }

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


        //[HttpPost("add_product")]
        //public async Task<IActionResult> NewOrder(Product product)
        //{
        //    //try
        //    //{
        //    //    //await queueServiceApi.NewOrder(orderData);
        //    //return Ok();

        //    using (DeliveryContext db = new DeliveryContext44444444444())
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


        //[HttpPost("new_order")]
        //public async Task<IActionResult> NewOrder(OrderData orderData)
        //{
        //    try
        //    {
        //        await queueServiceApi.NewOrder(orderData);
        //        return Ok();
        //    }
        //    catch (BuffetException ex)
        //    {
        //        return BadRequest(new ErrorModel { Message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status503ServiceUnavailable, new ErrorModel { Message = ex.Message, StackTrace = ex.StackTrace });
        //    }
        //}
    }
}
