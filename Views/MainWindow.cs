using System;
using System.Linq;
using System.Windows.Forms;
using LibraryApp.db;
using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryApp.Views
{
    public partial class MainWindow : Form
    {
        private db.ApplicationContext db = new db.ApplicationContext();
        private readonly BookService bookService;
        private readonly ClientService clientService;
        private readonly BookReservationService bookReservationService;
        private ListView usersListView;

        public MainWindow()
        {
            InitializeComponent();
            bookService = new BookService(db);
            clientService = new ClientService(db);
            bookReservationService = new BookReservationService(db);
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

            typeSearchComboBox.SelectedIndex = 0;
            typeSortComboBox.SelectedIndex = 0;
            dbPerformTypeCB.SelectedIndex = 0;
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить пользователя".
        /// </summary>
        private void AddUser_Click(object sender, EventArgs e)
        {
            UserDialogWindow userWindow = new UserDialogWindow(new Client(), db);
            if (userWindow.ShowDialog() == DialogResult.OK)
            {
                Client user = userWindow.User;
                clientService.AddClient(user);

                // Добавляем новый элемент в ListView
                ListViewItem item = new ListViewItem(user.Id.ToString());
                item.SubItems.Add(user.Name);
                item.SubItems.Add(user.Surname);
                item.SubItems.Add(user.MiddleName);
                item.SubItems.Add(user.PhoneNumber);
                usersListView.Items.Add(item);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Редактировать пользователя".
        /// </summary>
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
            }, db);

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

        /// <summary>
        /// Обработчик нажатия кнопки "Удалить пользователя".
        /// </summary>
        private void DeleteUser_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = usersListView.SelectedItems.Count > 0 ? usersListView.SelectedItems[0] : null;
            if (selectedItem == null)
                return;

            int userId = int.Parse(selectedItem.SubItems[0].Text);
            Client user = db.Clients.Find(userId);
            if (user == null)
                return;

            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить пользователя?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                clientService.DeleteClient(userId);

                // Удаляем элемент из ListView
                usersListView.Items.Remove(selectedItem);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Добавить книгу".
        /// </summary>
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

        /// <summary>
        /// Обработчик нажатия кнопки "Редактировать книгу".
        /// </summary>
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

        /// <summary>
        /// Обработчик нажатия кнопки "Удалить книгу".
        /// </summary>
        private void DeleteBook_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = bookList.SelectedItems.Count > 0 ? bookList.SelectedItems[0] : null;
            if (selectedItem == null)
                return;

            int bookId = int.Parse(selectedItem.SubItems[0].Text);
            Book book = db.Books.Find(bookId);
            if (book == null)
                return;

            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить эту книгу?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Удаляем элемент из ListView
            if (result == DialogResult.Yes)
            {
                db.Books.Remove(book);
                db.SaveChanges();

                // Удаляем элемент из ListView
                bookList.Items.Remove(selectedItem);
            }
        }
        /// <summary>
        /// Очистка списка книг
        /// </summary>
        private void BookListClear()
        {
            bookList.Items.Clear();
        }

        /// <summary>
        /// Очищает список клиентов в пользовательском интерфейсе.
        /// </summary>
        private void ClientListClear()
        {
            usersListView.Items.Clear();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Бронирование книги".
        /// </summary>
        private void bookReservationMenuButton_Click(object sender, EventArgs e)
        {
            BookReservationsWindow bookWindow = new BookReservationsWindow(db);
            bookWindow.Show();
        }

        /// <summary>
        /// Обновляет информацию о клиенте в пользовательском интерфейсе.
        /// </summary>
        /// <param name="selectedItem">Выбранный элемент в списке клиентов.</param>
        /// <param name="client">Информация о клиенте для обновления.</param>
        private void UpdateClientView(ListViewItem selectedItem, Client client)
        {
            selectedItem.SubItems[1].Text = client.Name.ToString();
            selectedItem.SubItems[2].Text = client.Surname.ToString();
            selectedItem.SubItems[3].Text = client.MiddleName.ToString();
            selectedItem.SubItems[4].Text = client.PhoneNumber.ToString();
        }

        /// <summary>
        /// Обновляет информацию о книге в пользовательском интерфейсе.
        /// </summary>
        /// <param name="selectedItem">Выбранный элемент в списке книг.</param>
        /// <param name="book">Информация о книге для обновления.</param>
        private void UpdateBookView(ListViewItem selectedItem, Book book)
        {
            selectedItem.SubItems[1].Text = book.Title;
            selectedItem.SubItems[2].Text = book.Author;
            selectedItem.SubItems[3].Text = book.Year.ToString();
            selectedItem.SubItems[4].Text = book.PageCount.ToString();
        }

        /// <summary>
        /// Заполняет список клиентов в пользовательском интерфейсе.
        /// </summary>
        /// <param name="clients">Список клиентов для отображения.</param>
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

        /// <summary>
        /// Заполняет список книг в пользовательском интерфейсе.
        /// </summary>
        /// <param name="books">Список книг для отображения.</param>
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

        /// <summary>
        /// Обработчик события нажатия кнопки "Фильтровать поиск клиентов".
        /// </summary>
        private void filterSearchButton_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show(
                    "Пожалуйста, выберите тип фильтрации.",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            ClientListClear();
            if (clients.Count > 0)
            {
                FillClientView(clients);
            }
            clientsFilterLabel.Text = "Найдено: " + clients.Count.ToString();
            clientsFilterLabel.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия ссылки "Сбросить фильтры".
        /// </summary>
        private void dropFiltersLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            newComerRadioButton.Checked = false;
            debtorsRadioButton.Checked = false;
            List<Client> clients = clientService.GetAllClients();
            FillClientView(clients);
            clientsFilterLabel.Visible = false;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Поиск книг".
        /// </summary>
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
            searchlabe.Text = "Найдено: " + results.Count.ToString();
            searchlabe.Visible = true;
        }

        /// <summary>
        /// Обработчик события нажатия ссылки "Сбросить поиск".
        /// </summary>
        private void searchDropLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            searchTextBox.Text = "";
            List<Book> results = bookService.GetAllBooks();
            FillBookView(results);
            searchlabe.Text = "Всего: " + results.Count.ToString();
            searchlabe.Visible = false;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Выполнить".
        /// </summary>
        private void dbPerformButton_Click(object sender, EventArgs e)
        {
            if (dbPerformTypeCB.SelectedIndex == 0)
            {
                DeleteDb();
            }
            else if (dbPerformTypeCB.SelectedIndex == 1)
            {
                CreateDb();
            }
            else
            {
                SaveDatabaseToJson();
            }
        }

        /// <summary>
        /// Удаляет базу данных.
        /// </summary>
        private void DeleteDb()
        {
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите удалить базу данных?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes)
            {
                db.Database.EnsureDeleted();
                BookListClear();
                ClientListClear();
            }
        }

        /// <summary>
        /// Создает базу данных.
        /// </summary>
        private void CreateDb()
        {
            db.Database.EnsureCreated();
            BookListClear();
            ClientListClear();
            FillClientView(clientService.GetAllClients());
            FillBookView(bookService.GetAllBooks());
        }

        /// <summary>
        /// Сохраняет базу данных в формате JSON.
        /// </summary>
        public void SaveDatabaseToJson()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Сохранить JSON файл",
                DefaultExt = ".json",
                Filter = "JSON файл (*.json)|*.json|Все файлы (*.*)|*.*"
            };

            // Показываем диалоговое окно и проверяем результат
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к файлу
                string filePath = saveFileDialog.FileName;

                // Получаем все данные для сохранения
                var dataToSave = new
                {
                    Clients = clientService.GetAllClients(),
                    Books = bookService.GetAllBooks(),
                    BookReservations = bookReservationService.GetAllBookReservations()
                };

                // Сериализуем данные в JSON и записываем в файл
                string jsonData = JsonConvert.SerializeObject(dataToSave, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, jsonData);

                MessageBox.Show("Файл успешно сохранен: " + filePath);
            }
        }

        /// <summary>
        /// Сортировка книг.
        /// </summary>
        private void sortButton_Click(object sender, EventArgs e)
        {
            string selectedSortType = typeSortComboBox.SelectedItem.ToString();

            List<Book> books = bookService.GetAllBooks();
            List<Book> result = new List<Book>();
            switch (selectedSortType)
            {
                case "А-Я":
                    result = books.OrderBy(item => item.Title).ToList();
                    break;
                case "Я-А":
                    result = books.OrderByDescending(item => item.Title).ToList();
                    break;
                case "Меньше страниц":
                    result = books.OrderBy(item => item.PageCount).ToList();
                    break;
                case "Больше страниц":
                    result = books.OrderByDescending(item => item.PageCount).ToList();
                    break;
                default:
                    // Обработать неизвестный тип сортировки
                    break;
            }
            FillBookView(result);
        }
    }
}
