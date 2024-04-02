

using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Service.Interface;

namespace OnlineRetailShop.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IProductRepository _ProductRepository;
        public OrderService(IOrderRepository orderRepository , IProductRepository productRepository)
        {
            _OrderRepository = orderRepository;
            _ProductRepository = productRepository;
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _OrderRepository.GetAllOrder();
        }
        public async Task<Order> GetOrderById(Guid OrderId)
        {
            return await _OrderRepository.GetOrderById(OrderId);
        }
        public async Task<Order> AddOrder(CreateOrder order1)
        {
            var product=await _ProductRepository.GetProductById(order1.ProductId);
            product.Quantity-=order1.Quantity;
            var product2= await _ProductRepository.UpdateProduct(product);
            if(product2!=null)
            {
                Order order = new Order();
                order.ProductId=Guid.NewGuid();
                order.ProductId=order1.ProductId;
                order.Quantity=order1.Quantity;
                order.CustomerId = order1.CustomerId;
                order.IsCancel = false;
                order.Product = null;
                order.Customer = null;
                return await _OrderRepository.AddOrder(order);
                
            }
            return null; 
        }
        public async Task<Order> DeleteOrder(Guid orderid)
        {
            var order=await _OrderRepository.GetOrderById(orderid);
            return await _OrderRepository.DeleteOrder(order);   
        }
        public async Task<Order> UpdateOrder(Guid orderid,int Quantity)
        {
            var order= await _OrderRepository.GetOrderById(orderid);
            order.Quantity=Quantity;
            await _OrderRepository.UpdateOrder(order);
            return order;
        }
    }
}
