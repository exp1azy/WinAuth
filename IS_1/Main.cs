using IS_1.Data;
using IS_1.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using User = IS_1.Data.User;

namespace IS_1
{
    public partial class Main : Form
    {
        private readonly Database _db;
        private readonly IConfiguration _config;
        
        private List<UserModel> _users;
        private UserModel? _current;

        private const string _adminUsername = "ADMIN";

        public Main(IConfiguration config)
        {
            InitializeComponent();

            _config = config;
            _db = new Database(config);          

            if (!File.Exists(_db.Path))
            {
                var admin = new User[] { new User { Name = _adminUsername, Password = "", IsBlocked = false, PasswordRestrictions = false } };

                File.WriteAllText(_db.Path, JsonConvert.SerializeObject(admin, Formatting.Indented));
            }

            _users = _db.GetUsers()!.Select(UserModel.ToModel).ToList()!;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (_users == null || _users.Count == 0)
            {
                var result = MessageBox.Show("Пользователи не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (result == DialogResult.OK) 
                    Close();
            }           
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            using var auth = new Auth();       
            auth.SetUsers(_users);
            auth.ShowDialog();

            var loggedInUser = auth.GetLoggedIn();

            if (loggedInUser != null) 
                Auth(loggedInUser);           
        }

        private void ChangePassLabel_Click(object sender, EventArgs e)
        {
            using var changePass = new ChangePassword();         
            changePass.SetCurrentUser(_current!);
            changePass.ShowDialog();

            var newPass = changePass.GetNewPassword();
            if (newPass != null)
            {
                _db.ChangePassword(_current!.Name, newPass);

                var userToChange = _users.First(u => u.Name == _current.Name);
                userToChange.Password = newPass;

                ChangeToLoggedOut();

                using (var auth = new Auth())
                {
                    auth.SetUsers(_users);

                    var res = auth.ShowDialog();

                    _current = auth.GetLoggedIn()!;

                    if (_current != null) 
                        ChangeToLoggedIn();
                }
            }
        }

        private void NewUserLabel_Click(object sender, EventArgs e)
        {
            using var newUser = new NewUser(_config);
            newUser.SetUsers(_users);
            newUser.ShowDialog();

            _users = newUser.GetRefreshedUsers();
        }

        private void AllUsersLabel_Click(object sender, EventArgs e)
        {
            using var allUsers = new AllUsers(_config);
            allUsers.SetUsers(_users);
            allUsers.ShowDialog();

            _users = allUsers.GetRefreshedUsers();
        }

        private void LogoutLabel_Click(object sender, EventArgs e)
        {
            ChangeToLoggedOut();

            using var auth = new Auth();
            auth.SetUsers(_users);
            auth.ShowDialog();

            var loggedInUser = auth.GetLoggedIn();

            if (loggedInUser != null) 
                Auth(loggedInUser);
        }

        private void AboutLabel_Click(object sender, EventArgs e)
        {
            using var about = new About();
            about.ShowDialog();
        }

        private void Auth(UserModel loggedInUser)
        {
            if (loggedInUser != null)
            {
                _current = loggedInUser;

                bool passwordChanged = false;

                if (string.IsNullOrEmpty(loggedInUser.Password))
                {
                    MessageBox.Show("Необходимо сменить пароль", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (var changePass = new ChangePassword())
                    {
                        changePass.SetCurrentUser(loggedInUser);
                        changePass.ShowDialog();

                        var newPass = changePass.GetNewPassword();
                        if (newPass != null)
                        {
                            loggedInUser.Password = newPass;
                            _db.ChangePassword(loggedInUser.Name, loggedInUser.Password);
                        }
                    }

                    passwordChanged = true;

                    var userToChange = _users.First(u => u.Name == loggedInUser.Name);
                    userToChange.Password = loggedInUser.Password;
                }

                if (loggedInUser.PasswordRestrictions)
                {
                    var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[а-яА-ЯёЁ])(?=.*[^\p{L}\p{N}]).+$");
                    if (!regex.IsMatch(loggedInUser.Password))
                    {
                        MessageBox.Show("Пароль не соответствует парольным ограничениям в связи с их установкой администратором. Смените пароль", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);                

                        using (var changePass = new ChangePassword())
                        {
                            changePass.SetCurrentUser(loggedInUser);
                            changePass.ShowDialog();

                            var newPass = changePass.GetNewPassword();
                            if (newPass != null)
                            {
                                loggedInUser.Password = newPass;
                                _db.ChangePassword(loggedInUser.Name, loggedInUser.Password);
                            }
                        }

                        passwordChanged = true;

                        var userToChange = _users.First(u => u.Name == loggedInUser.Name);
                        userToChange.Password = loggedInUser.Password;
                    }
                }

                if (passwordChanged)
                {
                    using (var auth = new Auth())
                    {
                        auth.SetUsers(_users);
                        var res = auth.ShowDialog();

                        _current = auth.GetLoggedIn()!;
                    }
                }

                if (_current != null)
                    ChangeToLoggedIn();
            }
        }

        private void ChangeToLoggedIn()
        {
            LoginButton.Visible = false;
            LoggedInUsernameLabel.Text = $"Вы вошли под ником {_current!.Name}";
            LoggedInUsernameLabel.Visible = true;
            ChangePassLabel.Enabled = true;
            LogoutLabel.Enabled = true;

            if (_current.Name == _adminUsername)
            {
                AllUsersLabel.Enabled = true;
                NewUserLabel.Enabled = true;
            }
            else
            {
                AllUsersLabel.Enabled = false;
                NewUserLabel.Enabled = false;
            }
        }

        private void ChangeToLoggedOut()
        {
            _current = null;

            LoginButton.Visible = true;
            LoggedInUsernameLabel.Visible = false;
            ChangePassLabel.Enabled = false;
            LogoutLabel.Enabled = false;
            AllUsersLabel.Enabled = false;
            NewUserLabel.Enabled = false;
        }

        #region Label focusing

        private void Label_Enter(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.LightBlue;
            }
        }

        private void Label_Leave(object sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
                label.BackColor = Color.Transparent;
            }
        }

        #endregion
    }
}
