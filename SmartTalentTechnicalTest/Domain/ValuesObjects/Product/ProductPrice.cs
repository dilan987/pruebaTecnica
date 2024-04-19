using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Product
{
    public record ProductPrice
    {
        public double Value { get; init; }
        internal ProductPrice(double value)
        {

            this.Value = value;
        }
        public static ProductPrice Create(double value)
        {
            
            return new ProductPrice(value);
        }
    }
}
