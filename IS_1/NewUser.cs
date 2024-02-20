using IS_1.Data;
using IS_1.Models;
using Microsoft.Extensions.Configuration;

namespace IS_1
{
    public partial class NewUser : Form
    {
        private readonly Database _db;  
        private List<UserModel> _users;

        public NewUser(IConfiguration config)
        {
            InitializeComponent();

            _db = new Database(config);
        }

        public List<UserModel> GetRefreshedUsers() => _users;

        public void SetUsers(List<UserModel> users)
        {
            _users = users;
        }

        private void NewUserButton_Click(object sender, EventArgs e)
        {
            var newUsername = NewUserTextbox.Text;
            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Имя пользователя не может быть пустым или состоять из пробелов", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_users.FirstOrDefault(u => u.User.Name == newUsername) != null)
            {
                MessageBox.Show("Такой пользователь уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
            _db.AddNewUser(newUsername, string.Empty);
            _users.Add(new UserModel 
            { 
                IsFirstAuth = true, 
                User = new User 
                {
                    Name = newUsername,
                    Password = string.Empty,
                    IsBlocked = false,
                    PasswordRestrictions = false
                } 
            });

            Close();
        }
    }
}
