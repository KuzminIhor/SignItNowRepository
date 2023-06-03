using System;

namespace SignItNow.Model.Exceptions
{
	[Serializable]
	public class UserModifyException: Exception
	{
		public UserModifyException()
		{

		}

		public UserModifyException(string message)
			: base(message)
		{

		}
	}
}