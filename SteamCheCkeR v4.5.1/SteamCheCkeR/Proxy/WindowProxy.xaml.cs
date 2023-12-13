using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.Win32;
using Xceed.Wpf.Toolkit;

namespace SteamCheCkeR.Proxy
{
	// Token: 0x02000003 RID: 3
	public partial class WindowProxy : Window
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00004020 File Offset: 0x00002220
		public WindowProxy(object proxyClassSender)
		{
			Class8.ah6VSoGzeNXX5();
			this.list_0 = new List<string>();
			this.list_1 = new List<string>();
			this.list_2 = new List<string>();
			this.list_3 = new List<string>();
			this.eqtfyLqxs = new List<string>();
			this.timer_0 = new System.Windows.Forms.Timer();
			this.timer_1 = new System.Windows.Forms.Timer();
			base..ctor();
			this.InitializeComponent();
			this.object_0 = proxyClassSender;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00004094 File Offset: 0x00002294
		private void method_0(object sender, RoutedEventArgs e)
		{
			this.list_0 = (List<string>)this.object_0.GetType().InvokeMember("GetHttpUrlList", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
			this.list_1 = (List<string>)this.object_0.GetType().InvokeMember("GetSock5UrlList", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
			this.list_2 = (List<string>)this.object_0.GetType().InvokeMember("GetHttpProxyList", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
			this.list_3 = (List<string>)this.object_0.GetType().InvokeMember("GetSock5ProxyList", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
			this.eqtfyLqxs = (List<string>)this.object_0.GetType().InvokeMember("GetSock4ProxyList", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
			this.method_1();
			foreach (string newItem in this.list_0)
			{
				this.listBoxHttpProxyList.Items.Add(newItem);
			}
			foreach (string newItem2 in this.list_1)
			{
				this.listBoxSocksProxyList.Items.Add(newItem2);
			}
			this.checkBoxUpdateProxyFromFile.IsChecked = new bool?((bool)this.object_0.GetType().InvokeMember("GetUpdateFromFile", BindingFlags.InvokeMethod, null, this.object_0, new object[0]));
			this.checkBoxUpdateProxyFromUrl.IsChecked = new bool?((bool)this.object_0.GetType().InvokeMember("GetUpdateFromUrl", BindingFlags.InvokeMethod, null, this.object_0, new object[0]));
			this.numericUpdTime.Text = ((int)this.object_0.GetType().InvokeMember("GetTimerUpdTimeMin", BindingFlags.InvokeMethod, null, this.object_0, new object[0])).ToString();
			if (this.checkBoxUpdateProxyFromFile.IsChecked.Value || this.checkBoxUpdateProxyFromUrl.IsChecked.Value)
			{
				this.numericUpdTime.IsReadOnly = false;
			}
			this.timer_0.Interval = 500;
			this.timer_0.Tick += this.timer_0_Tick;
			this.timer_1.Interval = 500;
			this.timer_1.Tick += this.timer_1_Tick;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000022BC File Offset: 0x000004BC
		private void timer_0_Tick(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.labelHttpProxyCount.Foreground = Brushes.Red;
				this.bool_0 = true;
				return;
			}
			this.labelHttpProxyCount.Foreground = Brushes.White;
			this.bool_0 = false;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000022F5 File Offset: 0x000004F5
		private void timer_1_Tick(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				this.labelSocks5ProxyCount.Foreground = Brushes.Red;
				this.bool_0 = true;
				return;
			}
			this.labelSocks5ProxyCount.Foreground = Brushes.White;
			this.bool_0 = false;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00004380 File Offset: 0x00002580
		private void method_1()
		{
			this.labelAllProxyCount.Content = (string)this.object_0.GetType().InvokeMember("AllProxyString", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
			this.labelHttpProxyCount.Content = ((List<string>)this.object_0.GetType().InvokeMember("GetHttpProxyList", BindingFlags.InvokeMethod, null, this.object_0, new object[0])).Count;
			this.labelSocks5ProxyCount.Content = ((List<string>)this.object_0.GetType().InvokeMember("GetSock5ProxyList", BindingFlags.InvokeMethod, null, this.object_0, new object[0])).Count;
			this.labelSocks4ProxyCount.Content = ((List<string>)this.object_0.GetType().InvokeMember("GetSock4ProxyList", BindingFlags.InvokeMethod, null, this.object_0, new object[0])).Count;
			this.labelSocksUrlCount.Content = this.list_1.Count;
			this.labelHttpUrlCount.Content = this.list_0.Count;
			this.object_0.GetType().InvokeMember("SaveConfig", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000044E8 File Offset: 0x000026E8
		private void ButonAddHttpProxy_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openFileDialog.Title = "Выберите файл Http(S) вида proxy:port";
			openFileDialog.Filter = "text file | *.txt";
			if (openFileDialog.ShowDialog().Value)
			{
				bool flag = (bool)this.object_0.GetType().InvokeMember("SetPatchToHttpFile", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					openFileDialog.FileName
				});
				this.object_0.GetType().InvokeMember("LoadProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					false,
					false
				});
				this.method_1();
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000045A8 File Offset: 0x000027A8
		private void ButonAddSocks5Proxy_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openFileDialog.Title = "Выберите файл Socks5(S) вида proxy:port";
			openFileDialog.Filter = "text file | *.txt";
			if (openFileDialog.ShowDialog().Value)
			{
				bool flag = (bool)this.object_0.GetType().InvokeMember("SetPatchToSocks5File", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					openFileDialog.FileName
				});
				this.object_0.GetType().InvokeMember("LoadProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					false,
					false
				});
				this.method_1();
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00004668 File Offset: 0x00002868
		private void RnpdOntkg(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openFileDialog.Title = "Выберите файл Socks4(S) вида proxy:port";
			openFileDialog.Filter = "text file | *.txt";
			if (openFileDialog.ShowDialog().Value)
			{
				bool flag = (bool)this.object_0.GetType().InvokeMember("SetPatchToSocks4File", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					openFileDialog.FileName
				});
				this.object_0.GetType().InvokeMember("LoadProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					false,
					false
				});
				this.method_1();
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00004728 File Offset: 0x00002928
		private void checkBoxUpdateProxyFromFile_Click(object sender, RoutedEventArgs e)
		{
			if (!this.checkBoxUpdateProxyFromFile.IsChecked.Value && !this.checkBoxUpdateProxyFromUrl.IsChecked.Value)
			{
				if (!this.checkBoxUpdateProxyFromFile.IsChecked.Value)
				{
					bool flag = (bool)this.object_0.GetType().InvokeMember("SetUpdateFromFile", BindingFlags.InvokeMethod, null, this.object_0, new object[]
					{
						false
					});
				}
				if (!this.checkBoxUpdateProxyFromUrl.IsChecked.Value)
				{
					bool flag2 = (bool)this.object_0.GetType().InvokeMember("SetUpdateFromUrl", BindingFlags.InvokeMethod, null, this.object_0, new object[]
					{
						false
					});
				}
				this.numericUpdTime.IsReadOnly = true;
			}
			else
			{
				this.numericUpdTime.IsReadOnly = false;
				if (this.checkBoxUpdateProxyFromFile.IsChecked.Value)
				{
					bool flag3 = (bool)this.object_0.GetType().InvokeMember("SetUpdateFromFile", BindingFlags.InvokeMethod, null, this.object_0, new object[]
					{
						true
					});
				}
				else
				{
					bool flag4 = (bool)this.object_0.GetType().InvokeMember("SetUpdateFromFile", BindingFlags.InvokeMethod, null, this.object_0, new object[]
					{
						false
					});
				}
				if (this.checkBoxUpdateProxyFromUrl.IsChecked.Value)
				{
					bool flag5 = (bool)this.object_0.GetType().InvokeMember("SetUpdateFromUrl", BindingFlags.InvokeMethod, null, this.object_0, new object[]
					{
						true
					});
				}
				else
				{
					bool flag6 = (bool)this.object_0.GetType().InvokeMember("SetUpdateFromUrl", BindingFlags.InvokeMethod, null, this.object_0, new object[]
					{
						false
					});
				}
			}
			this.object_0.GetType().InvokeMember("SaveConfig", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00004964 File Offset: 0x00002B64
		private void method_2(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.numericUpdTime.Text))
			{
				this.numericUpdTime.Text = "30";
				return;
			}
			int num = 30;
			if (!int.TryParse(this.numericUpdTime.Text, out num))
			{
				System.Windows.MessageBox.Show("Некорректное Значение!!!", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Hand);
				this.numericUpdTime.Text = "30";
				return;
			}
			if (num <= 0)
			{
				System.Windows.MessageBox.Show("Некорректное Значение!!!", "Ошибка!!!", MessageBoxButton.OK, MessageBoxImage.Hand);
				this.numericUpdTime.Text = "30";
				bool flag = (bool)this.object_0.GetType().InvokeMember("SetTimerUpdTimeMin", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					30
				});
				return;
			}
			try
			{
				bool flag2 = (bool)this.object_0.GetType().InvokeMember("SetTimerUpdTimeMin", BindingFlags.InvokeMethod, null, this.object_0, new object[]
				{
					num
				});
				this.method_1();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00004A84 File Offset: 0x00002C84
		private void method_3(object sender, EventArgs e)
		{
			bool flag = (bool)this.object_0.GetType().InvokeMember("SetTimerUpdTimeMin", BindingFlags.InvokeMethod, null, this.object_0, new object[]
			{
				Convert.ToInt32(this.numericUpdTime.Text)
			});
			this.object_0.GetType().InvokeMember("SaveConfig", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00004B00 File Offset: 0x00002D00
		private void ButonAddUrlProxy_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.textBoxUrlOne.Text))
			{
				System.Windows.MessageBox.Show("Пустая ссылка!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.textBoxUrlOne.Text == "htpp://------")
			{
				System.Windows.MessageBox.Show("Пустая ссылка!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.comboBoxAddto.SelectedIndex == 0)
			{
				List<string> list = this.list_0;
				if (list.Contains(this.textBoxUrlOne.Text))
				{
					System.Windows.MessageBox.Show("Ссылка уже есть в списке!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
					return;
				}
				list.Add(this.textBoxUrlOne.Text);
				this.listBoxHttpProxyList.Items.Clear();
				using (List<string>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string newItem = enumerator.Current;
						this.listBoxHttpProxyList.Items.Add(newItem);
					}
					goto IL_17F;
				}
			}
			List<string> list2 = this.list_1;
			if (list2.Contains(this.textBoxUrlOne.Text))
			{
				System.Windows.MessageBox.Show("Ссылка уже есть в списке!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			list2.Add(this.textBoxUrlOne.Text);
			this.listBoxSocksProxyList.Items.Clear();
			foreach (string newItem2 in list2)
			{
				this.listBoxSocksProxyList.Items.Add(newItem2);
			}
			IL_17F:
			this.method_1();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00004CB0 File Offset: 0x00002EB0
		private void listBoxHttpProxyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.listBoxHttpProxyList.SelectedIndex == -1)
			{
				return;
			}
			if (this.listBoxSocksProxyList.SelectedItems.Count > 0)
			{
				this.listBoxSocksProxyList.UnselectAll();
			}
			this.textBoxUrlOne.Text = this.listBoxHttpProxyList.SelectedItem.ToString();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00004D08 File Offset: 0x00002F08
		private void listBoxSocksProxyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.listBoxSocksProxyList.SelectedIndex == -1)
			{
				return;
			}
			if (this.listBoxHttpProxyList.SelectedItems.Count > 0)
			{
				this.listBoxHttpProxyList.UnselectAll();
			}
			this.textBoxUrlOne.Text = this.listBoxSocksProxyList.SelectedItem.ToString();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00004D60 File Offset: 0x00002F60
		private void ButonDelProxyUrl_Click(object sender, RoutedEventArgs e)
		{
			if (this.listBoxHttpProxyList.SelectedItems.Count == 0 && this.listBoxSocksProxyList.SelectedItems.Count == 0)
			{
				System.Windows.MessageBox.Show("Выберите что удалять!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.listBoxHttpProxyList.SelectedItems.Count > 0)
			{
				List<string> list = this.list_0;
				foreach (object obj in this.listBoxHttpProxyList.SelectedItems)
				{
					list.Remove(obj.ToString());
				}
				this.listBoxHttpProxyList.Items.Clear();
				foreach (string newItem in list)
				{
					this.listBoxHttpProxyList.Items.Add(newItem);
				}
			}
			if (this.listBoxSocksProxyList.SelectedItems.Count > 0)
			{
				List<string> list2 = this.list_1;
				foreach (object obj2 in this.listBoxSocksProxyList.SelectedItems)
				{
					list2.Remove(obj2.ToString());
				}
				this.listBoxSocksProxyList.Items.Clear();
				foreach (string newItem2 in list2)
				{
					this.listBoxSocksProxyList.Items.Add(newItem2);
				}
			}
			this.method_1();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00004F4C File Offset: 0x0000314C
		private void ButonCheckUrlProxy_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.textBoxUrlOne.Text))
			{
				System.Windows.MessageBox.Show("Пустая ссылка!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.textBoxUrlOne.Text == "htpp://------")
			{
				System.Windows.MessageBox.Show("Пустая ссылка!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			this.ButonCheckUrlProxy.IsEnabled = false;
			Thread thread = new Thread(new ThreadStart(this.method_4));
			thread.Start();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00004FD0 File Offset: 0x000031D0
		private void method_4()
		{
			string url = null;
			base.Dispatcher.Invoke(new MethodInvoker(delegate()
			{
				url = this.textBoxUrlOne.Text;
			}), new object[0]);
			List<string> list = (List<string>)this.object_0.GetType().InvokeMember("DownloadProxyToList", BindingFlags.InvokeMethod, null, this.object_0, new object[]
			{
				url
			});
			if (list.Count > 0)
			{
				System.Windows.MessageBox.Show("Прокси найдены! В количестве " + list.Count + "  !!!", "Результат!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
			else
			{
				System.Windows.MessageBox.Show("Не удалось обнаружить прокси!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			base.Dispatcher.Invoke(new MethodInvoker(this.method_7), new object[0]);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000050AC File Offset: 0x000032AC
		private void ButonAddHttpProxyUrl_Click(object sender, RoutedEventArgs e)
		{
			List<string> list = this.list_0;
			if (list.Count > 0)
			{
				this.ButonAddHttpProxyUrl.IsEnabled = false;
				this.ButonAddSocksProxyUrl.IsEnabled = false;
				this.timer_0.Start();
				Thread thread = new Thread(new ThreadStart(this.method_5));
				thread.Start();
				return;
			}
			System.Windows.MessageBox.Show("Нету ссылок для получения прокси!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00005118 File Offset: 0x00003318
		private void method_5()
		{
			this.object_0.GetType().InvokeMember("LoadProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[]
			{
				true,
				false
			});
			base.Dispatcher.Invoke(new MethodInvoker(this.method_8), new object[0]);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00005180 File Offset: 0x00003380
		private void ButonAddSocksProxyUrl_Click(object sender, RoutedEventArgs e)
		{
			List<string> list = this.list_1;
			if (list.Count > 0)
			{
				this.ButonAddHttpProxyUrl.IsEnabled = false;
				this.ButonAddSocksProxyUrl.IsEnabled = false;
				this.timer_1.Start();
				Thread thread = new Thread(new ThreadStart(this.method_6));
				thread.Start();
				return;
			}
			System.Windows.MessageBox.Show("Нету ссылок для получения прокси!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000051EC File Offset: 0x000033EC
		private void method_6()
		{
			this.object_0.GetType().InvokeMember("LoadProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[]
			{
				false,
				true
			});
			base.Dispatcher.Invoke(new MethodInvoker(this.method_9), new object[0]);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00005254 File Offset: 0x00003454
		private void ClearAllProxy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (System.Windows.MessageBox.Show("Вы хотите очистить все списки прокси?", "Вопросик!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				this.object_0.GetType().InvokeMember("ClearAllProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
				this.method_1();
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000232E File Offset: 0x0000052E
		private void CleaHttpProxy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (System.Windows.MessageBox.Show("Вы хотите очистить список Http(S) прокси?", "Вопросик!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				this.list_2.Clear();
				this.method_1();
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002356 File Offset: 0x00000556
		private void ClearSocks5Proxy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (System.Windows.MessageBox.Show("Вы хотите очистить список Socks5 прокси?", "Вопросик!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				this.list_3.Clear();
				this.method_1();
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000237E File Offset: 0x0000057E
		private void ClearSocks4Proxy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (System.Windows.MessageBox.Show("Вы хотите очистить список Socks4 прокси?", "Вопросик!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				this.eqtfyLqxs.Clear();
				this.method_1();
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000052A4 File Offset: 0x000034A4
		private void ButonOK_Click(object sender, RoutedEventArgs e)
		{
			bool flag = (bool)this.object_0.GetType().InvokeMember("SetTimerUpdTimeMin", BindingFlags.InvokeMethod, null, this.object_0, new object[]
			{
				this.numericUpdTime.Value.Value
			});
			this.object_0.GetType().InvokeMember("SaveConfig", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
			base.Close();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0000532C File Offset: 0x0000352C
		private void ButonClose_Click(object sender, RoutedEventArgs e)
		{
			if ((int)this.object_0.GetType().InvokeMember("AllProxyCount", BindingFlags.InvokeMethod, null, this.object_0, new object[0]) > 0)
			{
				if (System.Windows.MessageBox.Show("Вы хотите очистить все списки прокси и закрыть окно?", "Вопросик!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					this.object_0.GetType().InvokeMember("ClearAllProxy", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
					this.method_1();
					bool flag = (bool)this.object_0.GetType().InvokeMember("SetTimerUpdTimeMin", BindingFlags.InvokeMethod, null, this.object_0, new object[]
					{
						this.numericUpdTime.Value.Value
					});
					this.object_0.GetType().InvokeMember("SaveConfig", BindingFlags.InvokeMethod, null, this.object_0, new object[0]);
					base.Close();
					return;
				}
			}
			else
			{
				base.Close();
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000023A6 File Offset: 0x000005A6
		private void listBoxHttpProxyList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Delete && this.listBoxHttpProxyList.SelectedItems.Count > 0)
			{
				this.ButonDelProxyUrl_Click(null, null);
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000023CD File Offset: 0x000005CD
		private void listBoxSocksProxyList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Delete && this.listBoxSocksProxyList.SelectedItems.Count > 0)
			{
				this.ButonDelProxyUrl_Click(null, null);
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00005430 File Offset: 0x00003630
		private void cmMufXrj0(object sender, RoutedEventArgs e)
		{
			string text = System.Windows.Clipboard.GetText();
			this.textBoxUrlOne.Text = text;
			if (text.ToLower().Contains("socks"))
			{
				this.comboBoxAddto.SelectedIndex = 1;
				return;
			}
			if (text.ToLower().Contains("http"))
			{
				this.comboBoxAddto.SelectedIndex = 0;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000023F4 File Offset: 0x000005F4
		[CompilerGenerated]
		private void method_7()
		{
			this.ButonCheckUrlProxy.IsEnabled = true;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000058CC File Offset: 0x00003ACC
		[CompilerGenerated]
		private void method_8()
		{
			this.timer_0.Stop();
			this.labelHttpProxyCount.Foreground = Brushes.White;
			this.bool_0 = false;
			this.ButonAddHttpProxyUrl.IsEnabled = true;
			this.ButonAddSocksProxyUrl.IsEnabled = true;
			this.method_1();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0000591C File Offset: 0x00003B1C
		[CompilerGenerated]
		private void method_9()
		{
			this.timer_1.Stop();
			this.labelSocks5ProxyCount.Foreground = Brushes.White;
			this.bool_0 = false;
			this.ButonAddHttpProxyUrl.IsEnabled = true;
			this.ButonAddSocksProxyUrl.IsEnabled = true;
			this.method_1();
		}

		// Token: 0x04000001 RID: 1
		private object object_0;

		// Token: 0x04000002 RID: 2
		private List<string> list_0;

		// Token: 0x04000003 RID: 3
		private List<string> list_1;

		// Token: 0x04000004 RID: 4
		private List<string> list_2;

		// Token: 0x04000005 RID: 5
		private List<string> list_3;

		// Token: 0x04000006 RID: 6
		private List<string> eqtfyLqxs;

		// Token: 0x04000007 RID: 7
		private System.Windows.Forms.Timer timer_0;

		// Token: 0x04000008 RID: 8
		private System.Windows.Forms.Timer timer_1;

		// Token: 0x04000009 RID: 9
		private bool bool_0;
	}
}
