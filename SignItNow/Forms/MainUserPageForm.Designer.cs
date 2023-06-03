
namespace SignItNow.Forms
{
	partial class MainUserPageForm
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
			this.GreetingsLabel = new System.Windows.Forms.Label();
			this.ViewIncommingTasksButton = new System.Windows.Forms.Button();
			this.LogOutButton = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// GreetingsLabel
			// 
			this.GreetingsLabel.AutoSize = true;
			this.GreetingsLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.GreetingsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.GreetingsLabel.Location = new System.Drawing.Point(151, 26);
			this.GreetingsLabel.Name = "GreetingsLabel";
			this.GreetingsLabel.Size = new System.Drawing.Size(492, 45);
			this.GreetingsLabel.TabIndex = 10;
			this.GreetingsLabel.Text = "Вітаємо у головному меню";
			this.GreetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ViewIncommingTasksButton
			// 
			this.ViewIncommingTasksButton.Location = new System.Drawing.Point(12, 142);
			this.ViewIncommingTasksButton.Name = "ViewIncommingTasksButton";
			this.ViewIncommingTasksButton.Size = new System.Drawing.Size(155, 60);
			this.ViewIncommingTasksButton.TabIndex = 16;
			this.ViewIncommingTasksButton.Text = "Переглянути вхідні документи";
			this.ViewIncommingTasksButton.UseVisualStyleBackColor = true;
			this.ViewIncommingTasksButton.Click += new System.EventHandler(this.ViewIncommingTasksButton_Click);
			// 
			// LogOutButton
			// 
			this.LogOutButton.Location = new System.Drawing.Point(633, 378);
			this.LogOutButton.Name = "LogOutButton";
			this.LogOutButton.Size = new System.Drawing.Size(155, 60);
			this.LogOutButton.TabIndex = 17;
			this.LogOutButton.Text = "Вийти з профілю";
			this.LogOutButton.UseVisualStyleBackColor = true;
			this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(200, 226);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(155, 60);
			this.button2.TabIndex = 18;
			this.button2.Text = "Переглянути підписані документи";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(442, 226);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(155, 60);
			this.button3.TabIndex = 19;
			this.button3.Text = "Переглянути надіслані документи";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(633, 142);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(155, 60);
			this.button1.TabIndex = 20;
			this.button1.Text = "Надіслати документ";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 378);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(155, 60);
			this.button4.TabIndex = 21;
			this.button4.Text = "Оновити профіль";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// MainUserPageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(88)))), ((int)(((byte)(67)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.LogOutButton);
			this.Controls.Add(this.ViewIncommingTasksButton);
			this.Controls.Add(this.GreetingsLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainUserPageForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MainUserPageForm";
			this.Shown += new System.EventHandler(this.MainUserPageForm_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label GreetingsLabel;
		private System.Windows.Forms.Button ViewIncommingTasksButton;
		private System.Windows.Forms.Button LogOutButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button4;
	}
}