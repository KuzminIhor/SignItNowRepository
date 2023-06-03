using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SignItNow.Core;
using SignItNow.Model;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Repositories
{
	public class UserRoleRepository : IUserRoleRepository
	{
		public readonly DBAppContext db;

		public UserRoleRepository(DBAppContext dbApp)
		{
			this.db = dbApp;
		}

		public List<UserRole> GetUserRoles(int userId)
		{
			return db.UserRoles
				.Include(ur => ur.Role)
				.Include(ur => ur.User)
				.Where(ur => ur.User.Id == userId)
				.ToList();
		}
	}
}