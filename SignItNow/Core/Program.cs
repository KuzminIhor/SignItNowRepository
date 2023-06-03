using System;
using System.IO;
using System.Windows.Forms;
using NLog;
using SignItNow.AppData.Unity;
using SignItNow.Forms;
using SignItNow.Services.Interfaces;

namespace SignItNow.Core
{
    internal static class Program
    {
	    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public static int? UserId { get; set; }

		public const string SQLConnection = "Server=(localdb)\\mssqllocaldb;Database=SignItNowDB;Trusted_Connection=True;";
		public const string AvailableFileExtentions = ".pdf,.xlsx,.pptx,.docx,.xls,.ppt,.doc";

		public const string BaseFilePath = "D:\\SignItNow\\SignItNow";
		public const string UploadedDocsFolder = "AppData\\DocsForSign";
		public const string TempDocsFolder = "AppData\\TempDoc";

		public const bool VisualizeSignature = true;

		[STAThread]
	    static void Main()
	    {
		    _logger.Info("Запуск програми");

			UnityConfig.Register();

			_logger.Info("Залежності зареєстровані");

			Application.EnableVisualStyles();
		    Application.SetCompatibleTextRenderingDefault(false);
		    Application.Run(MainForm.GetInstance());
	    }
    }
}
