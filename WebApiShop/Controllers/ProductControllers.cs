using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService Services;
        public ProductController(IProductService services)
        {
            this.Services = services;
        }
 

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            ProductDTO Product = await Services.GetProductById(id);
            if (Product.ProductId == id)
                return Ok(Product);
            return NotFound();
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get([FromQuery] int[]? categoryId, [FromQuery] decimal maxPrice, [FromQuery] decimal minPrice)
        {

            return (IEnumerable<ProductDTO>)await Services.GetProducts(categoryId, maxPrice, minPrice);
        }
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO product)
        {
            ProductDTO _service = await Services.CreateProducts(product);
            if (_service == null)
                return NoContent();
            return CreatedAtAction(nameof(Get), new { Id = _service.ProductId }, _service);
        }

       





    }
}

