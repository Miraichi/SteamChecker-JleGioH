using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

// Token: 0x0200000B RID: 11
internal static class Class2
{
	// Token: 0x060000CC RID: 204 RVA: 0x00008388 File Offset: 0x00006588
	public static void smethod_0(this object object_0, Action<Window> action)
	{
		DependencyObject dependencyObject = object_0 as DependencyObject;
		while (dependencyObject != null)
		{
			dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
			if (dependencyObject is Window)
			{
				action(dependencyObject as Window);
				return;
			}
		}
	}

	// Token: 0x060000CD RID: 205 RVA: 0x000083C0 File Offset: 0x000065C0
	public static void smethod_1(this FrameworkElement frameworkElement_0, Action<Window> action)
	{
		Window window = ((FrameworkElement)frameworkElement_0).TemplatedParent as Window;
		if (window != null)
		{
			action(window);
		}
	}

	// Token: 0x060000CE RID: 206 RVA: 0x000083E8 File Offset: 0x000065E8
	public static IntPtr smethod_2(this Window window_0)
	{
		WindowInteropHelper windowInteropHelper = new WindowInteropHelper(window_0);
		return windowInteropHelper.Handle;
	}
}
