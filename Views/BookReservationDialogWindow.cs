using System;
using System.Windows.Forms;
using LibraryApp.Models;
using LibraryApp.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Views
{
    public partial class BookReservationDialogWindow : Form
    {
        public BookReservation BookReservation { get; private set; }
        private readonly BookService bookService;
        private readonly ClientService clientService;

        public BookReservationDialogWindow(BookReservation bookReservation, db.ApplicationContext context)
        {
            InitializeComponent();
            BookReservation = bookReservation;
            bookService = new BookService(context);
            clientService = new ClientService(context);
            InitializeBindings();
        }

        private void InitializeBindings()
        {
            // Привязка свойств текстовых полей к свойствам объекта User
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

        private bool ValidateDates()
        {
            if (dueDatePicker.Value <= issueDatePicker.Value)
            {
                MessageBox.Show("Дата возврата должна быть позже даты выдачи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateBookAndClient() && ValidateDates())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
