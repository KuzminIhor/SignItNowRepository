using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
	public partial class AdminForm : Form
	{
		private static AdminForm _form;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private ITaskInfoRepository taskInfoRepository;
		private IUserRepository userRepository;

		private IUserBannedService userBannedService = ServiceLocator.Get<IUserBannedService>();
		private IRevokeTaskService revokeTaskService;

		private IEncryptorDecryptor encryptorDecryptor;

		private IFormRedirectionService formRedirectionService;

		private List<User> userInfos = new List<User>();
		private List<TaskInfo> taskInfos = new List<TaskInfo>();

		private AdminForm()
		{
			taskInfoRepository = ServiceLocator.Get<ITaskInfoRepository>();
			userRepository = ServiceLocator.Get<IUserRepository>();
			revokeTaskService = ServiceLocator.Get<IRevokeTaskService>();
			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();
			formRedirectionService = ServiceLocator.Get<IFormRedirectionService>();

			InitializeComponent();
		}

		public static AdminForm GetInstance()
		{
			if (_form == null)
			{
				_form = new AdminForm();
			}

			return _form;
		}

		public void FillUsersTable()
		{
			userInfos.Clear();
			this.usersDataGridView.Rows.Clear();

			userInfos = userRepository.GetUsersCollectionExceptAdmin();

			foreach (var userInfo in userInfos)
			{
				var banButton = Convert.ToBoolean(userInfo.Metadata["isBanned"]) == true
					? "Розблокувати"
					: "Заблокувати";

				var banStatus = Convert.ToBoolean(userInfo.Metadata["isBanned"]) == true
					? "Так"
					: "Ні";

				this.usersDataGridView.Rows.Add(userInfo.Id, encryptorDecryptor.Decrypt(userInfo.UserName),
					encryptorDecryptor.Decrypt(userInfo.FirstName), encryptorDecryptor.Decrypt(userInfo.LastName),
					banStatus, banButton);
			}
		}

		public void FillTasksTable()
		{
			taskInfos.Clear();
			this.tasksDataGridView.Rows.Clear();

			taskInfos = taskInfoRepository.GetAllTasks();

			foreach (var taskInfo in taskInfos)
			{
				this.tasksDataGridView.Rows.Add(taskInfo.Id, taskInfo.Name, taskInfo.TaskStatus, "Переглянути",
					"Переглянути", "Забракувати");
			}
		}

		private void LogoutButton_Click(object sender, EventArgs e)
		{
			Program.UserId = null;
			formRedirectionService.Redirect(this, FormType.MainForm);
		}

		private void RefreshTasksButton_Click(object sender, EventArgs e)
		{
			FillTasksTable();
		}

		private void RefreshUsersButton_Click(object sender, EventArgs e)
		{
			FillUsersTable();
		}

		private void usersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1 && e.RowIndex < userInfos.Count && e.ColumnIndex == 5)
			{
				var userInfo = this.userInfos.FirstOrDefault(t => t.Id == (int)this.usersDataGridView.Rows[e.RowIndex].Cells[0].Value);

				//Ban/Unban
				var currentStatus = Convert.ToBoolean(userInfo.Metadata["isBanned"]);

				userInfo.Metadata["isBanned"] = (!currentStatus).ToString();

				var process = (!currentStatus) == true ? "Заблоковування" : "Розблоковування";

				try
				{
					userRepository.UpdateUser(userInfo);
				}
				catch (Exception ex)
				{
					_logger.Error($"Під час {process} адміністратором користувача {userInfo.Id} сталась помилка: {ex.Message}");
				}
				finally
				{
					_logger.Info($"Користувач {userInfo.Id} попав під процес {process} адміністратором");

					FillUsersTable();
				}
			}
		}

		private void tasksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1 && e.RowIndex < taskInfos.Count && e.ColumnIndex >= 3 && e.ColumnIndex <= 5)
			{
				var taskInfo = this.taskInfos.FirstOrDefault(t => t.Id == (int)this.tasksDataGridView.Rows[e.RowIndex].Cells[0].Value);

				if (taskInfo.TaskStatus == Model.Enums.TaskStatus.Забраковано)
				{
					DialogResult dr = MessageBox.Show("Задача забракована!", "Помилка");
					return;
				}

				//View signers
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

				//View doc
				if (e.ColumnIndex == 4)
				{
					var previewDoc = PreviewDocument.GetInstance();

					previewDoc.axAcroPDF1.src = Path.Combine(Program.BaseFilePath,
						Program.UploadedDocsFolder, taskInfo.Document.Name);

					previewDoc.Show();
				}

				//Revoke task
				if (e.ColumnIndex == 5)
				{
					DialogResult result = MessageBox.Show("Ви впевнені, що хочете забракувати дану задачу?",
						"Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (result == DialogResult.Yes)
					{
						try
						{
							revokeTaskService.Revoke(taskInfo.Id, taskInfo.Document.Id, taskInfo.Document.Name);
						}
						catch (Exception ex)
						{
							_logger.Error($"Сталась помилка під час забракування задачі {taskInfo.Id} адміністратором: {ex.Message}");
						}
						finally
						{
							_logger.Info($"Задача {taskInfo.Id} була забракована адміністратором");
						}
					}
				}

				FillTasksTable();
			}
		}

		private void ReportGenerationButton_Click(object sender, EventArgs e)
		{
			// Create a PDF document
			Document document = new Document();

			// Get the user-specified file name and location using SaveFileDialog
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
			saveFileDialog.Title = "Збережіть звітність";
			saveFileDialog.FileName = "Звіт";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string pdfFilePath = saveFileDialog.FileName;

				try
				{
					// Set the font for Cyrillic text
					BaseFont baseFont = BaseFont.CreateFont(Path.Combine(Program.BaseFilePath, "Core", "Fonts", "times new roman.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
					Font font = new Font(baseFont);

					// Create a PDF writer to write the document to the specified file
					PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));

					// Open the PDF document
					document.Open();

					// Read the content of the .log file
					string logContent = File.ReadAllText(Path.Combine(Program.BaseFilePath, "AppData", "Logs", "Logs.log"));

					// Add the content to the PDF document using the Cyrillic font
					document.Add(new Paragraph(logContent, font));

					// Close the PDF document
					document.Close();

					MessageBox.Show("Звітність згенерована успішно!", "Успіх");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Сталась помилка: " + ex.Message);
				}
			}
		}
	}
}
