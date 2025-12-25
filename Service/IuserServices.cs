using DTOs;
using Entities;

namespace Service
{
    public interface IuserServices
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> CreateUser(UserDTO user);
        Task<UserDTO>? GetUserById(int Id);
        Task<UserDTO> login(LoginUserDTO loggedUser);
        Task UpdateUser(int id, UserDTO loggedUser);
    }
}