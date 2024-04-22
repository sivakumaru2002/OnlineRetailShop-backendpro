using OnlineRetailShop.Repository.Entity;
using ViewModels;

namespace OnlineRetailShop.Service.Interface
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrder();
        Task<Order> GetOrderById(Guid id);
        Task<Order> AddOrder(CreateOrder order1);
        Task<Order> DeleteOrder(Guid orderid);
        Task<Order> UpdateOrder(Guid orderid, int Quantity);
    }
}
