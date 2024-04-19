using Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Order
{
    public record OrderData
    {
        public List<ProductOrder> Value { get; init; }
        internal OrderData(List<ProductOrder> value)
        {

            Value = value;
        }
        public static OrderData Create(List<ProductOrder> value)
        {
            return new OrderData(value);
        }
 
    }

}
