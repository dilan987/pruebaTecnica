using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValuesObjects.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        DatabaseContext db;
        public UserRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public async Task AddUser(User user)
        {
            await db.AddAsync(user);
            await db.SaveChangesAsync();
        }

        public async Task DeleteUser(UserId Id)
        {
            var user = await db.Users.FindAsync((Guid)Id);
            if (user != null)
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await db.Users.SingleOrDefaultAsync(u => u.Email.Value == email);
        }

        public async Task<User> GetUserById(UserId Id)
        {
            return await db.Users.FindAsync((Guid)Id);
        }

        public async Task UpdateUser(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
        }
    }
}
