using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;

namespace Whush.Demo.License
{
	// Token: 0x02000008 RID: 8
	public partial class WindowStart : Window
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00006E84 File Offset: 0x00005084
		public WindowStart()
		{
			Class8.ah6VSoGzeNXX5();
			this.timer_0 = new Timer();
			base..ctor();
			this.InitializeComponent();
			this.timer_0.Interval = 500;
			this.timer_0.Tick += this.TimerTick;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002596 File Offset: 0x00000796
		public void WindowLoad(object sender, EventArgs e)
		{
			this.timer_0.Start();
			WindowStart._StatusGetClass = false;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000025A9 File Offset: 0x000007A9
		public void TimerTick(object sender, EventArgs e)
		{
			if (WindowStart._StatusGetClass)
			{
				base.Close();
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000025B8 File Offset: 0x000007B8
		static WindowStart()
		{
			Class8.ah6VSoGzeNXX5();
		}

		// Token: 0x04000057 RID: 87
		private Timer timer_0;

		// Token: 0x04000058 RID: 88
		public static bool _StatusGetClass;
	}
}
