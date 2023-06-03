using SignItNow.Model;

namespace SignItNow.Helpers.Interfaces
{
	public interface IUpdateUserProcess: IAuthenticationHandler
	{
		public void Update(User user);
	}
}