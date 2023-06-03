namespace SignItNow.Services.Interfaces
{
	public interface IUserBannedService
	{
		public bool IsBanned(int userId);
	}
}