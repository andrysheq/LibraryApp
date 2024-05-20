using System;
using System.Linq;
using System.Windows.Forms;
using LibraryApp.db;
using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;

namespace LibraryApp.Views
{
    public partial class BookReservationsWindow : Form
    {
        private readonly db.ApplicationContext _context;
        private readonly BookService bookService;
        private readonly ClientService clientService;
        private readonly BookReservationService bookReservationService;

        /// <summary>
        /// Инициализирует новый экземпляр класса BookReservationsWindow с заданным контекстом базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public BookReservationsWindow(db.ApplicationContext context)
        {
            _context = context;
            bookService = new BookService(_context);
            clientService = new ClientService(_context);
            bookReservationService = new BookReservationService(_context);
            InitializeComponent();
            Load += BookReservationsWindow_Load;
        }

        private void BookReservationsWindow_Load(object sender, EventArgs e)
        {
            // Гарантируем, что база данных создана
            _context.Database.EnsureCreated();
            // Загружаем данные из БД
            _context.Clients.Load();
            _context.Books.Load();
            _context.BookReservations.Load();

            // Добавляем элементы в ListView из БД
            foreach (var reservation in _context.BookReservations.Local)
            {
                ListViewItem item = new ListViewItem(reservation.Id.ToString());
                item.SubItems.Add(reservation.ClientId.ToString());
                item.SubItems.Add(reservation.BookId.ToString());
                item.SubItems.Add(reservation.IssueDate.ToString());
                item.SubItems.Add(reservation.DueDate.ToString());
                if (reservation.ReturnDate == DateTime.MinValue)
                {
                    item.SubItems.Add("Не возвращено");
                }
                else
                {
                    item.SubItems.Add(reservation.ReturnDate.ToString());
                }
                bookReservationsListView.Items.Add(item);
            }
        }

        /// <summary>
        /// Добавляет новую запись бронирования книги.
        /// </summary>
        private void AddReservation_Click(object sender, EventArgs e)
        {
            BookReservationDialogWindow bookReservationWindow = new BookReservationDialogWindow(new BookReservation(), _context);
            if (bookReservationWindow.ShowDialog() == DialogResult.OK)
            {
                BookReservation bookReservation = bookReservationWindow.BookReservation;
                int bookId = bookReservation.BookId, clientId = bookReservation.ClientId;
                Book book = bookService.GetBookById(bookId);
                Client client = clientService.GetClientById(clientId);
                bookReservation.Book = book;
                bookReservation.Client = client;
                _context.BookReservations.Add(bookReservation);
                _context.SaveChanges();

                // Добавляем новый элемент в ListView
                ListViewItem item = new ListViewItem(bookReservation.Id.ToString());
                item.SubItems.Add(bookReservation.ClientId.ToString());
                item.SubItems.Add(bookReservation.BookId.ToString());
                item.SubItems.Add(bookReservation.IssueDate.ToString());
                item.SubItems.Add(bookReservation.DueDate.ToString());
                if (bookReservation.ReturnDate == DateTime.MinValue)
                {
                    item.SubItems.Add("Не возвращено");
                }
                else
                {
                    item.SubItems.Add(bookReservation.ReturnDate.ToString());
                }
                bookReservationsListView.Items.Add(item);
            }
        }

        /// <summary>
        /// Редактирует существующую запись бронирования книги.
        /// </summary>
        private void EditReservation_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = bookReservationsListView.SelectedItems.Count > 0 ? bookReservationsListView.SelectedItems[0] : null;
            if (selectedItem == null)
                return;

            int bookReservationId = int.Parse(selectedItem.SubItems[0].Text);
            BookReservation reservation = bookReservationService.GetBookReservationById(bookReservationId);
            if (reservation == null)
                return;

            BookReservationDialogWindow bookReservationWindow = new BookReservationDialogWindow(new BookReservation
            {
                Id = reservation.Id,
                BookId = reservation.BookId,
                Book = bookService.GetBookById(reservation.BookId),
                ClientId = reservation.ClientId,
                Client = clientService.GetClientById(reservation.ClientId),
                IssueDate = reservation.IssueDate,
                DueDate = reservation.DueDate,
                ReturnDate = reservation.ReturnDate,
            }, _context);

            if (bookReservationWindow.ShowDialog() == DialogResult.OK)
            {
                int bookId = bookReservationWindow.BookReservation.BookId, clientId = bookReservationWindow.BookReservation.ClientId;
                Book book = bookService.GetBookById(bookId);
                Client client = clientService.GetClientById(clientId);
                reservation.Book = book;
                reservation.Client = client;
                reservation.BookId = bookId;
                reservation.ClientId = clientId;
                reservation.IssueDate = bookReservationWindow.BookReservation.IssueDate;
                reservation.DueDate = bookReservationWindow.BookReservation.DueDate;
                reservation.ReturnDate = bookReservationWindow.BookReservation.ReturnDate;

                _context.SaveChanges();

                // Обновляем элемент в ListView
                UpdateElementView(selectedItem, reservation);
            }
        }

        /// <summary>
        /// Удаляет запись бронирования книги.
        /// </summary>
        private void DeleteReservation_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = bookReservationsListView.SelectedItems.Count > 0 ? bookReservationsListView.SelectedItems[0] : null;
            if (selectedItem == null)
                return;

            int bookReservationId = int.Parse(selectedItem.SubItems[0].Text);
            bookReservationService.DeleteBookReservation(bookReservationId);

            // Удаляем элемент из ListView
            bookReservationsListView.Items.Remove(selectedItem);
        }

        /// <summary>
        /// Выполняет возврат книги.
        /// </summary>
        private void ReturnBook_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = bookReservationsListView.SelectedItems.Count > 0 ? bookReservationsListView.SelectedItems[0] : null;
            if (selectedItem == null)
                return;

            int bookReservationId = int.Parse(selectedItem.SubItems[0].Text);
            BookReservation reservation = bookReservationService.GetBookReservationById(bookReservationId);
            reservation.ReturnDate = DateTime.Now;
            _context.SaveChanges();

            UpdateElementView(selectedItem, reservation);
        }

        /// <summary>
        /// Обновляет информацию о бронировании книги в ListView.
        /// </summary>
        private void UpdateElementView(ListViewItem selectedItem, BookReservation reservation)
        {
            selectedItem.SubItems[1].Text = reservation.ClientId.ToString();
            selectedItem.SubItems[2].Text = reservation.BookId.ToString();
            selectedItem.SubItems[3].Text = reservation.IssueDate.ToString();
            selectedItem.SubItems[4].Text = reservation.DueDate.ToString();
            if (reservation.ReturnDate == DateTime.MinValue)
            {
                selectedItem.SubItems[5].Text = "Не возвращено";
            }
            else
            {
                selectedItem.SubItems[5].Text = reservation.ReturnDate.ToString();
            }
        }
    }
}
