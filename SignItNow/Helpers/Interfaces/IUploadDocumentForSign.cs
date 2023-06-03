using SignItNow.Helpers.Interfaces;

namespace SignItNow.Helpers
{
	public interface IUploadDocumentForSign: ITaskHandler
	{
		public void Upload(string taskName);
	}
}