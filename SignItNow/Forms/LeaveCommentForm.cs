using System;
using System.Windows.Forms;
using NLog;
using SignItNow.Core;
using SignItNow.Model.Exceptions;
using SignItNow.Repositories.Interfaces;

namespace SignItNow.Forms
{
	public partial class LeaveCommentForm : Form
	{
		private static LeaveCommentForm _form;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private ISigningService signingService;

		public int TaskId { get; set; }
		public bool IsSigning { get; set; }

		private LeaveCommentForm()
		{
			signingService = ServiceLocator.Get<ISigningService>();

			InitializeComponent();
		}

		public static LeaveCommentForm GetInstance()
		{
			if (_form == null)
			{
				_form = new LeaveCommentForm();
			}

			return _form;
		}

		private void LeaveCommentForm_Load(object sender, EventArgs e)
		{

		}

		private void LeaveCommentForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				this.commentTextBox.Text = string.Empty;

				e.Cancel = true; // Cancel the form closing
				this.Hide(); // Hide the form instead
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ContinueButton_Click(object sender, EventArgs e)
		{
			if (IsSigning == true)
			{
				try
				{
					signingService.Sign(TaskId, Program.UserId.Value, true, this.commentTextBox.Text.Trim());

					DialogResult result3 = MessageBox.Show("Підписано!",
						"Успіх", MessageBoxButtons.OK);

					_logger.Info($"Користувач {Program.UserId.Value} підписав задачу {TaskId}");
				}
				catch (SigningTaskException ex)
				{
					DialogResult result3 = MessageBox.Show(ex.Message,
						"Помилка", MessageBoxButtons.OK);

					_logger.Error($"Сталась помилка під час підпису задачі {TaskId} користувачем {Program.UserId.Value}: {ex.Message}");
				}
				catch (Exception ex)
				{
					DialogResult result3 = MessageBox.Show("Сталась якась помилка",
						"Помилка", MessageBoxButtons.OK);

					_logger.Error($"Сталась помилка під час підпису задачі {TaskId} користувачем {Program.UserId.Value}: {ex.Message}");
				}
			}
			else
			{
				try
				{
					signingService.Reject(TaskId, Program.UserId.Value, true, this.commentTextBox.Text.Trim());

					DialogResult result3 = MessageBox.Show("Відмовлено у підписі!",
						"Успіх", MessageBoxButtons.OK);

					_logger.Info($"Користувач {Program.UserId.Value} відмовив у підписі задачу {TaskId}");

					this.commentTextBox.Text = string.Empty;

					this.Hide();
				}
				catch (SigningTaskException ex)
				{
					DialogResult result3 = MessageBox.Show(ex.Message,
						"Помилка", MessageBoxButtons.OK);

					_logger.Error(
						$"Сталась помилка під час відмови у підписі задачі {TaskId} користувачем {Program.UserId.Value}: {ex.Message}");
				}
				catch (Exception ex)
				{
					DialogResult result3 = MessageBox.Show("Сталась якась помилка",
						"Помилка", MessageBoxButtons.OK);

					_logger.Error(
						$"Сталась помилка під час відмови у підписі задачі {TaskId} користувачем {Program.UserId.Value}: {ex.Message}");
				}
			}

			this.commentTextBox.Text = string.Empty;
			this.Hide();
			IncommingTasksForm.GetInstance().FillIncommingTasks();
		}
	}
}
