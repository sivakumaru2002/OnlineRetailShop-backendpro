using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Service.Interface;
using ViewModels;

namespace OnlineRetailShop.Service.Implementation
{
    public class ProductService :IProductService
    {
        private IProductRepository _ProductRepository;

        public ProductService(IProductRepository productRepository) { 
            _ProductRepository = productRepository;
        }
        public Task<List<Product>> GetAllProduct()
        {
            var product = _ProductRepository.GetAllProduct();
            return product;
        }
        public  async Task<Product> GetProductById(Guid ProductId)
        {
            var product = await _ProductRepository.GetProductById(ProductId);
            return product;
        }

        public async Task<Product> AddProduct(CreateProduct product1)
        {
            Product product = new Product();
            product.ProductId=Guid.NewGuid();
            product.ProductName=product1.ProductName;
            product.Quantity=product1.Quantity;
            product.IsActive = product1.IsActive;
            var product2= await _ProductRepository.AddProduct(product);
            return product2;
        }

        public   Task<Product> DeleteProduct(Guid ProductId)
        {
            return  _ProductRepository.DeleteProduct(ProductId);
        }

        public async Task<Product> UpdateProduct(Guid productId , CreateProduct product)
        {
            Product product1 =await _ProductRepository.GetProductById(productId);
            product1.ProductId=productId;
            if(product.ProductName!="string")
            product1.ProductName=product.ProductName;
            if(product.Quantity!=0)
            product1.Quantity=product.Quantity; 
            if(!(product.IsActive))
            product1.IsActive = product.IsActive;
            return await _ProductRepository.UpdateProduct(product1);
        }
    }
}
