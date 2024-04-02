
using Microsoft.AspNetCore.Mvc;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Service.Interface;


namespace OnlineRetailShop.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _CustomerInterface;
        public CustomerService(ICustomerRepository customerInterface)
        {
            _CustomerInterface = customerInterface;
        }

        public Task<List<Customer>> GetAllCustomer()
        {
            var customer = _CustomerInterface.GetAllCustomer();
            return customer;
        }
        public Task<Customer> GetCustomerById(Guid customerId)
        {
            var customer= _CustomerInterface.GetCustomerById(customerId);
            return customer; 
        }

        public async Task<Customer> AddCustomer(CreateCustomer customer1)
        {
            Customer customer=new Customer();
            customer.CustomerId=Guid.NewGuid();
            customer.CustomerName=customer1.CustomerName;
            customer.Email=customer1.Email;
            customer.Mobile=customer1.Mobile;
            return await _CustomerInterface.AddCustomer(customer);
        }
        public Task<Customer> DeleteCustomer(Guid customerId)
        {
            return _CustomerInterface.DeleteCustomer(customerId);   
        }

        public async Task<Customer>UpdateCustomer(Guid CustomerId, CreateCustomer customer)
        {
            var customer1 = await _CustomerInterface.GetCustomerById(CustomerId);    
            if(customer.CustomerName!= "string")
            customer1.CustomerName=customer.CustomerName;
            if(customer.Email!= "string")
            customer1.Email=customer.Email;
            if(customer.Mobile!=0)
            customer1.Mobile=customer.Mobile;
            return await _CustomerInterface.UpdateCustomer(customer1);
        }
    }
}
