using System;
using System.Reflection;

// Token: 0x0200001F RID: 31
internal class Class4
{
	// Token: 0x06000189 RID: 393 RVA: 0x000125D0 File Offset: 0x000107D0
	internal static void cwWVSoGGvunSY(int typemdt)
	{
		Type type = Class4.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class4.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	// Token: 0x0600018A RID: 394 RVA: 0x00002402 File Offset: 0x00000602
	public Class4()
	{
		Class8.ah6VSoGzeNXX5();
		base..ctor();
	}

	// Token: 0x0600018B RID: 395 RVA: 0x00002E20 File Offset: 0x00001020
	static Class4()
	{
		Class8.ah6VSoGzeNXX5();
		Class4.module_0 = typeof(Class4).Assembly.ManifestModule;
	}

	// Token: 0x0400016E RID: 366
	internal static Module module_0;

	// Token: 0x02000020 RID: 32
	// (Invoke) Token: 0x0600018D RID: 397
	internal delegate void Delegate0(object o);
}
