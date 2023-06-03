using System;
using System.Security.Authentication;
using System.Windows.Forms;
using NLog;
using SignItNow.Core;
using SignItNow.Model.Enums;
using SignItNow.Services.Interfaces;

namespace SignItNow.Forms
{
    public partial class MainForm : Form
    {
	    private static MainForm _mainForm;
	    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

	    private IUserBannedService userBannedService = ServiceLocator.Get<IUserBannedService>();

		private readonly IFormRedirectionService formRedirectionService;
	    private readonly IAuthenticationService authenticationService;

	    private MainForm()
	    {
		    formRedirectionService = ServiceLocator.Get<IFormRedirectionService>();
		    authenticationService = ServiceLocator.Get<IAuthenticationService>();

	        InitializeComponent();	
        }

        public static MainForm GetInstance()
        {
	        if (_mainForm == null)
	        {
		        _mainForm = new MainForm();
	        }

	        return _mainForm;
        }

		private void LoginButton_Click(object sender, EventArgs e)
		{
			var userName = LoginTextBox.Text;
			var password = PasswordTextBox.Text;

			try
			{
				var formToRedirect = (FormType) authenticationService.Authenticate(userName, password);

				var userType = Program.UserId == 1 ? "Адмін" : "Підписант/Надсилач";

				_logger.Info($"Аутентифікація пройшла успішно. Тип користувача: {userType}. ID користувача: {Program.UserId}");

				this.LoginTextBox.Text = string.Empty;
				this.PasswordTextBox.Text = string.Empty;

				if (userType == "Адмін")
				{
					AdminForm.GetInstance().FillTasksTable();
					AdminForm.GetInstance().FillUsersTable();

					formRedirectionService.Redirect(this, formToRedirect);
					return;
				}

				if (userBannedService.IsBanned(Program.UserId.Value))
				{
					DialogResult result = MessageBox.Show("Вас заблокували! Зверніться з деталями до адміністратора!",
						"Помилка", MessageBoxButtons.OK);

					Program.UserId = null;

					return;
				}

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
		private void CreateNewProfileButton_Click(object sender, EventArgs e)
		{
			formRedirectionService.Redirect(this, FormType.RegisterUserForm);
		}
	}
}
