using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Services.Interfaces;

namespace SignItNow.Services
{
	public class RevokeTaskService: IRevokeTaskService
	{
		private IRemoveTaskSigners removeTaskSigners;
		private IRemoveDocumentInfo removeDocumentInfo;
		private IRevokeTaskStatus updateTaskStatus;
		private IDeleteFileHelper deleteFileHelper;

		public RevokeTaskService()
		{
			removeDocumentInfo = ServiceLocator.Get<IRemoveDocumentInfo>();
			removeTaskSigners = ServiceLocator.Get<IRemoveTaskSigners>();
			updateTaskStatus = ServiceLocator.Get<IRevokeTaskStatus>();
			deleteFileHelper = ServiceLocator.Get<IDeleteFileHelper>();
		}

		public void Revoke(int taskId, int documentId, string documentName)
		{
			removeTaskSigners.SetNext(updateTaskStatus).SetNext(removeDocumentInfo);

			removeTaskSigners.Handle(taskId, documentId);

			deleteFileHelper.DeleteExistPublishedUserDocument(documentName);
		}
	}
}