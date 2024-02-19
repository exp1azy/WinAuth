using IS_1.Data;
using IS_1.Models;
using Newtonsoft.Json;

namespace IS_1
{
    public partial class Main : Form
    {
        private readonly Database _db;

        private UserModel? _current;

        private const string _admin = "ADMIN";

        public Main()
        {
            InitializeComponent();

            _db = new Database();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var admin = new User
            {
                Username = _admin,
                Password = "",
                IsBlocked = false,
                PasswordRestrictions = false
            };

            if (!File.Exists(_db.Path))
            {
                File.Create(_db.Path);
                File.WriteAllText(_db.Path, JsonConvert.SerializeObject(admin));
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            using (var auth = new Auth())
            {
                auth.ShowDialog();

                var loggedInUser = auth.GetCurrentUser();
                Auth(loggedInUser);
            }
        }

        private void ChangePassLabel_Click(object sender, EventArgs e)
        {
            using (var changePass = new ChangePassword())
            {
                changePass.OldPassword = _current!.User.Password;
                changePass.ShowDialog();

                _current.User.Password = changePass.GetNewPassword();
            }
        }

        private void NewUserLabel_Click(object sender, EventArgs e)
        {
            using var newUser = new NewUser();           
            newUser.ShowDialog();           
        }

        private void AllUsersLabel_Click(object sender, EventArgs e)
        {
            using var allUsers = new AllUsers();
            allUsers.ShowDialog();
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
            auth.ShowDialog();

            var loggedInUser = auth.GetCurrentUser();
            Auth(loggedInUser);
        }

        private void AboutLabel_Click(object sender, EventArgs e)
        {
            using var about = new About();
            about.ShowDialog();
        }

        private void Auth(UserModel loggedInUser)
        {
            if (loggedInUser.IsFirstAuth)
            {
                using (var confirmAuth = new ConfirmAuth())
                {
                    confirmAuth.ShowDialog();

                    var confirmedPassword = confirmAuth.GetConfirmedPassword();
                    if (confirmedPassword == loggedInUser.User.Password)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"Введен неверный пароль для пользователя {loggedInUser.User.Username}", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            if (loggedInUser != null)
            {
                LoginButton.Visible = false;
                LoggedInUsernameLabel.Text = $"Вы вошли под ником {loggedInUser!.User.Username}";
                LoggedInUsernameLabel.Visible = true;
                ChangePassLabel.Enabled = true;
                LogoutLabel.Enabled = true;

                if (loggedInUser.User.Username == _admin)
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
