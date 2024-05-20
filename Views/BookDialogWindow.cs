using System;
using System.Windows.Forms;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Views
{
    public partial class BookDialogWindow : Form
    {
        public Book Book { get; private set; }

        public BookDialogWindow(Book book)
        {
            InitializeComponent();
            Book = book;
            InitializeBindings();
        }

        private void InitializeBindings()
        {
            // Привязка свойств текстовых полей к свойствам объекта Book
            titleTextBox.DataBindings.Add("Text", Book, "Title");
            authorTextBox.DataBindings.Add("Text", Book, "Author");
            yearTextBox.DataBindings.Add("Text", Book, "Year");
            pagesTextBox.DataBindings.Add("Text", Book, "PageCount");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // Проверка введенных данных
            if (!ValidateTitle() || !ValidateAuthor() || !ValidateYear() || !ValidatePages())
            {
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private bool ValidateTitle()
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название книги.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidateAuthor()
        {
            if (string.IsNullOrWhiteSpace(authorTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите автора книги.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidateYear()
        {
            int year;
            if (!int.TryParse(yearTextBox.Text, out year) || year < 1)
            {
                MessageBox.Show("Пожалуйста, введите корректный год издания (целое число больше нуля).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidatePages()
        {
            int pages;
            if (!int.TryParse(pagesTextBox.Text, out pages) || pages < 1)
            {
                MessageBox.Show("Пожалуйста, введите корректное количество страниц (целое число больше нуля).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
