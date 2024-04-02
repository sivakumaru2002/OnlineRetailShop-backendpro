using Microsoft.AspNetCore.Mvc;
using OnlineRetailShop.Repository.Entity;


namespace OnlineRetailShop.Repository.Interface
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomer();
        Task<Customer> GetCustomerById(Guid CustomerId);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> DeleteCustomer(Guid customerId);
        Task<Customer> UpdateCustomer(Customer customer);
    }
}
