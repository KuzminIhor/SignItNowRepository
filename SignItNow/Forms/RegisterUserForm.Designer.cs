
namespace SignItNow.Forms
{
	partial class RegisterUserForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.RegisterButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.LoginLabel = new System.Windows.Forms.Label();
			this.LoginTextBox = new System.Windows.Forms.TextBox();
			this.AthLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.PasswordTextBox = new System.Windows.Forms.TextBox();
			this.LastNameTextBox = new System.Windows.Forms.TextBox();
			this.FirstNameTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// RegisterButton
			// 
			this.RegisterButton.Location = new System.Drawing.Point(294, 329);
			this.RegisterButton.Name = "RegisterButton";
			this.RegisterButton.Size = new System.Drawing.Size(155, 60);
			this.RegisterButton.TabIndex = 15;
			this.RegisterButton.Text = "Зареєструватись";
			this.RegisterButton.UseVisualStyleBackColor = true;
			this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(668, 378);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(120, 60);
			this.CancelButton.TabIndex = 14;
			this.CancelButton.Text = "Назад";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(155, 145);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 31);
			this.label1.TabIndex = 13;
			this.label1.Text = "Ім\'я:";
			// 
			// LoginLabel
			// 
			this.LoginLabel.AutoSize = true;
			this.LoginLabel.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.LoginLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.LoginLabel.Location = new System.Drawing.Point(22, 86);
			this.LoginLabel.Name = "LoginLabel";
			this.LoginLabel.Size = new System.Drawing.Size(181, 31);
			this.LoginLabel.TabIndex = 12;
			this.LoginLabel.Text = "Унікальне ім\'я:";
			// 
			// LoginTextBox
			// 
			this.LoginTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LoginTextBox.Location = new System.Drawing.Point(227, 86);
			this.LoginTextBox.Name = "LoginTextBox";
			this.LoginTextBox.Size = new System.Drawing.Size(299, 30);
			this.LoginTextBox.TabIndex = 10;
			// 
			// AthLabel
			// 
			this.AthLabel.AutoSize = true;
			this.AthLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AthLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.AthLabel.Location = new System.Drawing.Point(271, 9);
			this.AthLabel.Name = "AthLabel";
			this.AthLabel.Size = new System.Drawing.Size(215, 45);
			this.AthLabel.TabIndex = 9;
			this.AthLabel.Text = "Реєстрація";
			this.AthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(112, 266);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 31);
			this.label2.TabIndex = 19;
			this.label2.Text = "Пароль:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label3.Location = new System.Drawing.Point(86, 207);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 31);
			this.label3.TabIndex = 18;
			this.label3.Text = "Прізвище:";
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.PasswordTextBox.Location = new System.Drawing.Point(227, 266);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(299, 30);
			this.PasswordTextBox.TabIndex = 17;
			// 
			// LastNameTextBox
			// 
			this.LastNameTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LastNameTextBox.Location = new System.Drawing.Point(227, 207);
			this.LastNameTextBox.Name = "LastNameTextBox";
			this.LastNameTextBox.Size = new System.Drawing.Size(299, 30);
			this.LastNameTextBox.TabIndex = 16;
			// 
			// FirstNameTextBox
			// 
			this.FirstNameTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FirstNameTextBox.Location = new System.Drawing.Point(227, 145);
			this.FirstNameTextBox.Name = "FirstNameTextBox";
			this.FirstNameTextBox.Size = new System.Drawing.Size(299, 30);
			this.FirstNameTextBox.TabIndex = 20;
			// 
			// RegisterUserForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(88)))), ((int)(((byte)(67)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.FirstNameTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.PasswordTextBox);
			this.Controls.Add(this.LastNameTextBox);
			this.Controls.Add(this.RegisterButton);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LoginLabel);
			this.Controls.Add(this.LoginTextBox);
			this.Controls.Add(this.AthLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RegisterUserForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RegisterUserForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button RegisterButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label LoginLabel;
		private System.Windows.Forms.TextBox LoginTextBox;
		private System.Windows.Forms.Label AthLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox PasswordTextBox;
		private System.Windows.Forms.TextBox LastNameTextBox;
		private System.Windows.Forms.TextBox FirstNameTextBox;
	}
}