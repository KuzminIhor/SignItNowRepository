using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Model.Enums;

namespace SignItNow.Helpers
{
	public class FinishAuthentication: AbstractAuthenticationHandler, IFinishAuthentication
	{
		public override object Handle(User user, bool isRegistrationOrUpdate)
		{
			var form = GetFormToRedirect(user.UserName);
			return form;
		}

		public FormType GetFormToRedirect(string userName)
		{
			if (userName.Equals("admin"))
			{
				return FormType.AdminForm;
			}

			return FormType.MainUserPageForm;
		}
	}
}