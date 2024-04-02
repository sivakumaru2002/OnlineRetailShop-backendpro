

using OnlineRetailShop.Repository.Entity;

namespace OnlineRetailShop.Service.Interface
{
    public interface ICartService
    {
        Task<List<Cart>> GetAllCart();
        Task<Cart> GetOrderById(Guid ProductId);
        Task<Cart> DeleteCart(Guid PrductId);
        Task<Cart> AddCart(Cart cart);
        Task<Cart> UpdateCart(PutProduct cart1);
      
    }
}

