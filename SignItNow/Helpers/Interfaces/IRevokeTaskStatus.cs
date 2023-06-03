namespace SignItNow.Helpers.Interfaces
{
	public interface IRevokeTaskStatus: ITaskHandler
	{
		public void Revoke(int taskId);
	}
}