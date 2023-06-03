namespace SignItNow.Helpers.Interfaces
{
	public interface IFindSignerHelper
	{
		public bool DoesSignerExist(string userName, string firstName, string lastName);
	}
}