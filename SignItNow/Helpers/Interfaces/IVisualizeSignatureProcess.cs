namespace SignItNow.Helpers.Interfaces
{
	public interface IVisualizeSignatureProcess: ITaskHandler
	{
		public void Execute(int taskId, int userId);
	}
}