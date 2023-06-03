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
using SignItNow.Model.Exceptions;
using SignItNow.Services.Interfaces;

namespace SignItNow.Forms
{
	public partial class NewTaskForm : Form
	{
		private static NewTaskForm _form;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private readonly IUploadDocumentService uploadDocumentService;
		private readonly ICreateTaskService createTaskService;
		private readonly IFormRedirectionService formRedirectionService;

		private IUserBannedService userBannedService = ServiceLocator.Get<IUserBannedService>();

		private readonly IFindSignerHelper findSignerHelper;
		private readonly IUserFieldsValidator userFieldsValidator;

		private List<User> Signers = new List<User>();

		private NewTaskForm()
		{
			uploadDocumentService = ServiceLocator.Get<IUploadDocumentService>();
			createTaskService = ServiceLocator.Get<ICreateTaskService>();
			formRedirectionService = ServiceLocator.Get<IFormRedirectionService>();

			findSignerHelper = ServiceLocator.Get<IFindSignerHelper>();
			userFieldsValidator = ServiceLocator.Get<IUserFieldsValidator>();

			InitializeComponent();
		}

		public static NewTaskForm GetInstance()
		{
			if (_form == null)
			{
				_form = new NewTaskForm();
			}

			return _form;
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

			this.Signers = new List<User>();

			this.TaskNameTextBox.Text = string.Empty;

			this.signerFirstName.Text = string.Empty;
			this.signerLastName.Text = string.Empty;
			this.signerUserName.Text = string.Empty;

			this.signersDataGridView.Rows.Clear();

			formRedirectionService.Redirect(this, FormType.MainUserPageForm);
		}

		//Upload file
		private void button1_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			if (this.uploadFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					string selectedFilePath = this.uploadFileDialog.FileName;

					uploadDocumentService.UploadTempDocument(selectedFilePath);

					DialogResult dr1 = MessageBox.Show("Файл успішно завантажено", "Успіх");
				}
				catch (FileLoadException ex)
				{
					DialogResult dr1 = MessageBox.Show(ex.Message, "Помилка");

					_logger.Error("Сталась помилка від час завантаження тимчасового документу: " + ex.Message);
				}
				catch (Exception ex)
				{
					DialogResult dr1 = MessageBox.Show("Сталась якась помилка", "Помилка");

					_logger.Error("Сталась помилка від час завантаження тимчасового документу: " + ex.Message);
				}
			}
		}

		private void documentPreviewButton_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			if (!File.Exists(Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + ".pdf")))
			{
				DialogResult dr1 = MessageBox.Show("Ви не завантажили файл!", "Помилка");
				return;
			}

			var previewDoc = PreviewDocument.GetInstance();

			previewDoc.axAcroPDF1.src = Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + ".pdf");
			
			previewDoc.Show();
		}

		private void SubmitCreatingTaskButton_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			if (!File.Exists(Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + ".pdf")))
			{
				DialogResult dr1 = MessageBox.Show("Ви не завантажили файл!", "Помилка");
				return;
			}

			try
			{
				createTaskService.CreateTask(this.TaskNameTextBox.Text, this.Signers);

				DialogResult dr1 = MessageBox.Show("Задача успішно створена!", "Успіх");

				this.TaskNameTextBox.Text = string.Empty;

				this.Signers.Clear();
				this.signersDataGridView.Rows.Clear();

				this.signerFirstName.Text = string.Empty;
				this.signerLastName.Text = string.Empty;
				this.signerUserName.Text = string.Empty;

				_logger.Info($"Створена нова задача з документом на підпис користувачем {Program.UserId.Value}");
			}
			catch (TaskCreateException ex)
			{
				DialogResult dr1 = MessageBox.Show(ex.Message, "Помилка");

				_logger.Error("Сталась помилка від час створення нової задачі: " + ex.Message);
			}
			catch (Exception ex)
			{
				DialogResult dr1 = MessageBox.Show(ex.Message, "Помилка");

				_logger.Error("Сталась помилка від час створення нової задачі: " + ex.Message);
			}
		}

		private void AddSignerButton_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			try
			{
				userFieldsValidator.ValidateUserName(this.signerUserName.Text);
				userFieldsValidator.ValidateFirstName(this.signerFirstName.Text);
				userFieldsValidator.ValidateLastName(this.signerLastName.Text);

				if (this.Signers.FirstOrDefault(s => s.UserName.Equals(this.signerUserName.Text)) != null)
				{
					DialogResult dr1 = MessageBox.Show("Ви вже додали даного підписанта!", "Помилка");
					return;
				} else if (!findSignerHelper.DoesSignerExist(this.signerUserName.Text, this.signerFirstName.Text,
					           this.signerLastName.Text))
				{
					DialogResult dr1 = MessageBox.Show("Такого користувача-підписанта не існує!", "Помилка");
					return;
				}

				this.Signers.Add(new User()
				{
					UserName = this.signerUserName.Text, 
					FirstName = this.signerFirstName.Text,
					LastName = this.signerLastName.Text
				});

				this.signersDataGridView.Rows.Add(this.signerUserName.Text, this.signerFirstName.Text,
					this.signerLastName.Text, "Видалити");

				this.signerFirstName.Text = string.Empty;
				this.signerLastName.Text = string.Empty;
				this.signerUserName.Text = string.Empty;
			}
			catch (UserModifyException ex)
			{
				DialogResult dr1 = MessageBox.Show(ex.Message, "Помилка");
			}
		}

		private void ClearSignerFields_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			this.signerFirstName.Text = string.Empty;
			this.signerLastName.Text = string.Empty;
			this.signerUserName.Text = string.Empty;
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

			//Pressed Delete button
			if (e.ColumnIndex == 3 && e.RowIndex > -1 && e.RowIndex < this.Signers.Count)
			{
				this.Signers.RemoveAt(e.RowIndex);
				this.signersDataGridView.Rows.RemoveAt(e.RowIndex);
			}
		}
	}
}
