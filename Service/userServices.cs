using AutoMapper;
using DTOs;
using Entities;
using Repository;
using System.Text.Json;
using Zxcvbn;

namespace Service
{
    public class userServices : IuserServices
    {
        IuserRepositories repository;
        IpasswordServic passwordServic;
        IMapper mapper;
        public userServices(IuserRepositories repository, IpasswordServic passwordServic,IMapper mapper)
        {
            this.repository = repository;
            this.passwordServic = passwordServic;
            this.mapper = mapper;
        }
        //userRepositories repository=new userRepositories();

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            IEnumerable<User> users = await repository.GetUsers();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            
        }
        public async Task<UserDTO?> GetUserById(int Id)
        {

            User user = await repository.GetUserById(Id);
            return mapper.Map<User, UserDTO>(user);
        }

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            
            password password = passwordServic.PasswordHardness(user.Password);
            if (password.Level >= 3)
            {
                User user1= mapper.Map<UserDTO,User>(user);
                user1= await repository.CreateUser(user1);
                return mapper.Map<User, UserDTO>(user1);
            }
            return null;
        }


        public async Task<UserDTO> login(LoginUserDTO loggedUser)
        {
            User user=mapper.Map<LoginUserDTO, User>(loggedUser);
            
            user= await repository.login(user);
            return mapper.Map<User,UserDTO>(user);
        }

        // PUT api/<UsersController>/5

        public async Task UpdateUser(int id, UserDTO user)
        {
            passwordServic passwordServic = new passwordServic();
            password password = passwordServic.PasswordHardness(user.Password);
            if (password.Level < 3)
            {
                throw new Exception("passworn us too weak");
            }
            User user1 = mapper.Map<UserDTO, User>(user);
            await repository.UpdateUser(id, user1);
        }


    }
}
