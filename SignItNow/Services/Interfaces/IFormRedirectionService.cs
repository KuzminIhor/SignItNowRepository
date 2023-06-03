using System.Windows.Forms;
using SignItNow.Model.Enums;

namespace SignItNow.Services.Interfaces
{
	public interface IFormRedirectionService
	{
		public void Redirect(Form oldForm, FormType newForm);
	}
}