using IS_1.Data;
using IS_1.Models;

namespace IS_1
{
    public partial class AllUsers : Form
    {
        private readonly Database _db;

        private List<UserModel?> _users;
        private UserModel _currentUser;

        public AllUsers()
        {
            InitializeComponent();

            _db = new Database();
            _users = _db.GetUsers()!.Select(UserModel.ToModel).ToList();
        }

        private void SaveChanges()
        {
            var username = UserTextbox.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Имя пользователя не может быть пустым или состоять из пробелов", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _db.ChangeUsername(_currentUser.User.Username, username);
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            var firstUser = _users.First();
            if (firstUser != null)
            {
                UserTextbox.Text = firstUser.User.Username;
                BlockedCheckbox.Checked = firstUser.User.IsBlocked;
                PassRestrictionsCheckbox.Checked = firstUser.User.PasswordRestrictions;

                _currentUser = firstUser;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var username = UserTextbox.Text;
            var nextUser = _users.FirstOrDefault(u => u.User.Username != username);
            if (nextUser != null)
            {
                UserTextbox.Text = nextUser.User.Username;
                BlockedCheckbox.Checked = nextUser.User.IsBlocked;
                PassRestrictionsCheckbox.Checked = nextUser.User.PasswordRestrictions;

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
