using System;

namespace SignItNow.Model.Exceptions
{
	[Serializable]
	public class SigningTaskException: Exception
	{
		public SigningTaskException()
		{

		}

		public SigningTaskException(string message)
			: base(message)
		{

		}
	}
}