using IS_1.Data;
using IS_1.Models;

namespace IS_1
{
    public partial class Auth : Form
    {
        private readonly Database _db;

        private List<UserModel?> _users;
        private UserModel? _currentUser = null;
        private int _wrongPasswordCount = 0;

        public Auth()
        {
            InitializeComponent();

            _db = new Database();
            _users = _db.GetUsers().Select(UserModel.ToModel).ToList();
        }

        public UserModel? GetCurrentUser() => _currentUser;

        private void Auth_Load(object sender, EventArgs e)
        {
            if (_users == null || _users.Count == 0)
            {
                MessageBox.Show("Пользователи не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            var username = UsernameTextbox.Text;
            var password = PasswordTextbox.Text;

            var thisUser = _users!.FirstOrDefault(u => u.User.Username == username);
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
                    MessageBox.Show($"Введен неверный пароль для пользователя {thisUser.User.Username}", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _wrongPasswordCount = 0;
            thisUser.IsFirstAuth = false;
            _currentUser = thisUser;

            Close();
        }
    }
}
