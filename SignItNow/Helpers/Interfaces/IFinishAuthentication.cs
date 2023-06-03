using SignItNow.Model.Enums;

namespace SignItNow.Helpers.Interfaces
{
	public interface IFinishAuthentication: IAuthenticationHandler
	{
		public FormType GetFormToRedirect(string userName);
	}
}