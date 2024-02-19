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
            AboutLabel3 = new Label();
            SuspendLayout();
            // 
            // AboutLabel
            // 
            AboutLabel.AutoSize = true;
            AboutLabel.Location = new Point(59, 28);
            AboutLabel.Margin = new Padding(2, 0, 2, 0);
            AboutLabel.Name = "AboutLabel";
            AboutLabel.Size = new Size(187, 15);
            AboutLabel.TabIndex = 0;
            AboutLabel.Text = "Программа написана студентом";
            // 
            // AboutLabel1
            // 
            AboutLabel1.AutoSize = true;
            AboutLabel1.Location = new Point(22, 48);
            AboutLabel1.Margin = new Padding(2, 0, 2, 0);
            AboutLabel1.Name = "AboutLabel1";
            AboutLabel1.Size = new Size(264, 15);
            AboutLabel1.TabIndex = 1;
            AboutLabel1.Text = "ИДБ-20-08 Паниным Антоном Михайловичем";
            // 
            // AboutLabel2
            // 
            AboutLabel2.AutoSize = true;
            AboutLabel2.Location = new Point(31, 70);
            AboutLabel2.Margin = new Padding(2, 0, 2, 0);
            AboutLabel2.Name = "AboutLabel2";
            AboutLabel2.Size = new Size(251, 15);
            AboutLabel2.TabIndex = 2;
            AboutLabel2.Text = "в рамках 1-й лабораторной работы по МИБ";
            // 
            // OKButton
            // 
            OKButton.Location = new Point(233, 142);
            OKButton.Margin = new Padding(2, 2, 2, 2);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(76, 20);
            OKButton.TabIndex = 3;
            OKButton.Text = "ОК";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // AboutLabel3
            // 
            AboutLabel3.AutoSize = true;
            AboutLabel3.Location = new Point(73, 104);
            AboutLabel3.Name = "AboutLabel3";
            AboutLabel3.Size = new Size(164, 15);
            AboutLabel3.TabIndex = 4;
            AboutLabel3.Text = "Индивидуальное задание: 11";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(316, 168);
            Controls.Add(AboutLabel3);
            Controls.Add(OKButton);
            Controls.Add(AboutLabel2);
            Controls.Add(AboutLabel1);
            Controls.Add(AboutLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(2, 2, 2, 2);
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
        private Label AboutLabel3;
    }
}