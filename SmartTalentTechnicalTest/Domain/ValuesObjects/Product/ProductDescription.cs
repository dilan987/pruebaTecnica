using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Product
{
    public record ProductDescription
    {
        public string Value { get; init; }
        internal ProductDescription(string value)
        {

            this.Value = value;
        }
        public static ProductDescription Create(string value)
        {
            validate(value);
            return new ProductDescription(value);
        }
        private static void validate(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("The value cannot be null");
            }
        }
    }
}
