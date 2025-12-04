using Entities;

namespace Repository
{
    public interface IuserRepositories
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> CreateUser(User user);
        Task<User?> GetUserById(int Id);
        Task<User> login(User loggedUser);
        Task UpdateUser(int id, User loggedUser);
    }
}