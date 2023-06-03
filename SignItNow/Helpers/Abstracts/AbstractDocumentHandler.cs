using SignItNow.Helpers.Interfaces;
using SignItNow.Model;

namespace SignItNow.Helpers.Abstracts
{
	public class AbstractDocumentHandler: IDocumentHandler
	{
		private IDocumentHandler _nextHandler;

		public IDocumentHandler SetNext(IDocumentHandler handler)
		{
			_nextHandler = handler;
			return handler;
		}

		public virtual object Handle(string uploadedFileName)
		{
			object result = null;

			if (_nextHandler != null)
			{
				result = _nextHandler.Handle(uploadedFileName);
			}

			return result;
		}
	}
}