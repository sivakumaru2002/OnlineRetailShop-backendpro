using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Migrations;
using OnlineRetailShop.Service.Implementation;
using OnlineRetailShop.Service.Interface;
using OnlineRetailshop.Filter;
using ViewModels;

namespace OnlineRetailShop.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class ProductController : ControllerBase
    {
        private IProductService _ProductService;
        public ProductController(IProductService productService) { 
            _ProductService = productService;
        }

        [HttpGet]
        [Route ("GetAllProduct")]
        public async Task<IActionResult> GetAllProduct()
        {
            var product= await _ProductService.GetAllProduct();
            if(product == null) { return NoContent(); }
            return Ok(product);
        }
        [HttpGet]
        [Route ("GetProductById")]
         public async Task<IActionResult> GetProductById(Guid productId)
        {
            var product=await _ProductService.GetProductById(productId);
            if(product == null) { return NotFound(); }
            return Ok(product);
        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(CreateProduct product)
        {
            if (product == null) { return NoContent(); }
            var product1 = await _ProductService.AddProduct(product);
            if (product1 == null) { return NoContent(); }
            return Ok(product1);
        }

        [HttpDelete]
        [Route ("DeleteProduct")]
        public async Task<IActionResult>DeleteProduct(Guid ProductId)
        {
            var product = await _ProductService.DeleteProduct(ProductId);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        [HttpPut]
        [Route ("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Guid ProductId,CreateProduct product)
        {
            var product1 = await _ProductService.UpdateProduct(ProductId, product);
            if (product1 == null) { return NoContent(); }
            return Ok(product1);
        }
    }
}
