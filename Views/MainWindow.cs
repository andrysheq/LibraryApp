using System;
using System.Linq;
using System.Windows.Forms;
using LibraryApp.db;
using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApp.Views
{
    public partial class MainWindow : Form
    {
        private db.ApplicationContext db = new db.ApplicationContext();
        private readonly BookService bookService;
        private readonly ClientService clientService;
        private ListView usersListView;

        public MainWindow()
        {
            InitializeComponent();
            bookService = new BookService(db);
            clientService = new ClientService(db);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // Загружаем данные из БД
            db.Clients.Load();
            db.Books.Load();

            // Добавляем элементы в ListView из БД
            FillClientView(clientService.GetAllClients());
            FillBookView(bookService.GetAllBooks());
        }

        // Добавление пользователя
        private void AddUser_Click(object sender, EventArgs e)
        {
            UserDialogWindow userWindow = new UserDialogWindow(new Client());
            if (userWindow.ShowDialog() == DialogResult.OK)
            {
                Client user = userWindow.User;
                db.Clients.Add(user);
                db.SaveChanges();

                // Добавляем новый элемент в ListView
                ListViewItem item = new ListViewItem(user.Id.ToString());
                item.SubItems.Add(user.Name);
                item.SubItems.Add(user.Surname);
                item.SubItems.Add(user.MiddleName);
                item.SubItems.Add(user.PhoneNumber);
                usersListView.Items.Add(item);
            }
        }

        // Редактирование пользователя
        private void EditUser_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = usersListView.SelectedItems.Count > 0 ? usersListView.SelectedItems[0] : null;
            if (selectedItem == null)
                return;

            int userId = int.Parse(selectedItem.SubItems[0].Text);
            Client user = clientService.GetClientById(userId);
            if (user == null)
                return;

            UserDialogWindow userWindow = new UserDialogWindow(new Client
            {
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Surname = user.Surname,
                MiddleName = user.MiddleName
            });

            if (userWindow.ShowDialog() == DialogResult.OK)
            {
                user.PhoneNumber = userWindow.User.PhoneNumber;
                user.Name = userWindow.User.Name;
                user.Surname = userWindow.User.Surname;
                user.MiddleName = userWindow.User.MiddleName;
                db.SaveChanges();

                // Обновляем элемент в ListView
                UpdateClientView(selectedItem, user);
            }
        }

        // Удаление пользователя
        private void DeleteUser_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = usersListView.SelectedItems.Count > 0 ? usersListView.SelectedItems[0] : null;
            if (selectedItem == null)
                return;

            int userId = int.Parse(selectedItem.SubItems[0].Text);
            Client user = db.Clients.Find(userId);
            if (user == null)
                return;

            db.Clients.Remove(user);
            db.SaveChanges();

            // Удаляем элемент из ListView
            usersListView.Items.Remove(selectedItem);
        }

        // Добавление пользователя
        private void AddBook_Click(object sender, EventArgs e)
        {
            BookDialogWindow bookWindow = new BookDialogWindow(new Book());
            if (bookWindow.ShowDialog() == DialogResult.OK)
            {
                Book book = bookWindow.Book;
                db.Books.Add(book);
                db.SaveChanges();

                // Добавляем новый элемент в ListView
                ListViewItem item = new ListViewItem(book.Id.ToString());
                item.SubItems.Add(book.Title);
                item.SubItems.Add(book.Author);
                item.SubItems.Add(book.Year.ToString());
                item.SubItems.Add(book.PageCount.ToString());
                bookList.Items.Add(item);
            }
        }

        // Редактирование пользователя
        private void EditBook_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = bookList.SelectedItems.Count > 0 ? bookList.SelectedItems[0] : null;
            if (selectedItem == null)
                return;

            int bookId = int.Parse(selectedItem.SubItems[0].Text);
            Book book = db.Books.Find(bookId);
            if (book == null)
                return;

            BookDialogWindow bookWindow = new BookDialogWindow(new Book
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                PageCount = book.PageCount,
            });

            if (bookWindow.ShowDialog() == DialogResult.OK)
            {
                book.Title = bookWindow.Book.Title;
                book.Author = bookWindow.Book.Author;
                book.Year = bookWindow.Book.Year;
                book.PageCount = bookWindow.Book.PageCount;
                db.SaveChanges();

                // Обновляем элемент в ListView
                UpdateBookView(selectedItem, book);
            }
        }

        // Удаление пользователя
        private void DeleteBook_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = bookList.SelectedItems.Count > 0 ? bookList.SelectedItems[0] : null;
            if (selectedItem == null)
                return;

            int bookId = int.Parse(selectedItem.SubItems[0].Text);
            Book book = db.Books.Find(bookId);
            if (book == null)
                return;

            db.Books.Remove(book);
            db.SaveChanges();

            // Удаляем элемент из ListView
            bookList.Items.Remove(selectedItem);
        }

        private void BookListClear()
        {
            bookList.Items.Clear();
        }

        private void ClientListClear()
        {
            usersListView.Items.Clear();
        }

        private void bookReservationMenuButton_Click(object sender, EventArgs e)
        {
            BookReservationsWindow bookWindow = new BookReservationsWindow(db);
            bookWindow.Show();
        }

        private void UpdateClientView(ListViewItem selectedItem, Client client)
        {
            selectedItem.SubItems[1].Text = client.Name.ToString();
            selectedItem.SubItems[2].Text = client.Surname.ToString();
            selectedItem.SubItems[3].Text = client.MiddleName.ToString();
            selectedItem.SubItems[4].Text = client.PhoneNumber.ToString();
        }

        private void UpdateBookView(ListViewItem selectedItem, Book book)
        {
            selectedItem.SubItems[1].Text = book.Title;
            selectedItem.SubItems[2].Text = book.Author;
            selectedItem.SubItems[3].Text = book.Year.ToString();
            selectedItem.SubItems[4].Text = book.PageCount.ToString();
        }

        private void FillClientView(List<Client> clients)
        {
            ClientListClear();
            // Добавляем элементы в ListView из БД
            foreach (var client in clients)
            {
                ListViewItem item = new ListViewItem(client.Id.ToString());
                item.SubItems.Add(client.Surname);
                item.SubItems.Add(client.Name);
                item.SubItems.Add(client.MiddleName);
                item.SubItems.Add(client.PhoneNumber);
                usersListView.Items.Add(item);
            }
        }

        private void FillBookView(List<Book> books)
        {
            BookListClear();
            foreach (var book in books)
            {
                ListViewItem item = new ListViewItem(book.Id.ToString());
                item.SubItems.Add(book.Title);
                item.SubItems.Add(book.Author);
                item.SubItems.Add(book.Year.ToString());
                item.SubItems.Add(book.PageCount.ToString());
                bookList.Items.Add(item);
            }
        }

        private void filterSearchButton_Click(object sender, EventArgs e)
        {
            ClientListClear();
            List<Client> clients = new List<Client>();
            if (debtorsRadioButton.Checked)
            {
                clients = clientService.GetDebtors();
            }
            else if (newComerRadioButton.Checked)
            {
                clients = clientService.GetNewComers();
            }
            else
            {
                clients = clientService.GetAllClients();
            }
            if (clients.Count > 0)
            {
                FillClientView(clients);
            }
        }

        private void dropFiltersLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            newComerRadioButton.Checked = false;
            debtorsRadioButton.Checked = false;
            FillClientView(clientService.GetAllClients());
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchType = typeSearchComboBox.SelectedItem.ToString();
            string searchQuery = searchTextBox.Text.Trim();
            List<Book> results = new List<Book>();
            if (searchType == "По автору")
            {
                results = bookService.SearchBooksByAuthor(searchQuery);
            }
            if (searchType == "По названию")
            {
                results = bookService.SearchBooksByTitle(searchQuery);
            }
            FillBookView(results);

            if (results.Count <= 0)
            {
                searchlabe.Visible = true;
            }
        }

        private void searchDropLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            searchTextBox.Text = "";
            searchlabe.Visible = false;
            FillBookView(bookService.GetAllBooks());
        }
    }
}
