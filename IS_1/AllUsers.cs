using IS_1.Data;
using IS_1.Models;
using Microsoft.Extensions.Configuration;

namespace IS_1
{
    public partial class AllUsers : Form
    {
        private readonly Database _db;

        private List<UserModel> _users;
        private UserModel _currentUser;
        private int _skip = 0;

        public AllUsers(IConfiguration config)
        {
            InitializeComponent();

            _db = new Database(config);
        }

        public List<UserModel> GetRefreshedUsers() => _users;

        public void SetUsers(List<UserModel> users)
        {
            _users = users;
        }

        private void ChangeBlockVisibilityIfNeeded(UserModel user)
        {
            if (user.Name == Const.AdminName)
            {
                BlockedCheckbox.Enabled = false;
            }
            else
            {
                BlockedCheckbox.Enabled = true;
            }
        }

        private void SaveChanges()
        {
            var username = UserTextbox.Text;
            var isBlocked = BlockedCheckbox.Checked;
            var passRestrictions = PassRestrictionsCheckbox.Checked;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Имя пользователя не может быть пустым или состоять из пробелов", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_users.Where(u => u != _currentUser).FirstOrDefault(u => u.Name == username) != null)
            {
                MessageBox.Show("Пользователь с таким ником уже существует", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _db.ChangeUser(_currentUser.Name, new User
            {
                Name = username,
                Password = _currentUser.Password,
                IsBlocked = isBlocked,
                PasswordRestrictions = passRestrictions,
            });

            var currentUser = _users.First(u => u.Name == _currentUser.Name);
            currentUser.Name = username;
            currentUser.IsBlocked = isBlocked;
            currentUser.PasswordRestrictions = passRestrictions;
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            var firstUser = _users.First();

            _skip++;

            if (firstUser != null)
            {
                UserTextbox.Text = firstUser.Name;
                BlockedCheckbox.Checked = firstUser.IsBlocked;
                PassRestrictionsCheckbox.Checked = firstUser.PasswordRestrictions;

                ChangeBlockVisibilityIfNeeded(firstUser);

                _currentUser = firstUser;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (_skip == _users.Count) _skip = 0;

            var nextUser = _users.Skip(_skip).First();

            _skip++;

            if (nextUser != null)
            {
                UserTextbox.Text = nextUser.Name;
                BlockedCheckbox.Checked = nextUser.IsBlocked;
                PassRestrictionsCheckbox.Checked = nextUser.PasswordRestrictions;

                ChangeBlockVisibilityIfNeeded(nextUser);

                _currentUser = nextUser;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            SaveChanges();
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
