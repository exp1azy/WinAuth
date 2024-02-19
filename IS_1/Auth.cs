using IS_1.Models;

namespace IS_1
{
    public partial class Auth : Form
    {
        private UserModel _loggedInUser;
        private List<UserModel> _users;
        private int _wrongPasswordCount = 0;

        public Auth()
        {
            InitializeComponent();
        }

        public UserModel? GetLoggedIn() => _loggedInUser;

        public void SetUsers(List<UserModel> users)
        {
            _users = users;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            var username = UsernameTextbox.Text;
            var password = PasswordTextbox.Text;

            var thisUser = _users!.FirstOrDefault(u => u.User.Name == username);
            if (thisUser == null)
            {
                MessageBox.Show($"Пользователь {username} не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (thisUser!.User.Password != password)
            {
                _wrongPasswordCount++;
                if (_wrongPasswordCount == 3)
                {
                    MessageBox.Show($"Вы 3 раза ввели неверный пароль!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show($"Введен неверный пароль для пользователя {thisUser.User.Name}", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _loggedInUser = thisUser;
            _wrongPasswordCount = 0;

            Close();
        }
    }
}
