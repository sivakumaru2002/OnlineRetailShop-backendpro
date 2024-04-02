using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;

namespace OnlineRetailShop.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _Dbcontext;
        public ProductRepository(AppDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        public async Task<List<Product>> GetAllProduct()
        {

            return await _Dbcontext.Product.ToListAsync();
        }

        public async Task<Product> GetProductById(Guid ProductId)
        {
            var product = await _Dbcontext.Product.FindAsync(ProductId);
            return product;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _Dbcontext.Product.Add(product);
            await _Dbcontext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(Guid ProductId)
        {
            var product = await _Dbcontext.Product.FindAsync(ProductId);
            _Dbcontext.Product.Remove(product);
            await _Dbcontext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _Dbcontext.Product.Update(product);
            await _Dbcontext.SaveChangesAsync();
            return product;
        }
    }
}
