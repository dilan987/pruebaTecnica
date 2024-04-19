using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Product
{
    public record ProductQuantityAvailable
    {
        public double Value { get; init; }
        internal ProductQuantityAvailable(double value)
        {

            this.Value = value;
        }
        public static ProductQuantityAvailable Create(double value)
        {

            return new ProductQuantityAvailable(value);
        }

 
    }
}
