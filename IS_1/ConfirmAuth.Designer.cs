namespace IS_1
{
    partial class ConfirmAuth
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
            ConfirmPassLabel = new Label();
            ConfirmPassTextbox = new TextBox();
            ConfirmPassButton = new Button();
            SuspendLayout();
            // 
            // ConfirmPassLabel
            // 
            ConfirmPassLabel.AutoSize = true;
            ConfirmPassLabel.Location = new Point(21, 18);
            ConfirmPassLabel.Margin = new Padding(5, 0, 5, 0);
            ConfirmPassLabel.Name = "ConfirmPassLabel";
            ConfirmPassLabel.Size = new Size(212, 30);
            ConfirmPassLabel.TabIndex = 0;
            ConfirmPassLabel.Text = "Подтвердите пароль";
            // 
            // ConfirmPassTextbox
            // 
            ConfirmPassTextbox.Location = new Point(21, 54);
            ConfirmPassTextbox.Margin = new Padding(5, 6, 5, 6);
            ConfirmPassTextbox.Name = "ConfirmPassTextbox";
            ConfirmPassTextbox.PasswordChar = '*';
            ConfirmPassTextbox.Size = new Size(400, 35);
            ConfirmPassTextbox.TabIndex = 1;
            // 
            // ConfirmPassButton
            // 
            ConfirmPassButton.Location = new Point(267, 138);
            ConfirmPassButton.Margin = new Padding(5, 6, 5, 6);
            ConfirmPassButton.Name = "ConfirmPassButton";
            ConfirmPassButton.Size = new Size(156, 46);
            ConfirmPassButton.TabIndex = 2;
            ConfirmPassButton.Text = "Подтвердить";
            ConfirmPassButton.UseVisualStyleBackColor = true;
            ConfirmPassButton.Click += ConfirmPassButton_Click;
            // 
            // ConfirmAuth
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 208);
            Controls.Add(ConfirmPassButton);
            Controls.Add(ConfirmPassTextbox);
            Controls.Add(ConfirmPassLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5, 6, 5, 6);
            Name = "ConfirmAuth";
            Text = "Подтверждение";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ConfirmPassLabel;
        private TextBox ConfirmPassTextbox;
        private Button ConfirmPassButton;
    }
}