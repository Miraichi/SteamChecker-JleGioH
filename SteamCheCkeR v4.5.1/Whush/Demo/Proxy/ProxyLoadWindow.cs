using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;

namespace Whush.Demo.Proxy
{
	// Token: 0x02000009 RID: 9
	public class ProxyLoadWindow : Window, IComponentConnector
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00006F50 File Offset: 0x00005150
		public ProxyLoadWindow(object proxyClass)
		{
			Class8.ah6VSoGzeNXX5();
			this.timer_0 = new System.Windows.Forms.Timer();
			base..ctor();
			this.InitializeComponent();
			this.object_0 = proxyClass;
			this.timer_0.Interval = 500;
			this.timer_0.Tick += this.TimerTick;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000025BF File Offset: 0x000007BF
		public void WindowLoad(object sender, EventArgs e)
		{
			new Thread(new ThreadStart(this.method_0)).Start();
			this.timer_0.Start();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00006FA8 File Offset: 0x000051A8
		private void method_0()
		{
			this.object_0.GetType().InvokeMember("LoadProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[]
			{
				true,
				true
			});
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000025E2 File Offset: 0x000007E2
		public void TimerTick(object sender, EventArgs e)
		{
			if ((bool)this.object_0.GetType().InvokeMember("ProxyUpdated", BindingFlags.InvokeMethod, null, this.object_0, new object[0]))
			{
				base.Close();
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00006FF4 File Offset: 0x000051F4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			Uri resourceLocator = new Uri("/SteamCheCkeR v4.5.1;component/proxy/pwoxyloadwindow.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00007024 File Offset: 0x00005224
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((ProxyLoadWindow)target).Loaded += new RoutedEventHandler(this.WindowLoad);
				return;
			case 2:
				this.GifInfo = (Image)target;
				return;
			default:
				this.bool_0 = true;
				return;
			}
		}

		// Token: 0x0400005B RID: 91
		private object object_0;

		// Token: 0x0400005C RID: 92
		private System.Windows.Forms.Timer timer_0;

		// Token: 0x0400005D RID: 93
		internal Image GifInfo;

		// Token: 0x0400005E RID: 94
		private bool bool_0;
	}
}
