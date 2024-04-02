using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Service.Interface;

namespace OnlineRetailShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _OrderService;
        public OrderController(IOrderService orderService)
        {
            _OrderService = orderService;
        }

        [HttpGet]
        [Route ("GetAllOrder")]
        public async Task<IActionResult> GetAllProduct()
        {
            var order = await _OrderService.GetAllOrder();
            if (order == null) { return NoContent(); }
            return Ok(order);
        }
        [HttpGet]
        [Route ("GetOrderById")]
        public async Task<IActionResult> GetProductById(Guid OrderId)
        {
            var order=await _OrderService.GetOrderById(OrderId);
            if (order == null) { return NoContent(); }
            return Ok(order);   
        }
        [HttpPost]
        [Route ("AddOrder")]
        public async Task<IActionResult> AddOrder(CreateOrder order1)
        {
            var order=await _OrderService.AddOrder(order1);
            if (order == null) { return NotFound(); }
            return Ok(order);
        }
        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(Guid OrderId)
        {
            var order=await _OrderService.DeleteOrder(OrderId);
            if (order == null) { return NotFound();}
            return Ok(order);
        }
        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(Guid OrderId,int Quantity)
        {
            var order=await _OrderService.UpdateOrder(OrderId,Quantity);
            if (order == null) { return NotFound();}
            return Ok(order);
        }

    }
}
