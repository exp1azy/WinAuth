using IS_1.Data;
using IS_1.Models;

namespace IS_1
{
    public partial class ChangePassword : Form
    {
        private string _newPassword;

        public ChangePassword()
        {
            InitializeComponent();
        }

        public string OldPassword { get; set; }
        public UserModel CurrentUser { get; set; }

        public string GetNewPassword() => _newPassword;

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            var oldPass = OldPasswordTextbox.Text;
            var newPass = NewPasswordTextbox.Text;
            var confirmNewPass = ConfirmNewPasswordTextbox.Text;

            if (oldPass != OldPassword)
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

            _newPassword = newPass;

            Close();
        }
    }
}
