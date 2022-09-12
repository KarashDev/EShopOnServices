using Catalog.API.Database;
using Catalog.API.Models;
using Catalog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("http://localhost:7117/api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly IQueryService queryService;
        private readonly ICommandService commandService;
        private readonly ICatalogHandler catalogHandler;

        public CatalogController(IQueryService queryService, ICommandService commandService, ICatalogHandler catalogHandler)
        {
            DatabaseCreator.CreateDataBase();
            this.queryService = queryService;
            this.commandService = commandService;
            this.catalogHandler = catalogHandler;
        }
        //$"http://jiktest.orenpay.ru:4010/api/Buffet/get_prod_categories/{vendor}"


        [HttpGet("get_catalog")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCatalog()
        {
            //try
            //{
            //var prodCategories = await queryService.GetProdCategories(vendor);

            using (CatalogContext db = new CatalogContext())
            {
                var prodCategories = db.Products.Include(p => p.Manufacturer).Include(p => p.Category).ToList();
                return Ok(prodCategories);
            }

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


        [HttpPost("add_category")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            //try
            //{
            //await queueServiceApi.NewOrder(orderData);
            using (CatalogContext db = new CatalogContext())
            {

                db.Categories.Add(category);
                db.SaveChanges();

                return Ok();
            }

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


        [HttpPost("add_manufacturer")]
        public async Task<IActionResult> AddManufacturer(Manufacturer manufacturer)
        {
            //try
            //{
            //await queueServiceApi.NewOrder(orderData);

            using (CatalogContext db = new CatalogContext())
            {
                db.Manufacturers.Add(manufacturer);
                db.SaveChanges();

                return Ok();
            }

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


        [HttpPost("add_product")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            //try
            //{
            //    //await queueServiceApi.NewOrder(orderData);
            //return Ok();

            using (CatalogContext db = new CatalogContext())
            {
                db.Products.Add(product);
                db.SaveChanges();

                return Ok();
            }
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


        [HttpPost("search_product")]
        public async Task<IActionResult> SearchProduct(ProductFromOrder product)
        {
            //try
            //{
            var result = catalogHandler.SearchProduct(product.ProductName, product.ManufacturerName);

            return Ok(result);
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

        //[HttpGet("search_product/{productName}")]
        //[ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> SearchProduct(string productName)
        //{
        //    //try
        //    //{
        //    //var prodCategories = await queryService.GetProdCategories(vendor);

        //    using (CatalogContext db = new CatalogContext())
        //    {
        //        var foundProducts = db.Products.Where(p => p.ProductName == productName).ToList();


        //        return Ok(foundProducts);
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


    }
}
