using Domain.Entities;
using Domain.Repositories;
using Domain.ValuesObjects.User;

namespace SmartTalentTechnicalTest.Queries
{
    public class UserQueries
    {
        private readonly IUserRepository _userRepository;
        public UserQueries(IUserRepository userRepository) { 

            this._userRepository = userRepository;
        }
        public async Task<User> GetUserIdAsync(Guid id)
        {
            var response = await _userRepository.GetUserById(UserId.Create(id));
            return response;
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUser(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUser(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteUser(UserId.Create(id));
        }
    }
}
