

using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;

namespace OnlineRetailShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _DbContext;
        public OrderRepository(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }
         public async Task<List<Order>> GetAllOrder()
        {
            var order = await _DbContext.Order.ToListAsync();
            return order;
        }
        public async Task<Order> GetOrderById(Guid OrderId)
        {
            var order=await _DbContext.Order.FirstOrDefaultAsync(Orders => Orders.OrderId == OrderId);
            return order;
        }
        public async Task<Order> AddOrder(Order order)
        {
             _DbContext.Order.Add(order);
            await _DbContext.SaveChangesAsync();
            return order;
        }
        public async Task<Order> DeleteOrder(Order order)
        {
            _DbContext.Order.Remove(order);
            await _DbContext.SaveChangesAsync();
            return order;
        }
        public async Task<Order> UpdateOrder(Order order)
        {
            _DbContext.Order.Update(order);
            await _DbContext.SaveChangesAsync();
            return order;
        }
    }
}
