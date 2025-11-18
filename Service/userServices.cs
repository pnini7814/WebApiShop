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
        public User? GetUserById(int Id)
        {
            return repository.GetUserById(Id);
        }

        public User CreateUser(User user)
        {
            
            password password = passwordServic.PasswordHardness(user.Password);
            if (password.Level >= 3)
            {
                return repository.CreateUser(user);
            }
            return null;
        }


        public User login(User loggedUser)
        {
            return repository.login(loggedUser);
        }

        // PUT api/<UsersController>/5

        public void UpdateUser(int id, User loggedUser)
        {
            passwordServic passwordServic = new passwordServic();
            password password = passwordServic.PasswordHardness(loggedUser.Password);
            if (password.Level < 3)
            {
                throw new Exception("passworn us too weak");
            }
            repository.UpdateUser(id, loggedUser);

        }


    }
}
