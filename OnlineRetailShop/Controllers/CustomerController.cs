using Microsoft.AspNetCore.Mvc;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Service.Interface;


namespace OnlineRetailShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _CustomerService;
        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        [HttpGet]
        [Route ("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer() {
            var customer = await _CustomerService.GetAllCustomer();
            if(customer == null) { return NoContent(); }
            return Ok(customer);
        }

        [HttpGet]
        [Route ("GetCustomerById")]

        public async Task<IActionResult> GetCustomerById(Guid customerId)
        {
            var customer = await _CustomerService.GetCustomerById(customerId);
            if (customer == null) { return NoContent(); }
            return Ok(customer);
        }

        [HttpPost]
        [Route ("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CreateCustomer customer)
        {
            if (customer == null) { return NoContent(); }
            var customer1=await _CustomerService.AddCustomer(customer);
            if(customer1 == null) { return NoContent(); }
            return Ok(customer1);
        }

        [HttpDelete]
        [Route ("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId)
        {
           var customer=await _CustomerService.DeleteCustomer(customerId);
            if(customer == null) { return NoContent();}
            return Ok(customer);
        }

        [HttpPut]
        [Route ("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(Guid CustomerId,CreateCustomer customer)
        {
            var customner=await _CustomerService.UpdateCustomer(CustomerId, customer);
            if(customner == null) { return NoContent();}
            return Ok(customner);
        }

    }
}
