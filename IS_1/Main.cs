using IS_1.Data;
using IS_1.Models;
using Newtonsoft.Json;
using User = IS_1.Data.User;

namespace IS_1
{
    public partial class Main : Form
    {
        private readonly Database _db;
        
        private List<UserModel> _users;
        private UserModel? _current;

        private const string _adminUsername = "ADMIN";

        public Main()
        {
            InitializeComponent();

            _db = new Database();          

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
                if (result == DialogResult.OK) Close();
            }           
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            using var auth = new Auth();       
            auth.SetUsers(_users);
            auth.ShowDialog();

            var loggedInUser = auth.GetLoggedIn();
            if (loggedInUser != null) Auth(loggedInUser);           
        }

        private void ChangePassLabel_Click(object sender, EventArgs e)
        {
            using var changePass = new ChangePassword();         
            changePass.SetCurrentUser(_current!);
            changePass.ShowDialog();

            _current!.User.Password = changePass.GetNewPassword(); 
            _db.ChangePassword(_current.User.Name, _current.User.Password);
        }

        private void NewUserLabel_Click(object sender, EventArgs e)
        {
            using var newUser = new NewUser();
            newUser.SetUsers(_users);
            newUser.ShowDialog();

            _users = newUser.GetRefreshedUsers();
        }

        private void AllUsersLabel_Click(object sender, EventArgs e)
        {
            using var allUsers = new AllUsers();
            allUsers.SetUsers(_users);
            allUsers.ShowDialog();

            _users = allUsers.GetRefreshedUsers();
        }

        private void LogoutLabel_Click(object sender, EventArgs e)
        {
            _current = null;

            LoginButton.Visible = true;
            LoggedInUsernameLabel.Visible = false;
            ChangePassLabel.Enabled = false;
            LogoutLabel.Enabled = false;
            AllUsersLabel.Enabled = false;
            NewUserLabel.Enabled = false;

            using var auth = new Auth();
            auth.SetUsers(_users);
            auth.ShowDialog();

            var loggedInUser = auth.GetLoggedIn();
            if (loggedInUser != null) Auth(loggedInUser);
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
                if (loggedInUser.IsFirstAuth)
                {
                    using (var confirmAuth = new ConfirmAuth())
                    {
                        confirmAuth.ShowDialog();

                        var confirmedPassword = confirmAuth.GetConfirmedPassword();
                        if (confirmedPassword == loggedInUser.User.Password)
                        {
                            confirmAuth.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Введен неверный пароль для пользователя {loggedInUser.User.Name}", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    loggedInUser.IsFirstAuth = false;
                }

                LoginButton.Visible = false;
                LoggedInUsernameLabel.Text = $"Вы вошли под ником {loggedInUser!.User.Name}";
                LoggedInUsernameLabel.Visible = true;
                ChangePassLabel.Enabled = true;
                LogoutLabel.Enabled = true;

                if (loggedInUser.User.Name == _adminUsername)
                {
                    AllUsersLabel.Enabled = true;
                    NewUserLabel.Enabled = true;
                }
                else
                {
                    AllUsersLabel.Enabled = false;
                    NewUserLabel.Enabled = false;
                }

                _current = loggedInUser;
                var changedUser = _users.First(u => u.User.Name == _current.User.Name);
                changedUser = _current;
            }
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
