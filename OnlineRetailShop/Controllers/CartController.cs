using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Service.Interface;
using ViewModels;

namespace OnlineRetailShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _CartService;
        public CartController(ICartService cartService)
        {
            _CartService = cartService;
        }
        [HttpGet]
        [Route ("GetAllCart")]
        public async Task<IActionResult> GetAllCart()
        {
            var cart = await _CartService.GetAllCart();
            if (cart == null) { return NoContent(); }
            return Ok(cart);
        }

        [HttpGet]
        [Route("GetCartById")]
        public async Task<IActionResult> GetCartByid(Guid productid)
        {
            var product=await _CartService.GetOrderById(productid);
            if (product == null) { return NoContent(); }
            return Ok(product);
        }

        [HttpDelete]
        [Route("DeleteCart")]
        public async Task<IActionResult>DeleteCart(Guid productid)
        {
            var cart1 = await _CartService.DeleteCart(productid);
            if (cart1 == null) { return NotFound(); }
            return Ok(cart1);
        }

        [HttpPut]
        [Route ("UpdateCart")]
        public async Task<IActionResult>UpdateCart(PutProduct product)
        {
            var product1=await _CartService.UpdateCart(product);
            if (product1 == null) { return NotFound(); }
            return Ok(product1);    
        }
        [HttpPost]
        [Route ("AddCart")]
        public async Task<IActionResult>AddCart(Cart cart)
        {
            var cart1 = await _CartService.AddCart(cart);
            if (cart1 == null) { return NotFound();}
            return Ok(cart1);
        }
    }

}