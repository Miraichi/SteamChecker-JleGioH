using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SteamCheCkeR.Properties
{
	// Token: 0x0200001C RID: 28
	[DebuggerNonUserCode]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	internal class Resources
	{
		// Token: 0x06000180 RID: 384 RVA: 0x00002402 File Offset: 0x00000602
		internal Resources()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00012540 File Offset: 0x00010740
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager_0
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceManager_0, null))
				{
					ResourceManager resourceManager = new ResourceManager("SteamCheCkeR.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceManager_0 = resourceManager;
				}
				return Resources.resourceManager_0;
			}
		}

		// Token: 0x17000023 RID: 35
		// (set) Token: 0x06000182 RID: 386 RVA: 0x00002DD3 File Offset: 0x00000FD3
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo CultureInfo_0
		{
			set
			{
				Resources.cultureInfo_0 = value;
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00012580 File Offset: 0x00010780
		internal static Bitmap qQddvUdAoK()
		{
			object @object = Resources.ResourceManager_0.GetObject("Info", Resources.cultureInfo_0);
			return (Bitmap)@object;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00002DDB File Offset: 0x00000FDB
		internal static UnmanagedMemoryStream smethod_0()
		{
			return Resources.ResourceManager_0.GetStream("MoneyWav", Resources.cultureInfo_0);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000125A8 File Offset: 0x000107A8
		internal static Bitmap smethod_1()
		{
			object @object = Resources.ResourceManager_0.GetObject("Vadim_zastavka_german_girl2", Resources.cultureInfo_0);
			return (Bitmap)@object;
		}

		// Token: 0x0400016B RID: 363
		private static ResourceManager resourceManager_0;

		// Token: 0x0400016C RID: 364
		private static CultureInfo cultureInfo_0;
	}
}
