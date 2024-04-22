using OnlineRetailShop.Repository.Entity;
using ViewModels;

namespace OnlineRetailShop.Service.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(Guid ProductId);
        Task<Product> AddProduct(CreateProduct product1);
        Task<Product> DeleteProduct(Guid ProductId);
        Task<Product> UpdateProduct(Guid productId, CreateProduct product);
    }
}
