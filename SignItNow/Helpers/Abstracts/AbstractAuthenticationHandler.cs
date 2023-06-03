using SignItNow.Helpers.Interfaces;
using SignItNow.Model;

namespace SignItNow.Helpers.Abstracts
{
	public abstract class AbstractAuthenticationHandler: IAuthenticationHandler
	{
		private IAuthenticationHandler _nextHandler;

		public IAuthenticationHandler SetNext(IAuthenticationHandler handler)
		{
			_nextHandler = handler;
			return handler;
		}

		public virtual object Handle(User user, bool isRegistrationOrUpdate)
		{
			object result = null;

			if (_nextHandler != null)
			{
				result = _nextHandler.Handle(user, isRegistrationOrUpdate);
			}

			return result;
		}
	}
}