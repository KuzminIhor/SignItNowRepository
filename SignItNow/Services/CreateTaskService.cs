using System.Collections.Generic;
using SignItNow.Core;
using SignItNow.Helpers;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Services.Interfaces;

namespace SignItNow.Services
{
	public class CreateTaskService: ICreateTaskService
	{
		private ITaskElementsValidator taskElementsValidator;
		private ICreateTaskProcess createTaskProcess;
		private IUploadDocumentForSign uploadDocumentForSign;

		public CreateTaskService()
		{
			taskElementsValidator = ServiceLocator.Get<ITaskElementsValidator>();
			createTaskProcess = ServiceLocator.Get<ICreateTaskProcess>();
			uploadDocumentForSign = ServiceLocator.Get<IUploadDocumentForSign>();
		}

		public void CreateTask(string taskName, List<User> signers)
		{
			taskElementsValidator.SetNext(createTaskProcess).SetNext(uploadDocumentForSign);

			taskElementsValidator.Handle(taskName, signers);
		}
	}
}