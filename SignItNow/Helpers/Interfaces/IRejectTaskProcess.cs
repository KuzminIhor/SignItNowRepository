namespace SignItNow.Helpers.Interfaces
{
	public interface IRejectTaskProcess: ITaskHandler
	{
		public void Execute(int taskId, int userId);
	}
}