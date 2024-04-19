using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.User
{
    public record UserPassword
    {
        public string Value { get; init; }
        internal UserPassword(string value)
        {

            Value = value;
        }
        public static UserPassword Create(string value)
        {
            validate(value);
            return new UserPassword(value);
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
