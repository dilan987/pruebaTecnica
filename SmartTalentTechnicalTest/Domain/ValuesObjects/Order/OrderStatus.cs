using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Order
{
    public record OrderStatus
    {
        public Boolean Value { get; init; }
        internal OrderStatus(Boolean value)
        {

            Value = value;
        }
        public static OrderStatus Create(Boolean value)
        {
            return new OrderStatus(value);
        }
 
    }
}
