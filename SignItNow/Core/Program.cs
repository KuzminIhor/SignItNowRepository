using System;
using System.IO;
using System.Windows.Forms;
using NLog;
using System.Configuration;
using SignItNow.AppData.Unity;
using SignItNow.Forms;
using SignItNow.Services.Interfaces;

namespace SignItNow.Core
{
    internal static class Program
    {
	    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public static int? UserId { get; set; }

		public static string SQLConnection;
		public const string AvailableFileExtentions = ".pdf,.xlsx,.pptx,.docx,.xls,.ppt,.doc";

		public static string BaseFilePath;
		public static string UploadedDocsFolder;
		public static string TempDocsFolder;

		public static bool VisualizeSignature = true;

		[STAThread]
	    static void Main()
	    {
		    _logger.Info("Запуск програми");

		    var configMap = new ExeConfigurationFileMap { ExeConfigFilename = @"D:\SignItNow\SignItNow\Core\App.config" };
		    var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

		    SQLConnection = config.AppSettings.Settings["DatabaseConnectionString"].Value;
		    BaseFilePath = config.AppSettings.Settings["BaseFilePath"].Value;
		    UploadedDocsFolder = config.AppSettings.Settings["UploadedDocsFolder"].Value;
		    TempDocsFolder = config.AppSettings.Settings["TempDocsFolder"].Value;
		    VisualizeSignature = Convert.ToBoolean(config.AppSettings.Settings["VisualizeSignature"].Value);

		    UnityConfig.Register();

			_logger.Info("Залежності зареєстровані");

			Application.EnableVisualStyles();
		    Application.SetCompatibleTextRenderingDefault(false);
		    Application.Run(MainForm.GetInstance());
	    }
    }
}
