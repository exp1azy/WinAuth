namespace IS_1
{
    partial class Auth
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UsernameTextbox = new TextBox();
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            PasswordTextbox = new TextBox();
            ConfirmButton = new Button();
            SuspendLayout();
            // 
            // UsernameTextbox
            // 
            UsernameTextbox.Location = new Point(17, 64);
            UsernameTextbox.Margin = new Padding(5, 6, 5, 6);
            UsernameTextbox.Name = "UsernameTextbox";
            UsernameTextbox.Size = new Size(523, 35);
            UsernameTextbox.TabIndex = 0;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(17, 28);
            UsernameLabel.Margin = new Padding(5, 0, 5, 0);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(192, 30);
            UsernameLabel.TabIndex = 1;
            UsernameLabel.Text = "Имя пользователя";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(17, 132);
            PasswordLabel.Margin = new Padding(5, 0, 5, 0);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(85, 30);
            PasswordLabel.TabIndex = 2;
            PasswordLabel.Text = "Пароль";
            // 
            // PasswordTextbox
            // 
            PasswordTextbox.Location = new Point(17, 168);
            PasswordTextbox.Margin = new Padding(5, 6, 5, 6);
            PasswordTextbox.Name = "PasswordTextbox";
            PasswordTextbox.PasswordChar = '*';
            PasswordTextbox.Size = new Size(523, 35);
            PasswordTextbox.TabIndex = 3;
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(362, 280);
            ConfirmButton.Margin = new Padding(5, 6, 5, 6);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(182, 64);
            ConfirmButton.TabIndex = 4;
            ConfirmButton.Text = "Войти";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // Auth
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 380);
            Controls.Add(ConfirmButton);
            Controls.Add(PasswordTextbox);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(UsernameTextbox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5, 6, 5, 6);
            Name = "Auth";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTextbox;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private TextBox PasswordTextbox;
        private Button ConfirmButton;
    }
}