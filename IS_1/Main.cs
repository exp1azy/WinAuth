using IS_1.Data;
using IS_1.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.ApplicationServices;
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
        private string _passphrase;

        public Main(IConfiguration config)
        {
            InitializeComponent();

            _config = config;
            _db = new Database(config);
        }

        private void EncryptAndDeleteTemp()
        {
            var cryptoHandler = new CryptoHandler(_config);

            cryptoHandler.EncryptDecryptCredentials(_passphrase, true);
            cryptoHandler.DeleteTempFile();
        }

        private void Main_Load(object sender, EventArgs e)
        {            
            using (var passphrase = new Passphrase(_config))
            {
                passphrase.ShowDialog();
                _passphrase = passphrase.Pass;
            }

            if (!File.Exists(_db.Path))
            {
                var admin = new User[] { new User { Name = Const.AdminName, Password = "", IsBlocked = false, PasswordRestrictions = false } };

                File.WriteAllText(_db.Path, JsonConvert.SerializeObject(admin, Formatting.Indented));
            }
           
            if (_db.GetUsers() == null)
            {
                MessageBox.Show("Введена неверная парольная фраза", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                EncryptAndDeleteTemp();
                Close();
            }
            else
            {
                _users = _db.GetUsers().Select(UserModel.ToModel).ToList()!;
            }            
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            EncryptAndDeleteTemp();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            using var auth = new Auth();
            auth.SetUsers(_users);
            auth.ShowDialog();

            var loggedInUser = auth.GetLoggedIn();

            if (loggedInUser != null)
                Authenticate(loggedInUser);
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
                Authenticate(loggedInUser);
        }

        private void AboutLabel_Click(object sender, EventArgs e)
        {
            using var about = new About();
            about.ShowDialog();
        }

        #region Auth

        private void Authenticate(UserModel loggedInUser)
        {
            if (loggedInUser != null)
            {
                _current = loggedInUser;

                bool passwordChanged = false;

                if (string.IsNullOrEmpty(loggedInUser.Password))
                {
                    MessageBox.Show("Необходимо сменить пароль", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    passwordChanged = ChangePassword(loggedInUser);
                }

                if (loggedInUser.PasswordRestrictions)
                {
                    var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[а-яА-ЯёЁ])(?=.*[^\p{L}\p{N}]).+$");
                    if (!regex.IsMatch(loggedInUser.Password))
                    {
                        MessageBox.Show("Пароль не соответствует парольным ограничениям в связи с их установкой администратором. Смените пароль", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        passwordChanged = ChangePassword(loggedInUser);
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

        private bool ChangePassword(UserModel user)
        {
            var changedUser = OpenFormAndChangePassword(user);

            SetNewPassword(changedUser);

            return true;
        }

        private UserModel OpenFormAndChangePassword(UserModel user)
        {
            using var changePass = new ChangePassword();        
            changePass.SetCurrentUser(user);
            changePass.ShowDialog();

            var newPass = changePass.GetNewPassword();
            if (newPass != null)
            {
                user.Password = newPass;
                _db.ChangePassword(user.Name, user.Password);
            }
            
            return user;
        }

        private void SetNewPassword(UserModel user)
        {
            var userToChange = _users.First(u => u.Name == user.Name);
            userToChange.Password = user.Password;
        }

        private void ChangeToLoggedIn()
        {
            LoginButton.Visible = false;            
            LoggedInUsernameLabel.Visible = true;
            ChangePassLabel.Enabled = true;
            LogoutLabel.Enabled = true;

            if (_current!.Name == Const.AdminName)
            {
                AllUsersLabel.Enabled = true;
                NewUserLabel.Enabled = true;
                LoggedInUsernameLabel.Text = $"Вы вошли как администратор";
            }
            else
            {
                AllUsersLabel.Enabled = false;
                NewUserLabel.Enabled = false;
                LoggedInUsernameLabel.Text = $"Вы вошли под ником {_current!.Name}";
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

        #endregion

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
