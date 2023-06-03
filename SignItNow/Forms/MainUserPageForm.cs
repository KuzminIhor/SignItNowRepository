using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using SignItNow.Core;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;
using SignItNow.Services.Interfaces;

namespace SignItNow.Forms
{
	public partial class MainUserPageForm : Form
	{
		private static MainUserPageForm _form;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private IFormRedirectionService formRedirectionService;
		private IUserBannedService userBannedService = ServiceLocator.Get<IUserBannedService>();

		private MainUserPageForm()
		{
			formRedirectionService = ServiceLocator.Get<IFormRedirectionService>();

			InitializeComponent();
		}

		public static MainUserPageForm GetInstance()
		{
			if (_form == null)
			{
				_form = new MainUserPageForm();
			}

			return _form;
		}

		private void MainUserPageForm_Shown(object sender, EventArgs e)
		{
		}

		private void LogOutButton_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			Program.UserId = null;

			formRedirectionService.Redirect(this, FormType.MainForm);
		}

		//Update profile
		private void button4_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			UpdateUserProfileForm.GetInstance().SetCurrentUser();

			formRedirectionService.Redirect(this, FormType.UpdateUserProfileForm);
		}

		//Send Doc
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

			formRedirectionService.Redirect(this, FormType.NewTaskForm);
		}

		//Sent Tasks
		private void button3_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			SentTasksForm.GetInstance().FillSentTasksTable();
			formRedirectionService.Redirect(this, FormType.SentTasksForm);
		}

		//Incomming Tasks
		private void ViewIncommingTasksButton_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			IncommingTasksForm.GetInstance().FillIncommingTasks();
			formRedirectionService.Redirect(this, FormType.IncommingTasksForm);
		}

		//Completed Tasks
		private void button2_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			CompletedTasksForm.GetInstance().FillCompletedTasks();
			formRedirectionService.Redirect(this, FormType.CompletedTasksForm);
		}
	}
}
