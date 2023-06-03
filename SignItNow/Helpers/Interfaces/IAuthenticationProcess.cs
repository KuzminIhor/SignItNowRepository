using SignItNow.Model;

namespace SignItNow.Helpers.Interfaces
{
	public interface IAuthenticationProcess: IAuthenticationHandler
	{
		public void Authenticate(string userName, string password);
		public void Register(User user);
	}
}