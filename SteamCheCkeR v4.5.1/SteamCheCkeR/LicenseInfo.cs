using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using JLeGNet;

namespace SteamCheCkeR
{
	// Token: 0x02000006 RID: 6
	public class LicenseInfo : Window, IComponentConnector
	{
		// Token: 0x0600004E RID: 78 RVA: 0x00002516 File Offset: 0x00000716
		public LicenseInfo()
		{
			Class8.ah6VSoGzeNXX5();
			this.string_0 = "";
			base..ctor();
			this.InitializeComponent();
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002534 File Offset: 0x00000734
		private void method_0(object sender, RoutedEventArgs e)
		{
			this.TextLicenceInfo.Text = JLLicenseInfo.allinfo;
			this.infoNumber.Content = JLLicenseInfo.keySn;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002556 File Offset: 0x00000756
		private void buttonCopy_Click(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(this.TextLicenceInfo.Text))
			{
				Clipboard.SetText(this.TextLicenceInfo.Text);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00006CE0 File Offset: 0x00004EE0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			Uri resourceLocator = new Uri("/SteamCheCkeR v4.5.1;component/license/licenseinfo.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00006D10 File Offset: 0x00004F10
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((LicenseInfo)target).Loaded += this.method_0;
				return;
			case 2:
				this.GifInfo = (Image)target;
				return;
			case 3:
				this.buttonCopy = (Button)target;
				this.buttonCopy.Click += this.buttonCopy_Click;
				return;
			case 4:
				this.TextLicenceInfo = (TextBox)target;
				return;
			case 5:
				this.infoNumber = (Label)target;
				return;
			default:
				this.bool_0 = true;
				return;
			}
		}

		// Token: 0x0400004D RID: 77
		private string string_0;

		// Token: 0x0400004E RID: 78
		internal Image GifInfo;

		// Token: 0x0400004F RID: 79
		internal Button buttonCopy;

		// Token: 0x04000050 RID: 80
		internal TextBox TextLicenceInfo;

		// Token: 0x04000051 RID: 81
		internal Label infoNumber;

		// Token: 0x04000052 RID: 82
		private bool bool_0;
	}
}
