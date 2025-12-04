using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    public class userRepositories : IuserRepositories
    {
        WebApiShopDBContext _webApiShopDBContext;
        //const string _filePath = "M:\\New folder - Copy\\WebApiShop\\WebApiShop\\Users.txt";

        public userRepositories(WebApiShopDBContext webApiShopDBContext)
        {
            _webApiShopDBContext = webApiShopDBContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _webApiShopDBContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int Id)
        {
            return await _webApiShopDBContext.Users.FindAsync(Id);
        }

        public async Task<User> CreateUser(User user)
        {
            await _webApiShopDBContext.Users.AddAsync(user);
            await _webApiShopDBContext.SaveChangesAsync();
            return user;    
        }


        public async Task<User> login(User loggedUser)
        {
            return await _webApiShopDBContext.Users.Where(user=>user.UserName==loggedUser.UserName&& user.Password==loggedUser.Password ).FirstOrDefaultAsync();
        }

        // PUT api/<UsersController>/5

        public async Task UpdateUser(int id, User loggedUser)
        {
            _webApiShopDBContext.Users.Update(loggedUser);
            await _webApiShopDBContext.SaveChangesAsync();
        }
    }
}
