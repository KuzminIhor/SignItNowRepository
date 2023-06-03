namespace SignItNow.Helpers.Interfaces
{
	public interface ICommentValidator: ITaskHandler
	{
		public void Validate(string comment);
	}
}