using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Model.Enums;
using SignItNow.Services.Interfaces;

namespace SignItNow.Services
{
	public class UpdateUserService: IUpdateUserService
	{
		private readonly IFieldsValidator validator;
		private readonly IUpdateUserProcess updateProcess;
		private readonly IFinishAuthentication finishAuth;

		public UpdateUserService()
		{
			validator = ServiceLocator.Get<IFieldsValidator>();
			updateProcess = ServiceLocator.Get<IUpdateUserProcess>();
			finishAuth = ServiceLocator.Get<IFinishAuthentication>();
		}

		public object Update(string userName, string password, string firstName, string lastName)
		{
			validator.SetNext(updateProcess).SetNext(finishAuth);

			return (FormType) validator.Handle(new User()
				{UserName = userName, FirstName = firstName, LastName = lastName, Password = password}, true);
		}
	}
}