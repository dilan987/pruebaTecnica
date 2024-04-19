using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.Order
{
    public record OrderDate
    {
        public DateTime Value { get; init; }
        internal OrderDate(DateTime value)
        {

            Value = value;
        }
        public static OrderDate Create(DateTime value)
        {
            return new OrderDate(value);
        }
 
    }
}
