using System;
using System.Collections;
using System.IO;
using System.Threading;

// Token: 0x02000054 RID: 84
internal class Class35
{
	// Token: 0x06000372 RID: 882 RVA: 0x0002A9F0 File Offset: 0x00028BF0
	internal static void smethod_0()
	{
		Class35.bool_0 = false;
		Class35.bool_1 = false;
		Class35.bool_2 = false;
		Class35.bool_3 = false;
		Class35.bool_4 = false;
		Class35.bool_5 = false;
		Class35.int_0 = 0;
		Class35.int_1 = 0;
		Class35.string_1 = "####-####-####-####-####";
		Class35.int_2 = 1;
		Class35.int_3 = 0;
		Class35.int_4 = 1;
		Class35.enum9_0 = Enum9.Trial_Days;
		DateTime now = DateTime.Now;
		Class35.sortedList_0 = new SortedList();
		Class35.byte_0 = new byte[0];
	}

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x06000373 RID: 883 RVA: 0x0002AA6C File Offset: 0x00028C6C
	// (remove) Token: 0x06000374 RID: 884 RVA: 0x0002AAA0 File Offset: 0x00028CA0
	public static event Class35.Delegate3 Event_0
	{
		add
		{
			Class35.Delegate3 @delegate = Class35.object_0;
			Class35.Delegate3 delegate2;
			do
			{
				delegate2 = @delegate;
				Class35.Delegate3 value2 = (Class35.Delegate3)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange<Class35.Delegate3>(ref Class35.object_0, value2, delegate2);
			}
			while (@delegate != delegate2);
		}
		remove
		{
			Class35.Delegate3 @delegate = Class35.object_0;
			Class35.Delegate3 delegate2;
			do
			{
				delegate2 = @delegate;
				Class35.Delegate3 value2 = (Class35.Delegate3)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange<Class35.Delegate3>(ref Class35.object_0, value2, delegate2);
			}
			while (@delegate != delegate2);
		}
	}

	// Token: 0x06000375 RID: 885 RVA: 0x00003D85 File Offset: 0x00001F85
	public static string smethod_1()
	{
		return Class30.smethod_3();
	}

	// Token: 0x14000003 RID: 3
	// (add) Token: 0x06000376 RID: 886 RVA: 0x0002AAD4 File Offset: 0x00028CD4
	// (remove) Token: 0x06000377 RID: 887 RVA: 0x0002AB08 File Offset: 0x00028D08
	public static event Class35.Delegate4 Event_1
	{
		add
		{
			Class35.Delegate4 @delegate = Class35.object_1;
			Class35.Delegate4 delegate2;
			do
			{
				delegate2 = @delegate;
				Class35.Delegate4 value2 = (Class35.Delegate4)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange<Class35.Delegate4>(ref Class35.object_1, value2, delegate2);
			}
			while (@delegate != delegate2);
		}
		remove
		{
			Class35.Delegate4 @delegate = Class35.object_1;
			Class35.Delegate4 delegate2;
			do
			{
				delegate2 = @delegate;
				Class35.Delegate4 value2 = (Class35.Delegate4)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange<Class35.Delegate4>(ref Class35.object_1, value2, delegate2);
			}
			while (@delegate != delegate2);
		}
	}

	// Token: 0x06000378 RID: 888 RVA: 0x00003D8C File Offset: 0x00001F8C
	public static bool smethod_2(string string_2, object object_4)
	{
		return Class30.smethod_0(string_2, object_4);
	}

	// Token: 0x14000004 RID: 4
	// (add) Token: 0x06000379 RID: 889 RVA: 0x0002AB3C File Offset: 0x00028D3C
	// (remove) Token: 0x0600037A RID: 890 RVA: 0x0002AB70 File Offset: 0x00028D70
	public static event Class35.Delegate5 Event_2
	{
		add
		{
			Class35.Delegate5 @delegate = Class35.object_2;
			Class35.Delegate5 delegate2;
			do
			{
				delegate2 = @delegate;
				Class35.Delegate5 value2 = (Class35.Delegate5)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange<Class35.Delegate5>(ref Class35.object_2, value2, delegate2);
			}
			while (@delegate != delegate2);
		}
		remove
		{
			Class35.Delegate5 @delegate = Class35.object_2;
			Class35.Delegate5 delegate2;
			do
			{
				delegate2 = @delegate;
				Class35.Delegate5 value2 = (Class35.Delegate5)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange<Class35.Delegate5>(ref Class35.object_2, value2, delegate2);
			}
			while (@delegate != delegate2);
		}
	}

	// Token: 0x0600037B RID: 891 RVA: 0x0002ABA4 File Offset: 0x00028DA4
	public static void smethod_3(byte[] byte_1)
	{
		byte[] byte_2 = byte_1;
		if (byte_1 == null || byte_1.Length == 0)
		{
			byte[] array = new byte[1];
			byte_2 = array;
		}
		new Class30().method_4(byte_2);
	}

	// Token: 0x14000005 RID: 5
	// (add) Token: 0x0600037C RID: 892 RVA: 0x0002ABD0 File Offset: 0x00028DD0
	// (remove) Token: 0x0600037D RID: 893 RVA: 0x0002AC04 File Offset: 0x00028E04
	public static event Class35.Delegate6 Event_3
	{
		add
		{
			Class35.Delegate6 @delegate = Class35.object_3;
			Class35.Delegate6 delegate2;
			do
			{
				delegate2 = @delegate;
				Class35.Delegate6 value2 = (Class35.Delegate6)Delegate.Combine(delegate2, value);
				@delegate = Interlocked.CompareExchange<Class35.Delegate6>(ref Class35.object_3, value2, delegate2);
			}
			while (@delegate != delegate2);
		}
		remove
		{
			Class35.Delegate6 @delegate = Class35.object_3;
			Class35.Delegate6 delegate2;
			do
			{
				delegate2 = @delegate;
				Class35.Delegate6 value2 = (Class35.Delegate6)Delegate.Remove(delegate2, value);
				@delegate = Interlocked.CompareExchange<Class35.Delegate6>(ref Class35.object_3, value2, delegate2);
			}
			while (@delegate != delegate2);
		}
	}

	// Token: 0x0600037E RID: 894 RVA: 0x00003D95 File Offset: 0x00001F95
	public static bool smethod_4(string string_2)
	{
		return Class30.smethod_1(string_2);
	}

	// Token: 0x0600037F RID: 895 RVA: 0x0002AC38 File Offset: 0x00028E38
	public static void smethod_5(string string_2)
	{
		FileStream fileStream = new FileStream(string_2, FileMode.Open, FileAccess.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		Class35.smethod_3(array);
	}

	// Token: 0x06000380 RID: 896 RVA: 0x00003D9D File Offset: 0x00001F9D
	public static bool smethod_6()
	{
		return Class35.bool_0;
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00003DA4 File Offset: 0x00001FA4
	public static void smethod_7(bool bool_6)
	{
		Class35.bool_0 = bool_6;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x00003DAC File Offset: 0x00001FAC
	public static string smethod_8()
	{
		return Class35.string_0;
	}

	// Token: 0x06000383 RID: 899 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public static void smethod_9(string string_2)
	{
		Class35.string_0 = string_2;
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x06000384 RID: 900 RVA: 0x00003DBB File Offset: 0x00001FBB
	// (set) Token: 0x06000385 RID: 901 RVA: 0x00003DC2 File Offset: 0x00001FC2
	public static string License_HardwareID
	{
		get
		{
			return Class35.string_1;
		}
		set
		{
			Class35.string_1 = value;
		}
	}

	// Token: 0x06000386 RID: 902 RVA: 0x00003DCA File Offset: 0x00001FCA
	public static bool smethod_10()
	{
		return Class35.bool_1;
	}

	// Token: 0x06000387 RID: 903 RVA: 0x00003DD1 File Offset: 0x00001FD1
	public static void smethod_11(bool bool_6)
	{
		Class35.bool_1 = bool_6;
	}

	// Token: 0x06000388 RID: 904 RVA: 0x00003DD9 File Offset: 0x00001FD9
	public static bool smethod_12()
	{
		return Class35.bool_2;
	}

	// Token: 0x06000389 RID: 905 RVA: 0x00003DE0 File Offset: 0x00001FE0
	public static void smethod_13(bool bool_6)
	{
		Class35.bool_2 = bool_6;
	}

	// Token: 0x0600038A RID: 906 RVA: 0x00003DE8 File Offset: 0x00001FE8
	public static bool smethod_14()
	{
		return Class35.bool_3;
	}

	// Token: 0x0600038B RID: 907 RVA: 0x00003DEF File Offset: 0x00001FEF
	public static void smethod_15(bool bool_6)
	{
		Class35.bool_3 = bool_6;
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00003DF7 File Offset: 0x00001FF7
	public static bool smethod_16()
	{
		return Class35.bool_4;
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00003DFE File Offset: 0x00001FFE
	public static void smethod_17(bool bool_6)
	{
		Class35.bool_4 = bool_6;
	}

	// Token: 0x0600038E RID: 910 RVA: 0x00003E06 File Offset: 0x00002006
	public static bool smethod_18()
	{
		return Class35.bool_5;
	}

	// Token: 0x0600038F RID: 911 RVA: 0x00003E0D File Offset: 0x0000200D
	public static void smethod_19(bool bool_6)
	{
		Class35.bool_5 = bool_6;
	}

	// Token: 0x06000390 RID: 912 RVA: 0x00003E15 File Offset: 0x00002015
	public static int smethod_20()
	{
		return Class35.int_0;
	}

	// Token: 0x06000391 RID: 913 RVA: 0x00003E1C File Offset: 0x0000201C
	public static void smethod_21(int int_5)
	{
		Class35.int_0 = int_5;
	}

	// Token: 0x06000392 RID: 914 RVA: 0x00003E24 File Offset: 0x00002024
	public static int smethod_22()
	{
		return Class35.int_1;
	}

	// Token: 0x06000393 RID: 915 RVA: 0x00003E2B File Offset: 0x0000202B
	public static void smethod_23(int int_5)
	{
		Class35.int_1 = int_5;
	}

	// Token: 0x06000394 RID: 916 RVA: 0x00003E33 File Offset: 0x00002033
	public static int smethod_24()
	{
		return Class35.int_4;
	}

	// Token: 0x06000395 RID: 917 RVA: 0x00003E3A File Offset: 0x0000203A
	public static void smethod_25(int int_5)
	{
		Class35.int_4 = int_5;
	}

	// Token: 0x06000396 RID: 918 RVA: 0x00003E42 File Offset: 0x00002042
	public static int smethod_26()
	{
		return Class35.int_2;
	}

	// Token: 0x06000397 RID: 919 RVA: 0x00003E49 File Offset: 0x00002049
	public static void smethod_27(int int_5)
	{
		Class35.int_2 = int_5;
	}

	// Token: 0x06000398 RID: 920 RVA: 0x00003E51 File Offset: 0x00002051
	public static int smethod_28()
	{
		return Class35.int_3;
	}

	// Token: 0x06000399 RID: 921 RVA: 0x00003E58 File Offset: 0x00002058
	public static void smethod_29(int int_5)
	{
		Class35.int_3 = int_5;
	}

	// Token: 0x0600039A RID: 922 RVA: 0x00003E60 File Offset: 0x00002060
	public static Enum9 smethod_30()
	{
		return Class35.enum9_0;
	}

	// Token: 0x0600039B RID: 923 RVA: 0x00003E67 File Offset: 0x00002067
	public static void smethod_31(Enum9 enum9_1)
	{
		Class35.enum9_0 = enum9_1;
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00003E6F File Offset: 0x0000206F
	public static byte[] smethod_32()
	{
		return Class35.byte_0;
	}

	// Token: 0x0600039D RID: 925 RVA: 0x00003E76 File Offset: 0x00002076
	public static void smethod_33(byte[] byte_1)
	{
		Class35.byte_0 = byte_1;
	}

	// Token: 0x0600039E RID: 926 RVA: 0x00003E7E File Offset: 0x0000207E
	public static DateTime smethod_34()
	{
		return Class35.dateTime_0;
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00003E85 File Offset: 0x00002085
	public static void smethod_35(DateTime dateTime_1)
	{
		Class35.dateTime_0 = dateTime_1;
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x00003E8D File Offset: 0x0000208D
	public static SortedList smethod_36()
	{
		return Class35.sortedList_0;
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x00003E94 File Offset: 0x00002094
	public static void smethod_37(SortedList sortedList_1)
	{
		Class35.sortedList_0 = sortedList_1;
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x00003E9C File Offset: 0x0000209C
	public static string smethod_38(bool bool_6, bool bool_7, bool bool_8, bool bool_9)
	{
		return Class10.smethod_11(bool_7, bool_9, bool_6, bool_8);
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x00002402 File Offset: 0x00000602
	private Class35()
	{
		Class8.ah6VSoGzeNXX5();
		base..ctor();
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x0002AC74 File Offset: 0x00028E74
	static Class35()
	{
		Class8.ah6VSoGzeNXX5();
		Class35.bool_0 = false;
		Class35.bool_1 = false;
		Class35.bool_2 = false;
		Class35.bool_3 = false;
		Class35.bool_4 = false;
		Class35.bool_5 = false;
		Class35.int_0 = 0;
		Class35.int_1 = 0;
		Class35.string_0 = "####-####-####-####-####";
		Class35.string_1 = "####-####-####-####-####";
		Class35.int_2 = 1;
		Class35.int_3 = 0;
		Class35.int_4 = 1;
		Class35.enum9_0 = Enum9.Trial_Days;
		Class35.dateTime_0 = DateTime.Now;
		Class35.sortedList_0 = new SortedList();
		Class35.byte_0 = new byte[0];
	}

	// Token: 0x040002B9 RID: 697
	private static bool bool_0;

	// Token: 0x040002BA RID: 698
	private static bool bool_1;

	// Token: 0x040002BB RID: 699
	private static bool bool_2;

	// Token: 0x040002BC RID: 700
	private static bool bool_3;

	// Token: 0x040002BD RID: 701
	private static bool bool_4;

	// Token: 0x040002BE RID: 702
	private static bool bool_5;

	// Token: 0x040002BF RID: 703
	private static int int_0;

	// Token: 0x040002C0 RID: 704
	private static int int_1;

	// Token: 0x040002C1 RID: 705
	private static string string_0;

	// Token: 0x040002C2 RID: 706
	private static string string_1;

	// Token: 0x040002C3 RID: 707
	private static int int_2;

	// Token: 0x040002C4 RID: 708
	private static int int_3;

	// Token: 0x040002C5 RID: 709
	private static int int_4;

	// Token: 0x040002C6 RID: 710
	private static Enum9 enum9_0;

	// Token: 0x040002C7 RID: 711
	private static DateTime dateTime_0;

	// Token: 0x040002C8 RID: 712
	private static SortedList sortedList_0;

	// Token: 0x040002C9 RID: 713
	private static byte[] byte_0;

	// Token: 0x040002CA RID: 714
	private static object object_0;

	// Token: 0x040002CB RID: 715
	private static object object_1;

	// Token: 0x040002CC RID: 716
	private static object object_2;

	// Token: 0x040002CD RID: 717
	private static object object_3;

	// Token: 0x02000055 RID: 85
	// (Invoke) Token: 0x060003A6 RID: 934
	public delegate string Delegate3();

	// Token: 0x02000056 RID: 86
	// (Invoke) Token: 0x060003AA RID: 938
	public delegate bool Delegate4(string harwareID, string confirmationCode);

	// Token: 0x02000057 RID: 87
	// (Invoke) Token: 0x060003AE RID: 942
	public delegate void Delegate5(byte[] license);

	// Token: 0x02000058 RID: 88
	// (Invoke) Token: 0x060003B2 RID: 946
	public delegate bool Delegate6(string code);
}
