namespace LibraryApp.Views
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            addUserButton = new Button();
            editUserButton = new Button();
            deleteUserButton = new Button();
            usersListView = new ListView();
            ClientId = new ColumnHeader();
            Surname = new ColumnHeader();
            ClientName = new ColumnHeader();
            MiddleName = new ColumnHeader();
            PhoneNumer = new ColumnHeader();
            addBookButton = new Button();
            editBookButton = new Button();
            deleteBookButton = new Button();
            bookList = new ListView();
            Id = new ColumnHeader();
            Title = new ColumnHeader();
            Author = new ColumnHeader();
            Year = new ColumnHeader();
            PageCount = new ColumnHeader();
            bookReservationMenuButton = new Button();
            groupBox1 = new GroupBox();
            dropFiltersLink = new LinkLabel();
            filterSearchButton = new Button();
            newComerRadioButton = new RadioButton();
            debtorsRadioButton = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            sortButton = new Button();
            label4 = new Label();
            typeSortComboBox = new ComboBox();
            searchDropLabel = new LinkLabel();
            searchLabel = new Label();
            searchlabe = new Label();
            label3 = new Label();
            typeSearchComboBox = new ComboBox();
            searchButton = new Button();
            searchTextBox = new TextBox();
            groupBox3 = new GroupBox();
            dbPerformButton = new Button();
            dbPerformTypeCB = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // addUserButton
            // 
            addUserButton.Location = new Point(27, 311);
            addUserButton.Name = "addUserButton";
            addUserButton.Size = new Size(88, 40);
            addUserButton.TabIndex = 2;
            addUserButton.Text = "Добавить запись";
            addUserButton.UseVisualStyleBackColor = true;
            addUserButton.Click += AddUser_Click;
            // 
            // editUserButton
            // 
            editUserButton.Location = new Point(150, 311);
            editUserButton.Name = "editUserButton";
            editUserButton.Size = new Size(88, 40);
            editUserButton.TabIndex = 1;
            editUserButton.Text = "Изменить запись";
            editUserButton.UseVisualStyleBackColor = true;
            editUserButton.Click += EditUser_Click;
            // 
            // deleteUserButton
            // 
            deleteUserButton.Location = new Point(273, 311);
            deleteUserButton.Name = "deleteUserButton";
            deleteUserButton.Size = new Size(88, 40);
            deleteUserButton.TabIndex = 0;
            deleteUserButton.Text = "Удалить запись";
            deleteUserButton.UseVisualStyleBackColor = true;
            deleteUserButton.Click += DeleteUser_Click;
            // 
            // usersListView
            // 
            usersListView.Columns.AddRange(new ColumnHeader[] { ClientId, Surname, ClientName, MiddleName, PhoneNumer });
            usersListView.Location = new Point(27, 57);
            usersListView.Name = "usersListView";
            usersListView.Size = new Size(698, 231);
            usersListView.TabIndex = 3;
            usersListView.UseCompatibleStateImageBehavior = false;
            usersListView.View = View.Details;
            // 
            // ClientId
            // 
            ClientId.Text = "Id клиента";
            ClientId.Width = 100;
            // 
            // Surname
            // 
            Surname.Text = "Фамилия";
            Surname.Width = 150;
            // 
            // ClientName
            // 
            ClientName.Text = "Имя";
            ClientName.Width = 150;
            // 
            // MiddleName
            // 
            MiddleName.Text = "Отчество";
            MiddleName.Width = 150;
            // 
            // PhoneNumer
            // 
            PhoneNumer.Text = "Номер телефона";
            PhoneNumer.Width = 140;
            // 
            // addBookButton
            // 
            addBookButton.Location = new Point(27, 744);
            addBookButton.Name = "addBookButton";
            addBookButton.Size = new Size(88, 40);
            addBookButton.TabIndex = 4;
            addBookButton.Text = "Добавить запись";
            addBookButton.UseVisualStyleBackColor = true;
            addBookButton.Click += AddBook_Click;
            // 
            // editBookButton
            // 
            editBookButton.Location = new Point(150, 744);
            editBookButton.Name = "editBookButton";
            editBookButton.Size = new Size(88, 40);
            editBookButton.TabIndex = 5;
            editBookButton.Text = "Изменить запись";
            editBookButton.UseVisualStyleBackColor = true;
            editBookButton.Click += EditBook_Click;
            // 
            // deleteBookButton
            // 
            deleteBookButton.Location = new Point(273, 744);
            deleteBookButton.Name = "deleteBookButton";
            deleteBookButton.Size = new Size(88, 40);
            deleteBookButton.TabIndex = 6;
            deleteBookButton.Text = "Удалить запись";
            deleteBookButton.UseVisualStyleBackColor = true;
            deleteBookButton.Click += DeleteBook_Click;
            // 
            // bookList
            // 
            bookList.Columns.AddRange(new ColumnHeader[] { Id, Title, Author, Year, PageCount });
            bookList.Location = new Point(27, 431);
            bookList.Name = "bookList";
            bookList.Size = new Size(668, 293);
            bookList.TabIndex = 7;
            bookList.UseCompatibleStateImageBehavior = false;
            bookList.View = View.Details;
            // 
            // Id
            // 
            Id.Text = "Id";
            // 
            // Title
            // 
            Title.Text = "Название";
            Title.Width = 150;
            // 
            // Author
            // 
            Author.Text = "Автор";
            Author.Width = 250;
            // 
            // Year
            // 
            Year.Text = "Год издания";
            Year.Width = 100;
            // 
            // PageCount
            // 
            PageCount.Text = "Кол-во страниц";
            PageCount.Width = 100;
            // 
            // bookReservationMenuButton
            // 
            bookReservationMenuButton.Location = new Point(762, 738);
            bookReservationMenuButton.Name = "bookReservationMenuButton";
            bookReservationMenuButton.Size = new Size(185, 46);
            bookReservationMenuButton.TabIndex = 9;
            bookReservationMenuButton.Text = "Меню выдачи книг";
            bookReservationMenuButton.UseVisualStyleBackColor = true;
            bookReservationMenuButton.Click += bookReservationMenuButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dropFiltersLink);
            groupBox1.Controls.Add(filterSearchButton);
            groupBox1.Controls.Add(newComerRadioButton);
            groupBox1.Controls.Add(debtorsRadioButton);
            groupBox1.Location = new Point(762, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(214, 153);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Фильтр";
            // 
            // dropFiltersLink
            // 
            dropFiltersLink.AutoSize = true;
            dropFiltersLink.LinkColor = Color.FromArgb(64, 64, 64);
            dropFiltersLink.Location = new Point(134, 117);
            dropFiltersLink.Name = "dropFiltersLink";
            dropFiltersLink.Size = new Size(60, 15);
            dropFiltersLink.TabIndex = 3;
            dropFiltersLink.TabStop = true;
            dropFiltersLink.Text = "Сбросить";
            dropFiltersLink.LinkClicked += dropFiltersLink_LinkClicked;
            // 
            // filterSearchButton
            // 
            filterSearchButton.Location = new Point(16, 110);
            filterSearchButton.Name = "filterSearchButton";
            filterSearchButton.Size = new Size(93, 28);
            filterSearchButton.TabIndex = 2;
            filterSearchButton.Text = "Применить";
            filterSearchButton.UseVisualStyleBackColor = true;
            filterSearchButton.Click += filterSearchButton_Click;
            // 
            // newComerRadioButton
            // 
            newComerRadioButton.AutoSize = true;
            newComerRadioButton.Location = new Point(16, 52);
            newComerRadioButton.Name = "newComerRadioButton";
            newComerRadioButton.Size = new Size(105, 19);
            newComerRadioButton.TabIndex = 1;
            newComerRadioButton.TabStop = true;
            newComerRadioButton.Text = "Не брали книг";
            // 
            // debtorsRadioButton
            // 
            debtorsRadioButton.AutoSize = true;
            debtorsRadioButton.Location = new Point(16, 27);
            debtorsRadioButton.Name = "debtorsRadioButton";
            debtorsRadioButton.Size = new Size(83, 19);
            debtorsRadioButton.TabIndex = 0;
            debtorsRadioButton.TabStop = true;
            debtorsRadioButton.Text = "Должники";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(27, 16);
            label1.Name = "label1";
            label1.Size = new Size(136, 25);
            label1.TabIndex = 12;
            label1.Text = "База клиентов";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(27, 387);
            label2.Name = "label2";
            label2.Size = new Size(162, 25);
            label2.TabIndex = 13;
            label2.Text = "Книгохранилище";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(sortButton);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(typeSortComboBox);
            groupBox2.Controls.Add(searchDropLabel);
            groupBox2.Controls.Add(searchLabel);
            groupBox2.Controls.Add(searchlabe);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(typeSearchComboBox);
            groupBox2.Controls.Add(searchButton);
            groupBox2.Controls.Add(searchTextBox);
            groupBox2.Location = new Point(762, 431);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(366, 247);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Поиск";
            // 
            // sortButton
            // 
            sortButton.Location = new Point(259, 192);
            sortButton.Name = "sortButton";
            sortButton.Size = new Size(92, 23);
            sortButton.TabIndex = 9;
            sortButton.Text = "Сортировать";
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += sortButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 165);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 8;
            label4.Text = "Сортировка";
            // 
            // typeSortComboBox
            // 
            typeSortComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeSortComboBox.FormattingEnabled = true;
            typeSortComboBox.Items.AddRange(new object[] { "А-Я", "Я-А", "Меньше страниц", "Больше страниц" });
            typeSortComboBox.Location = new Point(14, 192);
            typeSortComboBox.Name = "typeSortComboBox";
            typeSortComboBox.Size = new Size(223, 23);
            typeSortComboBox.TabIndex = 7;
            // 
            // searchDropLabel
            // 
            searchDropLabel.AutoSize = true;
            searchDropLabel.LinkColor = Color.FromArgb(64, 64, 64);
            searchDropLabel.Location = new Point(282, 32);
            searchDropLabel.Name = "searchDropLabel";
            searchDropLabel.Size = new Size(60, 15);
            searchDropLabel.TabIndex = 6;
            searchDropLabel.TabStop = true;
            searchDropLabel.Text = "Сбросить";
            searchDropLabel.LinkClicked += searchDropLabel_LinkClicked;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(79, 72);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(0, 15);
            searchLabel.TabIndex = 5;
            // 
            // searchlabe
            // 
            searchlabe.AutoSize = true;
            searchlabe.Location = new Point(14, 72);
            searchlabe.Name = "searchlabe";
            searchlabe.Size = new Size(113, 15);
            searchlabe.TabIndex = 4;
            searchlabe.Text = "Ничего не найдено";
            searchlabe.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 102);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 3;
            label3.Text = "Тип поиска";
            // 
            // typeSearchComboBox
            // 
            typeSearchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeSearchComboBox.FormattingEnabled = true;
            typeSearchComboBox.Items.AddRange(new object[] { "По названию", "По автору" });
            typeSearchComboBox.Location = new Point(14, 130);
            typeSearchComboBox.Name = "typeSearchComboBox";
            typeSearchComboBox.Size = new Size(223, 23);
            typeSearchComboBox.TabIndex = 2;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(243, 28);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(24, 23);
            searchButton.TabIndex = 1;
            searchButton.Text = "🔍";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(14, 28);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(223, 23);
            searchTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dbPerformButton);
            groupBox3.Controls.Add(dbPerformTypeCB);
            groupBox3.Location = new Point(762, 296);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(307, 88);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Действия с БД";
            // 
            // dbPerformButton
            // 
            dbPerformButton.Location = new Point(206, 31);
            dbPerformButton.Name = "dbPerformButton";
            dbPerformButton.Size = new Size(84, 23);
            dbPerformButton.TabIndex = 1;
            dbPerformButton.Text = "Выполнить";
            dbPerformButton.UseVisualStyleBackColor = true;
            dbPerformButton.Click += dbPerformButton_Click;
            // 
            // dbPerformTypeCB
            // 
            dbPerformTypeCB.DropDownStyle = ComboBoxStyle.DropDownList;
            dbPerformTypeCB.FormattingEnabled = true;
            dbPerformTypeCB.Items.AddRange(new object[] { "Удалить БД", "Создать БД", "Сохранить БД в файл" });
            dbPerformTypeCB.Location = new Point(10, 31);
            dbPerformTypeCB.Name = "dbPerformTypeCB";
            dbPerformTypeCB.Size = new Size(166, 23);
            dbPerformTypeCB.TabIndex = 0;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 829);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(bookReservationMenuButton);
            Controls.Add(addBookButton);
            Controls.Add(editBookButton);
            Controls.Add(deleteBookButton);
            Controls.Add(bookList);
            Controls.Add(deleteUserButton);
            Controls.Add(editUserButton);
            Controls.Add(addUserButton);
            Controls.Add(usersListView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Библиотека";
            Load += MainWindow_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Button editUserButton;
        private System.Windows.Forms.Button deleteUserButton;

        #endregion

        private Button addBookButton;
        private Button editBookButton;
        private Button deleteBookButton;
        private ListView bookList;
        private Button bookReservationMenuButton;
        private ColumnHeader Surname;
        private ColumnHeader MiddleName;
        private ColumnHeader ClientName;
        private ColumnHeader PhoneNumer;
        private ColumnHeader Id;
        private ColumnHeader Title;
        private ColumnHeader Author;
        private ColumnHeader Year;
        private ColumnHeader PageCount;
        private ColumnHeader ClientId;
        private GroupBox groupBox1;
        private Button filterSearchButton;
        private RadioButton newComerRadioButton;
        private RadioButton debtorsRadioButton;
        private LinkLabel dropFiltersLink;
        private Label label1;
        private Label label2;
        private GroupBox groupBox2;
        private TextBox searchTextBox;
        private Label label3;
        private ComboBox typeSearchComboBox;
        private Button searchButton;
        private Label searchLabel;
        private Label searchlabe;
        private LinkLabel searchDropLabel;
        private GroupBox groupBox3;
        private Button dbPerformButton;
        private ComboBox dbPerformTypeCB;
        private Label label4;
        private ComboBox typeSortComboBox;
        private Button sortButton;
    }
}
