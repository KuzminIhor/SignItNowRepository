using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using SignItNow.Core;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Repositories
{
	public class TaskInfoRepository : ITaskInfoRepository
	{
		private DBAppContext db;
		private IUserRepository userRepository;
		private IDocumentInfoRepository documentInfoRepository;
		private ITaskSignerRepository taskSignerRepository;
		private IEncryptorDecryptor encryptorDecryptor;

		public TaskInfoRepository()
		{
			userRepository = ServiceLocator.Get<IUserRepository>();
			documentInfoRepository = ServiceLocator.Get<IDocumentInfoRepository>();
			taskSignerRepository = ServiceLocator.Get<ITaskSignerRepository>();

			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();

			db = ServiceLocator.Get<DBAppContext>();
		}

		public void AddTaskInfo(string taskName, DocumentInfo documentInfo, List<User> signers)
		{
			var creator = userRepository.GetUser(Program.UserId.Value);

			var taskInfo = new TaskInfo()
			{
				Document = documentInfo,
				Name = encryptorDecryptor.Encrypt(taskName),
				TaskCreator = creator
			};

			foreach (var signer in signers)
			{
				var signerInDB = userRepository.GetUser(signer.UserName);

				var taskSigner = new TaskSigner()
				{
					Signer = signerInDB
				};

				taskInfo.Signers.Add(taskSigner);
			}

			db.TaskInfos.Add(taskInfo);
			db.SaveChanges();
		}

		public TaskInfo GetTaskInfo(string taskName, int creatorId)
		{
			return db.TaskInfos.Include(t => t.Document).Include(t => t.TaskCreator).LastOrDefault(delegate(TaskInfo t)
			{
				var decryptedTaskName = encryptorDecryptor.Decrypt(t.Name);

				return decryptedTaskName.Equals(taskName) && t.TaskCreator.Id == creatorId;
			});
		}

		public TaskInfo GetTaskInfo(int taskId)
		{
			return db.TaskInfos.Include(t => t.Document).Include(t => t.TaskCreator).FirstOrDefault(t => t.Id == taskId);
		}

		public List<TaskInfo> GetAllTasks()
		{
			var tasks = db.TaskInfos.Include(t => t.Document).Include(t => t.TaskCreator).Include(t => t.Signers)
				.ThenInclude(ts => ts.Signer).ToList();

			var decryptedTasks = new List<TaskInfo>();

			foreach (var task in tasks)
			{
				var clonedTask = task.Clone();

				clonedTask.Name = encryptorDecryptor.Decrypt(task.Name);

				if (clonedTask.TaskStatus != TaskStatus.Забраковано)
				{
					var decryptedDocumentInfo = documentInfoRepository.GetDocumentInfo(clonedTask.Document.Id);
					var decryptedTaskSigners = taskSignerRepository.GetTaskSigners(clonedTask.Id);

					clonedTask.Document = decryptedDocumentInfo;
					clonedTask.Signers = decryptedTaskSigners;
				}

				decryptedTasks.Add(clonedTask);
			}

			return decryptedTasks;
		}

		public List<TaskInfo> GetCreatedTasks(int creatorId)
		{
			var tasks = db.TaskInfos.Include(t => t.Document).Include(t => t.TaskCreator).Include(t => t.Signers)
				.ThenInclude(ts => ts.Signer).Where(t => t.TaskCreator.Id == creatorId).ToList();

			var decryptedTasks = new List<TaskInfo>();

			foreach (var task in tasks)
			{
				var clonedTask = task.Clone();

				clonedTask.Name = encryptorDecryptor.Decrypt(task.Name);

				if (clonedTask.TaskStatus != TaskStatus.Забраковано)
				{
					var decryptedDocumentInfo = documentInfoRepository.GetDocumentInfo(clonedTask.Document.Id);
					var decryptedTaskSigners = taskSignerRepository.GetTaskSigners(clonedTask.Id);

					clonedTask.Document = decryptedDocumentInfo;
					clonedTask.Signers = decryptedTaskSigners;
				}

				decryptedTasks.Add(clonedTask);
			}

			return decryptedTasks;
		}

		public List<TaskInfo> GetIncommingTasks(int signerId)
		{
			var tasks = db.TaskInfos
				.Include(t => t.Document)
				.Include(t => t.TaskCreator)
				.Include(t => t.Signers)
					.ThenInclude(ts => ts.Signer)
				.Where(t => t.TaskStatus == TaskStatus.Обробляється
				            && t.Signers.Any(ts => ts.Signer.Id == signerId
												&& ts.SigningStatus == SigningStatus.Очікується))
				.ToList();

			var decryptedTasks = new List<TaskInfo>();

			foreach (var task in tasks)
			{
				var clonedTask = task.Clone();

				clonedTask.Name = task.Name;

				clonedTask.TaskCreator.FirstName = task.TaskCreator.FirstName;
				clonedTask.TaskCreator.LastName = task.TaskCreator.LastName;

				var decryptedDocumentInfo = documentInfoRepository.GetDocumentInfo(clonedTask.Document.Id);
				var decryptedTaskSigners = taskSignerRepository.GetTaskSigners(clonedTask.Id);

				clonedTask.Document = decryptedDocumentInfo;
				clonedTask.Signers = decryptedTaskSigners;

				decryptedTasks.Add(clonedTask);
			}

			return decryptedTasks;
		}

		public List<TaskInfo> GetCompletedTasks(int signerId)
		{
			var tasks = db.TaskInfos
				.Include(t => t.Document)
				.Include(t => t.TaskCreator)
				.Include(t => t.Signers)
				.ThenInclude(ts => ts.Signer)
				.Where(t => t.Signers.Any(ts => ts.Signer.Id == signerId
					&& (ts.SigningStatus == SigningStatus.Відхилено ||
					    ts.SigningStatus == SigningStatus.Підписано)))
				.ToList();

			var decryptedTasks = new List<TaskInfo>();

			foreach (var task in tasks)
			{
				var clonedTask = task.Clone();

				clonedTask.Name = task.Name;

				clonedTask.TaskCreator.FirstName = task.TaskCreator.FirstName;
				clonedTask.TaskCreator.LastName = task.TaskCreator.LastName;

				var decryptedDocumentInfo = documentInfoRepository.GetDocumentInfo(clonedTask.Document.Id);
				var decryptedTaskSigners = taskSignerRepository.GetTaskSigners(clonedTask.Id);

				clonedTask.Document = decryptedDocumentInfo;
				clonedTask.Signers = decryptedTaskSigners;

				decryptedTasks.Add(clonedTask);
			}

			return decryptedTasks;
		}

		public void UpdateTaskStatus(int taskId, TaskStatus status)
		{
			var taskInDB = db.TaskInfos.Include(t => t.Document).Include(t => t.Signers).ThenInclude(ts => ts.Signer).FirstOrDefault(t => t.Id == taskId);

			taskInDB.TaskStatus = status;

			db.TaskInfos.Update(taskInDB);
			db.SaveChanges();
		}

		public TaskStatus GetTaskStatus(int taskId)
		{
			return db.TaskInfos.FirstOrDefault(t => t.Id == taskId).TaskStatus;
		}
	}
}