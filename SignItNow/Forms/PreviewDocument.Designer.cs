
namespace SignItNow.Forms
{
	partial class PreviewDocument
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewDocument));
			this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
			((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
			this.SuspendLayout();
			// 
			// axAcroPDF1
			// 
			this.axAcroPDF1.Enabled = true;
			this.axAcroPDF1.Location = new System.Drawing.Point(0, -5);
			this.axAcroPDF1.Name = "axAcroPDF1";
			this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
			this.axAcroPDF1.Size = new System.Drawing.Size(904, 694);
			this.axAcroPDF1.TabIndex = 22;
			// 
			// PreviewDocument
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1200, 1055);
			this.Controls.Add(this.axAcroPDF1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PreviewDocument";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PreviewDocument";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviewDocument_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public AxAcroPDFLib.AxAcroPDF axAcroPDF1;
	}
}