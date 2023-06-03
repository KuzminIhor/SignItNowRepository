namespace SignItNow.Repositories.Interfaces
{
	public interface ISigningService
	{
		public void Sign(int taskId, int userId, bool isCommenting, string comment);
		public void Reject(int taskId, int userId, bool isCommenting, string comment);
	}
}