using DotTestKit.API.Models;
using DotTestKit.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotTestKit.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _service.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var addedProduct = _service.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = addedProduct.Id }, addedProduct);
        }
    }
}
