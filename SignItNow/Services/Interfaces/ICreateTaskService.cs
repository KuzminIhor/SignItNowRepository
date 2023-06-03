using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using SignItNow.Model;

namespace SignItNow.Services.Interfaces
{
	public interface ICreateTaskService
	{
		public void CreateTask(string taskName, List<User> signers);
	}
}