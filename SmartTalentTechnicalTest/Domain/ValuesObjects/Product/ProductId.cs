using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Product
{
    public record ProductId
    {
        public Guid Value { get; init; }
        internal ProductId(Guid value_)
        {

            Value = value_;
        }
        public static ProductId Create(Guid value)
        {
            return new ProductId(value);
        }
        public static implicit operator Guid(ProductId userId)
        {
            return userId.Value;
        }
    }
}
