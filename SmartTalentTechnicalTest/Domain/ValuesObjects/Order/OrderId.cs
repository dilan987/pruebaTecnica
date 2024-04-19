using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Order
{
    public record OrderId
    {
        public Guid Value { get; init; }
        internal OrderId(Guid value_)
        {

            Value = value_;
        }
        public static OrderId Create(Guid value)
        {
            return new OrderId(value);
        }
        public static implicit operator Guid(OrderId userId)
        {
            return userId.Value;
        }
    }
}
