using Microsoft.Extensions.Configuration;

namespace IS_1
{
    public partial class Passphrase : Form
    {
        private readonly IConfiguration _config;

        private string _pass;

        public Passphrase(IConfiguration config)
        {
            InitializeComponent();

            _config = config;
        }

        public string Pass => _pass;

        private void PassphraseButton_Click(object sender, EventArgs e)
        {
            var passphrase = PassphraseTextbox.Text;

            if (string.IsNullOrEmpty(passphrase))
            {
                MessageBox.Show($"Введите парольную фразу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _pass = passphrase;

            var cryptoHandler = new CryptoHandler(_config);
            
            cryptoHandler.EncryptDecryptCredentials(passphrase, false);

            Close();
        }
    }
}
