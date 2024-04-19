using Domain.Entities;
using Domain.ValuesObjects.Order;
using Domain.ValuesObjects.Product;
using Domain.ValuesObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(ProductId Id);
        Task<Product[]> GetProducts();
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(ProductId Id);
    }
 
}
