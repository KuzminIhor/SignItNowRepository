namespace SignItNow.Helpers.Interfaces
{
	public interface IUploadTempDocument: IDocumentHandler
	{
		public void UploadPDF(string filePath);
		public void UploadWord(string filePath);
		public void UploadExcel(string filePath);
		public void UploadPowerPoint(string filePath);
	}
}