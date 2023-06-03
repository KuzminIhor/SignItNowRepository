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
using SignItNow.Model.Enums;
using SignItNow.Services.Interfaces;

namespace SignItNow.Forms
{
	public partial class RegisterUserForm : Form
	{
		private static RegisterUserForm _registerUserForm;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private readonly IFormRedirectionService formRedirectionService;
		private readonly IAuthenticationService authenticationService;

		public RegisterUserForm()
		{
			formRedirectionService = ServiceLocator.Get<IFormRedirectionService>();
			authenticationService = ServiceLocator.Get<IAuthenticationService>();
			
			InitializeComponent();
		}
		public static RegisterUserForm GetInstance()
		{
			if (_registerUserForm == null)
			{
				_registerUserForm = new RegisterUserForm();
			}

			return _registerUserForm;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			formRedirectionService.Redirect(this, FormType.MainForm);
		}

		private void RegisterButton_Click(object sender, EventArgs e)
		{
			var userName = this.LoginTextBox.Text;
			var firstName = this.FirstNameTextBox.Text;
			var lastName = this.LastNameTextBox.Text;
			var password = this.PasswordTextBox.Text;

			try
			{
				var formToRedirect = (FormType) authenticationService.Register(userName, password, firstName, lastName);

				var userType = "Підписант/Надсилач";

				_logger.Info($"Реєстрація пройшла успішно. Тип користувача: {userType}. ID користувача: {Program.UserId}");

				this.LoginTextBox.Text = string.Empty;
				this.FirstNameTextBox.Text = string.Empty;
				this.LastNameTextBox.Text = string.Empty;
				this.PasswordTextBox.Text = string.Empty;

				formRedirectionService.Redirect(this, formToRedirect);
			}
			catch (AuthenticationException ex)
			{
				DialogResult dr1 = MessageBox.Show(ex.Message, "Помилка");

				_logger.Error($"ПОМИЛКА під час аутентифікації користувачем: {ex.Message}");
			}
			catch (Exception ex)
			{
				DialogResult dr1 = MessageBox.Show("Сталась якась помилка", "Помилка");

				_logger.Error($"ПОМИЛКА під час аутентифікації користувачем: {ex.Message}");
			}
		}
	}
}
