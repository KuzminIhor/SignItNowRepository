using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class LeaveCommentProcess: AbstractTaskHandler, ILeaveCommentProcess
	{
		private ITaskSignerRepository taskSignerRepository;

		public LeaveCommentProcess()
		{
			taskSignerRepository = ServiceLocator.Get<ITaskSignerRepository>();
		}

		public object Handle(int taskId, int userId, string comment)
		{
			Execute(taskId, userId, comment);

			return base.Handle(taskId, userId, comment);
		}

		public void Execute(int taskId, int userId, string comment)
		{
			taskSignerRepository.AddCommentForTask(taskId, userId, comment);
		}
	}
}