using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NLog;
using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;
using SignItNow.Services.Interfaces;

namespace SignItNow.Forms
{
	public partial class CompletedTasksForm : Form
	{
		private static CompletedTasksForm _form;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private ITaskInfoRepository taskInfoRepository;

		private IUserBannedService userBannedService = ServiceLocator.Get<IUserBannedService>();

		private IEncryptorDecryptor encryptorDecryptor;

		private IFormRedirectionService formRedirectionService;

		private List<TaskInfo> taskInfos = new List<TaskInfo>();

		private CompletedTasksForm()
		{
			taskInfoRepository = ServiceLocator.Get<ITaskInfoRepository>();
			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();
			formRedirectionService = ServiceLocator.Get<IFormRedirectionService>();

			InitializeComponent();
		}

		public static CompletedTasksForm GetInstance()
		{
			if (_form == null)
			{
				_form = new CompletedTasksForm();
			}

			return _form;
		}

		public void FillCompletedTasks()
		{
			this.completedTasksDataGridView.Rows.Clear();
			taskInfos = taskInfoRepository.GetCompletedTasks(Program.UserId.Value);

			foreach (var task in taskInfos)
			{
				this.completedTasksDataGridView.Rows.Add(task.Id, encryptorDecryptor.Decrypt(task.Name),
					encryptorDecryptor.Decrypt(task.Name) + ".pdf",
					$"{encryptorDecryptor.Decrypt(task.TaskCreator.FirstName)} {encryptorDecryptor.Decrypt(task.TaskCreator.LastName)}",
					task.Signers.FirstOrDefault(ts => ts.Signer.Id == Program.UserId.Value).SigningStatus,
					"Переглянути");
			}
		}

		private void completedTasksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);
				
				return;
			}

			if (e.RowIndex > -1 && e.RowIndex < taskInfos.Count && e.ColumnIndex == 5)
			{
				var taskInfo = this.taskInfos.FirstOrDefault(t =>
					t.Id == (int) this.completedTasksDataGridView.Rows[e.RowIndex].Cells[0].Value);

				//Preview Doc
				var previewDoc = PreviewDocument.GetInstance();

				if (!File.Exists(Path.Combine(Program.BaseFilePath, Program.UploadedDocsFolder,
					    taskInfo.Document.Name)))
				{
					DialogResult result = MessageBox.Show("Документ вже не існує!",
						"Помилка", MessageBoxButtons.OK);

					return;
				}

				previewDoc.axAcroPDF1.src = Path.Combine(Program.BaseFilePath,
					Program.UploadedDocsFolder, taskInfo.Document.Name);

				previewDoc.Show();

				this.FillCompletedTasks();
			}
		}

		private void RefreshButton_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			this.FillCompletedTasks();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			this.taskInfos.Clear();
			this.completedTasksDataGridView.Rows.Clear();

			formRedirectionService.Redirect(this, FormType.MainUserPageForm);
		}
	}
}
