
namespace SignItNow.Forms
{
	partial class NewTaskForm
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
			this.components = new System.ComponentModel.Container();
			this.GreetingsLabel = new System.Windows.Forms.Label();
			this.CancelButton = new System.Windows.Forms.Button();
			this.uploadFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.uploadDocButton = new System.Windows.Forms.Button();
			this.uploadDocLabel = new System.Windows.Forms.Label();
			this.LoginLabel = new System.Windows.Forms.Label();
			this.TaskNameTextBox = new System.Windows.Forms.TextBox();
			this.documentPreviewButton = new System.Windows.Forms.Button();
			this.SubmitCreatingTaskButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.signerFirstName = new System.Windows.Forms.TextBox();
			this.signerLastName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.signerUserName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.signersDataGridView = new System.Windows.Forms.DataGridView();
			this.SignerUserNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SignerFirstNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SignerLastNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
			this.AddSignerButton = new System.Windows.Forms.Button();
			this.ClearSignerFields = new System.Windows.Forms.Button();
			this.newTaskFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.signersDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.newTaskFormBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// GreetingsLabel
			// 
			this.GreetingsLabel.AutoSize = true;
			this.GreetingsLabel.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.GreetingsLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.GreetingsLabel.Location = new System.Drawing.Point(233, 9);
			this.GreetingsLabel.Name = "GreetingsLabel";
			this.GreetingsLabel.Size = new System.Drawing.Size(632, 45);
			this.GreetingsLabel.TabIndex = 11;
			this.GreetingsLabel.Text = "Створення документу для підпису";
			this.GreetingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(914, 729);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(120, 60);
			this.CancelButton.TabIndex = 15;
			this.CancelButton.Text = "Назад";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// uploadFileDialog
			// 
			this.uploadFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|Word Files (*.doc; *.docx)|*.doc;*.docx|Excel Files (*.xl" +
    "s; *.xlsx)|*.xls;*.xlsx|PowerPoint Files (*.ppt; *.pptx)|*.ppt;*.pptx";
			// 
			// uploadDocButton
			// 
			this.uploadDocButton.Location = new System.Drawing.Point(726, 125);
			this.uploadDocButton.Name = "uploadDocButton";
			this.uploadDocButton.Size = new System.Drawing.Size(139, 42);
			this.uploadDocButton.TabIndex = 16;
			this.uploadDocButton.Text = "Завантажити документ";
			this.uploadDocButton.UseVisualStyleBackColor = true;
			this.uploadDocButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// uploadDocLabel
			// 
			this.uploadDocLabel.AutoSize = true;
			this.uploadDocLabel.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.uploadDocLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.uploadDocLabel.Location = new System.Drawing.Point(734, 91);
			this.uploadDocLabel.Name = "uploadDocLabel";
			this.uploadDocLabel.Size = new System.Drawing.Size(274, 31);
			this.uploadDocLabel.TabIndex = 17;
			this.uploadDocLabel.Text = "Документ для підпису:";
			this.uploadDocLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LoginLabel
			// 
			this.LoginLabel.AutoSize = true;
			this.LoginLabel.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.LoginLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.LoginLabel.Location = new System.Drawing.Point(81, 92);
			this.LoginLabel.Name = "LoginLabel";
			this.LoginLabel.Size = new System.Drawing.Size(162, 31);
			this.LoginLabel.TabIndex = 19;
			this.LoginLabel.Text = "Назва задачі:";
			// 
			// TaskNameTextBox
			// 
			this.TaskNameTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TaskNameTextBox.Location = new System.Drawing.Point(12, 125);
			this.TaskNameTextBox.Name = "TaskNameTextBox";
			this.TaskNameTextBox.Size = new System.Drawing.Size(299, 30);
			this.TaskNameTextBox.TabIndex = 18;
			// 
			// documentPreviewButton
			// 
			this.documentPreviewButton.Location = new System.Drawing.Point(871, 125);
			this.documentPreviewButton.Name = "documentPreviewButton";
			this.documentPreviewButton.Size = new System.Drawing.Size(137, 42);
			this.documentPreviewButton.TabIndex = 20;
			this.documentPreviewButton.Text = "Переглянути документ";
			this.documentPreviewButton.UseVisualStyleBackColor = true;
			this.documentPreviewButton.Click += new System.EventHandler(this.documentPreviewButton_Click);
			// 
			// SubmitCreatingTaskButton
			// 
			this.SubmitCreatingTaskButton.Location = new System.Drawing.Point(12, 729);
			this.SubmitCreatingTaskButton.Name = "SubmitCreatingTaskButton";
			this.SubmitCreatingTaskButton.Size = new System.Drawing.Size(120, 60);
			this.SubmitCreatingTaskButton.TabIndex = 21;
			this.SubmitCreatingTaskButton.Text = "Створити задачу";
			this.SubmitCreatingTaskButton.UseVisualStyleBackColor = true;
			this.SubmitCreatingTaskButton.Click += new System.EventHandler(this.SubmitCreatingTaskButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(70, 260);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(193, 31);
			this.label1.TabIndex = 23;
			this.label1.Text = "Ім\'я підписанта:";
			// 
			// signerFirstName
			// 
			this.signerFirstName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.signerFirstName.Location = new System.Drawing.Point(12, 294);
			this.signerFirstName.Name = "signerFirstName";
			this.signerFirstName.Size = new System.Drawing.Size(299, 30);
			this.signerFirstName.TabIndex = 24;
			// 
			// signerLastName
			// 
			this.signerLastName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.signerLastName.Location = new System.Drawing.Point(367, 294);
			this.signerLastName.Name = "signerLastName";
			this.signerLastName.Size = new System.Drawing.Size(299, 30);
			this.signerLastName.TabIndex = 26;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(389, 260);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(262, 31);
			this.label2.TabIndex = 25;
			this.label2.Text = "Прізвище підписанта:";
			// 
			// signerUserName
			// 
			this.signerUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.signerUserName.Location = new System.Drawing.Point(713, 294);
			this.signerUserName.Name = "signerUserName";
			this.signerUserName.Size = new System.Drawing.Size(299, 30);
			this.signerUserName.TabIndex = 28;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 16F);
			this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label3.Location = new System.Drawing.Point(694, 260);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(314, 31);
			this.label3.TabIndex = 27;
			this.label3.Text = "Унікальне Ім\'я підписанта:";
			// 
			// signersDataGridView
			// 
			this.signersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.signersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SignerUserNameCol,
            this.SignerFirstNameCol,
            this.SignerLastNameCol,
            this.Delete});
			this.signersDataGridView.Location = new System.Drawing.Point(12, 454);
			this.signersDataGridView.Name = "signersDataGridView";
			this.signersDataGridView.RowHeadersWidth = 51;
			this.signersDataGridView.RowTemplate.Height = 24;
			this.signersDataGridView.Size = new System.Drawing.Size(1022, 269);
			this.signersDataGridView.TabIndex = 30;
			this.signersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.signersDataGridView_CellContentClick);
			// 
			// SignerUserNameCol
			// 
			this.SignerUserNameCol.HeaderText = "Унікальне ім\'я";
			this.SignerUserNameCol.MinimumWidth = 6;
			this.SignerUserNameCol.Name = "SignerUserNameCol";
			this.SignerUserNameCol.ReadOnly = true;
			this.SignerUserNameCol.Width = 125;
			// 
			// SignerFirstNameCol
			// 
			this.SignerFirstNameCol.HeaderText = "Ім\'я";
			this.SignerFirstNameCol.MinimumWidth = 6;
			this.SignerFirstNameCol.Name = "SignerFirstNameCol";
			this.SignerFirstNameCol.ReadOnly = true;
			this.SignerFirstNameCol.Width = 125;
			// 
			// SignerLastNameCol
			// 
			this.SignerLastNameCol.HeaderText = "Прізвище";
			this.SignerLastNameCol.MinimumWidth = 6;
			this.SignerLastNameCol.Name = "SignerLastNameCol";
			this.SignerLastNameCol.ReadOnly = true;
			this.SignerLastNameCol.Width = 125;
			// 
			// Delete
			// 
			this.Delete.HeaderText = "Видалити";
			this.Delete.MinimumWidth = 6;
			this.Delete.Name = "Delete";
			this.Delete.ReadOnly = true;
			this.Delete.Text = "Видалити";
			this.Delete.Width = 125;
			// 
			// AddSignerButton
			// 
			this.AddSignerButton.Location = new System.Drawing.Point(312, 367);
			this.AddSignerButton.Name = "AddSignerButton";
			this.AddSignerButton.Size = new System.Drawing.Size(120, 60);
			this.AddSignerButton.TabIndex = 31;
			this.AddSignerButton.Text = "Додати підписанта";
			this.AddSignerButton.UseVisualStyleBackColor = true;
			this.AddSignerButton.Click += new System.EventHandler(this.AddSignerButton_Click);
			// 
			// ClearSignerFields
			// 
			this.ClearSignerFields.Location = new System.Drawing.Point(593, 367);
			this.ClearSignerFields.Name = "ClearSignerFields";
			this.ClearSignerFields.Size = new System.Drawing.Size(120, 60);
			this.ClearSignerFields.TabIndex = 32;
			this.ClearSignerFields.Text = "Очистити дані про підписанта";
			this.ClearSignerFields.UseVisualStyleBackColor = true;
			this.ClearSignerFields.Click += new System.EventHandler(this.ClearSignerFields_Click);
			// 
			// newTaskFormBindingSource
			// 
			this.newTaskFormBindingSource.DataSource = typeof(SignItNow.Forms.NewTaskForm);
			// 
			// NewTaskForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(88)))), ((int)(((byte)(67)))));
			this.ClientSize = new System.Drawing.Size(1046, 801);
			this.Controls.Add(this.ClearSignerFields);
			this.Controls.Add(this.AddSignerButton);
			this.Controls.Add(this.signersDataGridView);
			this.Controls.Add(this.signerUserName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.signerLastName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.signerFirstName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SubmitCreatingTaskButton);
			this.Controls.Add(this.documentPreviewButton);
			this.Controls.Add(this.LoginLabel);
			this.Controls.Add(this.TaskNameTextBox);
			this.Controls.Add(this.uploadDocLabel);
			this.Controls.Add(this.uploadDocButton);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.GreetingsLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewTaskForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NewTaskForm";
			((System.ComponentModel.ISupportInitialize)(this.signersDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.newTaskFormBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label GreetingsLabel;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button uploadDocButton;
		private System.Windows.Forms.Label uploadDocLabel;
		private System.Windows.Forms.Label LoginLabel;
		private System.Windows.Forms.TextBox TaskNameTextBox;
		private System.Windows.Forms.Button documentPreviewButton;
		public System.Windows.Forms.OpenFileDialog uploadFileDialog;
		private System.Windows.Forms.Button SubmitCreatingTaskButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox signerFirstName;
		private System.Windows.Forms.TextBox signerLastName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox signerUserName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView signersDataGridView;
		private System.Windows.Forms.Button AddSignerButton;
		private System.Windows.Forms.Button ClearSignerFields;
		private System.Windows.Forms.BindingSource newTaskFormBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn SignerUserNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn SignerFirstNameCol;
		private System.Windows.Forms.DataGridViewTextBoxColumn SignerLastNameCol;
		private System.Windows.Forms.DataGridViewButtonColumn Delete;
	}
}