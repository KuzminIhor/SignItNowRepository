using System;
using System.IO;
using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;

namespace SignItNow.Helpers
{
	public class DocumentValidator: AbstractDocumentHandler, IDocumentValidator
	{
		public override object Handle(string uploadedFileName)
		{
			ValidateFileLength(uploadedFileName);
			ValidateFileExtention(uploadedFileName);

			return base.Handle(uploadedFileName);
		}

		public void ValidateFileLength(string filePath)
		{
			if (new FileInfo(filePath).Length < 0)
			{
				throw new FileLoadException("Документ не може бути пустим!");
			}
		}

		public void ValidateFileExtention(string filePath)
		{
			if (!Program.AvailableFileExtentions.Contains(new FileInfo(filePath).Extension))
			{
				throw new FileLoadException("Даний файл не може бути завантаженим!");
			}
		}
	}
}