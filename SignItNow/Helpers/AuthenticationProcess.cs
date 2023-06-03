using System.Collections.Generic;
using System.Security.Authentication;
using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class AuthenticationProcess: AbstractAuthenticationHandler, IAuthenticationProcess
	{
		private readonly IUserRepository userRepository;
		private readonly IRoleRepository roleRepository;
		private readonly IUserRoleRepository userRoleRepository;

		public AuthenticationProcess()
		{
			userRepository = ServiceLocator.Get<IUserRepository>();
			roleRepository = ServiceLocator.Get<IRoleRepository>();
			userRoleRepository = ServiceLocator.Get<IUserRoleRepository>();
		}

		public override object Handle(User user, bool isRegistrationOrUpdate)
		{
			if (isRegistrationOrUpdate)
			{
				Register(user);
			}
			else
			{
				Authenticate(user.UserName, user.Password);
			}

			return base.Handle(user, isRegistrationOrUpdate);
		}

		public void Authenticate(string userName, string password)
		{
			User user = userRepository.GetUser(userName);
				
			if (user == null)
			{
				throw new AuthenticationException("Такого користувача не існує!\n");
			}

			if (!userRepository.IsCorrectPassword(user.Id, password))
			{
				throw new AuthenticationException("Пароль не є вірним!\n");
			}

			Program.UserId = user.Id;
		}

		public void Register(User user)
		{
			var userFromDatabase = userRepository.GetUser(user.UserName);

			if (userFromDatabase != null)
			{
				throw new AuthenticationException("Користувач з даним\nунікальним іменем вже існує!\n");
			}
			
			var signRole = roleRepository.GetRole(RoleName.Signer);
			var creatorRole = roleRepository.GetRole(RoleName.SignCreator);

			user.UserRoles.AddRange(new List<UserRole>()
			{
				new UserRole() {Role = signRole, User = user},
				new UserRole() {Role = creatorRole, User = user}
			});

			userRepository.AddUser(user);

			var userInDB = userRepository.GetUser(user.UserName);

			Program.UserId = userInDB.Id;
		}
	}
}