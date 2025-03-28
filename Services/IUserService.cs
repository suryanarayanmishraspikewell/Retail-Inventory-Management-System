using InventoryManagementAPI.Models;

namespace InventoryManagementAPI.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserByID(int id);
        public Task Createuser(User user);

        public Task UpdateUser(User user);

        //public Task Deleteuser(User user);
        public Task DeleteUser(int id);

    }
}
