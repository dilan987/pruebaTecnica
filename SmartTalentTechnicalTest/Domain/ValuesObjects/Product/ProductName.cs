using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Product
{
    public record ProductName
    {
        public string Value { get; init; }
        internal ProductName(string value)
        {

            this.Value = value;
        }
        public static ProductName Create(string value)
        {
            validate(value);
            return new ProductName(value);
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
