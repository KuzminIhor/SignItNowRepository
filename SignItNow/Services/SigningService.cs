using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model.Enums;
using SignItNow.Model.Exceptions;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Services
{
	public class SigningService: ISigningService
	{
		private ICommentValidator commentValidator;
		private ILeaveCommentProcess leaveCommentProcess;
		private IVisualizeSignatureProcess visualizeSignatureProcess;
		private ISignTaskProcess signTaskProcess;
		private IRejectTaskProcess rejectTaskProcess;
		private ICheckSigningStatuses checkSigningStatuses;

		public SigningService()
		{
			commentValidator = ServiceLocator.Get<ICommentValidator>();
			leaveCommentProcess = ServiceLocator.Get<ILeaveCommentProcess>();
			visualizeSignatureProcess = ServiceLocator.Get<IVisualizeSignatureProcess>();
			signTaskProcess = ServiceLocator.Get<ISignTaskProcess>();
			rejectTaskProcess = ServiceLocator.Get<IRejectTaskProcess>();
			checkSigningStatuses = ServiceLocator.Get<ICheckSigningStatuses>();
		}

		public void Sign(int taskId, int userId, bool isCommenting, string comment)
		{
			var status = checkSigningStatuses.CheckTaskStatus(taskId);

			if (status == TaskStatus.Забраковано)
			{
				throw new SigningTaskException("Задача забракована!");
			}
			else if (status == TaskStatus.Відмовлено)
			{
				throw new SigningTaskException("Задача відмовлена у підписі!");
			}

			if (isCommenting)
			{ 
				commentValidator.SetNext(leaveCommentProcess);
				commentValidator.Handle(taskId, userId, comment);
			}

			if (Program.VisualizeSignature)
			{
				visualizeSignatureProcess.Handle(taskId, userId, comment);
			}

			signTaskProcess.SetNext(checkSigningStatuses);
			signTaskProcess.Handle(taskId, userId, comment);
		}

		public void Reject(int taskId, int userId, bool isCommenting, string comment)
		{
			var status = checkSigningStatuses.CheckTaskStatus(taskId);

			if (status == TaskStatus.Забраковано)
			{
				throw new SigningTaskException("Задача забракована!");
			}
			else if (status == TaskStatus.Відмовлено)
			{
				throw new SigningTaskException("Задача відмовлена у підписі!");
			}

			if (isCommenting)
			{
				commentValidator.SetNext(leaveCommentProcess).SetNext(rejectTaskProcess).SetNext(checkSigningStatuses);
				commentValidator.Handle(taskId, userId, comment);
			}
			else
			{
				rejectTaskProcess.SetNext(checkSigningStatuses);
				rejectTaskProcess.Handle(taskId, userId, comment);
			}
		}
	}
}