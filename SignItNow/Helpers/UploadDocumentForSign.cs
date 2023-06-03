using System.Collections.Generic;
using System.IO;
using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Model;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Helpers
{
	public class UploadDocumentForSign: AbstractTaskHandler, IUploadDocumentForSign
	{
		private ITaskInfoRepository taskInfoRepository;

		public UploadDocumentForSign()
		{
			taskInfoRepository = ServiceLocator.Get<ITaskInfoRepository>();
		}

		public override object Handle(string taskName, List<User> signers)
		{
			Upload(taskName);

			return base.Handle(taskName, signers);
		}

		public void Upload(string taskName)
		{
			var sourcePath = Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, $"{Program.UserId.Value}.pdf");

			var taskInfo = taskInfoRepository.GetTaskInfo(taskName, Program.UserId.Value);

			var destinationPath = Path.Combine(Program.BaseFilePath, Program.UploadedDocsFolder, taskInfo.Document.Name);

			File.Move(sourcePath, destinationPath);
		}
	}
}