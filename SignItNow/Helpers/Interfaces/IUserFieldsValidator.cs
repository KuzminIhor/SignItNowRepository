namespace SignItNow.Helpers.Interfaces
{
	public interface IUserFieldsValidator
	{
		public void ValidateFirstName(string firstName);
		public void ValidateUserName(string userName);
		public void ValidateLastName(string lastName);
	}
}