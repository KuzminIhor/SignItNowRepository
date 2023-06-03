using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Repositories
{
	public class TaskSignerRepository : ITaskSignerRepository
	{
		private DBAppContext db;

		private IEncryptorDecryptor encryptorDecryptor;

		public TaskSignerRepository()
		{
			db = ServiceLocator.Get<DBAppContext>();

			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();
		}

		public List<TaskSigner> GetTaskSigners(int taskId)
		{
			var taskSigners = db.TaskSigners.Include(ts => ts.Signer).Include(ts => ts.Task)
				.Where(ts => ts.Task.Id == taskId).ToList();

			/*var decryptedTaskSigners = new List<TaskSigner>();

			foreach (var taskSigner in taskSigners)
			{
				var decryptedSigner = new User()
				{
					Id = taskSigner.Signer.Id,
					UserName = taskSigner.Signer.UserName,
					FirstName = taskSigner.Signer.FirstName,
					LastName = taskSigner.Signer.LastName
				};

				var decryptedTaskSigner = taskSigner.Clone();
				decryptedTaskSigner.Signer = decryptedSigner;

				decryptedTaskSigners.Add(decryptedTaskSigner);
			}*/

			return taskSigners;
		}

		public void RemoveAllSignersForTask(int taskId)
		{
			var taskSignersInDB = db.TaskSigners.Include(ts => ts.Signer).Include(ts => ts.Task)
				.Where(ts => ts.Task.Id == taskId).ToList();

			db.RemoveRange(taskSignersInDB);
			db.SaveChanges();
		}

		public void UpdateSigningStatus(int taskId, int userId, SigningStatus signingStatus)
		{
			var taskSignersInDB = db.TaskSigners.Include(ts => ts.Signer).Include(ts => ts.Task)
				.FirstOrDefault(ts => ts.Task.Id == taskId && ts.Signer.Id == userId);

			taskSignersInDB.SigningStatus = signingStatus;

			db.TaskSigners.Update(taskSignersInDB);
			db.SaveChanges();
		}

		public void AddCommentForTask(int taskId, int userId, string comment)
		{
			var taskSignersInDB = db.TaskSigners.Include(ts => ts.Signer).Include(ts => ts.Task)
				.FirstOrDefault(ts => ts.Task.Id == taskId && ts.Signer.Id == userId);

			taskSignersInDB.TaskComment = encryptorDecryptor.Encrypt(comment);

			db.TaskSigners.Update(taskSignersInDB);
			db.SaveChanges();
		}

		public List<SigningStatus> GetSigningStatuses(int taskId)
		{
			var signingStatuses = db.TaskSigners.Include(tas => tas.Task).Where(ts => ts.Task.Id == taskId)
				.Select(ts => ts.SigningStatus).ToList();

			return signingStatuses;
		}
	}
}