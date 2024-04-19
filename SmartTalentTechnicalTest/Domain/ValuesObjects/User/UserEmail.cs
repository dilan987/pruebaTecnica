using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.User
{
    public record UserEmail
    {
        public string Value { get; init; }
        internal UserEmail(string value)
        {

            Value = value;
        }
        public static UserEmail Create(string value)
        {
            validate(value);
            return new UserEmail(value);
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
