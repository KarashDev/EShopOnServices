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

        [HttpPost("prepare_order")]
        public async Task<IActionResult> PrepareOrder(Order order)
        {
            try
            {
                deliveryService.PrepareOrder(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost("cancel_order")]
        public async Task<IActionResult> CancelOrder(Order order)
        {
            try
            {
                deliveryService.CancelOrder(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost("deliver_order")]
        public async Task<IActionResult> DeliverOrder(Order order)
        {
            try
            {
                deliveryService.CancelOrder(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}
