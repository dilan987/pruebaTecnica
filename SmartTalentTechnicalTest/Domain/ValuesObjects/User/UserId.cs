using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValuesObjects.User
{
    public record UserId
    {
        public Guid Value { get; init; }
        internal UserId(Guid value_)
        {

            Value = value_;
        }
        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }
        public static implicit operator Guid(UserId userId)
        {
            return userId.Value;
        }
    }
}
