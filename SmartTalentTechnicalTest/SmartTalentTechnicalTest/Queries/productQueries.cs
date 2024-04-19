using Domain.Entities;
using Domain.Repositories;
using Domain.ValuesObjects.Product;
using Domain.ValuesObjects.User;
using Infrastructure;

namespace SmartTalentTechnicalTest.Queries
{
    public class ProductQueries
    {
        private readonly IProductRepository _productRepository;
        public ProductQueries(IProductRepository productRepository) { 

            this._productRepository = productRepository;
        }
        public async Task<Product> GetProductIdAsync(Guid id)
        {
            var response = await _productRepository.GetProductById(ProductId.Create(id));
            return response;
        }
        public async Task<Product[]> GetProductsAsync()
        {
            var response = await _productRepository.GetProducts();
            return response;
        }
        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddProduct(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProduct(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteProduct(ProductId.Create(id));
        }
    }
}
