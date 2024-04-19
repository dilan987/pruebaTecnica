using Domain.Entities;
using Domain.ValuesObjects.Product;
using Domain.ValuesObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(UserId Id);
        Task<User> GetUserByEmail(string email);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(UserId Id);
    }
}
