using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using SignItNow.Model;
using SignItNow.Model.Enums;

namespace SignItNow.Helpers.Interfaces
{
	public interface ITaskHandler
	{
		public ITaskHandler SetNext(ITaskHandler handler);
		public object Handle(string taskName, List<User> signers);
		public object Handle(int taskId, int documentId);
		public object Handle(int taskId, int userId, string comment);
	}
}