using SignItNow.Model;

namespace SignItNow.Repositories.Interfaces
{
	public interface IDocumentInfoRepository
	{
		public DocumentInfo AddDocumentInfo();
		public DocumentInfo GetDocumentInfo(int id);
		public DocumentInfo GetDocumentInfo(string name);
		public void Remove(int id);
	}
}