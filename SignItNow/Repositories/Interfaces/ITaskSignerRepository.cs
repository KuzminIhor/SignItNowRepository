using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using SignItNow.Model;
using SignItNow.Model.Enums;

namespace SignItNow.Repositories.Interfaces
{
	public interface ITaskSignerRepository
	{
		public List<TaskSigner> GetTaskSigners(int taskId);
		public void RemoveAllSignersForTask(int taskId);
		public void UpdateSigningStatus(int taskId, int userId, SigningStatus signingStatus);
		public void AddCommentForTask(int taskId, int userId, string comment);
		public List<SigningStatus> GetSigningStatuses(int taskId);
	}
}