using System;
using System.Windows.Forms;
using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Views
{
    /// <summary>
    /// Окно диалога для добавления или редактирования информации о бронировании книги.
    /// </summary>
    public partial class BookReservationDialogWindow : Form
    {
        /// <summary>
        /// Бронирование книги, с которым работает окно диалога.
        /// </summary>
        public BookReservation BookReservation { get; private set; }

        private readonly BookService bookService;
        private readonly ClientService clientService;

        /// <summary>
        /// Инициализирует новый экземпляр класса BookReservationDialogWindow с заданным бронированием книги и контекстом базы данных.
        /// </summary>
        /// <param name="bookReservation">Бронирование книги, с которым будет работать окно диалога.</param>
        /// <param name="context">Контекст базы данных.</param>
        public BookReservationDialogWindow(BookReservation bookReservation, db.ApplicationContext context)
        {
            InitializeComponent();
            BookReservation = bookReservation;
            bookService = new BookService(context);
            clientService = new ClientService(context);
            InitializeBindings();
        }

        /// <summary>
        /// Инициализирует привязки данных.
        /// </summary>
        private void InitializeBindings()
        {
            // Привязка свойств текстовых полей к свойствам объекта BookReservation
            bookIdTextBox.DataBindings.Add("Text", BookReservation, "BookId");
            clientIdTextBox.DataBindings.Add("Text", BookReservation, "ClientId");
            issueDatePicker.DataBindings.Add("Value", BookReservation, "IssueDate");
            dueDatePicker.DataBindings.Add("Value", BookReservation, "DueDate");
            returnedCheckBox.Checked = BookReservation.ReturnDate != DateTime.MinValue;
            returnedCheckBox.CheckedChanged += (sender, e) =>
            {
                BookReservation.ReturnDate = returnedCheckBox.Checked ? DateTime.Now : DateTime.MinValue;
            };
        }

        /// <summary>
        /// Проверяет корректность идентификаторов книги и клиента.
        /// </summary>
        private bool ValidateBookAndClient()
        {
            if (!int.TryParse(bookIdTextBox.Text, out int bookId))
            {
                MessageBox.Show("Неверный формат идентификатора книги.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(clientIdTextBox.Text, out int clientId))
            {
                MessageBox.Show("Неверный формат идентификатора клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (bookService.GetBookById(bookId) == null)
            {
                MessageBox.Show("Книга с указанным идентификатором не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (clientService.GetClientById(clientId) == null)
            {
                MessageBox.Show("Клиент с указанным идентификатором не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет корректность даты выдачи и возврата книги.
        /// </summary>
        private bool ValidateDates()
        {
            if (dueDatePicker.Value <= issueDatePicker.Value)
            {
                MessageBox.Show("Дата возврата должна быть позже даты выдачи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "ОК".
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateBookAndClient() && ValidateDates())
            {
                DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Отмена".
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
