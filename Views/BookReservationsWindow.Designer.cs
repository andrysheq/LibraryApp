namespace LibraryApp.Views
{
    partial class BookReservationsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookReservationsWindow));
            addReservationButton = new Button();
            editReservationButton = new Button();
            deleteReservationButton = new Button();
            bookReservationsListView = new ListView();
            Id = new ColumnHeader();
            ClientId = new ColumnHeader();
            BookId = new ColumnHeader();
            IssueDate = new ColumnHeader();
            DueDate = new ColumnHeader();
            ReturnDate = new ColumnHeader();
            button1 = new Button();
            SuspendLayout();
            // 
            // addReservationButton
            // 
            addReservationButton.Location = new Point(27, 266);
            addReservationButton.Name = "addReservationButton";
            addReservationButton.Size = new Size(88, 40);
            addReservationButton.TabIndex = 2;
            addReservationButton.Text = "Добавить запись";
            addReservationButton.UseVisualStyleBackColor = true;
            addReservationButton.Click += AddReservation_Click;
            // 
            // editReservationButton
            // 
            editReservationButton.Location = new Point(150, 266);
            editReservationButton.Name = "editReservationButton";
            editReservationButton.Size = new Size(88, 40);
            editReservationButton.TabIndex = 1;
            editReservationButton.Text = "Изменить запись";
            editReservationButton.UseVisualStyleBackColor = true;
            editReservationButton.Click += EditReservation_Click;
            // 
            // deleteReservationButton
            // 
            deleteReservationButton.Location = new Point(273, 266);
            deleteReservationButton.Name = "deleteReservationButton";
            deleteReservationButton.Size = new Size(88, 40);
            deleteReservationButton.TabIndex = 0;
            deleteReservationButton.Text = "Удалить запись";
            deleteReservationButton.UseVisualStyleBackColor = true;
            deleteReservationButton.Click += DeleteReservation_Click;
            // 
            // bookReservationsListView
            // 
            bookReservationsListView.Columns.AddRange(new ColumnHeader[] { Id, ClientId, BookId, IssueDate, DueDate, ReturnDate });
            bookReservationsListView.Location = new Point(27, 12);
            bookReservationsListView.Name = "bookReservationsListView";
            bookReservationsListView.Size = new Size(685, 231);
            bookReservationsListView.TabIndex = 3;
            bookReservationsListView.UseCompatibleStateImageBehavior = false;
            bookReservationsListView.View = View.Details;
            // 
            // Id
            // 
            Id.Text = "Id";
            Id.Width = 40;
            // 
            // ClientId
            // 
            ClientId.Text = "Id читателя";
            ClientId.Width = 80;
            // 
            // BookId
            // 
            BookId.Text = "Id книги";
            // 
            // IssueDate
            // 
            IssueDate.Text = "Дата выдачи";
            IssueDate.Width = 150;
            // 
            // DueDate
            // 
            DueDate.Text = "Дата предпологаемого возврата";
            DueDate.Width = 200;
            // 
            // ReturnDate
            // 
            ReturnDate.Text = "Возвращено";
            ReturnDate.Width = 150;
            // 
            // button1
            // 
            button1.Location = new Point(396, 266);
            button1.Name = "button1";
            button1.Size = new Size(123, 40);
            button1.TabIndex = 4;
            button1.Text = "Зарегистрировать возврат";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ReturnBook_Click;
            // 
            // BookReservationsWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 382);
            Controls.Add(button1);
            Controls.Add(deleteReservationButton);
            Controls.Add(editReservationButton);
            Controls.Add(addReservationButton);
            Controls.Add(bookReservationsListView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BookReservationsWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Меню учёта выданных книг";
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button addReservationButton;
        private System.Windows.Forms.Button editReservationButton;
        private System.Windows.Forms.Button deleteReservationButton;

#endregion
        private ListView bookReservationsListView;
        private Button button1;
        private ColumnHeader Id;
        private ColumnHeader ClientId;
        private ColumnHeader BookId;
        private ColumnHeader IssueDate;
        private ColumnHeader DueDate;
        private ColumnHeader ReturnDate;
    }
}
