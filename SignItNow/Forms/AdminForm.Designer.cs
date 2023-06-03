
namespace SignItNow.Forms
{
	partial class AdminForm
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
			this.AthLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.RefreshUsersButton = new System.Windows.Forms.Button();
			this.LogoutButton = new System.Windows.Forms.Button();
			this.RefreshTasksButton = new System.Windows.Forms.Button();
			this.tasksDataGridView = new System.Windows.Forms.DataGridView();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Signers = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Document = new System.Windows.Forms.DataGridViewButtonColumn();
			this.Revoke = new System.Windows.Forms.DataGridViewButtonColumn();
			this.usersDataGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IsBanned = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BanButton = new System.Windows.Forms.DataGridViewButtonColumn();
			this.ReportGenerationButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.tasksDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// AthLabel
			// 
			this.AthLabel.AutoSize = true;
			this.AthLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.AthLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.AthLabel.Location = new System.Drawing.Point(409, 9);
			this.AthLabel.Name = "AthLabel";
			this.AthLabel.Size = new System.Drawing.Size(458, 45);
			this.AthLabel.TabIndex = 1;
			this.AthLabel.Text = "Адміністраційна панель";
			this.AthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(522, 97);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(182, 35);
			this.label1.TabIndex = 2;
			this.label1.Text = "Користувачі";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(411, 565);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(440, 35);
			this.label2.TabIndex = 3;
			this.label2.Text = "Створені користувачами задачі";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RefreshUsersButton
			// 
			this.RefreshUsersButton.Location = new System.Drawing.Point(12, 508);
			this.RefreshUsersButton.Name = "RefreshUsersButton";
			this.RefreshUsersButton.Size = new System.Drawing.Size(120, 60);
			this.RefreshUsersButton.TabIndex = 39;
			this.RefreshUsersButton.Text = "Актуалізувати дані користувачів";
			this.RefreshUsersButton.UseVisualStyleBackColor = true;
			this.RefreshUsersButton.Click += new System.EventHandler(this.RefreshUsersButton_Click);
			// 
			// LogoutButton
			// 
			this.LogoutButton.Location = new System.Drawing.Point(1119, 12);
			this.LogoutButton.Name = "LogoutButton";
			this.LogoutButton.Size = new System.Drawing.Size(120, 60);
			this.LogoutButton.TabIndex = 38;
			this.LogoutButton.Text = "Вийти з профілю";
			this.LogoutButton.UseVisualStyleBackColor = true;
			this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
			// 
			// RefreshTasksButton
			// 
			this.RefreshTasksButton.Location = new System.Drawing.Point(12, 933);
			this.RefreshTasksButton.Name = "RefreshTasksButton";
			this.RefreshTasksButton.Size = new System.Drawing.Size(120, 60);
			this.RefreshTasksButton.TabIndex = 40;
			this.RefreshTasksButton.Text = "Актуалізувати дані задач";
			this.RefreshTasksButton.UseVisualStyleBackColor = true;
			this.RefreshTasksButton.Click += new System.EventHandler(this.RefreshTasksButton_Click);
			// 
			// tasksDataGridView
			// 
			this.tasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tasksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TaskName,
            this.TaskStatus,
            this.Signers,
            this.Document,
            this.Revoke});
			this.tasksDataGridView.Location = new System.Drawing.Point(12, 603);
			this.tasksDataGridView.Name = "tasksDataGridView";
			this.tasksDataGridView.RowHeadersWidth = 51;
			this.tasksDataGridView.RowTemplate.Height = 24;
			this.tasksDataGridView.Size = new System.Drawing.Size(1227, 324);
			this.tasksDataGridView.TabIndex = 41;
			this.tasksDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tasksDataGridView_CellContentClick);
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
			// usersDataGridView
			// 
			this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.usersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.UserName,
            this.FirstName,
            this.LastName,
            this.IsBanned,
            this.BanButton});
			this.usersDataGridView.Location = new System.Drawing.Point(12, 135);
			this.usersDataGridView.Name = "usersDataGridView";
			this.usersDataGridView.RowHeadersWidth = 51;
			this.usersDataGridView.RowTemplate.Height = 24;
			this.usersDataGridView.Size = new System.Drawing.Size(1227, 367);
			this.usersDataGridView.TabIndex = 42;
			this.usersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.usersDataGridView_CellContentClick);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Id";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 125;
			// 
			// UserName
			// 
			this.UserName.HeaderText = "Унікальне ім\'я";
			this.UserName.MinimumWidth = 6;
			this.UserName.Name = "UserName";
			this.UserName.ReadOnly = true;
			this.UserName.Width = 125;
			// 
			// FirstName
			// 
			this.FirstName.HeaderText = "Ім\'я";
			this.FirstName.MinimumWidth = 6;
			this.FirstName.Name = "FirstName";
			this.FirstName.ReadOnly = true;
			this.FirstName.Width = 125;
			// 
			// LastName
			// 
			this.LastName.HeaderText = "Прізвище";
			this.LastName.MinimumWidth = 6;
			this.LastName.Name = "LastName";
			this.LastName.ReadOnly = true;
			this.LastName.Width = 125;
			// 
			// IsBanned
			// 
			this.IsBanned.HeaderText = "Заблокований";
			this.IsBanned.MinimumWidth = 6;
			this.IsBanned.Name = "IsBanned";
			this.IsBanned.ReadOnly = true;
			this.IsBanned.Width = 125;
			// 
			// BanButton
			// 
			this.BanButton.HeaderText = "Заблокувати/Розблокувати";
			this.BanButton.MinimumWidth = 6;
			this.BanButton.Name = "BanButton";
			this.BanButton.ReadOnly = true;
			this.BanButton.Width = 200;
			// 
			// ReportGenerationButton
			// 
			this.ReportGenerationButton.Location = new System.Drawing.Point(12, 12);
			this.ReportGenerationButton.Name = "ReportGenerationButton";
			this.ReportGenerationButton.Size = new System.Drawing.Size(187, 60);
			this.ReportGenerationButton.TabIndex = 43;
			this.ReportGenerationButton.Text = "Згенерувати звітність активностей користувачів";
			this.ReportGenerationButton.UseVisualStyleBackColor = true;
			this.ReportGenerationButton.Click += new System.EventHandler(this.ReportGenerationButton_Click);
			// 
			// AdminForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(88)))), ((int)(((byte)(67)))));
			this.ClientSize = new System.Drawing.Size(1251, 1022);
			this.Controls.Add(this.ReportGenerationButton);
			this.Controls.Add(this.usersDataGridView);
			this.Controls.Add(this.tasksDataGridView);
			this.Controls.Add(this.RefreshTasksButton);
			this.Controls.Add(this.RefreshUsersButton);
			this.Controls.Add(this.LogoutButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.AthLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AdminForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AdminForm";
			((System.ComponentModel.ISupportInitialize)(this.tasksDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label AthLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button RefreshUsersButton;
		private System.Windows.Forms.Button LogoutButton;
		private System.Windows.Forms.Button RefreshTasksButton;
		private System.Windows.Forms.DataGridView tasksDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
		private System.Windows.Forms.DataGridViewTextBoxColumn TaskStatus;
		private System.Windows.Forms.DataGridViewButtonColumn Signers;
		private System.Windows.Forms.DataGridViewButtonColumn Document;
		private System.Windows.Forms.DataGridViewButtonColumn Revoke;
		private System.Windows.Forms.DataGridView usersDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
		private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
		private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
		private System.Windows.Forms.DataGridViewTextBoxColumn IsBanned;
		private System.Windows.Forms.DataGridViewButtonColumn BanButton;
		private System.Windows.Forms.Button ReportGenerationButton;
	}
}