using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IS_1.Data
{
    public class Database
    {
        private string _path;

        public Database(IConfiguration config) 
        { 
            _path = config["DbPath"]!;
        }

        public string Path => _path;

        public List<User> GetUsers() => GetAll();

        public void ChangeUser(string userToChange, User user)
        {
            var users = GetAll();
            if (users != null)
            {
                var currentUser = users.FirstOrDefault(u => u.Name == userToChange);
                if (currentUser != null)
                {
                    currentUser.Name = user.Name;
                    currentUser.Password = user.Password;
                    currentUser.PasswordRestrictions = user.PasswordRestrictions;
                    currentUser.IsBlocked = user.IsBlocked;

                    SaveChanges(users);
                }
            }
        }

        public void ChangePassword(string userToChange, string newPassword)
        {
            var users = GetAll();
            if (users != null)
            {
                var currentUser = users.FirstOrDefault(u => u.Name == userToChange);
                if (currentUser != null)
                {
                    currentUser.Password = newPassword;
                    SaveChanges(users);
                }
            }
        }

        public User? AddNewUser(string username, string password, bool isBlocked = false, bool passRestrictions = false)
        {
            var users = GetAll();
            if (users != null)
            {
                var newUser = new User
                {
                    Name = username,
                    Password = password,
                    IsBlocked = isBlocked,
                    PasswordRestrictions = passRestrictions,
                };

                users.Add(newUser);
                SaveChanges(users);
                
                return newUser;
            }

            return null;
        }

        private void SaveChanges(List<User> users)
        {
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(Path, updatedJson);
        }

        private List<User> GetAll()
        {
            string json = File.ReadAllText(Path);
            var users = JsonConvert.DeserializeObject<List<User>>(json);

            return users!;
        }
    }
}
