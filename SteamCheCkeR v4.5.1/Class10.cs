using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

// Token: 0x0200002B RID: 43
internal sealed class Class10
{
	// Token: 0x060001CC RID: 460 RVA: 0x00015D00 File Offset: 0x00013F00
	internal void method_0()
	{
		string text = "{12211-22232-40001-0123}";
		if (text.Length == 12)
		{
			text += "c";
		}
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00015D2C File Offset: 0x00013F2C
	public Class10()
	{
		Class8.ah6VSoGzeNXX5();
		this.string_0 = "";
		this.string_1 = "";
		this.string_2 = "";
		this.string_3 = "";
		base..ctor();
		this.string_0 = "kl§$%7ghJ/()3w45ZZHW$5$%&gwSADF2";
		this.string_2 = "sd§5$§&g457!23nm";
		this.string_1 = "($)(/)()=fg55jm,§98*jgt65=§C33$t";
		this.string_3 = "g&5§$§7!s3nm42d5";
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00015D9C File Offset: 0x00013F9C
	public byte[] method_1(string string_18, bool bool_14)
	{
		FileStream fileStream = new FileStream(string_18, FileMode.Open, FileAccess.Read, FileShare.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		fileStream.Close();
		return this.method_5(memoryStream, bool_14);
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00015DEC File Offset: 0x00013FEC
	public void method_2(string string_18, string string_19)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_18);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(bytes, 0, bytes.Length);
		byte[] array = this.method_5(memoryStream, true);
		Directory.CreateDirectory(Path.GetDirectoryName(string_19));
		FileStream fileStream = new FileStream(string_19, FileMode.Create, FileAccess.ReadWrite);
		fileStream.Write(array, 0, array.Length);
		fileStream.Close();
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x00015E48 File Offset: 0x00014048
	public string method_3(string string_18)
	{
		FileStream fileStream = new FileStream(string_18, FileMode.Open, FileAccess.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		byte[] array2 = this.method_10(memoryStream, true);
		return Encoding.Unicode.GetString(array2, 0, array2.Length);
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00015EA8 File Offset: 0x000140A8
	public byte[] method_4(string string_18, byte[] byte_0)
	{
		FileStream fileStream = new FileStream(string_18, FileMode.Open, FileAccess.Read, FileShare.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		return this.method_12(array, byte_0);
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x00015EE8 File Offset: 0x000140E8
	public byte[] method_5(MemoryStream memoryStream_0, bool bool_14)
	{
		int num = 0;
		try
		{
			string text = this.string_0;
			string text2 = this.string_2;
			if (bool_14)
			{
				text = this.string_1;
				text2 = this.string_3;
			}
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			byte[] array2 = new byte[text2.Length];
			for (int j = 0; j < text2.Length; j++)
			{
				array2[j] = Convert.ToByte(text2[j]);
			}
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor(array, array2);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array3 = memoryStream_0.ToArray();
			cryptoStream.Write(array3, 0, array3.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch (Exception ex)
		{
			try
			{
				MessageBox.Show("Encryption Error " + num.ToString() + " " + ex.ToString());
			}
			catch
			{
			}
		}
		return new byte[1];
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x0001603C File Offset: 0x0001423C
	public byte[] method_6(byte[] byte_0, byte[] byte_1, byte[] byte_2)
	{
		int num = 0;
		try
		{
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor(byte_2, byte_1);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch (Exception ex)
		{
			try
			{
				MessageBox.Show("Encryption Error " + num.ToString() + " " + ex.ToString());
			}
			catch
			{
			}
		}
		return new byte[1];
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x00016104 File Offset: 0x00014304
	public byte[] method_7(byte[] byte_0, bool bool_14)
	{
		int num = 0;
		try
		{
			string text = this.string_0;
			string text2 = this.string_2;
			if (bool_14)
			{
				text = this.string_1;
				text2 = this.string_3;
			}
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			byte[] array2 = new byte[text2.Length];
			for (int j = 0; j < text2.Length; j++)
			{
				array2[j] = Convert.ToByte(text2[j]);
			}
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor(array, array2);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch (Exception ex)
		{
			try
			{
				MessageBox.Show("Encryption Error " + num.ToString() + " " + ex.ToString());
			}
			catch
			{
			}
		}
		return new byte[1];
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x00016250 File Offset: 0x00014450
	public byte[] method_8(MemoryStream memoryStream_0, byte[] byte_0, bool bool_14)
	{
		int num = 0;
		try
		{
			string text = this.string_2;
			if (bool_14)
			{
				text = this.string_3;
			}
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor(byte_0, array);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array2 = memoryStream_0.ToArray();
			cryptoStream.Write(array2, 0, array2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch (Exception ex)
		{
			try
			{
				MessageBox.Show("Encryption Error " + num.ToString() + " " + ex.ToString());
			}
			catch
			{
			}
		}
		return new byte[1];
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x00016360 File Offset: 0x00014560
	public byte[] method_9(string string_18, bool bool_14)
	{
		FileStream fileStream = new FileStream(string_18, FileMode.Open, FileAccess.Read, FileShare.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		fileStream.Close();
		return this.method_10(memoryStream, bool_14);
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x000163B0 File Offset: 0x000145B0
	public byte[] method_10(MemoryStream memoryStream_0, bool bool_14)
	{
		try
		{
			string text = this.string_0;
			string text2 = this.string_2;
			if (bool_14)
			{
				text = this.string_1;
				text2 = this.string_3;
			}
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			byte[] array2 = new byte[text2.Length];
			for (int j = 0; j < text2.Length; j++)
			{
				array2[j] = Convert.ToByte(text2[j]);
			}
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array, array2);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array3 = memoryStream_0.ToArray();
			cryptoStream.Write(array3, 0, array3.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch
		{
		}
		return new byte[1];
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x000164C8 File Offset: 0x000146C8
	public byte[] method_11(MemoryStream memoryStream_0, byte[] byte_0, bool bool_14)
	{
		try
		{
			string text = this.string_2;
			if (bool_14)
			{
				text = this.string_3;
			}
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(byte_0, array);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array2 = memoryStream_0.ToArray();
			cryptoStream.Write(array2, 0, array2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch
		{
		}
		return new byte[1];
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x0001659C File Offset: 0x0001479C
	public byte[] method_12(byte[] byte_0, byte[] byte_1)
	{
		try
		{
			string text = this.string_2;
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor(byte_1, array);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch
		{
		}
		return new byte[1];
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0001665C File Offset: 0x0001485C
	public byte[] method_13(MemoryStream memoryStream_0, byte[] byte_0)
	{
		try
		{
			string text = this.string_2;
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(byte_0, array);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array2 = memoryStream_0.ToArray();
			cryptoStream.Write(array2, 0, array2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return result;
		}
		catch
		{
		}
		return new byte[1];
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00016724 File Offset: 0x00014924
	public MemoryStream method_14(MemoryStream memoryStream_0, bool bool_14)
	{
		try
		{
			string text = this.string_0;
			string text2 = this.string_2;
			if (bool_14)
			{
				text = this.string_1;
				text2 = this.string_3;
			}
			byte[] array = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				array[i] = Convert.ToByte(text[i]);
			}
			byte[] array2 = new byte[text2.Length];
			for (int j = 0; j < text2.Length; j++)
			{
				array2[j] = Convert.ToByte(text2[j]);
			}
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array, array2);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array3 = memoryStream_0.ToArray();
			cryptoStream.Write(array3, 0, array3.Length);
			cryptoStream.FlushFinalBlock();
			memoryStream.Close();
			cryptoStream.Close();
			return memoryStream;
		}
		catch
		{
		}
		return null;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x00016828 File Offset: 0x00014A28
	public byte[] method_15()
	{
		Class10.Class21 @class = new Class10.Class21();
		ManagementClass managementClass = new ManagementClass("Win32_BIOS");
		ManagementObjectCollection instances = managementClass.GetInstances();
		using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)enumerator.Current;
				Class10.Class24 class2 = new Class10.Class24("BIOS");
				if (managementObject.Properties["Manufacturer"].Value != null)
				{
					class2.method_6("Manufacturer", managementObject.Properties["Manufacturer"].Value.ToString(), "");
				}
				else
				{
					class2.method_6("Manufacturer", "", "");
				}
				if (managementObject.Properties["Version"].Value != null)
				{
					class2.method_6("Version", managementObject.Properties["Version"].Value.ToString(), "");
				}
				else
				{
					class2.method_6("Version", "", "");
				}
				if (managementObject.Properties["SMBIOSBIOSVersion"].Value != null)
				{
					class2.method_6("SMBIOSBIOSVersion", managementObject.Properties["SMBIOSBIOSVersion"].Value.ToString(), "");
				}
				else
				{
					class2.method_6("SMBIOSBIOSVersion", "", "");
				}
				@class.method_0().method_2(class2);
			}
		}
		managementClass = new ManagementClass("Win32_BaseBoard");
		instances = managementClass.GetInstances();
		using (ManagementObjectCollection.ManagementObjectEnumerator enumerator2 = instances.GetEnumerator())
		{
			if (enumerator2.MoveNext())
			{
				ManagementObject managementObject2 = (ManagementObject)enumerator2.Current;
				Class10.Class24 class3 = new Class10.Class24("BOARD");
				if (managementObject2.Properties["Manufacturer"].Value != null)
				{
					class3.method_6("Manufacturer", managementObject2.Properties["Manufacturer"].Value.ToString(), "");
				}
				else
				{
					class3.method_6("Manufacturer", "", "");
				}
				@class.method_0().method_2(class3);
			}
		}
		managementClass = new ManagementClass("Win32_Processor");
		instances = managementClass.GetInstances();
		using (ManagementObjectCollection.ManagementObjectEnumerator enumerator3 = instances.GetEnumerator())
		{
			if (enumerator3.MoveNext())
			{
				ManagementObject managementObject3 = (ManagementObject)enumerator3.Current;
				Class10.Class24 class4 = new Class10.Class24("PROCESSOR");
				if (managementObject3.Properties["Manufacturer"].Value != null)
				{
					class4.method_6("Manufacturer", managementObject3.Properties["Manufacturer"].Value.ToString(), "");
				}
				else
				{
					class4.method_6("Manufacturer", "", "");
				}
				if (managementObject3.Properties["Name"].Value != null)
				{
					class4.method_6("Name", managementObject3.Properties["Name"].Value.ToString(), "");
				}
				else
				{
					class4.method_6("Name", "", "");
				}
				if (managementObject3.Properties["ProcessorId"].Value != null)
				{
					class4.method_6("ProcessorId", managementObject3.Properties["ProcessorId"].Value.ToString(), "");
				}
				else
				{
					class4.method_6("ProcessorId", "", "");
				}
				@class.method_0().method_2(class4);
			}
		}
		MemoryStream memoryStream = new MemoryStream();
		StreamWriter textWriter_ = new StreamWriter(memoryStream);
		@class.method_1(textWriter_);
		return memoryStream.ToArray();
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00016C38 File Offset: 0x00014E38
	public static string smethod_0(string string_18)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_18);
		HashAlgorithm hashAlgorithm = null;
		try
		{
			hashAlgorithm = new SHA256CryptoServiceProvider();
		}
		catch
		{
			hashAlgorithm = SHA256.Create();
		}
		byte[] byte_ = hashAlgorithm.ComputeHash(bytes);
		return Class10.smethod_33(byte_);
	}

	// Token: 0x060001DE RID: 478 RVA: 0x00016C84 File Offset: 0x00014E84
	public static byte[] smethod_1(string string_18)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_18);
		HashAlgorithm hashAlgorithm = null;
		try
		{
			hashAlgorithm = new SHA256CryptoServiceProvider();
		}
		catch
		{
			hashAlgorithm = SHA256.Create();
		}
		return hashAlgorithm.ComputeHash(bytes);
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00016CC8 File Offset: 0x00014EC8
	public static byte[] smethod_2(string string_18)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_18);
		Array.Reverse(bytes);
		HashAlgorithm hashAlgorithm = null;
		try
		{
			hashAlgorithm = new SHA256CryptoServiceProvider();
		}
		catch
		{
			hashAlgorithm = SHA256.Create();
		}
		return hashAlgorithm.ComputeHash(bytes);
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x00016D14 File Offset: 0x00014F14
	public static string smethod_3(string string_18)
	{
		byte[] bytes = Encoding.Unicode.GetBytes(string_18);
		HashAlgorithm hashAlgorithm = null;
		try
		{
			hashAlgorithm = new SHA256CryptoServiceProvider();
		}
		catch
		{
			hashAlgorithm = SHA256.Create();
		}
		byte[] inArray = hashAlgorithm.ComputeHash(bytes);
		return Convert.ToBase64String(inArray);
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00016D60 File Offset: 0x00014F60
	public static void smethod_4(string string_18)
	{
		Class10.Class21 class21_ = Class10.smethod_29();
		byte[] array = Class10.Class29.smethod_0(class21_);
		FileStream fileStream = new FileStream(string_18, FileMode.Create, FileAccess.ReadWrite);
		fileStream.Write(array, 0, array.Length);
		fileStream.Close();
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x00016D94 File Offset: 0x00014F94
	internal static string smethod_5(bool bool_14, bool bool_15, bool bool_16, bool bool_17)
	{
		string text = "";
		if (bool_14)
		{
			text = Class10.smethod_17();
		}
		if (bool_15)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_19();
		}
		if (bool_16)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_21();
		}
		if (bool_17)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_18();
		}
		return text;
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00016E20 File Offset: 0x00015020
	internal static string smethod_6(bool bool_14, bool bool_15, bool bool_16, bool bool_17)
	{
		string text = "";
		if (bool_14)
		{
			text = Class10.smethod_15();
		}
		if (bool_15)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_19();
		}
		if (bool_16)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_21();
		}
		if (bool_17)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_18();
		}
		return text;
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x00016EAC File Offset: 0x000150AC
	internal static string smethod_7(bool bool_14, bool bool_15, bool bool_16, bool bool_17)
	{
		string text = "";
		if (bool_14)
		{
			text = Class10.smethod_17();
		}
		if (bool_15)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_20();
		}
		if (bool_16)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_22();
		}
		if (bool_17)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_15();
		}
		return text;
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x00016F38 File Offset: 0x00015138
	internal static string smethod_8(bool bool_14, bool bool_15, bool bool_16, bool bool_17)
	{
		string text = "";
		if (bool_14)
		{
			text = Class10.smethod_17();
		}
		if (bool_15)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_20();
		}
		if (bool_16)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_22();
		}
		if (bool_17)
		{
			if (text.Length > 0)
			{
				text += "-";
			}
			text += Class10.smethod_12();
		}
		return text;
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x00016FC4 File Offset: 0x000151C4
	internal static string smethod_9(bool bool_14, bool bool_15, bool bool_16, bool bool_17)
	{
		string text = "";
		RSACryptoServiceProvider.UseMachineKeyStore = true;
		if (bool_14)
		{
			byte[] array = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_17()));
			text += array[3].ToString("X2");
			text = text + array[11].ToString("X2") + "-";
		}
		else
		{
			text = "85C1-";
		}
		if (bool_15)
		{
			byte[] array2 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_20()));
			text += array2[3].ToString("X2");
			text = text + array2[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array3 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
			text += array3[15].ToString("X2");
			text = text + array3[7].ToString("X2") + "-";
		}
		if (bool_16)
		{
			byte[] array4 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_22()));
			text += array4[3].ToString("X2");
			text = text + array4[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array5 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
			text += array5[2].ToString("X2");
			text = text + array5[14].ToString("X2") + "-";
		}
		if (bool_17)
		{
			byte[] array6 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_13()));
			text += array6[3].ToString("X2");
			text = text + array6[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array7 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
			text += array7[1].ToString("X2");
			text = text + array7[9].ToString("X2") + "-";
		}
		byte[] array8 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
		text += array8[1].ToString("X2");
		return text + array8[9].ToString("X2");
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0001724C File Offset: 0x0001544C
	internal static string smethod_10(bool bool_14, bool bool_15, bool bool_16, bool bool_17)
	{
		string text = "";
		RSACryptoServiceProvider.UseMachineKeyStore = true;
		if (bool_14)
		{
			byte[] array = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_17()));
			text += array[3].ToString("X2");
			text = text + array[11].ToString("X2") + "-";
		}
		else
		{
			text = "85C1-";
		}
		if (bool_15)
		{
			byte[] array2 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_20()));
			text += array2[3].ToString("X2");
			text = text + array2[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array3 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
			text += array3[15].ToString("X2");
			text = text + array3[7].ToString("X2") + "-";
		}
		if (bool_16)
		{
			byte[] array4 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_22()));
			text += array4[3].ToString("X2");
			text = text + array4[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array5 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
			text += array5[2].ToString("X2");
			text = text + array5[14].ToString("X2") + "-";
		}
		if (bool_17)
		{
			byte[] array6 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_16()));
			text += array6[3].ToString("X2");
			text = text + array6[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array7 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
			text += array7[1].ToString("X2");
			text = text + array7[9].ToString("X2") + "-";
		}
		byte[] array8 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
		text += array8[1].ToString("X2");
		return text + array8[9].ToString("X2");
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x000174D4 File Offset: 0x000156D4
	internal static string smethod_11(bool bool_14, bool bool_15, bool bool_16, bool bool_17)
	{
		string text = "";
		RSACryptoServiceProvider.UseMachineKeyStore = true;
		if (bool_14)
		{
			byte[] array = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_17()));
			text += array[3].ToString("X2");
			text = text + array[11].ToString("X2") + "-";
		}
		else
		{
			text = "85C1-";
		}
		if (bool_15)
		{
			byte[] array2 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_20()));
			text += array2[3].ToString("X2");
			text = text + array2[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array3 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
			text += array3[15].ToString("X2");
			text = text + array3[7].ToString("X2") + "-";
		}
		if (bool_16)
		{
			byte[] array4 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_22()));
			text += array4[3].ToString("X2");
			text = text + array4[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array5 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
			text += array5[2].ToString("X2");
			text = text + array5[14].ToString("X2") + "-";
		}
		if (bool_17)
		{
			byte[] array6 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_14()));
			text += array6[3].ToString("X2");
			text = text + array6[11].ToString("X2") + "-";
		}
		else
		{
			byte[] array7 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
			text += array7[1].ToString("X2");
			text = text + array7[9].ToString("X2") + "-";
		}
		byte[] array8 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
		text += array8[1].ToString("X2");
		return text + array8[9].ToString("X2");
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x0001775C File Offset: 0x0001595C
	private static string smethod_12()
	{
		if (!Class10.bool_0)
		{
			Class10.bool_0 = true;
			try
			{
				string text = string.Empty;
				ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
				ManagementObjectCollection instances = managementClass.GetInstances();
				foreach (ManagementBaseObject managementBaseObject in instances)
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					try
					{
						if (text == string.Empty && managementObject.Properties["PnPDeviceID"] != null && managementObject.Properties["PnPDeviceID"].Value != null)
						{
							text = managementObject.Properties["PnPDeviceID"].Value.ToString();
							if (text.Length > 0 && text.IndexOf("USBSTOR") >= 0)
							{
								text = "";
							}
							if (managementObject.Properties["MediaType"] != null && managementObject.Properties["MediaType"].Value != null && managementObject.Properties["MediaType"].Value.ToString().ToUpper().IndexOf("REMOVABLE") >= 0)
							{
								text = "";
							}
							if (managementObject.Properties["InterfaceType"] != null && managementObject.Properties["InterfaceType"].Value != null)
							{
								if (managementObject.Properties["InterfaceType"].Value.ToString() == "USB")
								{
									text = "";
								}
								if (managementObject.Properties["InterfaceType"].Value.ToString() == "1394")
								{
									text = "";
								}
							}
							if (text.Length != 0)
							{
								break;
							}
							text = string.Empty;
						}
					}
					catch
					{
					}
				}
				if (text == string.Empty)
				{
					text = "";
				}
				Class10.string_4 = text;
				if (Class10.string_4.Length > 0)
				{
					string[] array = Class10.string_4.Split(new char[]
					{
						'\\'
					});
					Class10.string_4 = array[array.Length - 1];
				}
			}
			catch
			{
				Class10.string_4 = "";
			}
		}
		return Class10.string_4;
	}

	// Token: 0x060001EA RID: 490 RVA: 0x000179E8 File Offset: 0x00015BE8
	private static string smethod_13()
	{
		if (!Class10.bool_1)
		{
			Class10.bool_1 = true;
			try
			{
				string text = string.Empty;
				ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
				ManagementObjectCollection instances = managementClass.GetInstances();
				foreach (ManagementBaseObject managementBaseObject in instances)
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					try
					{
						if (text == string.Empty && managementObject.Properties["PnPDeviceID"] != null && managementObject.Properties["PnPDeviceID"].Value != null)
						{
							text = managementObject.Properties["PnPDeviceID"].Value.ToString();
							if (text.Length > 0 && text.IndexOf("USBSTOR") >= 0)
							{
								text = "";
							}
							if (managementObject.Properties["InterfaceType"] != null && managementObject.Properties["InterfaceType"].Value != null)
							{
								if (managementObject.Properties["InterfaceType"].Value.ToString() == "USB")
								{
									text = "";
								}
								if (managementObject.Properties["InterfaceType"].Value.ToString() == "1394")
								{
									text = "";
								}
							}
							if (text.Length != 0)
							{
								break;
							}
							text = string.Empty;
						}
					}
					catch
					{
					}
				}
				if (text == string.Empty)
				{
					text = "";
				}
				Class10.string_5 = text;
				if (Class10.string_5.Length > 0)
				{
					string[] array = Class10.string_5.Split(new char[]
					{
						'\\'
					});
					Class10.string_5 = array[array.Length - 1];
				}
			}
			catch
			{
				Class10.string_5 = "";
			}
		}
		return Class10.string_5;
	}

	// Token: 0x060001EB RID: 491 RVA: 0x00017C14 File Offset: 0x00015E14
	private static string smethod_14()
	{
		if (Class10.bool_2)
		{
			return Class10.string_6;
		}
		Class10.bool_2 = true;
		try
		{
			ArrayList arrayList = new ArrayList();
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
			foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				if (managementObject["DeviceID"] != null && managementObject["InterfaceType"] != null && managementObject["InterfaceType"].ToString() != "USB" && managementObject["InterfaceType"].ToString() != "1394")
				{
					bool flag = true;
					if (managementObject["MediaType"] != null && managementObject["MediaType"].ToString() == "Removable Media")
					{
						flag = false;
					}
					if (flag)
					{
						if (managementObject["SerialNumber"] != null)
						{
							object obj = managementObject["SerialNumber"];
							if (obj != null && !(obj.ToString().Trim() == string.Empty) && obj.ToString()[0] != Convert.ToChar(31))
							{
								Class10.string_6 = obj.ToString().Trim();
								return Class10.string_6;
							}
						}
						arrayList.Add(managementObject["DeviceID"].ToString());
					}
				}
			}
			managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (object obj2 in arrayList)
			{
				string b = (string)obj2;
				foreach (ManagementBaseObject managementBaseObject2 in managementObjectCollection)
				{
					ManagementObject managementObject2 = (ManagementObject)managementBaseObject2;
					if (managementObject2["Tag"] != null)
					{
						string a = managementObject2["Tag"].ToString();
						if (a == b && managementObject2["SerialNumber"] != null)
						{
							object obj3 = managementObject2["SerialNumber"];
							if (obj3 != null && !(obj3.ToString() == string.Empty) && obj3.ToString()[0] != Convert.ToChar(31))
							{
								Class10.string_6 = obj3.ToString().Trim().Replace(" ", "");
								return Class10.string_6;
							}
							break;
						}
					}
				}
			}
		}
		catch
		{
			Class10.string_6 = "";
		}
		return "";
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00017F2C File Offset: 0x0001612C
	private static string smethod_15()
	{
		if (!Class10.bool_3)
		{
			Class10.bool_3 = true;
			try
			{
				Class10.string_7 = Class10.Class17.smethod_0();
			}
			catch
			{
				Class10.string_7 = "failure-failure";
			}
		}
		return Class10.string_7;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x00017F74 File Offset: 0x00016174
	private static string smethod_16()
	{
		if (Class10.bool_4)
		{
			return Class10.string_8;
		}
		Class10.bool_4 = true;
		try
		{
			ArrayList arrayList = new ArrayList();
			foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive").Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				if (managementObject["DeviceID"] != null && managementObject["InterfaceType"] != null && managementObject["InterfaceType"].ToString() != "USB" && managementObject["InterfaceType"].ToString() != "1394")
				{
					arrayList.Add(managementObject["DeviceID"].ToString());
				}
			}
			ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia").Get();
			foreach (object obj in arrayList)
			{
				string b = (string)obj;
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator3 = managementObjectCollection.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						ManagementObject managementObject2 = (ManagementObject)enumerator3.Current;
						if (managementObject2["Tag"] != null && managementObject2["Tag"].ToString() == b && managementObject2["SerialNumber"] != null)
						{
							object obj2 = managementObject2["SerialNumber"];
							if (obj2 != null && !(obj2.ToString() == string.Empty) && obj2.ToString()[0] != Convert.ToChar(31))
							{
								Class10.string_8 = obj2.ToString().Trim();
								return Class10.string_8;
							}
							break;
						}
					}
				}
			}
		}
		catch
		{
			Class10.string_8 = "";
		}
		return "";
	}

	// Token: 0x060001EE RID: 494 RVA: 0x000181C0 File Offset: 0x000163C0
	private static string smethod_17()
	{
		if (!Class10.bool_5)
		{
			try
			{
				string text = string.Empty;
				ManagementClass managementClass = new ManagementClass("Win32_Processor");
				ManagementObjectCollection instances = managementClass.GetInstances();
				foreach (ManagementBaseObject managementBaseObject in instances)
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					if (text == string.Empty)
					{
						try
						{
							text = managementObject.Properties["ProcessorId"].Value.ToString();
							if (text.Length != 0)
							{
								break;
							}
							text = string.Empty;
						}
						catch
						{
						}
					}
				}
				Class10.string_9 = text;
			}
			catch
			{
			}
			Class10.bool_5 = true;
		}
		if (Class10.string_9 == string.Empty)
		{
			Class10.string_9 = "";
		}
		return Class10.string_9;
	}

	// Token: 0x060001EF RID: 495 RVA: 0x000182B4 File Offset: 0x000164B4
	private static string smethod_18()
	{
		if (!Class10.bool_6)
		{
			string text = string.Empty;
			try
			{
				if (text == string.Empty)
				{
					ManagementClass managementClass = new ManagementClass("Win32_PhysicalMedia");
					ManagementObjectCollection instances = managementClass.GetInstances();
					foreach (ManagementBaseObject managementBaseObject in instances)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						if (text == string.Empty)
						{
							try
							{
								string text2 = managementObject.Properties["SerialNumber"].Value.ToString();
								text = text2;
								if (text.Length != 0)
								{
									break;
								}
								text = string.Empty;
							}
							catch
							{
							}
						}
					}
				}
			}
			catch
			{
			}
			Class10.string_10 = text;
			Class10.bool_6 = true;
		}
		if (Class10.string_10 == string.Empty)
		{
			Class10.string_10 = "";
		}
		return Class10.string_10;
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x000183B8 File Offset: 0x000165B8
	private static string smethod_19()
	{
		if (!Class10.bool_7)
		{
			try
			{
				string text = string.Empty;
				ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
				ManagementObjectCollection instances = managementClass.GetInstances();
				foreach (ManagementBaseObject managementBaseObject in instances)
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					if (!(text == string.Empty))
					{
						break;
					}
					try
					{
						if (managementObject["IPEnabled"] != null && (bool)managementObject["IPEnabled"] && managementObject["MacAddress"] != null)
						{
							text = managementObject["MacAddress"].ToString();
							text = text.Replace(":", "");
						}
					}
					catch
					{
					}
				}
				Class10.string_11 = text;
			}
			catch
			{
			}
			Class10.bool_7 = true;
		}
		if (Class10.string_11 == string.Empty)
		{
			Class10.string_11 = "";
		}
		return Class10.string_11;
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x000184D0 File Offset: 0x000166D0
	private static string smethod_20()
	{
		if (!Class10.bool_8)
		{
			try
			{
				string text = Class10.Class16.smethod_0();
				if (text.Length == 0)
				{
					text = string.Empty;
					ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
					ManagementObjectCollection instances = managementClass.GetInstances();
					foreach (ManagementBaseObject managementBaseObject in instances)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						if (!(text == string.Empty))
						{
							break;
						}
						try
						{
							if (managementObject["IPEnabled"] != null && (bool)managementObject["IPEnabled"] && managementObject["MacAddress"] != null && managementObject["MacAddress"].ToString().Length > 0)
							{
								text = managementObject["MacAddress"].ToString().ToUpper();
								text = text.Replace(":", "");
							}
						}
						catch
						{
						}
					}
				}
				Class10.string_12 = text;
			}
			catch
			{
			}
			Class10.bool_8 = true;
		}
		if (Class10.string_12 == string.Empty)
		{
			Class10.string_12 = "";
		}
		return Class10.string_12;
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00018620 File Offset: 0x00016820
	private static string smethod_21()
	{
		if (!Class10.bool_9)
		{
			try
			{
				Class10.string_13 = Class10.smethod_23() + "-" + Class10.smethod_25();
			}
			catch
			{
			}
			Class10.bool_9 = true;
		}
		if (Class10.string_13 == string.Empty)
		{
			Class10.string_13 = "";
		}
		return Class10.string_13;
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x0001868C File Offset: 0x0001688C
	private static string smethod_22()
	{
		if (!Class10.bool_10)
		{
			try
			{
				Class10.string_14 = string.Concat(new string[]
				{
					Class10.smethod_23(),
					"-",
					Class10.smethod_25(),
					"-",
					Class10.smethod_27()
				});
			}
			catch
			{
			}
			Class10.bool_10 = true;
		}
		if (Class10.string_14 == string.Empty)
		{
			Class10.string_14 = "";
		}
		return Class10.string_14;
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x00002FA1 File Offset: 0x000011A1
	private static string smethod_23()
	{
		if (!Class10.bool_11)
		{
			Class10.string_15 = Class10.smethod_24();
			Class10.bool_11 = true;
		}
		return Class10.string_15;
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00018718 File Offset: 0x00016918
	private static string smethod_24()
	{
		string result;
		try
		{
			string text = string.Empty;
			ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
			ManagementObjectCollection instances = managementClass.GetInstances();
			foreach (ManagementBaseObject managementBaseObject in instances)
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				try
				{
					if (managementObject.Properties["Product"] != null && managementObject.Properties["Product"].Value != null && text == string.Empty)
					{
						text = managementObject.Properties["Product"].Value.ToString();
						if (text.Length != 0)
						{
							break;
						}
						text = string.Empty;
					}
				}
				catch
				{
				}
			}
			if (text == string.Empty)
			{
				text = "";
			}
			result = text;
		}
		catch
		{
			result = "";
		}
		return result;
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00002FBF File Offset: 0x000011BF
	private static string smethod_25()
	{
		if (!Class10.bool_12)
		{
			Class10.string_16 = Class10.smethod_26();
			Class10.bool_12 = true;
		}
		return Class10.string_16;
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00018820 File Offset: 0x00016A20
	private static string smethod_26()
	{
		string result;
		try
		{
			string text = string.Empty;
			ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
			ManagementObjectCollection instances = managementClass.GetInstances();
			foreach (ManagementBaseObject managementBaseObject in instances)
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				try
				{
					if (text == string.Empty && managementObject.Properties["Manufacturer"] != null && managementObject.Properties["Manufacturer"].Value != null)
					{
						text = managementObject.Properties["Manufacturer"].Value.ToString();
						if (text.Length != 0)
						{
							break;
						}
						text = string.Empty;
					}
				}
				catch
				{
				}
			}
			if (text == string.Empty)
			{
				text = "";
			}
			result = text;
		}
		catch
		{
			result = "";
		}
		return result;
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00002FDD File Offset: 0x000011DD
	private static string smethod_27()
	{
		if (!Class10.bool_13)
		{
			Class10.string_17 = Class10.smethod_28();
			Class10.bool_13 = true;
		}
		return Class10.string_17;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00018928 File Offset: 0x00016B28
	private static string smethod_28()
	{
		string result;
		try
		{
			string text = string.Empty;
			ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
			ManagementObjectCollection instances = managementClass.GetInstances();
			foreach (ManagementBaseObject managementBaseObject in instances)
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				try
				{
					if (text == string.Empty && managementObject.Properties["SerialNumber"] != null && managementObject.Properties["SerialNumber"].Value != null)
					{
						text = managementObject.Properties["SerialNumber"].Value.ToString();
						if (text.Length != 0)
						{
							break;
						}
						text = string.Empty;
					}
				}
				catch
				{
				}
			}
			if (text == string.Empty)
			{
				text = "";
			}
			result = text;
		}
		catch
		{
			result = "";
		}
		return result;
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00018A30 File Offset: 0x00016C30
	internal static Class10.Class21 smethod_29()
	{
		Class10.Class21 @class = new Class10.Class21();
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_BIOS");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					Class10.Class24 class2 = new Class10.Class24("BIOS");
					if (managementObject.Properties["Manufacturer"].Value != null)
					{
						class2.method_6("Manufacturer", managementObject.Properties["Manufacturer"].Value.ToString(), "");
					}
					else
					{
						class2.method_6("Manufacturer", "", "");
					}
					if (managementObject.Properties["Version"].Value != null)
					{
						class2.method_6("Version", managementObject.Properties["Version"].Value.ToString(), "");
					}
					else
					{
						class2.method_6("Version", "", "");
					}
					if (managementObject.Properties["SMBIOSBIOSVersion"].Value != null)
					{
						class2.method_6("SMBIOSBIOSVersion", managementObject.Properties["SMBIOSBIOSVersion"].Value.ToString(), "");
					}
					else
					{
						class2.method_6("SMBIOSBIOSVersion", "", "");
					}
					@class.method_0().method_2(class2);
				}
			}
		}
		catch
		{
		}
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_BaseBoard");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator2 = instances.GetEnumerator())
			{
				if (enumerator2.MoveNext())
				{
					ManagementObject managementObject2 = (ManagementObject)enumerator2.Current;
					Class10.Class24 class3 = new Class10.Class24("BOARD");
					if (managementObject2.Properties["Manufacturer"].Value != null)
					{
						class3.method_6("Manufacturer", managementObject2.Properties["Manufacturer"].Value.ToString(), "");
					}
					else
					{
						class3.method_6("Manufacturer", "", "");
					}
					@class.method_0().method_2(class3);
				}
			}
		}
		catch
		{
		}
		try
		{
			ManagementClass managementClass = new ManagementClass("Win32_Processor");
			ManagementObjectCollection instances = managementClass.GetInstances();
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator3 = instances.GetEnumerator())
			{
				if (enumerator3.MoveNext())
				{
					ManagementObject managementObject3 = (ManagementObject)enumerator3.Current;
					Class10.Class24 class4 = new Class10.Class24("PROCESSOR");
					if (managementObject3.Properties["Manufacturer"].Value != null)
					{
						class4.method_6("Manufacturer", managementObject3.Properties["Manufacturer"].Value.ToString(), "");
					}
					else
					{
						class4.method_6("Manufacturer", "", "");
					}
					if (managementObject3.Properties["Name"].Value != null)
					{
						class4.method_6("Name", managementObject3.Properties["Name"].Value.ToString(), "");
					}
					else
					{
						class4.method_6("Name", "", "");
					}
					if (managementObject3.Properties["ProcessorId"].Value != null)
					{
						class4.method_6("ProcessorId", managementObject3.Properties["ProcessorId"].Value.ToString(), "");
					}
					else
					{
						class4.method_6("ProcessorId", "", "");
					}
					@class.method_0().method_2(class4);
				}
			}
		}
		catch
		{
		}
		return @class;
	}

	// Token: 0x060001FB RID: 507 RVA: 0x00018E7C File Offset: 0x0001707C
	public string method_16()
	{
		byte[] array = this.method_15();
		string text = "";
		for (int i = 0; i < array.Length; i++)
		{
			text += array[i].ToString("D3");
		}
		return text;
	}

	// Token: 0x060001FC RID: 508 RVA: 0x00018EC0 File Offset: 0x000170C0
	public static string smethod_30(DateTime dateTime_0)
	{
		return Class10.smethod_33(new byte[]
		{
			Convert.ToByte(dateTime_0.Year.ToString("D4").Substring(0, 2)),
			Convert.ToByte(dateTime_0.Year.ToString("D4").Substring(2, 2)),
			Convert.ToByte(dateTime_0.Month),
			Convert.ToByte(dateTime_0.Day)
		});
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00018F40 File Offset: 0x00017140
	public static DateTime smethod_31(string string_18)
	{
		byte[] array = new byte[string_18.Length / 3];
		for (int i = 0; i < string_18.Length / 3; i++)
		{
			array[i] = Convert.ToByte(string_18.Substring(i * 3, 3));
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class10 @class = new Class10();
		array = @class.method_10(memoryStream, true);
		DateTime result = new DateTime(Convert.ToInt32(array[0].ToString("D2") + array[1].ToString("D2")), (int)array[2], (int)array[3]);
		return result;
	}

	// Token: 0x060001FE RID: 510 RVA: 0x00018FEC File Offset: 0x000171EC
	public static string smethod_32(object object_0)
	{
		string text = "";
		for (int i = 0; i < object_0.Length; i++)
		{
			text += object_0[i].ToString("D3");
		}
		return text;
	}

	// Token: 0x060001FF RID: 511 RVA: 0x00019028 File Offset: 0x00017228
	public static string smethod_33(byte[] byte_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(byte_0, 0, byte_0.Length);
		memoryStream.Position = 0L;
		Class10 @class = new Class10();
		return Class10.smethod_32(@class.method_5(memoryStream, true));
	}

	// Token: 0x06000200 RID: 512 RVA: 0x00019068 File Offset: 0x00017268
	public static string smethod_34(string string_18, byte[] byte_0)
	{
		byte[] array = new byte[string_18.Length];
		for (int i = 0; i < string_18.Length; i++)
		{
			array[i] = Convert.ToByte(string_18[i]);
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class10 @class = new Class10();
		byte[] inArray = @class.method_8(memoryStream, byte_0, true);
		return Class10.smethod_3(Convert.ToBase64String(inArray));
	}

	// Token: 0x06000201 RID: 513 RVA: 0x000190E0 File Offset: 0x000172E0
	public static string smethod_35(string string_18, byte[] byte_0)
	{
		byte[] array = new byte[string_18.Length];
		for (int i = 0; i < string_18.Length; i++)
		{
			array[i] = Convert.ToByte(string_18[i]);
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class10 @class = new Class10();
		byte[] inArray = @class.method_8(memoryStream, byte_0, true);
		return Convert.ToBase64String(inArray);
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00019154 File Offset: 0x00017354
	public static string smethod_36(string string_18, byte[] byte_0)
	{
		byte[] array = Convert.FromBase64String(string_18);
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class10 @class = new Class10();
		byte[] array2 = @class.method_11(memoryStream, byte_0, true);
		string text = "";
		for (int i = 0; i < array2.Length; i++)
		{
			text += (char)array2[i];
		}
		return text;
	}

	// Token: 0x06000203 RID: 515 RVA: 0x000191C8 File Offset: 0x000173C8
	public static string smethod_37(string string_18)
	{
		byte[] array = new byte[string_18.Length];
		for (int i = 0; i < string_18.Length; i++)
		{
			array[i] = Convert.ToByte(string_18[i]);
		}
		return Class10.smethod_33(array);
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00019208 File Offset: 0x00017408
	public static string smethod_38(string string_18)
	{
		byte[] array = new byte[string_18.Length / 3];
		for (int i = 0; i < string_18.Length / 3; i++)
		{
			array[i] = Convert.ToByte(string_18.Substring(i * 3, 3));
		}
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(array, 0, array.Length);
		memoryStream.Position = 0L;
		Class10 @class = new Class10();
		array = @class.method_10(memoryStream, true);
		string text = "";
		for (int j = 0; j < array.Length; j++)
		{
			text += Convert.ToChar(array[j]);
		}
		return text;
	}

	// Token: 0x06000205 RID: 517 RVA: 0x000192A8 File Offset: 0x000174A8
	static Class10()
	{
		Class8.ah6VSoGzeNXX5();
		Class10.string_4 = "";
		Class10.bool_0 = false;
		Class10.string_5 = "";
		Class10.bool_1 = false;
		Class10.string_6 = "";
		Class10.bool_2 = false;
		Class10.string_7 = "";
		Class10.bool_3 = false;
		Class10.string_8 = "";
		Class10.bool_4 = false;
		Class10.string_9 = "";
		Class10.bool_5 = false;
		Class10.string_10 = "";
		Class10.bool_6 = false;
		Class10.string_11 = "";
		Class10.bool_7 = false;
		Class10.string_12 = "";
		Class10.bool_8 = false;
		Class10.string_13 = "";
		Class10.bool_9 = false;
		Class10.string_14 = "";
		Class10.bool_10 = false;
		Class10.string_15 = "";
		Class10.bool_11 = false;
		Class10.string_16 = "";
		Class10.bool_12 = false;
		Class10.string_17 = "";
		Class10.bool_13 = false;
	}

	// Token: 0x0400018F RID: 399
	private string string_0;

	// Token: 0x04000190 RID: 400
	private string string_1;

	// Token: 0x04000191 RID: 401
	private string string_2;

	// Token: 0x04000192 RID: 402
	private string string_3;

	// Token: 0x04000193 RID: 403
	private static string string_4;

	// Token: 0x04000194 RID: 404
	private static bool bool_0;

	// Token: 0x04000195 RID: 405
	private static string string_5;

	// Token: 0x04000196 RID: 406
	private static bool bool_1;

	// Token: 0x04000197 RID: 407
	private static string string_6;

	// Token: 0x04000198 RID: 408
	private static bool bool_2;

	// Token: 0x04000199 RID: 409
	private static string string_7;

	// Token: 0x0400019A RID: 410
	private static bool bool_3;

	// Token: 0x0400019B RID: 411
	private static string string_8;

	// Token: 0x0400019C RID: 412
	private static bool bool_4;

	// Token: 0x0400019D RID: 413
	private static string string_9;

	// Token: 0x0400019E RID: 414
	private static bool bool_5;

	// Token: 0x0400019F RID: 415
	private static string string_10;

	// Token: 0x040001A0 RID: 416
	private static bool bool_6;

	// Token: 0x040001A1 RID: 417
	private static string string_11;

	// Token: 0x040001A2 RID: 418
	private static bool bool_7;

	// Token: 0x040001A3 RID: 419
	private static string string_12;

	// Token: 0x040001A4 RID: 420
	private static bool bool_8;

	// Token: 0x040001A5 RID: 421
	private static string string_13;

	// Token: 0x040001A6 RID: 422
	private static bool bool_9;

	// Token: 0x040001A7 RID: 423
	private static string string_14;

	// Token: 0x040001A8 RID: 424
	private static bool bool_10;

	// Token: 0x040001A9 RID: 425
	private static string string_15;

	// Token: 0x040001AA RID: 426
	private static bool bool_11;

	// Token: 0x040001AB RID: 427
	private static string string_16;

	// Token: 0x040001AC RID: 428
	private static bool bool_12;

	// Token: 0x040001AD RID: 429
	private static string string_17;

	// Token: 0x040001AE RID: 430
	private static bool bool_13;

	// Token: 0x0200002C RID: 44
	internal class Class11
	{
		// Token: 0x06000206 RID: 518 RVA: 0x00002FFB File Offset: 0x000011FB
		internal static string smethod_0()
		{
			return "{nohid-22222-10001-00000}";
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0001939C File Offset: 0x0001759C
		internal static string smethod_1(bool bool_5, bool bool_6, bool bool_7, bool bool_8)
		{
			string text = Class10.smethod_5(bool_5, bool_6, bool_7, bool_8);
			byte[] array = Class10.smethod_1(text);
			Class10.Class19.smethod_4();
			byte[] array2 = Class10.Class19.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0001949C File Offset: 0x0001769C
		internal static string smethod_2(bool bool_5, bool bool_6, bool bool_7, bool bool_8)
		{
			string text = Class10.smethod_6(bool_5, bool_6, bool_7, bool_8);
			byte[] array = Class10.smethod_1(text);
			Class10.Class19.smethod_4();
			byte[] array2 = Class10.Class19.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0001959C File Offset: 0x0001779C
		internal static string KefSrjlCea(bool bool_5, bool bool_6, bool bool_7, bool bool_8)
		{
			string text = Class10.smethod_7(bool_5, bool_6, bool_7, bool_8);
			byte[] array = Class10.smethod_1(text);
			Class10.Class19.smethod_4();
			byte[] array2 = Class10.Class19.smethod_6(text);
			text = "";
			for (int i = 0; i < array2.Length; i++)
			{
				text += array2[i].ToString("X2");
			}
			for (int j = 0; j < array.Length; j++)
			{
				text += array[j].ToString("X2");
			}
			text = text.Substring(0, 20);
			return string.Concat(new string[]
			{
				text.Substring(0, 4),
				"-",
				text.Substring(4, 4),
				"-",
				text.Substring(8, 4),
				"-",
				text.Substring(12, 4),
				"-",
				text.Substring(16, 4)
			});
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00003002 File Offset: 0x00001202
		internal static string smethod_3(bool bool_5, bool bool_6, bool bool_7, bool bool_8)
		{
			return Class10.smethod_9(bool_5, bool_6, bool_7, bool_8);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000300D File Offset: 0x0000120D
		internal static string smethod_4(bool bool_5, bool bool_6, bool bool_7, bool bool_8)
		{
			return Class10.smethod_10(bool_5, bool_6, bool_7, bool_8);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00003018 File Offset: 0x00001218
		internal static string smethod_5(bool bool_5, bool bool_6, bool bool_7, bool bool_8)
		{
			return Class10.smethod_11(bool_5, bool_6, bool_7, bool_8);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00002402 File Offset: 0x00000602
		private Class11()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0001969C File Offset: 0x0001789C
		public static string smethod_6(Color color_0)
		{
			return color_0.R.ToString("D3") + color_0.G.ToString("D3") + color_0.B.ToString("D3");
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00003023 File Offset: 0x00001223
		public static Color smethod_7(string string_3)
		{
			return Color.FromArgb((int)Convert.ToByte(string_3.Substring(0, 3)), (int)Convert.ToByte(string_3.Substring(3, 3)), (int)Convert.ToByte(string_3.Substring(6, 3)));
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00003051 File Offset: 0x00001251
		public static void smethod_8(Icon icon_0, Graphics graphics_0)
		{
			graphics_0.DrawIcon(icon_0, 0, 0);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000196EC File Offset: 0x000178EC
		internal static bool smethod_9(string string_3, bool bool_5, bool bool_6, bool bool_7, bool bool_8)
		{
			if (string_3 == null)
			{
				return false;
			}
			string text = string_3.ToUpper().Replace("-", "").Trim();
			if (text.Length < 16)
			{
				return false;
			}
			Class10.Class11.smethod_10();
			return (!bool_5 || !(text.Substring(0, 4) != Class10.Class11.string_1)) && (!bool_6 || Class10.Class11.arrayList_0.Contains(text.Substring(4, 4))) && (!bool_7 || !(text.Substring(8, 4) != Class10.Class11.string_2)) && (!bool_8 || Class10.Class11.arrayList_1.Contains(text.Substring(12, 4)));
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00019794 File Offset: 0x00017994
		public static void smethod_10()
		{
			if (Class10.Class11.bool_4)
			{
				return;
			}
			Class10.Class11.bool_4 = true;
			byte[] array = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_17()));
			Class10.Class11.string_1 = array[3].ToString("X2");
			Class10.Class11.string_1 += array[11].ToString("X2");
			Class10.Class11.string_1 = Class10.Class11.string_1.ToUpper();
			byte[] array2 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_22()));
			Class10.Class11.string_2 = array2[3].ToString("X2");
			Class10.Class11.string_2 += array2[11].ToString("X2");
			Class10.Class11.string_2 = Class10.Class11.string_2.ToUpper();
			try
			{
				string text = Class10.Class16.smethod_0();
				if (text != null && text.Length == 12 && text != "000000000000")
				{
					byte[] array3 = Class5.smethod_9(Encoding.Unicode.GetBytes(text));
					string text2 = array3[3].ToString("X2");
					text2 += array3[11].ToString("X2");
					text2 = text2.ToUpper();
					if (!Class10.Class11.arrayList_0.Contains(text2))
					{
						Class10.Class11.arrayList_0.Add(text2);
					}
				}
			}
			catch
			{
			}
			try
			{
				ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
				ManagementObjectCollection instances = managementClass.GetInstances();
				foreach (ManagementBaseObject managementBaseObject in instances)
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					try
					{
						if (managementObject["MacAddress"] != null)
						{
							string text3 = managementObject["MacAddress"].ToString().ToUpper().Replace(":", "");
							if (text3.Length == 12 && text3 != "000000000000")
							{
								byte[] array4 = Class5.smethod_9(Encoding.Unicode.GetBytes(text3));
								string text4 = array4[3].ToString("X2");
								text4 += array4[11].ToString("X2");
								text4 = text4.ToUpper();
								if (!Class10.Class11.arrayList_0.Contains(text4))
								{
									Class10.Class11.arrayList_0.Add(text4);
								}
							}
						}
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			try
			{
				byte[] array5 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_16()));
				string text5 = array5[3].ToString("X2");
				text5 += array5[11].ToString("X2");
				text5 = text5.ToUpper();
				if (!Class10.Class11.arrayList_1.Contains(text5))
				{
					Class10.Class11.arrayList_1.Add(text5);
				}
				byte[] array6 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_13()));
				string text6 = array6[3].ToString("X2");
				text6 += array6[11].ToString("X2");
				text6 = text6.ToUpper();
				if (!Class10.Class11.arrayList_1.Contains(text6))
				{
					Class10.Class11.arrayList_1.Add(text6);
				}
				byte[] array7 = Class5.smethod_9(Encoding.Unicode.GetBytes(Class10.smethod_14()));
				string text7 = array7[3].ToString("X2");
				text7 += array7[11].ToString("X2");
				text7 = text7.ToUpper();
				if (!Class10.Class11.arrayList_1.Contains(text7))
				{
					Class10.Class11.arrayList_1.Add(text7);
				}
				try
				{
					ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
					foreach (ManagementBaseObject managementBaseObject2 in managementObjectSearcher.Get())
					{
						ManagementObject managementObject2 = (ManagementObject)managementBaseObject2;
						if (managementObject2["DeviceID"] != null && managementObject2["InterfaceType"] != null && managementObject2["InterfaceType"].ToString() != "USB" && managementObject2["InterfaceType"].ToString() != "1394")
						{
							bool flag = true;
							if (managementObject2["MediaType"] != null && managementObject2["MediaType"].ToString() == "Removable Media")
							{
								flag = false;
							}
							if (flag && managementObject2["SerialNumber"] != null)
							{
								object obj = managementObject2["SerialNumber"];
								if (obj != null && !(obj.ToString().Trim() == string.Empty) && obj.ToString()[0] != Convert.ToChar(31))
								{
									string text8 = obj.ToString().Trim();
									if (text8.Length > 0)
									{
										byte[] array8 = Class5.smethod_9(Encoding.Unicode.GetBytes(text8));
										text8 = array8[3].ToString("X2");
										text8 += array8[11].ToString("X2");
										text8 = text8.ToUpper();
										if (!Class10.Class11.arrayList_1.Contains(text8))
										{
											Class10.Class11.arrayList_1.Add(text8);
										}
									}
								}
							}
						}
					}
					managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
					ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
					foreach (ManagementBaseObject managementBaseObject3 in managementObjectCollection)
					{
						ManagementObject managementObject3 = (ManagementObject)managementBaseObject3;
						if (managementObject3["SerialNumber"] != null)
						{
							object obj2 = managementObject3["SerialNumber"];
							if (obj2 != null && !(obj2.ToString() == string.Empty) && obj2.ToString()[0] != Convert.ToChar(31))
							{
								string text9 = obj2.ToString().Trim().Replace(" ", "");
								if (text9.Length > 0)
								{
									byte[] array9 = Class5.smethod_9(Encoding.Unicode.GetBytes(text9));
									text9 = array9[3].ToString("X2");
									text9 += array9[11].ToString("X2");
									text9 = text9.ToUpper();
									if (!Class10.Class11.arrayList_1.Contains(text9))
									{
										Class10.Class11.arrayList_1.Add(text9);
									}
								}
							}
						}
					}
				}
				catch
				{
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00019EF0 File Offset: 0x000180F0
		public static string smethod_11()
		{
			if (Class10.Class11.string_0.Length > 0)
			{
				return Class10.Class11.string_0;
			}
			try
			{
				string text = Class10.smethod_5(true, true, true, false);
				byte[] array = Class10.smethod_1(text);
				Class10.Class19.smethod_4();
				byte[] array2 = Class10.Class19.smethod_6(text);
				text = "";
				for (int i = 0; i < array2.Length; i++)
				{
					text += array2[i].ToString("X2");
				}
				for (int j = 0; j < array.Length; j++)
				{
					text += array[j].ToString("X2");
				}
				text = text.Substring(0, 20);
				text = string.Concat(new string[]
				{
					text.Substring(0, 4),
					"-",
					text.Substring(4, 4),
					"-",
					text.Substring(8, 4),
					"-",
					text.Substring(12, 4),
					"-",
					text.Substring(16, 4)
				});
				Class10.Class11.string_0 = text;
			}
			catch
			{
				Class10.Class11.string_0 = "3B3F-96F2-C310-5438-AC1F";
			}
			return Class10.Class11.string_0;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0001A02C File Offset: 0x0001822C
		static Class11()
		{
			Class8.ah6VSoGzeNXX5();
			Class10.Class11.string_0 = "";
			Class10.Class11.bool_0 = true;
			Class10.Class11.bool_1 = true;
			Class10.Class11.bool_2 = true;
			Class10.Class11.bool_3 = false;
			Class10.Class11.string_1 = "";
			Class10.Class11.string_2 = "";
			Class10.Class11.arrayList_0 = new ArrayList();
			Class10.Class11.arrayList_1 = new ArrayList();
			Class10.Class11.bool_4 = false;
		}

		// Token: 0x040001AF RID: 431
		internal static string string_0;

		// Token: 0x040001B0 RID: 432
		internal static bool bool_0;

		// Token: 0x040001B1 RID: 433
		internal static bool bool_1;

		// Token: 0x040001B2 RID: 434
		internal static bool bool_2;

		// Token: 0x040001B3 RID: 435
		internal static bool bool_3;

		// Token: 0x040001B4 RID: 436
		private static string string_1;

		// Token: 0x040001B5 RID: 437
		private static string string_2;

		// Token: 0x040001B6 RID: 438
		private static ArrayList arrayList_0;

		// Token: 0x040001B7 RID: 439
		private static ArrayList arrayList_1;

		// Token: 0x040001B8 RID: 440
		private static bool bool_4;
	}

	// Token: 0x0200002D RID: 45
	internal class Class12 : RSA
	{
		// Token: 0x06000215 RID: 533 RVA: 0x0000305C File Offset: 0x0000125C
		public Class12()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
			this.int_0 = 128;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00003074 File Offset: 0x00001274
		public Class12(int int_1)
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
			this.int_0 = int_1 / 8;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0001A090 File Offset: 0x00018290
		public override void FromXmlString(string xmlString)
		{
			StringReader input = new StringReader(xmlString);
			XmlTextReader xmlTextReader = new XmlTextReader(input);
			this.class13_0 = (this.class13_1 = (this.class13_2 = (this.class13_3 = (this.class13_4 = (this.class13_5 = (this.class13_6 = (this.class13_7 = null)))))));
			for (;;)
			{
				XmlNodeType xmlNodeType = xmlTextReader.MoveToContent();
				XmlNodeType xmlNodeType2 = xmlNodeType;
				switch (xmlNodeType2)
				{
				case XmlNodeType.None:
					return;
				case XmlNodeType.Element:
				{
					string name = xmlTextReader.Name;
					if (!this.method_6(xmlTextReader, name, "Modulus", ref this.class13_0) && !this.method_6(xmlTextReader, name, "Exponent", ref this.class13_1) && !this.method_6(xmlTextReader, name, "P", ref this.class13_2) && !this.method_6(xmlTextReader, name, "Q", ref this.class13_3) && !this.method_6(xmlTextReader, name, "DP", ref this.class13_4) && !this.method_6(xmlTextReader, name, "DQ", ref this.class13_5) && !this.method_6(xmlTextReader, name, "InverseQ", ref this.class13_6) && !this.method_6(xmlTextReader, name, "D", ref this.class13_7))
					{
						xmlTextReader.ReadString();
					}
					break;
				}
				default:
					if (xmlNodeType2 != XmlNodeType.EndElement)
					{
						goto Block_9;
					}
					xmlTextReader.ReadEndElement();
					break;
				}
			}
			Block_9:
			throw new ArgumentException();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0001A1FC File Offset: 0x000183FC
		public override void ImportParameters(RSAParameters parameters)
		{
			this.class13_0 = new Class10.Class13(parameters.Modulus);
			this.class13_1 = new Class10.Class13(parameters.Exponent);
			this.class13_2 = ((!object.ReferenceEquals(parameters.P, null)) ? new Class10.Class13(parameters.P) : null);
			this.class13_3 = ((!object.ReferenceEquals(parameters.Q, null)) ? new Class10.Class13(parameters.Q) : null);
			this.class13_4 = ((!object.ReferenceEquals(parameters.DP, null)) ? new Class10.Class13(parameters.DP) : null);
			this.class13_5 = ((!object.ReferenceEquals(parameters.DQ, null)) ? new Class10.Class13(parameters.DQ) : null);
			this.class13_6 = ((!object.ReferenceEquals(parameters.InverseQ, null)) ? new Class10.Class13(parameters.InverseQ) : null);
			this.class13_7 = ((!object.ReferenceEquals(parameters.D, null)) ? new Class10.Class13(parameters.D) : null);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0001A308 File Offset: 0x00018508
		public override RSAParameters ExportParameters(bool includePrivateParameters)
		{
			RSAParameters result = default(RSAParameters);
			result.Modulus = this.class13_0.method_2();
			result.Exponent = this.class13_1.method_2();
			if (includePrivateParameters)
			{
				result.P = this.class13_2.method_2();
				result.Q = this.class13_3.method_2();
				result.DP = this.class13_4.method_2();
				result.DQ = this.class13_5.method_2();
				result.InverseQ = this.class13_6.method_2();
				result.D = this.class13_7.method_2();
			}
			return result;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0001A3B4 File Offset: 0x000185B4
		public byte[] method_0(byte[] byte_1)
		{
			if (byte_1.Length != this.int_0)
			{
				throw new ArgumentException("input.Length does not match keylen");
			}
			if (object.ReferenceEquals(this.class13_0, null))
			{
				throw new ArgumentException("no key set!");
			}
			Class10.Class13 @class = new Class10.Class13(byte_1);
			if (@class >= this.class13_0)
			{
				throw new ArgumentException("input exceeds modulus");
			}
			@class = @class.method_7(this.class13_1, this.class13_0);
			byte[] byte_2 = @class.method_2();
			return this.method_5(byte_2, this.int_0);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0001A438 File Offset: 0x00018638
		public byte[] method_1(byte[] byte_1)
		{
			if (byte_1.Length != this.int_0)
			{
				throw new ArgumentException("input.Length does not match keylen");
			}
			if (object.ReferenceEquals(this.class13_7, null))
			{
				throw new ArgumentException("no private key set!");
			}
			Class10.Class13 @class = new Class10.Class13(byte_1);
			if (@class >= this.class13_0)
			{
				throw new ArgumentException("input exceeds modulus");
			}
			@class = @class.method_7(this.class13_7, this.class13_0);
			byte[] byte_2 = @class.method_2();
			return this.method_5(byte_2, this.int_0);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0001A4BC File Offset: 0x000186BC
		public bool method_2(byte[] byte_1, byte[] byte_2)
		{
			int num = byte_2.Length;
			if (num != this.int_0)
			{
				return false;
			}
			byte[] array = this.method_0(byte_2);
			if (array[0] == 0)
			{
				if (array[1] == 1)
				{
					int num2 = array.Length;
					int i = 2;
					while (i < num2 - 1)
					{
						byte b = array[i];
						if (b != 0)
						{
							if (b != 255)
							{
								return false;
							}
							i++;
						}
						else
						{
							i++;
							int num3 = num2 - i;
							if (num3 != 34)
							{
								return false;
							}
							if (array[i + 13] != 5)
							{
								return false;
							}
							array[i + 13] = 0;
							return this.method_4(array, i, Class10.Class12.byte_0, 0, 18) && this.method_4(array, i + 18, byte_1, 0, 16);
						}
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0001A564 File Offset: 0x00018764
		public bool method_3(byte[] byte_1, byte[] byte_2)
		{
			byte[] byte_3 = Class5.smethod_9(byte_1);
			return this.method_2(byte_3, byte_2);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000308A File Offset: 0x0000128A
		public override byte[] EncryptValue(byte[] rgb)
		{
			return this.method_0(rgb);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00003093 File Offset: 0x00001293
		public override byte[] DecryptValue(byte[] rgb)
		{
			return this.method_1(rgb);
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000220 RID: 544 RVA: 0x0000309C File Offset: 0x0000129C
		public override string KeyExchangeAlgorithm
		{
			get
			{
				return "RSA-PKCS1-KeyEx";
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000221 RID: 545 RVA: 0x000030A3 File Offset: 0x000012A3
		public override string SignatureAlgorithm
		{
			get
			{
				return "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000222 RID: 546 RVA: 0x000030AA File Offset: 0x000012AA
		// (set) Token: 0x06000223 RID: 547 RVA: 0x000030B4 File Offset: 0x000012B4
		public override int KeySize
		{
			get
			{
				return this.int_0 * 8;
			}
			set
			{
				throw new ArgumentException();
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0001A580 File Offset: 0x00018780
		protected override void Dispose(bool disposing)
		{
			this.class13_0 = (this.class13_1 = (this.class13_2 = (this.class13_3 = (this.class13_4 = (this.class13_5 = (this.class13_6 = (this.class13_7 = null)))))));
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0001A5DC File Offset: 0x000187DC
		private bool method_4(byte[] byte_1, int int_1, byte[] byte_2, int int_2, int int_3)
		{
			for (int i = 0; i < int_3; i++)
			{
				if (byte_1[i + int_1] != byte_2[i + int_2])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0001A608 File Offset: 0x00018808
		private byte[] method_5(byte[] byte_1, int int_1)
		{
			int num = byte_1.Length;
			if (num >= int_1)
			{
				return byte_1;
			}
			byte[] array = new byte[int_1];
			int num2 = int_1 - num;
			for (int i = 0; i < num2; i++)
			{
				array[i] = 0;
			}
			Array.Copy(byte_1, 0, array, num2, num);
			return array;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0001A648 File Offset: 0x00018848
		private bool method_6(XmlReader xmlReader_0, string string_0, string string_1, ref Class10.Class13 class13_8)
		{
			if (string.Compare(string_0, string_1, true) != 0)
			{
				return false;
			}
			string s = xmlReader_0.ReadString();
			byte[] array = Convert.FromBase64String(s);
			Class10.Class13 @class = new Class10.Class13(array);
			class13_8 = @class;
			return true;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x000030BB File Offset: 0x000012BB
		static Class12()
		{
			Class8.ah6VSoGzeNXX5();
			Class10.Class12.byte_0 = new byte[]
			{
				48,
				32,
				48,
				12,
				6,
				8,
				42,
				134,
				72,
				134,
				247,
				13,
				2,
				0,
				5,
				0,
				4,
				16
			};
		}

		// Token: 0x040001B9 RID: 441
		private static byte[] byte_0;

		// Token: 0x040001BA RID: 442
		private int int_0;

		// Token: 0x040001BB RID: 443
		private Class10.Class13 class13_0;

		// Token: 0x040001BC RID: 444
		private Class10.Class13 class13_1;

		// Token: 0x040001BD RID: 445
		private Class10.Class13 class13_2;

		// Token: 0x040001BE RID: 446
		private Class10.Class13 class13_3;

		// Token: 0x040001BF RID: 447
		private Class10.Class13 class13_4;

		// Token: 0x040001C0 RID: 448
		private Class10.Class13 class13_5;

		// Token: 0x040001C1 RID: 449
		private Class10.Class13 class13_6;

		// Token: 0x040001C2 RID: 450
		private Class10.Class13 class13_7;
	}

	// Token: 0x0200002E RID: 46
	internal enum Enum1
	{

	}

	// Token: 0x0200002F RID: 47
	internal class Class13
	{
		// Token: 0x06000229 RID: 553 RVA: 0x000030D9 File Offset: 0x000012D9
		public Class13(Class10.Enum1 enum1_0, uint uint_2)
		{
			Class8.ah6VSoGzeNXX5();
			this.uint_0 = 1U;
			base..ctor();
			this.uint_1 = new uint[uint_2];
			this.uint_0 = uint_2;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00003101 File Offset: 0x00001301
		public Class13(Class10.Class13 class13_0)
		{
			Class8.ah6VSoGzeNXX5();
			this.uint_0 = 1U;
			base..ctor();
			this.uint_1 = (uint[])class13_0.uint_1.Clone();
			this.uint_0 = class13_0.uint_0;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0001A67C File Offset: 0x0001887C
		public Class13(Class10.Class13 class13_0, uint uint_2)
		{
			Class8.ah6VSoGzeNXX5();
			this.uint_0 = 1U;
			base..ctor();
			this.uint_1 = new uint[uint_2];
			for (uint num = 0U; num < class13_0.uint_0; num += 1U)
			{
				this.uint_1[(int)((UIntPtr)num)] = class13_0.uint_1[(int)((UIntPtr)num)];
			}
			this.uint_0 = class13_0.uint_0;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0001A6D8 File Offset: 0x000188D8
		public Class13(byte[] byte_0)
		{
			Class8.ah6VSoGzeNXX5();
			this.uint_0 = 1U;
			base..ctor();
			this.uint_0 = (uint)byte_0.Length >> 2;
			int num = byte_0.Length & 3;
			if (num != 0)
			{
				this.uint_0 += 1U;
			}
			this.uint_1 = new uint[this.uint_0];
			int i = byte_0.Length - 1;
			int num2 = 0;
			while (i >= 3)
			{
				this.uint_1[num2] = (uint)((int)byte_0[i - 3] << 24 | (int)byte_0[i - 2] << 16 | (int)byte_0[i - 1] << 8 | (int)byte_0[i]);
				i -= 4;
				num2++;
			}
			switch (num)
			{
			case 1:
				this.uint_1[(int)((UIntPtr)(this.uint_0 - 1U))] = (uint)byte_0[0];
				break;
			case 2:
				this.uint_1[(int)((UIntPtr)(this.uint_0 - 1U))] = (uint)((int)byte_0[0] << 8 | (int)byte_0[1]);
				break;
			case 3:
				this.uint_1[(int)((UIntPtr)(this.uint_0 - 1U))] = (uint)((int)byte_0[0] << 16 | (int)byte_0[1] << 8 | (int)byte_0[2]);
				break;
			}
			this.method_5();
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0001A7D4 File Offset: 0x000189D4
		public Class13(uint uint_2)
		{
			Class8.ah6VSoGzeNXX5();
			this.uint_0 = 1U;
			base..ctor();
			this.uint_1 = new uint[]
			{
				uint_2
			};
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0001A808 File Offset: 0x00018A08
		public Class13(ulong ulong_0)
		{
			Class8.ah6VSoGzeNXX5();
			this.uint_0 = 1U;
			base..ctor();
			this.uint_1 = new uint[]
			{
				(uint)ulong_0,
				(uint)(ulong_0 >> 32)
			};
			this.uint_0 = 2U;
			this.method_5();
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00003137 File Offset: 0x00001337
		public static implicit operator Class10.Class13(uint uint_2)
		{
			return new Class10.Class13(uint_2);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000313F File Offset: 0x0000133F
		public static implicit operator Class10.Class13(int int_0)
		{
			if (int_0 < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			return new Class10.Class13((uint)int_0);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00003156 File Offset: 0x00001356
		public static implicit operator Class10.Class13(ulong ulong_0)
		{
			return new Class10.Class13(ulong_0);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000315E File Offset: 0x0000135E
		public static Class10.Class13 operator +(Class10.Class13 class13_0, Class10.Class13 class13_1)
		{
			if (class13_0 == 0U)
			{
				return new Class10.Class13(class13_1);
			}
			if (class13_1 == 0U)
			{
				return new Class10.Class13(class13_0);
			}
			return Class10.Class15.smethod_0(class13_0, class13_1);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0001A850 File Offset: 0x00018A50
		public static Class10.Class13 operator -(Class10.Class13 class13_0, uint[] uint_2)
		{
			if (uint_2 == 0U)
			{
				return new Class10.Class13(class13_0);
			}
			if (class13_0 == 0U)
			{
				throw new ArithmeticException();
			}
			switch (Class10.Class15.smethod_4(class13_0, uint_2))
			{
			case (Class10.Enum1)(-1):
				throw new ArithmeticException();
			case (Class10.Enum1)0:
				return 0;
			case (Class10.Enum1)1:
				return Class10.Class15.smethod_1(class13_0, uint_2);
			default:
				throw new Exception();
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00003187 File Offset: 0x00001387
		public static int operator %(uint[] uint_2, int int_0)
		{
			if (int_0 > 0)
			{
				return (int)Class10.Class15.smethod_6(uint_2, (uint)int_0);
			}
			return (int)(-(int)Class10.Class15.smethod_6(uint_2, (uint)(-(uint)int_0)));
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000319E File Offset: 0x0000139E
		public static uint operator %(uint[] uint_2, uint uint_3)
		{
			return Class10.Class15.smethod_6(uint_2, uint_3);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x000031A7 File Offset: 0x000013A7
		public static Class10.Class13 operator %(object object_0, object object_1)
		{
			return Class10.Class15.smethod_9(object_0, object_1)[1];
		}

		// Token: 0x06000237 RID: 567 RVA: 0x000031B2 File Offset: 0x000013B2
		public static Class10.Class13 operator /(uint[] uint_2, int int_0)
		{
			if (int_0 <= 0)
			{
				throw new ArithmeticException();
			}
			return Class10.Class15.smethod_7(uint_2, (uint)int_0);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x000031C5 File Offset: 0x000013C5
		public static Class10.Class13 operator /(object object_0, object object_1)
		{
			return Class10.Class15.smethod_9(object_0, object_1)[0];
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0001A8B4 File Offset: 0x00018AB4
		public static Class10.Class13 operator *(uint[] uint_2, uint[] uint_3)
		{
			if (uint_2 == 0U || uint_3 == 0U)
			{
				return 0;
			}
			if ((long)uint_2.uint_1.Length < (long)((ulong)uint_2.uint_0))
			{
				throw new IndexOutOfRangeException("bi1 out of range");
			}
			if ((long)uint_3.uint_1.Length < (long)((ulong)uint_3.uint_0))
			{
				throw new IndexOutOfRangeException("bi2 out of range");
			}
			Class10.Class13 @class = new Class10.Class13((Class10.Enum1)1, uint_2.uint_0 + uint_3.uint_0);
			Class10.Class15.smethod_13(uint_2.uint_1, 0U, uint_2.uint_0, uint_3.uint_1, 0U, uint_3.uint_0, @class.uint_1, 0U);
			@class.method_5();
			return @class;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000031D0 File Offset: 0x000013D0
		public static Class10.Class13 operator *(Class10.Class13 class13_0, int int_0)
		{
			if (int_0 < 0)
			{
				throw new ArithmeticException();
			}
			if (int_0 == 0)
			{
				return 0;
			}
			if (int_0 == 1)
			{
				return new Class10.Class13(class13_0);
			}
			return Class10.Class15.smethod_12(class13_0, (uint)int_0);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000031F8 File Offset: 0x000013F8
		public static Class10.Class13 operator <<(object object_0, int int_0)
		{
			return Class10.Class15.smethod_10(object_0, int_0);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00003201 File Offset: 0x00001401
		public static Class10.Class13 operator >>(object object_0, int int_0)
		{
			return Class10.Class15.smethod_11(object_0, int_0);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0001A958 File Offset: 0x00018B58
		public int method_0()
		{
			this.method_5();
			uint num = this.uint_1[(int)((UIntPtr)(this.uint_0 - 1U))];
			uint num2 = 2147483648U;
			uint num3 = 32U;
			while (num3 > 0U && (num & num2) == 0U)
			{
				num3 -= 1U;
				num2 >>= 1;
			}
			return (int)(num3 + (this.uint_0 - 1U << 5));
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0001A9A8 File Offset: 0x00018BA8
		public bool method_1(int int_0)
		{
			if (int_0 < 0)
			{
				throw new IndexOutOfRangeException("bitNum out of range");
			}
			uint num = (uint)int_0 >> 5;
			byte b = (byte)(int_0 & 31);
			uint num2 = 1U << (int)b;
			return (this.uint_1[(int)((UIntPtr)num)] | num2) == this.uint_1[(int)((UIntPtr)num)];
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000320A File Offset: 0x0000140A
		public byte[] method_2()
		{
			return this.method_3();
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0001A9EC File Offset: 0x00018BEC
		public byte[] method_3()
		{
			if (this == 0U)
			{
				return new byte[1];
			}
			int num = this.method_0();
			int num2 = num >> 3;
			if ((num & 7) != 0)
			{
				num2++;
			}
			byte[] array = new byte[num2];
			int num3 = num2 & 3;
			if (num3 == 0)
			{
				num3 = 4;
			}
			int num4 = 0;
			for (int i = (int)(this.uint_0 - 1U); i >= 0; i--)
			{
				uint num5 = this.uint_1[i];
				for (int j = num3 - 1; j >= 0; j--)
				{
					array[num4 + j] = (byte)(num5 & 255U);
					num5 >>= 8;
				}
				num4 += num3;
				num3 = 4;
			}
			return array;
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00003212 File Offset: 0x00001412
		public static bool operator ==(object object_0, uint uint_2)
		{
			if (object_0.uint_0 != 1U)
			{
				object_0.method_5();
			}
			return object_0.uint_0 == 1U && object_0.uint_1[0] == uint_2;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00003239 File Offset: 0x00001439
		public static bool operator !=(object object_0, uint uint_2)
		{
			if (object_0.uint_0 != 1U)
			{
				object_0.method_5();
			}
			return object_0.uint_0 != 1U || object_0.uint_1[0] != uint_2;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00003263 File Offset: 0x00001463
		public static bool operator ==(uint[] uint_2, uint[] uint_3)
		{
			return uint_2 == uint_3 || (!(null == uint_2) && !(null == uint_3) && Class10.Class15.smethod_4(uint_2, uint_3) == (Class10.Enum1)0);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00003289 File Offset: 0x00001489
		public static bool operator !=(uint[] uint_2, uint[] uint_3)
		{
			return uint_2 != uint_3 && (null == uint_2 || null == uint_3 || Class10.Class15.smethod_4(uint_2, uint_3) != (Class10.Enum1)0);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000032B2 File Offset: 0x000014B2
		public static bool operator >(uint[] uint_2, uint[] uint_3)
		{
			return Class10.Class15.smethod_4(uint_2, uint_3) > (Class10.Enum1)0;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000032BE File Offset: 0x000014BE
		public static bool operator <(uint[] uint_2, uint[] uint_3)
		{
			return Class10.Class15.smethod_4(uint_2, uint_3) < (Class10.Enum1)0;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000032CA File Offset: 0x000014CA
		public static bool operator >=(uint[] uint_2, uint[] uint_3)
		{
			return Class10.Class15.smethod_4(uint_2, uint_3) >= (Class10.Enum1)0;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x000032D9 File Offset: 0x000014D9
		public static bool operator <=(uint[] uint_2, uint[] uint_3)
		{
			return Class10.Class15.smethod_4(uint_2, uint_3) <= (Class10.Enum1)0;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x000032E8 File Offset: 0x000014E8
		public Class10.Enum1 method_4(Class10.Class13 class13_0)
		{
			return Class10.Class15.smethod_4(this, class13_0);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0001AA84 File Offset: 0x00018C84
		internal void method_5()
		{
			while (this.uint_0 > 0U && this.uint_1[(int)((UIntPtr)(this.uint_0 - 1U))] == 0U)
			{
				this.uint_0 -= 1U;
			}
			if (this.uint_0 == 0U)
			{
				this.uint_0 += 1U;
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0001AAD4 File Offset: 0x00018CD4
		public override int GetHashCode()
		{
			uint num = 0U;
			for (uint num2 = 0U; num2 < this.uint_0; num2 += 1U)
			{
				num ^= this.uint_1[(int)((UIntPtr)num2)];
			}
			return (int)num;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0001AB04 File Offset: 0x00018D04
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is int)
			{
				return (int)obj >= 0 && this == (uint)obj;
			}
			Class10.Class13 uint_ = obj as Class10.Class13;
			return !(uint_ == null) && Class10.Class15.smethod_4(this, uint_) == (Class10.Enum1)0;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x000032F1 File Offset: 0x000014F1
		public Class10.Class13 method_6(Class10.Class13 class13_0)
		{
			return Class10.Class15.smethod_16(this, class13_0);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0001AB54 File Offset: 0x00018D54
		public Class10.Class13 method_7(Class10.Class13 class13_0, Class10.Class13 class13_1)
		{
			Class10.Class14 @class = new Class10.Class14(class13_1);
			return @class.method_3(this, class13_0);
		}

		// Token: 0x040001C4 RID: 452
		internal uint uint_0;

		// Token: 0x040001C5 RID: 453
		internal uint[] uint_1;
	}

	// Token: 0x02000030 RID: 48
	internal sealed class Class14
	{
		// Token: 0x0600024F RID: 591 RVA: 0x0001AB70 File Offset: 0x00018D70
		public Class14(Class10.Class13 class13_2)
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
			this.class13_0 = class13_2;
			uint num = this.class13_0.uint_0 << 1;
			this.class13_1 = new Class10.Class13((Class10.Enum1)1, num + 1U);
			this.class13_1.uint_1[(int)((UIntPtr)num)] = 1U;
			this.class13_1 /= this.class13_0;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0001ABD4 File Offset: 0x00018DD4
		public void method_0(Class10.Class13 class13_2)
		{
			Class10.Class13 @class = this.class13_0;
			uint uint_ = @class.uint_0;
			uint num = uint_ + 1U;
			uint num2 = uint_ - 1U;
			if (class13_2.uint_0 < uint_)
			{
				return;
			}
			if ((long)class13_2.uint_1.Length < (long)((ulong)class13_2.uint_0))
			{
				throw new IndexOutOfRangeException("x out of range");
			}
			Class10.Class13 class2 = new Class10.Class13((Class10.Enum1)1, class13_2.uint_0 - num2 + this.class13_1.uint_0);
			Class10.Class15.smethod_13(class13_2.uint_1, num2, class13_2.uint_0 - num2, this.class13_1.uint_1, 0U, this.class13_1.uint_0, class2.uint_1, 0U);
			uint uint_2 = (class13_2.uint_0 > num) ? num : class13_2.uint_0;
			class13_2.uint_0 = uint_2;
			class13_2.method_5();
			Class10.Class13 class3 = new Class10.Class13((Class10.Enum1)1, num);
			Class10.Class15.smethod_14(class2.uint_1, (int)num, (int)(class2.uint_0 - num), @class.uint_1, 0, (int)@class.uint_0, class3.uint_1, 0, (int)num);
			class3.method_5();
			if (class3 <= class13_2)
			{
				Class10.Class15.smethod_2(class13_2, class3);
			}
			else
			{
				Class10.Class13 class4 = new Class10.Class13((Class10.Enum1)1, num + 1U);
				class4.uint_1[(int)((UIntPtr)num)] = 1U;
				Class10.Class15.smethod_2(class4, class3);
				Class10.Class15.smethod_3(class13_2, class4);
			}
			while (class13_2 >= @class)
			{
				Class10.Class15.smethod_2(class13_2, @class);
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0001AD18 File Offset: 0x00018F18
		public Class10.Class13 method_1(Class10.Class13 class13_2, Class10.Class13 class13_3)
		{
			if (!(class13_2 == 0U) && !(class13_3 == 0U))
			{
				if (class13_2 > this.class13_0)
				{
					class13_2 %= this.class13_0;
				}
				if (class13_3 > this.class13_0)
				{
					class13_3 %= this.class13_0;
				}
				Class10.Class13 @class = class13_2 * class13_3;
				this.method_0(@class);
				return @class;
			}
			return 0;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0001AD88 File Offset: 0x00018F88
		public Class10.Class13 method_2(Class10.Class13 class13_2, Class10.Class13 class13_3)
		{
			Class10.Enum1 @enum = Class10.Class15.smethod_4(class13_2, class13_3);
			Class10.Class13 @class;
			switch (@enum)
			{
			case (Class10.Enum1)(-1):
				@class = class13_3 - class13_2;
				break;
			case (Class10.Enum1)0:
				return 0;
			case (Class10.Enum1)1:
				@class = class13_2 - class13_3;
				break;
			default:
				throw new Exception();
			}
			if (@class >= this.class13_0)
			{
				if (@class.uint_0 >= this.class13_0.uint_0 << 1)
				{
					@class %= this.class13_0;
				}
				else
				{
					this.method_0(@class);
				}
			}
			if (@enum == (Class10.Enum1)(-1))
			{
				@class = this.class13_0 - @class;
			}
			return @class;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0001AE20 File Offset: 0x00019020
		public Class10.Class13 method_3(Class10.Class13 class13_2, Class10.Class13 class13_3)
		{
			Class10.Class13 @class = new Class10.Class13(1U);
			if (class13_3 == 0U)
			{
				return @class;
			}
			Class10.Class13 class2 = class13_2;
			if (class13_3.method_1(0))
			{
				@class = class13_2;
			}
			for (int i = 1; i < class13_3.method_0(); i++)
			{
				class2 = this.method_1(class2, class2);
				if (class13_3.method_1(i))
				{
					@class = this.method_1(class2, @class);
				}
			}
			return @class;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000032FA File Offset: 0x000014FA
		public Class10.Class13 method_4(uint uint_0, Class10.Class13 class13_2)
		{
			return this.method_3(new Class10.Class13(uint_0), class13_2);
		}

		// Token: 0x040001C6 RID: 454
		private Class10.Class13 class13_0;

		// Token: 0x040001C7 RID: 455
		private Class10.Class13 class13_1;
	}

	// Token: 0x02000031 RID: 49
	private sealed class Class15
	{
		// Token: 0x06000255 RID: 597 RVA: 0x0001AE7C File Offset: 0x0001907C
		public static Class10.Class13 smethod_0(uint[] uint_0, uint[] uint_1)
		{
			uint num = 0U;
			uint[] uint_2;
			uint uint_3;
			uint[] uint_4;
			uint uint_5;
			if (uint_0.uint_0 < uint_1.uint_0)
			{
				uint_2 = uint_1.uint_1;
				uint_3 = uint_1.uint_0;
				uint_4 = uint_0.uint_1;
				uint_5 = uint_0.uint_0;
			}
			else
			{
				uint_2 = uint_0.uint_1;
				uint_3 = uint_0.uint_0;
				uint_4 = uint_1.uint_1;
				uint_5 = uint_1.uint_0;
			}
			Class10.Class13 @class = new Class10.Class13((Class10.Enum1)1, uint_3 + 1U);
			uint[] uint_6 = @class.uint_1;
			ulong num2 = 0UL;
			do
			{
				num2 = (ulong)uint_2[(int)((UIntPtr)num)] + (ulong)uint_4[(int)((UIntPtr)num)] + num2;
				uint_6[(int)((UIntPtr)num)] = (uint)num2;
				num2 >>= 32;
			}
			while ((num += 1U) < uint_5);
			bool flag;
			if (flag = (num2 != 0UL))
			{
				if (num < uint_3)
				{
					do
					{
						flag = ((uint_6[(int)((UIntPtr)num)] = uint_2[(int)((UIntPtr)num)] + 1U) == 0U);
					}
					while ((num += 1U) < uint_3 && flag);
				}
				if (flag)
				{
					uint_6[(int)((UIntPtr)num)] = 1U;
					@class.uint_0 = num + 1U;
					return @class;
				}
			}
			if (num < uint_3)
			{
				do
				{
					uint_6[(int)((UIntPtr)num)] = uint_2[(int)((UIntPtr)num)];
				}
				while ((num += 1U) < uint_3);
			}
			@class.method_5();
			return @class;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0001AF8C File Offset: 0x0001918C
		public static Class10.Class13 smethod_1(uint[] uint_0, uint[] uint_1)
		{
			Class10.Class13 @class = new Class10.Class13((Class10.Enum1)1, uint_0.uint_0);
			uint[] uint_2 = @class.uint_1;
			uint[] uint_3 = uint_0.uint_1;
			uint[] uint_4 = uint_1.uint_1;
			uint num = 0U;
			uint num2 = 0U;
			do
			{
				uint num3 = uint_4[(int)((UIntPtr)num)];
				if ((num3 += num2) < num2 | (uint_2[(int)((UIntPtr)num)] = uint_3[(int)((UIntPtr)num)] - num3) > ~num3)
				{
					num2 = 1U;
				}
				else
				{
					num2 = 0U;
				}
			}
			while ((num += 1U) < uint_1.uint_0);
			if (num != uint_0.uint_0)
			{
				if (num2 == 1U)
				{
					do
					{
						uint_2[(int)((UIntPtr)num)] = uint_3[(int)((UIntPtr)num)] - 1U;
					}
					while (uint_3[(int)((UIntPtr)(num++))] == 0U && num < uint_0.uint_0);
					if (num == uint_0.uint_0)
					{
						goto IL_C8;
					}
				}
				do
				{
					uint_2[(int)((UIntPtr)num)] = uint_3[(int)((UIntPtr)num)];
				}
				while ((num += 1U) < uint_0.uint_0);
			}
			IL_C8:
			@class.method_5();
			return @class;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0001B068 File Offset: 0x00019268
		public static void smethod_2(object object_0, uint[] uint_0)
		{
			uint[] uint_ = object_0.uint_1;
			uint[] uint_2 = uint_0.uint_1;
			uint num = 0U;
			uint num2 = 0U;
			do
			{
				uint num3 = uint_2[(int)((UIntPtr)num)];
				if ((num3 += num2) < num2 | (uint_[(int)((UIntPtr)num)] -= num3) > ~num3)
				{
					num2 = 1U;
				}
				else
				{
					num2 = 0U;
				}
			}
			while ((num += 1U) < uint_0.uint_0);
			if (num != object_0.uint_0 && num2 == 1U)
			{
				do
				{
					uint_[(int)((UIntPtr)num)] -= 1U;
				}
				while (uint_[(int)((UIntPtr)(num++))] == 0U && num < object_0.uint_0);
			}
			while (object_0.uint_0 > 0U && object_0.uint_1[(int)((UIntPtr)(object_0.uint_0 - 1U))] == 0U)
			{
				object_0.uint_0 -= 1U;
			}
			if (object_0.uint_0 == 0U)
			{
				object_0.uint_0 += 1U;
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0001B14C File Offset: 0x0001934C
		public static void smethod_3(object object_0, uint[] uint_0)
		{
			uint num = 0U;
			bool flag = false;
			uint[] uint_;
			uint uint_2;
			uint[] uint_3;
			uint uint_4;
			if (object_0.uint_0 < uint_0.uint_0)
			{
				flag = true;
				uint_ = uint_0.uint_1;
				uint_2 = uint_0.uint_0;
				uint_3 = object_0.uint_1;
				uint_4 = object_0.uint_0;
			}
			else
			{
				uint_ = object_0.uint_1;
				uint_2 = object_0.uint_0;
				uint_3 = uint_0.uint_1;
				uint_4 = uint_0.uint_0;
			}
			uint[] uint_5 = object_0.uint_1;
			ulong num2 = 0UL;
			do
			{
				num2 += (ulong)uint_[(int)((UIntPtr)num)] + (ulong)uint_3[(int)((UIntPtr)num)];
				uint_5[(int)((UIntPtr)num)] = (uint)num2;
				num2 >>= 32;
			}
			while ((num += 1U) < uint_4);
			bool flag2;
			if (flag2 = (num2 != 0UL))
			{
				if (num < uint_2)
				{
					do
					{
						flag2 = ((uint_5[(int)((UIntPtr)num)] = uint_[(int)((UIntPtr)num)] + 1U) == 0U);
					}
					while ((num += 1U) < uint_2 && flag2);
				}
				if (flag2)
				{
					uint_5[(int)((UIntPtr)num)] = 1U;
					object_0.uint_0 = num + 1U;
					return;
				}
			}
			if (flag && num < uint_2 - 1U)
			{
				do
				{
					uint_5[(int)((UIntPtr)num)] = uint_[(int)((UIntPtr)num)];
				}
				while ((num += 1U) < uint_2);
			}
			object_0.uint_0 = uint_2 + 1U;
			object_0.method_5();
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0001B264 File Offset: 0x00019464
		public static Class10.Enum1 smethod_4(uint[] uint_0, uint[] uint_1)
		{
			uint num = uint_0.uint_0;
			uint num2 = uint_1.uint_0;
			while (num > 0U && uint_0.uint_1[(int)((UIntPtr)(num - 1U))] == 0U)
			{
				num -= 1U;
			}
			while (num2 > 0U && uint_1.uint_1[(int)((UIntPtr)(num2 - 1U))] == 0U)
			{
				num2 -= 1U;
			}
			if (num == 0U && num2 == 0U)
			{
				return (Class10.Enum1)0;
			}
			if (num < num2)
			{
				return (Class10.Enum1)(-1);
			}
			if (num > num2)
			{
				return (Class10.Enum1)1;
			}
			uint num3;
			for (num3 = num - 1U; num3 != 0U; num3 -= 1U)
			{
				if (uint_0.uint_1[(int)((UIntPtr)num3)] != uint_1.uint_1[(int)((UIntPtr)num3)])
				{
					break;
				}
			}
			if (uint_0.uint_1[(int)((UIntPtr)num3)] < uint_1.uint_1[(int)((UIntPtr)num3)])
			{
				return (Class10.Enum1)(-1);
			}
			if (uint_0.uint_1[(int)((UIntPtr)num3)] > uint_1.uint_1[(int)((UIntPtr)num3)])
			{
				return (Class10.Enum1)1;
			}
			return (Class10.Enum1)0;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0001B314 File Offset: 0x00019514
		public static uint smethod_5(object object_0, uint uint_0)
		{
			ulong num = 0UL;
			uint uint_ = object_0.uint_0;
			while (uint_-- > 0U)
			{
				num <<= 32;
				num |= (ulong)object_0.uint_1[(int)((UIntPtr)uint_)];
				object_0.uint_1[(int)((UIntPtr)uint_)] = (uint)(num / (ulong)uint_0);
				num %= (ulong)uint_0;
			}
			object_0.method_5();
			return (uint)num;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0001B36C File Offset: 0x0001956C
		public static uint smethod_6(uint[] uint_0, uint uint_1)
		{
			ulong num = 0UL;
			uint uint_2 = uint_0.uint_0;
			while (uint_2-- > 0U)
			{
				num <<= 32;
				num |= (ulong)uint_0.uint_1[(int)((UIntPtr)uint_2)];
				num %= (ulong)uint_1;
			}
			return (uint)num;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0001B3B0 File Offset: 0x000195B0
		public static Class10.Class13 smethod_7(uint[] uint_0, uint uint_1)
		{
			Class10.Class13 @class = new Class10.Class13((Class10.Enum1)1, uint_0.uint_0);
			ulong num = 0UL;
			uint uint_2 = uint_0.uint_0;
			while (uint_2-- > 0U)
			{
				num <<= 32;
				num |= (ulong)uint_0.uint_1[(int)((UIntPtr)uint_2)];
				@class.uint_1[(int)((UIntPtr)uint_2)] = (uint)(num / (ulong)uint_1);
				num %= (ulong)uint_1;
			}
			@class.method_5();
			return @class;
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0001B414 File Offset: 0x00019614
		public static Class10.Class13[] smethod_8(uint[] uint_0, uint uint_1)
		{
			Class10.Class13 @class = new Class10.Class13((Class10.Enum1)1, uint_0.uint_0);
			ulong num = 0UL;
			uint uint_2 = uint_0.uint_0;
			while (uint_2-- > 0U)
			{
				num <<= 32;
				num |= (ulong)uint_0.uint_1[(int)((UIntPtr)uint_2)];
				@class.uint_1[(int)((UIntPtr)uint_2)] = (uint)(num / (ulong)uint_1);
				num %= (ulong)uint_1;
			}
			@class.method_5();
			Class10.Class13 class2 = (uint)num;
			return new Class10.Class13[]
			{
				@class,
				class2
			};
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0001B490 File Offset: 0x00019690
		public static Class10.Class13[] smethod_9(object object_0, object object_1)
		{
			if (Class10.Class15.smethod_4(object_0, object_1) == (Class10.Enum1)(-1))
			{
				return new Class10.Class13[]
				{
					0,
					new Class10.Class13(object_0)
				};
			}
			object_0.method_5();
			object_1.method_5();
			if (object_1.uint_0 == 1U)
			{
				return Class10.Class15.smethod_8(object_0, object_1.uint_1[0]);
			}
			uint num = object_0.uint_0 + 1U;
			int num2 = (int)(object_1.uint_0 + 1U);
			uint num3 = 2147483648U;
			uint num4 = object_1.uint_1[(int)((UIntPtr)(object_1.uint_0 - 1U))];
			int num5 = 0;
			int num6 = (int)(object_0.uint_0 - object_1.uint_0);
			while (num3 != 0U && (num4 & num3) == 0U)
			{
				num5++;
				num3 >>= 1;
			}
			Class10.Class13 @class = new Class10.Class13((Class10.Enum1)1, object_0.uint_0 - object_1.uint_0 + 1U);
			Class10.Class13 class2 = object_0 << num5;
			uint[] uint_ = class2.uint_1;
			object_1 <<= num5;
			int i = (int)(num - object_1.uint_0);
			int num7 = (int)(num - 1U);
			uint num8 = object_1.uint_1[(int)((UIntPtr)(object_1.uint_0 - 1U))];
			ulong num9 = (ulong)object_1.uint_1[(int)((UIntPtr)(object_1.uint_0 - 2U))];
			while (i > 0)
			{
				ulong num10 = ((ulong)uint_[num7] << 32) + (ulong)uint_[num7 - 1];
				ulong num11 = num10 / (ulong)num8;
				ulong num12 = num10 % (ulong)num8;
				do
				{
					if (num11 != 4294967296UL)
					{
						if (num11 * num9 <= (num12 << 32) + (ulong)uint_[num7 - 2])
						{
							break;
						}
					}
					num11 -= 1UL;
					num12 += (ulong)num8;
				}
				while (num12 < 4294967296UL);
				IL_181:
				uint num13 = 0U;
				int num14 = num7 - num2 + 1;
				ulong num15 = 0UL;
				uint num16 = (uint)num11;
				do
				{
					num15 += (ulong)object_1.uint_1[(int)((UIntPtr)num13)] * (ulong)num16;
					uint num17 = uint_[num14];
					uint_[num14] -= (uint)num15;
					num15 >>= 32;
					if (uint_[num14] > num17)
					{
						num15 += 1UL;
					}
					num13 += 1U;
					num14++;
				}
				while ((ulong)num13 < (ulong)((long)num2));
				num14 = num7 - num2 + 1;
				num13 = 0U;
				if (num15 != 0UL)
				{
					num16 -= 1U;
					ulong num18 = 0UL;
					do
					{
						num18 = (ulong)uint_[num14] + (ulong)object_1.uint_1[(int)((UIntPtr)num13)] + num18;
						uint_[num14] = (uint)num18;
						num18 >>= 32;
						num13 += 1U;
						num14++;
					}
					while ((ulong)num13 < (ulong)((long)num2));
				}
				@class.uint_1[num6--] = num16;
				num7--;
				i--;
				continue;
				goto IL_181;
			}
			@class.method_5();
			class2.method_5();
			Class10.Class13[] array = new Class10.Class13[]
			{
				@class,
				class2
			};
			if (num5 != 0)
			{
				Class10.Class13[] array2;
				(array2 = array)[1] = array2[1] >> num5;
			}
			return array;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0001B750 File Offset: 0x00019950
		public static Class10.Class13 smethod_10(object object_0, int int_0)
		{
			if (int_0 == 0)
			{
				return new Class10.Class13(object_0, object_0.uint_0 + 1U);
			}
			int num = int_0 >> 5;
			int_0 &= 31;
			Class10.Class13 @class = new Class10.Class13((Class10.Enum1)1, object_0.uint_0 + 1U + (uint)num);
			uint num2 = 0U;
			uint uint_ = object_0.uint_0;
			if (int_0 != 0)
			{
				uint num3 = 0U;
				while (num2 < uint_)
				{
					uint num4 = object_0.uint_1[(int)((UIntPtr)num2)];
					@class.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num2 + (ulong)((long)num)))))] = (num4 << int_0 | num3);
					num3 = num4 >> 32 - int_0;
					num2 += 1U;
				}
				@class.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num2 + (ulong)((long)num)))))] = num3;
			}
			else
			{
				while (num2 < uint_)
				{
					@class.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num2 + (ulong)((long)num)))))] = object_0.uint_1[(int)((UIntPtr)num2)];
					num2 += 1U;
				}
			}
			@class.method_5();
			return @class;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0001B808 File Offset: 0x00019A08
		public static Class10.Class13 smethod_11(object object_0, int int_0)
		{
			if (int_0 == 0)
			{
				return new Class10.Class13(object_0);
			}
			int num = int_0 >> 5;
			int num2 = int_0 & 31;
			Class10.Class13 @class = new Class10.Class13((Class10.Enum1)1, object_0.uint_0 - (uint)num + 1U);
			uint num3 = (uint)(@class.uint_1.Length - 1);
			if (num2 != 0)
			{
				uint num4 = 0U;
				while (num3-- > 0U)
				{
					uint num5 = object_0.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num3 + (ulong)((long)num)))))];
					@class.uint_1[(int)((UIntPtr)num3)] = (num5 >> int_0 | num4);
					num4 = num5 << 32 - int_0;
				}
			}
			else
			{
				while (num3-- > 0U)
				{
					@class.uint_1[(int)((UIntPtr)num3)] = object_0.uint_1[(int)(checked((IntPtr)(unchecked((ulong)num3 + (ulong)((long)num)))))];
				}
			}
			@class.method_5();
			return @class;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0001B8AC File Offset: 0x00019AAC
		public static Class10.Class13 smethod_12(uint[] uint_0, uint uint_1)
		{
			Class10.Class13 @class = new Class10.Class13((Class10.Enum1)1, uint_0.uint_0 + 1U);
			uint num = 0U;
			ulong num2 = 0UL;
			do
			{
				num2 += (ulong)uint_0.uint_1[(int)((UIntPtr)num)] * (ulong)uint_1;
				@class.uint_1[(int)((UIntPtr)num)] = (uint)num2;
				num2 >>= 32;
			}
			while ((num += 1U) < uint_0.uint_0);
			@class.uint_1[(int)((UIntPtr)num)] = (uint)num2;
			@class.method_5();
			return @class;
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0001B914 File Offset: 0x00019B14
		public unsafe static void smethod_13(uint[] uint_0, uint uint_1, uint uint_2, uint[] uint_3, uint uint_4, uint uint_5, uint[] uint_6, uint uint_7)
		{
			uint* ptr;
			if (uint_0 != null && uint_0.Length != 0)
			{
				fixed (uint* ptr = &uint_0[0])
				{
				}
			}
			else
			{
				ptr = null;
			}
			uint* ptr2;
			if (uint_3 != null && uint_3.Length != 0)
			{
				fixed (uint* ptr2 = &uint_3[0])
				{
				}
			}
			else
			{
				ptr2 = null;
			}
			uint* ptr3;
			if (uint_6 != null && uint_6.Length != 0)
			{
				fixed (uint* ptr3 = &uint_6[0])
				{
				}
			}
			else
			{
				ptr3 = null;
			}
			uint* ptr4 = ptr + uint_1;
			uint* ptr5 = ptr4 + uint_2;
			uint* ptr6 = ptr2 + uint_4;
			uint* ptr7 = ptr6 + uint_5;
			uint* ptr8 = ptr3 + uint_7;
			while (ptr4 < ptr5)
			{
				if (*ptr4 != 0U)
				{
					ulong num = 0UL;
					uint* ptr9 = ptr8;
					uint* ptr10 = ptr6;
					while (ptr10 < ptr7)
					{
						num += (ulong)(*ptr4) * (ulong)(*ptr10) + (ulong)(*ptr9);
						*ptr9 = (uint)num;
						num >>= 32;
						ptr10++;
						ptr9++;
					}
					if (num != 0UL)
					{
						*ptr9 = (uint)num;
					}
				}
				ptr4++;
				ptr8++;
			}
			ptr = null;
			ptr2 = null;
			ptr3 = null;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0001BA20 File Offset: 0x00019C20
		public unsafe static void smethod_14(uint[] uint_0, int int_0, int int_1, uint[] uint_1, int int_2, int int_3, uint[] uint_2, int int_4, int int_5)
		{
			uint* ptr;
			if (uint_0 != null && uint_0.Length != 0)
			{
				fixed (uint* ptr = &uint_0[0])
				{
				}
			}
			else
			{
				ptr = null;
			}
			uint* ptr2;
			if (uint_1 != null && uint_1.Length != 0)
			{
				fixed (uint* ptr2 = &uint_1[0])
				{
				}
			}
			else
			{
				ptr2 = null;
			}
			uint* ptr3;
			if (uint_2 != null && uint_2.Length != 0)
			{
				fixed (uint* ptr3 = &uint_2[0])
				{
				}
			}
			else
			{
				ptr3 = null;
			}
			uint* ptr4 = ptr + int_0;
			uint* ptr5 = ptr4 + int_1;
			uint* ptr6 = ptr2 + int_2;
			uint* ptr7 = ptr6 + int_3;
			uint* ptr8 = ptr3 + int_4;
			uint* ptr9 = ptr8 + int_5;
			while (ptr4 < ptr5)
			{
				if (*ptr4 != 0U)
				{
					ulong num = 0UL;
					uint* ptr10 = ptr8;
					uint* ptr11 = ptr6;
					while (ptr11 < ptr7 && ptr10 < ptr9)
					{
						num += (ulong)(*ptr4) * (ulong)(*ptr11) + (ulong)(*ptr10);
						*ptr10 = (uint)num;
						num >>= 32;
						ptr11++;
						ptr10++;
					}
					if (num != 0UL && ptr10 < ptr9)
					{
						*ptr10 = (uint)num;
					}
				}
				ptr4++;
				ptr8++;
			}
			ptr = null;
			ptr2 = null;
			ptr3 = null;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0001BB44 File Offset: 0x00019D44
		public unsafe static void smethod_15(object object_0, ref uint[] uint_0)
		{
			uint[] array = uint_0;
			uint_0 = object_0.uint_1;
			uint[] uint_ = object_0.uint_1;
			uint uint_2 = object_0.uint_0;
			object_0.uint_1 = array;
			uint[] array2;
			uint* ptr;
			if ((array2 = uint_) != null && array2.Length != 0)
			{
				fixed (uint* ptr = &array2[0])
				{
				}
			}
			else
			{
				ptr = null;
			}
			uint[] array3;
			uint* ptr2;
			if ((array3 = array) != null && array3.Length != 0)
			{
				fixed (uint* ptr2 = &array3[0])
				{
				}
			}
			else
			{
				ptr2 = null;
			}
			uint* ptr3 = ptr2 + array.Length;
			for (uint* ptr4 = ptr2; ptr4 < ptr3; ptr4++)
			{
				*ptr4 = 0U;
			}
			uint* ptr5 = ptr;
			uint* ptr6 = ptr2;
			uint num = 0U;
			while (num < uint_2)
			{
				if (*ptr5 != 0U)
				{
					ulong num2 = 0UL;
					uint num3 = *ptr5;
					uint* ptr7 = ptr5 + 1;
					uint* ptr8 = ptr6 + 2U * num + 1;
					uint num4 = num + 1U;
					while (num4 < uint_2)
					{
						num2 += (ulong)num3 * (ulong)(*ptr7) + (ulong)(*ptr8);
						*ptr8 = (uint)num2;
						num2 >>= 32;
						num4 += 1U;
						ptr8++;
						ptr7++;
					}
					if (num2 != 0UL)
					{
						*ptr8 = (uint)num2;
					}
				}
				num += 1U;
				ptr5++;
			}
			ptr6 = ptr2;
			uint num5 = 0U;
			while (ptr6 < ptr3)
			{
				uint num6 = *ptr6;
				*ptr6 = (num6 << 1 | num5);
				num5 = num6 >> 31;
				ptr6++;
			}
			if (num5 != 0U)
			{
				*ptr6 = num5;
			}
			ptr5 = ptr;
			ptr6 = ptr2;
			uint* ptr9 = ptr5 + uint_2;
			while (ptr5 < ptr9)
			{
				ulong num7 = (ulong)(*ptr5) * (ulong)(*ptr5) + (ulong)(*ptr6);
				*ptr6 = (uint)num7;
				num7 >>= 32;
				*(++ptr6) += (uint)num7;
				if (*ptr6 < (uint)num7)
				{
					uint* ptr10 = ptr6;
					*(++ptr10) += 1U;
					while (*(ptr10++) == 0U)
					{
						*ptr10 += 1U;
					}
				}
				ptr5++;
				ptr6++;
			}
			object_0.uint_0 <<= 1;
			while (ptr2[object_0.uint_0 - 1U] == 0U && object_0.uint_0 > 1U)
			{
				object_0.uint_0 -= 1U;
			}
			ptr = null;
			ptr2 = null;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0001BD68 File Offset: 0x00019F68
		public static Class10.Class13 smethod_16(Class10.Class13 class13_0, Class10.Class13 class13_1)
		{
			Class10.Class13 @class = class13_0;
			Class10.Class13 class2 = class13_1;
			Class10.Class13 class3 = class2;
			while (@class.uint_0 > 1U)
			{
				class3 = @class;
				@class = class2 % @class;
				class2 = class3;
			}
			if (@class == 0U)
			{
				return class3;
			}
			uint num = @class.uint_1[0];
			uint num2 = class2 % num;
			int num3 = 0;
			while (((num2 | num) & 1U) == 0U)
			{
				num2 >>= 1;
				num >>= 1;
				num3++;
			}
			while (num2 != 0U)
			{
				while ((num2 & 1U) == 0U)
				{
					num2 >>= 1;
				}
				while ((num & 1U) == 0U)
				{
					num >>= 1;
				}
				if (num2 >= num)
				{
					num2 = num2 - num >> 1;
				}
				else
				{
					num = num - num2 >> 1;
				}
			}
			return num << num3;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0001BE0C File Offset: 0x0001A00C
		public static uint smethod_17(uint[] uint_0, uint uint_1)
		{
			uint num = uint_1;
			uint num2 = uint_0 % uint_1;
			uint num3 = 0U;
			uint num4 = 1U;
			while (num2 != 0U)
			{
				if (num2 == 1U)
				{
					return num4;
				}
				num3 += num / num2 * num4;
				num %= num2;
				if (num == 0U)
				{
					return 0U;
				}
				if (num == 1U)
				{
					return uint_1 - num3;
				}
				num4 += num2 / num * num3;
				num2 %= num;
			}
			return 0U;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0001BE5C File Offset: 0x0001A05C
		public static Class10.Class13 smethod_18(Class10.Class13 class13_0, object object_0)
		{
			if (object_0.uint_0 == 1U)
			{
				return Class10.Class15.smethod_17(class13_0, object_0.uint_1[0]);
			}
			Class10.Class13[] array = new Class10.Class13[]
			{
				0,
				1
			};
			Class10.Class13[] array2 = new Class10.Class13[2];
			Class10.Class13[] array3 = new Class10.Class13[]
			{
				0,
				0
			};
			int num = 0;
			Class10.Class13 object_ = object_0;
			Class10.Class13 @class = class13_0;
			Class10.Class14 class2 = new Class10.Class14(object_0);
			while (@class != 0U)
			{
				if (num > 1)
				{
					Class10.Class13 class3 = class2.method_2(array[0], array[1] * array2[0]);
					array[0] = array[1];
					array[1] = class3;
				}
				Class10.Class13[] array4 = Class10.Class15.smethod_9(object_, @class);
				array2[0] = array2[1];
				array2[1] = array4[0];
				array3[0] = array3[1];
				array3[1] = array4[1];
				object_ = @class;
				@class = array4[1];
				num++;
			}
			if (array3[0] != 1U)
			{
				throw new ArithmeticException("No inverse!");
			}
			return class2.method_2(array[0], array[1] * array2[0]);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00002402 File Offset: 0x00000602
		public Class15()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}
	}

	// Token: 0x02000032 RID: 50
	internal struct Struct1
	{
		// Token: 0x040001C8 RID: 456
		public IntPtr intptr_0;

		// Token: 0x040001C9 RID: 457
		public int int_0;

		// Token: 0x040001CA RID: 458
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string string_0;

		// Token: 0x040001CB RID: 459
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
		public string string_1;

		// Token: 0x040001CC RID: 460
		public uint uint_0;

		// Token: 0x040001CD RID: 461
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] byte_0;

		// Token: 0x040001CE RID: 462
		public int int_1;

		// Token: 0x040001CF RID: 463
		public uint uint_1;

		// Token: 0x040001D0 RID: 464
		public uint uint_2;

		// Token: 0x040001D1 RID: 465
		public IntPtr intptr_1;

		// Token: 0x040001D2 RID: 466
		public Class10.Struct2 struct2_0;

		// Token: 0x040001D3 RID: 467
		public Class10.Struct2 struct2_1;

		// Token: 0x040001D4 RID: 468
		public Class10.Struct2 struct2_2;

		// Token: 0x040001D5 RID: 469
		public bool bool_0;

		// Token: 0x040001D6 RID: 470
		public Class10.Struct2 struct2_3;

		// Token: 0x040001D7 RID: 471
		public Class10.Struct2 struct2_4;

		// Token: 0x040001D8 RID: 472
		public int int_2;

		// Token: 0x040001D9 RID: 473
		public int int_3;
	}

	// Token: 0x02000033 RID: 51
	internal struct Struct2
	{
		// Token: 0x040001DA RID: 474
		public IntPtr intptr_0;

		// Token: 0x040001DB RID: 475
		public Class10.Struct3 struct3_0;

		// Token: 0x040001DC RID: 476
		public Class10.Struct3 struct3_1;

		// Token: 0x040001DD RID: 477
		public int int_0;
	}

	// Token: 0x02000034 RID: 52
	internal struct Struct3
	{
		// Token: 0x040001DE RID: 478
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string string_0;
	}

	// Token: 0x02000035 RID: 53
	internal class Class16
	{
		// Token: 0x06000269 RID: 617
		[DllImport("iphlpapi.dll", CharSet = CharSet.Ansi)]
		public static extern int GetAdaptersInfo(IntPtr intptr_0, ref long long_0);

		// Token: 0x0600026A RID: 618 RVA: 0x0001BF70 File Offset: 0x0001A170
		internal static string smethod_0()
		{
			string text = string.Empty;
			try
			{
				long value = (long)Marshal.SizeOf(typeof(Class10.Struct1));
				IntPtr intPtr = Marshal.AllocHGlobal(new IntPtr(value));
				int adaptersInfo = Class10.Class16.GetAdaptersInfo(intPtr, ref value);
				if (adaptersInfo == 111)
				{
					intPtr = Marshal.ReAllocHGlobal(intPtr, new IntPtr(value));
					adaptersInfo = Class10.Class16.GetAdaptersInfo(intPtr, ref value);
				}
				if (adaptersInfo == 0)
				{
					IntPtr ptr = intPtr;
					Class10.Struct1 @struct = (Class10.Struct1)Marshal.PtrToStructure(ptr, typeof(Class10.Struct1));
					int num = 0;
					while ((long)num < (long)((ulong)@struct.uint_0))
					{
						text += @struct.byte_0[num].ToString("X2");
						num++;
					}
					Marshal.FreeHGlobal(intPtr);
				}
				else
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			catch
			{
			}
			if (text == string.Empty)
			{
				text = "";
			}
			return text;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0001C054 File Offset: 0x0001A254
		internal static string[] smethod_1()
		{
			List<string> list = new List<string>();
			string text = string.Empty;
			try
			{
				long value = (long)Marshal.SizeOf(typeof(Class10.Struct1));
				IntPtr intPtr = Marshal.AllocHGlobal(new IntPtr(value));
				int adaptersInfo = Class10.Class16.GetAdaptersInfo(intPtr, ref value);
				if (adaptersInfo == 111)
				{
					intPtr = Marshal.ReAllocHGlobal(intPtr, new IntPtr(value));
					adaptersInfo = Class10.Class16.GetAdaptersInfo(intPtr, ref value);
				}
				if (adaptersInfo == 0)
				{
					IntPtr intPtr2 = intPtr;
					do
					{
						text = string.Empty;
						Class10.Struct1 @struct = (Class10.Struct1)Marshal.PtrToStructure(intPtr2, typeof(Class10.Struct1));
						int num = 0;
						while ((long)num < (long)((ulong)@struct.uint_0))
						{
							text += @struct.byte_0[num].ToString("X2");
							num++;
						}
						list.Add(text);
						intPtr2 = @struct.intptr_0;
					}
					while (intPtr2 != IntPtr.Zero);
					Marshal.FreeHGlobal(intPtr);
				}
				else
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			catch
			{
			}
			return list.ToArray();
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00002402 File Offset: 0x00000602
		public Class16()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}
	}

	// Token: 0x02000036 RID: 54
	private struct Struct4
	{
		// Token: 0x040001DF RID: 479
		public uint uint_0;

		// Token: 0x040001E0 RID: 480
		public uint uint_1;

		// Token: 0x040001E1 RID: 481
		public char char_0;

		// Token: 0x040001E2 RID: 482
		public char char_1;

		// Token: 0x040001E3 RID: 483
		public byte byte_0;

		// Token: 0x040001E4 RID: 484
		public byte byte_1;

		// Token: 0x040001E5 RID: 485
		public uint uint_2;

		// Token: 0x040001E6 RID: 486
		public uint uint_3;

		// Token: 0x040001E7 RID: 487
		public uint uint_4;

		// Token: 0x040001E8 RID: 488
		public uint uint_5;

		// Token: 0x040001E9 RID: 489
		public Class10.Enum4 enum4_0;

		// Token: 0x040001EA RID: 490
		public uint uint_6;

		// Token: 0x040001EB RID: 491
		public IntPtr intptr_0;
	}

	// Token: 0x02000037 RID: 55
	private struct Struct5
	{
		// Token: 0x040001EC RID: 492
		public Class10.Enum2 enum2_0;

		// Token: 0x040001ED RID: 493
		public Class10.Enum3 enum3_0;

		// Token: 0x040001EE RID: 494
		public IntPtr intptr_0;
	}

	// Token: 0x02000038 RID: 56
	private enum Enum2
	{

	}

	// Token: 0x02000039 RID: 57
	private enum Enum3
	{

	}

	// Token: 0x0200003A RID: 58
	private enum Enum4
	{

	}

	// Token: 0x0200003B RID: 59
	internal class Class17
	{
		// Token: 0x0600026D RID: 621 RVA: 0x0001C15C File Offset: 0x0001A35C
		internal static string smethod_0()
		{
			try
			{
				int num = 16;
				for (int i = 0; i < num; i++)
				{
					string string_ = "\\\\.\\PHYSICALDRIVE" + i.ToString();
					IntPtr intPtr;
					if (Environment.OSVersion.Platform == PlatformID.Win32NT)
					{
						intPtr = Class10.Class17.CreateFile(string_, 0U, 3, IntPtr.Zero, 3, 0, IntPtr.Zero);
					}
					else
					{
						intPtr = Class10.Class17.CreateFile("\\\\.\\Smartvsd", 0U, 0, IntPtr.Zero, 1, 0, IntPtr.Zero);
					}
					if ((int)intPtr != -1)
					{
						Class10.Struct5 @struct = default(Class10.Struct5);
						@struct.enum2_0 = (Class10.Enum2)0;
						@struct.enum3_0 = (Class10.Enum3)0;
						uint num2 = (uint)Marshal.SizeOf(typeof(Class10.Struct5));
						IntPtr intPtr2 = Marshal.AllocHGlobal((int)num2);
						Marshal.StructureToPtr(@struct, intPtr2, true);
						IntPtr intPtr3 = Marshal.AllocHGlobal(1024);
						uint num3 = 0U;
						if (Class10.Class17.DeviceIoControl(intPtr, 2954240U, intPtr2, num2, intPtr3, 1024U, ref num3, IntPtr.Zero))
						{
							Class10.Struct4 struct2 = (Class10.Struct4)Marshal.PtrToStructure(intPtr3, typeof(Class10.Struct4));
							long num4 = intPtr3.ToInt64();
							string text = string.Empty;
							if (struct2.uint_5 != 0U)
							{
								text = Marshal.PtrToStringAnsi((IntPtr)(num4 + (long)((ulong)struct2.uint_5)));
							}
							if (text != null && text.Length > 0)
							{
								Marshal.FreeHGlobal(intPtr3);
								Marshal.FreeHGlobal(intPtr2);
								Class10.Class17.CloseHandle(intPtr);
								return text;
							}
						}
						Marshal.FreeHGlobal(intPtr3);
						Marshal.FreeHGlobal(intPtr2);
					}
					Class10.Class17.CloseHandle(intPtr);
				}
			}
			catch
			{
			}
			return "failure";
		}

		// Token: 0x0600026E RID: 622
		[DllImport("kernel32.dll")]
		private static extern IntPtr CreateFile(string string_0, uint uint_0, int int_0, IntPtr intptr_0, int int_1, int int_2, IntPtr intptr_1);

		// Token: 0x0600026F RID: 623
		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr intptr_0);

		// Token: 0x06000270 RID: 624
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool DeviceIoControl(IntPtr intptr_0, uint uint_0, IntPtr intptr_1, uint uint_1, [Out] IntPtr intptr_2, uint uint_2, ref uint uint_3, IntPtr intptr_3);

		// Token: 0x06000271 RID: 625 RVA: 0x00002402 File Offset: 0x00000602
		public Class17()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}
	}

	// Token: 0x0200003C RID: 60
	internal sealed class Class18
	{
		// Token: 0x06000272 RID: 626 RVA: 0x0001C304 File Offset: 0x0001A504
		public Class18()
		{
			Class8.ah6VSoGzeNXX5();
			this.byte_0 = new byte[0];
			this.string_0 = "";
			base..ctor();
			try
			{
				RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider();
				this.byte_0 = new byte[32];
				rngcryptoServiceProvider.GetBytes(this.byte_0);
				this.class12_0 = new Class10.Class12();
				this.bool_0 = false;
			}
			catch
			{
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0001C37C File Offset: 0x0001A57C
		internal void method_0(string string_1)
		{
			try
			{
				Stream stream = new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read);
				BinaryReader binaryReader = new BinaryReader(stream);
				bool flag = false;
				if (binaryReader.BaseStream.Length == 32L)
				{
					this.method_5(new byte[binaryReader.BaseStream.Length]);
					this.method_5(binaryReader.ReadBytes((int)binaryReader.BaseStream.Length));
					flag = true;
					this.bool_0 = true;
				}
				binaryReader.Close();
				stream.Close();
				if (!flag)
				{
					this.bool_0 = false;
					using (StreamReader streamReader = new StreamReader(string_1))
					{
						string text = streamReader.ReadLine();
						string[] array = text.Split(new char[]
						{
							'|'
						});
						this.byte_0 = Convert.FromBase64String(array[0]);
						this.string_0 = array[1];
						this.class12_0 = new Class10.Class12();
						this.method_8().FromXmlString(this.string_0);
						if (this.string_0.Length != this.method_8().ToXmlString(false).Length)
						{
							this.string_0 = this.method_8().ToXmlString(true);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0001C4D8 File Offset: 0x0001A6D8
		internal void method_1(string string_1)
		{
			try
			{
				string_1 = string_1.Trim();
				try
				{
					if (!(string_1 == string.Empty) && string_1.Length != 0)
					{
						if (string_1.Length == 32)
						{
							this.byte_0 = new byte[32];
							for (int i = 0; i < 32; i++)
							{
								this.byte_0[i] = (byte)string_1.ToCharArray()[i];
							}
						}
						else if (string_1.Length == 96)
						{
							this.byte_0 = new byte[32];
							for (int j = 0; j < 32; j++)
							{
								this.byte_0[j] = Convert.ToByte(string_1.Substring(j * 3, 3));
							}
							this.bool_0 = true;
						}
						else
						{
							this.bool_0 = false;
							string text = string_1;
							string[] array = text.Split(new char[]
							{
								'|'
							});
							this.byte_0 = Convert.FromBase64String(array[0]);
							this.string_0 = array[1];
							this.class12_0 = new Class10.Class12();
							this.method_8().FromXmlString(this.string_0);
							if (this.string_0.Length != this.method_8().ToXmlString(false).Length)
							{
								this.string_0 = this.method_8().ToXmlString(true);
							}
						}
					}
					else
					{
						RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider();
						this.byte_0 = new byte[32];
						rngcryptoServiceProvider.GetBytes(this.byte_0);
						this.class12_0 = new Class10.Class12();
						this.bool_0 = false;
					}
				}
				catch
				{
					RNGCryptoServiceProvider rngcryptoServiceProvider2 = new RNGCryptoServiceProvider();
					this.byte_0 = new byte[32];
					rngcryptoServiceProvider2.GetBytes(this.byte_0);
					this.class12_0 = new Class10.Class12();
					this.method_8().FromXmlString(this.string_0);
					this.bool_0 = false;
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0001C6C8 File Offset: 0x0001A8C8
		internal void method_2(string string_1)
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(string_1))
				{
					streamWriter.Write(Convert.ToBase64String(this.byte_0) + "|" + this.string_0);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00003309 File Offset: 0x00001509
		public override string ToString()
		{
			return Convert.ToBase64String(this.byte_0) + "|" + this.string_0;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0001C72C File Offset: 0x0001A92C
		public string method_3()
		{
			string result;
			try
			{
				result = Convert.ToBase64String(this.byte_0) + "|" + this.method_8().ToXmlString(false);
			}
			catch
			{
				result = Convert.ToBase64String(this.byte_0);
			}
			return result;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00003326 File Offset: 0x00001526
		public byte[] method_4()
		{
			return this.byte_0;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000332E File Offset: 0x0000152E
		public void method_5(byte[] byte_1)
		{
			this.byte_0 = byte_1;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00003337 File Offset: 0x00001537
		public bool method_6()
		{
			return this.bool_0;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000333F File Offset: 0x0000153F
		public void method_7(bool bool_1)
		{
			this.bool_0 = bool_1;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0001C780 File Offset: 0x0001A980
		private static byte[] smethod_0(string string_1)
		{
			byte[] result;
			try
			{
				byte[] array = null;
				FileStream fileStream = File.Open(string_1, FileMode.Open, FileAccess.Read, FileShare.Read);
				try
				{
					array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
				}
				finally
				{
					fileStream.Close();
				}
				result = array;
			}
			catch
			{
				result = new byte[0];
			}
			return result;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0001C7E8 File Offset: 0x0001A9E8
		public Class18(Class10.Class12 class12_1)
		{
			Class8.ah6VSoGzeNXX5();
			this.byte_0 = new byte[0];
			this.string_0 = "";
			base..ctor();
			try
			{
				if (class12_1 == null)
				{
					throw new ArgumentNullException("rsa");
				}
				this.method_9(class12_1);
				this.bool_0 = false;
			}
			catch
			{
			}
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0001C848 File Offset: 0x0001AA48
		public Class10.Class12 method_8()
		{
			try
			{
				if (this.class12_0 == null)
				{
					this.class12_0 = new Class10.Class12();
				}
			}
			catch
			{
			}
			return this.class12_0;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x00003348 File Offset: 0x00001548
		public void method_9(Class10.Class12 class12_1)
		{
			this.class12_0 = class12_1;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0001C884 File Offset: 0x0001AA84
		internal static bool smethod_1(Class10.Class12 class12_1, byte[] byte_1, byte[] byte_2)
		{
			bool result;
			try
			{
				result = class12_1.method_3(byte_1, byte_2);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x040001F2 RID: 498
		private Class10.Class12 class12_0;

		// Token: 0x040001F3 RID: 499
		private byte[] byte_0;

		// Token: 0x040001F4 RID: 500
		private string string_0;

		// Token: 0x040001F5 RID: 501
		private bool bool_0;
	}

	// Token: 0x0200003D RID: 61
	internal sealed class Class19
	{
		// Token: 0x06000281 RID: 641 RVA: 0x00002402 File Offset: 0x00000602
		private Class19()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00003351 File Offset: 0x00001551
		static Class19()
		{
			Class8.ah6VSoGzeNXX5();
			Class10.Class19.uint_0 = new uint[256];
			Class10.Class19.uint_1 = 3988292384U;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00003371 File Offset: 0x00001571
		public static bool smethod_0()
		{
			return Class10.Class19.bool_0;
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000284 RID: 644 RVA: 0x00003378 File Offset: 0x00001578
		[CLSCompliant(false)]
		public static uint UInt32_0
		{
			get
			{
				return Class10.Class19.uint_1;
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0001C8B4 File Offset: 0x0001AAB4
		[CLSCompliant(false)]
		public static void smethod_1(uint uint_2)
		{
			if (!Class10.Class19.bool_0)
			{
				Class10.Class19.uint_1 = uint_2;
				for (uint num = 0U; num < 256U; num += 1U)
				{
					uint num2 = num;
					for (uint num3 = 8U; num3 > 0U; num3 -= 1U)
					{
						if ((num2 & 1U) != 0U)
						{
							num2 = (num2 >> 1 ^ Class10.Class19.uint_1);
						}
						else
						{
							num2 >>= 1;
						}
					}
					Class10.Class19.uint_0[(int)((UIntPtr)num)] = num2;
				}
				Class10.Class19.bool_0 = true;
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0001C918 File Offset: 0x0001AB18
		public static void smethod_2(int int_0)
		{
			byte[] bytes = BitConverter.GetBytes(int_0);
			uint uint_ = BitConverter.ToUInt32(bytes, 0);
			Class10.Class19.smethod_1(uint_);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0001C93C File Offset: 0x0001AB3C
		public static void smethod_3(long long_0)
		{
			uint uint_ = (uint)(long_0 & 4294967295L);
			Class10.Class19.smethod_1(uint_);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000337F File Offset: 0x0000157F
		public static void smethod_4()
		{
			Class10.Class19.smethod_1(3988292384U);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0001C95C File Offset: 0x0001AB5C
		public static byte[] smethod_5(object object_0)
		{
			if (!Class10.Class19.bool_0)
			{
				throw new InvalidOperationException("You must initialize the CRC table before attempting to calculate the check on data.");
			}
			uint num = (uint)object_0.Length;
			uint num2 = uint.MaxValue;
			for (uint num3 = 0U; num3 < num; num3 += 1U)
			{
				num2 = (num2 >> 8 ^ Class10.Class19.uint_0[(int)((UIntPtr)(object_0[(int)((UIntPtr)num3)] ^ (num2 & 255U)))]);
			}
			uint value = num2 ^ uint.MaxValue;
			return BitConverter.GetBytes(value);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000338B File Offset: 0x0000158B
		public static byte[] smethod_6(string string_0)
		{
			return Class10.Class19.smethod_8(string_0, Encoding.ASCII);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0001C9B8 File Offset: 0x0001ABB8
		public static string smethod_7(string string_0)
		{
			string text = "";
			byte[] array = Class10.Class19.smethod_8(string_0, Encoding.ASCII);
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("X2");
			}
			return text;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0001CA00 File Offset: 0x0001AC00
		public static byte[] smethod_8(string string_0, Encoding encoding_0)
		{
			byte[] bytes = encoding_0.GetBytes(string_0);
			return Class10.Class19.smethod_5(bytes);
		}

		// Token: 0x040001F6 RID: 502
		private static uint[] uint_0;

		// Token: 0x040001F7 RID: 503
		private static uint uint_1;

		// Token: 0x040001F8 RID: 504
		private static bool bool_0;
	}

	// Token: 0x0200003E RID: 62
	[DefaultMember("Item")]
	internal sealed class Class20
	{
		// Token: 0x0600028D RID: 653 RVA: 0x0001CA1C File Offset: 0x0001AC1C
		public Class20(string[] string_0)
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
			this.hashtable_0 = new Hashtable();
			Regex regex = new Regex("^-{1,2}|^/|=|:", RegexOptions.Compiled);
			Regex regex2 = new Regex("^['\"]?(.*?)['\"]?$", RegexOptions.Compiled);
			string text = null;
			foreach (string input in string_0)
			{
				string[] array = regex.Split(input, 3);
				switch (array.Length)
				{
				case 1:
					if (text != null)
					{
						if (!this.hashtable_0.Contains(text))
						{
							array[0] = regex2.Replace(array[0], "$1");
							this.hashtable_0.Add(text, array[0]);
						}
						text = null;
					}
					break;
				case 2:
					if (text != null && !this.hashtable_0.Contains(text))
					{
						this.hashtable_0.Add(text, "true");
					}
					text = array[1];
					break;
				case 3:
					if (text != null && !this.hashtable_0.Contains(text))
					{
						this.hashtable_0.Add(text, "true");
					}
					text = array[1];
					if (!this.hashtable_0.Contains(text))
					{
						array[2] = regex2.Replace(array[2], "$1");
						this.hashtable_0.Add(text, array[2]);
					}
					text = null;
					break;
				}
			}
			if (text != null && !this.hashtable_0.Contains(text))
			{
				this.hashtable_0.Add(text, "true");
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00003398 File Offset: 0x00001598
		public string method_0(string string_0)
		{
			return (string)this.hashtable_0[string_0];
		}

		// Token: 0x040001F9 RID: 505
		private Hashtable hashtable_0;
	}

	// Token: 0x0200003F RID: 63
	internal enum Enum5
	{

	}

	// Token: 0x02000040 RID: 64
	internal sealed class Class21
	{
		// Token: 0x0600028F RID: 655 RVA: 0x000033AB File Offset: 0x000015AB
		public Class21(string string_0)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(new StreamReader(string_0));
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000033BE File Offset: 0x000015BE
		public Class21(string string_0, Class10.Enum5 enum5_0)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(new StreamReader(string_0), enum5_0);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x000033D2 File Offset: 0x000015D2
		public Class21(TextReader textReader_0)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(textReader_0, (Class10.Enum5)0);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000033E1 File Offset: 0x000015E1
		public Class21(TextReader textReader_0, Class10.Enum5 enum5_0)
		{
			Class8.ah6VSoGzeNXX5();
			this.class25_0 = new Class10.Class25();
			this.arrayList_0 = new ArrayList();
			base..ctor();
			this.method_3(this.method_4(textReader_0, enum5_0));
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00003412 File Offset: 0x00001612
		public Class21(Stream stream_0)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(new StreamReader(stream_0));
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00003425 File Offset: 0x00001625
		public Class21(Stream stream_0, Class10.Enum5 enum5_0)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(new StreamReader(stream_0), enum5_0);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00003439 File Offset: 0x00001639
		public Class21(Class10.Class23 class23_0)
		{
			Class8.ah6VSoGzeNXX5();
			this.class25_0 = new Class10.Class25();
			this.arrayList_0 = new ArrayList();
			base..ctor();
			this.method_3(class23_0);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00003463 File Offset: 0x00001663
		public Class21()
		{
			Class8.ah6VSoGzeNXX5();
			this.class25_0 = new Class10.Class25();
			this.arrayList_0 = new ArrayList();
			base..ctor();
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00003486 File Offset: 0x00001686
		public Class10.Class25 method_0()
		{
			return this.class25_0;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0001CB88 File Offset: 0x0001AD88
		public void method_1(TextWriter textWriter_0)
		{
			Class10.Class26 @class = new Class10.Class26(textWriter_0);
			foreach (object obj in this.arrayList_0)
			{
				string string_ = (string)obj;
				@class.method_17(string_);
			}
			for (int i = 0; i < this.class25_0.Count; i++)
			{
				Class10.Class24 class2 = this.class25_0.method_0(i);
				@class.method_13(class2.Name, class2.method_0());
				for (int j = 0; j < class2.method_1(); j++)
				{
					Class10.Class22 class3 = class2.method_3(j);
					switch (class3.method_0())
					{
					case (Class10.Enum7)1:
						@class.method_15(class3.Name, class3.method_2(), class3.method_4());
						break;
					case (Class10.Enum7)2:
						@class.method_17(class3.method_4());
						break;
					}
				}
			}
			@class.method_10();
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0001CC98 File Offset: 0x0001AE98
		public void method_2(string string_0)
		{
			StreamWriter streamWriter = new StreamWriter(string_0);
			this.method_1(streamWriter);
			streamWriter.Close();
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0001CCBC File Offset: 0x0001AEBC
		private void method_3(Class10.Class23 class23_0)
		{
			class23_0.method_6(false);
			bool flag = false;
			Class10.Class24 @class = null;
			while (class23_0.method_12())
			{
				switch (class23_0.method_1())
				{
				case (Class10.Enum7)0:
					flag = true;
					if (this.class25_0.method_1(class23_0.Name) != null)
					{
						this.class25_0.method_3(class23_0.Name);
					}
					@class = new Class10.Class24(class23_0.Name, class23_0.method_2());
					this.class25_0.method_2(@class);
					break;
				case (Class10.Enum7)1:
					@class.method_6(class23_0.Name, class23_0.method_0(), class23_0.method_2());
					break;
				case (Class10.Enum7)2:
					if (!flag)
					{
						this.arrayList_0.Add(class23_0.method_2());
					}
					else
					{
						@class.method_8(class23_0.method_2());
					}
					break;
				}
			}
			class23_0.method_15();
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0001CD8C File Offset: 0x0001AF8C
		private Class10.Class23 method_4(TextReader textReader_0, Class10.Enum5 enum5_0)
		{
			Class10.Class23 @class = new Class10.Class23(textReader_0);
			switch (enum5_0)
			{
			case (Class10.Enum5)1:
				@class.method_11(false);
				@class.method_19(new char[]
				{
					':'
				});
				break;
			case (Class10.Enum5)2:
				@class.method_11(false);
				@class.method_9(true);
				break;
			}
			return @class;
		}

		// Token: 0x040001FB RID: 507
		private Class10.Class25 class25_0;

		// Token: 0x040001FC RID: 508
		private ArrayList arrayList_0;
	}

	// Token: 0x02000041 RID: 65
	[Serializable]
	internal sealed class Exception0 : SystemException
	{
		// Token: 0x0600029C RID: 668 RVA: 0x0000348E File Offset: 0x0000168E
		public int method_0()
		{
			if (this.class23_0 != null)
			{
				return this.class23_0.method_4();
			}
			return 0;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000034A5 File Offset: 0x000016A5
		public int method_1()
		{
			if (this.class23_0 != null)
			{
				return this.class23_0.method_3();
			}
			return 0;
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600029E RID: 670 RVA: 0x0001CDE4 File Offset: 0x0001AFE4
		public override string Message
		{
			get
			{
				if (this.class23_0 == null)
				{
					return base.Message;
				}
				return string.Format(CultureInfo.InvariantCulture, "{0} - Line: {1}, Position: {2}.", new object[]
				{
					base.Message,
					this.method_1(),
					this.method_0()
				});
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x000034BC File Offset: 0x000016BC
		public Exception0()
		{
			Class8.ah6VSoGzeNXX5();
			this.string_0 = "";
			base..ctor();
			this.string_0 = "An error has occurred";
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x000034DF File Offset: 0x000016DF
		public Exception0(string string_1, Exception exception_0)
		{
			Class8.ah6VSoGzeNXX5();
			this.string_0 = "";
			base..ctor(string_1, exception_0);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x000034F9 File Offset: 0x000016F9
		public Exception0(string string_1)
		{
			Class8.ah6VSoGzeNXX5();
			this.string_0 = "";
			base..ctor(string_1);
			this.string_0 = string_1;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00003519 File Offset: 0x00001719
		internal Exception0(Class10.Class23 class23_1, string string_1)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(string_1);
			this.class23_0 = class23_1;
			this.string_0 = string_1;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00003535 File Offset: 0x00001735
		protected Exception0(SerializationInfo serializationInfo_0, StreamingContext streamingContext_0)
		{
			Class8.ah6VSoGzeNXX5();
			this.string_0 = "";
			base..ctor(serializationInfo_0, streamingContext_0);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000354F File Offset: 0x0000174F
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			if (this.class23_0 != null)
			{
				info.AddValue("lineNumber", this.class23_0.method_3());
				info.AddValue("linePosition", this.class23_0.method_4());
			}
		}

		// Token: 0x040001FD RID: 509
		private Class10.Class23 class23_0;

		// Token: 0x040001FE RID: 510
		private string string_0;
	}

	// Token: 0x02000042 RID: 66
	internal class Attribute1 : Attribute
	{
		// Token: 0x060002A5 RID: 677 RVA: 0x00002F3B File Offset: 0x0000113B
		public Attribute1(ulong ulong_0)
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}
	}

	// Token: 0x02000043 RID: 67
	[Class10.Attribute1(9223372036854775908UL)]
	internal class Class22
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x0000358D File Offset: 0x0000178D
		public Class10.Enum7 method_0()
		{
			return this.enum7_0;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00003595 File Offset: 0x00001795
		public void method_1(Class10.Enum7 enum7_1)
		{
			this.enum7_0 = enum7_1;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000359E File Offset: 0x0000179E
		public string method_2()
		{
			return this.string_1;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000035A6 File Offset: 0x000017A6
		public void method_3(string string_3)
		{
			this.string_1 = string_3;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060002AA RID: 682 RVA: 0x000035AF File Offset: 0x000017AF
		public string Name
		{
			get
			{
				return this.string_0;
			}
		}

		// Token: 0x060002AB RID: 683 RVA: 0x000035B7 File Offset: 0x000017B7
		public string method_4()
		{
			return this.string_2;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000035BF File Offset: 0x000017BF
		public void method_5(string string_3)
		{
			this.string_2 = string_3;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0001CE3C File Offset: 0x0001B03C
		protected internal Class22(string string_3, string string_4, Class10.Enum7 enum7_1, string string_5)
		{
			Class8.ah6VSoGzeNXX5();
			this.enum7_0 = (Class10.Enum7)2;
			this.string_0 = "";
			this.string_1 = "";
			base..ctor();
			this.string_0 = string_3;
			this.string_1 = string_4;
			this.enum7_0 = enum7_1;
			this.string_2 = string_5;
		}

		// Token: 0x040001FF RID: 511
		private Class10.Enum7 enum7_0;

		// Token: 0x04000200 RID: 512
		private string string_0;

		// Token: 0x04000201 RID: 513
		private string string_1;

		// Token: 0x04000202 RID: 514
		private string string_2;
	}

	// Token: 0x02000044 RID: 68
	internal enum Enum6
	{

	}

	// Token: 0x02000045 RID: 69
	internal enum Enum7
	{

	}

	// Token: 0x02000046 RID: 70
	internal class Class23 : IDisposable
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000035C8 File Offset: 0x000017C8
		public string Name
		{
			get
			{
				return this.stringBuilder_0.ToString();
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x000035D5 File Offset: 0x000017D5
		public string method_0()
		{
			return this.stringBuilder_1.ToString();
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x000035E2 File Offset: 0x000017E2
		public Class10.Enum7 method_1()
		{
			return this.enum7_0;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x000035EA File Offset: 0x000017EA
		public string method_2()
		{
			if (!this.bool_1)
			{
				return null;
			}
			return this.stringBuilder_2.ToString();
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00003601 File Offset: 0x00001801
		public int method_3()
		{
			return this.int_0;
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00003609 File Offset: 0x00001809
		public int method_4()
		{
			return this.int_1;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00003611 File Offset: 0x00001811
		public bool method_5()
		{
			return this.bool_0;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00003619 File Offset: 0x00001819
		public void method_6(bool bool_5)
		{
			this.bool_0 = bool_5;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00003622 File Offset: 0x00001822
		public Class10.Enum6 method_7()
		{
			return this.enum6_0;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000362A File Offset: 0x0000182A
		public bool method_8()
		{
			return this.bool_3;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00003632 File Offset: 0x00001832
		public void method_9(bool bool_5)
		{
			this.bool_3 = bool_5;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000363B File Offset: 0x0000183B
		public bool method_10()
		{
			return this.bool_4;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00003643 File Offset: 0x00001843
		public void method_11(bool bool_5)
		{
			this.bool_4 = bool_5;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0001CE90 File Offset: 0x0001B090
		public Class23(string string_0)
		{
			Class8.ah6VSoGzeNXX5();
			this.int_0 = 1;
			this.int_1 = 1;
			this.enum7_0 = (Class10.Enum7)2;
			this.stringBuilder_0 = new StringBuilder();
			this.stringBuilder_1 = new StringBuilder();
			this.stringBuilder_2 = new StringBuilder();
			this.enum6_0 = (Class10.Enum6)3;
			this.bool_4 = true;
			this.char_0 = new char[]
			{
				';'
			};
			this.object_0 = new char[]
			{
				'='
			};
			base..ctor();
			this.streamReader_0 = new StreamReader(string_0);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0001CF20 File Offset: 0x0001B120
		public Class23(TextReader textReader_0)
		{
			Class8.ah6VSoGzeNXX5();
			this.int_0 = 1;
			this.int_1 = 1;
			this.enum7_0 = (Class10.Enum7)2;
			this.stringBuilder_0 = new StringBuilder();
			this.stringBuilder_1 = new StringBuilder();
			this.stringBuilder_2 = new StringBuilder();
			this.enum6_0 = (Class10.Enum6)3;
			this.bool_4 = true;
			this.char_0 = new char[]
			{
				';'
			};
			this.object_0 = new char[]
			{
				'='
			};
			base..ctor();
			this.streamReader_0 = textReader_0;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000364C File Offset: 0x0000184C
		public Class23(Stream stream_0)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(new StreamReader(stream_0));
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0001CFAC File Offset: 0x0001B1AC
		public bool method_12()
		{
			bool result = false;
			if (this.enum6_0 != (Class10.Enum6)1 || this.enum6_0 != (Class10.Enum6)0)
			{
				this.enum6_0 = (Class10.Enum6)4;
				result = this.method_21();
			}
			return result;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0001CFDC File Offset: 0x0001B1DC
		public bool method_13()
		{
			bool flag;
			do
			{
				flag = this.method_12();
			}
			while (this.enum7_0 != (Class10.Enum7)0 && flag);
			return flag;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0001D000 File Offset: 0x0001B200
		public bool method_14()
		{
			bool flag;
			for (;;)
			{
				flag = this.method_12();
				if (this.enum7_0 == (Class10.Enum7)0)
				{
					break;
				}
				if (this.enum7_0 == (Class10.Enum7)1 || !flag)
				{
					return flag;
				}
			}
			flag = false;
			return flag;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0000365F File Offset: 0x0000185F
		public void method_15()
		{
			this.method_20();
			this.enum6_0 = (Class10.Enum6)0;
			if (this.streamReader_0 != null)
			{
				this.streamReader_0.Close();
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00003681 File Offset: 0x00001881
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000368A File Offset: 0x0000188A
		public char[] method_16()
		{
			return new char[0];
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00002E41 File Offset: 0x00001041
		public void method_17(char[] char_1)
		{
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0001D030 File Offset: 0x0001B230
		public char[] method_18()
		{
			char[] array = new char[this.object_0.Length];
			Array.Copy(this.object_0, 0, array, 0, this.object_0.Length);
			return array;
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00003692 File Offset: 0x00001892
		public void method_19(char[] char_1)
		{
			if (char_1.Length < 1)
			{
				throw new ArgumentException("Must supply at least one delimiter");
			}
			this.object_0 = char_1;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x000036AC File Offset: 0x000018AC
		protected virtual void Dispose(bool bool_5)
		{
			if (!this.bool_2)
			{
				this.streamReader_0.Close();
				this.bool_2 = true;
				if (bool_5)
				{
					GC.SuppressFinalize(this);
				}
			}
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0001D064 File Offset: 0x0001B264
		~Class23()
		{
			this.Dispose(false);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x0001D094 File Offset: 0x0001B294
		private void method_20()
		{
			this.stringBuilder_0.Remove(0, this.stringBuilder_0.Length);
			this.stringBuilder_1.Remove(0, this.stringBuilder_1.Length);
			this.stringBuilder_2.Remove(0, this.stringBuilder_2.Length);
			this.enum7_0 = (Class10.Enum7)2;
			this.bool_1 = false;
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0001D0F8 File Offset: 0x0001B2F8
		private bool method_21()
		{
			bool result = true;
			int num = this.method_30();
			this.method_20();
			if (this.method_31(num))
			{
				this.enum7_0 = (Class10.Enum7)2;
				this.method_29();
				this.method_22();
				return result;
			}
			int num2 = num;
			if (num2 <= 13)
			{
				if (num2 == -1)
				{
					this.enum6_0 = (Class10.Enum6)1;
					return false;
				}
				switch (num2)
				{
				case 9:
				case 13:
					goto IL_86;
				case 10:
					this.method_29();
					return result;
				}
			}
			else
			{
				if (num2 == 32)
				{
					goto IL_86;
				}
				if (num2 == 91)
				{
					this.method_26();
					return result;
				}
			}
			this.method_24();
			return result;
			IL_86:
			this.method_35();
			this.method_21();
			return result;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0001D19C File Offset: 0x0001B39C
		private void method_22()
		{
			this.method_35();
			this.bool_1 = true;
			int num;
			do
			{
				num = this.method_29();
				this.stringBuilder_2.Append((char)num);
			}
			while (!this.method_36(num));
			this.method_23(this.stringBuilder_2);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
		private void method_23(StringBuilder stringBuilder_3)
		{
			string text = stringBuilder_3.ToString();
			stringBuilder_3.Remove(0, stringBuilder_3.Length);
			stringBuilder_3.Append(text.TrimEnd(null));
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0001D214 File Offset: 0x0001B414
		private void method_24()
		{
			this.enum7_0 = (Class10.Enum7)1;
			for (;;)
			{
				int int_ = this.method_30();
				if (this.method_32(int_))
				{
					break;
				}
				if (this.method_36(int_))
				{
					goto IL_39;
				}
				this.stringBuilder_0.Append((char)this.method_29());
			}
			this.method_29();
			this.method_25();
			this.method_27();
			this.method_23(this.stringBuilder_0);
			return;
			IL_39:
			throw new Class10.Exception0(this, string.Format("Expected assignment operator ({0})", this.object_0[0]));
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0001D298 File Offset: 0x0001B498
		private void method_25()
		{
			bool flag = false;
			int num = 0;
			this.method_35();
			for (;;)
			{
				int num2 = this.method_30();
				if (!this.method_34(num2))
				{
					num++;
				}
				if (num2 == 34)
				{
					this.method_29();
					if (flag || num != 1)
					{
						goto IL_11C;
					}
					flag = true;
				}
				else
				{
					if (flag && this.method_36(num2))
					{
						break;
					}
					if (this.bool_3 && num2 == 92)
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append((char)this.method_29());
						while (this.method_30() != 10 && this.method_34(this.method_30()))
						{
							if (this.method_30() != 13)
							{
								stringBuilder.Append((char)this.method_29());
							}
							else
							{
								this.method_29();
							}
						}
						if (this.method_30() == 10)
						{
							this.method_29();
							continue;
						}
						this.stringBuilder_1.Append(stringBuilder.ToString());
					}
					if ((this.bool_4 && this.method_31(num2)) || this.method_36(num2))
					{
						goto IL_11C;
					}
					this.stringBuilder_1.Append((char)this.method_29());
				}
			}
			throw new Class10.Exception0(this, "Expected closing quote (\")");
			IL_11C:
			if (!flag)
			{
				this.method_23(this.stringBuilder_1);
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0001D3D0 File Offset: 0x0001B5D0
		private void method_26()
		{
			this.enum7_0 = (Class10.Enum7)0;
			int num = this.method_29();
			for (;;)
			{
				num = this.method_30();
				if (num == 93)
				{
					goto IL_48;
				}
				if (this.method_36(num))
				{
					break;
				}
				this.stringBuilder_0.Append((char)this.method_29());
			}
			throw new Class10.Exception0(this, "Expected section end (])");
			IL_48:
			this.method_28();
			this.method_23(this.stringBuilder_0);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0001D438 File Offset: 0x0001B638
		private void method_27()
		{
			int int_ = this.method_29();
			while (!this.method_36(int_))
			{
				if (!this.method_31(int_))
				{
					int_ = this.method_29();
				}
				else
				{
					if (this.bool_0)
					{
						this.method_28();
						return;
					}
					this.method_22();
					return;
				}
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0001D480 File Offset: 0x0001B680
		private void method_28()
		{
			int int_;
			do
			{
				int_ = this.method_29();
			}
			while (!this.method_36(int_));
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0001D4A0 File Offset: 0x0001B6A0
		private int method_29()
		{
			int num = this.streamReader_0.Read();
			if (num == 10)
			{
				this.int_0++;
				this.int_1 = 1;
			}
			else
			{
				this.int_1++;
			}
			return num;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000036D1 File Offset: 0x000018D1
		private int method_30()
		{
			return this.streamReader_0.Peek();
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000036DE File Offset: 0x000018DE
		private bool method_31(int int_2)
		{
			return this.method_33(this.char_0, int_2);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000036ED File Offset: 0x000018ED
		private bool method_32(int int_2)
		{
			return this.method_33(this.object_0, int_2);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0001D4E4 File Offset: 0x0001B6E4
		private bool method_33(char[] char_1, int int_2)
		{
			bool result = false;
			for (int i = 0; i < char_1.Length; i++)
			{
				if (int_2 == (int)char_1[i])
				{
					result = true;
					return result;
				}
			}
			return result;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x000036FC File Offset: 0x000018FC
		private bool method_34(int int_2)
		{
			return int_2 == 32 || int_2 == 9 || int_2 == 13 || int_2 == 10;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00003714 File Offset: 0x00001914
		private void method_35()
		{
			while (this.method_34(this.method_30()))
			{
				if (this.method_36(this.method_30()))
				{
					return;
				}
				this.method_29();
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000373D File Offset: 0x0000193D
		private bool method_36(int int_2)
		{
			return int_2 == 10 || int_2 == -1;
		}

		// Token: 0x04000205 RID: 517
		private int int_0;

		// Token: 0x04000206 RID: 518
		private int int_1;

		// Token: 0x04000207 RID: 519
		private Class10.Enum7 enum7_0;

		// Token: 0x04000208 RID: 520
		private StreamReader streamReader_0;

		// Token: 0x04000209 RID: 521
		private bool bool_0;

		// Token: 0x0400020A RID: 522
		private StringBuilder stringBuilder_0;

		// Token: 0x0400020B RID: 523
		private StringBuilder stringBuilder_1;

		// Token: 0x0400020C RID: 524
		private StringBuilder stringBuilder_2;

		// Token: 0x0400020D RID: 525
		private Class10.Enum6 enum6_0;

		// Token: 0x0400020E RID: 526
		private bool bool_1;

		// Token: 0x0400020F RID: 527
		private bool bool_2;

		// Token: 0x04000210 RID: 528
		private bool bool_3;

		// Token: 0x04000211 RID: 529
		private bool bool_4;

		// Token: 0x04000212 RID: 530
		private char[] char_0;

		// Token: 0x04000213 RID: 531
		private object object_0;
	}

	// Token: 0x02000047 RID: 71
	internal sealed class Class24
	{
		// Token: 0x060002DA RID: 730 RVA: 0x0000374A File Offset: 0x0000194A
		public Class24(string string_2, string string_3)
		{
			Class8.ah6VSoGzeNXX5();
			this.class27_0 = new Class10.Class27();
			this.string_0 = "";
			base..ctor();
			this.string_0 = string_2;
			this.string_1 = string_3;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000377B File Offset: 0x0000197B
		public Class24(string string_2)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(string_2, null);
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000378A File Offset: 0x0000198A
		public string Name
		{
			get
			{
				return this.string_0;
			}
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00003792 File Offset: 0x00001992
		public string method_0()
		{
			return this.string_1;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000379A File Offset: 0x0000199A
		public int method_1()
		{
			return this.class27_0.Count;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0001D510 File Offset: 0x0001B710
		public string method_2(string string_2)
		{
			string result = null;
			if (this.method_5(string_2))
			{
				Class10.Class22 @class = (Class10.Class22)this.class27_0[string_2];
				result = @class.method_2();
			}
			return result;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000037A7 File Offset: 0x000019A7
		public Class10.Class22 method_3(int int_1)
		{
			return (Class10.Class22)this.class27_0.method_0(int_1);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0001D544 File Offset: 0x0001B744
		public string[] method_4()
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < this.class27_0.Count; i++)
			{
				Class10.Class22 @class = (Class10.Class22)this.class27_0.method_0(i);
				if (@class.method_0() == (Class10.Enum7)1)
				{
					arrayList.Add(@class.Name);
				}
			}
			string[] array = new string[arrayList.Count];
			arrayList.CopyTo(array, 0);
			return array;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000037BA File Offset: 0x000019BA
		public bool method_5(string string_2)
		{
			return this.class27_0[string_2] != null;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0001D5AC File Offset: 0x0001B7AC
		public void method_6(string string_2, string string_3, string string_4)
		{
			Class10.Class22 @class;
			if (this.method_5(string_2))
			{
				@class = (Class10.Class22)this.class27_0[string_2];
				@class.method_3(string_3);
				@class.method_5(string_4);
				return;
			}
			@class = new Class10.Class22(string_2, string_3, (Class10.Enum7)1, string_4);
			this.class27_0.Add(string_2, @class);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0001D5FC File Offset: 0x0001B7FC
		public void method_7(string string_2, string string_3)
		{
			Class10.Class22 @class;
			if (this.method_5(string_2))
			{
				@class = (Class10.Class22)this.class27_0[string_2];
				@class.method_3(string_3);
				@class.method_5(this.string_1);
				return;
			}
			@class = new Class10.Class22(string_2, string_3, (Class10.Enum7)1, null);
			this.class27_0.Add(string_2, @class);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0001D654 File Offset: 0x0001B854
		public void method_8(string string_2)
		{
			string text = "#comment" + this.int_0;
			Class10.Class22 value = new Class10.Class22(text, null, (Class10.Enum7)2, string_2);
			this.class27_0.Add(text, value);
			this.int_0++;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000037CE File Offset: 0x000019CE
		public void method_9()
		{
			this.method_8(null);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000037D7 File Offset: 0x000019D7
		public void method_10(string string_2)
		{
			if (this.method_5(string_2))
			{
				this.class27_0.Remove(string_2);
			}
		}

		// Token: 0x04000214 RID: 532
		private Class10.Class27 class27_0;

		// Token: 0x04000215 RID: 533
		private string string_0;

		// Token: 0x04000216 RID: 534
		private string string_1;

		// Token: 0x04000217 RID: 535
		private int int_0;
	}

	// Token: 0x02000048 RID: 72
	[DefaultMember("Item")]
	internal class Class25 : ICollection, IEnumerable
	{
		// Token: 0x060002E8 RID: 744 RVA: 0x000037EE File Offset: 0x000019EE
		public Class10.Class24 method_0(int int_0)
		{
			return (Class10.Class24)this.class27_0.method_0(int_0);
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00003801 File Offset: 0x00001A01
		public Class10.Class24 method_1(string string_0)
		{
			return (Class10.Class24)this.class27_0[string_0];
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00003814 File Offset: 0x00001A14
		public int Count
		{
			get
			{
				return this.class27_0.Count;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060002EB RID: 747 RVA: 0x00003821 File Offset: 0x00001A21
		public object SyncRoot
		{
			get
			{
				return this.class27_0.SyncRoot;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060002EC RID: 748 RVA: 0x0000382E File Offset: 0x00001A2E
		public bool IsSynchronized
		{
			get
			{
				return this.class27_0.IsSynchronized;
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000383B File Offset: 0x00001A3B
		public void method_2(Class10.Class24 class24_0)
		{
			if (this.class27_0.Contains(class24_0))
			{
				throw new ArgumentException("IniSection already exists");
			}
			this.class27_0.Add(class24_0.Name, class24_0);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00003868 File Offset: 0x00001A68
		public void method_3(string string_0)
		{
			this.class27_0.Remove(string_0);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00003876 File Offset: 0x00001A76
		public void CopyTo(Array array, int index)
		{
			this.class27_0.CopyTo(array, index);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00003885 File Offset: 0x00001A85
		public void method_4(Class10.Class24[] class24_0, int int_0)
		{
			((ICollection)this.class27_0).CopyTo(class24_0, int_0);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00003894 File Offset: 0x00001A94
		public IEnumerator GetEnumerator()
		{
			return this.class27_0.method_5();
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000038A1 File Offset: 0x00001AA1
		public Class25()
		{
			Class8.ah6VSoGzeNXX5();
			this.class27_0 = new Class10.Class27();
			base..ctor();
		}

		// Token: 0x04000218 RID: 536
		private Class10.Class27 class27_0;
	}

	// Token: 0x02000049 RID: 73
	internal enum Enum8
	{

	}

	// Token: 0x0200004A RID: 74
	internal class Class26 : IDisposable
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x000038B9 File Offset: 0x00001AB9
		public int method_0()
		{
			return this.int_0;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0001D69C File Offset: 0x0001B89C
		public void method_1(int int_1)
		{
			if (int_1 < 0)
			{
				throw new ArgumentException("Negative values are illegal");
			}
			this.int_0 = int_1;
			this.stringBuilder_0.Remove(0, this.stringBuilder_0.Length);
			for (int i = 0; i < int_1; i++)
			{
				this.stringBuilder_0.Append(' ');
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000038C1 File Offset: 0x00001AC1
		public bool method_2()
		{
			return this.bool_0;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x000038C9 File Offset: 0x00001AC9
		public void method_3(bool bool_2)
		{
			this.bool_0 = bool_2;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x000038D2 File Offset: 0x00001AD2
		public Class10.Enum8 method_4()
		{
			return this.enum8_0;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x000038DA File Offset: 0x00001ADA
		public char method_5()
		{
			return this.char_0;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x000038E2 File Offset: 0x00001AE2
		public void method_6(char char_2)
		{
			this.char_0 = char_2;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x000038EB File Offset: 0x00001AEB
		public char method_7()
		{
			return this.char_1;
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000038F3 File Offset: 0x00001AF3
		public void method_8(char char_2)
		{
			this.char_1 = char_2;
		}

		// Token: 0x060002FC RID: 764 RVA: 0x000038FC File Offset: 0x00001AFC
		public Stream method_9()
		{
			return this.stream_0;
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00003904 File Offset: 0x00001B04
		public Class26(string string_1)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(new FileStream(string_1, FileMode.Create, FileAccess.Write, FileShare.None));
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0001D6F4 File Offset: 0x0001B8F4
		public Class26(TextWriter textWriter_1)
		{
			Class8.ah6VSoGzeNXX5();
			this.char_0 = ';';
			this.char_1 = '=';
			this.string_0 = "\r\n";
			this.stringBuilder_0 = new StringBuilder();
			base..ctor();
			this.textWriter_0 = textWriter_1;
			StreamWriter streamWriter = textWriter_1 as StreamWriter;
			if (streamWriter != null)
			{
				this.stream_0 = streamWriter.BaseStream;
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000391A File Offset: 0x00001B1A
		public Class26(Stream stream_1)
		{
			Class8.ah6VSoGzeNXX5();
			this..ctor(new StreamWriter(stream_1));
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000392D File Offset: 0x00001B2D
		public void method_10()
		{
			this.textWriter_0.Close();
			this.enum8_0 = (Class10.Enum8)3;
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00003941 File Offset: 0x00001B41
		public void method_11()
		{
			this.textWriter_0.Flush();
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000394E File Offset: 0x00001B4E
		public override string ToString()
		{
			return this.textWriter_0.ToString();
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000395B File Offset: 0x00001B5B
		public void method_12(string string_1)
		{
			this.method_20();
			this.enum8_0 = (Class10.Enum8)2;
			this.method_23("[" + string_1 + "]");
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00003980 File Offset: 0x00001B80
		public void method_13(string string_1, string string_2)
		{
			this.method_20();
			this.enum8_0 = (Class10.Enum8)2;
			this.method_23("[" + string_1 + "]" + this.method_21(string_2));
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0001D750 File Offset: 0x0001B950
		public void method_14(string string_1, string string_2)
		{
			this.method_19();
			this.method_23(string.Concat(new object[]
			{
				string_1,
				" ",
				this.char_1,
				" ",
				this.method_18(string_2)
			}));
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0001D7A4 File Offset: 0x0001B9A4
		public void method_15(string string_1, string string_2, string string_3)
		{
			this.method_19();
			this.method_23(string.Concat(new object[]
			{
				string_1,
				" ",
				this.char_1,
				" ",
				this.method_18(string_2),
				this.method_21(string_3)
			}));
		}

		// Token: 0x06000307 RID: 775 RVA: 0x000039AC File Offset: 0x00001BAC
		public void method_16()
		{
			this.method_20();
			if (this.enum8_0 == (Class10.Enum8)0)
			{
				this.enum8_0 = (Class10.Enum8)1;
			}
			this.method_23("");
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0001D800 File Offset: 0x0001BA00
		public void method_17(string string_1)
		{
			this.method_20();
			if (this.enum8_0 == (Class10.Enum8)0)
			{
				this.enum8_0 = (Class10.Enum8)1;
			}
			if (string_1 == null)
			{
				this.method_23("");
				return;
			}
			this.method_23(this.char_0 + " " + string_1);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000039CE File Offset: 0x00001BCE
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000039D7 File Offset: 0x00001BD7
		protected virtual void Dispose(bool bool_2)
		{
			if (!this.bool_1)
			{
				this.textWriter_0.Close();
				this.stream_0.Close();
				this.bool_1 = true;
				if (bool_2)
				{
					GC.SuppressFinalize(this);
				}
			}
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0001D850 File Offset: 0x0001BA50
		~Class26()
		{
			this.Dispose(false);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0001D880 File Offset: 0x0001BA80
		private string method_18(string string_1)
		{
			string result;
			if (this.bool_0)
			{
				result = this.method_24('"' + string_1 + '"');
			}
			else
			{
				result = this.method_24(string_1);
			}
			return result;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0001D8BC File Offset: 0x0001BABC
		private void method_19()
		{
			this.method_20();
			switch (this.enum8_0)
			{
			case (Class10.Enum8)0:
			case (Class10.Enum8)1:
				throw new InvalidOperationException("The WriteState is not Section");
			case (Class10.Enum8)2:
				return;
			case (Class10.Enum8)3:
				throw new InvalidOperationException("The writer is closed");
			default:
				return;
			}
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00003A07 File Offset: 0x00001C07
		private void method_20()
		{
			if (this.enum8_0 == (Class10.Enum8)3)
			{
				throw new InvalidOperationException("The writer is closed");
			}
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0001D904 File Offset: 0x0001BB04
		private string method_21(string string_1)
		{
			if (string_1 != null)
			{
				return string.Concat(new object[]
				{
					" ",
					this.char_0,
					" ",
					string_1
				});
			}
			return "";
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00003A1D File Offset: 0x00001C1D
		private void method_22(string string_1)
		{
			this.textWriter_0.Write(this.stringBuilder_0.ToString() + string_1);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00003A3B File Offset: 0x00001C3B
		private void method_23(string string_1)
		{
			this.method_22(string_1 + this.string_0);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00003A4F File Offset: 0x00001C4F
		private string method_24(string string_1)
		{
			return string_1.Replace("\n", "");
		}

		// Token: 0x0400021A RID: 538
		private int int_0;

		// Token: 0x0400021B RID: 539
		private bool bool_0;

		// Token: 0x0400021C RID: 540
		private Class10.Enum8 enum8_0;

		// Token: 0x0400021D RID: 541
		private char char_0;

		// Token: 0x0400021E RID: 542
		private char char_1;

		// Token: 0x0400021F RID: 543
		private TextWriter textWriter_0;

		// Token: 0x04000220 RID: 544
		private string string_0;

		// Token: 0x04000221 RID: 545
		private StringBuilder stringBuilder_0;

		// Token: 0x04000222 RID: 546
		private Stream stream_0;

		// Token: 0x04000223 RID: 547
		private bool bool_1;
	}

	// Token: 0x0200004B RID: 75
	internal sealed class Class27 : ICollection, IEnumerable, IDictionary
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000313 RID: 787 RVA: 0x00003A61 File Offset: 0x00001C61
		public int Count
		{
			get
			{
				return this.arrayList_0.Count;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000314 RID: 788 RVA: 0x00003A6E File Offset: 0x00001C6E
		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00003A6E File Offset: 0x00001C6E
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000316 RID: 790 RVA: 0x00003A6E File Offset: 0x00001C6E
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0001D94C File Offset: 0x0001BB4C
		public object method_0(int int_0)
		{
			return ((DictionaryEntry)this.arrayList_0[int_0]).Value;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0001D974 File Offset: 0x0001BB74
		public void method_1(int int_0, object object_0)
		{
			if (int_0 < 0 || int_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			object key = ((DictionaryEntry)this.arrayList_0[int_0]).Key;
			this.arrayList_0[int_0] = new DictionaryEntry(key, object_0);
			this.hashtable_0[key] = object_0;
		}

		// Token: 0x17000034 RID: 52
		public object this[object key]
		{
			get
			{
				return this.hashtable_0[key];
			}
			set
			{
				if (this.hashtable_0.Contains(key))
				{
					this.hashtable_0[key] = value;
					this.hashtable_0[this.method_6(key)] = new DictionaryEntry(key, value);
					return;
				}
				this.Add(key, value);
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600031B RID: 795 RVA: 0x0001DA2C File Offset: 0x0001BC2C
		public ICollection Keys
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i < this.arrayList_0.Count; i++)
				{
					arrayList.Add(((DictionaryEntry)this.arrayList_0[i]).Key);
				}
				return arrayList;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0001DA78 File Offset: 0x0001BC78
		public ICollection Values
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i < this.arrayList_0.Count; i++)
				{
					arrayList.Add(((DictionaryEntry)this.arrayList_0[i]).Value);
				}
				return arrayList;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600031D RID: 797 RVA: 0x00003A7F File Offset: 0x00001C7F
		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00003A82 File Offset: 0x00001C82
		public void Add(object key, object value)
		{
			this.hashtable_0.Add(key, value);
			this.arrayList_0.Add(new DictionaryEntry(key, value));
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00003AA9 File Offset: 0x00001CA9
		public void Clear()
		{
			this.hashtable_0.Clear();
			this.arrayList_0.Clear();
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00003AC1 File Offset: 0x00001CC1
		public bool Contains(object key)
		{
			return this.hashtable_0.Contains(key);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00003ACF File Offset: 0x00001CCF
		public void CopyTo(Array array, int index)
		{
			this.hashtable_0.CopyTo(array, index);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00003ACF File Offset: 0x00001CCF
		public void method_2(DictionaryEntry[] dictionaryEntry_0, int int_0)
		{
			this.hashtable_0.CopyTo(dictionaryEntry_0, int_0);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00003ADE File Offset: 0x00001CDE
		public void method_3(int int_0, object object_0, object object_1)
		{
			if (int_0 > this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.hashtable_0.Add(object_0, object_1);
			this.arrayList_0.Insert(int_0, new DictionaryEntry(object_0, object_1));
		}

		// Token: 0x06000324 RID: 804 RVA: 0x00003B19 File Offset: 0x00001D19
		public void Remove(object key)
		{
			this.hashtable_0.Remove(key);
			this.arrayList_0.RemoveAt(this.method_6(key));
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0001DAC4 File Offset: 0x0001BCC4
		public void method_4(int int_0)
		{
			if (int_0 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			this.hashtable_0.Remove(((DictionaryEntry)this.arrayList_0[int_0]).Key);
			this.arrayList_0.RemoveAt(int_0);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00003B39 File Offset: 0x00001D39
		public IEnumerator method_5()
		{
			return new Class10.Class28(this.arrayList_0);
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00003B39 File Offset: 0x00001D39
		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return new Class10.Class28(this.arrayList_0);
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00003B39 File Offset: 0x00001D39
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Class10.Class28(this.arrayList_0);
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0001DB18 File Offset: 0x0001BD18
		private int method_6(object object_0)
		{
			for (int i = 0; i < this.arrayList_0.Count; i++)
			{
				if (((DictionaryEntry)this.arrayList_0[i]).Key.Equals(object_0))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00003B46 File Offset: 0x00001D46
		public Class27()
		{
			Class8.ah6VSoGzeNXX5();
			this.hashtable_0 = new Hashtable();
			this.arrayList_0 = new ArrayList();
			base..ctor();
		}

		// Token: 0x04000224 RID: 548
		private Hashtable hashtable_0;

		// Token: 0x04000225 RID: 549
		private ArrayList arrayList_0;
	}

	// Token: 0x0200004C RID: 76
	internal sealed class Class28 : IEnumerator, IDictionaryEnumerator
	{
		// Token: 0x0600032B RID: 811 RVA: 0x00003B69 File Offset: 0x00001D69
		internal Class28(ArrayList arrayList_1)
		{
			Class8.ah6VSoGzeNXX5();
			this.int_0 = -1;
			base..ctor();
			this.arrayList_0 = arrayList_1;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600032C RID: 812 RVA: 0x00003B84 File Offset: 0x00001D84
		object IEnumerator.Current
		{
			get
			{
				if (this.int_0 < 0 || this.int_0 >= this.arrayList_0.Count)
				{
					throw new InvalidOperationException();
				}
				return this.arrayList_0[this.int_0];
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00003BB9 File Offset: 0x00001DB9
		public DictionaryEntry method_0()
		{
			if (this.int_0 < 0 || this.int_0 >= this.arrayList_0.Count)
			{
				throw new InvalidOperationException();
			}
			return (DictionaryEntry)this.arrayList_0[this.int_0];
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600032E RID: 814 RVA: 0x00003BF3 File Offset: 0x00001DF3
		public DictionaryEntry Entry
		{
			get
			{
				return this.method_0();
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0001DB60 File Offset: 0x0001BD60
		public object Key
		{
			get
			{
				return this.Entry.Key;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0001DB7C File Offset: 0x0001BD7C
		public object Value
		{
			get
			{
				return this.Entry.Value;
			}
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00003BFB File Offset: 0x00001DFB
		public bool MoveNext()
		{
			this.int_0++;
			return this.int_0 < this.arrayList_0.Count;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00003C21 File Offset: 0x00001E21
		public void Reset()
		{
			this.int_0 = -1;
		}

		// Token: 0x04000226 RID: 550
		private int int_0;

		// Token: 0x04000227 RID: 551
		private ArrayList arrayList_0;
	}

	// Token: 0x0200004D RID: 77
	internal sealed class Class29
	{
		// Token: 0x06000333 RID: 819 RVA: 0x0001DB98 File Offset: 0x0001BD98
		public Class29()
		{
			Class8.ah6VSoGzeNXX5();
			this.bool_1 = true;
			this.bool_3 = true;
			this.string_0 = "";
			this.string_1 = "";
			this.string_2 = "";
			this.string_3 = "";
			this.bool_5 = true;
			this.string_4 = "";
			this.bool_9 = true;
			this.bool_11 = true;
			this.bool_13 = true;
			this.bool_19 = true;
			this.bool_20 = true;
			this.bool_25 = true;
			this.int_0 = 9;
			this.bool_28 = true;
			this.string_5 = "";
			this.string_6 = "<AssemblyLocation>\\<AssemblyName>_Secure\\<AssemblyFileName>";
			this.bool_34 = true;
			this.bool_35 = true;
			this.bool_36 = true;
			this.class18_0 = new Class10.Class18();
			this.string_7 = "";
			this.string_8 = "";
			this.string_9 = "";
			this.string_10 = "";
			this.string_11 = "";
			this.ykhrHdJeDZ = "";
			this.bool_37 = true;
			this.bool_38 = true;
			this.bool_40 = true;
			this.bool_41 = true;
			this.bool_42 = true;
			this.dateTime_0 = DateTime.Now;
			this.string_12 = "";
			this.bool_46 = true;
			this.bool_47 = true;
			this.bool_48 = true;
			this.int_1 = 5;
			this.int_2 = -1;
			this.int_3 = 14;
			this.int_4 = 10;
			this.int_5 = 10;
			this.int_6 = 5;
			this.bool_52 = true;
			this.string_13 = "Lock System";
			this.string_14 = "";
			this.bool_53 = true;
			this.bool_54 = true;
			this.bool_55 = true;
			this.string_15 = "Your expiration date is reached! You need to purchase a license file to run this software.";
			this.string_16 = "Nag Screen! This message will disappear when a valid license file is installed. You are on day [current_minutes_days] of your [max_minutes_days] day evaluation period. You have [minutes_days_left] days left. You have used this software [current_uses] times out of a maximum of [max_uses]. You have [uses_left] uses left.";
			this.string_17 = "This software won't run without a valid license file. Either a valid license file could not be found or your license file is expired.";
			this.string_18 = "You are on day [current_minutes_days] of your [max_minutes_days] day evaluation period. Your trial period is expired! You need to purchase a license to run this software.";
			this.string_19 = "You have used this software [current_uses] times out of a maximum of [max_uses]. You have [uses_left] uses left. Your trial period is expired! You need to purchase a license to run this software.";
			this.string_20 = "You can only run maximal [max_processes] instances of this software at the same time.";
			this.color_0 = Color.White;
			this.color_1 = Color.FromArgb(157, 211, 252);
			this.bool_57 = true;
			this.byte_0 = new byte[0];
			this.class21_0 = new Class10.Class21();
			this.string_21 = "####-####-####-####-####";
			this.dateTime_1 = DateTime.Now;
			this.int_7 = 1;
			this.hashtable_0 = new Hashtable();
			this.byte_1 = new byte[0];
			base..ctor();
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00003C2A File Offset: 0x00001E2A
		internal void method_0()
		{
			if (this.class18_0 != null && this.class18_0.method_8() != null)
			{
				this.class18_0.method_8().Clear();
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0001DE14 File Offset: 0x0001C014
		public Class10.Class21 method_1(bool bool_63, bool bool_64)
		{
			Class10.Class21 @class = new Class10.Class21();
			Class10.Class24 class2 = new Class10.Class24("General_Settings");
			class2.method_6("General_Loading_Screen_Enable", this.bool_0.ToString(), "");
			class2.method_6("General_Exception_Catching", this.bool_1.ToString(), "");
			class2.method_6("General_Internalization", this.bool_2.ToString(), "");
			class2.method_6("General_V3Mode", this.bool_3.ToString(), "");
			class2.method_6("General_VistaAdmin", this.bool_4.ToString(), "");
			class2.method_6("General_App_Icon", this.string_0.ToString(), "");
			class2.method_6("SPC_File", this.string_1.ToString(), "");
			class2.method_6("PVK_File", this.string_2.ToString(), "");
			class2.method_6("PVK_Password", this.string_3.ToString(), "");
			class2.method_6("General_App_Satellite_Assemblies", "", "");
			class2.method_6("General_App_Satellite_Assemblies_Sizes", "", "");
			class2.method_6("General_App_Console", this.bool_29.ToString(), "");
			class2.method_6("General_RequestHID", this.bool_30.ToString(), "");
			class2.method_6("General_Lib_Necrobit", this.bool_6.ToString(), "");
			class2.method_6("General_Mono_Mode", this.bool_7.ToString(), "");
			class2.method_6("General_AdditionalFilesOwnDirectory", this.bool_8.ToString(), "");
			class2.method_6("General_Lib_Obfuscation", this.bool_9.ToString(), "");
			class2.method_6("General_Lib_Merge", this.bool_10.ToString(), "");
			class2.method_6("General_Lib_MergeAttr", this.bool_11.ToString(), "");
			class2.method_6("General_Lib_Pack", this.bool_12.ToString(), "");
			class2.method_6("General_NAT_Merge", this.bool_13.ToString(), "");
			class2.method_6("General_NATCOMP_Merge", this.bool_14.ToString(), "");
			class2.method_6("General_STRONGPRO", this.bool_15.ToString(), "");
			class2.method_6("General_PatchPRO", this.bool_16.ToString(), "");
			class2.method_6("General_ResourcePRO", this.bool_17.ToString(), "");
			class2.method_6("General_NativeApp", this.bool_18.ToString(), "");
			class2.method_6("General_Prejit", this.BqirlQiKo1.ToString(), "");
			class2.method_6("SuppressILDASM", this.bool_19.ToString(), "");
			class2.method_6("General_Obfuscate_Serializable_Types", this.bool_20.ToString(), "");
			class2.method_6("General_IgnoreInternalsVisible", this.bool_31.ToString(), "");
			class2.method_6("General_Lib_MappingFile", this.bool_21.ToString(), "");
			class2.method_6("General_Obfuscate_Public_Items", this.bool_22.ToString(), "");
			class2.method_6("General_Obfuscate_ShortStrings", this.bool_23.ToString(), "");
			class2.method_6("General_Obfuscate_AllParams", this.bool_24.ToString(), "");
			class2.method_6("General_AntiILDASM_MD", this.bool_25.ToString(), "");
			class2.method_6("General_Control_Flow_Obfuscation", this.bool_26.ToString(), "");
			class2.method_6("General_Control_Flow_Obfuscation_Level", this.int_0.ToString(), "");
			class2.method_6("General_Lib_Obfuscation_Unprintable_Characters", this.bool_27.ToString(), "");
			class2.method_6("General_SetCompatibleTextRenderingDefault", this.bool_33.ToString(), "");
			class2.method_6("General_RenderingDefault", this.bool_34.ToString(), "");
			class2.method_6("General_App_VisualStyles", this.bool_5.ToString(), "");
			class2.method_6("General_Lib_String_Encryption", this.bool_28.ToString(), "");
			class2.method_6("General_Lib_DesignTimeLicense", "False", "");
			class2.method_6("General_Lib_AntiDecompiler", "True", "");
			class2.method_6("General_Lib_Native_Protection_License_System", this.bool_35.ToString(), "");
			class2.method_6("General_Lib_Native_Satellite_Name", this.string_4.ToString(), "");
			class2.method_6("General_License_File_Name", this.string_8.ToString(), "");
			class2.method_6("General_PID", this.string_9.ToString(), "");
			class2.method_6("Assembly_File_Name", this.string_10.ToString(), "");
			class2.method_6("Assembly_Full_Name", this.string_11.ToString(), "");
			class2.method_6("General_Lib_Strong_Name_Key_Pair", this.string_5.ToString(), "");
			class2.method_6("General_Target_FileName", this.string_6.ToString(), "");
			class2.method_6("General_Lib_Remove_Resources", this.bool_32.ToString(), "");
			class2.method_6("General_Compressor", this.bool_36.ToString(), "");
			if (bool_63)
			{
				string text = "";
				for (int i = 0; i < this.class18_0.method_4().Length; i++)
				{
					text += this.class18_0.method_4()[i].ToString("D3");
				}
				class2.method_6("MasterKey", text.ToString(), "");
			}
			else if (bool_64)
			{
				class2.method_6("MasterKey", this.class18_0.method_3(), "");
			}
			else
			{
				class2.method_6("MasterKey", this.class18_0.ToString(), "");
			}
			class2.method_6("ImageRuntimeVersion", this.string_7.ToString(), "");
			class2.method_6("PFX_Password", this.ykhrHdJeDZ.ToString(), "");
			string text2 = "";
			IDictionaryEnumerator enumerator = this.hashtable_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				text2 = string.Concat(new string[]
				{
					text2,
					enumerator.Key.ToString().Replace(";", "ez&#01").Replace("|", "ez&#02"),
					"|",
					enumerator.Value.ToString().Replace(";", "ez&#01").Replace("|", "ez&#02"),
					"|"
				});
			}
			text2 = text2.Replace("\"", "'");
			class2.method_6("AdditonalLicenseInformation", text2, "");
			class2.method_6("General_Protection_Type_Enable", this.bool_62.ToString(), "");
			@class.method_0().method_2(class2);
			class2 = new Class10.Class24("Lock_Settings");
			class2.method_6("Lock_Snag_Screen_Enable", this.bool_39.ToString(), "");
			class2.method_6("Not_Found_Screen_Enable", this.bool_40.ToString(), "");
			class2.method_6("Run_Without_License_File", this.bool_37.ToString(), "");
			class2.method_6("Expiration_Behaviour_ALL", this.bool_38.ToString(), "");
			class2.method_6("Lock_Expiration_Screen_Enable", this.bool_41.ToString(), "");
			class2.method_6("Dialogs_Trial_Period_End_Enabled", this.bool_53.ToString(), "");
			class2.method_6("Dialogs_Number_Of_Uses_Enabled", this.bool_54.ToString(), "");
			class2.method_6("Dialogs_Expiration_Date_Enabled", this.bool_55.ToString(), "");
			class2.method_6("Lock_Max_Processes_Exceeded_Screen_Enable", this.bool_42.ToString(), "");
			class2.method_6("Lock_Expiration_Date_Enable", this.bool_43.ToString(), "");
			class2.method_6("Lock_Hardware_Enable", false.ToString(), "");
			class2.method_6("Lock_Hardware_HDD", this.bool_45.ToString(), "");
			class2.method_6("Lock_Hardware_MAC", this.bool_46.ToString(), "");
			class2.method_6("Lock_Hardware_BOARD", this.bool_47.ToString(), "");
			class2.method_6("Lock_Hardware_CPU", this.bool_48.ToString(), "");
			class2.method_6("Lock_License_Enable", this.bool_43.ToString(), "");
			class2.method_6("Lock_License_Expiration_Date", this.dateTime_0.Year.ToString("D4") + this.dateTime_0.Month.ToString("D2") + this.dateTime_0.Day.ToString("D2"), "");
			class2.method_6("Lock_Evaluation_Enable", this.bool_51.ToString(), "");
			class2.method_6("Lock_Number_Of_Uses_Enable", this.bool_49.ToString(), "");
			class2.method_6("Lock_Max_Number_Of_Processes_Enable", this.bool_50.ToString(), "");
			class2.method_6("Lock_Evaluation_Type", this.enum9_0.ToString(), "");
			class2.method_6("Lock_Evaluation_Time", this.int_3.ToString(), "");
			class2.method_6("Lock_Number_Of_Uses", this.int_4.ToString(), "");
			class2.method_6("Lock_Number_Of_Processes", this.int_1.ToString(), "");
			class2.method_6("Lock_Nag_XDays_Before_Expiration", this.int_2.ToString(), "");
			class2.method_6("License_Number_Of_Uses", this.int_5.ToString(), "");
			class2.method_6("License_Number_Of_Processes", this.int_6.ToString(), "");
			class2.method_6("Lock_Expiration_Date", this.dateTime_0.Year.ToString("D4") + this.dateTime_0.Month.ToString("D2") + this.dateTime_0.Day.ToString("D2"), "");
			class2.method_6("Lock_Close_Process_After_Expiration", this.bool_52.ToString(), "");
			class2.method_6("Lock_Run_Another_Process_After_Expiration", this.string_12.ToString(), "");
			class2.method_6("License_Number_Of_Uses_Enable", this.bool_56.ToString(), "");
			class2.method_6("License_Global_Licensing_Behaviour", this.bool_57.ToString(), "");
			class2.method_6("License_Max_Number_Of_Processes_Enable", this.bool_58.ToString(), "");
			class2.method_6("License_Hardware_Enable", this.bool_59.ToString(), "");
			class2.method_6("License_Evaluation_Enable", this.bool_61.ToString(), "");
			class2.method_6("License_Evaluation_Type", this.enum9_1.ToString(), "");
			class2.method_6("License_Evaluation_Time", this.int_7.ToString(), "");
			class2.method_6("License_Expiration_Date_Enable", this.bool_60.ToString(), "");
			class2.method_6("License_Expiration_Date", this.dateTime_1.Year.ToString("D4") + this.dateTime_1.Month.ToString("D2") + this.dateTime_1.Day.ToString("D2"), "");
			@class.method_0().method_2(class2);
			class2 = new Class10.Class24("Dialogs");
			class2.method_6("Dialogs_Caption", this.string_13.ToString(), "");
			class2.method_6("CustomizeMessageBox", this.string_14.ToString(), "");
			class2.method_6("Dialogs_License_Expired", this.string_15.ToString(), "");
			class2.method_6("Dialogs_SnagScreen", this.string_16.ToString(), "");
			class2.method_6("Dialogs_Invalid_License", this.string_17.ToString(), "");
			class2.method_6("Dialogs_License_Examination_Failed", "", "");
			class2.method_6("Dialogs_Trial_Period_End", this.string_18.ToString(), "");
			class2.method_6("Dialogs_Number_Of_Uses", this.string_19.ToString(), "");
			class2.method_6("Dialogs_Max_Processes_Exceeded", this.string_20.ToString(), "");
			class2.method_6("Dialogs_Gradient_Color_Begin", Class10.Class11.smethod_6(this.color_0), "");
			class2.method_6("Dialogs_Gradient_Color_End", Class10.Class11.smethod_6(this.color_1), "");
			class2.method_6("License_HardwareID_2", this.string_21.ToString(), "");
			@class.method_0().method_2(class2);
			return @class;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0001EBF0 File Offset: 0x0001CDF0
		public Class10.Class21 method_2()
		{
			Class10.Class21 @class = new Class10.Class21();
			Class10.Class24 class2 = new Class10.Class24("License_Settings");
			string str = "";
			for (int i = 0; i < this.class18_0.method_4().Length; i++)
			{
				str += this.class18_0.method_4()[i].ToString("D3");
			}
			class2.method_6("MasterKey", str, "");
			class2.method_6("Lock_License_Enable", this.bool_60.ToString(), "");
			class2.method_6("Lock_License_Expiration_Date", this.dateTime_1.Year.ToString("D4") + this.dateTime_1.Month.ToString("D2") + this.dateTime_1.Day.ToString("D2"), "");
			class2.method_6("License_Hardware_Enable", this.bool_59.ToString(), "");
			class2.method_6("Lock_Hardware_HDD", this.bool_45.ToString(), "");
			class2.method_6("Lock_Hardware_MAC", this.bool_46.ToString(), "");
			class2.method_6("Lock_Hardware_BOARD", this.bool_47.ToString(), "");
			class2.method_6("Lock_Hardware_CPU", this.bool_48.ToString(), "");
			class2.method_6("License_Evaluation_Enable", this.bool_61.ToString(), "");
			class2.method_6("License_Evaluation_Type", this.enum9_1.ToString(), "");
			class2.method_6("License_Evaluation_Time", this.int_7.ToString(), "");
			class2.method_6("License_Number_Of_Uses_Enable", this.bool_56.ToString(), "");
			this.byte_0 = new Class10.Class18().method_4();
			class2.method_6("License_Individual_Key", Convert.ToBase64String(this.byte_0), "");
			class2.method_6("License_Global_Licensing_Behaviour", this.bool_57.ToString(), "");
			class2.method_6("License_Max_Number_Of_Processes_Enable", this.bool_58.ToString(), "");
			class2.method_6("License_Number_Of_Uses", this.int_5.ToString(), "");
			class2.method_6("License_Number_Of_Processes", this.int_6.ToString(), "");
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream);
			this.class21_0.method_1(streamWriter);
			byte[] array = memoryStream.ToArray();
			string str2 = "";
			for (int j = 0; j < array.Length; j++)
			{
				str2 += array[j].ToString("D3");
			}
			streamWriter.Close();
			memoryStream.Close();
			class2.method_6("License_HardwareID", str2, "");
			class2.method_6("License_HardwareID_2", this.string_21, "");
			string text = "";
			IDictionaryEnumerator enumerator = this.hashtable_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				text = string.Concat(new string[]
				{
					text,
					enumerator.Key.ToString().Replace(";", "ez&#01").Replace("|", "ez&#02"),
					"|",
					enumerator.Value.ToString().Replace(";", "ez&#01").Replace("|", "ez&#02"),
					"|"
				});
			}
			text = text.Replace("\"", "'");
			class2.method_6("AdditonalLicenseInformation", text, "");
			@class.method_0().method_2(class2);
			return @class;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0001EFD8 File Offset: 0x0001D1D8
		public byte[] method_3()
		{
			Class10.Class21 @class = this.method_1(false, false);
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class10 class2 = new Class10();
			return class2.method_5(memoryStream, true);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0001F010 File Offset: 0x0001D210
		public byte[] method_4()
		{
			Class10.Class21 @class = this.method_1(true, false);
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class10 class2 = new Class10();
			return class2.method_5(memoryStream, true);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0001F048 File Offset: 0x0001D248
		public byte[] method_5()
		{
			Class10.Class21 @class = this.method_1(false, true);
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class10 class2 = new Class10();
			return class2.method_5(memoryStream, true);
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0001F080 File Offset: 0x0001D280
		public byte[] method_6()
		{
			Class10.Class21 @class = this.method_2();
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class10 class2 = new Class10();
			return class2.method_5(memoryStream, true);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0001F0B8 File Offset: 0x0001D2B8
		public static byte[] smethod_0(Class10.Class21 class21_1)
		{
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			class21_1.method_1(textWriter_);
			Class10 @class = new Class10();
			return @class.method_5(memoryStream, true);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0001F0E8 File Offset: 0x0001D2E8
		public void method_7(string string_22)
		{
			byte[] array = this.method_6();
			array = this.method_8(array);
			FileStream fileStream = new FileStream(string_22, FileMode.Create, FileAccess.ReadWrite);
			fileStream.Write(array, 0, array.Length);
			fileStream.Close();
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0001F120 File Offset: 0x0001D320
		public byte[] method_8(byte[] byte_2)
		{
			Class10.Class21 @class = new Class10.Class21();
			Class10.Class24 class2 = new Class10.Class24("sdtwe4dbutueteretdg4er");
			class2.method_6("ujh45mngsdrt3", Convert.ToBase64String(byte_2), "");
			class2.method_6("kjrwejhjsnbbhherw", Convert.ToBase64String(this.byte_1), "");
			@class.method_0().method_2(class2);
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter textWriter_ = new StreamWriter(memoryStream);
			@class.method_1(textWriter_);
			Class10 class3 = new Class10();
			return class3.method_5(memoryStream, false);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0001F1A0 File Offset: 0x0001D3A0
		public void method_9(string string_22)
		{
			byte[] array = this.method_3();
			FileStream fileStream = new FileStream(string_22, FileMode.Create, FileAccess.ReadWrite);
			fileStream.Write(array, 0, array.Length);
			fileStream.Close();
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0001F1D0 File Offset: 0x0001D3D0
		public string method_10(string string_22, string string_23)
		{
			string result;
			try
			{
				if ((Path.GetDirectoryName(string_23.Replace("<", "").Replace(">", "")).ToUpper() + "\\").IndexOf((Path.GetDirectoryName(string_22) + "\\").ToUpper()) >= 0)
				{
					result = string_23.Substring(Path.GetDirectoryName(string_22).Length).Trim(new char[]
					{
						'\\'
					});
				}
				else
				{
					result = string_23;
				}
			}
			catch
			{
				result = string_23;
			}
			return result;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0001F270 File Offset: 0x0001D470
		public string method_11(string string_22, string string_23)
		{
			string result;
			try
			{
				if (string_23 != null && string_23.Length > 0 && string_23[0] == '<')
				{
					result = string_23;
				}
				else if (!Path.IsPathRooted(string_23.Replace("<", "").Replace(">", "")))
				{
					result = Path.GetDirectoryName(string_22) + '\\' + string_23;
				}
				else
				{
					result = string_23;
				}
			}
			catch
			{
				result = string_23;
			}
			return result;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0001F2F0 File Offset: 0x0001D4F0
		public void method_12(string string_22, bool bool_63)
		{
			string text = this.string_10;
			string text2 = this.string_0;
			string text3 = this.string_1;
			string text4 = this.string_2;
			string text5 = this.string_5;
			this.string_6 = this.string_6.Trim();
			string text6 = this.string_6;
			if (this.string_10.Length > 0)
			{
				this.string_10 = this.method_10(string_22, this.string_10);
			}
			if (this.string_0.Length > 0)
			{
				this.string_0 = this.method_10(string_22, this.string_0);
			}
			if (this.string_1.Length > 0)
			{
				this.string_1 = this.method_10(string_22, this.string_1);
			}
			if (this.string_2.Length > 0)
			{
				this.string_2 = this.method_10(string_22, this.string_2);
			}
			if (this.string_6.Length > 0)
			{
				this.string_6 = this.method_10(string_22, this.string_6);
			}
			if (this.string_5.Length > 0)
			{
				this.string_5 = this.method_10(string_22, this.string_5);
			}
			if (!bool_63)
			{
				this.method_1(false, false).method_2(string_22);
			}
			else
			{
				byte[] array = this.method_3();
				FileStream fileStream = new FileStream(string_22, FileMode.Create, FileAccess.ReadWrite);
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
			}
			this.string_10 = text;
			this.string_0 = text2;
			this.string_5 = text5;
			this.string_6 = text6;
			this.string_1 = text3;
			this.string_2 = text4;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0001F468 File Offset: 0x0001D668
		public void method_13(Class10.Class21 class21_1)
		{
			Class10.Class24 @class = class21_1.method_0().method_1("General_Settings");
			this.bool_0 = bool.Parse(@class.method_2("General_Loading_Screen_Enable"));
			try
			{
				if (@class.method_2("General_V3Mode") != null)
				{
					this.bool_3 = bool.Parse(@class.method_2("General_V3Mode"));
				}
				else
				{
					this.bool_3 = false;
				}
			}
			catch
			{
				this.bool_3 = false;
			}
			try
			{
				if (@class.method_2("General_VistaAdmin") != null)
				{
					this.bool_4 = bool.Parse(@class.method_2("General_VistaAdmin"));
				}
				else
				{
					this.bool_4 = false;
				}
			}
			catch
			{
				this.bool_4 = false;
			}
			try
			{
				if (@class.method_2("General_Exception_Catching") != null)
				{
					this.bool_1 = bool.Parse(@class.method_2("General_Exception_Catching"));
				}
				else
				{
					this.bool_1 = true;
				}
			}
			catch
			{
				this.bool_1 = true;
			}
			try
			{
				if (@class.method_2("General_Internalization") != null)
				{
					this.bool_2 = bool.Parse(@class.method_2("General_Internalization"));
				}
				else
				{
					this.bool_2 = false;
				}
			}
			catch
			{
				this.bool_2 = false;
			}
			this.string_0 = "";
			try
			{
				if (@class.method_2("SPC_File") != null)
				{
					this.string_1 = @class.method_2("SPC_File");
				}
				else
				{
					this.string_1 = "";
				}
			}
			catch
			{
				this.string_1 = "";
			}
			try
			{
				if (@class.method_2("PVK_File") != null)
				{
					this.string_2 = @class.method_2("PVK_File");
				}
				else
				{
					this.string_2 = "";
				}
			}
			catch
			{
				this.string_2 = "";
			}
			try
			{
				if (@class.method_2("PVK_Password") != null)
				{
					this.string_3 = @class.method_2("PVK_Password");
				}
				else
				{
					this.string_3 = "";
				}
			}
			catch
			{
				this.string_3 = "";
			}
			if (@class.method_2("General_App_Console") != null)
			{
				this.bool_29 = bool.Parse(@class.method_2("General_App_Console"));
			}
			else
			{
				this.bool_29 = false;
			}
			if (@class.method_2("General_RequestHID") != null)
			{
				this.bool_30 = bool.Parse(@class.method_2("General_RequestHID"));
			}
			else
			{
				this.bool_30 = false;
			}
			try
			{
				if (@class.method_2("General_Lib_Necrobit") != null)
				{
					this.bool_6 = bool.Parse(@class.method_2("General_Lib_Necrobit"));
				}
				else
				{
					this.bool_6 = true;
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("General_Mono_Mode") != null)
				{
					this.bool_7 = bool.Parse(@class.method_2("General_Mono_Mode"));
				}
				else
				{
					this.bool_7 = false;
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("General_AdditionalFilesOwnDirectory") != null)
				{
					this.bool_8 = bool.Parse(@class.method_2("General_AdditionalFilesOwnDirectory"));
				}
				else
				{
					this.bool_8 = false;
				}
			}
			catch
			{
				this.bool_8 = false;
			}
			try
			{
				if (@class.method_2("General_Lib_Obfuscation") != null)
				{
					this.bool_9 = bool.Parse(@class.method_2("General_Lib_Obfuscation"));
				}
				else
				{
					this.bool_9 = true;
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("General_Lib_Merge") != null)
				{
					this.bool_10 = bool.Parse(@class.method_2("General_Lib_Merge"));
				}
				else
				{
					this.bool_10 = false;
				}
			}
			catch
			{
				this.bool_10 = false;
			}
			try
			{
				if (@class.method_2("General_Lib_MergeAttr") != null)
				{
					this.bool_11 = bool.Parse(@class.method_2("General_Lib_MergeAttr"));
				}
				else
				{
					this.bool_11 = true;
				}
			}
			catch
			{
				this.bool_11 = true;
			}
			try
			{
				if (@class.method_2("General_Lib_Pack") != null)
				{
					this.bool_12 = bool.Parse(@class.method_2("General_Lib_Pack"));
				}
				else
				{
					this.bool_12 = false;
				}
			}
			catch
			{
				this.bool_12 = false;
			}
			try
			{
				if (@class.method_2("General_NAT_Merge") != null)
				{
					this.bool_13 = bool.Parse(@class.method_2("General_NAT_Merge"));
				}
				else
				{
					this.bool_13 = false;
				}
			}
			catch
			{
				this.bool_13 = false;
			}
			try
			{
				if (@class.method_2("General_NATCOMP_Merge") != null)
				{
					this.bool_14 = bool.Parse(@class.method_2("General_NATCOMP_Merge"));
				}
				else
				{
					this.bool_14 = false;
				}
			}
			catch
			{
				this.bool_14 = false;
			}
			try
			{
				if (@class.method_2("General_STRONGPRO") != null)
				{
					this.bool_15 = bool.Parse(@class.method_2("General_STRONGPRO"));
				}
				else
				{
					this.bool_15 = false;
				}
			}
			catch
			{
				this.bool_15 = false;
			}
			try
			{
				if (@class.method_2("General_PatchPRO") != null)
				{
					this.bool_16 = bool.Parse(@class.method_2("General_PatchPRO"));
				}
				else
				{
					this.bool_16 = false;
				}
			}
			catch
			{
				this.bool_16 = false;
			}
			try
			{
				if (@class.method_2("General_ResourcePRO") != null)
				{
					this.bool_17 = bool.Parse(@class.method_2("General_ResourcePRO"));
				}
				else
				{
					this.bool_17 = false;
				}
			}
			catch
			{
				this.bool_17 = false;
			}
			try
			{
				if (@class.method_2("General_NativeApp") != null)
				{
					this.bool_18 = bool.Parse(@class.method_2("General_NativeApp"));
				}
				else
				{
					this.bool_18 = false;
				}
			}
			catch
			{
				this.bool_18 = false;
			}
			try
			{
				if (@class.method_2("General_Prejit") != null)
				{
					this.BqirlQiKo1 = bool.Parse(@class.method_2("General_Prejit"));
				}
				else
				{
					this.BqirlQiKo1 = false;
				}
			}
			catch
			{
				this.BqirlQiKo1 = false;
			}
			try
			{
				if (@class.method_2("SuppressILDASM") != null)
				{
					this.bool_19 = bool.Parse(@class.method_2("SuppressILDASM"));
				}
				else
				{
					this.bool_19 = true;
				}
			}
			catch
			{
				this.bool_19 = true;
			}
			try
			{
				if (@class.method_2("General_Obfuscate_Serializable_Types") != null)
				{
					this.bool_20 = bool.Parse(@class.method_2("General_Obfuscate_Serializable_Types"));
				}
				else
				{
					this.bool_20 = true;
				}
			}
			catch
			{
				this.bool_20 = true;
			}
			try
			{
				if (@class.method_2("General_IgnoreInternalsVisible") != null)
				{
					this.bool_31 = bool.Parse(@class.method_2("General_IgnoreInternalsVisible"));
				}
				else
				{
					this.bool_31 = false;
				}
			}
			catch
			{
				this.bool_31 = false;
			}
			try
			{
				if (@class.method_2("General_Lib_MappingFile") != null)
				{
					this.bool_21 = bool.Parse(@class.method_2("General_Lib_MappingFile"));
				}
				else
				{
					this.bool_21 = false;
				}
			}
			catch
			{
				this.bool_21 = false;
			}
			try
			{
				if (@class.method_2("General_Obfuscate_Public_Items") != null)
				{
					this.bool_22 = bool.Parse(@class.method_2("General_Obfuscate_Public_Items"));
				}
				else
				{
					this.bool_22 = false;
				}
			}
			catch
			{
				this.bool_22 = false;
			}
			try
			{
				if (@class.method_2("General_Obfuscate_ShortStrings") != null)
				{
					this.bool_23 = bool.Parse(@class.method_2("General_Obfuscate_ShortStrings"));
				}
				else
				{
					this.bool_23 = false;
				}
			}
			catch
			{
				this.bool_23 = false;
			}
			try
			{
				if (@class.method_2("General_Obfuscate_AllParams") != null)
				{
					this.bool_24 = bool.Parse(@class.method_2("General_Obfuscate_AllParams"));
				}
				else
				{
					this.bool_24 = false;
				}
			}
			catch
			{
				this.bool_24 = false;
			}
			try
			{
				if (@class.method_2("General_AntiILDASM_MD") != null)
				{
					this.bool_25 = bool.Parse(@class.method_2("General_AntiILDASM_MD"));
				}
				else
				{
					this.bool_25 = true;
				}
			}
			catch
			{
				this.bool_25 = true;
			}
			try
			{
				if (@class.method_2("General_Control_Flow_Obfuscation") != null)
				{
					this.bool_26 = bool.Parse(@class.method_2("General_Control_Flow_Obfuscation"));
				}
				else
				{
					this.bool_26 = false;
				}
			}
			catch
			{
				this.bool_26 = false;
			}
			try
			{
				if (@class.method_2("General_Control_Flow_Obfuscation_Level") != null)
				{
					this.int_0 = Convert.ToInt32(@class.method_2("General_Control_Flow_Obfuscation_Level"));
				}
				else
				{
					this.int_0 = 9;
				}
			}
			catch
			{
				this.int_0 = 9;
			}
			try
			{
				if (@class.method_2("General_Lib_Obfuscation_Unprintable_Characters") != null)
				{
					this.bool_27 = bool.Parse(@class.method_2("General_Lib_Obfuscation_Unprintable_Characters"));
				}
				else
				{
					this.bool_27 = false;
				}
			}
			catch
			{
				this.bool_27 = false;
			}
			try
			{
				if (@class.method_2("General_SetCompatibleTextRenderingDefault") != null)
				{
					this.bool_33 = bool.Parse(@class.method_2("General_SetCompatibleTextRenderingDefault"));
				}
				else
				{
					this.bool_33 = false;
				}
			}
			catch
			{
				this.bool_33 = false;
			}
			try
			{
				if (@class.method_2("General_RenderingDefault") != null)
				{
					this.bool_34 = bool.Parse(@class.method_2("General_RenderingDefault"));
				}
				else
				{
					this.bool_34 = true;
				}
			}
			catch
			{
				this.bool_34 = true;
			}
			try
			{
				if (@class.method_2("General_App_VisualStyles") != null)
				{
					this.bool_5 = bool.Parse(@class.method_2("General_App_VisualStyles"));
				}
				else
				{
					this.bool_5 = true;
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("General_Lib_String_Encryption") != null)
				{
					this.bool_28 = bool.Parse(@class.method_2("General_Lib_String_Encryption"));
				}
				else
				{
					this.bool_28 = true;
				}
			}
			catch
			{
			}
			if (@class.method_2("General_Lib_Native_Protection_License_System") != null)
			{
				this.bool_35 = bool.Parse(@class.method_2("General_Lib_Native_Protection_License_System"));
			}
			else
			{
				this.bool_35 = true;
			}
			this.string_4 = @class.method_2("General_Lib_Native_Satellite_Name");
			this.string_8 = @class.method_2("General_License_File_Name");
			this.string_10 = @class.method_2("Assembly_File_Name");
			try
			{
				if (@class.method_2("Assembly_Full_Name") != null)
				{
					this.string_11 = @class.method_2("Assembly_Full_Name");
				}
				else
				{
					this.string_11 = "";
				}
			}
			catch
			{
				this.string_11 = "";
			}
			try
			{
				this.string_9 = @class.method_2("General_PID");
				if (this.string_9 == null)
				{
					this.string_9 = "";
				}
			}
			catch
			{
				this.string_9 = "";
			}
			try
			{
				if (@class.method_2("PFX_Password") != null)
				{
					this.ykhrHdJeDZ = @class.method_2("PFX_Password");
				}
				else
				{
					this.ykhrHdJeDZ = "";
				}
			}
			catch
			{
				this.ykhrHdJeDZ = "";
			}
			this.string_5 = @class.method_2("General_Lib_Strong_Name_Key_Pair");
			try
			{
				this.string_6 = @class.method_2("General_Target_FileName");
				if (this.string_6 == null)
				{
					this.string_6 = "";
				}
			}
			catch
			{
				this.string_6 = "";
			}
			this.bool_32 = bool.Parse(@class.method_2("General_Lib_Remove_Resources"));
			if (@class.method_2("General_Compressor") != null && @class.method_2("General_Compressor").Length > 0)
			{
				this.bool_36 = bool.Parse(@class.method_2("General_Compressor"));
			}
			this.class18_0.method_1(@class.method_2("MasterKey"));
			this.string_7 = @class.method_2("ImageRuntimeVersion");
			string text = @class.method_2("AdditonalLicenseInformation");
			string[] array = text.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length / 2; i++)
			{
				this.hashtable_0.Add(array[i * 2].Replace("ez&#01", ";").Replace("ez&#02", "|"), array[i * 2 + 1].Replace("ez&#01", ";").Replace("ez&#02", "|"));
			}
			this.bool_62 = bool.Parse(@class.method_2("General_Protection_Type_Enable"));
			@class = class21_1.method_0().method_1("Lock_Settings");
			try
			{
				if (@class.method_2("Lock_Close_Process_After_Expiration") != null)
				{
					this.bool_52 = bool.Parse(@class.method_2("Lock_Close_Process_After_Expiration"));
				}
				else
				{
					this.bool_52 = true;
				}
			}
			catch
			{
				this.bool_52 = true;
			}
			try
			{
				if (@class.method_2("Lock_Run_Another_Process_After_Expiration") != null)
				{
					this.string_12 = @class.method_2("Lock_Run_Another_Process_After_Expiration");
				}
			}
			catch
			{
				this.string_12 = "";
			}
			this.bool_39 = bool.Parse(@class.method_2("Lock_Snag_Screen_Enable"));
			this.bool_41 = bool.Parse(@class.method_2("Lock_Expiration_Screen_Enable"));
			this.bool_54 = this.bool_41;
			this.bool_55 = this.bool_41;
			this.bool_53 = this.bool_41;
			try
			{
				if (@class.method_2("Dialogs_Number_Of_Uses_Enabled") != null)
				{
					this.bool_54 = bool.Parse(@class.method_2("Dialogs_Number_Of_Uses_Enabled"));
				}
				else
				{
					this.bool_54 = this.bool_41;
				}
			}
			catch
			{
				this.bool_54 = this.bool_41;
			}
			try
			{
				if (@class.method_2("Not_Found_Screen_Enable") != null)
				{
					this.bool_40 = bool.Parse(@class.method_2("Not_Found_Screen_Enable"));
				}
				else
				{
					this.bool_40 = true;
				}
			}
			catch
			{
				this.bool_40 = true;
			}
			try
			{
				if (@class.method_2("Dialogs_Expiration_Date_Enabled") != null)
				{
					this.bool_55 = bool.Parse(@class.method_2("Dialogs_Expiration_Date_Enabled"));
				}
				else
				{
					this.bool_55 = this.bool_41;
				}
			}
			catch
			{
				this.bool_55 = this.bool_41;
			}
			try
			{
				if (@class.method_2("Dialogs_Trial_Period_End_Enabled") != null)
				{
					this.bool_53 = bool.Parse(@class.method_2("Dialogs_Trial_Period_End_Enabled"));
				}
				else
				{
					this.bool_53 = this.bool_41;
				}
			}
			catch
			{
				this.bool_53 = this.bool_41;
			}
			try
			{
				if (@class.method_2("Lock_Max_Processes_Exceeded_Screen_Enable") != null)
				{
					this.bool_42 = bool.Parse(@class.method_2("Lock_Max_Processes_Exceeded_Screen_Enable"));
				}
				else
				{
					this.bool_42 = true;
				}
			}
			catch
			{
				this.bool_42 = true;
			}
			if (@class.method_2("Run_Without_License_File") != null)
			{
				this.bool_37 = bool.Parse(@class.method_2("Run_Without_License_File"));
			}
			else
			{
				this.bool_37 = true;
			}
			try
			{
				if (@class.method_2("Expiration_Behaviour_ALL") != null)
				{
					this.bool_38 = bool.Parse(@class.method_2("Expiration_Behaviour_ALL"));
				}
				else
				{
					this.bool_38 = true;
				}
			}
			catch
			{
				this.bool_38 = true;
			}
			if (@class.method_2("Lock_License_Enable") != null)
			{
				this.bool_43 = bool.Parse(@class.method_2("Lock_License_Enable"));
			}
			else
			{
				this.bool_43 = false;
			}
			if (@class.method_2("Lock_Expiration_Date_Enable") != null)
			{
				this.bool_43 = bool.Parse(@class.method_2("Lock_Expiration_Date_Enable"));
			}
			else
			{
				this.bool_43 = false;
			}
			this.bool_44 = false;
			if (@class.method_2("License_Hardware_Enable") != null)
			{
				this.bool_59 = bool.Parse(@class.method_2("License_Hardware_Enable"));
			}
			else
			{
				this.bool_59 = false;
			}
			if (@class.method_2("License_Expiration_Date_Enable") != null)
			{
				this.bool_60 = bool.Parse(@class.method_2("License_Expiration_Date_Enable"));
			}
			else
			{
				this.bool_60 = false;
			}
			if (@class.method_2("License_Evaluation_Enable") != null)
			{
				this.bool_61 = bool.Parse(@class.method_2("License_Evaluation_Enable"));
			}
			else
			{
				this.bool_61 = false;
			}
			try
			{
				if (@class.method_2("License_Evaluation_Type") != null)
				{
					this.enum9_1 = (Enum9)Enum.Parse(typeof(Enum9), @class.method_2("License_Evaluation_Type"));
				}
			}
			catch
			{
			}
			this.bool_51 = bool.Parse(@class.method_2("Lock_Evaluation_Enable"));
			try
			{
				if (@class.method_2("Lock_Hardware_HDD") != null)
				{
					this.bool_45 = bool.Parse(@class.method_2("Lock_Hardware_HDD"));
				}
				else
				{
					this.bool_45 = false;
				}
			}
			catch
			{
				this.bool_45 = false;
			}
			try
			{
				if (@class.method_2("Lock_Hardware_MAC") != null)
				{
					this.bool_46 = bool.Parse(@class.method_2("Lock_Hardware_MAC"));
				}
				else
				{
					this.bool_46 = true;
				}
			}
			catch
			{
				this.bool_46 = true;
			}
			try
			{
				if (@class.method_2("Lock_Hardware_BOARD") != null)
				{
					this.bool_47 = bool.Parse(@class.method_2("Lock_Hardware_BOARD"));
				}
				else
				{
					this.bool_47 = true;
				}
			}
			catch
			{
				this.bool_47 = true;
			}
			try
			{
				if (@class.method_2("Lock_Hardware_CPU") != null)
				{
					this.bool_48 = bool.Parse(@class.method_2("Lock_Hardware_CPU"));
				}
				else
				{
					this.bool_48 = true;
				}
			}
			catch
			{
				this.bool_48 = true;
			}
			try
			{
				if (@class.method_2("Lock_Number_Of_Uses_Enable") != null)
				{
					this.bool_49 = bool.Parse(@class.method_2("Lock_Number_Of_Uses_Enable"));
				}
				else
				{
					this.bool_49 = false;
				}
			}
			catch
			{
				this.bool_49 = false;
			}
			try
			{
				if (@class.method_2("Lock_Max_Number_Of_Processes_Enable") != null)
				{
					this.bool_50 = bool.Parse(@class.method_2("Lock_Max_Number_Of_Processes_Enable"));
				}
				else
				{
					this.bool_50 = false;
				}
			}
			catch
			{
				this.bool_50 = false;
			}
			try
			{
				if (@class.method_2("License_Number_Of_Uses_Enable") != null)
				{
					this.bool_56 = bool.Parse(@class.method_2("License_Number_Of_Uses_Enable"));
				}
				else
				{
					this.bool_56 = false;
				}
			}
			catch
			{
				this.bool_56 = false;
			}
			try
			{
				if (@class.method_2("License_Global_Licensing_Behaviour") != null)
				{
					this.bool_57 = bool.Parse(@class.method_2("License_Global_Licensing_Behaviour"));
				}
				else
				{
					this.bool_57 = true;
				}
			}
			catch
			{
				this.bool_57 = true;
			}
			try
			{
				if (@class.method_2("License_Max_Number_Of_Processes_Enable") != null)
				{
					this.bool_58 = bool.Parse(@class.method_2("License_Max_Number_Of_Processes_Enable"));
				}
				else
				{
					this.bool_58 = false;
				}
			}
			catch
			{
				this.bool_58 = false;
			}
			if (@class.method_2("Lock_Evaluation_Type") == "Trial_Days")
			{
				this.enum9_0 = Enum9.Trial_Days;
			}
			else
			{
				this.enum9_0 = Enum9.Runtime_Minutes;
			}
			this.int_3 = Convert.ToInt32(@class.method_2("Lock_Evaluation_Time"));
			try
			{
				if (@class.method_2("License_Evaluation_Time") != null)
				{
					this.int_7 = Convert.ToInt32(@class.method_2("License_Evaluation_Time"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("Lock_Number_Of_Uses") != null)
				{
					this.int_4 = Convert.ToInt32(@class.method_2("Lock_Number_Of_Uses"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("Lock_Number_Of_Processes") != null)
				{
					this.int_1 = Convert.ToInt32(@class.method_2("Lock_Number_Of_Processes"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("Lock_Nag_XDays_Before_Expiration") != null)
				{
					this.int_2 = Convert.ToInt32(@class.method_2("Lock_Nag_XDays_Before_Expiration"));
				}
				else
				{
					this.int_2 = -1;
				}
			}
			catch
			{
				this.int_2 = -1;
			}
			try
			{
				if (@class.method_2("License_Number_Of_Uses") != null)
				{
					this.int_5 = Convert.ToInt32(@class.method_2("License_Number_Of_Uses"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("License_Number_Of_Processes") != null)
				{
					this.int_6 = Convert.ToInt32(@class.method_2("License_Number_Of_Processes"));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("Lock_Expiration_Date") != null)
				{
					string value = @class.method_2("Lock_Expiration_Date").Substring(0, 4);
					string value2 = @class.method_2("Lock_Expiration_Date").Substring(4, 2);
					string value3 = @class.method_2("Lock_Expiration_Date").Substring(6, 2);
					this.dateTime_0 = new DateTime(Convert.ToInt32(value), Convert.ToInt32(value2), Convert.ToInt32(value3));
				}
			}
			catch
			{
			}
			try
			{
				if (@class.method_2("License_Expiration_Date") != null)
				{
					string value4 = @class.method_2("License_Expiration_Date").Substring(0, 4);
					string value5 = @class.method_2("License_Expiration_Date").Substring(4, 2);
					string value6 = @class.method_2("License_Expiration_Date").Substring(6, 2);
					this.dateTime_1 = new DateTime(Convert.ToInt32(value4), Convert.ToInt32(value5), Convert.ToInt32(value6));
				}
			}
			catch
			{
			}
			@class = class21_1.method_0().method_1("Dialogs");
			this.string_13 = @class.method_2("Dialogs_Caption");
			try
			{
				this.string_21 = @class.method_2("License_HardwareID_2");
				if (this.string_21 == null)
				{
					this.string_21 = "####-####-####-####-####";
				}
			}
			catch
			{
				this.string_21 = "####-####-####-####-####";
			}
			try
			{
				this.string_14 = @class.method_2("CustomizeMessageBox");
				if (this.string_14 == null)
				{
					this.string_14 = "";
				}
			}
			catch
			{
				this.string_14 = "";
			}
			this.string_15 = @class.method_2("Dialogs_License_Expired");
			this.string_16 = @class.method_2("Dialogs_SnagScreen");
			try
			{
				if (@class.method_2("Dialogs_Invalid_License").ToString().Length > 0)
				{
					this.string_17 = @class.method_2("Dialogs_Invalid_License");
				}
			}
			catch
			{
			}
			this.string_18 = @class.method_2("Dialogs_Trial_Period_End");
			try
			{
				if (@class.method_2("Dialogs_Number_Of_Uses").ToString().Length > 0)
				{
					this.string_19 = @class.method_2("Dialogs_Number_Of_Uses");
				}
			}
			catch
			{
				this.string_19 = this.string_18;
			}
			try
			{
				if (@class.method_2("Dialogs_Max_Processes_Exceeded").ToString().Length > 0)
				{
					this.string_20 = @class.method_2("Dialogs_Max_Processes_Exceeded");
				}
			}
			catch
			{
			}
			this.color_0 = Class10.Class11.smethod_7(@class.method_2("Dialogs_Gradient_Color_Begin"));
			this.color_1 = Class10.Class11.smethod_7(@class.method_2("Dialogs_Gradient_Color_End"));
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00020EF4 File Offset: 0x0001F0F4
		public void method_14(Class10.Class21 class21_1)
		{
			Class10.Class24 @class = class21_1.method_0().method_1("License_Settings");
			try
			{
				if (@class.method_2("Lock_License_Enable") != null && @class.method_2("Lock_License_Enable").Length > 0)
				{
					this.bool_60 = bool.Parse(@class.method_2("Lock_License_Enable"));
				}
			}
			catch
			{
				this.bool_60 = false;
			}
			try
			{
				if (@class.method_2("Lock_License_Expiration_Date") != null)
				{
					string value = @class.method_2("Lock_License_Expiration_Date").Substring(0, 4);
					string value2 = @class.method_2("Lock_License_Expiration_Date").Substring(4, 2);
					string value3 = @class.method_2("Lock_License_Expiration_Date").Substring(6, 2);
					this.dateTime_1 = new DateTime(Convert.ToInt32(value), Convert.ToInt32(value2), Convert.ToInt32(value3));
				}
			}
			catch
			{
			}
			this.class18_0.method_1(@class.method_2("MasterKey"));
			try
			{
				if (@class.method_2("License_Hardware_Enable") != null)
				{
					this.bool_59 = bool.Parse(@class.method_2("License_Hardware_Enable"));
				}
				else
				{
					this.bool_59 = false;
				}
			}
			catch
			{
				this.bool_59 = false;
			}
			try
			{
				if (@class.method_2("Lock_Hardware_HDD") != null)
				{
					this.bool_45 = bool.Parse(@class.method_2("Lock_Hardware_HDD"));
				}
				else
				{
					this.bool_45 = false;
				}
			}
			catch
			{
				this.bool_45 = false;
			}
			try
			{
				if (@class.method_2("Lock_Hardware_MAC") != null)
				{
					this.bool_46 = bool.Parse(@class.method_2("Lock_Hardware_MAC"));
				}
				else
				{
					this.bool_46 = true;
				}
			}
			catch
			{
				this.bool_46 = true;
			}
			try
			{
				if (@class.method_2("Lock_Hardware_BOARD") != null)
				{
					this.bool_47 = bool.Parse(@class.method_2("Lock_Hardware_BOARD"));
				}
				else
				{
					this.bool_47 = true;
				}
			}
			catch
			{
				this.bool_47 = true;
			}
			try
			{
				if (@class.method_2("Lock_Hardware_CPU") != null)
				{
					this.bool_48 = bool.Parse(@class.method_2("Lock_Hardware_CPU"));
				}
				else
				{
					this.bool_48 = true;
				}
			}
			catch
			{
				this.bool_48 = true;
			}
			try
			{
				if (@class.method_2("License_Evaluation_Enable") != null)
				{
					this.bool_61 = bool.Parse(@class.method_2("License_Evaluation_Enable"));
				}
				else
				{
					this.bool_61 = false;
				}
			}
			catch
			{
				this.bool_61 = false;
			}
			try
			{
				if (@class.method_2("License_Evaluation_Type") != null)
				{
					this.enum9_1 = (Enum9)Enum.Parse(typeof(Enum9), @class.method_2("License_Evaluation_Type"));
				}
				else
				{
					this.enum9_1 = Enum9.Trial_Days;
				}
			}
			catch
			{
				this.enum9_1 = Enum9.Trial_Days;
			}
			try
			{
				if (@class.method_2("License_Evaluation_Time") != null)
				{
					this.int_7 = Convert.ToInt32(@class.method_2("License_Evaluation_Time"));
				}
				else
				{
					this.int_7 = 1;
				}
			}
			catch
			{
				this.int_7 = 1;
			}
			try
			{
				if (@class.method_2("License_Number_Of_Uses_Enable") != null)
				{
					this.bool_56 = bool.Parse(@class.method_2("License_Number_Of_Uses_Enable"));
				}
				else
				{
					this.bool_56 = false;
				}
			}
			catch
			{
				this.bool_56 = false;
			}
			try
			{
				if (@class.method_2("License_Global_Licensing_Behaviour") != null)
				{
					this.bool_57 = bool.Parse(@class.method_2("License_Global_Licensing_Behaviour"));
				}
				else
				{
					this.bool_57 = true;
				}
			}
			catch
			{
				this.bool_57 = true;
			}
			if (!this.bool_57)
			{
				this.byte_0 = Convert.FromBase64String(@class.method_2("License_Individual_Key"));
			}
			else
			{
				this.byte_0 = new Class10.Class18().method_4();
			}
			try
			{
				if (@class.method_2("License_Max_Number_Of_Processes_Enable") != null)
				{
					this.bool_58 = bool.Parse(@class.method_2("License_Max_Number_Of_Processes_Enable"));
				}
				else
				{
					this.bool_58 = false;
				}
			}
			catch
			{
				this.bool_58 = false;
			}
			try
			{
				if (@class.method_2("License_Number_Of_Uses") != null)
				{
					this.int_5 = Convert.ToInt32(@class.method_2("License_Number_Of_Uses"));
				}
				else
				{
					this.int_5 = 1;
				}
			}
			catch
			{
				this.int_5 = 1;
			}
			try
			{
				if (@class.method_2("License_Number_Of_Processes") != null)
				{
					this.int_6 = Convert.ToInt32(@class.method_2("License_Number_Of_Processes"));
				}
				else
				{
					this.int_6 = 5;
				}
			}
			catch
			{
				this.int_6 = 5;
			}
			try
			{
				this.string_21 = @class.method_2("License_HardwareID_2");
			}
			catch
			{
				this.string_21 = "";
			}
			try
			{
				this.class21_0 = null;
				if (@class.method_2("License_HardwareID") != null)
				{
					string text = @class.method_2("License_HardwareID");
					byte[] array = new byte[text.Length / 3];
					for (int i = 0; i < array.Length; i++)
					{
						string value4 = text.Substring(i * 3, 3);
						array[i] = Convert.ToByte(value4);
					}
					MemoryStream memoryStream = new MemoryStream();
					memoryStream.Write(array, 0, array.Length);
					memoryStream.Position = 0L;
					this.class21_0 = new Class10.Class21(memoryStream);
				}
			}
			catch
			{
			}
			try
			{
				this.hashtable_0.Clear();
				string text2 = @class.method_2("AdditonalLicenseInformation");
				string[] array2 = text2.Split(new char[]
				{
					'|'
				});
				for (int j = 0; j < array2.Length / 2; j++)
				{
					this.hashtable_0.Add(array2[j * 2].Replace("ez&#01", ";").Replace("ez&#02", "|"), array2[j * 2 + 1].Replace("ez&#01", ";").Replace("ez&#02", "|"));
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00021520 File Offset: 0x0001F720
		public void method_15(byte[] byte_2)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(byte_2, 0, byte_2.Length);
			Class10 @class = new Class10();
			byte[] array = @class.method_10(memoryStream, true);
			MemoryStream memoryStream2 = new MemoryStream(array.Length);
			memoryStream2.Position = 0L;
			memoryStream2.Write(array, 0, array.Length);
			memoryStream2.Position = 0L;
			Class10.Class21 class21_ = new Class10.Class21(memoryStream2);
			memoryStream2.Close();
			this.method_13(class21_);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00021598 File Offset: 0x0001F798
		public void method_16(string string_22)
		{
			FileStream fileStream = new FileStream(string_22, FileMode.Open, FileAccess.Read);
			fileStream.Position = 0L;
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			byte[] array2 = array;
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(array2, 0, array2.Length);
			Class10 @class = new Class10();
			byte[] array3 = @class.method_10(memoryStream, true);
			MemoryStream memoryStream2 = new MemoryStream(array3.Length);
			memoryStream2.Position = 0L;
			memoryStream2.Write(array3, 0, array3.Length);
			memoryStream2.Position = 0L;
			Class10.Class21 class21_ = new Class10.Class21(memoryStream2);
			memoryStream2.Close();
			this.method_13(class21_);
			if (this.string_10.Length > 0)
			{
				this.string_10 = this.method_11(string_22, this.string_10);
			}
			if (this.string_0.Length > 0)
			{
				this.string_0 = this.method_11(string_22, this.string_0);
			}
			if (this.string_1.Length > 0)
			{
				this.string_1 = this.method_11(string_22, this.string_1);
			}
			if (this.string_2.Length > 0)
			{
				this.string_2 = this.method_11(string_22, this.string_2);
			}
			if (this.string_5.Length > 0)
			{
				this.string_5 = this.method_11(string_22, this.string_5);
			}
			if (this.string_6.Length > 0)
			{
				this.string_6 = this.method_11(string_22, this.string_6);
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00021718 File Offset: 0x0001F918
		public void method_17(byte[] byte_2)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(byte_2, 0, byte_2.Length);
			Class10 @class = new Class10();
			byte[] array = @class.method_10(memoryStream, true);
			MemoryStream memoryStream2 = new MemoryStream(array.Length);
			memoryStream2.Position = 0L;
			memoryStream2.Write(array, 0, array.Length);
			memoryStream2.Position = 0L;
			Class10.Class21 class21_ = new Class10.Class21(memoryStream2);
			memoryStream2.Close();
			this.method_13(class21_);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0002179C File Offset: 0x0001F99C
		public void method_18(byte[] byte_2, bool bool_63, Class10.Class29 class29_0)
		{
			if (bool_63)
			{
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(byte_2, 0, byte_2.Length);
				Class10 @class = new Class10();
				byte[] array = @class.method_10(memoryStream, true);
				MemoryStream memoryStream2 = new MemoryStream(array.Length);
				memoryStream2.Position = 0L;
				memoryStream2.Write(array, 0, array.Length);
				memoryStream2.Position = 0L;
				Class10.Class21 class2 = new Class10.Class21(memoryStream2);
				memoryStream2.Close();
				Class10.Class24 class3 = class2.method_0().method_1("sdtwe4dbutueteretdg4er");
				byte[] byte_3 = Convert.FromBase64String(class3.method_2("ujh45mngsdrt3"));
				byte[] byte_4 = Convert.FromBase64String(class3.method_2("kjrwejhjsnbbhherw"));
				if (Class10.Class18.smethod_1(class29_0.class18_0.method_8(), byte_3, byte_4))
				{
					this.method_18(byte_3, false, class29_0);
				}
				else
				{
					if (this.class18_0 != null && this.class18_0.method_8() != null)
					{
						this.class18_0.method_8().Clear();
					}
					this.class18_0 = new Class10.Class18();
				}
				this.bool_3 = bool_63;
				return;
			}
			MemoryStream memoryStream3 = new MemoryStream();
			memoryStream3.Write(byte_2, 0, byte_2.Length);
			Class10 class4 = new Class10();
			byte[] array2 = class4.method_10(memoryStream3, true);
			MemoryStream memoryStream4 = new MemoryStream(array2.Length);
			memoryStream4.Position = 0L;
			memoryStream4.Write(array2, 0, array2.Length);
			memoryStream4.Position = 0L;
			Class10.Class21 class21_ = new Class10.Class21(memoryStream4);
			memoryStream4.Close();
			this.method_14(class21_);
			this.bool_3 = bool_63;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00021924 File Offset: 0x0001FB24
		public Class10.Class21 method_19(byte[] byte_2)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(byte_2, 0, byte_2.Length);
			Class10 @class = new Class10();
			byte[] array = @class.method_10(memoryStream, true);
			MemoryStream memoryStream2 = new MemoryStream(array.Length);
			memoryStream2.Position = 0L;
			memoryStream2.Write(array, 0, array.Length);
			memoryStream2.Position = 0L;
			return new Class10.Class21(memoryStream2);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00021990 File Offset: 0x0001FB90
		public void method_20(string string_22, bool bool_63, Class10.Class29 class29_0)
		{
			try
			{
				FileStream fileStream = new FileStream(string_22, FileMode.Open, FileAccess.Read);
				fileStream.Position = 0L;
				byte[] array = new byte[fileStream.Length];
				fileStream.Read(array, 0, array.Length);
				fileStream.Close();
				this.method_18(array, bool_63, class29_0);
			}
			catch
			{
				if (this.class18_0 != null && this.class18_0.method_8() != null)
				{
					this.class18_0.method_8().Clear();
				}
				this.class18_0 = new Class10.Class18();
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00021A24 File Offset: 0x0001FC24
		public void method_21(byte[] byte_2, bool bool_63, Class10.Class29 class29_0)
		{
			try
			{
				this.method_18(byte_2, bool_63, class29_0);
			}
			catch
			{
				if (this.class18_0 != null && this.class18_0.method_8() != null)
				{
					this.class18_0.method_8().Clear();
				}
				this.class18_0 = new Class10.Class18();
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00021A80 File Offset: 0x0001FC80
		public Class10.Class21 method_22(string string_22)
		{
			FileStream fileStream = new FileStream(string_22, FileMode.Open, FileAccess.Read);
			fileStream.Position = 0L;
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return this.method_19(array);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00021ACC File Offset: 0x0001FCCC
		public void method_23(string string_22)
		{
			this.method_13(new Class10.Class21(string_22));
			if (this.string_10.Length > 0)
			{
				this.string_10 = this.method_11(string_22, this.string_10);
			}
			if (this.string_0.Length > 0)
			{
				this.string_0 = this.method_11(string_22, this.string_0);
			}
			if (this.string_1.Length > 0)
			{
				this.string_1 = this.method_11(string_22, this.string_1);
			}
			if (this.string_2.Length > 0)
			{
				this.string_2 = this.method_11(string_22, this.string_2);
			}
			if (this.string_5.Length > 0)
			{
				this.string_5 = this.method_11(string_22, this.string_5);
			}
			if (this.string_6.Length > 0)
			{
				this.string_6 = this.method_11(string_22, this.string_6);
			}
		}

		// Token: 0x04000228 RID: 552
		public bool bool_0;

		// Token: 0x04000229 RID: 553
		public bool bool_1;

		// Token: 0x0400022A RID: 554
		public bool bool_2;

		// Token: 0x0400022B RID: 555
		public bool bool_3;

		// Token: 0x0400022C RID: 556
		public bool bool_4;

		// Token: 0x0400022D RID: 557
		public string string_0;

		// Token: 0x0400022E RID: 558
		public string string_1;

		// Token: 0x0400022F RID: 559
		public string string_2;

		// Token: 0x04000230 RID: 560
		public string string_3;

		// Token: 0x04000231 RID: 561
		public bool bool_5;

		// Token: 0x04000232 RID: 562
		public string string_4;

		// Token: 0x04000233 RID: 563
		public bool bool_6;

		// Token: 0x04000234 RID: 564
		public bool bool_7;

		// Token: 0x04000235 RID: 565
		public bool bool_8;

		// Token: 0x04000236 RID: 566
		public bool bool_9;

		// Token: 0x04000237 RID: 567
		public bool bool_10;

		// Token: 0x04000238 RID: 568
		public bool bool_11;

		// Token: 0x04000239 RID: 569
		public bool bool_12;

		// Token: 0x0400023A RID: 570
		public bool bool_13;

		// Token: 0x0400023B RID: 571
		public bool bool_14;

		// Token: 0x0400023C RID: 572
		public bool bool_15;

		// Token: 0x0400023D RID: 573
		public bool bool_16;

		// Token: 0x0400023E RID: 574
		public bool bool_17;

		// Token: 0x0400023F RID: 575
		public bool bool_18;

		// Token: 0x04000240 RID: 576
		public bool BqirlQiKo1;

		// Token: 0x04000241 RID: 577
		public bool bool_19;

		// Token: 0x04000242 RID: 578
		public bool bool_20;

		// Token: 0x04000243 RID: 579
		public bool bool_21;

		// Token: 0x04000244 RID: 580
		public bool bool_22;

		// Token: 0x04000245 RID: 581
		public bool bool_23;

		// Token: 0x04000246 RID: 582
		public bool bool_24;

		// Token: 0x04000247 RID: 583
		public bool bool_25;

		// Token: 0x04000248 RID: 584
		public bool bool_26;

		// Token: 0x04000249 RID: 585
		public int int_0;

		// Token: 0x0400024A RID: 586
		public bool bool_27;

		// Token: 0x0400024B RID: 587
		public bool bool_28;

		// Token: 0x0400024C RID: 588
		public string string_5;

		// Token: 0x0400024D RID: 589
		public string string_6;

		// Token: 0x0400024E RID: 590
		public bool bool_29;

		// Token: 0x0400024F RID: 591
		public bool bool_30;

		// Token: 0x04000250 RID: 592
		public bool bool_31;

		// Token: 0x04000251 RID: 593
		public bool bool_32;

		// Token: 0x04000252 RID: 594
		public bool bool_33;

		// Token: 0x04000253 RID: 595
		public bool bool_34;

		// Token: 0x04000254 RID: 596
		public bool bool_35;

		// Token: 0x04000255 RID: 597
		public bool bool_36;

		// Token: 0x04000256 RID: 598
		internal Class10.Class18 class18_0;

		// Token: 0x04000257 RID: 599
		public string string_7;

		// Token: 0x04000258 RID: 600
		public string string_8;

		// Token: 0x04000259 RID: 601
		public string string_9;

		// Token: 0x0400025A RID: 602
		public string string_10;

		// Token: 0x0400025B RID: 603
		public string string_11;

		// Token: 0x0400025C RID: 604
		public string ykhrHdJeDZ;

		// Token: 0x0400025D RID: 605
		public bool bool_37;

		// Token: 0x0400025E RID: 606
		public bool bool_38;

		// Token: 0x0400025F RID: 607
		public bool bool_39;

		// Token: 0x04000260 RID: 608
		public bool bool_40;

		// Token: 0x04000261 RID: 609
		public bool bool_41;

		// Token: 0x04000262 RID: 610
		public bool bool_42;

		// Token: 0x04000263 RID: 611
		public bool bool_43;

		// Token: 0x04000264 RID: 612
		public DateTime dateTime_0;

		// Token: 0x04000265 RID: 613
		public string string_12;

		// Token: 0x04000266 RID: 614
		public bool bool_44;

		// Token: 0x04000267 RID: 615
		public bool bool_45;

		// Token: 0x04000268 RID: 616
		public bool bool_46;

		// Token: 0x04000269 RID: 617
		public bool bool_47;

		// Token: 0x0400026A RID: 618
		public bool bool_48;

		// Token: 0x0400026B RID: 619
		public bool bool_49;

		// Token: 0x0400026C RID: 620
		public bool bool_50;

		// Token: 0x0400026D RID: 621
		public int int_1;

		// Token: 0x0400026E RID: 622
		public int int_2;

		// Token: 0x0400026F RID: 623
		public bool bool_51;

		// Token: 0x04000270 RID: 624
		public Enum9 enum9_0;

		// Token: 0x04000271 RID: 625
		public int int_3;

		// Token: 0x04000272 RID: 626
		public int int_4;

		// Token: 0x04000273 RID: 627
		public int int_5;

		// Token: 0x04000274 RID: 628
		public int int_6;

		// Token: 0x04000275 RID: 629
		public bool bool_52;

		// Token: 0x04000276 RID: 630
		public string string_13;

		// Token: 0x04000277 RID: 631
		public string string_14;

		// Token: 0x04000278 RID: 632
		public bool bool_53;

		// Token: 0x04000279 RID: 633
		public bool bool_54;

		// Token: 0x0400027A RID: 634
		public bool bool_55;

		// Token: 0x0400027B RID: 635
		public string string_15;

		// Token: 0x0400027C RID: 636
		public string string_16;

		// Token: 0x0400027D RID: 637
		public string string_17;

		// Token: 0x0400027E RID: 638
		public string string_18;

		// Token: 0x0400027F RID: 639
		public string string_19;

		// Token: 0x04000280 RID: 640
		public string string_20;

		// Token: 0x04000281 RID: 641
		public Color color_0;

		// Token: 0x04000282 RID: 642
		public Color color_1;

		// Token: 0x04000283 RID: 643
		public bool bool_56;

		// Token: 0x04000284 RID: 644
		public bool bool_57;

		// Token: 0x04000285 RID: 645
		public byte[] byte_0;

		// Token: 0x04000286 RID: 646
		public bool bool_58;

		// Token: 0x04000287 RID: 647
		public bool bool_59;

		// Token: 0x04000288 RID: 648
		public Class10.Class21 class21_0;

		// Token: 0x04000289 RID: 649
		public string string_21;

		// Token: 0x0400028A RID: 650
		public bool bool_60;

		// Token: 0x0400028B RID: 651
		public DateTime dateTime_1;

		// Token: 0x0400028C RID: 652
		public bool bool_61;

		// Token: 0x0400028D RID: 653
		public Enum9 enum9_1;

		// Token: 0x0400028E RID: 654
		public int int_7;

		// Token: 0x0400028F RID: 655
		public Hashtable hashtable_0;

		// Token: 0x04000290 RID: 656
		public bool bool_62;

		// Token: 0x04000291 RID: 657
		internal byte[] byte_1;
	}
}
