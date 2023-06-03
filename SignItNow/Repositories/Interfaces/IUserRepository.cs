using System.Collections.Generic;
using SignItNow.Model;

namespace SignItNow.Repositories.Interfaces
{
	public interface IUserRepository
	{
		public User GetUser(string username);
		public User GetUser(int userId);
		public List<User> GetUsersCollectionExceptAdmin();
		public bool IsCorrectPassword(int userId, string password);
		public void AddUser(User user);
		public void UpdateUser(User user);
		public void RemoveUsers(params User[] users);
	}
}