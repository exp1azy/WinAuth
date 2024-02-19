using IS_1.Models;
using System.Text.RegularExpressions;

namespace IS_1
{
    public partial class ChangePassword : Form
    {
        private string _newPassword;
        private UserModel _currentUser;

        public ChangePassword()
        {
            InitializeComponent();
        }
     
        public string GetNewPassword() => _newPassword;

        public void SetCurrentUser(UserModel currentUser)
        {
            _currentUser = currentUser;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            var oldPass = OldPasswordTextbox.Text;
            var newPass = NewPasswordTextbox.Text;
            var confirmNewPass = ConfirmNewPasswordTextbox.Text;

            if (oldPass != _currentUser.User.Password)
            {
                MessageBox.Show("Неверный ввод в поле <Старый пароль>. Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (oldPass == newPass)
            {
                MessageBox.Show("Новый и старый пароль не должны совпадать", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPass != confirmNewPass)
            {
                MessageBox.Show("Неверный ввод в поле <Подтвердить>. Не удалось подтвердить новый пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_currentUser.User.PasswordRestrictions)
            {
                var regex = new Regex(@"^(?=.*[a-zA-Z])(?=.*[а-яА-ЯёЁ])(?=.*[^\p{L}\p{N}]).+$");
                if (!regex.IsMatch(newPass))
                {
                    MessageBox.Show("Пароль не соответствует парольным ограничениям: обязательное наличие латинских букв, символов кириллицы и знаков препинания.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _newPassword = newPass;

            Close();
        }
    }
}
