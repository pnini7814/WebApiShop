using Entities;

namespace Service
{
    public interface IuserServices
    {
        User CreateUser(User user);
        User? GetUserById(int Id);
        User login(User loggedUser);
        void UpdateUser(int id, User loggedUser);
    }
}