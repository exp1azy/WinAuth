namespace IS_1
{
    partial class Main
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
            components = new System.ComponentModel.Container();
            TabControl = new TabControl();
            UsersTabPage = new TabPage();
            LogoutLabel = new Label();
            AllUsersLabel = new Label();
            NewUserLabel = new Label();
            ChangePassLabel = new Label();
            RefTabPage = new TabPage();
            AboutLabel = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            LoginButton = new Button();
            LoggedInUsernameLabel = new Label();
            TabControl.SuspendLayout();
            UsersTabPage.SuspendLayout();
            RefTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Controls.Add(UsersTabPage);
            TabControl.Controls.Add(RefTabPage);
            TabControl.Location = new Point(2, 4);
            TabControl.Margin = new Padding(5, 6, 5, 6);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(434, 246);
            TabControl.TabIndex = 0;
            // 
            // UsersTabPage
            // 
            UsersTabPage.BorderStyle = BorderStyle.FixedSingle;
            UsersTabPage.Controls.Add(LogoutLabel);
            UsersTabPage.Controls.Add(AllUsersLabel);
            UsersTabPage.Controls.Add(NewUserLabel);
            UsersTabPage.Controls.Add(ChangePassLabel);
            UsersTabPage.Location = new Point(4, 39);
            UsersTabPage.Margin = new Padding(5, 6, 5, 6);
            UsersTabPage.Name = "UsersTabPage";
            UsersTabPage.Padding = new Padding(5, 6, 5, 6);
            UsersTabPage.Size = new Size(426, 203);
            UsersTabPage.TabIndex = 0;
            UsersTabPage.Text = "Пользователи";
            UsersTabPage.UseVisualStyleBackColor = true;
            // 
            // LogoutLabel
            // 
            LogoutLabel.AutoSize = true;
            LogoutLabel.Enabled = false;
            LogoutLabel.Location = new Point(3, 150);
            LogoutLabel.Margin = new Padding(5, 0, 5, 0);
            LogoutLabel.Name = "LogoutLabel";
            LogoutLabel.Size = new Size(73, 30);
            LogoutLabel.TabIndex = 3;
            LogoutLabel.Text = "Выход";
            LogoutLabel.Click += LogoutLabel_Click;
            LogoutLabel.MouseEnter += Label_Enter;
            LogoutLabel.MouseLeave += Label_Leave;
            // 
            // AllUsersLabel
            // 
            AllUsersLabel.AutoSize = true;
            AllUsersLabel.Enabled = false;
            AllUsersLabel.Location = new Point(3, 66);
            AllUsersLabel.Margin = new Padding(5, 0, 5, 0);
            AllUsersLabel.Name = "AllUsersLabel";
            AllUsersLabel.Size = new Size(184, 30);
            AllUsersLabel.TabIndex = 2;
            AllUsersLabel.Text = "Все пользователи";
            AllUsersLabel.Click += AllUsersLabel_Click;
            AllUsersLabel.MouseEnter += Label_Enter;
            AllUsersLabel.MouseLeave += Label_Leave;
            // 
            // NewUserLabel
            // 
            NewUserLabel.AutoSize = true;
            NewUserLabel.Enabled = false;
            NewUserLabel.Location = new Point(3, 36);
            NewUserLabel.Margin = new Padding(5, 0, 5, 0);
            NewUserLabel.Name = "NewUserLabel";
            NewUserLabel.Size = new Size(215, 30);
            NewUserLabel.TabIndex = 1;
            NewUserLabel.Text = "Новый пользователь";
            NewUserLabel.Click += NewUserLabel_Click;
            NewUserLabel.MouseEnter += Label_Enter;
            NewUserLabel.MouseLeave += Label_Leave;
            // 
            // ChangePassLabel
            // 
            ChangePassLabel.AutoSize = true;
            ChangePassLabel.BackColor = Color.Transparent;
            ChangePassLabel.Enabled = false;
            ChangePassLabel.Location = new Point(3, 6);
            ChangePassLabel.Margin = new Padding(5, 0, 5, 0);
            ChangePassLabel.Name = "ChangePassLabel";
            ChangePassLabel.Size = new Size(171, 30);
            ChangePassLabel.TabIndex = 0;
            ChangePassLabel.Text = "Сменить пароль";
            ChangePassLabel.Click += ChangePassLabel_Click;
            ChangePassLabel.MouseEnter += Label_Enter;
            ChangePassLabel.MouseLeave += Label_Leave;
            // 
            // RefTabPage
            // 
            RefTabPage.BorderStyle = BorderStyle.FixedSingle;
            RefTabPage.Controls.Add(AboutLabel);
            RefTabPage.Location = new Point(4, 39);
            RefTabPage.Margin = new Padding(5, 6, 5, 6);
            RefTabPage.Name = "RefTabPage";
            RefTabPage.Padding = new Padding(5, 6, 5, 6);
            RefTabPage.Size = new Size(426, 203);
            RefTabPage.TabIndex = 1;
            RefTabPage.Text = "Справка";
            RefTabPage.UseVisualStyleBackColor = true;
            // 
            // AboutLabel
            // 
            AboutLabel.AutoSize = true;
            AboutLabel.Location = new Point(5, 6);
            AboutLabel.Margin = new Padding(5, 0, 5, 0);
            AboutLabel.Name = "AboutLabel";
            AboutLabel.Size = new Size(143, 30);
            AboutLabel.TabIndex = 0;
            AboutLabel.Text = "О программе";
            AboutLabel.Click += AboutLabel_Click;
            AboutLabel.MouseEnter += Label_Enter;
            AboutLabel.MouseLeave += Label_Leave;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(28, 28);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // LoginButton
            // 
            LoginButton.AutoSize = true;
            LoginButton.Location = new Point(285, 262);
            LoginButton.Margin = new Padding(5, 6, 5, 6);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(129, 54);
            LoginButton.TabIndex = 2;
            LoginButton.Text = "Войти";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // LoggedInUsernameLabel
            // 
            LoggedInUsernameLabel.AutoSize = true;
            LoggedInUsernameLabel.Location = new Point(15, 270);
            LoggedInUsernameLabel.Margin = new Padding(5, 0, 5, 0);
            LoggedInUsernameLabel.Name = "LoggedInUsernameLabel";
            LoggedInUsernameLabel.Size = new Size(0, 30);
            LoggedInUsernameLabel.TabIndex = 3;
            LoggedInUsernameLabel.Visible = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 332);
            Controls.Add(LoggedInUsernameLabel);
            Controls.Add(LoginButton);
            Controls.Add(TabControl);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5, 6, 5, 6);
            Name = "Main";
            Text = "Программа";
            Load += Main_Load;
            FormClosing += Main_FormClosing;
            TabControl.ResumeLayout(false);
            UsersTabPage.ResumeLayout(false);
            UsersTabPage.PerformLayout();
            RefTabPage.ResumeLayout(false);
            RefTabPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }       

        #endregion

        private TabControl TabControl;
        private TabPage UsersTabPage;
        private TabPage RefTabPage;
        private ContextMenuStrip contextMenuStrip1;
        private Button LoginButton;
        private Label ChangePassLabel;
        private Label NewUserLabel;
        private Label AllUsersLabel;
        private Label LogoutLabel;
        private Label AboutLabel;
        private Label LoggedInUsernameLabel;
    }
}