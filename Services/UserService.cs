using InventoryManagementAPI.Models;
using InventoryManagementAPI.Repositories;

namespace InventoryManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Createuser(User user)
        {
            await _userRepository.Add(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserByID(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task UpdateUser(User user)
        {
             await _userRepository.Update(user);
        }

        public async Task DeleteUser(int id)
        {
             await _userRepository.Delete(id);
        }
    }
}

