using System;
using SignItNow.Core;
using SignItNow.Repositories.Interfaces;
using SignItNow.Services.Interfaces;

namespace SignItNow.Services
{
	public class UserBannedService: IUserBannedService
	{
		private IUserRepository userRepository;

		public UserBannedService()
		{
			userRepository = ServiceLocator.Get<IUserRepository>();
		}

		public bool IsBanned(int userId)
		{
			var user = userRepository.GetUser(userId);

			user.Metadata.TryGetValue("isBanned", out string result);

			return Convert.ToBoolean(result);
		}
	}
}