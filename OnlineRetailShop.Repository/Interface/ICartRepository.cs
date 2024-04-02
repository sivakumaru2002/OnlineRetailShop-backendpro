

using OnlineRetailShop.Repository.Entity;

namespace OnlineRetailShop.Repository.Interface
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllCart();
        Task<Cart> GetCartById(Guid ProductId);
        Task<Cart> DeleteCart(Cart cart);
        Task<Cart> AddCart(Cart cart);
        Task<Cart> UpdateCustomer(Cart cart1);
    }
}
