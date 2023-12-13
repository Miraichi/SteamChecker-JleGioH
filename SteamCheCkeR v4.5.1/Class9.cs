using System;
using System.Reflection;
using System.Windows.Forms;

// Token: 0x0200002A RID: 42
internal static class Class9
{
	// Token: 0x060001CB RID: 459 RVA: 0x00002F7B File Offset: 0x0000117B
	internal static string yPyVSobdLtMrO(Assembly assembly)
	{
		if (assembly == typeof(Class9).Assembly)
		{
			return Application.ExecutablePath;
		}
		return assembly.Location;
	}
}
