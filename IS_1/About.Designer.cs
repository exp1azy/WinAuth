namespace IS_1
{
    partial class About
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
            AboutLabel = new Label();
            AboutLabel1 = new Label();
            AboutLabel2 = new Label();
            OKButton = new Button();
            SuspendLayout();
            // 
            // AboutLabel
            // 
            AboutLabel.AutoSize = true;
            AboutLabel.Location = new Point(102, 55);
            AboutLabel.Name = "AboutLabel";
            AboutLabel.Size = new Size(326, 30);
            AboutLabel.TabIndex = 0;
            AboutLabel.Text = "Программа написана студентом";
            // 
            // AboutLabel1
            // 
            AboutLabel1.AutoSize = true;
            AboutLabel1.Location = new Point(37, 97);
            AboutLabel1.Name = "AboutLabel1";
            AboutLabel1.Size = new Size(460, 30);
            AboutLabel1.TabIndex = 1;
            AboutLabel1.Text = "ИДБ-20-08 Паниным Антоном Михайловичем";
            // 
            // AboutLabel2
            // 
            AboutLabel2.AutoSize = true;
            AboutLabel2.Location = new Point(53, 141);
            AboutLabel2.Name = "AboutLabel2";
            AboutLabel2.Size = new Size(440, 30);
            AboutLabel2.TabIndex = 2;
            AboutLabel2.Text = "в рамках 1-й лабораторной работы по МИБ";
            // 
            // OKButton
            // 
            OKButton.Location = new Point(399, 284);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(131, 40);
            OKButton.TabIndex = 3;
            OKButton.Text = "ОК";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 336);
            Controls.Add(OKButton);
            Controls.Add(AboutLabel2);
            Controls.Add(AboutLabel1);
            Controls.Add(AboutLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "About";
            Text = "О программе";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AboutLabel;
        private Label AboutLabel1;
        private Label AboutLabel2;
        private Button OKButton;
    }
}