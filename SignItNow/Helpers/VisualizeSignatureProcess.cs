using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using SignItNow.Model.Enums;
using SignItNow.Repositories.Interfaces;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.General.Find;
using Spire.Pdf.Graphics;
using Path = System.IO.Path;
using PdfDocument = Spire.Pdf.PdfDocument;

namespace SignItNow.Helpers
{
	public class VisualizeSignatureProcess : AbstractTaskHandler, IVisualizeSignatureProcess
	{
		private IUserRepository userRepository;
		private ITaskInfoRepository taskInfoRepository;

		private IEncryptorDecryptor encryptorDecryptor;

		public VisualizeSignatureProcess()
		{
			userRepository = ServiceLocator.Get<IUserRepository>();
			taskInfoRepository = ServiceLocator.Get<ITaskInfoRepository>();

			encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();
		}

		public object Handle(int taskId, int userId, string comment)
		{
			Execute(taskId, userId);

			Thread.Sleep(500);

			return base.Handle(taskId, userId, comment);
		}

		public void Execute(int taskId, int userId)
		{
			var user = userRepository.GetUser(userId);
			var taskInfo = taskInfoRepository.GetTaskInfo(taskId);

			var filePath = Path.Combine(Program.BaseFilePath, Program.UploadedDocsFolder, taskInfo.Document.Name);

			var encryptorDecryptor = ServiceLocator.Get<IEncryptorDecryptor>();

			var signatureText =
				$"Signed by {encryptorDecryptor.Decrypt(user.FirstName)} {encryptorDecryptor.Decrypt(user.LastName)}";

			//for (int i = 1; i < 15; i++)
			//{
			//string tempFilePath = Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Guid.NewGuid() + "_temp.pdf");
			string tempFilePath = Path.Combine(Program.BaseFilePath, Program.TempDocsFolder,
				Guid.NewGuid() + "_temp.pdf");

			// Load the existing PDF document
			Spire.Pdf.PdfDocument document = new Spire.Pdf.PdfDocument();
			document.LoadFromFile(filePath);

			// Find the location of "Signatures:" text
			(PdfPageBase page, int pageNumber) = FindSignaturesTextPage(document, "Signatures:");
			if (page == null)
			{
				// "Signatures:" text not found, stop the process
				document.Close();
				return;
			}

			// Get the position of "Signatures:" text
			PointF textLocation = FindSignaturesTextLocation(page, "Signatures:");

			using (PdfReader reader = new PdfReader(filePath))
			using (FileStream fs = new FileStream(tempFilePath, FileMode.Create))
			using (PdfStamper stamper = new PdfStamper(reader, fs))
			{
				PdfContentByte contentByte = stamper.GetOverContent(pageNumber);
				ColumnText columnText = new ColumnText(contentByte);

				// Set the position of the text
				columnText.SetSimpleColumn(textLocation.X, page.ArtBox.Height - textLocation.Y,
					textLocation.X + 500f, textLocation.Y); // Adjust the dimensions as needed

				// Create a new paragraph with the signature text
				Paragraph paragraph = new Paragraph(signatureText);
				paragraph.Alignment = Element.ALIGN_LEFT;

				// Add the paragraph to the ColumnText
				columnText.AddElement(paragraph);

				// Update the ColumnText layout
				columnText.Go();

				stamper.Close();
			}

			File.Delete(filePath);
			File.Move(tempFilePath, filePath);
			File.Delete(tempFilePath);
			//}
		}

		private (PdfPageBase, int) FindSignaturesTextPage(PdfDocument document, string searchText)
        {
	        int pageIndex = 1;
	        foreach (PdfPageBase page in document.Pages)
	        {
		        string pageText = page.ExtractText();

		        if (pageText.Contains(searchText))
		        {
			        return (page, pageIndex);
		        }

		        pageIndex++;
	        }
	        return (null, 0);
        }

        private PointF FindSignaturesTextLocation(PdfPageBase page, string searchText)
        {
			PointF result;

			var signatureText = page.FindText(searchText, TextFindParameter.None).Finds.LastOrDefault();

			var lastSignatures = page.FindText("Signed by", TextFindParameter.None).Finds.ToList();
			
			if (lastSignatures.Count == 0)
			{
				result = signatureText.Position;
				result.Y += 25;
			}
			else
			{
				var lastSignatureMatch = lastSignatures.Last();
				var textRectangles = lastSignatureMatch.Position;

				// Assuming the last signature is a single line, take the bottom-left point of the last rectangle
				result = new PointF(textRectangles.X, textRectangles.Y);
				result.Y += 15;
			}

			return result;
		}
	}
}