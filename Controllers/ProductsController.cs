//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace InventoryManagementAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//    }
//}

//using InventoryManagementAPI.Models;
//using InventoryManagementAPI.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace InventoryManagementAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//        private readonly IRepository<Product> _productRepository;

//        public ProductsController(IRepository<Product> productRepository)
//        {
//            _productRepository = productRepository;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
//        {
//            return Ok(await _productRepository.GetAll());
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Product>> GetProduct(int id)
//        {
//            var product = await _productRepository.GetById(id);
//            if (product == null) return NotFound();
//            return Ok(product);
//        }

//        [HttpPost]
//        public async Task<ActionResult> CreateProduct(Product product)
//        {
//            await _productRepository.Add(product);
//            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateProduct(int id, Product product)
//        {
//            if (id != product.ProductId) return BadRequest();
//            await _productRepository.Update(product);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProduct(int id)
//        {
//            await _productRepository.Delete(id);
//            return NoContent();
//        }
//    }
//}


using InventoryManagementAPI.Models;
using InventoryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET all products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        // GET product by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST (Create) a new product
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await _productService.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        // PUT (Update) an existing product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.ProductId) return BadRequest();
            await _productService.UpdateProduct(product);
            return NoContent();
        }

        // DELETE a product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}


