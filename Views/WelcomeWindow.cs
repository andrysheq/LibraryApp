using System;
using System.Windows.Forms;

namespace LibraryApp.Views
{
    /// <summary>
    /// Окно приветствия, позволяющее перейти к главному окну приложения.
    /// </summary>
    public partial class WelcomeWindow : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр окна приветствия.
        /// </summary>
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Продолжить".
        /// </summary>
        private void continueButton_Click(object sender, EventArgs e)
        {
            // Скрыть текущее окно
            this.Hide();
            // Создать и отобразить главное окно приложения
            MainWindow mainWindow = new MainWindow();
            // Закрыть текущее окно после закрытия главного окна
            mainWindow.FormClosed += (s, args) => this.Close();
            mainWindow.Show();
        }
    }
}
