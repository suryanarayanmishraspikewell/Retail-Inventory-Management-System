using InventoryManagementAPI.Models;
using InventoryManagementAPI.Repositories;

namespace InventoryManagementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task CreateProduct(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}


