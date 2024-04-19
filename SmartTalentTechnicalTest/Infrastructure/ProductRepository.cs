using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValuesObjects.Product;
using Domain.ValuesObjects.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        DatabaseContext db;
        public ProductRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task AddProduct(Product product)
        {
            await db.AddAsync(product);
            await db.SaveChangesAsync();
        }

        public async Task DeleteProduct(ProductId Id)
        {
            var product = await db.Products.FindAsync((Guid)Id);
            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductById(ProductId Id)
        {
            return await db.Products.FindAsync((Guid)Id);
        }

        public async Task<Product[]> GetProducts()
        {
            return await db.Products.ToArrayAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }
    }
}
