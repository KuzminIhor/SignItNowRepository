namespace SignItNow.Helpers.Interfaces
{
	public interface ISignTaskProcess: ITaskHandler
	{
		public void Execute(int taskId, int userId);
	}
}