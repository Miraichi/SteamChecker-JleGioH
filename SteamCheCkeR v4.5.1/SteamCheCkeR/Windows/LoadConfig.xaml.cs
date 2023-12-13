using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using JLeGNet.JLHelpers;

namespace SteamCheCkeR.Windows
{
	// Token: 0x02000011 RID: 17
	public partial class LoadConfig : Window
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00008AE8 File Offset: 0x00006CE8
		public LoadConfig()
		{
			Class8.ah6VSoGzeNXX5();
			this.timer_0 = new System.Windows.Forms.Timer();
			base..ctor();
			this.InitializeComponent();
			this.timer_0.Interval = 500;
			this.timer_0.Tick += this.TimerTick;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00002A99 File Offset: 0x00000C99
		public void WindowLoad(object sender, EventArgs e)
		{
			new Thread(new ThreadStart(this.method_0)).Start();
			this.timer_0.Start();
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00002ABC File Offset: 0x00000CBC
		private void method_0()
		{
			if (EmailConfigWorker.EmailSettingCount == 0)
			{
				EmailConfigWorker.GetAllConfig();
			}
			this.bool_0 = true;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00002AD1 File Offset: 0x00000CD1
		public void TimerTick(object sender, EventArgs e)
		{
			if (this.bool_0)
			{
				base.Close();
			}
		}

		// Token: 0x040000AF RID: 175
		private object object_0;

		// Token: 0x040000B0 RID: 176
		private System.Windows.Forms.Timer timer_0;

		// Token: 0x040000B1 RID: 177
		private bool bool_0;
	}
}
