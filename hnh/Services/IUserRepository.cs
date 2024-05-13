using hnh.Models;

namespace hnh.Services
{
    public interface IUserRepository
    {
        IEnumerable<UserVM> GetUsers();
        UserVM GetUser(int id);
        UserVM AddUser(UserVM user);
        UserVM UpdateUser(UserVM user);
        void DeleteUser(int id);
        bool UserExists(int id);
        bool Save();
    }
}
