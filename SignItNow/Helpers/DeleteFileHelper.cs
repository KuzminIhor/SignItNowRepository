using System.IO;
using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;

namespace SignItNow.Helpers
{
	public class DeleteFileHelper: AbstractDocumentHandler, IDeleteFileHelper
	{
		public override object Handle(string uploadedFileName)
		{
			DeleteExistTempUserDocument();

			return base.Handle(uploadedFileName);
		}

		public void DeleteExistTempUserDocument()
		{
			var destinationFilePath =
				Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + ".pdf");

			if (File.Exists(destinationFilePath))
			{
				File.Delete(destinationFilePath);
			}
		}

		public void DeleteExistPublishedUserDocument(string documentName)
		{
			var destinationFilePath =
				Path.Combine(Program.BaseFilePath, Program.UploadedDocsFolder, documentName);

			if (File.Exists(destinationFilePath))
			{
				File.Delete(destinationFilePath);
			}
		}
	}
}