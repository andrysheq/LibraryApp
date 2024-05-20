namespace LibraryApp.Views
{
    partial class UserDialogWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDialogWindow));
            nameLabel = new Label();
            ageLabel = new Label();
            nameTextBox = new TextBox();
            phoneTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            surnameLabel = new Label();
            middleNameLabel = new Label();
            surnameTextBox = new TextBox();
            middleNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(35, 100);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(34, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Имя:";
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(35, 32);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(104, 15);
            ageLabel.TabIndex = 1;
            ageLabel.Text = "Номер телефона:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(145, 65);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(116, 23);
            nameTextBox.TabIndex = 2;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(145, 29);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(116, 23);
            phoneTextBox.TabIndex = 3;
            // 
            // okButton
            // 
            okButton.Location = new Point(173, 184);
            okButton.Name = "okButton";
            okButton.Size = new Size(88, 26);
            okButton.TabIndex = 4;
            okButton.Text = "Сохранить";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(35, 184);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(88, 26);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // surnameLabel
            // 
            surnameLabel.AutoSize = true;
            surnameLabel.Location = new Point(35, 68);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(61, 15);
            surnameLabel.TabIndex = 10;
            surnameLabel.Text = "Фамилия:";
            // 
            // middleNameLabel
            // 
            middleNameLabel.AutoSize = true;
            middleNameLabel.Location = new Point(35, 135);
            middleNameLabel.Name = "middleNameLabel";
            middleNameLabel.Size = new Size(61, 15);
            middleNameLabel.TabIndex = 11;
            middleNameLabel.Text = "Отчество:";
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new Point(145, 97);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(116, 23);
            surnameTextBox.TabIndex = 12;
            // 
            // middleNameTextBox
            // 
            middleNameTextBox.Location = new Point(145, 132);
            middleNameTextBox.Name = "middleNameTextBox";
            middleNameTextBox.Size = new Size(116, 23);
            middleNameTextBox.TabIndex = 13;
            // 
            // UserDialogWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 240);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(phoneTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(ageLabel);
            Controls.Add(nameLabel);
            Controls.Add(surnameLabel);
            Controls.Add(middleNameLabel);
            Controls.Add(surnameTextBox);
            Controls.Add(middleNameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserDialogWindow";
            Text = "UserWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Label middleNameLabel;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox middleNameTextBox;



        #endregion
    }
}
