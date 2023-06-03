using SignItNow.Model.Enums;

namespace SignItNow.Helpers.Interfaces
{
	public interface ICheckSigningStatuses: ITaskHandler
	{
		public void CheckSigningStatusesForTask(int taskId);
		public TaskStatus CheckTaskStatus(int taskId);
	}
}