using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class UpdateUserProcess: AbstractAuthenticationHandler, IUpdateUserProcess
	{
		private readonly IUserRepository userRepository;
		private readonly IEncryptorDecryptor encryptorDecryptor;

		public UpdateUserProcess()
		{
			userRepository = ServiceLocator.Get<IUserRepository>();
			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();
		}

		public override object Handle(User user, bool isRegistrationOrUpdate)
		{
			Update(user);

			return base.Handle(user, isRegistrationOrUpdate);
		}

		public void Update(User user)
		{
			var userInDB = userRepository.GetUser(Program.UserId.Value);

			userInDB.UserName = encryptorDecryptor.Encrypt(user.UserName);
			userInDB.FirstName = encryptorDecryptor.Encrypt(user.FirstName);
			userInDB.LastName = encryptorDecryptor.Encrypt(user.LastName);
			userInDB.Password = encryptorDecryptor.Encrypt(user.Password);

			userRepository.UpdateUser(userInDB);
		}
	}
}