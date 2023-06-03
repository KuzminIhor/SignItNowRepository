using System.Collections.Generic;
using SignItNow.Model;
using SignItNow.Model.Enums;

namespace SignItNow.Repositories.Interfaces
{
	public interface ITaskInfoRepository
	{
		public void AddTaskInfo(string taskName, DocumentInfo documentInfo, List<User> signers);
		public TaskInfo GetTaskInfo(string taskName, int creatorId);
		public TaskInfo GetTaskInfo(int taskId);
		public List<TaskInfo> GetAllTasks();
		public List<TaskInfo> GetCreatedTasks(int creatorId);
		public List<TaskInfo> GetIncommingTasks(int signerId);
		public List<TaskInfo> GetCompletedTasks(int signerId);
		public void UpdateTaskStatus(int taskId, TaskStatus status);
		public TaskStatus GetTaskStatus(int taskId);
	}
}