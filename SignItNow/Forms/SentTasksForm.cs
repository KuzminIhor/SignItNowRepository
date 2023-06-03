using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	public partial class SentTasksForm : Form
	{
		private static SentTasksForm _form;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private List<TaskInfo> taskInfos = new List<TaskInfo>();

		private ITaskInfoRepository taskInfoRepository;

		private IUserBannedService userBannedService = ServiceLocator.Get<IUserBannedService>();

		private IEncryptorDecryptor encryptorDecryptor;
		
		private IFormRedirectionService formRedirectionService;
		private IRevokeTaskService revokeTaskService;

		private SentTasksForm()
		{
			taskInfoRepository = ServiceLocator.Get<ITaskInfoRepository>();
			formRedirectionService = ServiceLocator.Get<IFormRedirectionService>();
			revokeTaskService = ServiceLocator.Get<IRevokeTaskService>();
			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();

			InitializeComponent();
		}

		public static SentTasksForm GetInstance()
		{
			if (_form == null)
			{
				_form = new SentTasksForm();
			}

			return _form;
		}

		public void FillSentTasksTable()
		{
			this.sentTasksDataGridView.Rows.Clear();
			taskInfos = taskInfoRepository.GetCreatedTasks(Program.UserId.Value);

			foreach (var taskInfo in taskInfos)
			{
				this.sentTasksDataGridView.Rows.Add(taskInfo.Id, taskInfo.Name, taskInfo.TaskStatus, "Переглянути",
					"Переглянути", "Забракувати");
			}
		}

		private void sentTasksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			if (e.RowIndex > -1 && e.RowIndex < taskInfos.Count && e.ColumnIndex >= 3 && e.ColumnIndex <=5)
			{
				var taskInfo = this.taskInfos.FirstOrDefault(t => t.Id == (int) this.sentTasksDataGridView.Rows[e.RowIndex].Cells[0].Value);

				if (taskInfo.TaskStatus == Model.Enums.TaskStatus.Забраковано)
				{
					DialogResult dr = MessageBox.Show("Ваша задача забракована!", "Помилка");
					return;
				}

				//Document preview 
				if (e.ColumnIndex == 4)
				{
					var previewDoc = PreviewDocument.GetInstance();

					previewDoc.axAcroPDF1.src = Path.Combine(Program.BaseFilePath,
						Program.UploadedDocsFolder, taskInfo.Document.Name);

					previewDoc.Show();
				}

				//Signers preview 
				if (e.ColumnIndex == 3)
				{
					var signersInfoString = "";

					foreach (var signer in taskInfo.Signers)
					{
						signersInfoString +=
							$"Ім'я: {encryptorDecryptor.Decrypt(signer.Signer.FirstName)}\nПрізвище: {encryptorDecryptor.Decrypt(signer.Signer.LastName)}\nУнікальне ім'я: {encryptorDecryptor.Decrypt(signer.Signer.UserName)}\nСтатус: {signer.SigningStatus}\nКоментар: {encryptorDecryptor.Decrypt(signer.TaskComment)}\n\n";
					}

					DialogResult dr1 = MessageBox.Show(signersInfoString, "Підписанти");
				}

				//Revoke 
				if (e.ColumnIndex == 5)
				{
					DialogResult result = MessageBox.Show("Ви впевнені, що хочете забракувати дану задачу?",
						"Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (result == DialogResult.Yes)
					{
						revokeTaskService.Revoke(taskInfo.Id, taskInfo.Document.Id, taskInfo.Document.Name);
					}
				}

				FillSentTasksTable();
			}
		}

		private void SentTasksForm_Load(object sender, EventArgs e)
		{

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
			
			this.sentTasksDataGridView.Rows.Clear();

			formRedirectionService.Redirect(this, FormType.MainUserPageForm);
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

			FillSentTasksTable();
		}
	}
}
