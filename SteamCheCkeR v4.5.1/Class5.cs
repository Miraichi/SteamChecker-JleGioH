using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

// Token: 0x02000021 RID: 33
internal class Class5
{
	// Token: 0x06000190 RID: 400 RVA: 0x0001263C File Offset: 0x0001083C
	static Class5()
	{
		Class5.assembly_0 = typeof(Class5).Assembly;
		Class5.uint_0 = new uint[]
		{
			3614090360U,
			3905402710U,
			606105819U,
			3250441966U,
			4118548399U,
			1200080426U,
			2821735955U,
			4249261313U,
			1770035416U,
			2336552879U,
			4294925233U,
			2304563134U,
			1804603682U,
			4254626195U,
			2792965006U,
			1236535329U,
			4129170786U,
			3225465664U,
			643717713U,
			3921069994U,
			3593408605U,
			38016083U,
			3634488961U,
			3889429448U,
			568446438U,
			3275163606U,
			4107603335U,
			1163531501U,
			2850285829U,
			4243563512U,
			1735328473U,
			2368359562U,
			4294588738U,
			2272392833U,
			1839030562U,
			4259657740U,
			2763975236U,
			1272893353U,
			4139469664U,
			3200236656U,
			681279174U,
			3936430074U,
			3572445317U,
			76029189U,
			3654602809U,
			3873151461U,
			530742520U,
			3299628645U,
			4096336452U,
			1126891415U,
			2878612391U,
			4237533241U,
			1700485571U,
			2399980690U,
			4293915773U,
			2240044497U,
			1873313359U,
			4264355552U,
			2734768916U,
			1309151649U,
			4149444226U,
			3174756917U,
			718787259U,
			3951481745U
		};
		Class5.bool_4 = false;
		Class5.bool_0 = false;
		Class5.byte_3 = new byte[0];
		Class5.byte_2 = new byte[0];
		Class5.byte_1 = new byte[0];
		Class5.byte_0 = new byte[0];
		Class5.intptr_1 = IntPtr.Zero;
		Class5.intptr_2 = IntPtr.Zero;
		Class5.string_0 = new string[0];
		Class5.int_1 = new int[0];
		Class5.int_4 = 1;
		Class5.bool_1 = false;
		Class5.sortedList_0 = new SortedList();
		Class5.int_3 = 0;
		Class5.long_1 = 0L;
		Class5.delegate1_0 = null;
		Class5.delegate1_1 = null;
		Class5.long_0 = 0L;
		Class5.int_2 = 0;
		Class5.bool_6 = false;
		Class5.bool_2 = false;
		Class5.int_0 = 0;
		Class5.intptr_0 = IntPtr.Zero;
		Class5.bool_3 = false;
		Class5.hashtable_0 = new Hashtable();
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00002E41 File Offset: 0x00001041
	private void yeNVSoGb7DcSH()
	{
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00012754 File Offset: 0x00010954
	internal static byte[] smethod_0(object object_0)
	{
		uint[] array = new uint[16];
		int num = 448 - object_0.Length * 8 % 512;
		uint num2 = (uint)((num + 512) % 512);
		if (num2 == 0U)
		{
			num2 = 512U;
		}
		uint num3 = (uint)((long)object_0.Length + (long)((ulong)(num2 / 8U)) + 8L);
		ulong num4 = (ulong)((long)object_0.Length * 8L);
		byte[] array2 = new byte[num3];
		for (int i = 0; i < object_0.Length; i++)
		{
			array2[i] = object_0[i];
		}
		byte[] array3 = array2;
		int num5 = object_0.Length;
		array3[num5] |= 128;
		for (int j = 8; j > 0; j--)
		{
			array2[(int)(checked((IntPtr)(unchecked((ulong)num3 - (ulong)((long)j)))))] = (byte)(num4 >> (8 - j) * 8 & 255UL);
		}
		uint num6 = (uint)(array2.Length * 8 / 32);
		uint num7 = 1732584193U;
		uint num8 = 4023233417U;
		uint num9 = 2562383102U;
		uint num10 = 271733878U;
		for (uint num11 = 0U; num11 < num6 / 16U; num11 += 1U)
		{
			uint num12 = num11 << 6;
			for (uint num13 = 0U; num13 < 61U; num13 += 4U)
			{
				array[(int)((UIntPtr)(num13 >> 2))] = (uint)((int)array2[(int)((UIntPtr)(num12 + (num13 + 3U)))] << 24 | (int)array2[(int)((UIntPtr)(num12 + (num13 + 2U)))] << 16 | (int)array2[(int)((UIntPtr)(num12 + (num13 + 1U)))] << 8 | (int)array2[(int)((UIntPtr)(num12 + num13))]);
			}
			uint num14 = num7;
			uint num15 = num8;
			uint num16 = num9;
			uint num17 = num10;
			Class5.smethod_1(ref num7, num8, num9, num10, 0U, 7, 1U, array);
			Class5.smethod_1(ref num10, num7, num8, num9, 1U, 12, 2U, array);
			Class5.smethod_1(ref num9, num10, num7, num8, 2U, 17, 3U, array);
			Class5.smethod_1(ref num8, num9, num10, num7, 3U, 22, 4U, array);
			Class5.smethod_1(ref num7, num8, num9, num10, 4U, 7, 5U, array);
			Class5.smethod_1(ref num10, num7, num8, num9, 5U, 12, 6U, array);
			Class5.smethod_1(ref num9, num10, num7, num8, 6U, 17, 7U, array);
			Class5.smethod_1(ref num8, num9, num10, num7, 7U, 22, 8U, array);
			Class5.smethod_1(ref num7, num8, num9, num10, 8U, 7, 9U, array);
			Class5.smethod_1(ref num10, num7, num8, num9, 9U, 12, 10U, array);
			Class5.smethod_1(ref num9, num10, num7, num8, 10U, 17, 11U, array);
			Class5.smethod_1(ref num8, num9, num10, num7, 11U, 22, 12U, array);
			Class5.smethod_1(ref num7, num8, num9, num10, 12U, 7, 13U, array);
			Class5.smethod_1(ref num10, num7, num8, num9, 13U, 12, 14U, array);
			Class5.smethod_1(ref num9, num10, num7, num8, 14U, 17, 15U, array);
			Class5.smethod_1(ref num8, num9, num10, num7, 15U, 22, 16U, array);
			Class5.smethod_2(ref num7, num8, num9, num10, 1U, 5, 17U, array);
			Class5.smethod_2(ref num10, num7, num8, num9, 6U, 9, 18U, array);
			Class5.smethod_2(ref num9, num10, num7, num8, 11U, 14, 19U, array);
			Class5.smethod_2(ref num8, num9, num10, num7, 0U, 20, 20U, array);
			Class5.smethod_2(ref num7, num8, num9, num10, 5U, 5, 21U, array);
			Class5.smethod_2(ref num10, num7, num8, num9, 10U, 9, 22U, array);
			Class5.smethod_2(ref num9, num10, num7, num8, 15U, 14, 23U, array);
			Class5.smethod_2(ref num8, num9, num10, num7, 4U, 20, 24U, array);
			Class5.smethod_2(ref num7, num8, num9, num10, 9U, 5, 25U, array);
			Class5.smethod_2(ref num10, num7, num8, num9, 14U, 9, 26U, array);
			Class5.smethod_2(ref num9, num10, num7, num8, 3U, 14, 27U, array);
			Class5.smethod_2(ref num8, num9, num10, num7, 8U, 20, 28U, array);
			Class5.smethod_2(ref num7, num8, num9, num10, 13U, 5, 29U, array);
			Class5.smethod_2(ref num10, num7, num8, num9, 2U, 9, 30U, array);
			Class5.smethod_2(ref num9, num10, num7, num8, 7U, 14, 31U, array);
			Class5.smethod_2(ref num8, num9, num10, num7, 12U, 20, 32U, array);
			Class5.smethod_3(ref num7, num8, num9, num10, 5U, 4, 33U, array);
			Class5.smethod_3(ref num10, num7, num8, num9, 8U, 11, 34U, array);
			Class5.smethod_3(ref num9, num10, num7, num8, 11U, 16, 35U, array);
			Class5.smethod_3(ref num8, num9, num10, num7, 14U, 23, 36U, array);
			Class5.smethod_3(ref num7, num8, num9, num10, 1U, 4, 37U, array);
			Class5.smethod_3(ref num10, num7, num8, num9, 4U, 11, 38U, array);
			Class5.smethod_3(ref num9, num10, num7, num8, 7U, 16, 39U, array);
			Class5.smethod_3(ref num8, num9, num10, num7, 10U, 23, 40U, array);
			Class5.smethod_3(ref num7, num8, num9, num10, 13U, 4, 41U, array);
			Class5.smethod_3(ref num10, num7, num8, num9, 0U, 11, 42U, array);
			Class5.smethod_3(ref num9, num10, num7, num8, 3U, 16, 43U, array);
			Class5.smethod_3(ref num8, num9, num10, num7, 6U, 23, 44U, array);
			Class5.smethod_3(ref num7, num8, num9, num10, 9U, 4, 45U, array);
			Class5.smethod_3(ref num10, num7, num8, num9, 12U, 11, 46U, array);
			Class5.smethod_3(ref num9, num10, num7, num8, 15U, 16, 47U, array);
			Class5.smethod_3(ref num8, num9, num10, num7, 2U, 23, 48U, array);
			Class5.smethod_4(ref num7, num8, num9, num10, 0U, 6, 49U, array);
			Class5.smethod_4(ref num10, num7, num8, num9, 7U, 10, 50U, array);
			Class5.smethod_4(ref num9, num10, num7, num8, 14U, 15, 51U, array);
			Class5.smethod_4(ref num8, num9, num10, num7, 5U, 21, 52U, array);
			Class5.smethod_4(ref num7, num8, num9, num10, 12U, 6, 53U, array);
			Class5.smethod_4(ref num10, num7, num8, num9, 3U, 10, 54U, array);
			Class5.smethod_4(ref num9, num10, num7, num8, 10U, 15, 55U, array);
			Class5.smethod_4(ref num8, num9, num10, num7, 1U, 21, 56U, array);
			Class5.smethod_4(ref num7, num8, num9, num10, 8U, 6, 57U, array);
			Class5.smethod_4(ref num10, num7, num8, num9, 15U, 10, 58U, array);
			Class5.smethod_4(ref num9, num10, num7, num8, 6U, 15, 59U, array);
			Class5.smethod_4(ref num8, num9, num10, num7, 13U, 21, 60U, array);
			Class5.smethod_4(ref num7, num8, num9, num10, 4U, 6, 61U, array);
			Class5.smethod_4(ref num10, num7, num8, num9, 11U, 10, 62U, array);
			Class5.smethod_4(ref num9, num10, num7, num8, 2U, 15, 63U, array);
			Class5.smethod_4(ref num8, num9, num10, num7, 9U, 21, 64U, array);
			num7 += num14;
			num8 += num15;
			num9 += num16;
			num10 += num17;
		}
		byte[] array4 = new byte[16];
		Array.Copy(BitConverter.GetBytes(num7), 0, array4, 0, 4);
		Array.Copy(BitConverter.GetBytes(num8), 0, array4, 4, 4);
		Array.Copy(BitConverter.GetBytes(num9), 0, array4, 8, 4);
		Array.Copy(BitConverter.GetBytes(num10), 0, array4, 12, 4);
		return array4;
	}

	// Token: 0x06000193 RID: 403 RVA: 0x00002E43 File Offset: 0x00001043
	private static void smethod_1(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_0)
	{
		uint_1 = uint_2 + Class5.smethod_5(uint_1 + ((uint_2 & uint_3) | (~uint_2 & uint_4)) + object_0[(int)((UIntPtr)uint_5)] + Class5.uint_0[(int)((UIntPtr)(uint_6 - 1U))], ushort_0);
	}

	// Token: 0x06000194 RID: 404 RVA: 0x00002E6E File Offset: 0x0000106E
	private static void smethod_2(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_0)
	{
		uint_1 = uint_2 + Class5.smethod_5(uint_1 + ((uint_2 & uint_4) | (uint_3 & ~uint_4)) + object_0[(int)((UIntPtr)uint_5)] + Class5.uint_0[(int)((UIntPtr)(uint_6 - 1U))], ushort_0);
	}

	// Token: 0x06000195 RID: 405 RVA: 0x00002E99 File Offset: 0x00001099
	private static void smethod_3(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_0)
	{
		uint_1 = uint_2 + Class5.smethod_5(uint_1 + (uint_2 ^ uint_3 ^ uint_4) + object_0[(int)((UIntPtr)uint_5)] + Class5.uint_0[(int)((UIntPtr)(uint_6 - 1U))], ushort_0);
	}

	// Token: 0x06000196 RID: 406 RVA: 0x00002EC1 File Offset: 0x000010C1
	private static void smethod_4(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_0)
	{
		uint_1 = uint_2 + Class5.smethod_5(uint_1 + (uint_3 ^ (uint_2 | ~uint_4)) + object_0[(int)((UIntPtr)uint_5)] + Class5.uint_0[(int)((UIntPtr)(uint_6 - 1U))], ushort_0);
	}

	// Token: 0x06000197 RID: 407 RVA: 0x00002EEA File Offset: 0x000010EA
	private static uint smethod_5(uint uint_1, ushort ushort_0)
	{
		return uint_1 >> (int)(32 - ushort_0) | uint_1 << (int)ushort_0;
	}

	// Token: 0x06000198 RID: 408 RVA: 0x00002EFC File Offset: 0x000010FC
	internal static bool smethod_6()
	{
		if (!Class5.bool_4)
		{
			Class5.smethod_8();
			Class5.bool_4 = true;
		}
		return Class5.bool_0;
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00012DF8 File Offset: 0x00010FF8
	internal static SymmetricAlgorithm smethod_7()
	{
		SymmetricAlgorithm result = null;
		if (Class5.smethod_6())
		{
			result = new AesCryptoServiceProvider();
		}
		else
		{
			try
			{
				result = new RijndaelManaged();
			}
			catch
			{
				result = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
			}
		}
		return result;
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00012E4C File Offset: 0x0001104C
	internal static void smethod_8()
	{
		try
		{
			Class5.bool_0 = CryptoConfig.AllowOnlyFipsAlgorithms;
		}
		catch
		{
		}
	}

	// Token: 0x0600019B RID: 411 RVA: 0x00002F15 File Offset: 0x00001115
	internal static byte[] smethod_9(byte[] byte_4)
	{
		if (!Class5.smethod_6())
		{
			return new MD5CryptoServiceProvider().ComputeHash(byte_4);
		}
		return Class5.smethod_0(byte_4);
	}

	// Token: 0x0600019C RID: 412 RVA: 0x00012E7C File Offset: 0x0001107C
	[Class5.Attribute0(typeof(Class5.Attribute0.Class6<object>[]))]
	internal static bool smethod_10(int int_5)
	{
		if (Class5.byte_2.Length == 0)
		{
			BinaryReader binaryReader = new BinaryReader(Class5.assembly_0.GetManifestResourceStream("{11111-22222-20001-00000}"));
			binaryReader.BaseStream.Position = 0L;
			RSACryptoServiceProvider.UseMachineKeyStore = true;
			byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
			byte[] rgbKey = new Class5().method_2();
			byte[] array2 = new Class5().method_1();
			byte[] publicKeyToken = Class5.assembly_0.GetName().GetPublicKeyToken();
			if (publicKeyToken != null && publicKeyToken.Length > 0)
			{
				array2[1] = publicKeyToken[0];
				array2[3] = publicKeyToken[1];
				array2[5] = publicKeyToken[2];
				array2[7] = publicKeyToken[3];
				array2[9] = publicKeyToken[4];
				array2[11] = publicKeyToken[5];
				array2[13] = publicKeyToken[6];
				array2[15] = publicKeyToken[7];
			}
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(rgbKey, array2);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			Class5.byte_2 = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			binaryReader.Close();
		}
		if (Class5.byte_3.Length == 0)
		{
			Class5.byte_3 = Class5.cgewftHaHH(Class5.smethod_17(Class5.assembly_0).ToString());
		}
		int num = 0;
		try
		{
			num = BitConverter.ToInt32(new byte[]
			{
				Class5.byte_2[int_5],
				Class5.byte_2[int_5 + 1],
				Class5.byte_2[int_5 + 2],
				Class5.byte_2[int_5 + 3]
			}, 0);
		}
		catch
		{
		}
		try
		{
			if (Class5.byte_3[num] == 128)
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	// Token: 0x0600019D RID: 413 RVA: 0x0001304C File Offset: 0x0001124C
	[Class5.Attribute0(typeof(Class5.Attribute0.Class6<object>[]))]
	static string smethod_11(int int_5)
	{
		if (Class5.byte_1.Length == 0)
		{
			BinaryReader binaryReader = new BinaryReader(Class5.assembly_0.GetManifestResourceStream("fg8CBvb4d8j6mABaLh.VFBXX2nihi31ClXmC2"));
			binaryReader.BaseStream.Position = 0L;
			RSACryptoServiceProvider.UseMachineKeyStore = true;
			byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
			binaryReader.Close();
			byte[] array2 = new byte[32];
			array2[0] = 145;
			array2[0] = 100;
			array2[0] = 133;
			array2[0] = 100;
			array2[0] = 73;
			array2[0] = 94;
			array2[1] = 103;
			array2[1] = 58;
			array2[1] = 105;
			array2[1] = 94;
			array2[1] = 198;
			array2[2] = 164;
			array2[2] = 106;
			array2[2] = 165;
			array2[2] = 41;
			array2[3] = 94;
			array2[3] = 139;
			array2[3] = 205;
			array2[4] = 105;
			array2[4] = 84;
			array2[4] = 187;
			array2[4] = 90;
			array2[4] = 203;
			array2[5] = 84;
			array2[5] = 47;
			array2[5] = 36;
			array2[6] = 84;
			array2[6] = 116;
			array2[6] = 54;
			array2[6] = 51;
			array2[6] = 39;
			array2[6] = 26;
			array2[7] = 134;
			array2[7] = 158;
			array2[7] = 151;
			array2[7] = 7;
			array2[7] = 13;
			array2[8] = 21;
			array2[8] = 144;
			array2[8] = 169;
			array2[9] = 153;
			array2[9] = 88;
			array2[9] = 192;
			array2[10] = 124;
			array2[10] = 165;
			array2[10] = 5;
			array2[11] = 220;
			array2[11] = 117;
			array2[11] = 73;
			array2[11] = 102;
			array2[11] = 161;
			array2[11] = 91;
			array2[12] = 144;
			array2[12] = 137;
			array2[12] = 251;
			array2[13] = 93;
			array2[13] = 143;
			array2[13] = 101;
			array2[13] = 120;
			array2[13] = 40;
			array2[13] = 88;
			array2[14] = 93;
			array2[14] = 217;
			array2[14] = 196;
			array2[14] = 156;
			array2[14] = 238;
			array2[15] = 158;
			array2[15] = 64;
			array2[15] = 124;
			array2[15] = 104;
			array2[15] = 121;
			array2[16] = 151;
			array2[16] = 141;
			array2[16] = 144;
			array2[17] = 124;
			array2[17] = 126;
			array2[17] = 200;
			array2[17] = 85;
			array2[17] = 103;
			array2[17] = 239;
			array2[18] = 142;
			array2[18] = 42;
			array2[18] = 174;
			array2[19] = 135;
			array2[19] = 11;
			array2[19] = 120;
			array2[19] = 137;
			array2[19] = 183;
			array2[20] = 49;
			array2[20] = 92;
			array2[20] = 66;
			array2[21] = 88;
			array2[21] = 123;
			array2[21] = 57;
			array2[22] = 136;
			array2[22] = 113;
			array2[22] = 89;
			array2[23] = 148;
			array2[23] = 28;
			array2[23] = 212;
			array2[24] = 36;
			array2[24] = 168;
			array2[24] = 97;
			array2[24] = 58;
			array2[25] = 92;
			array2[25] = 151;
			array2[25] = 106;
			array2[25] = 178;
			array2[25] = 166;
			array2[26] = 97;
			array2[26] = 53;
			array2[26] = 122;
			array2[26] = 118;
			array2[26] = 85;
			array2[26] = 133;
			array2[27] = 140;
			array2[27] = 150;
			array2[27] = 108;
			array2[28] = 111;
			array2[28] = 200;
			array2[28] = 39;
			array2[29] = 120;
			array2[29] = 104;
			array2[29] = 134;
			array2[29] = 129;
			array2[29] = 162;
			array2[29] = 112;
			array2[30] = 109;
			array2[30] = 139;
			array2[30] = 31;
			array2[30] = 94;
			array2[30] = 47;
			array2[31] = 100;
			array2[31] = 48;
			array2[31] = 110;
			array2[31] = 139;
			array2[31] = 44;
			byte[] array3 = array2;
			byte[] array4 = new byte[16];
			array4[0] = 145;
			array4[0] = 105;
			array4[0] = 138;
			array4[0] = 144;
			array4[0] = 246;
			array4[1] = 142;
			array4[1] = 92;
			array4[1] = 108;
			array4[1] = 87;
			array4[1] = 109;
			array4[2] = 188;
			array4[2] = 106;
			array4[2] = 208;
			array4[3] = 86;
			array4[3] = 119;
			array4[3] = 166;
			array4[3] = 141;
			array4[3] = 187;
			array4[4] = 85;
			array4[4] = 84;
			array4[4] = 166;
			array4[4] = 92;
			array4[5] = 128;
			array4[5] = 29;
			array4[5] = 85;
			array4[5] = 104;
			array4[5] = 176;
			array4[5] = 15;
			array4[6] = 95;
			array4[6] = 113;
			array4[6] = 222;
			array4[7] = 118;
			array4[7] = 39;
			array4[7] = 160;
			array4[7] = 128;
			array4[7] = 107;
			array4[7] = 4;
			array4[8] = 85;
			array4[8] = 152;
			array4[8] = 131;
			array4[8] = 10;
			array4[9] = 142;
			array4[9] = 122;
			array4[9] = 16;
			array4[9] = 124;
			array4[9] = 165;
			array4[9] = 130;
			array4[10] = 152;
			array4[10] = 130;
			array4[10] = 10;
			array4[11] = 73;
			array4[11] = 101;
			array4[11] = 156;
			array4[11] = 194;
			array4[11] = 22;
			array4[12] = 108;
			array4[12] = 110;
			array4[12] = 150;
			array4[12] = 101;
			array4[12] = 120;
			array4[12] = 205;
			array4[13] = 100;
			array4[13] = 121;
			array4[13] = 253;
			array4[14] = 217;
			array4[14] = 196;
			array4[14] = 156;
			array4[14] = 119;
			array4[15] = 207;
			array4[15] = 15;
			array4[15] = 137;
			array4[15] = 139;
			array4[15] = 89;
			byte[] array5 = array4;
			Array.Reverse(array5);
			byte[] publicKeyToken = Class5.assembly_0.GetName().GetPublicKeyToken();
			if (publicKeyToken != null && publicKeyToken.Length > 0)
			{
				array5[1] = publicKeyToken[0];
				array5[3] = publicKeyToken[1];
				array5[5] = publicKeyToken[2];
				array5[7] = publicKeyToken[3];
				array5[9] = publicKeyToken[4];
				array5[11] = publicKeyToken[5];
				array5[13] = publicKeyToken[6];
				array5[15] = publicKeyToken[7];
			}
			for (int i = 0; i < array5.Length; i++)
			{
				array3[i] ^= array5[i];
			}
			if (int_5 == -1)
			{
				SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
				symmetricAlgorithm.Mode = CipherMode.CBC;
				ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array3, array5);
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				Class5.byte_1 = memoryStream.ToArray();
				memoryStream.Close();
				cryptoStream.Close();
				array = Class5.byte_1;
			}
			int num = array.Length % 4;
			int num2 = array.Length / 4;
			byte[] array6 = new byte[array.Length];
			int num3 = array3.Length / 4;
			uint num4 = 0U;
			if (num > 0)
			{
				num2++;
			}
			for (int j = 0; j < num2; j++)
			{
				int num5 = j % num3;
				int num6 = j * 4;
				uint num7 = (uint)(num5 * 4);
				uint num8 = (uint)((int)array3[(int)((UIntPtr)(num7 + 3U))] << 24 | (int)array3[(int)((UIntPtr)(num7 + 2U))] << 16 | (int)array3[(int)((UIntPtr)(num7 + 1U))] << 8 | (int)array3[(int)((UIntPtr)num7)]);
				uint num9 = 255U;
				int num10 = 0;
				uint num11;
				if (j == num2 - 1 && num > 0)
				{
					num11 = 0U;
					for (int k = 0; k < num; k++)
					{
						if (k > 0)
						{
							num11 <<= 8;
						}
						num11 |= (uint)array[array.Length - (1 + k)];
					}
					num4 += num8;
				}
				else
				{
					num7 = (uint)num6;
					num11 = (uint)((int)array[(int)((UIntPtr)(num7 + 3U))] << 24 | (int)array[(int)((UIntPtr)(num7 + 2U))] << 16 | (int)array[(int)((UIntPtr)(num7 + 1U))] << 8 | (int)array[(int)((UIntPtr)num7)]);
					num4 += num8;
				}
				uint num12 = num4;
				uint num13 = num4;
				num13 ^= num13 >> 29;
				num13 += 2223296986U;
				num13 ^= num13 << 1;
				num13 += 1685712301U;
				num13 ^= num13 >> 15;
				num13 += 2889850832U;
				num13 = 214797007U - num13;
				num4 = num12 + (uint)num13;
				if (j == num2 - 1 && num > 0)
				{
					uint num14 = num4 ^ num11;
					for (int l = 0; l < num; l++)
					{
						if (l > 0)
						{
							num9 <<= 8;
							num10 += 8;
						}
						array6[num6 + l] = (byte)((num14 & num9) >> num10);
					}
				}
				else
				{
					uint num15 = num4 ^ num11;
					array6[num6] = (byte)(num15 & 255U);
					array6[num6 + 1] = (byte)((num15 & 65280U) >> 8);
					array6[num6 + 2] = (byte)((num15 & 16711680U) >> 16);
					array6[num6 + 3] = (byte)((num15 & 4278190080U) >> 24);
				}
			}
			Class5.byte_1 = array6;
		}
		int count = BitConverter.ToInt32(Class5.byte_1, int_5);
		try
		{
			return Encoding.Unicode.GetString(Class5.byte_1, int_5 + 4, count);
		}
		catch
		{
		}
		return "";
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00013CA4 File Offset: 0x00011EA4
	[Class5.Attribute0(typeof(Class5.Attribute0.Class6<object>[]))]
	internal static string smethod_12(string string_1)
	{
		"{11111-22222-50001-00000}".Trim();
		byte[] array = Convert.FromBase64String(string_1);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	// Token: 0x0600019F RID: 415
	[DllImport("kernel32.dll")]
	private static extern void RtlZeroMemory(IntPtr intptr_3, uint uint_1);

	// Token: 0x060001A0 RID: 416
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern int VirtualProtect(ref IntPtr intptr_3, int int_5, int int_6, ref int int_7);

	// Token: 0x060001A1 RID: 417
	[DllImport("kernel32.dll")]
	public static extern IntPtr FindResource(IntPtr intptr_3, string string_1, uint uint_1);

	// Token: 0x060001A2 RID: 418
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr VirtualAlloc(IntPtr intptr_3, uint uint_1, uint uint_2, uint uint_3);

	// Token: 0x060001A3 RID: 419 RVA: 0x00013CD4 File Offset: 0x00011ED4
	internal static uint smethod_13(IntPtr intptr_3, IntPtr intptr_4, IntPtr intptr_5, [MarshalAs(UnmanagedType.U4)] uint uint_1, IntPtr intptr_6, ref uint uint_2)
	{
		IntPtr ptr = intptr_5;
		if (Class5.bool_5)
		{
			ptr = intptr_4;
		}
		long num;
		if (IntPtr.Size == 4)
		{
			num = (long)Marshal.ReadInt32(ptr, IntPtr.Size * 2);
		}
		else
		{
			num = Marshal.ReadInt64(ptr, IntPtr.Size * 2);
		}
		object obj = Class5.hashtable_0[num];
		if (obj == null)
		{
			return Class5.delegate1_0(intptr_3, intptr_4, intptr_5, uint_1, intptr_6, ref uint_2);
		}
		Class5.Struct0 @struct = (Class5.Struct0)obj;
		IntPtr intPtr = Marshal.AllocCoTaskMem(@struct.byte_0.Length);
		Marshal.Copy(@struct.byte_0, 0, intPtr, @struct.byte_0.Length);
		if (@struct.bool_0)
		{
			intptr_6 = intPtr;
			uint_2 = (uint)@struct.byte_0.Length;
			Class5.VirtualProtect_1(intptr_6, @struct.byte_0.Length, 64, ref Class5.int_0);
			return 0U;
		}
		Marshal.WriteIntPtr(ptr, IntPtr.Size * 2, intPtr);
		Marshal.WriteInt32(ptr, IntPtr.Size * 3, @struct.byte_0.Length);
		uint result = 0U;
		if (uint_1 == 216669565U && !Class5.bool_3)
		{
			Class5.bool_3 = true;
		}
		else
		{
			result = Class5.delegate1_0(intptr_3, intptr_4, intptr_5, uint_1, intptr_6, ref uint_2);
		}
		return result;
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00013E00 File Offset: 0x00012000
	private static void smethod_14()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00013E2C File Offset: 0x0001202C
	private static Delegate smethod_15(IntPtr intptr_3, Type type_0)
	{
		return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
		{
			typeof(IntPtr),
			typeof(Type)
		}).Invoke(null, new object[]
		{
			intptr_3,
			type_0
		});
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x00013E94 File Offset: 0x00012094
	unsafe static void smethod_16()
	{
		if (!Class5.bool_1)
		{
			Class5.bool_1 = true;
			long num = 0L;
			Marshal.ReadIntPtr(new IntPtr((void*)(&num)), 0);
			Marshal.ReadInt32(new IntPtr((void*)(&num)), 0);
			Marshal.ReadInt64(new IntPtr((void*)(&num)), 0);
			Marshal.WriteIntPtr(new IntPtr((void*)(&num)), 0, IntPtr.Zero);
			Marshal.WriteInt32(new IntPtr((void*)(&num)), 0, 0);
			Marshal.WriteInt64(new IntPtr((void*)(&num)), 0, 0L);
			byte[] array = new byte[1];
			Marshal.Copy(array, 0, Marshal.AllocCoTaskMem(8), 1);
			Class5.smethod_14();
			if (!(Class5.FindResource(Process.GetCurrentProcess().MainModule.BaseAddress, "__", 10U) != IntPtr.Zero))
			{
				return;
			}
			if (IntPtr.Size == 4 && Type.GetType("System.Reflection.ReflectionContext", false) != null)
			{
				ProcessModuleCollection modules = Process.GetCurrentProcess().Modules;
				foreach (object obj in modules)
				{
					ProcessModule processModule = (ProcessModule)obj;
					if (processModule.ModuleName.ToLower() == "clrjit.dll")
					{
						Version v = new Version(processModule.FileVersionInfo.ProductMajorPart, processModule.FileVersionInfo.ProductMinorPart, processModule.FileVersionInfo.ProductBuildPart, processModule.FileVersionInfo.ProductPrivatePart);
						Version v2 = new Version(4, 0, 30319, 17020);
						Version v3 = new Version(4, 0, 30319, 17921);
						if (v >= v2 && v < v3)
						{
							Class5.bool_5 = true;
							break;
						}
					}
				}
			}
			BinaryReader binaryReader = new BinaryReader(Class5.assembly_0.GetManifestResourceStream("CoVFX35X5sKg66HyVW.spCryvp3XxUArIZyeT"));
			binaryReader.BaseStream.Position = 0L;
			byte[] array2 = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
			byte[] array3 = new byte[32];
			array3[0] = 118;
			array3[0] = 116;
			array3[0] = 169;
			array3[0] = 253;
			array3[1] = 41;
			array3[1] = 63;
			array3[1] = 92;
			array3[1] = 91;
			array3[1] = 152;
			array3[2] = 110;
			array3[2] = 111;
			array3[2] = 162;
			array3[2] = 135;
			array3[2] = 23;
			array3[2] = 90;
			array3[3] = 161;
			array3[3] = 181;
			array3[3] = 149;
			array3[3] = 122;
			array3[3] = 145;
			array3[4] = 137;
			array3[4] = 130;
			array3[4] = 155;
			array3[4] = 128;
			array3[4] = 171;
			array3[5] = 137;
			array3[5] = 33;
			array3[5] = 172;
			array3[6] = 34;
			array3[6] = 213;
			array3[6] = 170;
			array3[7] = 159;
			array3[7] = 62;
			array3[7] = 99;
			array3[8] = 140;
			array3[8] = 110;
			array3[8] = 126;
			array3[8] = 133;
			array3[8] = 185;
			array3[8] = 110;
			array3[9] = 110;
			array3[9] = 128;
			array3[9] = 169;
			array3[9] = 116;
			array3[9] = 95;
			array3[10] = 152;
			array3[10] = 125;
			array3[10] = 161;
			array3[10] = 162;
			array3[10] = 106;
			array3[11] = 163;
			array3[11] = 84;
			array3[11] = 178;
			array3[12] = 166;
			array3[12] = 98;
			array3[12] = 209;
			array3[12] = 126;
			array3[12] = 130;
			array3[12] = 65;
			array3[13] = 102;
			array3[13] = 107;
			array3[13] = 116;
			array3[13] = 36;
			array3[14] = 97;
			array3[14] = 93;
			array3[14] = 163;
			array3[14] = 65;
			array3[15] = 168;
			array3[15] = 164;
			array3[15] = 174;
			array3[16] = 114;
			array3[16] = 130;
			array3[16] = 58;
			array3[16] = 152;
			array3[16] = 155;
			array3[16] = 52;
			array3[17] = 165;
			array3[17] = 119;
			array3[17] = 135;
			array3[17] = 112;
			array3[17] = 93;
			array3[17] = 209;
			array3[18] = 182;
			array3[18] = 135;
			array3[18] = 166;
			array3[18] = 114;
			array3[18] = 108;
			array3[18] = 101;
			array3[19] = 39;
			array3[19] = 196;
			array3[19] = 140;
			array3[19] = 106;
			array3[19] = 129;
			array3[19] = 237;
			array3[20] = 137;
			array3[20] = 126;
			array3[20] = 196;
			array3[20] = 187;
			array3[20] = 167;
			array3[21] = 88;
			array3[21] = 203;
			array3[21] = 135;
			array3[21] = 189;
			array3[21] = 103;
			array3[22] = 120;
			array3[22] = 74;
			array3[22] = 151;
			array3[22] = 130;
			array3[22] = 131;
			array3[22] = 115;
			array3[23] = 116;
			array3[23] = 126;
			array3[23] = 140;
			array3[23] = 126;
			array3[24] = 88;
			array3[24] = 136;
			array3[24] = 241;
			array3[25] = 63;
			array3[25] = 158;
			array3[25] = 154;
			array3[26] = 160;
			array3[26] = 222;
			array3[26] = 27;
			array3[26] = 28;
			array3[26] = 237;
			array3[27] = 134;
			array3[27] = 96;
			array3[27] = 89;
			array3[27] = 197;
			array3[28] = 123;
			array3[28] = 118;
			array3[28] = 199;
			array3[29] = 169;
			array3[29] = 117;
			array3[29] = 148;
			array3[29] = 136;
			array3[29] = 36;
			array3[30] = 95;
			array3[30] = 141;
			array3[30] = 52;
			array3[30] = 72;
			array3[31] = 165;
			array3[31] = 106;
			array3[31] = 120;
			array3[31] = 62;
			byte[] array4 = array3;
			byte[] array5 = new byte[16];
			array5[0] = 141;
			array5[0] = 170;
			array5[0] = 122;
			array5[0] = 128;
			array5[0] = 136;
			array5[1] = 94;
			array5[1] = 159;
			array5[1] = 114;
			array5[1] = 114;
			array5[1] = 73;
			array5[2] = 25;
			array5[2] = 87;
			array5[2] = 11;
			array5[3] = 118;
			array5[3] = 118;
			array5[3] = 199;
			array5[4] = 148;
			array5[4] = 96;
			array5[4] = 83;
			array5[4] = 165;
			array5[4] = 70;
			array5[5] = 175;
			array5[5] = 140;
			array5[5] = 6;
			array5[6] = 142;
			array5[6] = 142;
			array5[6] = 134;
			array5[7] = 102;
			array5[7] = 116;
			array5[7] = 110;
			array5[7] = 166;
			array5[7] = 247;
			array5[8] = 154;
			array5[8] = 90;
			array5[8] = 129;
			array5[8] = 84;
			array5[8] = 132;
			array5[8] = 163;
			array5[9] = 182;
			array5[9] = 120;
			array5[9] = 196;
			array5[10] = 85;
			array5[10] = 154;
			array5[10] = 88;
			array5[10] = 105;
			array5[10] = 33;
			array5[11] = 126;
			array5[11] = 112;
			array5[11] = 162;
			array5[12] = 103;
			array5[12] = 107;
			array5[12] = 51;
			array5[13] = 142;
			array5[13] = 115;
			array5[13] = 181;
			array5[13] = 93;
			array5[13] = 164;
			array5[13] = 203;
			array5[14] = 58;
			array5[14] = 181;
			array5[14] = 158;
			array5[14] = 56;
			array5[14] = 221;
			array5[15] = 149;
			array5[15] = 92;
			array5[15] = 143;
			byte[] array6 = array5;
			Array.Reverse(array6);
			byte[] publicKeyToken = Class5.assembly_0.GetName().GetPublicKeyToken();
			if (publicKeyToken != null && publicKeyToken.Length > 0)
			{
				array6[1] = publicKeyToken[0];
				array6[3] = publicKeyToken[1];
				array6[5] = publicKeyToken[2];
				array6[7] = publicKeyToken[3];
				array6[9] = publicKeyToken[4];
				array6[11] = publicKeyToken[5];
				array6[13] = publicKeyToken[6];
				array6[15] = publicKeyToken[7];
				Array.Clear(publicKeyToken, 0, publicKeyToken.Length);
			}
			for (int i = 0; i < array6.Length; i++)
			{
				array4[i] ^= array6[i];
			}
			byte[] array7 = array2;
			int num2 = array7.Length % 4;
			int num3 = array7.Length / 4;
			byte[] array8 = new byte[array7.Length];
			int num4 = array4.Length / 4;
			uint num5 = 0U;
			if (num2 > 0)
			{
				num3++;
			}
			for (int j = 0; j < num3; j++)
			{
				int num6 = j % num4;
				int num7 = j * 4;
				uint num8 = (uint)(num6 * 4);
				uint num9 = (uint)((int)array4[(int)((UIntPtr)(num8 + 3U))] << 24 | (int)array4[(int)((UIntPtr)(num8 + 2U))] << 16 | (int)array4[(int)((UIntPtr)(num8 + 1U))] << 8 | (int)array4[(int)((UIntPtr)num8)]);
				uint num10 = 255U;
				int num11 = 0;
				uint num12;
				if (j == num3 - 1 && num2 > 0)
				{
					num12 = 0U;
					for (int k = 0; k < num2; k++)
					{
						if (k > 0)
						{
							num12 <<= 8;
						}
						num12 |= (uint)array7[array7.Length - (1 + k)];
					}
					num5 += num9;
				}
				else
				{
					num8 = (uint)num7;
					num12 = (uint)((int)array7[(int)((UIntPtr)(num8 + 3U))] << 24 | (int)array7[(int)((UIntPtr)(num8 + 2U))] << 16 | (int)array7[(int)((UIntPtr)(num8 + 1U))] << 8 | (int)array7[(int)((UIntPtr)num8)]);
					num5 += num9;
				}
				uint num13 = num5;
				uint num14 = num5;
				num14 ^= num14 >> 29;
				num14 += 2223296986U;
				num14 ^= num14 << 1;
				num14 += 1685712301U;
				num14 ^= num14 >> 15;
				num14 += 2889850832U;
				num14 = 214797007U - num14;
				num5 = num13 + (uint)num14;
				if (j == num3 - 1 && num2 > 0)
				{
					uint num15 = num5 ^ num12;
					for (int l = 0; l < num2; l++)
					{
						if (l > 0)
						{
							num10 <<= 8;
							num11 += 8;
						}
						array8[num7 + l] = (byte)((num15 & num10) >> num11);
					}
				}
				else
				{
					uint num16 = num5 ^ num12;
					array8[num7] = (byte)(num16 & 255U);
					array8[num7 + 1] = (byte)((num16 & 65280U) >> 8);
					array8[num7 + 2] = (byte)((num16 & 16711680U) >> 16);
					array8[num7 + 3] = (byte)((num16 & 4278190080U) >> 24);
				}
			}
			byte[] array9 = array8;
			int num17 = array9.Length / 8;
			byte* ptr;
			if ((array = array9) != null && array.Length != 0)
			{
				fixed (byte* ptr = &array[0])
				{
				}
			}
			else
			{
				ptr = null;
			}
			for (int m = 0; m < num17; m++)
			{
				((long*)ptr)[(IntPtr)m * 8] ^= 1759972394L;
			}
			ptr = null;
			binaryReader = new BinaryReader(new MemoryStream(array9));
			binaryReader.BaseStream.Position = 0L;
			long num18 = Marshal.GetHINSTANCE(Class5.assembly_0.GetModules()[0]).ToInt64();
			int int_ = 0;
			int num19 = 0;
			if (Class5.assembly_0.Location == null || Class5.assembly_0.Location.Length == 0)
			{
				num19 = 7168;
			}
			int num20 = binaryReader.ReadInt32();
			int num21 = binaryReader.ReadInt32();
			if (num21 == 4)
			{
				SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
				symmetricAlgorithm.Mode = CipherMode.CBC;
				ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array4, array6);
				Array.Clear(array4, 0, array4.Length);
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				cryptoStream.Write(array2, 0, array2.Length);
				cryptoStream.FlushFinalBlock();
				array9 = memoryStream.ToArray();
				Array.Clear(array6, 0, array6.Length);
				memoryStream.Close();
				cryptoStream.Close();
				binaryReader.Close();
				num20 = binaryReader.ReadInt32();
				num21 = binaryReader.ReadInt32();
			}
			if (num21 == 1)
			{
				IntPtr intptr_ = IntPtr.Zero;
				intptr_ = Class5.OpenProcess(56U, 1, (uint)Process.GetCurrentProcess().Id);
				if (IntPtr.Size == 4)
				{
					Class5.int_3 = Marshal.GetHINSTANCE(Class5.assembly_0.GetModules()[0]).ToInt32();
				}
				Class5.long_1 = Marshal.GetHINSTANCE(Class5.assembly_0.GetModules()[0]).ToInt64();
				IntPtr zero = IntPtr.Zero;
				for (int n = 0; n < num20; n++)
				{
					IntPtr intPtr = new IntPtr(Class5.long_1 + (long)binaryReader.ReadInt32() - (long)num19);
					Class5.VirtualProtect_1(intPtr, 4, 4, ref int_);
					if (IntPtr.Size == 4)
					{
						Class5.WriteProcessMemory(intptr_, intPtr, BitConverter.GetBytes(binaryReader.ReadInt32()), 4U, out zero);
					}
					else
					{
						Class5.WriteProcessMemory(intptr_, intPtr, BitConverter.GetBytes(binaryReader.ReadInt32()), 4U, out zero);
					}
					Class5.VirtualProtect_1(intPtr, 4, int_, ref int_);
				}
				while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length - 1L)
				{
					int num22 = binaryReader.ReadInt32();
					IntPtr intptr_2 = new IntPtr(Class5.long_1 + (long)num22);
					int num23 = binaryReader.ReadInt32();
					Class5.VirtualProtect_1(intptr_2, num23 * 4, 4, ref int_);
					for (int num24 = 0; num24 < num23; num24++)
					{
						Marshal.WriteInt32(new IntPtr(intptr_2.ToInt64() + (long)(num24 * 4)), binaryReader.ReadInt32());
					}
					Class5.VirtualProtect_1(intptr_2, num23 * 4, int_, ref int_);
				}
				Class5.CloseHandle(intptr_);
				return;
			}
			for (int num25 = 0; num25 < num20; num25++)
			{
				IntPtr intPtr2 = new IntPtr(num18 + (long)binaryReader.ReadInt32() - (long)num19);
				Class5.VirtualProtect_1(intPtr2, 4, 4, ref int_);
				Marshal.WriteInt32(intPtr2, binaryReader.ReadInt32());
				Class5.VirtualProtect_1(intPtr2, 4, int_, ref int_);
			}
			Class5.hashtable_0 = new Hashtable(binaryReader.ReadInt32() + 1);
			Class5.Struct0 @struct = default(Class5.Struct0);
			@struct.byte_0 = new byte[]
			{
				42
			};
			@struct.bool_0 = false;
			Class5.hashtable_0.Add(0L, @struct);
			while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length - 1L)
			{
				int num26 = binaryReader.ReadInt32() - num19;
				int num27 = binaryReader.ReadInt32();
				bool flag = false;
				if (num27 >= 1879048192)
				{
					flag = true;
				}
				int count = binaryReader.ReadInt32();
				byte[] array10 = binaryReader.ReadBytes(count);
				Class5.Struct0 struct2 = default(Class5.Struct0);
				struct2.byte_0 = array10;
				struct2.bool_0 = flag;
				Class5.hashtable_0.Add(num18 + (long)num26, struct2);
			}
			Class5.long_0 = Marshal.GetHINSTANCE(typeof(Class5).Assembly.GetModules()[0]).ToInt64();
			if (IntPtr.Size == 4)
			{
				Class5.int_2 = Convert.ToInt32(Class5.long_0);
			}
			byte[] bytes = new byte[]
			{
				109,
				115,
				99,
				111,
				114,
				106,
				105,
				116,
				46,
				100,
				108,
				108
			};
			string @string = Encoding.UTF8.GetString(bytes);
			IntPtr intPtr3 = Class5.LoadLibrary(@string);
			if (intPtr3 == IntPtr.Zero)
			{
				bytes = new byte[]
				{
					99,
					108,
					114,
					106,
					105,
					116,
					46,
					100,
					108,
					108
				};
				@string = Encoding.UTF8.GetString(bytes);
				intPtr3 = Class5.LoadLibrary(@string);
			}
			byte[] bytes2 = new byte[]
			{
				103,
				101,
				116,
				74,
				105,
				116
			};
			string string2 = Encoding.UTF8.GetString(bytes2);
			IntPtr procAddress = Class5.GetProcAddress(intPtr3, string2);
			Class5.Delegate2 @delegate = (Class5.Delegate2)Class5.smethod_15(procAddress, typeof(Class5.Delegate2));
			IntPtr ptr2 = @delegate();
			long value = 0L;
			if (IntPtr.Size == 4)
			{
				value = (long)Marshal.ReadInt32(ptr2);
			}
			else
			{
				value = Marshal.ReadInt64(ptr2);
			}
			Marshal.ReadIntPtr(ptr2, 0);
			Class5.delegate1_1 = new Class5.Delegate1(Class5.smethod_13);
			IntPtr intPtr4 = IntPtr.Zero;
			intPtr4 = Marshal.GetFunctionPointerForDelegate(Class5.delegate1_1);
			long num28 = 0L;
			if (IntPtr.Size == 4)
			{
				num28 = (long)Marshal.ReadInt32(new IntPtr(value));
			}
			else
			{
				num28 = Marshal.ReadInt64(new IntPtr(value));
			}
			Process currentProcess = Process.GetCurrentProcess();
			try
			{
				ProcessModuleCollection modules2 = currentProcess.Modules;
				foreach (object obj2 in modules2)
				{
					ProcessModule processModule2 = (ProcessModule)obj2;
					if (processModule2.ModuleName == @string && (num28 < processModule2.BaseAddress.ToInt64() || num28 > processModule2.BaseAddress.ToInt64() + (long)processModule2.ModuleMemorySize) && typeof(Class5).Assembly.EntryPoint != null)
					{
						return;
					}
				}
			}
			catch
			{
			}
			try
			{
				ProcessModuleCollection modules3 = currentProcess.Modules;
				foreach (object obj3 in modules3)
				{
					ProcessModule processModule3 = (ProcessModule)obj3;
					if (processModule3.BaseAddress.ToInt64() == Class5.long_0)
					{
						break;
					}
				}
			}
			catch
			{
			}
			Class5.delegate1_0 = null;
			try
			{
				Class5.delegate1_0 = (Class5.Delegate1)Class5.smethod_15(new IntPtr(num28), typeof(Class5.Delegate1));
			}
			catch
			{
				try
				{
					Delegate delegate2 = Class5.smethod_15(new IntPtr(num28), typeof(Class5.Delegate1));
					Class5.delegate1_0 = (Class5.Delegate1)Delegate.CreateDelegate(typeof(Class5.Delegate1), delegate2.Method);
				}
				catch
				{
				}
			}
			int int_2 = 0;
			if (typeof(Class5).Assembly.EntryPoint != null && typeof(Class5).Assembly.EntryPoint.GetParameters().Length == 2 && typeof(Class5).Assembly.Location != null)
			{
				if (typeof(Class5).Assembly.Location.Length > 0)
				{
					return;
				}
			}
			try
			{
				object value2 = typeof(Class5).Assembly.ManifestModule.ModuleHandle.GetType().GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(typeof(Class5).Assembly.ManifestModule.ModuleHandle);
				if (value2 is IntPtr)
				{
					Class5.intptr_0 = (IntPtr)value2;
				}
				if (value2.GetType().ToString() == "System.Reflection.RuntimeModule")
				{
					Class5.intptr_0 = (IntPtr)value2.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(value2);
				}
				MemoryStream memoryStream2 = new MemoryStream();
				memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
				if (IntPtr.Size == 4)
				{
					memoryStream2.Write(BitConverter.GetBytes(Class5.intptr_0.ToInt32()), 0, 4);
				}
				else
				{
					memoryStream2.Write(BitConverter.GetBytes(Class5.intptr_0.ToInt64()), 0, 8);
				}
				memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
				memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
				memoryStream2.Position = 0L;
				byte[] array11 = memoryStream2.ToArray();
				memoryStream2.Close();
				uint num29 = 0U;
				try
				{
					byte* ptr3;
					if ((array = array11) != null && array.Length != 0)
					{
						fixed (byte* ptr3 = &array[0])
						{
						}
					}
					else
					{
						ptr3 = null;
					}
					Class5.delegate1_1(new IntPtr((void*)ptr3), new IntPtr((void*)ptr3), new IntPtr((void*)ptr3), 216669565U, new IntPtr((void*)ptr3), ref num29);
				}
				finally
				{
					byte* ptr3 = null;
				}
			}
			catch
			{
			}
			RuntimeHelpers.PrepareDelegate(Class5.delegate1_0);
			RuntimeHelpers.PrepareMethod(Class5.delegate1_0.Method.MethodHandle);
			RuntimeHelpers.PrepareDelegate(Class5.delegate1_1);
			RuntimeHelpers.PrepareMethod(Class5.delegate1_1.Method.MethodHandle);
			byte[] array12;
			if (IntPtr.Size != 4)
			{
				array12 = new byte[]
				{
					72,
					184,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					73,
					57,
					64,
					8,
					116,
					12,
					72,
					184,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					byte.MaxValue,
					224,
					72,
					184,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					byte.MaxValue,
					224
				};
			}
			else
			{
				array12 = new byte[]
				{
					85,
					139,
					236,
					139,
					69,
					16,
					129,
					120,
					4,
					125,
					29,
					234,
					12,
					116,
					7,
					184,
					182,
					177,
					74,
					6,
					235,
					5,
					184,
					182,
					146,
					64,
					12,
					93,
					byte.MaxValue,
					224
				};
			}
			IntPtr intPtr5 = Class5.VirtualAlloc(IntPtr.Zero, (uint)array12.Length, 4096U, 64U);
			byte[] array13 = array12;
			byte[] bytes3;
			byte[] bytes4;
			byte[] bytes5;
			if (IntPtr.Size == 4)
			{
				bytes3 = BitConverter.GetBytes(Class5.intptr_0.ToInt32());
				bytes4 = BitConverter.GetBytes(intPtr4.ToInt32());
				bytes5 = BitConverter.GetBytes(Convert.ToInt32(num28));
			}
			else
			{
				bytes3 = BitConverter.GetBytes(Class5.intptr_0.ToInt64());
				bytes4 = BitConverter.GetBytes(intPtr4.ToInt64());
				bytes5 = BitConverter.GetBytes(num28);
			}
			if (IntPtr.Size == 4)
			{
				array13[9] = bytes3[0];
				array13[10] = bytes3[1];
				array13[11] = bytes3[2];
				array13[12] = bytes3[3];
				array13[16] = bytes5[0];
				array13[17] = bytes5[1];
				array13[18] = bytes5[2];
				array13[19] = bytes5[3];
				array13[23] = bytes4[0];
				array13[24] = bytes4[1];
				array13[25] = bytes4[2];
				array13[26] = bytes4[3];
			}
			else
			{
				array13[2] = bytes3[0];
				array13[3] = bytes3[1];
				array13[4] = bytes3[2];
				array13[5] = bytes3[3];
				array13[6] = bytes3[4];
				array13[7] = bytes3[5];
				array13[8] = bytes3[6];
				array13[9] = bytes3[7];
				array13[18] = bytes5[0];
				array13[19] = bytes5[1];
				array13[20] = bytes5[2];
				array13[21] = bytes5[3];
				array13[22] = bytes5[4];
				array13[23] = bytes5[5];
				array13[24] = bytes5[6];
				array13[25] = bytes5[7];
				array13[30] = bytes4[0];
				array13[31] = bytes4[1];
				array13[32] = bytes4[2];
				array13[33] = bytes4[3];
				array13[34] = bytes4[4];
				array13[35] = bytes4[5];
				array13[36] = bytes4[6];
				array13[37] = bytes4[7];
			}
			Marshal.Copy(array13, 0, intPtr5, array13.Length);
			Class5.bool_6 = false;
			Class5.VirtualProtect_1(new IntPtr(value), IntPtr.Size, 64, ref int_2);
			Marshal.WriteIntPtr(new IntPtr(value), intPtr5);
			Class5.VirtualProtect_1(new IntPtr(value), IntPtr.Size, int_2, ref int_2);
			return;
		}
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00015A08 File Offset: 0x00013C08
	internal static object smethod_17(Assembly assembly_1)
	{
		try
		{
			if (File.Exists(((Assembly)assembly_1).Location))
			{
				return ((Assembly)assembly_1).Location;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(((Assembly)assembly_1).GetName().CodeBase.ToString().Replace("file:///", "")))
			{
				return ((Assembly)assembly_1).GetName().CodeBase.ToString().Replace("file:///", "");
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0]).ToString()))
			{
				return assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0]).ToString();
			}
		}
		catch
		{
		}
		return "";
	}

	// Token: 0x060001A8 RID: 424
	[DllImport("kernel32")]
	public static extern IntPtr LoadLibrary(string string_1);

	// Token: 0x060001A9 RID: 425
	[DllImport("kernel32", CharSet = CharSet.Ansi)]
	public static extern IntPtr GetProcAddress(IntPtr intptr_3, string string_1);

	// Token: 0x060001AA RID: 426
	[DllImport("kernel32.dll")]
	private static extern int WriteProcessMemory(IntPtr intptr_3, IntPtr intptr_4, [In] [Out] byte[] byte_4, uint uint_1, out IntPtr intptr_5);

	// Token: 0x060001AB RID: 427
	[DllImport("kernel32.dll")]
	private static extern int ReadProcessMemory(IntPtr intptr_3, IntPtr intptr_4, [In] [Out] byte[] byte_4, uint uint_1, out IntPtr intptr_5);

	// Token: 0x060001AC RID: 428
	[DllImport("kernel32.dll", EntryPoint = "VirtualProtect")]
	private static extern int VirtualProtect_1(IntPtr intptr_3, int int_5, int int_6, ref int int_7);

	// Token: 0x060001AD RID: 429
	[DllImport("kernel32.dll")]
	private static extern IntPtr OpenProcess(uint uint_1, int int_5, uint uint_2);

	// Token: 0x060001AE RID: 430
	[DllImport("kernel32.dll")]
	private static extern int CloseHandle(IntPtr intptr_3);

	// Token: 0x060001AF RID: 431 RVA: 0x00015B18 File Offset: 0x00013D18
	[Class5.Attribute0(typeof(Class5.Attribute0.Class6<object>[]))]
	private static byte[] cgewftHaHH(string string_1)
	{
		byte[] array;
		using (FileStream fileStream = new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read))
		{
			int num = 0;
			long length = fileStream.Length;
			int i = (int)length;
			array = new byte[i];
			while (i > 0)
			{
				int num2 = fileStream.Read(array, num, i);
				num += num2;
				i -= num2;
			}
		}
		return array;
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00015B80 File Offset: 0x00013D80
	[Class5.Attribute0(typeof(Class5.Attribute0.Class6<object>[]))]
	private static byte[] smethod_18(byte[] byte_4)
	{
		MemoryStream memoryStream = new MemoryStream();
		SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
		symmetricAlgorithm.Key = new byte[]
		{
			227,
			202,
			60,
			183,
			223,
			50,
			107,
			247,
			110,
			223,
			96,
			175,
			111,
			51,
			187,
			182,
			115,
			174,
			26,
			154,
			12,
			11,
			57,
			134,
			36,
			177,
			36,
			196,
			239,
			62,
			38,
			31
		};
		symmetricAlgorithm.IV = new byte[]
		{
			30,
			3,
			81,
			218,
			67,
			184,
			201,
			27,
			198,
			214,
			222,
			227,
			103,
			5,
			178,
			150
		};
		CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(byte_4, 0, byte_4.Length);
		cryptoStream.Close();
		return memoryStream.ToArray();
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x00002F30 File Offset: 0x00001130
	private byte[] method_0()
	{
		return null;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00002F30 File Offset: 0x00001130
	private byte[] GkVwxQumqh()
	{
		return null;
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x00015BF0 File Offset: 0x00013DF0
	private byte[] method_1()
	{
		string text = "{11111-22222-20001-00001}";
		if (text.Length > 0)
		{
			return new byte[]
			{
				1,
				2
			};
		}
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x00015C30 File Offset: 0x00013E30
	private byte[] method_2()
	{
		string text = "{11111-22222-20001-00002}";
		if (text.Length > 0)
		{
			return new byte[]
			{
				1,
				2
			};
		}
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x00002F30 File Offset: 0x00001130
	private byte[] method_3()
	{
		return null;
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00002F30 File Offset: 0x00001130
	private byte[] method_4()
	{
		return null;
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00002F30 File Offset: 0x00001130
	internal byte[] method_5()
	{
		return null;
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00002F30 File Offset: 0x00001130
	internal byte[] method_6()
	{
		return null;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00002F30 File Offset: 0x00001130
	internal byte[] method_7()
	{
		return null;
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00002F30 File Offset: 0x00001130
	internal byte[] method_8()
	{
		return null;
	}

	// Token: 0x0400016F RID: 367
	private static bool bool_0;

	// Token: 0x04000170 RID: 368
	private static bool bool_1;

	// Token: 0x04000171 RID: 369
	private static long long_0;

	// Token: 0x04000172 RID: 370
	private static bool bool_2;

	// Token: 0x04000173 RID: 371
	private static IntPtr intptr_0;

	// Token: 0x04000174 RID: 372
	[Class5.Attribute0(typeof(Class5.Attribute0.Class6<object>[]))]
	private static bool bool_3;

	// Token: 0x04000175 RID: 373
	internal static Hashtable hashtable_0;

	// Token: 0x04000176 RID: 374
	private static Assembly assembly_0;

	// Token: 0x04000177 RID: 375
	internal static Class5.Delegate1 delegate1_0;

	// Token: 0x04000178 RID: 376
	private static int int_0;

	// Token: 0x04000179 RID: 377
	private static bool bool_4;

	// Token: 0x0400017A RID: 378
	private static byte[] byte_0;

	// Token: 0x0400017B RID: 379
	private static int[] int_1;

	// Token: 0x0400017C RID: 380
	private static int int_2;

	// Token: 0x0400017D RID: 381
	private static int int_3;

	// Token: 0x0400017E RID: 382
	private static bool bool_5 = false;

	// Token: 0x0400017F RID: 383
	private static long long_1;

	// Token: 0x04000180 RID: 384
	private static SortedList sortedList_0;

	// Token: 0x04000181 RID: 385
	private static byte[] byte_1;

	// Token: 0x04000182 RID: 386
	private static string[] string_0;

	// Token: 0x04000183 RID: 387
	private static uint[] uint_0;

	// Token: 0x04000184 RID: 388
	private static IntPtr intptr_1;

	// Token: 0x04000185 RID: 389
	internal static Class5.Delegate1 delegate1_1;

	// Token: 0x04000186 RID: 390
	private static byte[] byte_2;

	// Token: 0x04000187 RID: 391
	private static bool bool_6;

	// Token: 0x04000188 RID: 392
	private static byte[] byte_3;

	// Token: 0x04000189 RID: 393
	private static int int_4;

	// Token: 0x0400018A RID: 394
	private static IntPtr intptr_2;

	// Token: 0x02000022 RID: 34
	internal class Attribute0 : Attribute
	{
		// Token: 0x060001BC RID: 444 RVA: 0x00002F3B File Offset: 0x0000113B
		[Class5.Attribute0(typeof(Class5.Attribute0.Class6<object>[]))]
		public Attribute0(object object_0)
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}

		// Token: 0x02000023 RID: 35
		internal class Class6<T>
		{
			// Token: 0x060001BD RID: 445 RVA: 0x00002402 File Offset: 0x00000602
			public Class6()
			{
				Class8.ah6VSoGzeNXX5();
				base..ctor();
			}
		}
	}

	// Token: 0x02000024 RID: 36
	internal class Class7
	{
		// Token: 0x060001BE RID: 446 RVA: 0x00002F48 File Offset: 0x00001148
		[Class5.Attribute0(typeof(Class5.Attribute0.Class6<object>[]))]
		internal static void ce4DmfsmSrOT856tDgfrkMb()
		{
			if (!(Class5.Class7.smethod_0(Convert.ToBase64String(Class5.assembly_0.GetName().GetPublicKeyToken()), " ") != "  "))
			{
				return;
			}
			for (;;)
			{
				Class5.Class7.ce4DmfsmSrOT856tDgfrkMb();
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00015C70 File Offset: 0x00013E70
		[Class5.Attribute0(typeof(Class5.Attribute0.Class6<object>[]))]
		internal static string smethod_0(string string_0, string string_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			byte[] array = bytes;
			byte[] key = new byte[]
			{
				82,
				102,
				104,
				110,
				32,
				77,
				24,
				34,
				118,
				181,
				51,
				17,
				18,
				51,
				12,
				109,
				10,
				32,
				77,
				24,
				34,
				158,
				161,
				41,
				97,
				28,
				118,
				181,
				5,
				25,
				1,
				88
			};
			byte[] iv = Class5.smethod_9(Encoding.Unicode.GetBytes(string_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = iv;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	// Token: 0x02000025 RID: 37
	// (Invoke) Token: 0x060001C2 RID: 450
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate uint Delegate1(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

	// Token: 0x02000026 RID: 38
	// (Invoke) Token: 0x060001C6 RID: 454
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate2();

	// Token: 0x02000027 RID: 39
	internal struct Struct0
	{
		// Token: 0x0400018B RID: 395
		internal bool bool_0;

		// Token: 0x0400018C RID: 396
		internal byte[] byte_0;
	}

	// Token: 0x02000028 RID: 40
	[Flags]
	private enum Enum0
	{

	}
}
