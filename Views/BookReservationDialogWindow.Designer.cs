namespace LibraryApp.Views
{
    partial class BookReservationDialogWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            nameLabel = new Label();
            ageLabel = new Label();
            bookIdTextBox = new TextBox();
            clientIdTextBox = new TextBox();
            issueDateLabel = new Label();
            dueDateLabel = new Label();
            issueDatePicker = new DateTimePicker();
            dueDatePicker = new DateTimePicker();
            returnedCheckBox = new CheckBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(79, 30);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(55, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Id книги:";
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(79, 65);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(67, 15);
            ageLabel.TabIndex = 1;
            ageLabel.Text = "Id клиента:";
            // 
            // bookIdTextBox
            // 
            bookIdTextBox.Location = new Point(189, 27);
            bookIdTextBox.Name = "bookIdTextBox";
            bookIdTextBox.Size = new Size(116, 23);
            bookIdTextBox.TabIndex = 2;
            // 
            // clientIdTextBox
            // 
            clientIdTextBox.Location = new Point(189, 62);
            clientIdTextBox.Name = "clientIdTextBox";
            clientIdTextBox.Size = new Size(116, 23);
            clientIdTextBox.TabIndex = 3;
            // 
            // issueDateLabel
            // 
            issueDateLabel.AutoSize = true;
            issueDateLabel.Location = new Point(79, 100);
            issueDateLabel.Name = "issueDateLabel";
            issueDateLabel.Size = new Size(76, 15);
            issueDateLabel.TabIndex = 6;
            issueDateLabel.Text = "Дата выдачи:";
            // 
            // issueDatePicker
            // 
            issueDatePicker.Location = new Point(189, 95);
            issueDatePicker.Name = "issueDatePicker";
            issueDatePicker.Size = new Size(116, 23);
            issueDatePicker.TabIndex = 7;
            // 
            // dueDateLabel
            // 
            dueDateLabel.AutoSize = true;
            dueDateLabel.Location = new Point(79, 135);
            dueDateLabel.Name = "dueDateLabel";
            dueDateLabel.Size = new Size(105, 15);
            dueDateLabel.TabIndex = 8;
            dueDateLabel.Text = "Дата возврата:";
            // 
            // dueDatePicker
            // 
            dueDatePicker.Location = new Point(189, 130);
            dueDatePicker.Name = "dueDatePicker";
            dueDatePicker.Size = new Size(116, 23);
            dueDatePicker.TabIndex = 9;
            // 
            // returnedCheckBox
            // 
            returnedCheckBox.AutoSize = true;
            returnedCheckBox.Location = new Point(79, 170);
            returnedCheckBox.Name = "returnedCheckBox";
            returnedCheckBox.Size = new Size(117, 19);
            returnedCheckBox.TabIndex = 10;
            returnedCheckBox.Text = "Книга возвращена";
            returnedCheckBox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.Location = new Point(206, 206);
            okButton.Name = "okButton";
            okButton.Size = new Size(88, 26);
            okButton.TabIndex = 4;
            okButton.Text = "Сохранить";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(83, 206);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(88, 26);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // BookReservationDialogWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 276);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(returnedCheckBox);
            Controls.Add(dueDatePicker);
            Controls.Add(dueDateLabel);
            Controls.Add(issueDatePicker);
            Controls.Add(issueDateLabel);
            Controls.Add(clientIdTextBox);
            Controls.Add(bookIdTextBox);
            Controls.Add(ageLabel);
            Controls.Add(nameLabel);
            Name = "BookReservationDialogWindow";
            Text = "Book Reservation";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox bookIdTextBox;
        private System.Windows.Forms.TextBox clientIdTextBox;
        private System.Windows.Forms.Label issueDateLabel;
        private System.Windows.Forms.Label dueDateLabel;
        private System.Windows.Forms.DateTimePicker issueDatePicker;
        private System.Windows.Forms.DateTimePicker dueDatePicker;
        private System.Windows.Forms.CheckBox returnedCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;

        #endregion
    }
}
