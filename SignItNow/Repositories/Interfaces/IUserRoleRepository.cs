using System.Collections.Generic;
using SignItNow.Model;

namespace SignItNow.Repositories.Interfaces
{
	public interface IUserRoleRepository
	{
		public List<UserRole> GetUserRoles(int userId);
	}
}