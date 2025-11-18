using Entities;

namespace Repository
{
    public interface IuserRepositories
    {
        User CreateUser(User user);
        User? GetUserById(int Id);
        User login(User loggedUser);
        void UpdateUser(int id, User loggedUser);
    }
}