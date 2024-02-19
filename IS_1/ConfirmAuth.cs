namespace IS_1
{
    public partial class ConfirmAuth : Form
    {
        private string _confirmedPassword;

        public ConfirmAuth()
        {
            InitializeComponent();
        }

        public string GetConfirmedPassword() => _confirmedPassword;

        private void ConfirmPassButton_Click(object sender, EventArgs e)
        {
            _confirmedPassword = ConfirmPassTextbox.Text;
            Close();
        }        
    }
}
