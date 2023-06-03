namespace SignItNow.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.AthLabel = new System.Windows.Forms.Label();
			this.LoginTextBox = new System.Windows.Forms.TextBox();
			this.PasswordTextBox = new System.Windows.Forms.TextBox();
			this.LoginLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.LoginButton = new System.Windows.Forms.Button();
			this.CreateNewProfileButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// AthLabel
			// 
			this.AthLabel.AutoSize = true;
			this.AthLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AthLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.AthLabel.Location = new System.Drawing.Point(252, 109);
			this.AthLabel.Name = "AthLabel";
			this.AthLabel.Size = new System.Drawing.Size(307, 45);
			this.AthLabel.TabIndex = 0;
			this.AthLabel.Text = "Аутентифікація";
			this.AthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LoginTextBox
			// 
			this.LoginTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LoginTextBox.Location = new System.Drawing.Point(260, 186);
			this.LoginTextBox.Name = "LoginTextBox";
			this.LoginTextBox.Size = new System.Drawing.Size(299, 30);
			this.LoginTextBox.TabIndex = 1;
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.PasswordTextBox.Location = new System.Drawing.Point(260, 245);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(299, 30);
			this.PasswordTextBox.TabIndex = 2;
			// 
			// LoginLabel
			// 
			this.LoginLabel.AutoSize = true;
			this.LoginLabel.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.LoginLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.LoginLabel.Location = new System.Drawing.Point(54, 186);
			this.LoginLabel.Name = "LoginLabel";
			this.LoginLabel.Size = new System.Drawing.Size(181, 31);
			this.LoginLabel.TabIndex = 3;
			this.LoginLabel.Text = "Унікальне ім\'я:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(145, 245);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 31);
			this.label1.TabIndex = 4;
			this.label1.Text = "Пароль:";
			// 
			// LoginButton
			// 
			this.LoginButton.Location = new System.Drawing.Point(260, 306);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(120, 60);
			this.LoginButton.TabIndex = 5;
			this.LoginButton.Text = "Увійти";
			this.LoginButton.UseVisualStyleBackColor = true;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// CreateNewProfileButton
			// 
			this.CreateNewProfileButton.Location = new System.Drawing.Point(404, 306);
			this.CreateNewProfileButton.Name = "CreateNewProfileButton";
			this.CreateNewProfileButton.Size = new System.Drawing.Size(155, 60);
			this.CreateNewProfileButton.TabIndex = 8;
			this.CreateNewProfileButton.Text = "Створити новий профіль";
			this.CreateNewProfileButton.UseVisualStyleBackColor = true;
			this.CreateNewProfileButton.Click += new System.EventHandler(this.CreateNewProfileButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(88)))), ((int)(((byte)(67)))));
			this.ClientSize = new System.Drawing.Size(848, 556);
			this.Controls.Add(this.CreateNewProfileButton);
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LoginLabel);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.LoginTextBox);
			this.Controls.Add(this.AthLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(866, 603);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(866, 603);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainForm";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AthLabel;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginButton;
		private System.Windows.Forms.Button CreateNewProfileButton;
	}
}

