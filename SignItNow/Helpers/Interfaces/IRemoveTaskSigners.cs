namespace SignItNow.Helpers.Interfaces
{
	public interface IRemoveTaskSigners: ITaskHandler
	{
		public void Remove(int taskId);
	}
}