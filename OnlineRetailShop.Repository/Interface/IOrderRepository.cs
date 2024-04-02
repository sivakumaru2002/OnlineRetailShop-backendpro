

using OnlineRetailShop.Repository.Entity;

namespace OnlineRetailShop.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrder();
        Task<Order> GetOrderById(Guid OrderId);
        Task<Order> AddOrder(Order order);
        Task<Order> DeleteOrder(Order order);
        Task<Order> UpdateOrder(Order order);
    }
}
