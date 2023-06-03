
namespace SignItNow.Forms
{
	partial class UpdateUserProfileForm
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
			this.FirstNameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.PasswordTextBox = new System.Windows.Forms.TextBox();
			this.LastNameTextBox = new System.Windows.Forms.TextBox();
			this.UpdateButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.LoginLabel = new System.Windows.Forms.Label();
			this.LoginTextBox = new System.Windows.Forms.TextBox();
			this.AthLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// FirstNameTextBox
			// 
			this.FirstNameTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FirstNameTextBox.Location = new System.Drawing.Point(225, 146);
			this.FirstNameTextBox.Name = "FirstNameTextBox";
			this.FirstNameTextBox.Size = new System.Drawing.Size(299, 30);
			this.FirstNameTextBox.TabIndex = 31;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(110, 267);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 31);
			this.label2.TabIndex = 30;
			this.label2.Text = "Пароль:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label3.Location = new System.Drawing.Point(84, 208);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 31);
			this.label3.TabIndex = 29;
			this.label3.Text = "Прізвище:";
			// 
			// PasswordTextBox
			// 
			this.PasswordTextBox.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.PasswordTextBox.Location = new System.Drawing.Point(225, 267);
			this.PasswordTextBox.Name = "PasswordTextBox";
			this.PasswordTextBox.Size = new System.Drawing.Size(299, 30);
			this.PasswordTextBox.TabIndex = 28;
			// 
			// LastNameTextBox
			// 
			this.LastNameTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LastNameTextBox.Location = new System.Drawing.Point(225, 208);
			this.LastNameTextBox.Name = "LastNameTextBox";
			this.LastNameTextBox.Size = new System.Drawing.Size(299, 30);
			this.LastNameTextBox.TabIndex = 27;
			// 
			// UpdateButton
			// 
			this.UpdateButton.Location = new System.Drawing.Point(292, 330);
			this.UpdateButton.Name = "UpdateButton";
			this.UpdateButton.Size = new System.Drawing.Size(155, 60);
			this.UpdateButton.TabIndex = 26;
			this.UpdateButton.Text = "Підтвердити зміни";
			this.UpdateButton.UseVisualStyleBackColor = true;
			this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(668, 378);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(120, 60);
			this.CancelButton.TabIndex = 25;
			this.CancelButton.Text = "Назад";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(153, 146);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 31);
			this.label1.TabIndex = 24;
			this.label1.Text = "Ім\'я:";
			// 
			// LoginLabel
			// 
			this.LoginLabel.AutoSize = true;
			this.LoginLabel.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.LoginLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.LoginLabel.Location = new System.Drawing.Point(21, 87);
			this.LoginLabel.Name = "LoginLabel";
			this.LoginLabel.Size = new System.Drawing.Size(181, 31);
			this.LoginLabel.TabIndex = 23;
			this.LoginLabel.Text = "Унікальне ім\'я:";
			// 
			// LoginTextBox
			// 
			this.LoginTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LoginTextBox.Location = new System.Drawing.Point(225, 87);
			this.LoginTextBox.Name = "LoginTextBox";
			this.LoginTextBox.Size = new System.Drawing.Size(299, 30);
			this.LoginTextBox.TabIndex = 22;
			// 
			// AthLabel
			// 
			this.AthLabel.AutoSize = true;
			this.AthLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AthLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.AthLabel.Location = new System.Drawing.Point(142, 19);
			this.AthLabel.Name = "AthLabel";
			this.AthLabel.Size = new System.Drawing.Size(492, 45);
			this.AthLabel.TabIndex = 21;
			this.AthLabel.Text = "Зміна інформації профілю";
			this.AthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// UpdateUserProfileForm
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
			this.Controls.Add(this.UpdateButton);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.LoginLabel);
			this.Controls.Add(this.LoginTextBox);
			this.Controls.Add(this.AthLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UpdateUserProfileForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UpdateUserProfileForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox FirstNameTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox PasswordTextBox;
		private System.Windows.Forms.TextBox LastNameTextBox;
		private System.Windows.Forms.Button UpdateButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label LoginLabel;
		private System.Windows.Forms.TextBox LoginTextBox;
		private System.Windows.Forms.Label AthLabel;
	}
}