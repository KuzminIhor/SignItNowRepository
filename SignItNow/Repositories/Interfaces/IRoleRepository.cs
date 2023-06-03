using SignItNow.Model;
using SignItNow.Model.Enums;

namespace SignItNow.Repositories.Interfaces
{
	public interface IRoleRepository
	{
		public Role GetRole(RoleName roleName);
	}
}