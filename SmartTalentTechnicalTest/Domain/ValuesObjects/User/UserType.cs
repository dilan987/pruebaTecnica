using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.User
{
    public record UserType
    {
        public int Value { get; init; }
        internal UserType(int value)
        {

            Value = value;
        }
        public static UserType Create(int value)
        {
            return new UserType(value);
        }
    }
}
