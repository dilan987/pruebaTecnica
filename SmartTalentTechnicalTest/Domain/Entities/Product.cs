using Domain.ValuesObjects;
using Domain.ValuesObjects.Order;
using Domain.ValuesObjects.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; init; }
        public ProductName Name { get; private set; }
        public ProductDescription Description { get; private set; }
        public ProductPrice Price { get; private set; }
        public ProductQuantityAvailable QuantityAvailable { get; set; }
        public Product(Guid id)
        {
            this.Id = id;
        }
        public void SetName(ProductName name)
        {
            Name = name;
        }
        public void SetDescription(ProductDescription description)
        {
            Description = description;
        }
        public void SetPrice(ProductPrice price)
        {
            Price = price;
        }

        public void SetQuantityAvailable(ProductQuantityAvailable quantityAvailable)
        {
            QuantityAvailable = quantityAvailable;
        }

    }
}
