using SignItNow.Model;

namespace SignItNow.Helpers.Interfaces
{
	public interface IAuthenticationHandler
	{
		public IAuthenticationHandler SetNext(IAuthenticationHandler handler);
		public object Handle(User user, bool isRegistrationOrUpdate);
	}
}