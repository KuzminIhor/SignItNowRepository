using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model.Enums;
using SignItNow.Model.Exceptions;

namespace SignItNow.Helpers
{
	public class CommentValidator: AbstractTaskHandler, ICommentValidator
	{
		public object Handle(int taskId, int userId, string comment)
		{
			Validate(comment);

			return base.Handle(taskId, userId, comment);
		}

		public void Validate(string comment)
		{
			if (string.IsNullOrEmpty(comment))
			{
				throw new SigningTaskException("Ви не ввели коментар!");
			}
		}
	}
}