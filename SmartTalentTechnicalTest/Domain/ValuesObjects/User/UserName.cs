using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.User
{
    public record UserName
    {
        public string Value { get; init; }
        internal UserName(string value)
        {

            Value = value;
        }
        public static UserName Create(string value)
        {
            validate(value);
            return new UserName(value);
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
