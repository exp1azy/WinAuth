using Microsoft.Extensions.Configuration;

namespace IS_1
{
    public partial class Passphrase : Form
    {
        private readonly IConfiguration _config;

        private string _password;

        public Passphrase(IConfiguration config)
        {
            InitializeComponent();

            _config = config;
        }

        public string Password => _password;

        private void PassphraseButton_Click(object sender, EventArgs e)
        {
            var passphrase = PassphraseTextbox.Text;

            if (string.IsNullOrEmpty(passphrase))
            {
                MessageBox.Show("Введите парольную фразу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cryptoHandler = new CryptoHandler(_config);

            try
            {
                cryptoHandler.Decrypt(passphrase);
            }
            catch
            {
                MessageBox.Show("Неверная парольная фраза", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _password = passphrase;

            Close();
        }
    }
}
