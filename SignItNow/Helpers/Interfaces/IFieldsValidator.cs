namespace SignItNow.Helpers.Interfaces
{
	public interface IFieldsValidator: IAuthenticationHandler
	{
		public void ValidateUserName(string userName);
		public void ValidatePassword(string password);
		public void ValidateFirstName(string firstName);
		public void ValidateLastName(string lastName);
	}
}