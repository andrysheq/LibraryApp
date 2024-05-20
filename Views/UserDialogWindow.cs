using System;
using System.Windows.Forms;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Views
{
    public partial class UserDialogWindow : Form
    {
        public Client User { get; private set; }

        public UserDialogWindow(Client user)
        {
            InitializeComponent();
            User = user;
            InitializeBindings();
        }

        private void InitializeBindings()
        {
            // Привязка свойств текстовых полей к свойствам объекта User
            nameTextBox.DataBindings.Add("Text", User, "Name");
            phoneTextBox.DataBindings.Add("Text", User, "PhoneNumber");
            surnameTextBox.DataBindings.Add("Text", User, "Surname");
            middleNameTextBox.DataBindings.Add("Text", User, "MiddleName");
        }

        private bool ValidateName()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Поле 'Имя' не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(surnameTextBox.Text))
            {
                MessageBox.Show("Поле 'Фамилия' не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(middleNameTextBox.Text))
            {
                MessageBox.Show("Поле 'Отчество' не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidatePhoneNumber()
        {
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Номер телефона не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneTextBox.Text, @"^\+7\d{10}$"))
            {
                MessageBox.Show("Номер телефона должен быть в формате +7xxxxxxxxxx и содержать 11 цифр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateName() && ValidatePhoneNumber())
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
