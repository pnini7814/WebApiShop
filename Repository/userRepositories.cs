using Entities;
using System.Text.Json;

namespace Repository
{
    public class userRepositories : IuserRepositories
    {
        const string _filePath = "M:\\New folder - Copy\\WebApiShop\\WebApiShop\\Users.txt";
        public User? GetUserById(int Id)
        {
            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == Id)
                        return user;
                }
            }
            return null;
        }

        public User CreateUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(_filePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(_filePath, userJson + Environment.NewLine);
            return user;
        }


        public User login(User loggedUser)
        {

            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserName == loggedUser.UserName && user.Password == loggedUser.Password)
                        return user;
                }
            }
            return null;
        }

        // PUT api/<UsersController>/5

        public void UpdateUser(int id, User loggedUser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(_filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(loggedUser));
                System.IO.File.WriteAllText(_filePath, text);
            }
        }
    }
}
