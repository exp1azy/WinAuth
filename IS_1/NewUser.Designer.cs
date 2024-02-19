namespace IS_1
{
    partial class NewUser
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
            NewUserLabel = new Label();
            NewUserTextbox = new TextBox();
            NewUserButton = new Button();
            SuspendLayout();
            // 
            // NewUserLabel
            // 
            NewUserLabel.AutoSize = true;
            NewUserLabel.Location = new Point(38, 49);
            NewUserLabel.Name = "NewUserLabel";
            NewUserLabel.Size = new Size(265, 30);
            NewUserLabel.TabIndex = 0;
            NewUserLabel.Text = "Имя нового пользователя";
            // 
            // NewUserTextbox
            // 
            NewUserTextbox.Location = new Point(38, 82);
            NewUserTextbox.Name = "NewUserTextbox";
            NewUserTextbox.Size = new Size(380, 35);
            NewUserTextbox.TabIndex = 1;
            // 
            // NewUserButton
            // 
            NewUserButton.Location = new Point(320, 202);
            NewUserButton.Name = "NewUserButton";
            NewUserButton.Size = new Size(131, 40);
            NewUserButton.TabIndex = 2;
            NewUserButton.Text = "Добавить";
            NewUserButton.UseVisualStyleBackColor = true;
            NewUserButton.Click += NewUserButton_Click;
            // 
            // NewUser
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 254);
            Controls.Add(NewUserButton);
            Controls.Add(NewUserTextbox);
            Controls.Add(NewUserLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "NewUser";
            Text = "Новый пользователь";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NewUserLabel;
        private TextBox NewUserTextbox;
        private Button NewUserButton;
    }
}