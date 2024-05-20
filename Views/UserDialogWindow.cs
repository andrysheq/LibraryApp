using System;
using System.Windows.Forms;
using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Views
{
    public partial class UserDialogWindow : Form
    {
        /// <summary>
        /// Пользователь, информация о котором редактируется.
        /// </summary>
        public Client User { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр окна для редактирования информации о пользователе.
        /// </summary>
        /// <param name="user">Пользователь, информацию о котором нужно редактировать.</param>
        public UserDialogWindow(Client user)
        {
            InitializeComponent();
            User = user;
            InitializeBindings();
        }

        /// <summary>
        /// Инициализирует привязки данных между элементами управления и объектом пользователя.
        /// </summary>
        private void InitializeBindings()
        {
            // Привязка свойств текстовых полей к свойствам объекта User
            nameTextBox.DataBindings.Add("Text", User, "Name");
            phoneTextBox.DataBindings.Add("Text", User, "PhoneNumber");
            surnameTextBox.DataBindings.Add("Text", User, "Surname");
            middleNameTextBox.DataBindings.Add("Text", User, "MiddleName");
        }

        /// <summary>
        /// Проверяет валидность введенного имени пользователя.
        /// </summary>
        /// <returns>True, если имя пользователя валидно, иначе False.</returns>
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

        /// <summary>
        /// Проверяет валидность введенного номера телефона пользователя.
        /// </summary>
        /// <returns>True, если номер телефона валиден, иначе False.</returns>
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

        /// <summary>
        /// Обработчик события нажатия кнопки "OK".
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (ValidateName() && ValidatePhoneNumber())
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
