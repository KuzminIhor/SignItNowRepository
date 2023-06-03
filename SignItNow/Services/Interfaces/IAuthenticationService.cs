namespace SignItNow.Services.Interfaces
{
	public interface IAuthenticationService
	{
		public object Authenticate(string userName, string password);
		public object Register(string userName, string password, string firstName, string lastName);
	}
}