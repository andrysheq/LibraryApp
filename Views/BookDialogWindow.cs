using System;
using System.Windows.Forms;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Views
{
    /// <summary>
    /// Окно диалога для добавления или редактирования информации о книге.
    /// </summary>
    public partial class BookDialogWindow : Form
    {
        /// <summary>
        /// Книга, с которой работает окно диалога.
        /// </summary>
        public Book Book { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса BookDialogWindow с заданной книгой.
        /// </summary>
        /// <param name="book">Книга, с которой будет работать окно диалога.</param>
        public BookDialogWindow(Book book)
        {
            InitializeComponent();
            Book = book;
            InitializeBindings();
        }

        /// <summary>
        /// Инициализирует привязки данных.
        /// </summary>
        private void InitializeBindings()
        {
            // Привязка свойств текстовых полей к свойствам объекта Book
            titleTextBox.DataBindings.Add("Text", Book, "Title");
            authorTextBox.DataBindings.Add("Text", Book, "Author");
            yearsTextBox.DataBindings.Add("Text", Book, "Year");
            pagesTextBox.DataBindings.Add("Text", Book, "PageCount");
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "ОК".
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // Проверка введенных данных
            if (!ValidateTitle() || !ValidateAuthor() || !ValidateYear() || !ValidatePages())
            {
                return;
            }
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Отмена".
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        /// <summary>
        /// Проверяет корректность введенного названия книги.
        /// </summary>
        private bool ValidateTitle()
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название книги.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверяет корректность введенного автора книги.
        /// </summary>
        private bool ValidateAuthor()
        {
            if (string.IsNullOrWhiteSpace(authorTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите автора книги.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверяет корректность введенного года издания книги.
        /// </summary>
        private bool ValidateYear()
        {
            int year;
            if (!int.TryParse(yearsTextBox.Text, out year) || year < 1990 || year > 2024)
            {
                MessageBox.Show("Пожалуйста, введите корректный год издания (целое число больше нуля).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверяет корректность введенного количества страниц книги.
        /// </summary>
        private bool ValidatePages()
        {
            int pages;
            if (!int.TryParse(pagesTextBox.Text, out pages) || pages < 10 || pages >10000)
            {
                MessageBox.Show("Пожалуйста, введите корректное количество страниц (целое число больше нуля).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
