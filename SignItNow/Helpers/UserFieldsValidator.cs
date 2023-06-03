using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model.Exceptions;

namespace SignItNow.Helpers
{
	public class UserFieldsValidator: IUserFieldsValidator
	{
		public void ValidateFirstName(string firstName)
		{
			if (string.IsNullOrEmpty(firstName))
			{
				throw new UserModifyException("Ви не ввели ім'я!");
			}
		}

		public void ValidateUserName(string userName)
		{
			if (string.IsNullOrEmpty(userName))
			{
				throw new UserModifyException("Ви не ввели унікальне ім'я!");
			}
		}

		public void ValidateLastName(string lastName)
		{
			if (string.IsNullOrEmpty(lastName))
			{
				throw new UserModifyException("Ви не ввели прізвище!");
			}
		}
	}
}