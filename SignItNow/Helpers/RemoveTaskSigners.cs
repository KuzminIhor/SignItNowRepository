using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class RemoveTaskSigners: AbstractTaskHandler, IRemoveTaskSigners
	{
		private ITaskSignerRepository taskSignerRepository;

		public RemoveTaskSigners()
		{
			taskSignerRepository = ServiceLocator.Get<ITaskSignerRepository>();
		}

		public object Handle(int taskId, int documentId)
		{
			Remove(taskId);

			return base.Handle(taskId, documentId);
		}

		public void Remove(int taskId)
		{
			taskSignerRepository.RemoveAllSignersForTask(taskId);
		}
	}
}