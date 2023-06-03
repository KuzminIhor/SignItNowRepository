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
using SignItNow.Model.Exceptions;
using SignItNow.Repositories.Interfaces;
using SignItNow.Services.Interfaces;

namespace SignItNow.Forms
{
	public partial class IncommingTasksForm : Form
	{
		private static IncommingTasksForm _form;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private ITaskInfoRepository taskInfoRepository;

		private IUserBannedService userBannedService = ServiceLocator.Get<IUserBannedService>();

		private IEncryptorDecryptor encryptorDecryptor;

		private ISigningService signingService;
		private IFormRedirectionService formRedirectionService;

		private List<TaskInfo> taskInfos = new List<TaskInfo>();

		private IncommingTasksForm()
		{
			signingService = ServiceLocator.Get<ISigningService>();
			formRedirectionService = ServiceLocator.Get<IFormRedirectionService>();
			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();
			taskInfoRepository = ServiceLocator.Get<ITaskInfoRepository>();

			InitializeComponent();
		}

		public static IncommingTasksForm GetInstance()
		{
			if (_form == null)
			{
				_form = new IncommingTasksForm();
			}

			return _form;
		}

		public void FillIncommingTasks()
		{
			this.incommingTasksDataGridView.Rows.Clear();
			taskInfos = taskInfoRepository.GetIncommingTasks(Program.UserId.Value);

			foreach (var task in taskInfos)
			{
				this.incommingTasksDataGridView.Rows.Add(task.Id, encryptorDecryptor.Decrypt(task.Name), encryptorDecryptor.Decrypt(task.Name) + ".pdf",
					$"{encryptorDecryptor.Decrypt(task.TaskCreator.FirstName)} {encryptorDecryptor.Decrypt(task.TaskCreator.LastName)}", "Переглянути", "Підписати",
					"Відмовити");
			}
		}

		private void signersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			if (e.RowIndex > -1 && e.RowIndex < taskInfos.Count && e.ColumnIndex >= 4 && e.ColumnIndex <= 6)
			{
				var taskInfo = this.taskInfos.FirstOrDefault(t => t.Id == (int)this.incommingTasksDataGridView.Rows[e.RowIndex].Cells[0].Value);

				//Preview Doc
				if (e.ColumnIndex == 4)
				{
					var previewDoc = PreviewDocument.GetInstance();

					if (!File.Exists(Path.Combine(Program.BaseFilePath, Program.UploadedDocsFolder, taskInfo.Document.Name)))
					{
						DialogResult result = MessageBox.Show("Документ вже не існує!",
							"Помилка", MessageBoxButtons.OK);

						return;
					}

					previewDoc.axAcroPDF1.src = Path.Combine(Program.BaseFilePath,
						Program.UploadedDocsFolder, taskInfo.Document.Name);

					previewDoc.Show();
				}

				//Reject
				if (e.ColumnIndex == 6)
				{
					DialogResult result = MessageBox.Show("Ви впевнені, що хочете відмовити у підписі дану задачу?",
						"Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (result == DialogResult.Yes)
					{
						DialogResult result2 = MessageBox.Show("Бажаєте залишити коментар?",
							"Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

						//Leave comment
						if (result2 == DialogResult.Yes)
						{
							var form = LeaveCommentForm.GetInstance();
							form.TaskId = taskInfo.Id;
							form.IsSigning = false;
							form.Show();
						}
						//Reject
						else
						{
							try
							{
								signingService.Reject(taskInfo.Id, Program.UserId.Value, false, null);

								DialogResult result3 = MessageBox.Show("Відмовлено у підписі!",
									"Успіх", MessageBoxButtons.OK);

								_logger.Info(
									$"Користувач {Program.UserId.Value} відмовив у підписі задачу {taskInfo.Id}");
							}
							catch (SigningTaskException ex)
							{
								DialogResult result3 = MessageBox.Show(ex.Message,
									"Помилка", MessageBoxButtons.OK);

								_logger.Error(
									$"Сталась помилка під час відмови у підписі задачі {taskInfo.Id} користувачем {Program.UserId.Value}: {ex.Message}");
							}
							catch (Exception ex)
							{
								DialogResult result3 = MessageBox.Show("Сталась якась помилка",
									"Помилка", MessageBoxButtons.OK);

								_logger.Error(
									$"Сталась помилка під час відмови у підписі задачі {taskInfo.Id} користувачем {Program.UserId.Value}: {ex.Message}");
							}
						}
					}
				}

				//Sign
				if (e.ColumnIndex == 5)
				{
					DialogResult result = MessageBox.Show("Ви впевнені, що хочете підписати дану задачу?",
						"Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (result == DialogResult.Yes)
					{
						DialogResult result2 = MessageBox.Show("Бажаєте залишити коментар?",
							"Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

						//Leave comment
						if (result2 == DialogResult.Yes)
						{
							var form = LeaveCommentForm.GetInstance();
							form.TaskId = taskInfo.Id;
							form.IsSigning = true;
							form.Show();
						}
						//Sign
						else
						{
							try
							{
								signingService.Sign(taskInfo.Id, Program.UserId.Value, false, null);

								DialogResult result3 = MessageBox.Show("Підписано!",
									"Успіх", MessageBoxButtons.OK);

								_logger.Info($"Користувач {Program.UserId.Value} підписав задачу {taskInfo.Id}");
							}
							catch (SigningTaskException ex)
							{
								DialogResult result3 = MessageBox.Show(ex.Message,
									"Помилка", MessageBoxButtons.OK);

								_logger.Error(
									$"Сталась помилка під час підпису задачі {taskInfo.Id} користувачем {Program.UserId.Value}: {ex.Message}");
							}
							catch (Exception ex)
							{
								DialogResult result3 = MessageBox.Show("Сталась якась помилка",
									"Помилка", MessageBoxButtons.OK);

								_logger.Error(
									$"Сталась помилка під час підпису задачі {taskInfo.Id} користувачем {Program.UserId.Value}: {ex.Message}");
							}
						}
					}
				}

				this.FillIncommingTasks();
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

			FillIncommingTasks();
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
			this.incommingTasksDataGridView.Rows.Clear();

			formRedirectionService.Redirect(this, FormType.MainUserPageForm);
		}
	}
}
