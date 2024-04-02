

using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;


namespace OnlineRetailShop.Repository.Implementation
{
    public class CartRepository :ICartRepository
    {
        private readonly AppDbContext _DbContext;
        public CartRepository(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<List<Cart>> GetAllCart()
        {
            var cart = await _DbContext.Cart.ToListAsync();
            return cart;
        }
        public async Task<Cart> GetCartById(Guid ProductId)
        {
            var product= await _DbContext.Cart.FindAsync(ProductId);
            return product;
        }

        public async Task<Cart> DeleteCart(Cart cart)
        {
            _DbContext.Cart.Remove(cart);
            await _DbContext.SaveChangesAsync();
            return cart;
        }
        public async Task<Cart> AddCart(Cart cart)
        {
             _DbContext.Cart.Add(cart);
            await _DbContext.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> UpdateCustomer(Cart cart1)
        {
            _DbContext.Cart.Update(cart1);
            await _DbContext.SaveChangesAsync();
            return cart1;
        }

    }
}
