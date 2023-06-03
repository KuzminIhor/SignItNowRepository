namespace SignItNow.Helpers.Interfaces
{
	public interface IDeleteFileHelper: IDocumentHandler
	{
		public void DeleteExistTempUserDocument();
		public void DeleteExistPublishedUserDocument(string documentName);
	}
}