using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Services.Interfaces;

namespace SignItNow.Services
{
	public class UploadDocumentService: IUploadDocumentService
	{
		private IDocumentValidator documentValidator;
		private IDeleteFileHelper deleteFileHelper;
		private IUploadTempDocument uploadTempDocument;

		public UploadDocumentService()
		{
			documentValidator = ServiceLocator.Get<IDocumentValidator>();
			deleteFileHelper = ServiceLocator.Get<IDeleteFileHelper>();
			uploadTempDocument = ServiceLocator.Get<IUploadTempDocument>();
		}

		public void UploadTempDocument(string filePath)
		{
			documentValidator.SetNext(deleteFileHelper).SetNext(uploadTempDocument);

			documentValidator.Handle(filePath);
		}
	}
}