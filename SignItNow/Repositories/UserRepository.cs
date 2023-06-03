using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Repositories
{
	public class UserRepository: IUserRepository
	{
		public readonly DBAppContext db;

		private IEncryptorDecryptor encryptorDecryptor;

		public UserRepository(DBAppContext dbApp)
		{
			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();

			this.db = dbApp;
		}

		public User GetUser(string username)
		{
			return db.Users.FirstOrDefault(delegate(User u)
			{
				var decryptedUserName = encryptorDecryptor.Decrypt(u.UserName);
				return decryptedUserName.Equals(username);
			});
		}

		public User GetUser(int userId)
		{
			return db.Users.ToList().FirstOrDefault(p => p.Id == userId);
		}

		public List<User> GetUsersCollectionExceptAdmin()
		{
			return db.Users.Include(u => u.CreatedTasks).Include(u => u.UserRoles).Include(u => u.SigningTasks)
				.Where(u => u.Id > 1).ToList();
		}

		public bool IsCorrectPassword(int userId, string password)
		{
			var user = db.Users.FirstOrDefault(u => u.Id == userId);
			var decryptedPassword = encryptorDecryptor.Decrypt(user.Password);
			return decryptedPassword.Equals(password);
		}

		public void AddUser(User user)
		{
			var hashedUser = new User()
			{
				UserName = encryptorDecryptor.Encrypt(user.UserName),
				Password = encryptorDecryptor.Encrypt(user.Password),
				FirstName = encryptorDecryptor.Encrypt(user.FirstName),
				LastName = encryptorDecryptor.Encrypt(user.LastName),
				UserRoles = user.UserRoles
			};

			hashedUser.Metadata.Add("isBanned", "false");

			db.Users.Add(hashedUser);
			db.SaveChanges();
		}

		public void UpdateUser(User user)
		{
			db.Users.Update(user);
			db.SaveChanges();
		}

		public void RemoveUsers(params User[] users)
		{
			db.Users.RemoveRange(users);
			db.SaveChanges();
		}
	}
}