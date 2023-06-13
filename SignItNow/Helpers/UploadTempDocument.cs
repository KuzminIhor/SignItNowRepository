using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Interop.Word;
using SignItNow.Core;
using SignItNow.Helpers.Abstracts;
using SignItNow.Helpers.Interfaces;
using Document = Microsoft.Office.Interop.Word.Document;
using Font = iTextSharp.text.Font;
using Paragraph = iTextSharp.text.Paragraph;

namespace SignItNow.Helpers
{
	public class UploadTempDocument: AbstractDocumentHandler, IUploadTempDocument
	{
		public override object Handle(string uploadedFileName)
		{
			switch (new FileInfo(uploadedFileName).Extension)
			{
				case ".pdf":
					UploadPDF(uploadedFileName);
					break;
				case ".doc":
				case ".docx":
					UploadWord(uploadedFileName);
					break;
				case ".xls":
				case ".xlsx":
					UploadExcel(uploadedFileName);
					break;
				case ".ppt":
				case ".pptx":
					UploadPowerPoint(uploadedFileName);
					break;
			}

			return base.Handle(uploadedFileName);
		}

		public void UploadPDF(string filePath)
		{
			var destinationFilePath = Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + ".pdf");

			using (var reader = new PdfReader(filePath))
			using (var fileStream = new FileStream(destinationFilePath, FileMode.Create))
			using (var stamper = new PdfStamper(reader, fileStream))
			{
				if (Program.VisualizeSignature)
				{
					var pageCount = reader.NumberOfPages;

					var blankPage = new iTextSharp.text.Document().PageSize;
					stamper.InsertPage(pageCount + 1, blankPage);

					var contentByte = stamper.GetOverContent(pageCount + 1);

					var baseFont = BaseFont.CreateFont(Path.Combine(Program.BaseFilePath, "Core", "Fonts", "times new roman.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
					var font = new Font(baseFont, 12, Font.NORMAL);

					// Set the position of the text
					var x = 20f; // Adjust the value as needed
					var y = blankPage.Height - 50f; // Adjust the value as needed

					// Create a new ColumnText object to add the text
					var columnText = new ColumnText(contentByte);
					columnText.SetSimpleColumn(x, y, blankPage.Width - x, y - 20f);
					columnText.AddElement(new Chunk("Підписи:", font));
					columnText.Go(false); // Set simulate to false and text to null
				}

				stamper.Close();
				reader.Close();
			}
		}

		public void UploadWord(string filePath)
		{
			var wordApp = new Microsoft.Office.Interop.Word.Application();
			Document document = wordApp.Documents.Open(filePath);

			var destinationTempFilePath =
				Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + "_temp.pdf");

			var destinationFilePath =
				Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + ".pdf");

			if (Program.VisualizeSignature)
			{
				document.ExportAsFixedFormat(destinationTempFilePath, WdExportFormat.wdExportFormatPDF);
			}
			else
			{
				document.ExportAsFixedFormat(destinationFilePath, WdExportFormat.wdExportFormatPDF);
			}

			document.Close();
			wordApp.Quit();

			if (Program.VisualizeSignature)
			{
				using (var reader = new PdfReader(destinationTempFilePath))
				using (var fileStream = new FileStream(destinationFilePath, FileMode.OpenOrCreate))
				using (var stamper = new PdfStamper(reader, fileStream))
				{
					int pageCount = reader.NumberOfPages;

					var blankPage = new iTextSharp.text.Document().PageSize;
					stamper.InsertPage(pageCount + 1, blankPage);

					var contentByte = stamper.GetOverContent(pageCount + 1);
					var baseFont = BaseFont.CreateFont(Path.Combine(Program.BaseFilePath, "Core", "Fonts", "times new roman.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
					var font = new Font(baseFont, 12, Font.NORMAL);

					// Set the position of the text
					var x = 20f; // Adjust the value as needed
					var y = blankPage.Height - 50f; // Adjust the value as needed

					// Create a new ColumnText object to add the text
					var columnText = new ColumnText(contentByte);
					columnText.SetSimpleColumn(x, y, blankPage.Width - x, y - 20f);
					columnText.AddElement(new iTextSharp.text.Chunk("Підписи:", font));
					columnText.Go();

					stamper.Close();
					reader.Close();
				}
			}

			File.Delete(destinationTempFilePath);
		}

		public void UploadExcel(string filePath)
		{
			var excelApp = new Microsoft.Office.Interop.Excel.Application();
			Workbook workbook = excelApp.Workbooks.Open(filePath);

			var destinationTempFilePath =
				Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + "_temp.pdf");

			var destinationFilePath =
				Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + ".pdf");

			if (Program.VisualizeSignature)
			{
				workbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, destinationTempFilePath);
			}
			else
			{
				workbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, destinationFilePath);
			}

			workbook.Close();
			excelApp.Quit();

			if (Program.VisualizeSignature)
			{
				using (var reader = new PdfReader(destinationTempFilePath))
				using (var fileStream = new FileStream(destinationFilePath, FileMode.OpenOrCreate))
				using (var stamper = new PdfStamper(reader, fileStream))
				{
					int pageCount = reader.NumberOfPages;

					var blankPage = new iTextSharp.text.Document().PageSize;
					stamper.InsertPage(pageCount + 1, blankPage);

					var contentByte = stamper.GetOverContent(pageCount + 1);
					var baseFont = BaseFont.CreateFont(Path.Combine(Program.BaseFilePath, "Core", "Fonts", "times new roman.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
					var font = new Font(baseFont, 12, Font.NORMAL);

					// Set the position of the text
					var x = 20f; // Adjust the value as needed
					var y = blankPage.Height - 50f; // Adjust the value as needed

					// Create a new ColumnText object to add the text
					var columnText = new ColumnText(contentByte);
					columnText.SetSimpleColumn(x, y, blankPage.Width - x, y - 20f);
					columnText.AddElement(new iTextSharp.text.Chunk("Підписи:", font));
					columnText.Go();

					stamper.Close();
					reader.Close();
				}
			}

			File.Delete(destinationTempFilePath);
		}

		public void UploadPowerPoint(string filePath)
		{
			var pptApp = new Microsoft.Office.Interop.PowerPoint.Application();
			Presentation presentation = pptApp.Presentations.Open(filePath);

			var destinationTempFilePath =
				Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + "_temp.pdf");

			var destinationFilePath =
				Path.Combine(Program.BaseFilePath, Program.TempDocsFolder, Program.UserId.Value + ".pdf");

			if (Program.VisualizeSignature)
			{
				presentation.ExportAsFixedFormat(destinationTempFilePath, PpFixedFormatType.ppFixedFormatTypePDF);
			}
			else
			{
				presentation.ExportAsFixedFormat(destinationFilePath, PpFixedFormatType.ppFixedFormatTypePDF);
			}

			presentation.Close();
			pptApp.Quit();

			if (Program.VisualizeSignature)
			{
				using (var reader = new PdfReader(destinationTempFilePath))
				using (var fileStream = new FileStream(destinationFilePath, FileMode.OpenOrCreate))
				using (var stamper = new PdfStamper(reader, fileStream))
				{
					int pageCount = reader.NumberOfPages;

					var blankPage = new iTextSharp.text.Document().PageSize;
					stamper.InsertPage(pageCount + 1, blankPage);

					var contentByte = stamper.GetOverContent(pageCount + 1);
					var baseFont = BaseFont.CreateFont(Path.Combine(Program.BaseFilePath, "Core", "Fonts", "times new roman.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
					var font = new Font(baseFont, 12, Font.NORMAL);

					// Set the position of the text
					var x = 20f; // Adjust the value as needed
					var y = blankPage.Height - 50f; // Adjust the value as needed

					// Create a new ColumnText object to add the text
					var columnText = new ColumnText(contentByte);
					columnText.SetSimpleColumn(x, y, blankPage.Width - x, y - 20f);
					columnText.AddElement(new iTextSharp.text.Chunk("Підписи:", font));
					columnText.Go();

					stamper.Close();
					reader.Close();
				}
			}

			File.Delete(destinationTempFilePath);
		}
	}
}