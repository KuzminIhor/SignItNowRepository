namespace SignItNow.Services.Interfaces
{
	public interface IUpdateUserService
	{
		public object Update(string userName, string password, string firstName, string lastName);
	}
}