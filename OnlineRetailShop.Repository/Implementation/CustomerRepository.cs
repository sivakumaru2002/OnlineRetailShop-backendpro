using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;

namespace OnlineRetailShop.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext _Dbcontext;
        public CustomerRepository(AppDbContext _context) {
            _Dbcontext = _context;        
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
       
            return await _Dbcontext.Customer.ToListAsync();   
        }

        public async Task<Customer> GetCustomerById(Guid CustomerId)
        {
            var customer =await _Dbcontext.Customer.FindAsync(CustomerId);
            return customer;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            _Dbcontext.Customer.Add(customer);
            await _Dbcontext.SaveChangesAsync();
            return customer;
        }
    
        public async Task<Customer> DeleteCustomer(Guid customerId)
        {
            var customer=await _Dbcontext.Customer.FindAsync(customerId);
            _Dbcontext.Customer.Remove(customer);
            await _Dbcontext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer1)
        {
            _Dbcontext.Customer.Update(customer1);
            await _Dbcontext.SaveChangesAsync();
            return customer1;
        }
    }
}
