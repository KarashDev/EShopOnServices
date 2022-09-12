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
    public class CatalogController : Controller
    {
        private readonly ICatalogHandler catalogHandler;

        public CatalogController(ICatalogHandler catalogHandler)
        {
            DatabaseCreator.CreateDataBase();

            this.catalogHandler = catalogHandler;
        }


        [HttpGet("get_catalog")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCatalog()
        {
            try
            {
                var catalog = catalogHandler.GetCatalog();
                return Ok(catalog);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }


        [HttpPost("add_category")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            try
            {
                catalogHandler.AddCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }


        [HttpPost("add_manufacturer")]
        public async Task<IActionResult> AddManufacturer(Manufacturer manufacturer)
        {
            try
            {
                catalogHandler.AddManufacturer(manufacturer);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }


        [HttpPost("add_product")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {
                catalogHandler.AddProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }


        [HttpPost("search_product")]
        public async Task<IActionResult> SearchProduct(ProductFromOrder product)
        {
            try
            {
                var result = catalogHandler.SearchProduct(product.ProductName, product.ManufacturerName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

    }
}
