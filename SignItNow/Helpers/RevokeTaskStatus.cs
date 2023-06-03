using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class RevokeTaskStatus: AbstractTaskHandler, IRevokeTaskStatus
	{
		private ITaskInfoRepository taskInfoRepository;

		public RevokeTaskStatus()
		{
			this.taskInfoRepository = ServiceLocator.Get<ITaskInfoRepository>();
		}

		public object Handle(int taskId, int documentId)
		{
			Revoke(taskId);

			return base.Handle(taskId, documentId);
		}

		public void Revoke(int taskId)
		{
			taskInfoRepository.UpdateTaskStatus(taskId, TaskStatus.Забраковано);
		}
	}
}