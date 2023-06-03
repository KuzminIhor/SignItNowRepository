namespace SignItNow.Helpers.Interfaces
{
	public interface ILeaveCommentProcess: ITaskHandler
	{
		public void Execute(int taskId, int userId, string comment);
	}
}