using Domain.Entities;
using Domain.Repositories;
using Domain.ValuesObjects.Product;
using SmartTalentTechnicalTest.Commands;
using SmartTalentTechnicalTest.Queries;
using System.Security.Cryptography;
using System.Text;

namespace SmartTalentTechnicalTest.ApplicationServices
{
    public class ProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductQueries _productQueries;
        public ProductServices(IProductRepository repository,
            ProductQueries ProductQueries) 
        { 
            this._productRepository = repository;
            this._productQueries = ProductQueries;
        }

        public async Task HandleCommand(CreateProductCommand createProduct)
        {
            var newId = Guid.NewGuid();
            var product = new Product(ProductId.Create(newId));
            product.SetName(ProductName.Create(createProduct.name));
            product.SetDescription(ProductDescription.Create(createProduct.description));
            product.SetPrice(ProductPrice.Create(createProduct.price));
            product.SetQuantityAvailable(ProductQuantityAvailable.Create(createProduct.QuantityAvailable));

            await _productRepository.AddProduct(product);
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _productQueries.GetProductIdAsync(id);
        }

        public async Task<Product[]> GetProducts()
        {
            return await _productQueries.GetProductsAsync();
        }

        public async Task HandleCommand(UpdateProductCommand updateProduct)
        {
            var product = await _productQueries.GetProductIdAsync(updateProduct.productId);
            if (product != null)
            {
                product.SetName(ProductName.Create(updateProduct.name));
                product.SetDescription(ProductDescription.Create(updateProduct.description));
                product.SetPrice(ProductPrice.Create(updateProduct.price));
                product.SetQuantityAvailable(ProductQuantityAvailable.Create(updateProduct.QuantityAvailable));

                await _productQueries.UpdateProductAsync(product);
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productQueries.DeleteProductAsync(id);
        }

    }
}
