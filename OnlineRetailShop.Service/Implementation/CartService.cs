
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Service.Interface;

namespace OnlineRetailShop.Service.Implementation
{
    public class CartService : ICartService
    {
        private readonly ICartRepository  _CartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _CartRepository = cartRepository;
        }
        public async Task<List<Cart>> GetAllCart()
        {
            return await _CartRepository.GetAllCart();
        }
        public async Task<Cart> GetOrderById(Guid ProductId)
        {
            return await _CartRepository.GetCartById(ProductId);
        }
        public async Task<Cart> DeleteCart(Guid ProductId)
        {
            var product=await _CartRepository.GetCartById(ProductId);
            if(product != null) { product=await _CartRepository.DeleteCart(product); }
            return product;
        }
        public async Task<Cart> UpdateCart(PutProduct product1)
        {
            var product = await _CartRepository.GetCartById(product1.ProductId);
            if(product == null) { return null; }
            product.Quantity = product1.quantity;
            product=await _CartRepository.UpdateCustomer(product);
            return product;
        }
        public async Task<Cart> AddCart(Cart cart)
        {
            var product = await _CartRepository.GetCartById(cart.ProductId);
            if (product == null)
            {
                return await _CartRepository.AddCart(cart);
            }
            product.Quantity++;
            PutProduct product1 = new PutProduct();
            product1.ProductId = cart.ProductId;
            product1.quantity = product.Quantity;
            cart=await UpdateCart(product1);
            return cart;
        }
    }
}
