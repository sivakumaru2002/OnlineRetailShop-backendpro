using Microsoft.AspNetCore.Mvc;
using OnlineRetailShop.Repository.Entity;
using ViewModels;


namespace OnlineRetailShop.Service.Interface
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(Guid customerId);
        Task<Customer> AddCustomer(CreateCustomer customer);
        Task<Customer> DeleteCustomer(Guid customerId);
        Task<Customer> UpdateCustomer(Guid CustomerId, CreateCustomer Customer);
    }
}
