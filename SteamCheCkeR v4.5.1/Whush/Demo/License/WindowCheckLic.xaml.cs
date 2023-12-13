using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Shapes;
using SteamCheCkeR;

namespace Whush.Demo.License
{
	// Token: 0x02000007 RID: 7
	public partial class WindowCheckLic : Window
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00006DA8 File Offset: 0x00004FA8
		public WindowCheckLic()
		{
			Class8.ah6VSoGzeNXX5();
			this.timer_0 = new Timer();
			base..ctor();
			this.InitializeComponent();
			this.timer_0.Interval = 500;
			this.timer_0.Tick += this.TimerTick;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000257A File Offset: 0x0000077A
		public void WindowLoad(object sender, EventArgs e)
		{
			this.timer_0.Start();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002587 File Offset: 0x00000787
		public void TimerTick(object sender, EventArgs e)
		{
			if (MainWindow.LicenseCheck)
			{
				base.Close();
			}
		}

		// Token: 0x04000053 RID: 83
		private Timer timer_0;
	}
}
