using IS_1.Data;

namespace IS_1
{
    public partial class NewUser : Form
    {
        private readonly Database _db;

        public NewUser()
        {
            InitializeComponent();

            _db = new Database();
        }

        private void NewUserButton_Click(object sender, EventArgs e)
        {
            var newUsername = NewUserTextbox.Text;
            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Имя пользователя не может быть пустым или состоять из пробелов", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
            _db.AddNewUser(newUsername, string.Empty);

            Close();
        }
    }
}
