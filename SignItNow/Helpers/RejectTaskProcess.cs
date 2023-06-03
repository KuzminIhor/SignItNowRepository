using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class RejectTaskProcess: AbstractTaskHandler, IRejectTaskProcess
	{
		private ITaskSignerRepository taskSignerRepository;

		public RejectTaskProcess()
		{
			taskSignerRepository = ServiceLocator.Get<ITaskSignerRepository>();
		}

		public object Handle(int taskId, int userId, string comment)
		{
			Execute(taskId, userId);

			return base.Handle(taskId, userId, comment);
		}

		public void Execute(int taskId, int userId)
		{
			taskSignerRepository.UpdateSigningStatus(taskId, userId, SigningStatus.Відхилено);
		}
	}
}