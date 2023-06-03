using System.Collections.Generic;
using SignItNow.Model;

namespace SignItNow.Helpers.Interfaces
{
	public interface ICreateTaskProcess: ITaskHandler
	{
		public void CreateTask(string taskName, List<User> signers);
	}
}