
namespace SignItNow.Forms
{
	partial class IncommingTasksForm
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
			this.incommingTasksDataGridView = new System.Windows.Forms.DataGridView();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DocumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaskCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ReviewDoc = new System.Windows.Forms.DataGridViewButtonColumn();
			this.SignButton = new System.Windows.Forms.DataGridViewButtonColumn();
			this.RejectButton = new System.Windows.Forms.DataGridViewButtonColumn();
			this.CancelButton = new System.Windows.Forms.Button();
			this.GreetingsLabel = new System.Windows.Forms.Label();
			this.RefreshButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.incommingTasksDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// incommingTasksDataGridView
			// 
			this.incommingTasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.incommingTasksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TaskName,
            this.DocumentName,
            this.TaskCreator,
            this.ReviewDoc,
            this.SignButton,
            this.RejectButton});
			this.incommingTasksDataGridView.Location = new System.Drawing.Point(10, 57);
			this.incommingTasksDataGridView.Name = "incommingTasksDataGridView";
			this.incommingTasksDataGridView.RowHeadersWidth = 51;
			this.incommingTasksDataGridView.RowTemplate.Height = 24;
			this.incommingTasksDataGridView.Size = new System.Drawing.Size(1246, 307);
			this.incommingTasksDataGridView.TabIndex = 33;
			this.incommingTasksDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.signersDataGridView_CellContentClick);
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
			// ReviewDoc
			// 
			this.ReviewDoc.HeaderText = "Переглянути документ";
			this.ReviewDoc.MinimumWidth = 6;
			this.ReviewDoc.Name = "ReviewDoc";
			this.ReviewDoc.ReadOnly = true;
			this.ReviewDoc.Width = 125;
			// 
			// SignButton
			// 
			this.SignButton.HeaderText = "Підписати";
			this.SignButton.MinimumWidth = 6;
			this.SignButton.Name = "SignButton";
			this.SignButton.ReadOnly = true;
			this.SignButton.Width = 125;
			// 
			// RejectButton
			// 
			this.RejectButton.HeaderText = "Відмовити у підписі";
			this.RejectButton.MinimumWidth = 6;
			this.RejectButton.Name = "RejectButton";
			this.RejectButton.ReadOnly = true;
			this.RejectButton.Width = 125;
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(1136, 370);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(120, 60);
			this.CancelButton.TabIndex = 32;
			this.CancelButton.Text = "Назад";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// GreetingsLabel
			// 
			this.GreetingsLabel.AutoSize = true;
			this.GreetingsLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.GreetingsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.GreetingsLabel.Location = new System.Drawing.Point(298, 9);
			this.GreetingsLabel.Name = "GreetingsLabel";
			this.GreetingsLabel.Size = new System.Drawing.Size(703, 45);
			this.GreetingsLabel.TabIndex = 31;
			this.GreetingsLabel.Text = "Вхідні задачі з документами на підпис";
			this.GreetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RefreshButton
			// 
			this.RefreshButton.Location = new System.Drawing.Point(10, 370);
			this.RefreshButton.Name = "RefreshButton";
			this.RefreshButton.Size = new System.Drawing.Size(120, 60);
			this.RefreshButton.TabIndex = 34;
			this.RefreshButton.Text = "Актуалізувати дані";
			this.RefreshButton.UseVisualStyleBackColor = true;
			this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
			// 
			// IncommingTasksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(88)))), ((int)(((byte)(67)))));
			this.ClientSize = new System.Drawing.Size(1268, 439);
			this.Controls.Add(this.RefreshButton);
			this.Controls.Add(this.incommingTasksDataGridView);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.GreetingsLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IncommingTasksForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "IncommingTasksForm";
			((System.ComponentModel.ISupportInitialize)(this.incommingTasksDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView incommingTasksDataGridView;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Label GreetingsLabel;
		private System.Windows.Forms.Button RefreshButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
		private System.Windows.Forms.DataGridViewTextBoxColumn DocumentName;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskCreator;
		private System.Windows.Forms.DataGridViewButtonColumn ReviewDoc;
		private System.Windows.Forms.DataGridViewButtonColumn SignButton;
		private System.Windows.Forms.DataGridViewButtonColumn RejectButton;
	}
}