using System.Windows.Forms;
using SignItNow.Forms;
using SignItNow.Model.Enums;
using SignItNow.Services.Interfaces;

namespace SignItNow.Services
{
	public class FormRedirectionService : IFormRedirectionService
	{
		public void Redirect(Form oldForm, FormType newForm)
		{
			switch (newForm)
			{
				case FormType.AdminForm:
					AdminForm.GetInstance().Show();
					break;
				case FormType.MainForm:
					MainForm.GetInstance().Show();
					break;
				case FormType.RegisterUserForm:
					RegisterUserForm.GetInstance().Show();
					break;
				case FormType.MainUserPageForm:
					MainUserPageForm.GetInstance().Show();
					break;
				case FormType.IncommingTasksForm:
					IncommingTasksForm.GetInstance().Show();
					break;
				case FormType.CompletedTasksForm:
					CompletedTasksForm.GetInstance().Show();
					break;
				case FormType.SentTasksForm:
					SentTasksForm.GetInstance().Show();
					break;
				case FormType.NewTaskForm:
					NewTaskForm.GetInstance().Show();
					break;
				case FormType.UpdateUserProfileForm:
					UpdateUserProfileForm.GetInstance().Show();
					break;
			}

			oldForm.Hide();
		}
	}
}