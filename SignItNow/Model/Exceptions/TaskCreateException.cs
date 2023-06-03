using System;

namespace SignItNow.Model.Exceptions
{
	[Serializable]
	public class TaskCreateException: Exception
	{
		public TaskCreateException()
		{

		}

		public TaskCreateException(string message)
			: base(message)
		{

		}
	}
}