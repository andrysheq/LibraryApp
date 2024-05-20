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
            // Привязка свойств текстовых полей к свойствам объекта User
            titleTextBox.DataBindings.Add("Text", Book, "Title");
            authorTextBox.DataBindings.Add("Text", Book, "Author");
            yearTextBox.DataBindings.Add("Text", Book, "Year");
            pagesTextBox.DataBindings.Add("Text", Book, "PageCount");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }
    }
}
