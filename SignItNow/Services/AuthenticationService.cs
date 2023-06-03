using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Services.Interfaces;

namespace SignItNow.Services
{
	public class AuthenticationService: IAuthenticationService
	{
		private readonly IFieldsValidator validator;
		private readonly IAuthenticationProcess authProcess;
		private readonly IFinishAuthentication finishAuth;

		public AuthenticationService()
		{
			validator = ServiceLocator.Get<IFieldsValidator>();
			authProcess = ServiceLocator.Get<IAuthenticationProcess>();
			finishAuth = ServiceLocator.Get<IFinishAuthentication>();
		}

		public object Authenticate(string userName, string password)
		{
			validator.SetNext(authProcess).SetNext(finishAuth);

			var formToRedirect = validator.Handle(new User() { UserName = userName.Trim(), 
				Password = password.Trim() }, false);

			return formToRedirect;
		}

		public object Register(string userName, string password, string firstName, string lastName)
		{
			validator.SetNext(authProcess).SetNext(finishAuth);

			var formToRedirect = validator.Handle(new User() { UserName = userName.Trim(), 
				FirstName = firstName.Trim(), 
				LastName = lastName.Trim(), 
				Password = password.Trim() }, true);

			return formToRedirect;
		}
	}
}