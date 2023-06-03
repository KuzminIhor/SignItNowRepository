using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication;
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
	public partial class UpdateUserProfileForm : Form
	{
		private static UpdateUserProfileForm _form;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private User currentUser;

		private IUserRepository userRepository;
		private IFormRedirectionService formRedirectionService;
		private IEncryptorDecryptor encryptorDecryptor;
		private IUpdateUserService updateUserService;
		private IUserBannedService userBannedService = ServiceLocator.Get<IUserBannedService>();

		private UpdateUserProfileForm()
		{
			formRedirectionService = ServiceLocator.Get<IFormRedirectionService>();
			userRepository = ServiceLocator.Get<IUserRepository>();
			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();
			updateUserService = ServiceLocator.Get<IUpdateUserService>();

			InitializeComponent();
		}

		public static UpdateUserProfileForm GetInstance()
		{
			if (_form == null)
			{
				_form = new UpdateUserProfileForm();
			}

			return _form;
		}

		public void SetCurrentUser()
		{
			currentUser = userRepository.GetUser(Program.UserId.Value);

			this.LoginTextBox.Text = encryptorDecryptor.Decrypt(currentUser.UserName);
			this.FirstNameTextBox.Text = encryptorDecryptor.Decrypt(currentUser.FirstName);
			this.LastNameTextBox.Text = encryptorDecryptor.Decrypt(currentUser.LastName);
			this.PasswordTextBox.Text = encryptorDecryptor.Decrypt(currentUser.Password);
		}

		private void UpdateButton_Click(object sender, EventArgs e)
		{
			if (userBannedService.IsBanned(Program.UserId.Value))
			{
				DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
					"Помилка", MessageBoxButtons.OK);

				Program.UserId = null;

				formRedirectionService.Redirect(this, FormType.MainForm);

				return;
			}

			var userName = this.LoginTextBox.Text;
			var firstName = this.FirstNameTextBox.Text;
			var lastName = this.LastNameTextBox.Text;
			var password = this.PasswordTextBox.Text;

			try
			{
				var formToRedirect = (FormType)updateUserService.Update(userName, password, firstName, lastName);

				var userType = "Підписант/Надсилач";

				_logger.Info($"Зміна профілю пройшла успішно. Тип користувача: {userType}. ID користувача: {Program.UserId}");

				DialogResult dr1 = MessageBox.Show("Ваш профіль успішно оновлено", "Успіх");

				formRedirectionService.Redirect(this, formToRedirect);
			}
			catch (AuthenticationException ex)
			{
				DialogResult dr1 = MessageBox.Show(ex.Message, "Помилка");

				_logger.Error($"ПОМИЛКА під час зміни профілю користувачем: {ex.Message}");
			}
			catch (Exception ex)
			{
				DialogResult dr1 = MessageBox.Show("Сталась якась помилка", "Помилка");

				_logger.Error($"ПОМИЛКА під час зміни профілю користувачем: {ex.Message}");
			}
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

			formRedirectionService.Redirect(this, FormType.MainUserPageForm);
		}
	}
}
