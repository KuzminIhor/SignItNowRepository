using System.Collections.Generic;
using SignItNow.Model;

namespace SignItNow.Helpers.Interfaces
{
	public interface ITaskElementsValidator: ITaskHandler
	{
		public void ValidateTaskName(string taskName);
		public void ValidateSigners(List<User> signers);
	}
}