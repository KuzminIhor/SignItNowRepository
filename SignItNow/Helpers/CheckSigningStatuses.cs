using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class CheckSigningStatuses: AbstractTaskHandler, ICheckSigningStatuses
	{
		private ITaskSignerRepository taskSignerRepository;
		private ITaskInfoRepository taskInfoRepository;

		public CheckSigningStatuses()
		{
			taskSignerRepository = ServiceLocator.Get<ITaskSignerRepository>();
			taskInfoRepository = ServiceLocator.Get<ITaskInfoRepository>();
		}

		public object Handle(int taskId, int userId, string comment)
		{
			CheckSigningStatusesForTask(taskId);

			return base.Handle(taskId, userId, comment);
		}

		public void CheckSigningStatusesForTask(int taskId)
		{
			var statuses = taskSignerRepository.GetSigningStatuses(taskId);

			if (statuses.Any(s => s == SigningStatus.Відхилено))
			{
				taskInfoRepository.UpdateTaskStatus(taskId, TaskStatus.Відмовлено);
			} 
			else if (statuses.All(s => s == SigningStatus.Підписано))
			{
				taskInfoRepository.UpdateTaskStatus(taskId, TaskStatus.Підписано);
			}
		}

		public TaskStatus CheckTaskStatus(int taskId)
		{
			return taskInfoRepository.GetTaskStatus(taskId);
		}
	}
}