
namespace SignItNow.Forms
{
	partial class LeaveCommentForm
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
			this.ContinueButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.GreetingsLabel = new System.Windows.Forms.Label();
			this.commentTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ContinueButton
			// 
			this.ContinueButton.Location = new System.Drawing.Point(12, 378);
			this.ContinueButton.Name = "ContinueButton";
			this.ContinueButton.Size = new System.Drawing.Size(120, 60);
			this.ContinueButton.TabIndex = 37;
			this.ContinueButton.Text = "Продовжити";
			this.ContinueButton.UseVisualStyleBackColor = true;
			this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(419, 378);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(120, 60);
			this.CancelButton.TabIndex = 36;
			this.CancelButton.Text = "Відмінити";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// GreetingsLabel
			// 
			this.GreetingsLabel.AutoSize = true;
			this.GreetingsLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.GreetingsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.GreetingsLabel.Location = new System.Drawing.Point(95, 9);
			this.GreetingsLabel.Name = "GreetingsLabel";
			this.GreetingsLabel.Size = new System.Drawing.Size(358, 45);
			this.GreetingsLabel.TabIndex = 35;
			this.GreetingsLabel.Text = "Залиште коментар";
			this.GreetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// commentTextBox
			// 
			this.commentTextBox.Location = new System.Drawing.Point(12, 85);
			this.commentTextBox.Multiline = true;
			this.commentTextBox.Name = "commentTextBox";
			this.commentTextBox.Size = new System.Drawing.Size(527, 279);
			this.commentTextBox.TabIndex = 38;
			// 
			// LeaveCommentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(88)))), ((int)(((byte)(67)))));
			this.ClientSize = new System.Drawing.Size(551, 450);
			this.Controls.Add(this.commentTextBox);
			this.Controls.Add(this.ContinueButton);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.GreetingsLabel);
			this.Name = "LeaveCommentForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LeaveCommentForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LeaveCommentForm_FormClosing);
			this.Load += new System.EventHandler(this.LeaveCommentForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ContinueButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Label GreetingsLabel;
		private System.Windows.Forms.TextBox commentTextBox;
	}
}