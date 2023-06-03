namespace SignItNow.Helpers.Interfaces
{
	public interface IDocumentValidator: IDocumentHandler
	{
		public void ValidateFileLength(string filePath);
		public void ValidateFileExtention(string filePath);
	}
}