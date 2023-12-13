using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;

namespace SteamCheCkeR
{
	// Token: 0x02000016 RID: 22
	public class WindowShutdown : Window, IComponentConnector
	{
		// Token: 0x06000137 RID: 311 RVA: 0x0000E55C File Offset: 0x0000C75C
		public WindowShutdown()
		{
			Class8.ah6VSoGzeNXX5();
			this.timer_0 = new Timer();
			this.int_0 = 60;
			base..ctor();
			this.InitializeComponent();
			this.timer_0.Interval = 1000;
			this.timer_0.Tick += this.timer_0_Tick;
			this.timer_0.Start();
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000E5C0 File Offset: 0x0000C7C0
		private void method_0()
		{
			try
			{
				ManagementClass managementClass = new ManagementClass("Win32_OperatingSystem");
				managementClass.Get();
				managementClass.Scope.Options.EnablePrivileges = true;
				ManagementBaseObject methodParameters = managementClass.GetMethodParameters("Win32Shutdown");
				methodParameters["Flags"] = "1";
				methodParameters["Reserved"] = "15";
				foreach (ManagementBaseObject managementBaseObject in managementClass.GetInstances())
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					managementObject.InvokeMethod("Win32Shutdown", methodParameters, null);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00002C24 File Offset: 0x00000E24
		private void ButonStop_Click(object sender, RoutedEventArgs e)
		{
			this.timer_0.Stop();
			base.Close();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000E67C File Offset: 0x0000C87C
		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.int_0--;
			if (this.int_0 == 0)
			{
				this.method_0();
				base.Close();
			}
			this.progresBar.Value = (double)this.int_0;
			this.labeltick.Content = this.int_0.ToString() + " секунд до выключения ПК";
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000E6E0 File Offset: 0x0000C8E0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			Uri resourceLocator = new Uri("/SteamCheCkeR v4.5.1;component/windows/windowshutdown.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000E710 File Offset: 0x0000C910
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.ButonStop = (System.Windows.Controls.Button)target;
				this.ButonStop.Click += this.ButonStop_Click;
				return;
			case 2:
				this.progresBar = (System.Windows.Controls.ProgressBar)target;
				return;
			case 3:
				this.labeltick = (System.Windows.Controls.Label)target;
				return;
			default:
				this.bool_0 = true;
				return;
			}
		}

		// Token: 0x0400010A RID: 266
		private Timer timer_0;

		// Token: 0x0400010B RID: 267
		private int int_0;

		// Token: 0x0400010C RID: 268
		internal System.Windows.Controls.Button ButonStop;

		// Token: 0x0400010D RID: 269
		internal System.Windows.Controls.ProgressBar progresBar;

		// Token: 0x0400010E RID: 270
		internal System.Windows.Controls.Label labeltick;

		// Token: 0x0400010F RID: 271
		private bool bool_0;
	}
}
