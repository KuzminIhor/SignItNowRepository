
namespace SignItNow.Forms
{
	partial class SentTasksForm
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
			this.sentTasksDataGridView = new System.Windows.Forms.DataGridView();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Signers = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Document = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Revoke = new System.Windows.Forms.DataGridViewButtonColumn();
			this.CancelButton = new System.Windows.Forms.Button();
			this.RefreshButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.sentTasksDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// GreetingsLabel
			// 
			this.GreetingsLabel.AutoSize = true;
			this.GreetingsLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.GreetingsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.GreetingsLabel.Location = new System.Drawing.Point(233, 9);
			this.GreetingsLabel.Name = "GreetingsLabel";
			this.GreetingsLabel.Size = new System.Drawing.Size(616, 45);
			this.GreetingsLabel.TabIndex = 12;
			this.GreetingsLabel.Text = "Надіслані документи для підпису";
			this.GreetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sentTasksDataGridView
			// 
			this.sentTasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.sentTasksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TaskName,
            this.TaskStatus,
            this.Signers,
            this.Document,
            this.Revoke});
			this.sentTasksDataGridView.Location = new System.Drawing.Point(12, 57);
			this.sentTasksDataGridView.Name = "sentTasksDataGridView";
			this.sentTasksDataGridView.RowHeadersWidth = 51;
			this.sentTasksDataGridView.RowTemplate.Height = 24;
			this.sentTasksDataGridView.Size = new System.Drawing.Size(1028, 429);
			this.sentTasksDataGridView.TabIndex = 31;
			this.sentTasksDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sentTasksDataGridView_CellContentClick);
			// 
			// Id
			// 
			this.Id.HeaderText = "Id";
			this.Id.MinimumWidth = 6;
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			this.Id.Width = 125;
			// 
			// TaskName
			// 
			this.TaskName.HeaderText = "Назва задачі";
			this.TaskName.MinimumWidth = 6;
			this.TaskName.Name = "TaskName";
			this.TaskName.ReadOnly = true;
			this.TaskName.Width = 125;
			// 
			// TaskStatus
			// 
			this.TaskStatus.HeaderText = "Статус задачі";
			this.TaskStatus.MinimumWidth = 6;
			this.TaskStatus.Name = "TaskStatus";
			this.TaskStatus.ReadOnly = true;
			this.TaskStatus.Width = 125;
			// 
			// Signers
			// 
			this.Signers.HeaderText = "Підписанти";
			this.Signers.MinimumWidth = 6;
			this.Signers.Name = "Signers";
			this.Signers.ReadOnly = true;
			this.Signers.Width = 125;
			// 
			// Document
			// 
			this.Document.HeaderText = "Документ";
			this.Document.MinimumWidth = 6;
			this.Document.Name = "Document";
			this.Document.ReadOnly = true;
			this.Document.Width = 125;
			// 
			// Revoke
			// 
			this.Revoke.HeaderText = "Забракувати";
			this.Revoke.MinimumWidth = 6;
			this.Revoke.Name = "Revoke";
			this.Revoke.ReadOnly = true;
			this.Revoke.Width = 125;
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(920, 492);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(120, 60);
			this.CancelButton.TabIndex = 32;
			this.CancelButton.Text = "Назад";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// RefreshButton
			// 
			this.RefreshButton.Location = new System.Drawing.Point(12, 492);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(120, 60);
			this.RefreshButton.TabIndex = 35;
			this.RefreshButton.Text = "Актуалізувати дані";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// SentTasksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(88)))), ((int)(((byte)(67)))));
			this.ClientSize = new System.Drawing.Size(1052, 564);
			this.Controls.Add(this.RefreshButton);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.sentTasksDataGridView);
			this.Controls.Add(this.GreetingsLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SentTasksForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SentTasksForm";
			this.Load += new System.EventHandler(this.SentTasksForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.sentTasksDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label GreetingsLabel;
		private System.Windows.Forms.DataGridView sentTasksDataGridView;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskStatus;
		private System.Windows.Forms.DataGridViewButtonColumn Signers;
		private System.Windows.Forms.DataGridViewButtonColumn Document;
		private System.Windows.Forms.DataGridViewButtonColumn Revoke;
		private System.Windows.Forms.Button RefreshButton;
	}
}