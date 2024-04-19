using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Order
{
    public record OrderUserId
    {
        public Guid Value { get; init; }
        internal OrderUserId(Guid value)
        {

            Value = value;
        }
        public static OrderUserId Create(Guid value)
        {
            return new OrderUserId(value);
        }
 
    }
}
