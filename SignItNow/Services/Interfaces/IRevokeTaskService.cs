namespace SignItNow.Services.Interfaces
{
	public interface IRevokeTaskService
	{
		public void Revoke(int taskId, int documentId, string documentName);
	}
}