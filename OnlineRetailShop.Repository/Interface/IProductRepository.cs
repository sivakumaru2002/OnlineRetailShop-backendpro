

using OnlineRetailShop.Repository.Entity;

namespace OnlineRetailShop.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(Guid ProductId);
        Task<Product> AddProduct(Product product);
        Task<Product> DeleteProduct(Guid ProductId);
        Task<Product> UpdateProduct(Product product);
    }
}
