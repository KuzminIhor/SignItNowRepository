using System.Windows.Forms;
using NLog;

namespace SignItNow.Forms
{
	public partial class PreviewDocument : Form
	{
		private static PreviewDocument _form;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		public static PreviewDocument GetInstance()
		{
			if (_form == null)
			{
				_form = new PreviewDocument();
			}

			return _form;
		}
		private PreviewDocument()
		{
			InitializeComponent();
		}

		private void PreviewDocument_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true; // Cancel the form closing
				this.Hide();     // Hide the form instead
			}
		}
	}
}
