namespace IS_1
{
    partial class Passphrase
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
            PassphraseLabel = new Label();
            PassphraseTextbox = new TextBox();
            PassphraseButton = new Button();
            SuspendLayout();
            // 
            // PassphraseLabel
            // 
            PassphraseLabel.AutoSize = true;
            PassphraseLabel.Location = new Point(12, 9);
            PassphraseLabel.Name = "PassphraseLabel";
            PassphraseLabel.Size = new Size(292, 15);
            PassphraseLabel.TabIndex = 0;
            PassphraseLabel.Text = "Пароль для расшифрования базы учетных записей";
            // 
            // PassphraseTextbox
            // 
            PassphraseTextbox.Location = new Point(12, 27);
            PassphraseTextbox.Name = "PassphraseTextbox";
            PassphraseTextbox.PasswordChar = '*';
            PassphraseTextbox.Size = new Size(292, 23);
            PassphraseTextbox.TabIndex = 1;
            // 
            // PassphraseButton
            // 
            PassphraseButton.Location = new Point(229, 67);
            PassphraseButton.Name = "PassphraseButton";
            PassphraseButton.Size = new Size(75, 23);
            PassphraseButton.TabIndex = 2;
            PassphraseButton.Text = "ОК";
            PassphraseButton.UseVisualStyleBackColor = true;
            PassphraseButton.Click += PassphraseButton_Click;
            // 
            // Passphrase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 102);
            Controls.Add(PassphraseButton);
            Controls.Add(PassphraseTextbox);
            Controls.Add(PassphraseLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Passphrase";
            Text = "Расшифрование базы данных";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PassphraseLabel;
        private TextBox PassphraseTextbox;
        private Button PassphraseButton;
    }
}