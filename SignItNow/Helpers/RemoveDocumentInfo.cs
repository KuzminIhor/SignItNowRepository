using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class RemoveDocumentInfo: AbstractTaskHandler, IRemoveDocumentInfo
	{
		private IDocumentInfoRepository documentInfoRepository;

		public RemoveDocumentInfo()
		{
			documentInfoRepository = ServiceLocator.Get<IDocumentInfoRepository>();
		}

		public object Handle(int taskId, int documentId)
		{
			Remove(documentId);

			return base.Handle(taskId, documentId);
		}

		public void Remove(int documentId)
		{
			documentInfoRepository.Remove(documentId);
		}
	}
}