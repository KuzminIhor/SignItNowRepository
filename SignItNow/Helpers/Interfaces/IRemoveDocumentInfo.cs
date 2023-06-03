namespace SignItNow.Helpers.Interfaces
{
	public interface IRemoveDocumentInfo: ITaskHandler
	{
		public void Remove(int documentId);
	}
}