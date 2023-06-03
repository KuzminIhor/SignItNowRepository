using System.Linq;
using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class FindSignerHelper: IFindSignerHelper
	{
		private IUserRepository userRepository;
		private IUserRoleRepository userRoleRepository;
		private IEncryptorDecryptor encryptorDecryptor;

		public FindSignerHelper()
		{
			userRepository = ServiceLocator.Get<IUserRepository>();
			userRoleRepository = ServiceLocator.Get<IUserRoleRepository>();
			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();
		}

		public bool DoesSignerExist(string userName, string firstName, string lastName)
		{
			var userInDB = userRepository.GetUser(userName);

			if (userInDB == null)
			{
				return false;
			}

			if (!encryptorDecryptor.Decrypt(userInDB.FirstName).Equals(firstName) ||
			    !encryptorDecryptor.Decrypt(userInDB.LastName).Equals(lastName))
			{
				return false;
			}

			var userRoles = userRoleRepository.GetUserRoles(userInDB.Id);

			if (userRoles.FirstOrDefault(ur => ur.Role.Name.Equals(nameof(RoleName.Signer))) == null)
			{
				return false;
			}

			return true;
		}
	}
}