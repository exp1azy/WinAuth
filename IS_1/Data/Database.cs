using Newtonsoft.Json;

namespace IS_1.Data
{
    public class Database
    {
        public string Path = "C:\\Users\\Admin\\source\\repos\\IS_1\\IS_1\\Data\\users.json";

        public List<User>? GetUsers() => GetAll();

        public void ChangePassword(string username, string newPassword)
        {
            var users = GetAll();
            if (users != null)
            {
                var currentUser = users.FirstOrDefault(u => u.Username == username);
                if (currentUser != null)
                {
                    currentUser.Password = newPassword;
                    SaveChanges(users);
                }
            }
        }

        public void ChangeUsername(string usernameToChange, string newUsername)
        {
            var users = GetAll();
            if (users != null)
            {
                var currentUser = users.FirstOrDefault(u => u.Username == usernameToChange);
                if (currentUser != null)
                {
                    currentUser.Username = newUsername;
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
                    Username = username,
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

        private List<User>? GetAll()
        {
            string json = File.ReadAllText(Path);
            var users = JsonConvert.DeserializeObject<List<User>>(json);

            return users;
        }
    }
}
