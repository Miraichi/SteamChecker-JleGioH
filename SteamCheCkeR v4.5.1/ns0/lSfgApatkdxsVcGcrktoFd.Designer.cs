namespace ns0
{
	// Token: 0x02000059 RID: 89
	internal partial class lSfgApatkdxsVcGcrktoFd : global::System.Windows.Forms.Form
	{
		// Token: 0x060003B6 RID: 950 RVA: 0x00003EBA File Offset: 0x000020BA
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0002AD04 File Offset: 0x00028F04
		private void InitializeComponent()
		{
			global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager(typeof(global::ns0.lSfgApatkdxsVcGcrktoFd));
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			base.SuspendLayout();
			this.progressBar1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.progressBar1.Location = new global::System.Drawing.Point(0, 0);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(123, 10);
			this.progressBar1.TabIndex = 0;
			this.progressBar1.Value = 65;
			this.AutoScaleBaseSize = new global::System.Drawing.Size(5, 13);
			base.ClientSize = new global::System.Drawing.Size(123, 10);
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (global::System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
			base.Name = "LoadingForm";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "loading...";
			base.TopMost = true;
			base.ResumeLayout(false);
		}

		// Token: 0x040002CE RID: 718
		private global::System.ComponentModel.Container components;

		// Token: 0x040002CF RID: 719
		public global::System.Windows.Forms.ProgressBar progressBar1;
	}
}
