using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using ns0;

// Token: 0x0200004E RID: 78
internal class Class30
{
	// Token: 0x0600034D RID: 845 RVA: 0x00021BAC File Offset: 0x0001FDAC
	private bool method_0(RegistryKey registryKey_0, string string_9)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(string_9);
		this.method_1(registryKey_0, registryKey);
		registryKey.Close();
		return true;
	}

	// Token: 0x0600034E RID: 846 RVA: 0x00021BD4 File Offset: 0x0001FDD4
	private void method_1(RegistryKey registryKey_0, RegistryKey registryKey_1)
	{
		foreach (string name in registryKey_0.GetValueNames())
		{
			object value = registryKey_0.GetValue(name);
			registryKey_1.SetValue(name, value);
		}
		foreach (string text in registryKey_0.GetSubKeyNames())
		{
			RegistryKey registryKey_2 = registryKey_0.OpenSubKey(text, false);
			RegistryKey registryKey_3 = registryKey_1.CreateSubKey(text);
			this.method_1(registryKey_2, registryKey_3);
		}
	}

	// Token: 0x0600034F RID: 847 RVA: 0x00021C50 File Offset: 0x0001FE50
	private void method_2(RegistryKey registryKey_0, string string_9)
	{
		string text = "";
		foreach (string text2 in registryKey_0.GetValueNames())
		{
			string str = registryKey_0.GetValue(text2).ToString();
			if (text.Length > 0)
			{
				text += "|";
			}
			text = text + text2 + "|" + str;
		}
		Class10 @class = new Class10();
		@class.method_2(text, string_9);
	}

	// Token: 0x06000350 RID: 848 RVA: 0x00021CC4 File Offset: 0x0001FEC4
	private void method_3(string string_9, string string_10)
	{
		Class10 @class = new Class10();
		string text = @class.method_3(string_9);
		string[] array = text.Split(new char[]
		{
			'|'
		});
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(string_10);
		for (int i = 0; i < array.Length / 2; i++)
		{
			registryKey.SetValue(array[i * 2], array[i * 2 + 1]);
		}
		registryKey.Close();
	}

	// Token: 0x06000351 RID: 849 RVA: 0x00003C51 File Offset: 0x00001E51
	public License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
	{
		return this.method_4(new byte[0]);
	}

	// Token: 0x06000352 RID: 850 RVA: 0x00021D30 File Offset: 0x0001FF30
	internal License method_4(byte[] byte_1)
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
		bool flag = false;
		if (byte_1.Length > 0)
		{
			flag = true;
		}
		if (!flag && Class30.bool_0)
		{
			return new Class30.Class33(this, "");
		}
		bool flag2 = false;
		if (flag && Class30.bool_0)
		{
			flag2 = Class35.smethod_6();
			Class35.smethod_0();
		}
		Class30.bool_0 = true;
		lSfgApatkdxsVcGcrktoFd lSfgApatkdxsVcGcrktoFd = null;
		try
		{
			lSfgApatkdxsVcGcrktoFd = new lSfgApatkdxsVcGcrktoFd();
		}
		catch
		{
		}
		Class10.Class29 @class = null;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		bool flag3 = false;
		try
		{
			DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			this.type_0 = typeof(rFohpatkdxsVcxLfJKhM7);
			string executablePath = Application.ExecutablePath;
			if (Class30.string_8.Length > 0)
			{
				executablePath = Class30.string_8;
			}
			Class30.string_8 = executablePath;
			new Class10();
			@class = new Class10.Class29();
			BinaryReader binaryReader = new BinaryReader(typeof(Class30).Assembly.GetManifestResourceStream("UOP6setK4nyLy1q2bq.pyJL1HaQ5GgPLY67I4"));
			binaryReader.BaseStream.Position = 0L;
			byte[] byte_2 = new byte[0];
			byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
			byte[] array2 = new byte[32];
			array2[0] = 102;
			array2[0] = 172;
			array2[0] = 97;
			array2[0] = 222;
			array2[1] = 128;
			array2[1] = 61;
			array2[1] = 104;
			array2[1] = 188;
			array2[2] = 62;
			array2[2] = 117;
			array2[2] = 107;
			array2[2] = 136;
			array2[2] = 58;
			array2[3] = 159;
			array2[3] = 25;
			array2[3] = 77;
			array2[3] = 206;
			array2[4] = 90;
			array2[4] = 134;
			array2[4] = 112;
			array2[4] = 106;
			array2[4] = 119;
			array2[5] = 196;
			array2[5] = 194;
			array2[5] = 152;
			array2[5] = 112;
			array2[5] = 102;
			array2[5] = 202;
			array2[6] = 150;
			array2[6] = 161;
			array2[6] = 92;
			array2[6] = 92;
			array2[6] = 163;
			array2[6] = 139;
			array2[7] = 142;
			array2[7] = 140;
			array2[7] = 185;
			array2[7] = 109;
			array2[7] = 164;
			array2[7] = 2;
			array2[8] = 160;
			array2[8] = 162;
			array2[8] = 155;
			array2[8] = 108;
			array2[9] = 118;
			array2[9] = 114;
			array2[9] = 94;
			array2[9] = 92;
			array2[10] = 160;
			array2[10] = 110;
			array2[10] = 104;
			array2[10] = 130;
			array2[10] = 125;
			array2[10] = 212;
			array2[11] = 148;
			array2[11] = 153;
			array2[11] = 97;
			array2[11] = 152;
			array2[11] = 181;
			array2[12] = 152;
			array2[12] = 93;
			array2[12] = 100;
			array2[12] = 215;
			array2[12] = 101;
			array2[13] = 92;
			array2[13] = 120;
			array2[13] = 144;
			array2[13] = 167;
			array2[14] = 126;
			array2[14] = 148;
			array2[14] = 74;
			array2[14] = 130;
			array2[14] = 127;
			array2[15] = 107;
			array2[15] = 141;
			array2[15] = 84;
			array2[15] = 69;
			array2[16] = 142;
			array2[16] = 117;
			array2[16] = 85;
			array2[16] = 123;
			array2[16] = 198;
			array2[17] = 20;
			array2[17] = 112;
			array2[17] = 140;
			array2[17] = 92;
			array2[18] = 85;
			array2[18] = 162;
			array2[18] = 98;
			array2[19] = 134;
			array2[19] = 216;
			array2[19] = 153;
			array2[19] = 90;
			array2[19] = 98;
			array2[19] = 144;
			array2[20] = 150;
			array2[20] = 56;
			array2[20] = 92;
			array2[20] = 248;
			array2[21] = 162;
			array2[21] = 124;
			array2[21] = 61;
			array2[22] = 75;
			array2[22] = 156;
			array2[22] = 167;
			array2[22] = 208;
			array2[22] = 169;
			array2[22] = 118;
			array2[23] = 92;
			array2[23] = 120;
			array2[23] = 59;
			array2[24] = 156;
			array2[24] = 149;
			array2[24] = 89;
			array2[24] = 188;
			array2[24] = 132;
			array2[25] = 80;
			array2[25] = 132;
			array2[25] = 26;
			array2[25] = 24;
			array2[26] = 149;
			array2[26] = 225;
			array2[26] = 132;
			array2[26] = 166;
			array2[27] = 161;
			array2[27] = 115;
			array2[27] = 28;
			array2[28] = 167;
			array2[28] = 90;
			array2[28] = 118;
			array2[28] = 118;
			array2[28] = 3;
			array2[29] = 90;
			array2[29] = 155;
			array2[29] = 94;
			array2[29] = 123;
			array2[29] = 88;
			array2[29] = 65;
			array2[30] = 121;
			array2[30] = 45;
			array2[30] = 84;
			array2[30] = 24;
			array2[30] = 158;
			array2[30] = 65;
			array2[31] = 132;
			array2[31] = 114;
			array2[31] = 137;
			array2[31] = 25;
			byte[] rgbKey = array2;
			byte[] array3 = new byte[16];
			array3[0] = 123;
			array3[0] = 106;
			array3[0] = 244;
			array3[1] = 106;
			array3[1] = 202;
			array3[1] = 114;
			array3[1] = 235;
			array3[2] = 101;
			array3[2] = 69;
			array3[2] = 158;
			array3[2] = 102;
			array3[2] = 178;
			array3[3] = 154;
			array3[3] = 150;
			array3[3] = 112;
			array3[3] = 104;
			array3[3] = 231;
			array3[4] = 138;
			array3[4] = 24;
			array3[4] = 133;
			array3[4] = 181;
			array3[5] = 86;
			array3[5] = 118;
			array3[5] = 197;
			array3[6] = 140;
			array3[6] = 107;
			array3[6] = 78;
			array3[6] = 166;
			array3[6] = 182;
			array3[6] = 16;
			array3[7] = 149;
			array3[7] = 152;
			array3[7] = 196;
			array3[7] = 74;
			array3[7] = 140;
			array3[7] = 22;
			array3[8] = 185;
			array3[8] = 162;
			array3[8] = 69;
			array3[9] = 159;
			array3[9] = 165;
			array3[9] = 154;
			array3[9] = 94;
			array3[9] = 158;
			array3[10] = 132;
			array3[10] = 169;
			array3[10] = 75;
			array3[11] = 133;
			array3[11] = 96;
			array3[11] = 114;
			array3[11] = 131;
			array3[11] = 133;
			array3[11] = 170;
			array3[12] = 111;
			array3[12] = 122;
			array3[12] = 143;
			array3[12] = 122;
			array3[12] = 103;
			array3[13] = 156;
			array3[13] = 160;
			array3[13] = 135;
			array3[14] = 124;
			array3[14] = 96;
			array3[14] = 143;
			array3[14] = 74;
			array3[14] = 205;
			array3[14] = 3;
			array3[15] = 16;
			array3[15] = 81;
			array3[15] = 159;
			array3[15] = 240;
			byte[] rgbIV = array3;
			SymmetricAlgorithm symmetricAlgorithm = Class5.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(rgbKey, rgbIV);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			byte_2 = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			binaryReader.Close();
			@class.method_15(byte_2);
			try
			{
				if (@class.string_14.Length > 0)
				{
					this.type_0 = base.GetType().Assembly.GetType(@class.string_14, false);
					if (this.type_0 == null)
					{
						this.type_0 = typeof(rFohpatkdxsVcxLfJKhM7);
					}
				}
				else
				{
					this.type_0 = typeof(rFohpatkdxsVcxLfJKhM7);
				}
			}
			catch
			{
			}
			if (Class30.class29_0 != null && Class30.class29_0.class18_0 != null && Class30.class29_0.class18_0.method_8() != null)
			{
				Class30.class29_0.class18_0.method_8().Clear();
			}
			Class30.class29_0 = @class;
			Class30.int_0 = @class.int_3;
			Class30.int_1 = @class.int_4;
			Class30.int_2 = @class.int_1;
			if (Class30.class29_0.bool_5)
			{
				try
				{
					if (!flag)
					{
						Application.EnableVisualStyles();
						Application.DoEvents();
					}
				}
				catch
				{
				}
			}
			if (@class.bool_0)
			{
				try
				{
					if (!flag)
					{
						lSfgApatkdxsVcGcrktoFd.Show();
						lSfgApatkdxsVcGcrktoFd.Invalidate();
						lSfgApatkdxsVcGcrktoFd.progressBar1.Invalidate();
						Application.DoEvents();
					}
				}
				catch
				{
				}
			}
			try
			{
				if (!flag && File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\lkasedfjsedfuwemnbsfdcgwaeiu"))
				{
					MessageBox.Show(Encoding.Unicode.GetString(Convert.FromBase64String(@class.string_9)));
				}
			}
			catch
			{
			}
			if (!@class.bool_62 && !flag)
			{
				try
				{
					if (@class.bool_0)
					{
						try
						{
							if (!flag)
							{
								lSfgApatkdxsVcGcrktoFd.Hide();
							}
						}
						catch
						{
						}
					}
					rFohpatkdxsVcxLfJKhM7 rFohpatkdxsVcxLfJKhM = new rFohpatkdxsVcxLfJKhM7();
					rFohpatkdxsVcxLfJKhM.ShowDialog();
					if (@class.bool_0)
					{
						try
						{
							if (!flag)
							{
								lSfgApatkdxsVcGcrktoFd.Show();
								lSfgApatkdxsVcGcrktoFd.Invalidate();
								lSfgApatkdxsVcGcrktoFd.progressBar1.Invalidate();
								Application.DoEvents();
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
			}
			bool flag4 = false;
			flag3 = false;
			if (!@class.bool_51 && !@class.bool_43 && !@class.bool_49 && @class.bool_37 && !@class.bool_35)
			{
				flag3 = true;
			}
			else
			{
				flag4 = true;
			}
			if (flag4)
			{
				try
				{
					if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Isolated Storage"))
					{
						Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Isolated Storage");
					}
				}
				catch
				{
				}
				if (flag)
				{
					if (!flag || byte_1.Length != 1)
					{
						goto IL_F9D;
					}
				}
				try
				{
					flag3 = this.method_9(@class);
				}
				catch
				{
				}
				ArrayList arrayList = new ArrayList();
				try
				{
					if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory))
					{
						arrayList.Add(AppDomain.CurrentDomain.BaseDirectory);
					}
				}
				catch
				{
				}
				try
				{
					if (Directory.Exists(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath))
					{
						arrayList.Add(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);
					}
				}
				catch
				{
				}
				try
				{
					if (AppDomain.CurrentDomain.GetData("DataDirectory") != null)
					{
						string text = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
						if (Directory.Exists(text))
						{
							arrayList.Add(text + "\\");
						}
					}
				}
				catch
				{
				}
				try
				{
					if (AppDomain.CurrentDomain.GetData("PRIVATE_BINPATH") != null)
					{
						string text2 = AppDomain.CurrentDomain.GetData("PRIVATE_BINPATH").ToString();
						if (Directory.Exists(text2))
						{
							arrayList.Add(text2 + "\\");
						}
					}
				}
				catch
				{
				}
				for (int i = 0; i < arrayList.Count; i++)
				{
					try
					{
						if (!flag3)
						{
							flag3 = this.method_8(@class, (string)arrayList[i]);
						}
					}
					catch
					{
					}
				}
				try
				{
					if (!flag3)
					{
						flag3 = this.method_8(@class, Path.GetDirectoryName(executablePath));
					}
				}
				catch
				{
				}
				try
				{
					if (!flag3)
					{
						flag3 = this.method_8(@class, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
					}
				}
				catch
				{
				}
				try
				{
					if (!flag3 && Class9.yPyVSobdLtMrO(typeof(Class30).Assembly).Length > 0)
					{
						flag3 = this.method_8(@class, Path.GetDirectoryName(Class9.yPyVSobdLtMrO(typeof(Class30).Assembly)));
					}
				}
				catch
				{
				}
				try
				{
					if (!flag3)
					{
						flag3 = this.method_8(@class, Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.System)));
					}
				}
				catch
				{
				}
				try
				{
					if (!flag3)
					{
						flag3 = this.method_8(@class, Environment.GetFolderPath(Environment.SpecialFolder.System));
					}
				}
				catch
				{
				}
			}
			IL_F9D:
			if (flag && byte_1.Length > 1)
			{
				flag4 = true;
				flag3 = false;
				if (!(flag3 = this.method_7(@class, byte_1)))
				{
					return new Class30.Class33(this, "");
				}
				if (this.timer_0 != null)
				{
					try
					{
						this.timer_0.Dispose();
					}
					catch
					{
					}
					this.timer_0 = null;
				}
				if (this.timer_1 != null)
				{
					try
					{
						this.timer_1.Dispose();
					}
					catch
					{
					}
					this.timer_1 = null;
				}
			}
			Class10.Class19.smethod_4();
			if (flag4 && flag3)
			{
				try
				{
					string str = "Software\\CLASSES\\CLSID\\";
					string str2 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
					RegistryKey localMachine = Registry.LocalMachine;
					RegistryKey registryKey = localMachine.OpenSubKey(str + str2 + Class10.smethod_33(@class.class18_0.method_4()), false);
					if (registryKey != null)
					{
						flag3 = false;
					}
				}
				catch
				{
				}
				try
				{
					if (flag3)
					{
						string str3 = "Software\\CLASSES\\CLSID\\";
						string str4 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
						RegistryKey currentUser = Registry.CurrentUser;
						RegistryKey registryKey2 = currentUser.OpenSubKey(str3 + str4 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
						if (registryKey2 != null)
						{
							flag3 = false;
						}
					}
				}
				catch
				{
				}
				try
				{
					if (flag3)
					{
						string str5 = "Software\\CLASSES\\CID\\";
						string str6 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
						RegistryKey currentUser2 = Registry.CurrentUser;
						RegistryKey registryKey3 = currentUser2.OpenSubKey(str5 + str6 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
						if (registryKey3 != null)
						{
							flag3 = false;
						}
					}
				}
				catch
				{
				}
				try
				{
					string str7 = Class10.Class19.smethod_7(Class10.smethod_0("{Y3358E75-826A3-31A5-2C1E-14A484D53571}" + Class10.smethod_33(@class.class18_0.method_4())));
					if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Isolated Storage\\" + str7))
					{
						flag3 = false;
					}
				}
				catch
				{
				}
			}
			bool flag5 = true;
			bool flag6 = true;
			bool flag7 = true;
			num5 = 0;
			num = 0;
			num2 = 0;
			bool flag8 = false;
			bool flag9 = false;
			if (flag4 && flag3)
			{
				Class30.int_4 = int.MaxValue;
				string s = Convert.ToBase64String(@class.class18_0.method_4());
				if (!this.class29_1.bool_57)
				{
					@class.class18_0.method_5(this.class29_1.byte_0);
				}
				if (this.class29_1.bool_61)
				{
					num5 = this.class29_1.int_7;
					if (this.class29_1.enum9_1 == Enum9.Trial_Days)
					{
						try
						{
							string text3 = "Software\\CLASSES\\CID\\";
							string str8 = "Software\\CLASSES\\CLSID\\";
							RegistryKey currentUser3 = Registry.CurrentUser;
							RegistryKey registryKey4 = null;
							try
							{
								registryKey4 = currentUser3.OpenSubKey(text3, false);
							}
							catch
							{
								registryKey4 = null;
							}
							Class30.Class31 class2 = new Class30.Class31();
							int num6 = class2.method_3(24);
							string[] array4 = new string[0];
							int num7 = 0;
							if (registryKey4 != null)
							{
								array4 = registryKey4.GetSubKeyNames();
								num7 = array4.Length;
							}
							int num8 = 25;
							if (registryKey4 == null)
							{
								num6 = 0;
								num8 = 1;
							}
							if (num7 < 3)
							{
								num6 = 0;
								num8 = 1;
							}
							for (int j = 0; j < num8; j++)
							{
								if (j == num6)
								{
									if (Class30.string_0.Length == 0)
									{
										Class30.string_0 = Class10.Class11.smethod_11();
									}
									string str9 = "{B1159E65-821C3-21C5-CE21-34A484D54444}\\";
									RegistryKey registryKey5 = Registry.CurrentUser;
									RegistryKey registryKey6 = registryKey5.OpenSubKey(text3 + str9 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
									if (registryKey6 == null)
									{
										RegistryKey registryKey7 = registryKey5.OpenSubKey(str8 + str9 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
										if (registryKey7 != null)
										{
											this.method_0(registryKey7, text3 + str9 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											registryKey6 = registryKey5.OpenSubKey(text3 + str9 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
										}
									}
									if (registryKey6 != null)
									{
										goto IL_1960;
									}
									if (File.Exists(string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\Isolated Storage\\",
										Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
										"\\",
										Class10.Class19.smethod_7(str9)
									})))
									{
										this.method_3(string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\Isolated Storage\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
											"\\",
											Class10.Class19.smethod_7(str9)
										}), text3 + str9 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										goto IL_1960;
									}
									try
									{
										registryKey5 = Registry.LocalMachine;
										registryKey6 = registryKey5.OpenSubKey(text3 + str9 + Class10.smethod_33(@class.class18_0.method_4()), false);
										if (registryKey6 != null)
										{
											this.method_0(registryKey6, text3 + str9 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										}
										else
										{
											str9 = "{" + Class10.Class19.smethod_7(Class10.smethod_0(Class30.string_0)) + "}\\";
											registryKey5 = Registry.CurrentUser;
											registryKey6 = registryKey5.OpenSubKey(text3 + str9 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
											if (registryKey6 != null)
											{
												this.method_0(registryKey6, text3 + "{B1159E65-821C3-21C5-CE21-34A484D54444}\\" + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											}
										}
										goto IL_1960;
									}
									catch
									{
										str9 = "{" + Class10.Class19.smethod_7(Class10.smethod_0(Class30.string_0)) + "}\\";
										registryKey5 = Registry.CurrentUser;
										registryKey6 = registryKey5.OpenSubKey(text3 + str9 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
										if (registryKey6 != null)
										{
											this.method_0(registryKey6, text3 + "{B1159E65-821C3-21C5-CE21-34A484D54444}\\" + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										}
										goto IL_1960;
									}
									goto IL_155B;
									IL_15D6:
									RegistryKey registryKey8;
									string str10;
									if (registryKey8 != null)
									{
										try
										{
											if (registryKey8.GetValue("3") == null)
											{
												registryKey8.SetValue("3", Class10.smethod_37("10000000"));
											}
											else if (registryKey8.GetValue("3").ToString().Length == 0)
											{
												registryKey8.SetValue("3", Class10.smethod_37("10000000"));
											}
										}
										catch
										{
										}
										string string_ = (string)registryKey8.GetValue("1");
										DateTime value = Class10.smethod_31(string_);
										int num9 = Convert.ToInt32(Class10.smethod_38((string)registryKey8.GetValue("3"))) - 10000000;
										decimal num10 = Math.Abs(dateTime.Subtract(value).Days);
										num = (int)num10 + num9;
										if (num10 > 0m)
										{
											Class10.smethod_30(dateTime);
											Class10.smethod_37((10000000 + num).ToString());
											registryKey8.SetValue("1", Class10.smethod_30(dateTime));
											registryKey8.SetValue("3", Class10.smethod_37((10000000 + num).ToString()));
										}
										num2 = num5 - num;
										num++;
										if (num > num5)
										{
											flag5 = false;
											num2 = 0;
										}
										Class30.int_4 = num2;
										this.method_0(registryKey8, string.Concat(new string[]
										{
											text3,
											"{",
											Class10.Class19.smethod_7(Class10.smethod_0(Class30.string_0)),
											"}\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4()))
										}));
										this.method_2(registryKey8, string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\Isolated Storage\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
											"\\",
											Class10.Class19.smethod_7(str10)
										}));
										goto IL_1955;
									}
									RegistryKey currentUser4 = Registry.CurrentUser;
									registryKey8 = currentUser4.CreateSubKey(text3 + str10 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
									Class10.smethod_30(dateTime);
									registryKey8.SetValue("0", Class10.smethod_30(dateTime));
									registryKey8.SetValue("1", Class10.smethod_30(dateTime));
									registryKey8.SetValue("3", Class10.smethod_37("10000000"));
									num = 1;
									num2 = num5;
									Class30.int_4 = num2;
									this.method_0(registryKey8, string.Concat(new string[]
									{
										text3,
										"{",
										Class10.Class19.smethod_7(Class10.smethod_0(Class30.string_0)),
										"}\\",
										Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4()))
									}));
									this.method_2(registryKey8, string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\Isolated Storage\\",
										Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
										"\\",
										Class10.Class19.smethod_7(str10)
									}));
									goto IL_1955;
									IL_155B:
									RegistryKey registryKey9 = currentUser4.OpenSubKey(str8 + str10 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
									if (registryKey9 != null)
									{
										this.method_0(registryKey9, text3 + str10 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										registryKey8 = currentUser4.OpenSubKey(text3 + str10 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), true);
										goto IL_15D6;
									}
									goto IL_15D6;
									IL_1960:
									str10 = "{B1159E65-821C3-21C5-CE21-34A484D54444}\\";
									currentUser4 = Registry.CurrentUser;
									registryKey8 = currentUser4.OpenSubKey(text3 + str10 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), true);
									if (registryKey8 == null)
									{
										goto IL_155B;
									}
									goto IL_15D6;
								}
								else
								{
									try
									{
										int num11 = class2.method_3(num7 - 1);
										RegistryKey registryKey10 = registryKey4.OpenSubKey(array4[num11]);
										if (registryKey10.ValueCount > 0)
										{
											string[] valueNames = registryKey10.GetValueNames();
											if (valueNames.Length > 1)
											{
												registryKey10.GetValue(valueNames[0]);
											}
										}
										registryKey10.Close();
									}
									catch
									{
									}
								}
								IL_1955:;
							}
						}
						catch
						{
						}
					}
				}
				if (this.class29_1.bool_60)
				{
					try
					{
						string text4 = "Software\\CLASSES\\CID\\";
						string str11 = "Software\\CLASSES\\CLSID\\";
						RegistryKey currentUser5 = Registry.CurrentUser;
						RegistryKey registryKey11 = null;
						try
						{
							registryKey11 = currentUser5.OpenSubKey(text4, false);
						}
						catch
						{
							registryKey11 = null;
						}
						Class30.Class31 class3 = new Class30.Class31();
						int num12 = class3.method_3(24);
						string[] array5 = new string[0];
						int num13 = 0;
						if (registryKey11 != null)
						{
							array5 = registryKey11.GetSubKeyNames();
							num13 = array5.Length;
						}
						int num14 = 25;
						if (registryKey11 == null)
						{
							num12 = 0;
							num14 = 1;
						}
						if (num13 < 3)
						{
							num12 = 0;
							num14 = 1;
						}
						for (int k = 0; k < num14; k++)
						{
							if (k == num12)
							{
								string str12 = "{A3358E75-826A3-31A5-2C1E-14A484D53571}\\";
								RegistryKey registryKey12 = Registry.CurrentUser;
								RegistryKey registryKey13 = registryKey12.OpenSubKey(text4 + str12 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
								if (registryKey13 == null)
								{
									RegistryKey registryKey14 = registryKey12.OpenSubKey(str11 + str12 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
									if (registryKey14 != null)
									{
										this.method_0(registryKey14, text4 + str12 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										registryKey13 = registryKey12.OpenSubKey(text4 + str12 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
									}
								}
								if (registryKey13 != null)
								{
									goto IL_1FBF;
								}
								if (File.Exists(string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\Isolated Storage\\",
									Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
									"\\",
									Class10.Class19.smethod_7(str12)
								})))
								{
									this.method_3(string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\Isolated Storage\\",
										Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
										"\\",
										Class10.Class19.smethod_7(str12)
									}), text4 + str12 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
									goto IL_1FBF;
								}
								try
								{
									registryKey12 = Registry.LocalMachine;
									registryKey13 = registryKey12.OpenSubKey(text4 + str12 + Class10.smethod_33(@class.class18_0.method_4()), false);
									if (registryKey13 != null)
									{
										this.method_0(registryKey13, text4 + str12 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
									}
									goto IL_1FBF;
								}
								catch
								{
									goto IL_1FBF;
								}
								goto IL_1C2D;
								IL_1CA8:
								RegistryKey registryKey15;
								RegistryKey currentUser6;
								string str13;
								if (registryKey15 == null)
								{
									currentUser6 = Registry.CurrentUser;
									registryKey15 = currentUser6.CreateSubKey(text4 + str13 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
									registryKey15.SetValue("2", Class10.smethod_30(dateTime));
									DateTime now = DateTime.Now;
									if (DateTime.Compare(now, this.class29_1.dateTime_1) >= 0)
									{
										flag6 = false;
										num3 = 0;
										if (Class30.int_4 == 2147483647)
										{
											Class30.int_4 = 0;
										}
										else if (!@class.bool_38)
										{
											Class30.int_4 = 0;
										}
									}
									else
									{
										TimeSpan timeSpan = this.class29_1.dateTime_1.Subtract(DateTime.Now);
										num3 = timeSpan.Days;
										if (Class30.int_4 == 2147483647)
										{
											Class30.int_4 = timeSpan.Days;
										}
										else if (@class.bool_38)
										{
											if (timeSpan.Days > Class30.int_4)
											{
												Class30.int_4 = timeSpan.Days;
											}
										}
										else if (timeSpan.Days < Class30.int_4)
										{
											Class30.int_4 = timeSpan.Days;
										}
									}
									this.method_2(registryKey15, string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\Isolated Storage\\",
										Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
										"\\",
										Class10.Class19.smethod_7(str13)
									}));
									goto IL_1FB4;
								}
								string string_2 = (string)registryKey15.GetValue("2");
								DateTime dateTime2 = Class10.smethod_31(string_2);
								if (DateTime.Compare(dateTime, dateTime2) >= 0)
								{
									registryKey15.SetValue("2", Class10.smethod_30(dateTime));
									dateTime2 = dateTime;
								}
								if (DateTime.Compare(dateTime2, this.class29_1.dateTime_1) >= 0)
								{
									flag6 = false;
									num3 = 0;
									if (Class30.int_4 == 2147483647)
									{
										Class30.int_4 = 0;
									}
									else if (!@class.bool_38)
									{
										Class30.int_4 = 0;
									}
								}
								else
								{
									TimeSpan timeSpan2 = this.class29_1.dateTime_1.Subtract(DateTime.Now);
									num3 = timeSpan2.Days;
									if (Class30.int_4 == 2147483647)
									{
										Class30.int_4 = timeSpan2.Days;
									}
									else if (@class.bool_38)
									{
										if (timeSpan2.Days > Class30.int_4)
										{
											Class30.int_4 = timeSpan2.Days;
										}
									}
									else if (timeSpan2.Days < Class30.int_4)
									{
										Class30.int_4 = timeSpan2.Days;
									}
								}
								this.method_2(registryKey15, string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\Isolated Storage\\",
									Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
									"\\",
									Class10.Class19.smethod_7(str13)
								}));
								goto IL_1FB4;
								IL_1C2D:
								RegistryKey registryKey16 = currentUser6.OpenSubKey(str11 + str13 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
								if (registryKey16 != null)
								{
									this.method_0(registryKey16, text4 + str13 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
									registryKey15 = currentUser6.OpenSubKey(text4 + str13 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), true);
									goto IL_1CA8;
								}
								goto IL_1CA8;
								IL_1FBF:
								str13 = "{A3358E75-826A3-31A5-2C1E-14A484D53571}\\";
								currentUser6 = Registry.CurrentUser;
								registryKey15 = currentUser6.OpenSubKey(text4 + str13 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), true);
								if (registryKey15 == null)
								{
									goto IL_1C2D;
								}
								goto IL_1CA8;
							}
							else
							{
								try
								{
									int num15 = class3.method_3(num13 - 1);
									RegistryKey registryKey17 = registryKey11.OpenSubKey(array5[num15]);
									if (registryKey17.ValueCount > 0)
									{
										string[] valueNames2 = registryKey17.GetValueNames();
										if (valueNames2.Length > 1)
										{
											registryKey17.GetValue(valueNames2[0]);
										}
									}
									registryKey17.Close();
								}
								catch
								{
								}
							}
							IL_1FB4:;
						}
					}
					catch
					{
					}
					if ((!flag || (flag && !flag2)) && this.class29_1.enum9_1 == Enum9.Trial_Days)
					{
						try
						{
							this.timer_1.Dispose();
						}
						catch
						{
						}
						try
						{
							Class30.dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
							Class30.dateTime_1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
							this.timer_1 = new System.Threading.Timer(new TimerCallback(this.method_6), null, 60000, 60000);
						}
						catch
						{
						}
					}
				}
				if (this.class29_1.bool_56)
				{
					try
					{
						string text5 = "Software\\CLASSES\\CID\\";
						string str14 = "Software\\CLASSES\\CLSID\\";
						RegistryKey currentUser7 = Registry.CurrentUser;
						RegistryKey registryKey18 = null;
						try
						{
							registryKey18 = currentUser7.OpenSubKey(text5, false);
						}
						catch
						{
							registryKey18 = null;
						}
						Class30.Class31 class4 = new Class30.Class31();
						int num16 = class4.method_3(24);
						string[] array6 = new string[0];
						int num17 = 0;
						if (registryKey18 != null)
						{
							array6 = registryKey18.GetSubKeyNames();
							num17 = array6.Length;
						}
						int num18 = 25;
						if (registryKey18 == null)
						{
							num16 = 0;
							num18 = 1;
						}
						if (num17 < 3)
						{
							num16 = 0;
							num18 = 1;
						}
						for (int l = 0; l < num18; l++)
						{
							if (l == num16)
							{
								string str15 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
								RegistryKey registryKey19 = Registry.CurrentUser;
								if (registryKey19.OpenSubKey(text5 + str15 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false) != null)
								{
									goto IL_2574;
								}
								if (File.Exists(string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\Isolated Storage\\",
									Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
									"\\",
									Class10.Class19.smethod_7(str15)
								})))
								{
									this.method_3(string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\Isolated Storage\\",
										Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
										"\\",
										Class10.Class19.smethod_7(str15)
									}), text5 + str15 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
									goto IL_2574;
								}
								try
								{
									registryKey19 = Registry.LocalMachine;
									RegistryKey registryKey20 = registryKey19.OpenSubKey(text5 + str15 + Class10.smethod_33(@class.class18_0.method_4()), false);
									if (registryKey20 != null)
									{
										this.method_0(registryKey20, text5 + str15 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
									}
									goto IL_2574;
								}
								catch
								{
									goto IL_2574;
								}
								goto IL_22CE;
								IL_22F9:
								RegistryKey registryKey21;
								RegistryKey currentUser8;
								string str16;
								if (registryKey21 == null)
								{
									currentUser8 = Registry.CurrentUser;
									registryKey21 = currentUser8.CreateSubKey(text5 + str16 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
									registryKey21.SetValue("2", Class10.smethod_37(Class30.int_3.ToString()));
									flag8 = true;
									if (Class30.int_3 > this.class29_1.int_5)
									{
										flag7 = false;
										Class30.int_3 = this.class29_1.int_5 + 1;
										num4 = 0;
									}
									else
									{
										num4 = this.class29_1.int_5 - Class30.int_3;
									}
									this.method_2(registryKey21, string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\Isolated Storage\\",
										Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
										"\\",
										Class10.Class19.smethod_7(str16)
									}));
									goto IL_2569;
								}
								string string_3 = (string)registryKey21.GetValue("2");
								Class30.int_3 = Convert.ToInt32(Class10.smethod_38(string_3));
								bool flag10;
								if (flag10)
								{
									currentUser8 = Registry.CurrentUser;
									registryKey21 = currentUser8.CreateSubKey(text5 + str16 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
									registryKey21.SetValue("2", Class10.smethod_37(Class30.int_3.ToString()));
								}
								flag8 = true;
								Class30.int_3++;
								registryKey21.SetValue("2", Class10.smethod_37(Class30.int_3.ToString()));
								if (Class30.int_3 > this.class29_1.int_5)
								{
									flag7 = false;
									Class30.int_3 = this.class29_1.int_5 + 1;
									num4 = 0;
								}
								else
								{
									num4 = this.class29_1.int_5 - Class30.int_3;
								}
								this.method_2(registryKey21, string.Concat(new string[]
								{
									Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
									"\\Isolated Storage\\",
									Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
									"\\",
									Class10.Class19.smethod_7(str16)
								}));
								goto IL_2569;
								IL_22CE:
								flag10 = true;
								registryKey21 = currentUser8.OpenSubKey(str14 + str16 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
								goto IL_22F9;
								IL_2574:
								str16 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
								currentUser8 = Registry.CurrentUser;
								registryKey21 = currentUser8.OpenSubKey(text5 + str16 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), true);
								flag10 = false;
								if (registryKey21 == null)
								{
									goto IL_22CE;
								}
								goto IL_22F9;
							}
							else
							{
								try
								{
									int num19 = class4.method_3(num17 - 1);
									RegistryKey registryKey22 = registryKey18.OpenSubKey(array6[num19]);
									if (registryKey22.ValueCount > 0)
									{
										string[] valueNames3 = registryKey22.GetValueNames();
										if (valueNames3.Length > 1)
										{
											registryKey22.GetValue(valueNames3[0]);
										}
									}
									registryKey22.Close();
								}
								catch
								{
								}
							}
							IL_2569:;
						}
					}
					catch
					{
					}
				}
				if (Class30.class29_0.bool_38)
				{
					bool flag11 = true;
					if (this.class29_1.bool_61)
					{
						flag11 = false;
					}
					if (this.class29_1.bool_60)
					{
						flag11 = false;
					}
					if (this.class29_1.bool_56)
					{
						flag11 = false;
					}
					if (this.class29_1.bool_61 && flag5)
					{
						flag11 = true;
					}
					if (this.class29_1.bool_60 && flag6)
					{
						flag11 = true;
					}
					if (this.class29_1.bool_56 && flag7)
					{
						flag11 = true;
					}
					if (!flag11)
					{
						flag3 = false;
						flag9 = true;
					}
				}
				else
				{
					bool flag12 = true;
					if (this.class29_1.bool_61 && !flag5)
					{
						flag12 = false;
					}
					if (this.class29_1.bool_60 && !flag6)
					{
						flag12 = false;
					}
					if (this.class29_1.bool_56 && !flag7)
					{
						flag12 = false;
					}
					if (!flag12)
					{
						flag3 = false;
						flag9 = true;
					}
				}
				@class.class18_0.method_5(Convert.FromBase64String(s));
				if (flag3 && this.class29_1.bool_61 && (!flag || (flag && !flag2)))
				{
					if (this.class29_1.enum9_1 == Enum9.Runtime_Minutes)
					{
						try
						{
							this.timer_0.Dispose();
						}
						catch
						{
						}
						this.timer_0 = new System.Threading.Timer(new TimerCallback(this.method_5), null, num5 * 60000, num5 * 60000);
					}
					if (this.class29_1.enum9_1 == Enum9.Trial_Days)
					{
						try
						{
							this.timer_1.Dispose();
						}
						catch
						{
						}
						try
						{
							Class30.dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
							Class30.dateTime_1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
							this.timer_1 = new System.Threading.Timer(new TimerCallback(this.method_6), null, 60000, 60000);
						}
						catch
						{
						}
					}
				}
			}
			bool flag13 = true;
			if (flag4)
			{
				if ((flag3 || (flag9 && !@class.bool_37)) && this.class29_1 != null)
				{
					@class.bool_48 = this.class29_1.bool_48;
					@class.bool_45 = this.class29_1.bool_45;
					@class.bool_46 = this.class29_1.bool_46;
					@class.bool_47 = this.class29_1.bool_47;
					@class.bool_44 = this.class29_1.bool_59;
					@class.bool_59 = this.class29_1.bool_59;
					@class.string_21 = this.class29_1.string_21;
					@class.int_3 = this.class29_1.int_7;
					@class.int_7 = this.class29_1.int_7;
					num5 = this.class29_1.int_7;
					Class30.int_0 = this.class29_1.int_7;
					@class.bool_51 = this.class29_1.bool_61;
					@class.bool_61 = this.class29_1.bool_61;
					@class.enum9_0 = this.class29_1.enum9_1;
					@class.enum9_1 = this.class29_1.enum9_1;
					@class.bool_43 = this.class29_1.bool_60;
					@class.bool_60 = this.class29_1.bool_60;
					@class.dateTime_0 = this.class29_1.dateTime_1;
					@class.dateTime_1 = this.class29_1.dateTime_1;
					@class.bool_49 = this.class29_1.bool_56;
					@class.bool_56 = this.class29_1.bool_56;
					@class.int_5 = this.class29_1.int_5;
					@class.int_4 = this.class29_1.int_5;
					Class30.int_1 = this.class29_1.int_5;
					@class.bool_50 = this.class29_1.bool_58;
					@class.bool_58 = this.class29_1.bool_58;
					@class.int_6 = this.class29_1.int_6;
					@class.int_1 = this.class29_1.int_6;
					Class30.int_2 = this.class29_1.int_6;
				}
				if (!flag3)
				{
					flag5 = true;
					flag6 = true;
					flag7 = true;
					num5 = 0;
					num = 0;
					num2 = 0;
					Class30.int_3 = 1;
					Class30.int_4 = int.MaxValue;
					if (@class.bool_51)
					{
						num5 = @class.int_3;
						if (@class.enum9_0 == Enum9.Trial_Days)
						{
							try
							{
								string text6 = "Software\\CLASSES\\CID\\";
								string str17 = "Software\\CLASSES\\CLSID\\";
								RegistryKey currentUser9 = Registry.CurrentUser;
								RegistryKey registryKey23 = null;
								try
								{
									registryKey23 = currentUser9.OpenSubKey(text6, false);
								}
								catch
								{
									registryKey23 = null;
								}
								Class30.Class31 class5 = new Class30.Class31();
								int num20 = class5.method_3(24);
								string[] array7 = new string[0];
								int num21 = 0;
								if (registryKey23 != null)
								{
									array7 = registryKey23.GetSubKeyNames();
									num21 = array7.Length;
								}
								int num22 = 25;
								if (registryKey23 == null)
								{
									num20 = 0;
									num22 = 1;
								}
								if (num21 < 3)
								{
									num20 = 0;
									num22 = 1;
								}
								for (int m = 0; m < num22; m++)
								{
									if (m == num20)
									{
										if (Class30.string_0.Length == 0)
										{
											Class30.string_0 = Class10.Class11.smethod_11();
										}
										string str18 = "{B1159E65-821C3-21C5-CE21-34A484D54444}\\";
										RegistryKey registryKey24 = Registry.CurrentUser;
										RegistryKey registryKey25 = registryKey24.OpenSubKey(text6 + str18 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
										if (registryKey25 == null)
										{
											RegistryKey registryKey26 = registryKey24.OpenSubKey(str17 + str18 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
											if (registryKey26 != null)
											{
												this.method_0(registryKey26, text6 + str18 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
												registryKey25 = registryKey24.OpenSubKey(text6 + str18 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
											}
										}
										if (registryKey25 != null)
										{
											goto IL_31A1;
										}
										if (File.Exists(string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\Isolated Storage\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
											"\\",
											Class10.Class19.smethod_7(str18)
										})))
										{
											this.method_3(string.Concat(new string[]
											{
												Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
												"\\Isolated Storage\\",
												Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
												"\\",
												Class10.Class19.smethod_7(str18)
											}), text6 + str18 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											goto IL_31A1;
										}
										try
										{
											registryKey24 = Registry.LocalMachine;
											registryKey25 = registryKey24.OpenSubKey(text6 + str18 + Class10.smethod_33(@class.class18_0.method_4()), false);
											if (registryKey25 != null)
											{
												this.method_0(registryKey25, text6 + str18 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											}
											else
											{
												str18 = "{" + Class10.Class19.smethod_7(Class10.smethod_0(Class30.string_0)) + "}\\";
												registryKey24 = Registry.CurrentUser;
												registryKey25 = registryKey24.OpenSubKey(text6 + str18 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
												if (registryKey25 != null)
												{
													this.method_0(registryKey25, text6 + "{B1159E65-821C3-21C5-CE21-34A484D54444}\\" + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
												}
											}
											goto IL_31A1;
										}
										catch
										{
											str18 = "{" + Class10.Class19.smethod_7(Class10.smethod_0(Class30.string_0)) + "}\\";
											registryKey24 = Registry.CurrentUser;
											registryKey25 = registryKey24.OpenSubKey(text6 + str18 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
											if (registryKey25 != null)
											{
												this.method_0(registryKey25, text6 + "{B1159E65-821C3-21C5-CE21-34A484D54444}\\" + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											}
											goto IL_31A1;
										}
										goto IL_2D9C;
										IL_2E17:
										RegistryKey registryKey27;
										string str19;
										if (registryKey27 != null)
										{
											try
											{
												if (registryKey27.GetValue("3") == null)
												{
													registryKey27.SetValue("3", Class10.smethod_37("10000000"));
												}
												else if (registryKey27.GetValue("3").ToString().Length == 0)
												{
													registryKey27.SetValue("3", Class10.smethod_37("10000000"));
												}
											}
											catch
											{
											}
											string string_4 = (string)registryKey27.GetValue("1");
											DateTime value2 = Class10.smethod_31(string_4);
											int num23 = Convert.ToInt32(Class10.smethod_38((string)registryKey27.GetValue("3"))) - 10000000;
											decimal num24 = Math.Abs(dateTime.Subtract(value2).Days);
											num = (int)num24 + num23;
											if (num24 > 0m)
											{
												Class10.smethod_30(dateTime);
												Class10.smethod_37((10000000 + num).ToString());
												registryKey27.SetValue("1", Class10.smethod_30(dateTime));
												registryKey27.SetValue("3", Class10.smethod_37((10000000 + num).ToString()));
											}
											num2 = num5 - num;
											num++;
											if (num > num5)
											{
												flag5 = false;
												num2 = 0;
											}
											Class30.int_4 = num2;
											this.method_0(registryKey27, string.Concat(new string[]
											{
												text6,
												"{",
												Class10.Class19.smethod_7(Class10.smethod_0(Class30.string_0)),
												"}\\",
												Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4()))
											}));
											this.method_2(registryKey27, string.Concat(new string[]
											{
												Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
												"\\Isolated Storage\\",
												Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
												"\\",
												Class10.Class19.smethod_7(str19)
											}));
											goto IL_3196;
										}
										RegistryKey currentUser10 = Registry.CurrentUser;
										registryKey27 = currentUser10.CreateSubKey(text6 + str19 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										Class10.smethod_30(dateTime);
										registryKey27.SetValue("0", Class10.smethod_30(dateTime));
										registryKey27.SetValue("1", Class10.smethod_30(dateTime));
										registryKey27.SetValue("3", Class10.smethod_37("10000000"));
										num = 1;
										num2 = num5;
										Class30.int_4 = num2;
										this.method_0(registryKey27, string.Concat(new string[]
										{
											text6,
											"{",
											Class10.Class19.smethod_7(Class10.smethod_0(Class30.string_0)),
											"}\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4()))
										}));
										this.method_2(registryKey27, string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\Isolated Storage\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
											"\\",
											Class10.Class19.smethod_7(str19)
										}));
										goto IL_3196;
										IL_2D9C:
										RegistryKey registryKey28 = currentUser10.OpenSubKey(str17 + str19 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
										if (registryKey28 != null)
										{
											this.method_0(registryKey28, text6 + str19 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											registryKey27 = currentUser10.OpenSubKey(text6 + str19 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), true);
											goto IL_2E17;
										}
										goto IL_2E17;
										IL_31A1:
										str19 = "{B1159E65-821C3-21C5-CE21-34A484D54444}\\";
										currentUser10 = Registry.CurrentUser;
										registryKey27 = currentUser10.OpenSubKey(text6 + str19 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), true);
										if (registryKey27 == null)
										{
											goto IL_2D9C;
										}
										goto IL_2E17;
									}
									else
									{
										try
										{
											int num25 = class5.method_3(num21 - 1);
											RegistryKey registryKey29 = registryKey23.OpenSubKey(array7[num25]);
											if (registryKey29.ValueCount > 0)
											{
												string[] valueNames4 = registryKey29.GetValueNames();
												if (valueNames4.Length > 1)
												{
													registryKey29.GetValue(valueNames4[0]);
												}
											}
											registryKey29.Close();
										}
										catch
										{
										}
									}
									IL_3196:;
								}
							}
							catch
							{
							}
						}
					}
					if (@class.bool_43)
					{
						try
						{
							string text7 = "Software\\CLASSES\\CID\\";
							string str20 = "Software\\CLASSES\\CLSID\\";
							RegistryKey currentUser11 = Registry.CurrentUser;
							RegistryKey registryKey30 = null;
							try
							{
								registryKey30 = currentUser11.OpenSubKey(text7, false);
							}
							catch
							{
								registryKey30 = null;
							}
							Class30.Class31 class6 = new Class30.Class31();
							int num26 = class6.method_3(24);
							string[] array8 = new string[0];
							int num27 = 0;
							if (registryKey30 != null)
							{
								array8 = registryKey30.GetSubKeyNames();
								num27 = array8.Length;
							}
							int num28 = 25;
							if (registryKey30 == null)
							{
								num26 = 0;
								num28 = 1;
							}
							if (num27 < 3)
							{
								num26 = 0;
								num28 = 1;
							}
							for (int n = 0; n < num28; n++)
							{
								if (n == num26)
								{
									string str21 = "{A3358E75-826A3-31A5-2C1E-14A484D53571}\\";
									RegistryKey registryKey31 = Registry.CurrentUser;
									if (registryKey31.OpenSubKey(text7 + str21 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false) != null)
									{
										goto IL_3757;
									}
									if (File.Exists(string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\Isolated Storage\\",
										Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
										"\\",
										Class10.Class19.smethod_7(str21)
									})))
									{
										this.method_3(string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\Isolated Storage\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
											"\\",
											Class10.Class19.smethod_7(str21)
										}), text7 + str21 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										goto IL_3757;
									}
									try
									{
										registryKey31 = Registry.LocalMachine;
										RegistryKey registryKey32 = registryKey31.OpenSubKey(text7 + str21 + Class10.smethod_33(@class.class18_0.method_4()), false);
										if (registryKey32 != null)
										{
											this.method_0(registryKey32, text7 + str21 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										}
										goto IL_3757;
									}
									catch
									{
										goto IL_3757;
									}
									goto IL_33EA;
									IL_3415:
									RegistryKey registryKey33;
									RegistryKey currentUser12;
									string str22;
									if (registryKey33 == null)
									{
										currentUser12 = Registry.CurrentUser;
										registryKey33 = currentUser12.CreateSubKey(text7 + str22 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										registryKey33.SetValue("2", Class10.smethod_30(dateTime));
										DateTime now2 = DateTime.Now;
										if (DateTime.Compare(now2, @class.dateTime_0) >= 0)
										{
											flag6 = false;
											num3 = 0;
											if (Class30.int_4 == 2147483647)
											{
												Class30.int_4 = 0;
											}
											else if (!@class.bool_38)
											{
												Class30.int_4 = 0;
											}
										}
										else
										{
											TimeSpan timeSpan3 = @class.dateTime_0.Subtract(DateTime.Now);
											num3 = timeSpan3.Days;
											if (Class30.int_4 == 2147483647)
											{
												Class30.int_4 = timeSpan3.Days;
											}
											else if (@class.bool_38)
											{
												if (timeSpan3.Days > Class30.int_4)
												{
													Class30.int_4 = timeSpan3.Days;
												}
											}
											else if (timeSpan3.Days < Class30.int_4)
											{
												Class30.int_4 = timeSpan3.Days;
											}
										}
										this.method_2(registryKey33, string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\Isolated Storage\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
											"\\",
											Class10.Class19.smethod_7(str22)
										}));
										goto IL_374C;
									}
									string string_5 = (string)registryKey33.GetValue("2");
									DateTime dateTime3 = Class10.smethod_31(string_5);
									bool flag14;
									if (flag14)
									{
										currentUser12 = Registry.CurrentUser;
										registryKey33 = currentUser12.CreateSubKey(text7 + str22 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
										registryKey33.SetValue("2", Class10.smethod_30(dateTime3));
									}
									if (DateTime.Compare(dateTime, dateTime3) >= 0)
									{
										registryKey33.SetValue("2", Class10.smethod_30(dateTime));
										dateTime3 = dateTime;
									}
									if (DateTime.Compare(dateTime3, @class.dateTime_0) >= 0)
									{
										flag6 = false;
										num3 = 0;
										if (Class30.int_4 == 2147483647)
										{
											Class30.int_4 = 0;
										}
										else if (!@class.bool_38)
										{
											Class30.int_4 = 0;
										}
									}
									else
									{
										TimeSpan timeSpan4 = @class.dateTime_0.Subtract(DateTime.Now);
										num3 = timeSpan4.Days;
										if (Class30.int_4 == 2147483647)
										{
											Class30.int_4 = timeSpan4.Days;
										}
										else if (@class.bool_38)
										{
											if (timeSpan4.Days > Class30.int_4)
											{
												Class30.int_4 = timeSpan4.Days;
											}
										}
										else if (timeSpan4.Days < Class30.int_4)
										{
											Class30.int_4 = timeSpan4.Days;
										}
									}
									this.method_2(registryKey33, string.Concat(new string[]
									{
										Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
										"\\Isolated Storage\\",
										Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
										"\\",
										Class10.Class19.smethod_7(str22)
									}));
									goto IL_374C;
									IL_33EA:
									flag14 = true;
									registryKey33 = currentUser12.OpenSubKey(str20 + str22 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
									goto IL_3415;
									IL_3757:
									str22 = "{A3358E75-826A3-31A5-2C1E-14A484D53571}\\";
									currentUser12 = Registry.CurrentUser;
									registryKey33 = currentUser12.OpenSubKey(text7 + str22 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), true);
									flag14 = false;
									if (registryKey33 == null)
									{
										goto IL_33EA;
									}
									goto IL_3415;
								}
								else
								{
									try
									{
										int num29 = class6.method_3(num27 - 1);
										RegistryKey registryKey34 = registryKey30.OpenSubKey(array8[num29]);
										if (registryKey34.ValueCount > 0)
										{
											string[] valueNames5 = registryKey34.GetValueNames();
											if (valueNames5.Length > 1)
											{
												registryKey34.GetValue(valueNames5[0]);
											}
										}
										registryKey34.Close();
									}
									catch
									{
									}
								}
								IL_374C:;
							}
						}
						catch (Exception)
						{
						}
						if ((!flag || (flag && !flag2)) && this.class29_1.enum9_1 == Enum9.Trial_Days)
						{
							try
							{
								this.timer_1.Dispose();
							}
							catch
							{
							}
							try
							{
								Class30.dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
								Class30.dateTime_1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
								this.timer_1 = new System.Threading.Timer(new TimerCallback(this.method_6), null, 60000, 60000);
							}
							catch
							{
							}
						}
					}
					if (@class.bool_49)
					{
						if (!Class30.bool_1)
						{
							Class30.bool_1 = true;
							try
							{
								string text8 = "Software\\CLASSES\\CID\\";
								string str23 = "Software\\CLASSES\\CLSID\\";
								RegistryKey currentUser13 = Registry.CurrentUser;
								RegistryKey registryKey35 = null;
								try
								{
									registryKey35 = currentUser13.OpenSubKey(text8, false);
								}
								catch
								{
									registryKey35 = null;
								}
								Class30.Class31 class7 = new Class30.Class31();
								int num30 = class7.method_3(24);
								string[] array9 = new string[0];
								int num31 = 0;
								if (registryKey35 != null)
								{
									array9 = registryKey35.GetSubKeyNames();
									num31 = array9.Length;
								}
								int num32 = 25;
								if (registryKey35 == null)
								{
									num30 = 0;
									num32 = 1;
								}
								if (num31 < 3)
								{
									num30 = 0;
									num32 = 1;
								}
								for (int num33 = 0; num33 < num32; num33++)
								{
									if (num33 == num30)
									{
										string str24 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
										RegistryKey registryKey36 = Registry.CurrentUser;
										if (registryKey36.OpenSubKey(text8 + str24 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false) != null)
										{
											goto IL_3CFB;
										}
										if (File.Exists(string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\Isolated Storage\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
											"\\",
											Class10.Class19.smethod_7(str24)
										})))
										{
											this.method_3(string.Concat(new string[]
											{
												Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
												"\\Isolated Storage\\",
												Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
												"\\",
												Class10.Class19.smethod_7(str24)
											}), text8 + str24 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											goto IL_3CFB;
										}
										try
										{
											registryKey36 = Registry.LocalMachine;
											RegistryKey registryKey37 = registryKey36.OpenSubKey(text8 + str24 + Class10.smethod_33(@class.class18_0.method_4()), false);
											if (registryKey37 != null)
											{
												this.method_0(registryKey37, text8 + str24 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											}
											goto IL_3CFB;
										}
										catch
										{
											goto IL_3CFB;
										}
										goto IL_3A74;
										IL_3A9F:
										RegistryKey registryKey38;
										RegistryKey currentUser14;
										string str25;
										if (registryKey38 == null)
										{
											currentUser14 = Registry.CurrentUser;
											registryKey38 = currentUser14.CreateSubKey(text8 + str25 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											registryKey38.SetValue("2", Class10.smethod_37(Class30.int_3.ToString()));
											if (Class30.int_3 > @class.int_4)
											{
												flag7 = false;
												Class30.int_3 = @class.int_4 + 1;
												num4 = 0;
											}
											else
											{
												num4 = @class.int_4 - Class30.int_3;
											}
											this.method_2(registryKey38, string.Concat(new string[]
											{
												Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
												"\\Isolated Storage\\",
												Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
												"\\",
												Class10.Class19.smethod_7(str25)
											}));
											goto IL_3CF0;
										}
										string string_6 = (string)registryKey38.GetValue("2");
										Class30.int_3 = Convert.ToInt32(Class10.smethod_38(string_6));
										bool flag15;
										if (flag15)
										{
											currentUser14 = Registry.CurrentUser;
											registryKey38 = currentUser14.CreateSubKey(text8 + str25 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())));
											registryKey38.SetValue("2", Class10.smethod_37(Class30.int_3.ToString()));
										}
										if (!flag8)
										{
											Class30.int_3++;
											registryKey38.SetValue("2", Class10.smethod_37(Class30.int_3.ToString()));
										}
										if (Class30.int_3 > @class.int_4)
										{
											flag7 = false;
											Class30.int_3 = @class.int_4 + 1;
											num4 = 0;
										}
										else
										{
											num4 = @class.int_4 - Class30.int_3;
										}
										this.method_2(registryKey38, string.Concat(new string[]
										{
											Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
											"\\Isolated Storage\\",
											Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())),
											"\\",
											Class10.Class19.smethod_7(str25)
										}));
										goto IL_3CF0;
										IL_3A74:
										flag15 = true;
										registryKey38 = currentUser14.OpenSubKey(str23 + str25 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
										goto IL_3A9F;
										IL_3CFB:
										str25 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
										currentUser14 = Registry.CurrentUser;
										registryKey38 = currentUser14.OpenSubKey(text8 + str25 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), true);
										flag15 = false;
										if (registryKey38 == null)
										{
											goto IL_3A74;
										}
										goto IL_3A9F;
									}
									else
									{
										try
										{
											int num34 = class7.method_3(num31 - 1);
											RegistryKey registryKey39 = registryKey35.OpenSubKey(array9[num34], false);
											if (registryKey39.ValueCount > 0)
											{
												string[] valueNames6 = registryKey39.GetValueNames();
												if (valueNames6.Length > 1)
												{
													registryKey39.GetValue(valueNames6[0]);
												}
											}
											registryKey39.Close();
										}
										catch
										{
										}
									}
									IL_3CF0:;
								}
								goto IL_3E18;
							}
							catch
							{
								goto IL_3E18;
							}
						}
						try
						{
							string str26 = "Software\\CLASSES\\CID\\";
							string str27 = "Software\\CLASSES\\CLSID\\";
							string str28 = "{D3558E25-821F3-72C3-8A52-54A482A54739}\\";
							RegistryKey currentUser15 = Registry.CurrentUser;
							RegistryKey registryKey40 = currentUser15.OpenSubKey(str26 + str28 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
							if (registryKey40 == null)
							{
								registryKey40 = currentUser15.OpenSubKey(str27 + str28 + Class10.Class19.smethod_7(Class10.smethod_33(@class.class18_0.method_4())), false);
							}
							if (registryKey40 != null)
							{
								string string_7 = (string)registryKey40.GetValue("2");
								Class30.int_3 = Convert.ToInt32(Class10.smethod_38(string_7));
								if (Class30.int_3 > @class.int_4)
								{
									flag7 = false;
									Class30.int_3 = @class.int_4 + 1;
									num4 = 0;
								}
								else
								{
									num4 = @class.int_4 - Class30.int_3;
								}
							}
						}
						catch
						{
						}
					}
					IL_3E18:
					if (Class30.class29_0.bool_38)
					{
						if (@class.bool_51)
						{
							flag13 = false;
						}
						if (@class.bool_43)
						{
							flag13 = false;
						}
						if (@class.bool_49)
						{
							flag13 = false;
						}
						if (@class.bool_51 && flag5)
						{
							flag13 = true;
						}
						if (@class.bool_43 && flag6)
						{
							flag13 = true;
						}
						if (@class.bool_49 && flag7)
						{
							flag13 = true;
						}
					}
					else
					{
						if (@class.bool_51 && !flag5)
						{
							flag13 = false;
						}
						if (@class.bool_43 && !flag6)
						{
							flag13 = false;
						}
						if (@class.bool_49 && !flag7)
						{
							flag13 = false;
						}
					}
				}
			}
			if (@class.bool_50)
			{
				string processName = Process.GetCurrentProcess().ProcessName;
				Process[] processesByName = Process.GetProcessesByName(processName);
				if (processesByName.Length > @class.int_1)
				{
					try
					{
						if (@class.bool_42)
						{
							if (@class.bool_0)
							{
								try
								{
									if (!flag)
									{
										lSfgApatkdxsVcGcrktoFd.Close();
									}
								}
								catch
								{
								}
							}
							ConstructorInfo constructor = this.type_0.GetConstructor(new Type[0]);
							object target = constructor.Invoke(new object[0]);
							this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
							{
								@class.string_13
							});
							this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
							{
								@class.color_0
							});
							this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
							{
								@class.color_1
							});
							string text9 = @class.string_20;
							text9 = text9.Replace("[current_minutes_days]", num.ToString());
							text9 = text9.Replace("[expdate_days_left]", num3.ToString());
							text9 = text9.Replace("[minutes_days_left]", num2.ToString());
							text9 = text9.Replace("[uses_left]", num4.ToString());
							text9 = text9.Replace("[max_minutes_days]", num5.ToString());
							text9 = text9.Replace("[max_uses]", Class30.int_1.ToString());
							text9 = text9.Replace("[max_processes]", Class30.int_2.ToString());
							text9 = text9.Replace("[current_uses]", Class30.int_3.ToString());
							this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
							{
								text9
							});
							try
							{
								this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target, new object[0]);
							}
							catch
							{
							}
						}
						Class30.TerminateProcess(Class30.GetCurrentProcess(), 1);
						return new Class30.Class33(this, "");
					}
					catch
					{
					}
				}
			}
			if (@class.bool_0)
			{
				try
				{
					if (!flag)
					{
						lSfgApatkdxsVcGcrktoFd.Close();
					}
				}
				catch
				{
				}
			}
			Class35.smethod_7(flag3);
			if (@class.bool_30)
			{
				Class10.Class11.smethod_11();
				Class35.smethod_9(Class10.Class11.smethod_5(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45));
			}
			try
			{
				Class35.License_HardwareID = @class.string_21;
			}
			catch
			{
			}
			if (this.class29_1 != null)
			{
				Class35.smethod_36().Clear();
				IDictionaryEnumerator enumerator = this.class29_1.hashtable_0.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Class35.smethod_36().Add(enumerator.Key.ToString(), enumerator.Value.ToString());
				}
			}
			Class35.smethod_11(@class.bool_51);
			Class35.smethod_21(@class.int_3);
			if (@class.enum9_0 == Enum9.Trial_Days)
			{
				Class35.smethod_31(Enum9.Trial_Days);
				Class35.smethod_23(num);
			}
			else
			{
				Class35.smethod_31(Enum9.Runtime_Minutes);
				Class35.smethod_23(0);
			}
			try
			{
				Class35.smethod_19(@class.bool_44);
				Class35.smethod_13(@class.bool_43);
				Class35.smethod_35(@class.dateTime_0);
			}
			catch
			{
			}
			try
			{
				Class35.smethod_15(@class.bool_49);
				Class35.smethod_27(@class.int_4);
				Class35.smethod_25(Class30.int_3);
			}
			catch
			{
			}
			try
			{
				Class35.smethod_17(@class.bool_50);
				Class35.smethod_29(@class.int_1);
			}
			catch
			{
			}
			try
			{
				Class35.smethod_33(Class30.byte_0);
			}
			catch
			{
			}
			bool flag16 = false;
			if (!flag3 && !flag9 && !@class.bool_37)
			{
				try
				{
					if (Class30.class29_0.bool_40)
					{
						if (Class30.class29_0.bool_52 && byte_1.Length == 1 && Class30.class34_0 == null)
						{
							Class30.class34_0 = new Class30.Class34();
						}
						flag16 = true;
						ConstructorInfo constructor2 = this.type_0.GetConstructor(new Type[0]);
						object target2 = constructor2.Invoke(new object[0]);
						this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target2, new object[]
						{
							@class.string_13
						});
						this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target2, new object[]
						{
							@class.color_0
						});
						this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target2, new object[]
						{
							@class.color_1
						});
						string text10 = @class.string_17;
						text10 = text10.Replace("[current_minutes_days]", num.ToString());
						text10 = text10.Replace("[minutes_days_left]", num2.ToString());
						text10 = text10.Replace("[expdate_days_left]", num3.ToString());
						text10 = text10.Replace("[uses_left]", num4.ToString());
						text10 = text10.Replace("[max_minutes_days]", num5.ToString());
						text10 = text10.Replace("[max_uses]", Class30.int_1.ToString());
						text10 = text10.Replace("[max_processes]", Class30.int_2.ToString());
						text10 = text10.Replace("[current_uses]", Class30.int_3.ToString());
						this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target2, new object[]
						{
							text10
						});
						try
						{
							this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target2, new object[0]);
						}
						catch
						{
						}
					}
					if (@class.string_12.Length > 0)
					{
						string text11 = @class.string_12.Trim();
						string text12 = "";
						try
						{
							int num35 = text11.ToUpper().IndexOf(".EXE ");
							if (num35 > 0)
							{
								text12 = text11.Substring(num35 + 5).Trim();
								text11 = text11.Substring(0, num35 + 5).Trim();
							}
						}
						catch
						{
						}
						try
						{
							if (File.Exists(Path.GetFullPath(text11)))
							{
								text11 = Path.GetFullPath(text11);
							}
							else if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(text11)))
							{
								text11 = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(text11);
							}
						}
						catch
						{
						}
						try
						{
							if (text12.Length == 0)
							{
								Process.Start(text11);
							}
							else
							{
								Process.Start(text11, text12);
							}
						}
						catch
						{
						}
					}
					Class30.TerminateProcess(Class30.GetCurrentProcess(), 1);
					return new Class30.Class33(this, "");
				}
				catch
				{
				}
			}
			if (@class.bool_43 && !flag13 && !flag6)
			{
				try
				{
					if (Class30.class29_0.bool_55 && !flag16)
					{
						flag16 = true;
						ConstructorInfo constructor3 = this.type_0.GetConstructor(new Type[0]);
						object target3 = constructor3.Invoke(new object[0]);
						this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target3, new object[]
						{
							@class.string_13
						});
						this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target3, new object[]
						{
							@class.color_0
						});
						this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target3, new object[]
						{
							@class.color_1
						});
						string text13 = @class.string_15;
						text13 = text13.Replace("[current_minutes_days]", num.ToString());
						text13 = text13.Replace("[minutes_days_left]", num2.ToString());
						text13 = text13.Replace("[expdate_days_left]", num3.ToString());
						text13 = text13.Replace("[uses_left]", num4.ToString());
						text13 = text13.Replace("[max_minutes_days]", num5.ToString());
						text13 = text13.Replace("[max_uses]", Class30.int_1.ToString());
						text13 = text13.Replace("[max_processes]", Class30.int_2.ToString());
						text13 = text13.Replace("[current_uses]", Class30.int_3.ToString());
						this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target3, new object[]
						{
							text13
						});
						try
						{
							this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target3, new object[0]);
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
			if (@class.bool_51 && !flag13 && !flag5)
			{
				if (@class.bool_51)
				{
					if (@class.enum9_0 == Enum9.Runtime_Minutes)
					{
						flag13 = true;
						goto IL_4934;
					}
				}
				try
				{
					if (Class30.class29_0.bool_53 && !flag16)
					{
						flag16 = true;
						ConstructorInfo constructor4 = this.type_0.GetConstructor(new Type[0]);
						object target4 = constructor4.Invoke(new object[0]);
						this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target4, new object[]
						{
							@class.string_13
						});
						this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target4, new object[]
						{
							@class.color_0
						});
						this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target4, new object[]
						{
							@class.color_1
						});
						string text14 = @class.string_18;
						text14 = text14.Replace("[current_minutes_days]", num.ToString());
						text14 = text14.Replace("[minutes_days_left]", num2.ToString());
						text14 = text14.Replace("[expdate_days_left]", num3.ToString());
						text14 = text14.Replace("[uses_left]", num4.ToString());
						text14 = text14.Replace("[max_minutes_days]", num5.ToString());
						text14 = text14.Replace("[max_uses]", Class30.int_1.ToString());
						text14 = text14.Replace("[max_processes]", Class30.int_2.ToString());
						text14 = text14.Replace("[current_uses]", Class30.int_3.ToString());
						this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target4, new object[]
						{
							text14
						});
						try
						{
							this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target4, new object[0]);
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
			IL_4934:
			if (@class.bool_54 && !flag13 && !flag7)
			{
				try
				{
					if (Class30.class29_0.bool_54 && !flag16)
					{
						flag16 = true;
						if (!Class30.bool_2)
						{
							Class30.bool_2 = true;
							ConstructorInfo constructor5 = this.type_0.GetConstructor(new Type[0]);
							object target5 = constructor5.Invoke(new object[0]);
							this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target5, new object[]
							{
								@class.string_13
							});
							this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target5, new object[]
							{
								@class.color_0
							});
							this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target5, new object[]
							{
								@class.color_1
							});
							string text15 = @class.string_19;
							text15 = text15.Replace("[current_minutes_days]", num.ToString());
							text15 = text15.Replace("[minutes_days_left]", num2.ToString());
							text15 = text15.Replace("[expdate_days_left]", num3.ToString());
							text15 = text15.Replace("[uses_left]", num4.ToString());
							text15 = text15.Replace("[max_minutes_days]", num5.ToString());
							text15 = text15.Replace("[max_uses]", Class30.int_1.ToString());
							text15 = text15.Replace("[max_processes]", Class30.int_2.ToString());
							text15 = text15.Replace("[current_uses]", Class30.int_3.ToString());
							this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target5, new object[]
							{
								text15
							});
							try
							{
								this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target5, new object[0]);
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
			}
			if (!flag3 && @class.bool_39)
			{
				if (!@class.bool_43 && !@class.bool_51 && !@class.bool_49 && !@class.bool_44)
				{
					if (@class.bool_37)
					{
						goto IL_4D6B;
					}
				}
				try
				{
					bool flag17 = true;
					if (Class30.class29_0.int_2 != -1 && Class30.int_4 > Class30.class29_0.int_2)
					{
						flag17 = false;
					}
					if (flag17 && !flag16)
					{
						flag16 = true;
						if (!flag)
						{
							ConstructorInfo constructor6 = this.type_0.GetConstructor(new Type[0]);
							object target6 = constructor6.Invoke(new object[0]);
							this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target6, new object[]
							{
								@class.string_13
							});
							this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target6, new object[]
							{
								@class.color_0
							});
							this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target6, new object[]
							{
								@class.color_1
							});
							string text16 = @class.string_16;
							text16 = text16.Replace("[current_minutes_days]", num.ToString());
							text16 = text16.Replace("[minutes_days_left]", num2.ToString());
							text16 = text16.Replace("[expdate_days_left]", num3.ToString());
							text16 = text16.Replace("[uses_left]", num4.ToString());
							text16 = text16.Replace("[max_minutes_days]", num5.ToString());
							text16 = text16.Replace("[max_uses]", Class30.int_1.ToString());
							text16 = text16.Replace("[max_processes]", Class30.int_2.ToString());
							text16 = text16.Replace("[current_uses]", Class30.int_3.ToString());
							this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target6, new object[]
							{
								text16
							});
							try
							{
								this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target6, new object[0]);
							}
							catch
							{
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
			IL_4D6B:
			if (!flag3 && @class.bool_51 && (!flag || (flag && !flag2)))
			{
				if (@class.enum9_0 == Enum9.Runtime_Minutes)
				{
					try
					{
						this.timer_0.Dispose();
					}
					catch
					{
					}
					this.timer_0 = new System.Threading.Timer(new TimerCallback(this.method_5), null, num5 * 60000, num5 * 60000);
				}
				if (this.class29_1.enum9_1 == Enum9.Trial_Days)
				{
					try
					{
						this.timer_1.Dispose();
					}
					catch
					{
					}
					try
					{
						Class30.dateTime_0 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
						Class30.dateTime_1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
						this.timer_1 = new System.Threading.Timer(new TimerCallback(this.method_6), null, 60000, 60000);
					}
					catch
					{
					}
				}
			}
			if (!flag13)
			{
				if (@class.string_12.Length > 0)
				{
					string text17 = @class.string_12.Trim();
					string text18 = "";
					try
					{
						int num36 = text17.ToUpper().IndexOf(".EXE ");
						if (num36 > 0)
						{
							text18 = text17.Substring(num36 + 5).Trim();
							text17 = text17.Substring(0, num36 + 5).Trim();
						}
					}
					catch
					{
					}
					try
					{
						if (File.Exists(Path.GetFullPath(text17)))
						{
							text17 = Path.GetFullPath(text17);
						}
						else if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(text17)))
						{
							text17 = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(text17);
						}
					}
					catch
					{
					}
					try
					{
						if (text18.Length == 0)
						{
							Process.Start(text17);
						}
						else
						{
							Process.Start(text17, text18);
						}
					}
					catch
					{
					}
				}
				if (@class.bool_52)
				{
					Class30.TerminateProcess(Class30.GetCurrentProcess(), 1);
					return new Class30.Class33(this, "");
				}
			}
		}
		catch (Exception ex)
		{
			if (@class != null && @class.class18_0 != null && @class.class18_0.method_8() != null)
			{
				@class.class18_0.method_8().Clear();
			}
			throw ex;
		}
		return new Class30.Class33(this, "");
	}

	// Token: 0x06000353 RID: 851 RVA: 0x00027580 File Offset: 0x00025780
	private void method_5(object object_0)
	{
		try
		{
			this.timer_0.Dispose();
		}
		catch
		{
		}
		if (Class30.class29_0.bool_52 && Class30.class34_0 == null)
		{
			Class30.class34_0 = new Class30.Class34();
		}
		try
		{
			if (Class30.class29_0.bool_53)
			{
				ConstructorInfo constructor = this.type_0.GetConstructor(new Type[0]);
				object target = constructor.Invoke(new object[0]);
				this.type_0.InvokeMember("MessageBoxCaption", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
				{
					Class30.class29_0.string_13
				});
				this.type_0.InvokeMember("MessageBoxGradientBegin", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
				{
					Class30.class29_0.color_0
				});
				this.type_0.InvokeMember("MessageBoxGradientEnd", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
				{
					Class30.class29_0.color_1
				});
				string text = Class30.class29_0.string_18;
				text = text.Replace("[current_minutes_days]", Class30.int_0.ToString());
				text = text.Replace("[max_minutes_days]", Class30.int_0.ToString());
				text = text.Replace("[max_uses]", Class30.int_1.ToString());
				text = text.Replace("[max_processes]", Class30.int_2.ToString());
				text = text.Replace("[current_uses]", Class30.int_3.ToString());
				this.type_0.InvokeMember("MessageBoxText", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty, null, target, new object[]
				{
					text
				});
				try
				{
					this.type_0.InvokeMember("ShowDialog", BindingFlags.InvokeMethod, null, target, new object[0]);
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		if (Class30.class29_0.string_12.Length > 0)
		{
			string text2 = Class30.class29_0.string_12.Trim();
			string text3 = "";
			try
			{
				int num = text2.ToUpper().IndexOf(".EXE ");
				if (num > 0)
				{
					text3 = text2.Substring(num + 5).Trim();
					text2 = text2.Substring(0, num + 5).Trim();
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(Path.GetFullPath(text2)))
				{
					text2 = Path.GetFullPath(text2);
				}
				else if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(text2)))
				{
					text2 = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Path.GetFileName(text2);
				}
			}
			catch
			{
			}
			try
			{
				if (text3.Length == 0)
				{
					Process.Start(text2);
				}
				else
				{
					Process.Start(text2, text3);
				}
			}
			catch
			{
			}
		}
		if (Class30.class29_0.bool_52)
		{
			Class30.TerminateProcess(Class30.GetCurrentProcess(), 1);
		}
	}

	// Token: 0x06000354 RID: 852 RVA: 0x000278D8 File Offset: 0x00025AD8
	private void method_6(object object_0)
	{
		if (Class30.dateTime_1 != new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
		{
			Class30.dateTime_1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			new Class30().method_4(new byte[]
			{
				1
			});
		}
	}

	// Token: 0x06000355 RID: 853 RVA: 0x00003C5F File Offset: 0x00001E5F
	internal static bool smethod_0(string string_9, object object_0)
	{
		return Class10.smethod_34(string_9, Class30.class29_0.class18_0.method_4()).ToString() == object_0.ToString();
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0002796C File Offset: 0x00025B6C
	internal static bool smethod_1(string string_9)
	{
		Class10.Class19.smethod_4();
		bool result;
		try
		{
			string b = Class10.Class11.smethod_11();
			string b2 = Class10.Class11.smethod_1(Class30.class29_0.bool_48, Class30.class29_0.bool_46, Class30.class29_0.bool_47, Class30.class29_0.bool_45);
			string b3 = Class10.Class11.smethod_2(Class30.class29_0.bool_48, Class30.class29_0.bool_46, Class30.class29_0.bool_47, Class30.class29_0.bool_45);
			string b4 = Class10.Class11.KefSrjlCea(Class30.class29_0.bool_48, Class30.class29_0.bool_46, Class30.class29_0.bool_47, Class30.class29_0.bool_45);
			string b5 = Class10.Class11.smethod_3(Class30.class29_0.bool_48, Class30.class29_0.bool_46, Class30.class29_0.bool_47, Class30.class29_0.bool_45);
			string text = Class10.Class11.smethod_5(Class30.class29_0.bool_48, Class30.class29_0.bool_46, Class30.class29_0.bool_47, Class30.class29_0.bool_45);
			string b6 = Class10.Class11.smethod_4(Class30.class29_0.bool_48, Class30.class29_0.bool_46, Class30.class29_0.bool_47, Class30.class29_0.bool_45);
			string text2 = Class10.Class11.smethod_0();
			if (text2 == "{nohid-22222-10001-00000}")
			{
				text2 = text;
			}
			string[] array = Class10.smethod_36(string_9, Class30.class29_0.class18_0.method_4()).Split(new char[]
			{
				'|'
			});
			string text3 = array[1];
			string text4 = array[0] + array[2] + array[0] + array[2];
			bool flag = false;
			if (!(text3 == b) && !(text3 == b2) && !(text3 == b3) && !(text3 == b4) && !(text3 == b5) && !(text3 == text) && !(text3 == b6) && !(text3 == text2))
			{
				result = false;
			}
			else
			{
				try
				{
					string text5 = "Software\\CLASSES\\CLSID\\";
					RegistryKey localMachine = Registry.LocalMachine;
					RegistryKey registryKey = localMachine.OpenSubKey(string.Concat(new string[]
					{
						text5,
						"{",
						text4,
						"-826F8-31C4-2C1E-14A4",
						Class10.Class19.smethod_7(text3),
						"}\\"
					}), false);
					if (registryKey != null)
					{
						flag = true;
					}
				}
				catch
				{
				}
				try
				{
					string text6 = "Software\\CLASSES\\CLSID\\";
					RegistryKey currentUser = Registry.CurrentUser;
					RegistryKey registryKey2 = currentUser.OpenSubKey(string.Concat(new string[]
					{
						text6,
						"{",
						text4,
						"-826F8-31C4-2C1E-14A4",
						Class10.Class19.smethod_7(text3),
						"}\\"
					}), false);
					if (registryKey2 != null)
					{
						flag = true;
					}
				}
				catch
				{
				}
				try
				{
					string text7 = "Software\\CLASSES\\CID\\";
					RegistryKey currentUser2 = Registry.CurrentUser;
					RegistryKey registryKey3 = currentUser2.OpenSubKey(string.Concat(new string[]
					{
						text7,
						"{",
						text4,
						"-826F8-31C4-2C1E-14A4",
						Class10.Class19.smethod_7(text3),
						"}\\"
					}), false);
					if (registryKey3 != null)
					{
						flag = true;
					}
				}
				catch
				{
				}
				try
				{
					string str = Class10.Class19.smethod_7(Class10.smethod_0("{O33BAC75-826F8-31C4-2C1E-14A484D53587}" + Class10.smethod_33(Class30.class29_0.class18_0.method_4()) + text3 + text4));
					if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Isolated Storage\\" + str))
					{
						flag = true;
					}
				}
				catch
				{
				}
				if (flag)
				{
					result = false;
				}
				else
				{
					try
					{
						string text8 = "Software\\CLASSES\\CLSID\\";
						RegistryKey localMachine2 = Registry.LocalMachine;
						localMachine2.CreateSubKey(string.Concat(new string[]
						{
							text8,
							"{",
							text4,
							"-826F8-31C4-2C1E-14A4",
							Class10.Class19.smethod_7(text3),
							"}\\"
						}));
						localMachine2.Close();
					}
					catch
					{
					}
					try
					{
						string text9 = "Software\\CLASSES\\CLSID\\";
						RegistryKey currentUser3 = Registry.CurrentUser;
						currentUser3.CreateSubKey(string.Concat(new string[]
						{
							text9,
							"{",
							text4,
							"-826F8-31C4-2C1E-14A4",
							Class10.Class19.smethod_7(text3),
							"}\\"
						}));
						currentUser3.Close();
					}
					catch
					{
					}
					try
					{
						string text10 = "Software\\CLASSES\\CID\\";
						RegistryKey currentUser4 = Registry.CurrentUser;
						currentUser4.CreateSubKey(string.Concat(new string[]
						{
							text10,
							"{",
							text4,
							"-826F8-31C4-2C1E-14A4",
							Class10.Class19.smethod_7(text3),
							"}\\"
						}));
						currentUser4.Close();
					}
					catch
					{
					}
					try
					{
						string str2 = Class10.Class19.smethod_7(Class10.smethod_0("{O33BAC75-826F8-31C4-2C1E-14A484D53587}" + Class10.smethod_33(Class30.class29_0.class18_0.method_4()) + text3 + text4));
						Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Isolated Storage\\" + str2);
					}
					catch
					{
					}
					try
					{
						string str3 = "Software\\CLASSES\\CLSID\\";
						string str4 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
						RegistryKey localMachine3 = Registry.LocalMachine;
						localMachine3.DeleteSubKey(str3 + str4 + Class10.smethod_33(Class30.class29_0.class18_0.method_4()), false);
					}
					catch
					{
					}
					try
					{
						string str5 = "Software\\CLASSES\\CLSID\\";
						string str6 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
						RegistryKey currentUser5 = Registry.CurrentUser;
						currentUser5.DeleteSubKey(str5 + str6 + Class10.Class19.smethod_7(Class10.smethod_33(Class30.class29_0.class18_0.method_4())), false);
					}
					catch
					{
					}
					try
					{
						string str7 = "Software\\CLASSES\\CID\\";
						string str8 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
						RegistryKey currentUser6 = Registry.CurrentUser;
						currentUser6.DeleteSubKey(str7 + str8 + Class10.Class19.smethod_7(Class10.smethod_33(Class30.class29_0.class18_0.method_4())), false);
					}
					catch
					{
					}
					try
					{
						string str9 = Class10.Class19.smethod_7(Class10.smethod_0("{Y3358E75-826A3-31A5-2C1E-14A484D53571}" + Class10.smethod_33(Class30.class29_0.class18_0.method_4())));
						Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Isolated Storage\\" + str9);
					}
					catch
					{
					}
					result = true;
				}
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000357 RID: 855 RVA: 0x00003C8B File Offset: 0x00001E8B
	internal static void smethod_2(byte[] byte_1)
	{
		Class30.string_8.ToString();
		new Class30().method_4(byte_1);
	}

	// Token: 0x06000358 RID: 856 RVA: 0x000280B4 File Offset: 0x000262B4
	internal static string smethod_3()
	{
		string result = "";
		Class10.Class19.smethod_4();
		try
		{
			try
			{
				string str = "Software\\CLASSES\\CLSID\\";
				string str2 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
				RegistryKey localMachine = Registry.LocalMachine;
				localMachine.CreateSubKey(str + str2 + Class10.smethod_33(Class30.class29_0.class18_0.method_4()));
			}
			catch
			{
			}
			try
			{
				string str3 = "Software\\CLASSES\\CID\\";
				string str4 = "{Y3358E75-826A3-31A5-2C1E-14A484D53571}\\";
				RegistryKey currentUser = Registry.CurrentUser;
				currentUser.CreateSubKey(str3 + str4 + Class10.Class19.smethod_7(Class10.smethod_33(Class30.class29_0.class18_0.method_4())));
			}
			catch
			{
			}
			try
			{
				string str5 = Class10.Class19.smethod_7(Class10.smethod_0("{Y3358E75-826A3-31A5-2C1E-14A484D53571}" + Class10.smethod_33(Class30.class29_0.class18_0.method_4())));
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Isolated Storage\\" + str5);
			}
			catch
			{
			}
			try
			{
				string string_ = Class10.Class11.smethod_5(Class30.class29_0.bool_48, Class30.class29_0.bool_46, Class30.class29_0.bool_47, Class30.class29_0.bool_45);
				result = Class10.smethod_34(string_, Class30.class29_0.class18_0.method_4());
			}
			catch
			{
			}
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x06000359 RID: 857 RVA: 0x00028260 File Offset: 0x00026460
	private bool method_7(Class10.Class29 class29_2, byte[] byte_1)
	{
		bool result;
		try
		{
			Class10.Class29 @class = new Class10.Class29();
			@class.method_21(byte_1, class29_2.bool_3, class29_2);
			bool flag = true;
			for (int i = 0; i < @class.class18_0.method_4().Length; i++)
			{
				if (@class.class18_0.method_4()[i] != class29_2.class18_0.method_4()[i])
				{
					flag = false;
				}
			}
			if (@class.class18_0.method_4().Length < 32)
			{
				flag = false;
			}
			if (!flag)
			{
				@class.method_0();
				result = false;
			}
			else
			{
				if (@class.bool_59)
				{
					Class30.string_0 = Class10.Class11.smethod_11();
					Class30.string_1 = Class10.Class11.smethod_1(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
					Class30.string_2 = Class10.Class11.smethod_2(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
					Class30.string_3 = Class10.Class11.KefSrjlCea(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
					Class30.string_4 = Class10.Class11.smethod_3(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
					Class30.string_5 = Class10.Class11.smethod_5(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
					Class30.string_6 = Class10.Class11.smethod_4(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
					Class30.string_7 = Class10.Class11.smethod_0();
					if (Class30.string_7 == "{nohid-22222-10001-00000}")
					{
						Class30.string_7 = Class30.string_5;
					}
					if (@class.class21_0 == null)
					{
						if (@class.string_21.Length <= 0)
						{
							@class.method_0();
							return false;
						}
						if (!Class10.Class11.smethod_9(@class.string_21, @class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45) && !(Class30.string_0.ToString() == @class.string_21.ToString()) && !(Class30.string_1.ToString() == @class.string_21.ToString()) && !(Class30.string_2.ToString() == @class.string_21.ToString()) && !(Class30.string_3.ToString() == @class.string_21.ToString()) && !(Class30.string_4.ToString() == @class.string_21.ToString()) && !(Class30.string_5.ToString() == @class.string_21.ToString()) && !(Class30.string_6.ToString() == @class.string_21.ToString()) && !(Class30.string_7.ToString() == @class.string_21.ToString()))
						{
							@class.method_0();
							return false;
						}
						if (this.class29_1 != null)
						{
							this.class29_1.method_0();
						}
						this.class29_1 = @class;
						try
						{
							Class30.byte_0 = byte_1;
						}
						catch
						{
						}
						return true;
					}
					else if (@class.string_21.Length > 0)
					{
						if (!Class10.Class11.smethod_9(@class.string_21, @class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45) && !(Class30.string_0.ToString() == @class.string_21.ToString()) && !(Class30.string_1.ToString() == @class.string_21.ToString()) && !(Class30.string_2.ToString() == @class.string_21.ToString()) && !(Class30.string_3.ToString() == @class.string_21.ToString()) && !(Class30.string_4.ToString() == @class.string_21.ToString()) && !(Class30.string_5.ToString() == @class.string_21.ToString()) && !(Class30.string_6.ToString() == @class.string_21.ToString()) && !(Class30.string_7.ToString() == @class.string_21.ToString()))
						{
							@class.method_0();
							return false;
						}
						if (this.class29_1 != null)
						{
							this.class29_1.method_0();
						}
						this.class29_1 = @class;
						try
						{
							Class30.byte_0 = byte_1;
						}
						catch
						{
						}
						return true;
					}
					else
					{
						Class10.Class21 class2 = Class10.smethod_29();
						if (class2.method_0().Count != @class.class21_0.method_0().Count)
						{
							@class.method_0();
							return false;
						}
						for (int j = 0; j < class2.method_0().Count; j++)
						{
							Class10.Class24 class3 = class2.method_0().method_0(j);
							Class10.Class24 class4 = @class.class21_0.method_0().method_0(j);
							if (class3.method_1() != class4.method_1())
							{
								@class.method_0();
								return false;
							}
							if (class3.Name.Trim().ToString() != class4.Name.Trim().ToString())
							{
								@class.method_0();
								return false;
							}
							for (int k = 0; k < class3.method_1(); k++)
							{
								if (class3.method_3(k).method_2() != null && class4.method_3(k).method_2() != null && class3.method_3(k).method_2().Trim().ToString() != class4.method_3(k).method_2().Trim().ToString())
								{
									@class.method_0();
									return false;
								}
							}
						}
					}
				}
				if (this.class29_1 != null)
				{
					this.class29_1.method_0();
				}
				this.class29_1 = @class;
				try
				{
					Class30.byte_0 = byte_1;
				}
				catch
				{
				}
				result = true;
			}
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600035A RID: 858 RVA: 0x00028894 File Offset: 0x00026A94
	private bool method_8(Class10.Class29 class29_2, string string_9)
	{
		if (class29_2.string_8.Length > 0 && class29_2.string_8.IndexOf("*") < 0)
		{
			if (File.Exists(string_9 + "\\" + class29_2.string_8))
			{
				try
				{
					Class10.Class29 @class = new Class10.Class29();
					@class.method_20(string_9 + "\\" + class29_2.string_8, class29_2.bool_3, class29_2);
					bool flag = true;
					for (int i = 0; i < @class.class18_0.method_4().Length; i++)
					{
						if (@class.class18_0.method_4()[i] != class29_2.class18_0.method_4()[i])
						{
							flag = false;
						}
					}
					if (@class.class18_0.method_4().Length < 32)
					{
						flag = false;
					}
					if (!flag)
					{
						@class.method_0();
						return false;
					}
					if (@class.bool_59)
					{
						Class30.string_0 = Class10.Class11.smethod_11();
						Class30.string_1 = Class10.Class11.smethod_1(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_2 = Class10.Class11.smethod_2(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_3 = Class10.Class11.KefSrjlCea(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_4 = Class10.Class11.smethod_3(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_5 = Class10.Class11.smethod_5(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_6 = Class10.Class11.smethod_4(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_7 = Class10.Class11.smethod_0();
						if (Class30.string_7 == "{nohid-22222-10001-00000}")
						{
							Class30.string_7 = Class30.string_5;
						}
						if (@class.class21_0 == null)
						{
							if (@class.string_21.Length <= 0)
							{
								@class.method_0();
								return false;
							}
							if (!Class10.Class11.smethod_9(@class.string_21, @class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45) && !(Class30.string_0.ToString() == @class.string_21.ToString()) && !(Class30.string_1.ToString() == @class.string_21.ToString()) && !(Class30.string_2.ToString() == @class.string_21.ToString()) && !(Class30.string_3.ToString() == @class.string_21.ToString()) && !(Class30.string_4.ToString() == @class.string_21.ToString()) && !(Class30.string_5.ToString() == @class.string_21.ToString()) && !(Class30.string_6.ToString() == @class.string_21.ToString()) && !(Class30.string_7.ToString() == @class.string_21.ToString()))
							{
								@class.method_0();
								return false;
							}
							if (this.class29_1 != null)
							{
								this.class29_1.method_0();
							}
							this.class29_1 = @class;
							try
							{
								Class30.byte_0 = this.method_10(string_9 + "\\" + class29_2.string_8);
							}
							catch
							{
							}
							return true;
						}
						else if (@class.string_21.Length > 0)
						{
							if (!Class10.Class11.smethod_9(@class.string_21, @class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45) && !(Class30.string_0.ToString() == @class.string_21.ToString()) && !(Class30.string_1.ToString() == @class.string_21.ToString()) && !(Class30.string_2.ToString() == @class.string_21.ToString()) && !(Class30.string_3.ToString() == @class.string_21.ToString()) && !(Class30.string_4.ToString() == @class.string_21.ToString()) && !(Class30.string_5.ToString() == @class.string_21.ToString()) && !(Class30.string_6.ToString() == @class.string_21.ToString()) && !(Class30.string_7.ToString() == @class.string_21.ToString()))
							{
								@class.method_0();
								return false;
							}
							if (this.class29_1 != null)
							{
								this.class29_1.method_0();
							}
							this.class29_1 = @class;
							try
							{
								Class30.byte_0 = this.method_10(string_9 + "\\" + class29_2.string_8);
							}
							catch
							{
							}
							return true;
						}
						else
						{
							Class10.Class21 class2 = Class10.smethod_29();
							if (class2.method_0().Count != @class.class21_0.method_0().Count)
							{
								@class.method_0();
								return false;
							}
							for (int j = 0; j < class2.method_0().Count; j++)
							{
								Class10.Class24 class3 = class2.method_0().method_0(j);
								Class10.Class24 class4 = @class.class21_0.method_0().method_0(j);
								if (class3.method_1() != class4.method_1())
								{
									@class.method_0();
									return false;
								}
								if (class3.Name.Trim().ToString() != class4.Name.Trim().ToString())
								{
									@class.method_0();
									return false;
								}
								for (int k = 0; k < class3.method_1(); k++)
								{
									if (class3.method_3(k).method_2() != null && class4.method_3(k).method_2() != null && class3.method_3(k).method_2().Trim().ToString() != class4.method_3(k).method_2().Trim().ToString())
									{
										@class.method_0();
										return false;
									}
								}
							}
						}
					}
					if (this.class29_1 != null)
					{
						this.class29_1.method_0();
					}
					this.class29_1 = @class;
					try
					{
						Class30.byte_0 = this.method_10(string_9 + "\\" + class29_2.string_8);
					}
					catch
					{
					}
					return true;
				}
				catch
				{
					return false;
				}
			}
			return false;
		}
		string searchPattern = "*.license";
		if (class29_2.string_8.Length > 0)
		{
			searchPattern = class29_2.string_8;
		}
		string[] files = Directory.GetFiles(string_9, searchPattern);
		for (int l = 0; l < files.Length; l++)
		{
			try
			{
				Class10.Class29 class5 = new Class10.Class29();
				class5.method_20(files[l], class29_2.bool_3, class29_2);
				bool flag2 = true;
				for (int m = 0; m < class5.class18_0.method_4().Length; m++)
				{
					if (class29_2.class18_0.method_4()[m] != class5.class18_0.method_4()[m])
					{
						flag2 = false;
					}
				}
				if (class5.class18_0.method_4().Length < 32)
				{
					flag2 = false;
				}
				if (flag2)
				{
					if (class5.bool_59)
					{
						Class30.string_0 = Class10.Class11.smethod_11();
						Class30.string_1 = Class10.Class11.smethod_1(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_2 = Class10.Class11.smethod_2(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_3 = Class10.Class11.KefSrjlCea(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_4 = Class10.Class11.smethod_3(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_5 = Class10.Class11.smethod_5(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_6 = Class10.Class11.smethod_4(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_7 = Class10.Class11.smethod_0();
						if (Class30.string_7 == "{nohid-22222-10001-00000}")
						{
							Class30.string_7 = Class30.string_5;
						}
						if (class5.class21_0 == null)
						{
							if (class5.string_21.Length <= 0)
							{
								class5.method_0();
								return false;
							}
							if (!Class10.Class11.smethod_9(class5.string_21, class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45) && !(Class30.string_0.ToString() == class5.string_21.ToString()) && !(Class30.string_1.ToString() == class5.string_21.ToString()) && !(Class30.string_2.ToString() == class5.string_21.ToString()) && !(Class30.string_3.ToString() == class5.string_21.ToString()) && !(Class30.string_4.ToString() == class5.string_21.ToString()) && !(Class30.string_5.ToString() == class5.string_21.ToString()) && !(Class30.string_6.ToString() == class5.string_21.ToString()) && !(Class30.string_7.ToString() == class5.string_21.ToString()))
							{
								class5.method_0();
								return false;
							}
							if (this.class29_1 != null)
							{
								this.class29_1.method_0();
							}
							this.class29_1 = class5;
							try
							{
								Class30.byte_0 = this.method_10(files[l]);
							}
							catch
							{
							}
							return true;
						}
						else if (class5.string_21.Length > 0)
						{
							if (!Class10.Class11.smethod_9(class5.string_21, class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45) && !(Class30.string_0.ToString() == class5.string_21.ToString()) && !(Class30.string_1.ToString() == class5.string_21.ToString()) && !(Class30.string_2.ToString() == class5.string_21.ToString()) && !(Class30.string_3.ToString() == class5.string_21.ToString()) && !(Class30.string_4.ToString() == class5.string_21.ToString()) && !(Class30.string_5.ToString() == class5.string_21.ToString()) && !(Class30.string_6.ToString() == class5.string_21.ToString()) && !(Class30.string_7.ToString() == class5.string_21.ToString()))
							{
								class5.method_0();
								return false;
							}
							if (this.class29_1 != null)
							{
								this.class29_1.method_0();
							}
							this.class29_1 = class5;
							try
							{
								Class30.byte_0 = this.method_10(files[l]);
							}
							catch
							{
							}
							return true;
						}
						else
						{
							Class10.Class21 class6 = Class10.smethod_29();
							if (class6.method_0().Count != class5.class21_0.method_0().Count)
							{
								class5.method_0();
								return false;
							}
							for (int n = 0; n < class6.method_0().Count; n++)
							{
								Class10.Class24 class7 = class6.method_0().method_0(n);
								Class10.Class24 class8 = class5.class21_0.method_0().method_0(n);
								if (class7.method_1() != class8.method_1())
								{
									class5.method_0();
									return false;
								}
								if (class7.Name.Trim().ToString() != class8.Name.Trim().ToString())
								{
									class5.method_0();
									return false;
								}
								for (int num = 0; num < class7.method_1(); num++)
								{
									if (class7.method_3(num).method_2() != null && class8.method_3(num).method_2() != null && class7.method_3(num).method_2().Trim().ToString() != class8.method_3(num).method_2().Trim().ToString())
									{
										class5.method_0();
										return false;
									}
								}
							}
						}
					}
					if (this.class29_1 != null)
					{
						this.class29_1.method_0();
					}
					this.class29_1 = class5;
					try
					{
						Class30.byte_0 = this.method_10(files[l]);
					}
					catch
					{
					}
					return true;
				}
				class5.method_0();
			}
			catch
			{
			}
		}
		return false;
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00029644 File Offset: 0x00027844
	private bool method_9(Class10.Class29 class29_2)
	{
		if (class29_2.string_8.Length > 0 && class29_2.string_8.IndexOf("*") < 0)
		{
			if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class29_2.string_8))
			{
				try
				{
					Class10.Class29 @class = new Class10.Class29();
					@class.method_20(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class29_2.string_8, class29_2.bool_3, class29_2);
					bool flag = true;
					for (int i = 0; i < @class.class18_0.method_4().Length; i++)
					{
						if (class29_2.class18_0.method_4()[i] != @class.class18_0.method_4()[i])
						{
							flag = false;
						}
					}
					if (@class.class18_0.method_4().Length < 32)
					{
						flag = false;
					}
					if (!flag)
					{
						@class.method_0();
						return false;
					}
					if (@class.bool_59)
					{
						Class30.string_0 = Class10.Class11.smethod_11();
						Class30.string_1 = Class10.Class11.smethod_1(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_2 = Class10.Class11.smethod_2(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_3 = Class10.Class11.KefSrjlCea(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_4 = Class10.Class11.smethod_3(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_5 = Class10.Class11.smethod_5(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_6 = Class10.Class11.smethod_4(@class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45);
						Class30.string_7 = Class10.Class11.smethod_0();
						if (Class30.string_7 == "{nohid-22222-10001-00000}")
						{
							Class30.string_7 = Class30.string_5;
						}
						if (@class.class21_0 == null)
						{
							if (@class.string_21.Length <= 0)
							{
								@class.method_0();
								return false;
							}
							if (!Class10.Class11.smethod_9(@class.string_21, @class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45) && !(Class30.string_0.ToString() == @class.string_21.ToString()) && !(Class30.string_1.ToString() == @class.string_21.ToString()) && !(Class30.string_2.ToString() == @class.string_21.ToString()) && !(Class30.string_3.ToString() == @class.string_21.ToString()) && !(Class30.string_4.ToString() == @class.string_21.ToString()) && !(Class30.string_5.ToString() == @class.string_21.ToString()) && !(Class30.string_6.ToString() == @class.string_21.ToString()) && !(Class30.string_7.ToString() == @class.string_21.ToString()))
							{
								@class.method_0();
								return false;
							}
							if (this.class29_1 != null)
							{
								this.class29_1.method_0();
							}
							this.class29_1 = @class;
							try
							{
								Class30.byte_0 = this.method_10(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class29_2.string_8);
							}
							catch
							{
							}
							return true;
						}
						else if (@class.string_21.Length > 0)
						{
							if (!Class10.Class11.smethod_9(@class.string_21, @class.bool_48, @class.bool_46, @class.bool_47, @class.bool_45) && !(Class30.string_0.ToString() == @class.string_21.ToString()) && !(Class30.string_1.ToString() == @class.string_21.ToString()) && !(Class30.string_2.ToString() == @class.string_21.ToString()) && !(Class30.string_3.ToString() == @class.string_21.ToString()) && !(Class30.string_4.ToString() == @class.string_21.ToString()) && !(Class30.string_5.ToString() == @class.string_21.ToString()) && !(Class30.string_6.ToString() == @class.string_21.ToString()) && !(Class30.string_7.ToString() == @class.string_21.ToString()))
							{
								@class.method_0();
								return false;
							}
							if (this.class29_1 != null)
							{
								this.class29_1.method_0();
							}
							this.class29_1 = @class;
							try
							{
								Class30.byte_0 = this.method_10(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class29_2.string_8);
							}
							catch
							{
							}
							return true;
						}
						else
						{
							Class10.Class21 class2 = Class10.smethod_29();
							if (class2.method_0().Count != @class.class21_0.method_0().Count)
							{
								@class.method_0();
								return false;
							}
							for (int j = 0; j < class2.method_0().Count; j++)
							{
								Class10.Class24 class3 = class2.method_0().method_0(j);
								Class10.Class24 class4 = @class.class21_0.method_0().method_0(j);
								if (class3.method_1() != class4.method_1())
								{
									@class.method_0();
									return false;
								}
								if (class3.Name.Trim().ToString() != class4.Name.Trim().ToString())
								{
									@class.method_0();
									return false;
								}
								for (int k = 0; k < class3.method_1(); k++)
								{
									if (class3.method_3(k).method_2() != null && class4.method_3(k).method_2() != null && class3.method_3(k).method_2().Trim().ToString() != class4.method_3(k).method_2().Trim().ToString())
									{
										@class.method_0();
										return false;
									}
								}
							}
						}
					}
					if (this.class29_1 != null)
					{
						this.class29_1.method_0();
					}
					this.class29_1 = @class;
					try
					{
						Class30.byte_0 = this.method_10(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + class29_2.string_8);
					}
					catch
					{
					}
					return true;
				}
				catch
				{
					return false;
				}
			}
			return false;
		}
		string searchPattern = "*.license";
		if (class29_2.string_8.Length > 0)
		{
			searchPattern = class29_2.string_8;
		}
		string[] files = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath), searchPattern);
		for (int l = 0; l < files.Length; l++)
		{
			try
			{
				Class10.Class29 class5 = new Class10.Class29();
				class5.method_20(files[l], class29_2.bool_3, class29_2);
				bool flag2 = true;
				for (int m = 0; m < class5.class18_0.method_4().Length; m++)
				{
					if (class29_2.class18_0.method_4()[m] != class5.class18_0.method_4()[m])
					{
						flag2 = false;
					}
				}
				if (class5.class18_0.method_4().Length < 32)
				{
					flag2 = false;
				}
				if (flag2)
				{
					if (class5.bool_59)
					{
						Class30.string_0 = Class10.Class11.smethod_11();
						Class30.string_1 = Class10.Class11.smethod_1(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_2 = Class10.Class11.smethod_2(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_3 = Class10.Class11.KefSrjlCea(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_4 = Class10.Class11.smethod_3(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_5 = Class10.Class11.smethod_5(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_6 = Class10.Class11.smethod_4(class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45);
						Class30.string_7 = Class10.Class11.smethod_0();
						if (Class30.string_7 == "{nohid-22222-10001-00000}")
						{
							Class30.string_7 = Class30.string_5;
						}
						if (class5.class21_0 == null)
						{
							if (class5.string_21.Length <= 0)
							{
								class5.method_0();
								return false;
							}
							if (!Class10.Class11.smethod_9(class5.string_21, class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45) && !(Class30.string_0.ToString() == class5.string_21.ToString()) && !(Class30.string_1.ToString() == class5.string_21.ToString()) && !(Class30.string_2.ToString() == class5.string_21.ToString()) && !(Class30.string_3.ToString() == class5.string_21.ToString()) && !(Class30.string_4.ToString() == class5.string_21.ToString()) && !(Class30.string_5.ToString() == class5.string_21.ToString()) && !(Class30.string_6.ToString() == class5.string_21.ToString()) && !(Class30.string_7.ToString() == class5.string_21.ToString()))
							{
								class5.method_0();
								return false;
							}
							if (this.class29_1 != null)
							{
								this.class29_1.method_0();
							}
							this.class29_1 = class5;
							try
							{
								Class30.byte_0 = this.method_10(files[l]);
							}
							catch
							{
							}
							return true;
						}
						else if (class5.string_21.Length > 0)
						{
							if (!Class10.Class11.smethod_9(class5.string_21, class5.bool_48, class5.bool_46, class5.bool_47, class5.bool_45) && !(Class30.string_0.ToString() == class5.string_21.ToString()) && !(Class30.string_1.ToString() == class5.string_21.ToString()) && !(Class30.string_2.ToString() == class5.string_21.ToString()) && !(Class30.string_3.ToString() == class5.string_21.ToString()) && !(Class30.string_4.ToString() == class5.string_21.ToString()) && !(Class30.string_5.ToString() == class5.string_21.ToString()) && !(Class30.string_6.ToString() == class5.string_21.ToString()) && !(Class30.string_7.ToString() == class5.string_21.ToString()))
							{
								class5.method_0();
								return false;
							}
							if (this.class29_1 != null)
							{
								this.class29_1.method_0();
							}
							this.class29_1 = class5;
							try
							{
								Class30.byte_0 = this.method_10(files[l]);
							}
							catch
							{
							}
							return true;
						}
						else
						{
							Class10.Class21 class6 = Class10.smethod_29();
							if (class6.method_0().Count != class5.class21_0.method_0().Count)
							{
								class5.method_0();
								return false;
							}
							for (int n = 0; n < class6.method_0().Count; n++)
							{
								Class10.Class24 class7 = class6.method_0().method_0(n);
								Class10.Class24 class8 = class5.class21_0.method_0().method_0(n);
								if (class7.method_1() != class8.method_1())
								{
									class5.method_0();
									return false;
								}
								if (class7.Name.Trim().ToString() != class8.Name.Trim().ToString())
								{
									class5.method_0();
									return false;
								}
								for (int num = 0; num < class7.method_1(); num++)
								{
									if (class7.method_3(num).method_2() != null && class8.method_3(num).method_2() != null && class7.method_3(num).method_2().Trim().ToString() != class8.method_3(num).method_2().Trim().ToString())
									{
										class5.method_0();
										return false;
									}
								}
							}
						}
					}
					if (this.class29_1 != null)
					{
						this.class29_1.method_0();
					}
					this.class29_1 = class5;
					try
					{
						Class30.byte_0 = this.method_10(files[l]);
					}
					catch
					{
					}
					return true;
				}
				class5.method_0();
			}
			catch
			{
			}
		}
		return false;
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0002A428 File Offset: 0x00028628
	private byte[] method_10(string string_9)
	{
		FileStream fileStream = new FileStream(string_9, FileMode.Open, FileAccess.Read);
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		fileStream.Close();
		return array;
	}

	// Token: 0x0600035D RID: 861
	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern bool TerminateProcess(IntPtr intptr_0, int int_6);

	// Token: 0x0600035E RID: 862
	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
	internal static extern IntPtr GetCurrentProcess();

	// Token: 0x0600035F RID: 863 RVA: 0x00003CA4 File Offset: 0x00001EA4
	public Class30()
	{
		Class8.ah6VSoGzeNXX5();
		this.class29_1 = new Class10.Class29();
		base..ctor();
	}

	// Token: 0x06000360 RID: 864 RVA: 0x0002A460 File Offset: 0x00028660
	static Class30()
	{
		Class8.ah6VSoGzeNXX5();
		Class30.class29_0 = null;
		Class30.int_0 = 0;
		Class30.int_1 = 1;
		Class30.int_2 = 1;
		Class30.int_3 = 1;
		Class30.string_0 = "";
		Class30.string_1 = "";
		Class30.string_2 = "";
		Class30.string_3 = "";
		Class30.string_4 = "";
		Class30.string_5 = "";
		Class30.string_6 = "";
		Class30.string_7 = "";
		Class30.int_4 = int.MaxValue;
		Class30.int_5 = 0;
		Class30.string_8 = "";
		Class30.dateTime_0 = DateTime.Now;
		Class30.dateTime_1 = DateTime.Now;
		Class30.bool_0 = false;
		Class30.bool_1 = false;
		Class30.bool_2 = false;
		Class30.class34_0 = null;
		Class30.byte_0 = new byte[0];
	}

	// Token: 0x04000292 RID: 658
	internal static Class10.Class29 class29_0;

	// Token: 0x04000293 RID: 659
	private System.Threading.Timer timer_0;

	// Token: 0x04000294 RID: 660
	private System.Threading.Timer timer_1;

	// Token: 0x04000295 RID: 661
	private Type type_0;

	// Token: 0x04000296 RID: 662
	private Class10.Class29 class29_1;

	// Token: 0x04000297 RID: 663
	private static int int_0;

	// Token: 0x04000298 RID: 664
	private static int int_1;

	// Token: 0x04000299 RID: 665
	private static int int_2;

	// Token: 0x0400029A RID: 666
	private static int int_3;

	// Token: 0x0400029B RID: 667
	private static string string_0;

	// Token: 0x0400029C RID: 668
	private static string string_1;

	// Token: 0x0400029D RID: 669
	private static string string_2;

	// Token: 0x0400029E RID: 670
	private static string string_3;

	// Token: 0x0400029F RID: 671
	private static string string_4;

	// Token: 0x040002A0 RID: 672
	private static string string_5;

	// Token: 0x040002A1 RID: 673
	private static string string_6;

	// Token: 0x040002A2 RID: 674
	private static string string_7;

	// Token: 0x040002A3 RID: 675
	private static int int_4;

	// Token: 0x040002A4 RID: 676
	private static int int_5;

	// Token: 0x040002A5 RID: 677
	private static string string_8;

	// Token: 0x040002A6 RID: 678
	private static DateTime dateTime_0;

	// Token: 0x040002A7 RID: 679
	private static DateTime dateTime_1;

	// Token: 0x040002A8 RID: 680
	private static bool bool_0;

	// Token: 0x040002A9 RID: 681
	private static bool bool_1;

	// Token: 0x040002AA RID: 682
	private static bool bool_2;

	// Token: 0x040002AB RID: 683
	private static Class30.Class34 class34_0;

	// Token: 0x040002AC RID: 684
	private static byte[] byte_0;

	// Token: 0x0200004F RID: 79
	internal sealed class Class31
	{
		// Token: 0x06000361 RID: 865 RVA: 0x00003CBC File Offset: 0x00001EBC
		public Class31()
		{
			Class8.ah6VSoGzeNXX5();
			this.int_0 = 32;
			base..ctor();
			this.method_0(Environment.TickCount);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00003CDC File Offset: 0x00001EDC
		public Class31(int int_1)
		{
			Class8.ah6VSoGzeNXX5();
			this.int_0 = 32;
			base..ctor();
			this.method_0(int_1);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00003CF8 File Offset: 0x00001EF8
		public void method_0(int int_1)
		{
			this.uint_0 = (uint)int_1;
			this.uint_1 = 842502087U;
			this.uint_2 = 3579807591U;
			this.uint_3 = 273326509U;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0002A534 File Offset: 0x00028734
		public uint method_1()
		{
			uint num = this.uint_0 ^ this.uint_0 << 11;
			this.uint_0 = this.uint_1;
			this.uint_1 = this.uint_2;
			this.uint_2 = this.uint_3;
			return this.uint_3 = (this.uint_3 ^ this.uint_3 >> 19 ^ (num ^ num >> 8));
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0002A598 File Offset: 0x00028798
		public int method_2()
		{
			uint num = this.uint_0 ^ this.uint_0 << 11;
			this.uint_0 = this.uint_1;
			this.uint_1 = this.uint_2;
			this.uint_2 = this.uint_3;
			return (int)(2147483647U & (this.uint_3 = (this.uint_3 ^ this.uint_3 >> 19 ^ (num ^ num >> 8))));
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0002A600 File Offset: 0x00028800
		public int method_3(int int_1)
		{
			if (int_1 < 0)
			{
				throw new ArgumentOutOfRangeException("upperBound", int_1, "upperBound must be >=0");
			}
			uint num = this.uint_0 ^ this.uint_0 << 11;
			this.uint_0 = this.uint_1;
			this.uint_1 = this.uint_2;
			this.uint_2 = this.uint_3;
			return (int)(4.656612873077393E-10 * (double)(2147483647U & (this.uint_3 = (this.uint_3 ^ this.uint_3 >> 19 ^ (num ^ num >> 8)))) * (double)int_1);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0002A690 File Offset: 0x00028890
		public int method_4(int int_1, int int_2)
		{
			if (int_1 > int_2)
			{
				throw new ArgumentOutOfRangeException("upperBound", int_2, "upperBound must be >=lowerBound");
			}
			uint num = this.uint_0 ^ this.uint_0 << 11;
			this.uint_0 = this.uint_1;
			this.uint_1 = this.uint_2;
			this.uint_2 = this.uint_3;
			int num2 = int_2 - int_1;
			if (num2 < 0)
			{
				return int_1 + (int)(2.3283064365386963E-10 * (this.uint_3 = (this.uint_3 ^ this.uint_3 >> 19 ^ (num ^ num >> 8))) * (double)((long)int_2 - (long)int_1));
			}
			return int_1 + (int)(4.656612873077393E-10 * (double)(2147483647U & (this.uint_3 = (this.uint_3 ^ this.uint_3 >> 19 ^ (num ^ num >> 8)))) * (double)num2);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0002A760 File Offset: 0x00028960
		public double method_5()
		{
			uint num = this.uint_0 ^ this.uint_0 << 11;
			this.uint_0 = this.uint_1;
			this.uint_1 = this.uint_2;
			this.uint_2 = this.uint_3;
			return 4.656612873077393E-10 * (double)(2147483647U & (this.uint_3 = (this.uint_3 ^ this.uint_3 >> 19 ^ (num ^ num >> 8))));
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0002A7D4 File Offset: 0x000289D4
		public void method_6(byte[] byte_0)
		{
			uint num = this.uint_0;
			uint num2 = this.uint_1;
			uint num3 = this.uint_2;
			uint num4 = this.uint_3;
			int i = 0;
			while (i < byte_0.Length - 3)
			{
				uint num5 = num ^ num << 11;
				num = num2;
				num2 = num3;
				num3 = num4;
				num4 = (num4 ^ num4 >> 19 ^ (num5 ^ num5 >> 8));
				byte_0[i++] = (byte)(num4 & 255U);
				byte_0[i++] = (byte)((num4 & 65280U) >> 8);
				byte_0[i++] = (byte)((num4 & 16711680U) >> 16);
				byte_0[i++] = (byte)((num4 & 4278190080U) >> 24);
			}
			if (i < byte_0.Length)
			{
				uint num5 = num ^ num << 11;
				num = num2;
				num2 = num3;
				num3 = num4;
				num4 = (num4 ^ num4 >> 19 ^ (num5 ^ num5 >> 8));
				byte_0[i++] = (byte)(num4 & 255U);
				if (i < byte_0.Length)
				{
					byte_0[i++] = (byte)((num4 & 65280U) >> 8);
					if (i < byte_0.Length)
					{
						byte_0[i++] = (byte)((num4 & 16711680U) >> 16);
						if (i < byte_0.Length)
						{
							byte_0[i] = (byte)((num4 & 4278190080U) >> 24);
						}
					}
				}
			}
			this.uint_0 = num;
			this.uint_1 = num2;
			this.uint_2 = num3;
			this.uint_3 = num4;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0002A910 File Offset: 0x00028B10
		public bool method_7()
		{
			if (this.int_0 == 32)
			{
				uint num = this.uint_0 ^ this.uint_0 << 11;
				this.uint_0 = this.uint_1;
				this.uint_1 = this.uint_2;
				this.uint_2 = this.uint_3;
				this.uint_4 = (this.uint_3 = (this.uint_3 ^ this.uint_3 >> 19 ^ (num ^ num >> 8)));
				this.int_0 = 1;
				return (this.uint_4 & 1U) == 1U;
			}
			this.int_0++;
			return ((this.uint_4 >>= 1) & 1U) == 1U;
		}

		// Token: 0x040002AD RID: 685
		private uint uint_0;

		// Token: 0x040002AE RID: 686
		private uint uint_1;

		// Token: 0x040002AF RID: 687
		private uint uint_2;

		// Token: 0x040002B0 RID: 688
		private uint uint_3;

		// Token: 0x040002B1 RID: 689
		private uint uint_4;

		// Token: 0x040002B2 RID: 690
		private int int_0;
	}

	// Token: 0x02000050 RID: 80
	private class Class32
	{
		// Token: 0x0600036B RID: 875 RVA: 0x00003D22 File Offset: 0x00001F22
		private void method_0()
		{
			LicenseManager.Validate(typeof(Class30));
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00002402 File Offset: 0x00000602
		public Class32()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
		}
	}

	// Token: 0x02000051 RID: 81
	private class Class33 : License
	{
		// Token: 0x0600036D RID: 877 RVA: 0x00003D34 File Offset: 0x00001F34
		public Class33(object object_1, string string_1)
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
			this.object_0 = object_1;
			this.string_0 = string_1;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00003D4F File Offset: 0x00001F4F
		public override string LicenseKey
		{
			get
			{
				return this.string_0;
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00002E41 File Offset: 0x00001041
		public override void Dispose()
		{
		}

		// Token: 0x040002B3 RID: 691
		private object object_0;

		// Token: 0x040002B4 RID: 692
		private string string_0;
	}

	// Token: 0x02000052 RID: 82
	private class Class34
	{
		// Token: 0x06000370 RID: 880 RVA: 0x00003D57 File Offset: 0x00001F57
		public Class34()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
			Class30.Class34.timer_0 = new System.Threading.Timer(new TimerCallback(this.method_0), null, 90000, 30000);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0002A9B8 File Offset: 0x00028BB8
		internal void method_0(object object_0)
		{
			Class30.Class34.timer_0.Dispose();
			try
			{
				Class30.TerminateProcess(Class30.GetCurrentProcess(), 1);
			}
			catch
			{
			}
		}

		// Token: 0x040002B5 RID: 693
		internal static System.Threading.Timer timer_0;
	}
}
