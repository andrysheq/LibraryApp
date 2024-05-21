namespace LibraryApp.Views
{
    partial class BookDialogWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookDialogWindow));
            nameLabel = new Label();
            ageLabel = new Label();
            titleTextBox = new TextBox();
            authorTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            pagesTextBox = new TextBox();
            yearsTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(79, 30);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(62, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Название:";
            // 
            // ageLabel
            // 
            ageLabel.AutoSize = true;
            ageLabel.Location = new Point(79, 65);
            ageLabel.Name = "ageLabel";
            ageLabel.Size = new Size(43, 15);
            ageLabel.TabIndex = 1;
            ageLabel.Text = "Автор:";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(189, 27);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(116, 23);
            titleTextBox.TabIndex = 2;
            // 
            // authorTextBox
            // 
            authorTextBox.Location = new Point(189, 62);
            authorTextBox.Name = "authorTextBox";
            authorTextBox.Size = new Size(116, 23);
            authorTextBox.TabIndex = 3;
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
            // pagesTextBox
            // 
            pagesTextBox.Location = new Point(189, 135);
            pagesTextBox.Name = "pagesTextBox";
            pagesTextBox.Size = new Size(116, 23);
            pagesTextBox.TabIndex = 7;
            // 
            // yearsTextBox
            // 
            yearsTextBox.Location = new Point(189, 100);
            yearsTextBox.Name = "yearsTextBox";
            yearsTextBox.Size = new Size(116, 23);
            yearsTextBox.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 138);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 9;
            label1.Text = "Кол-во страниц:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 103);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 8;
            label2.Text = "Год издания:";
            // 
            // BookDialogWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 276);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(pagesTextBox);
            Controls.Add(yearsTextBox);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(authorTextBox);
            Controls.Add(titleTextBox);
            Controls.Add(ageLabel);
            Controls.Add(nameLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BookDialogWindow";
            Text = "Редактор книги";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;

        #endregion

        private TextBox pagesTextBox;
        private TextBox yearsTextBox;
        private Label label1;
        private Label label2;
    }
}
