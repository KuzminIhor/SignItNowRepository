
namespace SignItNow.Forms
{
	partial class CompletedTasksForm
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
			this.RefreshButton = new System.Windows.Forms.Button();
			this.completedTasksDataGridView = new System.Windows.Forms.DataGridView();
			this.CancelButton = new System.Windows.Forms.Button();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DocumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaskCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ReviewDoc = new System.Windows.Forms.DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)(this.completedTasksDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// GreetingsLabel
			// 
			this.GreetingsLabel.AutoSize = true;
			this.GreetingsLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.GreetingsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.GreetingsLabel.Location = new System.Drawing.Point(188, 9);
			this.GreetingsLabel.Name = "GreetingsLabel";
			this.GreetingsLabel.Size = new System.Drawing.Size(927, 45);
			this.GreetingsLabel.TabIndex = 32;
			this.GreetingsLabel.Text = "Ваші Підписані та Відмовлені у підписі документи";
			this.GreetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RefreshButton
			// 
			this.RefreshButton.Location = new System.Drawing.Point(12, 378);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(120, 60);
			this.RefreshButton.TabIndex = 37;
			this.RefreshButton.Text = "Актуалізувати дані";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// completedTasksDataGridView
			// 
			this.completedTasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.completedTasksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TaskName,
            this.DocumentName,
            this.TaskCreator,
            this.Status,
            this.ReviewDoc});
			this.completedTasksDataGridView.Location = new System.Drawing.Point(12, 57);
			this.completedTasksDataGridView.Name = "completedTasksDataGridView";
			this.completedTasksDataGridView.RowHeadersWidth = 51;
			this.completedTasksDataGridView.RowTemplate.Height = 24;
			this.completedTasksDataGridView.Size = new System.Drawing.Size(1246, 315);
			this.completedTasksDataGridView.TabIndex = 36;
			this.completedTasksDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.completedTasksDataGridView_CellContentClick);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(1140, 378);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(120, 60);
			this.CancelButton.TabIndex = 35;
			this.CancelButton.Text = "Назад";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
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
			// DocumentName
			// 
			this.DocumentName.HeaderText = "Назва документу";
			this.DocumentName.MinimumWidth = 6;
			this.DocumentName.Name = "DocumentName";
			this.DocumentName.ReadOnly = true;
			this.DocumentName.Width = 125;
			// 
			// TaskCreator
			// 
			this.TaskCreator.HeaderText = "Надсилач";
			this.TaskCreator.MinimumWidth = 6;
			this.TaskCreator.Name = "TaskCreator";
			this.TaskCreator.ReadOnly = true;
			this.TaskCreator.Width = 125;
			// 
			// Status
			// 
			this.Status.HeaderText = "Підписано/Відхилено";
			this.Status.MinimumWidth = 6;
			this.Status.Name = "Status";
			this.Status.ReadOnly = true;
			this.Status.Width = 175;
			// 
			// ReviewDoc
			// 
			this.ReviewDoc.HeaderText = "Переглянути документ";
			this.ReviewDoc.MinimumWidth = 6;
			this.ReviewDoc.Name = "ReviewDoc";
			this.ReviewDoc.ReadOnly = true;
			this.ReviewDoc.Width = 125;
			// 
			// CompletedTasksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(88)))), ((int)(((byte)(67)))));
			this.ClientSize = new System.Drawing.Size(1272, 450);
			this.Controls.Add(this.RefreshButton);
			this.Controls.Add(this.completedTasksDataGridView);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.GreetingsLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CompletedTasksForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CompletedTasksForm";
			((System.ComponentModel.ISupportInitialize)(this.completedTasksDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label GreetingsLabel;
		private System.Windows.Forms.Button RefreshButton;
		private System.Windows.Forms.DataGridView completedTasksDataGridView;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
		private System.Windows.Forms.DataGridViewTextBoxColumn DocumentName;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskCreator;
		private System.Windows.Forms.DataGridViewTextBoxColumn Status;
		private System.Windows.Forms.DataGridViewButtonColumn ReviewDoc;
	}
}