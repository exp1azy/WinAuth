namespace IS_1
{
    partial class AllUsers
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
            UserLabel = new Label();
            UserTextbox = new TextBox();
            BlockedCheckbox = new CheckBox();
            PassRestrictionsCheckbox = new CheckBox();
            NextButton = new Button();
            SaveButton = new Button();
            OKButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // UserLabel
            // 
            UserLabel.AutoSize = true;
            UserLabel.Location = new Point(12, 9);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(192, 30);
            UserLabel.TabIndex = 0;
            UserLabel.Text = "Имя пользователя";
            // 
            // UserTextbox
            // 
            UserTextbox.Location = new Point(12, 42);
            UserTextbox.Name = "UserTextbox";
            UserTextbox.Size = new Size(292, 35);
            UserTextbox.TabIndex = 1;
            // 
            // BlockedCheckbox
            // 
            BlockedCheckbox.AutoSize = true;
            BlockedCheckbox.CheckAlign = ContentAlignment.MiddleRight;
            BlockedCheckbox.Location = new Point(140, 134);
            BlockedCheckbox.Name = "BlockedCheckbox";
            BlockedCheckbox.Size = new Size(152, 34);
            BlockedCheckbox.TabIndex = 3;
            BlockedCheckbox.Text = "Блокировка";
            BlockedCheckbox.UseVisualStyleBackColor = true;
            // 
            // PassRestrictionsCheckbox
            // 
            PassRestrictionsCheckbox.AutoSize = true;
            PassRestrictionsCheckbox.CheckAlign = ContentAlignment.MiddleRight;
            PassRestrictionsCheckbox.Location = new Point(12, 94);
            PassRestrictionsCheckbox.Name = "PassRestrictionsCheckbox";
            PassRestrictionsCheckbox.Size = new Size(280, 34);
            PassRestrictionsCheckbox.TabIndex = 4;
            PassRestrictionsCheckbox.Text = "Парольные ограничения";
            PassRestrictionsCheckbox.UseVisualStyleBackColor = true;
            // 
            // NextButton
            // 
            NextButton.Location = new Point(12, 194);
            NextButton.Name = "NextButton";
            NextButton.Size = new Size(154, 40);
            NextButton.TabIndex = 5;
            NextButton.Text = "Следующий";
            NextButton.UseVisualStyleBackColor = true;
            NextButton.Click += NextButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(262, 194);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(131, 40);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // OKButton
            // 
            OKButton.Location = new Point(12, 266);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(154, 40);
            OKButton.TabIndex = 7;
            OKButton.Text = "ОК";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(262, 266);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(131, 40);
            CancelButton.TabIndex = 8;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AllUsers
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 318);
            Controls.Add(CancelButton);
            Controls.Add(OKButton);
            Controls.Add(SaveButton);
            Controls.Add(NextButton);
            Controls.Add(PassRestrictionsCheckbox);
            Controls.Add(BlockedCheckbox);
            Controls.Add(UserTextbox);
            Controls.Add(UserLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AllUsers";
            Text = "Все пользователи";
            Load += AllUsers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserLabel;
        private TextBox UserTextbox;
        private CheckBox BlockedCheckbox;
        private CheckBox PassRestrictionsCheckbox;
        private Button NextButton;
        private Button SaveButton;
        private Button OKButton;
        private Button CancelButton;
    }
}