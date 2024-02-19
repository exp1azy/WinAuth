namespace IS_1
{
    partial class ChangePassword
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
            OldPasswordLabel = new Label();
            OldPasswordTextbox = new TextBox();
            NewPasswordLavel = new Label();
            NewPasswordTextbox = new TextBox();
            ConfirmNewPasswordLabel = new Label();
            ConfirmNewPasswordTextbox = new TextBox();
            ConfirmButton = new Button();
            SuspendLayout();
            // 
            // OldPasswordLabel
            // 
            OldPasswordLabel.AutoSize = true;
            OldPasswordLabel.Location = new Point(12, 9);
            OldPasswordLabel.Name = "OldPasswordLabel";
            OldPasswordLabel.Size = new Size(136, 15);
            OldPasswordLabel.TabIndex = 0;
            OldPasswordLabel.Text = "Введите старый пароль";
            // 
            // OldPasswordTextbox
            // 
            OldPasswordTextbox.Location = new Point(12, 27);
            OldPasswordTextbox.Name = "OldPasswordTextbox";
            OldPasswordTextbox.Size = new Size(207, 23);
            OldPasswordTextbox.TabIndex = 1;
            // 
            // NewPasswordLavel
            // 
            NewPasswordLavel.AutoSize = true;
            NewPasswordLavel.Location = new Point(12, 53);
            NewPasswordLavel.Name = "NewPasswordLavel";
            NewPasswordLavel.Size = new Size(132, 15);
            NewPasswordLavel.TabIndex = 2;
            NewPasswordLavel.Text = "Введите новый пароль";
            // 
            // NewPasswordTextbox
            // 
            NewPasswordTextbox.Location = new Point(12, 71);
            NewPasswordTextbox.Name = "NewPasswordTextbox";
            NewPasswordTextbox.Size = new Size(207, 23);
            NewPasswordTextbox.TabIndex = 3;
            // 
            // ConfirmNewPasswordLabel
            // 
            ConfirmNewPasswordLabel.AutoSize = true;
            ConfirmNewPasswordLabel.Location = new Point(12, 97);
            ConfirmNewPasswordLabel.Name = "ConfirmNewPasswordLabel";
            ConfirmNewPasswordLabel.Size = new Size(77, 15);
            ConfirmNewPasswordLabel.TabIndex = 4;
            ConfirmNewPasswordLabel.Text = "Подтвердите";
            // 
            // ConfirmNewPasswordTextbox
            // 
            ConfirmNewPasswordTextbox.Location = new Point(12, 115);
            ConfirmNewPasswordTextbox.Name = "ConfirmNewPasswordTextbox";
            ConfirmNewPasswordTextbox.Size = new Size(207, 23);
            ConfirmNewPasswordTextbox.TabIndex = 5;
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(130, 165);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(89, 23);
            ConfirmButton.TabIndex = 6;
            ConfirmButton.Text = "Подтвердить";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 200);
            Controls.Add(ConfirmButton);
            Controls.Add(ConfirmNewPasswordTextbox);
            Controls.Add(ConfirmNewPasswordLabel);
            Controls.Add(NewPasswordTextbox);
            Controls.Add(NewPasswordLavel);
            Controls.Add(OldPasswordTextbox);
            Controls.Add(OldPasswordLabel);
            Name = "ChangePassword";
            Text = "Сменить пароль";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OldPasswordLabel;
        private TextBox OldPasswordTextbox;
        private Label NewPasswordLavel;
        private TextBox NewPasswordTextbox;
        private Label ConfirmNewPasswordLabel;
        private TextBox ConfirmNewPasswordTextbox;
        private Button ConfirmButton;
    }
}