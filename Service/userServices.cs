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
        public userServices(IuserRepositories repository, IpasswordServic passwordServic   )
        {
            this.repository = repository;
            this.passwordServic = passwordServic;
        }
        //userRepositories repository=new userRepositories();

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await repository.GetUsers();
        }
        public async Task<User?> GetUserById(int Id)
        {
            return await repository.GetUserById(Id);
        }

        public async Task<User> CreateUser(User user)
        {
            
            password password = passwordServic.PasswordHardness(user.Password);
            if (password.Level >= 3)
            {
                return await repository.CreateUser(user);
            }
            return null;
        }


        public async Task<User> login(User loggedUser)
        {
            return await repository.login(loggedUser);
        }

        // PUT api/<UsersController>/5

        public async Task UpdateUser(int id, User loggedUser)
        {
            passwordServic passwordServic = new passwordServic();
            password password = passwordServic.PasswordHardness(loggedUser.Password);
            if (password.Level < 3)
            {
                throw new Exception("passworn us too weak");
            }
            await repository.UpdateUser(id, loggedUser);

        }


    }
}
