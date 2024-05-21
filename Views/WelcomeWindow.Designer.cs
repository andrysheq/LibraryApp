namespace LibraryApp.Views
{
    partial class WelcomeWindow : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeWindow));
            label1 = new Label();
            continueButton = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.Location = new Point(108, 60);
            label1.Name = "label1";
            label1.Size = new Size(246, 25);
            label1.TabIndex = 0;
            label1.Text = "Приложение \"Библиотека\"";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // continueButton
            // 
            continueButton.Font = new Font("Segoe UI", 12F);
            continueButton.Location = new Point(179, 252);
            continueButton.Name = "continueButton";
            continueButton.Size = new Size(110, 40);
            continueButton.TabIndex = 1;
            continueButton.Text = "Продолжить";
            continueButton.UseVisualStyleBackColor = true;
            continueButton.Click += continueButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(27, 119);
            label2.Name = "label2";
            label2.Size = new Size(423, 25);
            label2.TabIndex = 2;
            label2.Text = "Выполнил Кареев Андрей гр.22ВП2 (Вариант 1)";
            // 
            // WelcomeWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 362);
            Controls.Add(label2);
            Controls.Add(continueButton);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WelcomeWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ИС \"Библиотека\"";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button continueButton;
        private Label label2;
    }
}
