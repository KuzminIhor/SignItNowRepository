using System.Collections.Generic;
using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class CreateTaskProcess: AbstractTaskHandler, ICreateTaskProcess
	{
		private IDocumentInfoRepository documentInfoRepository;
		private ITaskInfoRepository taskInfoRepository;

		public CreateTaskProcess()
		{
			documentInfoRepository = ServiceLocator.Get<IDocumentInfoRepository>();
			taskInfoRepository = ServiceLocator.Get<ITaskInfoRepository>();
		}

		public override object Handle(string taskName, List<User> signers)
		{
			CreateTask(taskName, signers);

			return base.Handle(taskName, signers);
		}

		public void CreateTask(string taskName, List<User> signers)
		{
			var documentInfo = documentInfoRepository.AddDocumentInfo();

			taskInfoRepository.AddTaskInfo(taskName, documentInfo, signers);
		}
	}
}