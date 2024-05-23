using System;
using System.Windows.Forms;

namespace LibraryApp.Views
{
    /// <summary>
    /// Окно приветствия, позволяющее перейти к главному окну приложения.
    /// </summary>
    public partial class WelcomeWindow : Form
    {
        private System.Windows.Forms.Timer inactivityTimer;
        private const int InactivityTimeout = 10000; // 10 секунд в миллисекундах

        /// <summary>
        /// Инициализирует новый экземпляр окна приветствия.
        /// </summary>
        public WelcomeWindow()
        {
            InitializeComponent();
            InitializeInactivityTimer();
        }

        /// <summary>
        /// Инициализирует таймер простоя.
        /// </summary>
        private void InitializeInactivityTimer()
        {
            inactivityTimer = new System.Windows.Forms.Timer();
            inactivityTimer.Interval = InactivityTimeout;
            inactivityTimer.Tick += InactivityTimer_Tick;
            inactivityTimer.Start();

            this.MouseMove += new MouseEventHandler(ResetInactivityTimer);
            this.KeyPress += new KeyPressEventHandler(ResetInactivityTimer);
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Продолжить".
        /// </summary>
        private void continueButton_Click(object sender, EventArgs e)
        {
            // Остановить таймер простоя
            inactivityTimer.Stop();
            // Скрыть текущее окно
            this.Hide();
            // Создать и отобразить главное окно приложения
            MainWindow mainWindow = new MainWindow();
            // Закрыть текущее окно после закрытия главного окна
            mainWindow.FormClosed += (s, args) => this.Close();
            mainWindow.Show();
        }

        /// <summary>
        /// Обработчик события тика таймера простоя.
        /// </summary>
        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            // Остановить таймер
            inactivityTimer.Stop();
            // Закрыть текущее окно
            this.Close();
        }

        /// <summary>
        /// Сбрасывает таймер простоя при активности пользователя.
        /// </summary>
        private void ResetInactivityTimer(object sender, EventArgs e)
        {
            inactivityTimer.Stop();
            inactivityTimer.Start();
        }
    }
}
