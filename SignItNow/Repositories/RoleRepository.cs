using System.Linq;
using SignItNow.Core;
using SignItNow.Model;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Repositories
{
	public class RoleRepository: IRoleRepository
	{
		public readonly DBAppContext db;

		public RoleRepository(DBAppContext dbApp)
		{
			this.db = dbApp;
		}

		public Role GetRole(RoleName roleName)
		{
			return db.Roles.FirstOrDefault(r => r.Name.Equals(roleName.ToString()));
		}
	}
}