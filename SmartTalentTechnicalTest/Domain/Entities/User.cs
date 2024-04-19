using Domain.ValuesObjects.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; init; }
        public UserName Name { get; private set; }
        public UserEmail Email { get; private set; }
        public UserPassword Password { get; private set; }
        public UserType Type { get; private set; }
        public User(Guid id)
        {
            this.Id = id;
        }
        public void SetName(UserName name)
        {
            Name = name;
        }
        public void SetEmail(UserEmail email)
        {
            Email = email;
        }
        public void SetPassword(UserPassword password)
        {
            Password = password;
        }

        public void SetType(UserType type)
        {
            Type = type;
        }

    }
}
