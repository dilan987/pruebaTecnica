using Domain.Entities;
using Domain.Repositories;
using Domain.ValuesObjects.User;
using SmartTalentTechnicalTest.Commands;
using SmartTalentTechnicalTest.Queries;
using System.Security.Cryptography;
using System.Text;

namespace SmartTalentTechnicalTest.ApplicationServices
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly UserQueries _userQueries;
        public UserServices(IUserRepository repository,
            UserQueries userQueries) 
        { 
            this._userRepository = repository;
            this._userQueries = userQueries;
        }

        public async Task HandleCommand(CreateUserCommand createUser)
        {
            var newUserId = Guid.NewGuid();
            var user = new User(UserId.Create(newUserId));
            user.SetName(UserName.Create(createUser.name));
            user.SetEmail(UserEmail.Create(createUser.email));
            var passw =  EncriptPassword(createUser.password);
            user.SetPassword(UserPassword.Create(passw));
            user.SetType(UserType.Create(1));

            await _userRepository.AddUser(user);
        }

        public async Task<User> GetUser(Guid id)
        {
            return await _userQueries.GetUserIdAsync(id);
        }

        public async Task HandleCommand(UpdateUserCommand updateUser)
        {
            var user = await _userRepository.GetUserById(UserId.Create(updateUser.userId));
            if (user != null)
            {
                user.SetName(UserName.Create(updateUser.name));
                user.SetEmail(UserEmail.Create(updateUser.email));
                var passw = EncriptPassword(updateUser.password);
                user.SetPassword(UserPassword.Create(passw));
                user.SetType(UserType.Create(updateUser.type));

                await _userRepository.UpdateUser(user);
            }
        }

        public async Task DeleteUser(Guid id)
        {
            await _userRepository.DeleteUser(UserId.Create(id));
        }


        public async Task<User> ValidateUserCredentials(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            var passw = EncriptPassword(password);
            if (user == null || user.Password.Value != passw) 
            {
                return null;
            }

            return user;
        }
        public static string EncriptPassword(string password)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(password));

                foreach(byte x in result)
                    sb.Append(x.ToString("x2"));
            }
                return sb.ToString();
        }

    }
}
