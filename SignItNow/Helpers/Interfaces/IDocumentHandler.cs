namespace SignItNow.Helpers.Interfaces
{
	public interface IDocumentHandler
	{
		public IDocumentHandler SetNext(IDocumentHandler handler);
		public object Handle(string uploadedFileName);
	}
}