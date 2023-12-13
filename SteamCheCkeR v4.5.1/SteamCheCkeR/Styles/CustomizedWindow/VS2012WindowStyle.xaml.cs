using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shapes;

namespace SteamCheCkeR.Styles.CustomizedWindow
{
	// Token: 0x0200000C RID: 12
	public partial class VS2012WindowStyle : ResourceDictionary, IStyleConnector
	{
		// Token: 0x060000CF RID: 207 RVA: 0x000028D9 File Offset: 0x00000AD9
		private void method_0(object sender, MouseButtonEventArgs e)
		{
			this.method_8(sender, VS2012WindowStyle.SizingAction.South);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000028E3 File Offset: 0x00000AE3
		private void method_1(object sender, MouseButtonEventArgs e)
		{
			this.method_8(sender, VS2012WindowStyle.SizingAction.North);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000028ED File Offset: 0x00000AED
		private void method_2(object sender, MouseButtonEventArgs e)
		{
			this.method_8(sender, VS2012WindowStyle.SizingAction.East);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000028F7 File Offset: 0x00000AF7
		private void method_3(object sender, MouseButtonEventArgs e)
		{
			this.method_8(sender, VS2012WindowStyle.SizingAction.West);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00002901 File Offset: 0x00000B01
		private void method_4(object sender, MouseButtonEventArgs e)
		{
			this.method_8(sender, VS2012WindowStyle.SizingAction.NorthWest);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000290B File Offset: 0x00000B0B
		private void method_5(object sender, MouseButtonEventArgs e)
		{
			this.method_8(sender, VS2012WindowStyle.SizingAction.NorthEast);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00002915 File Offset: 0x00000B15
		private void method_6(object sender, MouseButtonEventArgs e)
		{
			this.method_8(sender, VS2012WindowStyle.SizingAction.SouthEast);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000291F File Offset: 0x00000B1F
		private void method_7(object sender, MouseButtonEventArgs e)
		{
			this.method_8(sender, VS2012WindowStyle.SizingAction.SouthWest);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00008404 File Offset: 0x00006604
		private void method_8(object object_0, VS2012WindowStyle.SizingAction sizingAction_0)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				object_0.smethod_1(delegate(Window w)
				{
					if (w.WindowState == WindowState.Normal)
					{
						this.method_15(w.smethod_2(), sizingAction_0);
					}
				});
			}
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00008448 File Offset: 0x00006648
		private void method_9(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount > 1)
			{
				if (VS2012WindowStyle.action_0 == null)
				{
					VS2012WindowStyle.action_0 = new Action<Window>(VS2012WindowStyle.smethod_0);
				}
				sender.smethod_1(VS2012WindowStyle.action_0);
				return;
			}
			if (VS2012WindowStyle.action_1 == null)
			{
				VS2012WindowStyle.action_1 = new Action<Window>(VS2012WindowStyle.smethod_1);
			}
			sender.smethod_1(VS2012WindowStyle.action_1);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00002929 File Offset: 0x00000B29
		private void method_10(object sender, RoutedEventArgs e)
		{
			if (VS2012WindowStyle.action_2 == null)
			{
				VS2012WindowStyle.action_2 = new Action<Window>(VS2012WindowStyle.smethod_2);
			}
			sender.smethod_1(VS2012WindowStyle.action_2);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000294E File Offset: 0x00000B4E
		private void method_11(object sender, RoutedEventArgs e)
		{
			if (VS2012WindowStyle.IcwDeaVubx == null)
			{
				VS2012WindowStyle.IcwDeaVubx = new Action<Window>(VS2012WindowStyle.smethod_3);
			}
			sender.smethod_1(VS2012WindowStyle.IcwDeaVubx);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00002973 File Offset: 0x00000B73
		private void method_12(object sender, RoutedEventArgs e)
		{
			if (VS2012WindowStyle.action_3 == null)
			{
				VS2012WindowStyle.action_3 = new Action<Window>(VS2012WindowStyle.smethod_4);
			}
			sender.smethod_1(VS2012WindowStyle.action_3);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000084A8 File Offset: 0x000066A8
		private void method_13(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount > 1)
			{
				new System.Windows.Forms.WebBrowser().Navigate("http://jlegioh.info/", true);
				return;
			}
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				if (VS2012WindowStyle.action_4 == null)
				{
					VS2012WindowStyle.action_4 = new Action<Window>(VS2012WindowStyle.smethod_5);
				}
				sender.smethod_1(VS2012WindowStyle.action_4);
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000084FC File Offset: 0x000066FC
		private void method_14(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				sender.smethod_1(delegate(Window w)
				{
					if (w.WindowState == WindowState.Maximized)
					{
						w.BeginInit();
						double num = 40.0;
						Point position = e.MouseDevice.GetPosition(w);
						double num2 = Math.Max(w.ActualWidth - (double)80f, num);
						w.WindowState = WindowState.Normal;
						double num3 = Math.Max(w.ActualWidth - (double)80f, num);
						w.Left = (position.X - num) * (1.0 - num3 / num2);
						w.Top = -7.0;
						w.EndInit();
						w.DragMove();
					}
				});
			}
		}

		// Token: 0x060000DE RID: 222
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr intptr_0, uint uint_0, IntPtr intptr_1, IntPtr intptr_2);

		// Token: 0x060000DF RID: 223 RVA: 0x00002998 File Offset: 0x00000B98
		private void method_15(IntPtr intptr_0, VS2012WindowStyle.SizingAction sizingAction_0)
		{
			VS2012WindowStyle.SendMessage(intptr_0, 274U, (IntPtr)((long)(61440 + sizingAction_0)), IntPtr.Zero);
			VS2012WindowStyle.SendMessage(intptr_0, 514U, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00008570 File Offset: 0x00006770
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IStyleConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((Border)target).MouseLeftButtonDown += this.method_13;
				((Border)target).MouseMove += this.method_14;
				return;
			case 2:
				((Image)target).MouseLeftButtonDown += this.method_9;
				return;
			case 3:
				((System.Windows.Controls.Button)target).Click += this.method_11;
				return;
			case 4:
				((System.Windows.Controls.Button)target).Click += this.method_12;
				return;
			case 5:
				((System.Windows.Controls.Button)target).Click += this.method_10;
				return;
			case 6:
				((Line)target).MouseDown += this.method_1;
				return;
			case 7:
				((Line)target).MouseDown += this.method_0;
				return;
			case 8:
				((Line)target).MouseDown += this.method_3;
				return;
			case 9:
				((Line)target).MouseDown += this.method_2;
				return;
			case 10:
				((Rectangle)target).MouseDown += this.method_4;
				return;
			case 11:
				((Rectangle)target).MouseDown += this.method_5;
				return;
			case 12:
				((Rectangle)target).MouseDown += this.method_7;
				return;
			case 13:
				((Rectangle)target).MouseDown += this.method_6;
				return;
			default:
				return;
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000029D7 File Offset: 0x00000BD7
		public VS2012WindowStyle()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000029E4 File Offset: 0x00000BE4
		[CompilerGenerated]
		private static void smethod_0(Window window_0)
		{
			window_0.Close();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000029EC File Offset: 0x00000BEC
		[CompilerGenerated]
		private static void smethod_1(Window window_0)
		{
			VS2012WindowStyle.SendMessage(window_0.smethod_2(), 274U, (IntPtr)61696, (IntPtr)32);
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000029E4 File Offset: 0x00000BE4
		[CompilerGenerated]
		private static void smethod_2(Window window_0)
		{
			window_0.Close();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00002A10 File Offset: 0x00000C10
		[CompilerGenerated]
		private static void smethod_3(Window window_0)
		{
			window_0.WindowState = WindowState.Minimized;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00002A19 File Offset: 0x00000C19
		[CompilerGenerated]
		private static void smethod_4(Window window_0)
		{
			window_0.WindowState = ((window_0.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00002A2E File Offset: 0x00000C2E
		[CompilerGenerated]
		private static void smethod_5(Window window_0)
		{
			window_0.DragMove();
		}

		// Token: 0x04000097 RID: 151
		[CompilerGenerated]
		private static Action<Window> action_0;

		// Token: 0x04000098 RID: 152
		[CompilerGenerated]
		private static Action<Window> action_1;

		// Token: 0x04000099 RID: 153
		[CompilerGenerated]
		private static Action<Window> action_2;

		// Token: 0x0400009A RID: 154
		[CompilerGenerated]
		private static Action<Window> IcwDeaVubx;

		// Token: 0x0400009B RID: 155
		[CompilerGenerated]
		private static Action<Window> action_3;

		// Token: 0x0400009C RID: 156
		[CompilerGenerated]
		private static Action<Window> action_4;

		// Token: 0x0200000D RID: 13
		public enum SizingAction
		{
			// Token: 0x0400009E RID: 158
			North = 3,
			// Token: 0x0400009F RID: 159
			South = 6,
			// Token: 0x040000A0 RID: 160
			East = 2,
			// Token: 0x040000A1 RID: 161
			West = 1,
			// Token: 0x040000A2 RID: 162
			NorthEast = 5,
			// Token: 0x040000A3 RID: 163
			NorthWest = 4,
			// Token: 0x040000A4 RID: 164
			SouthEast = 8,
			// Token: 0x040000A5 RID: 165
			SouthWest = 7
		}
	}
}
