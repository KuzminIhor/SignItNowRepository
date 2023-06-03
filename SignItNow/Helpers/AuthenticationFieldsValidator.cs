using System.Security.Authentication;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;

namespace SignItNow.Helpers
{
	public class FieldsValidator: AbstractAuthenticationHandler, IFieldsValidator
	{
		public override object Handle(User user, bool isRegistrationOrUpdate)
		{
			ValidateUserName(user.UserName);
			ValidatePassword(user.Password);

			if (isRegistrationOrUpdate)
			{
				ValidateFirstName(user.FirstName);
				ValidateLastName(user.LastName);
			}

			return base.Handle(user, isRegistrationOrUpdate);
		}

		public void ValidateUserName(string userName)
		{
			if (string.IsNullOrEmpty(userName))
			{
				throw new AuthenticationException("Ви не ввели унікальне ім'я!\n");
			}
		}

		public void ValidateFirstName(string firstName)
		{
			if (string.IsNullOrEmpty(firstName))
			{
				throw new AuthenticationException("Ви не ввели ім'я!\n");
			}
		}

		public void ValidateLastName(string lastName)
		{
			if (string.IsNullOrEmpty(lastName))
			{
				throw new AuthenticationException("Ви не ввели прізвище!\n");
			}
		}

		public void ValidatePassword(string password)
		{
			if (string.IsNullOrEmpty(password))
			{
				throw new AuthenticationException("Ви не ввели пароль!\n");
			}
		}
	}
}