using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using JLeGNet.JLHelpers;
using Microsoft.Win32;

namespace SteamCheCkeR
{
	// Token: 0x02000012 RID: 18
	public class LogViewer : Window, IComponentConnector
	{
		// Token: 0x060000FC RID: 252 RVA: 0x00008BB4 File Offset: 0x00006DB4
		public LogViewer()
		{
			Class8.ah6VSoGzeNXX5();
			this.dictionary_0 = new Dictionary<string, LogViewer.Class3>();
			this.dictionary_1 = new Dictionary<string, LogViewer.Class3>();
			this.list_0 = new List<string>();
			this.list_1 = new List<string>();
			this.list_2 = new List<string>();
			this.string_0 = "\t\t(.*)";
			this.string_1 = "Inventory -->> Games:(.*)items:";
			this.string_3 = "http://steamcommunity.com/(id|profiles)/(.*)";
			this.string_4 = "Данные для входа:(.*)";
			this.string_5 = "Ссылка на профиль:(.*)";
			this.string_6 = "(.*)Games in Account -->>(.*)";
			this.string_7 = "\t\t(.*)";
			this.string_8 = "(.*)Inventory Game status -->>(.*)";
			this.string_9 = "Games:(.*)items: ([0-9]{1,})";
			this.string_10 = "STEAM_([0-9]{1,}):([0-9]{1,}):([0-9]{1,})";
			base..ctor();
			this.InitializeComponent();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00008C78 File Offset: 0x00006E78
		private void ButonAddAccsLog_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openFileDialog.Filter = "text files|*.txt";
			if (openFileDialog.ShowDialog() == true)
			{
				this.NickProfileLink.Content = "http://steamcommunity.com/id||profiles/XXXXXXXXXXXXXXXXXXXX";
				this.SteamID.Content = "SteamID: STEAM_x:c:xxxxxxxx [x]";
				this.LabelBanStatus.Content = "BAN status: -> OK";
				this.LabelTradeStatus.Content = "TRADE status: -> OK";
				this.LabelHideStatus.Content = "Profile status: -> Доступен";
				this.textBoxInfo.Text = "";
				this.LabelGameCount.Content = "Список игр: -> 0";
				this.LabelInventaryCount.Content = "Инвентарь: -> 0/0";
				this.dictionary_0.Clear();
				this.ListBoxLog.Items.Clear();
				this.list_0.Clear();
				this.list_2.Clear();
				this.ListBoxAllInventary.Items.Clear();
				this.ListBoxAllGames.Items.Clear();
				this.dictionary_1.Clear();
				this.CheckBoxDota.IsEnabled = false;
				this.CheckBoxDota.IsChecked = new bool?(false);
				this.groupBoxInfo.Margin = new Thickness(0.0, 0.0, 0.0, 0.0);
				this.string_2 = openFileDialog.FileName;
				string text = File.ReadAllText(this.string_2);
				string text2 = text.Replace("\r\n", "#$%^#%#$#");
				text2 = text2.Replace("Данные для входа", "\r\nДанные для входа");
				foreach (string text3 in text2.Split(new char[]
				{
					'\n'
				}))
				{
					string text4 = text3;
					if (!string.IsNullOrEmpty(text4))
					{
						text4 = text4.Replace("#$%^#%#$#", "\r\n");
						string text5 = Regex.Replace(Regex.Match(text4, "Данные для входа: (.*)").Value, "Данные для входа: (.*)", "$1");
						if (text5.Contains('\t'))
						{
							text5 = text5.Split(new char[]
							{
								'\t'
							})[0].Trim();
						}
						if (!string.IsNullOrEmpty(text5))
						{
							LogViewer.Class3 @class = new LogViewer.Class3();
							if (!this.dictionary_0.ContainsKey(text5))
							{
								@class.method_1(text5);
								@class.nvuQtwFoxe(ConverterHelper.DecodeEncodedNonAsciiCharacters(text4));
								@class.method_4(null);
								this.dictionary_0.Add(text5, @class);
								this.ListBoxLog.Items.Add(text5);
							}
							MatchCollection matchCollection = Regex.Matches(text4, this.string_0);
							foreach (object obj in matchCollection)
							{
								Match match = (Match)obj;
								string text6 = Regex.Replace(match.Value, this.string_0, "$1");
								if (!string.IsNullOrEmpty(text6) && !text6.Contains("->"))
								{
									if (text6.Contains("Цена:"))
									{
										text6 = text6.Replace("Цена:", "|").Split(new char[]
										{
											'|'
										})[0].Trim();
									}
									if (text6.Contains('\t'))
									{
										text6 = text6.Split(new char[]
										{
											'\t'
										})[0].Trim();
									}
									text6 = text6.Trim();
									if (!string.IsNullOrEmpty(text6) && !this.list_0.Contains(text6))
									{
										this.list_0.Add(text6);
									}
								}
							}
							MatchCollection matchCollection2 = Regex.Matches(text4, this.string_1);
							foreach (object obj2 in matchCollection2)
							{
								Match match2 = (Match)obj2;
								string text7 = Regex.Replace(match2.Value, this.string_1, "$1");
								if (!string.IsNullOrEmpty(text7))
								{
									text7 = text7.Trim();
									if (!string.IsNullOrEmpty(text7) && !this.list_2.Contains(text7))
									{
										this.list_2.Add(text7);
									}
								}
							}
						}
					}
				}
				this.list_0.Sort();
				foreach (string newItem in this.list_0)
				{
					this.ListBoxAllGames.Items.Add(newItem);
				}
				this.list_2.Sort();
				foreach (string newItem2 in this.list_2)
				{
					this.ListBoxAllInventary.Items.Add(newItem2);
				}
				this.labelAllAccsCountLog.Content = this.dictionary_0.Count;
				this.SaveSellerLog.IsEnabled = true;
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x000091E0 File Offset: 0x000073E0
		private void ButonAddDotaLog_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openFileDialog.Filter = "text files|*.txt";
			if (openFileDialog.ShowDialog() == true)
			{
				bool flag;
				if (!(flag = this.dictionary_0.Any<KeyValuePair<string, LogViewer.Class3>>()))
				{
					this.groupBoxInfo.Margin = new Thickness(0.0, 999.0, 999.0, 40.0);
					this.CheckBoxDota.IsEnabled = true;
					this.CheckBoxDota.IsChecked = new bool?(true);
				}
				string text = File.ReadAllText(openFileDialog.FileName);
				foreach (string text2 in text.Split(new char[]
				{
					'\n'
				}))
				{
					string input = ConverterHelper.DecodeEncodedNonAsciiCharacters(text2.Replace("itemName", "\nitemName"));
					string text3 = Regex.Replace(Regex.Match(input, "UserEmail:(.*)\\|").Value, "UserEmail:(.*)\\|", "$1");
					if (!string.IsNullOrEmpty(text3))
					{
						string pattern = "itemName:(.*)\\|itemColor:(.*)\\|itemIcon:(.*)\\|itemQualityName:(.*)\\|itemQualityColor:(.*)\\|itemRarityName:(.*)\\|itemRarityColor:(.*)";
						MatchCollection matchCollection = Regex.Matches(input, pattern);
						List<LogViewer.DotaItemClas> list = new List<LogViewer.DotaItemClas>();
						foreach (object obj in matchCollection)
						{
							Match match = (Match)obj;
							if (!string.IsNullOrEmpty(match.Value))
							{
								string text4 = Regex.Replace(match.Value, pattern, "$1");
								string text5 = Regex.Replace(match.Value, pattern, "$2");
								string text6 = Regex.Replace(match.Value, pattern, "$3");
								string text7 = Regex.Replace(match.Value, pattern, "$4");
								string text8 = Regex.Replace(match.Value, pattern, "$5");
								string text9 = Regex.Replace(match.Value, pattern, "$6");
								string text10 = Regex.Replace(match.Value, pattern, "$7");
								if (!string.IsNullOrEmpty(text4) && !string.IsNullOrEmpty(text5) && !string.IsNullOrEmpty(text6) && !string.IsNullOrEmpty(text7) && !string.IsNullOrEmpty(text8) && !string.IsNullOrEmpty(text9) && !string.IsNullOrEmpty(text10))
								{
									list.Add(new LogViewer.DotaItemClas
									{
										name = text4,
										nameColor = text5,
										icon_url = text6,
										qualityName = text7,
										qualityColor = text8,
										rarityName = text9,
										rarityColor = text10
									});
									if (!this.list_1.Contains(text4))
									{
										this.list_1.Add(text4);
									}
								}
							}
						}
						if (this.dictionary_0.ContainsKey(text3))
						{
							this.dictionary_0[text3].method_4(ConverterHelper.DecodeEncodedNonAsciiCharacters(text2));
							this.dictionary_0[text3].method_6(list);
						}
						else if (!flag)
						{
							LogViewer.Class3 @class = new LogViewer.Class3();
							if (!this.dictionary_0.ContainsKey(text3))
							{
								@class.method_1(text3);
								@class.nvuQtwFoxe(ConverterHelper.DecodeEncodedNonAsciiCharacters(text3));
								@class.method_4(null);
								this.dictionary_0.Add(text3, @class);
								@class.method_4(text2);
								@class.method_6(list);
								this.ListBoxLog.Items.Add(text3);
							}
						}
					}
				}
				this.list_1.Sort();
				foreach (string newItem in this.list_1)
				{
					this.ListBoxAllItems.Items.Add(newItem);
				}
				this.labelAllAccsCountLog.Content = this.dictionary_0.Count;
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000960C File Offset: 0x0000780C
		private void ListBoxLog_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.ListBoxLog.SelectedIndex == -1)
			{
				return;
			}
			this.checkBoxUnselect.IsChecked = new bool?(false);
			string text = this.ListBoxLog.SelectedItem.ToString();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (!this.dictionary_0.ContainsKey(text))
			{
				return;
			}
			if (string.IsNullOrEmpty(this.dictionary_0[text].method_2()))
			{
				this.CheckBoxDota.IsEnabled = true;
				this.method_0();
				return;
			}
			string text2 = this.dictionary_0[text].method_2();
			string value = this.dictionary_0[text].method_3();
			if (this.dictionary_0[text].method_5().Any<LogViewer.DotaItemClas>())
			{
				this.CheckBoxDota.IsEnabled = true;
			}
			else
			{
				this.CheckBoxDota.IsEnabled = false;
				this.CheckBoxDota.IsChecked = new bool?(false);
				this.groupBoxInfo.Margin = new Thickness(0.0, 0.0, 0.0, 0.0);
			}
			MatchCollection matchCollection = Regex.Matches(text2, this.string_0);
			MatchCollection matchCollection2 = Regex.Matches(text2, this.string_1);
			text2 = text2.Replace("-->> SteamID:", "\r\n-->> SteamID:");
			text2 = text2.Replace("\t", "");
			this.textBoxInfo.Text = text2.Replace("=======================================================", "");
			string value2 = Regex.Match(text2, this.string_3).Value;
			if (!string.IsNullOrEmpty(value2))
			{
				this.NickProfileLink.Content = value2;
			}
			else
			{
				this.NickProfileLink.Content = "http://steamcommunity.com/id||profiles/XXXXXXXXXXXXXXXXXXXX";
			}
			if (matchCollection.Count > 0)
			{
				this.LabelGameCount.Content = "Список игр: -> " + matchCollection.Count.ToString();
			}
			else
			{
				this.LabelGameCount.Content = "Список игр: -> 0";
			}
			if (matchCollection2.Count > 0)
			{
				int num = 0;
				if (Regex.IsMatch(text2, this.string_9))
				{
					MatchCollection matchCollection3 = Regex.Matches(text2, this.string_9);
					foreach (object obj in matchCollection3)
					{
						Match match = (Match)obj;
						string s = Regex.Replace(match.Value, this.string_9, "$2").Trim();
						int num2 = 0;
						if (int.TryParse(s, out num2))
						{
							num += num2;
						}
					}
				}
				this.LabelInventaryCount.Content = string.Format("Инвентарь: -> {0}/{1}", matchCollection2.Count.ToString(), num);
			}
			else
			{
				this.LabelInventaryCount.Content = "Инвентарь: -> 0/0";
			}
			string value3 = Regex.Match(text2, "STEAM_(.*)\\[([0-9]{1})\\]").Value;
			if (!string.IsNullOrEmpty(value3))
			{
				this.SteamID.Content = value3;
			}
			else
			{
				this.SteamID.Content = "SteamID: STEAM_x:c:xxxxxxxx [x]";
			}
			if (text2.Contains("Профиль пользователя заблокирован"))
			{
				this.LabelBanStatus.Content = "BAN status: -> BAD";
				this.LabelBanStatus.Foreground = new SolidColorBrush(Colors.Red);
			}
			else
			{
				this.LabelBanStatus.Content = "BAN status: -> OK";
				this.LabelBanStatus.Foreground = new SolidColorBrush(Colors.White);
			}
			if (text2.Contains("Trade Статус: заблокирован"))
			{
				this.LabelTradeStatus.Content = "TRADE status: -> BAD";
				this.LabelTradeStatus.Foreground = new SolidColorBrush(Colors.Red);
			}
			else
			{
				this.LabelTradeStatus.Content = "TRADE status: -> OK";
				this.LabelTradeStatus.Foreground = new SolidColorBrush(Colors.White);
			}
			if (text2.Contains("Trade Статус: заблокирован"))
			{
				this.LabelHideStatus.Content = "Profile status: -> СКРЫТ";
				this.LabelHideStatus.Foreground = new SolidColorBrush(Colors.Red);
			}
			else if (text2.Contains("Профиль пользователя  не настроен"))
			{
				this.LabelHideStatus.Content = "Profile status: -> Не настроен";
				this.LabelHideStatus.Foreground = new SolidColorBrush(Colors.Red);
			}
			else
			{
				this.LabelHideStatus.Content = "Profile status: -> Доступен";
				this.LabelHideStatus.Foreground = new SolidColorBrush(Colors.White);
			}
			this.dataGridDota.Items.Clear();
			if (!string.IsNullOrEmpty(value))
			{
				foreach (LogViewer.DotaItemClas dotaItemClas in this.dictionary_0[text].method_5())
				{
					LogViewer.DotaDataClas dotaDataClas = new LogViewer.DotaDataClas();
					dotaDataClas.name = dotaItemClas.name;
					dotaDataClas.qualityName = dotaItemClas.qualityName;
					dotaDataClas.rarityName = dotaItemClas.rarityName;
					this.dataGridDota.Items.Add(dotaDataClas);
				}
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00009B08 File Offset: 0x00007D08
		private void method_0()
		{
			if (this.ListBoxLog.SelectedIndex == -1)
			{
				return;
			}
			string text = this.ListBoxLog.SelectedItem.ToString();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (!this.dictionary_0.ContainsKey(text))
			{
				return;
			}
			string value = this.dictionary_0[text].method_3();
			if (!string.IsNullOrEmpty(value))
			{
				foreach (LogViewer.DotaItemClas dotaItemClas in this.dictionary_0[text].method_5())
				{
					LogViewer.DotaDataClas dotaDataClas = new LogViewer.DotaDataClas();
					dotaDataClas.name = dotaItemClas.name;
					dotaDataClas.qualityName = dotaItemClas.qualityName;
					dotaDataClas.rarityName = dotaItemClas.rarityName;
					this.dataGridDota.Items.Add(dotaDataClas);
				}
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00009BF4 File Offset: 0x00007DF4
		private void ButtonSbros_Click(object sender, RoutedEventArgs e)
		{
			this.dictionary_1.Clear();
			this.ListBoxLog.Items.Clear();
			foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair in this.dictionary_0)
			{
				this.ListBoxLog.Items.Add(keyValuePair.Key);
			}
			this.ListBoxAllGames.UnselectAll();
			this.ListBoxAllInventary.UnselectAll();
			this.ListBoxAllItems.UnselectAll();
			this.labelAllAccsCountLog.Content = this.dictionary_0.Count;
			this.NickProfileLink.Content = "http://steamcommunity.com/id||profiles/XXXXXXXXXXXXXXXXXXXX";
			this.SteamID.Content = "SteamID: STEAM_x:c:xxxxxxxx [x]";
			this.LabelBanStatus.Content = "BAN status: -> OK";
			this.LabelTradeStatus.Content = "TRADE status: -> OK";
			this.LabelHideStatus.Content = "Profile status: -> Доступен";
			this.LabelGameCount.Content = "Список игр: -> 0";
			this.LabelInventaryCount.Content = "Инвентарь: -> 0/0";
			this.textBoxInfo.Text = "";
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00009D30 File Offset: 0x00007F30
		private void ButtonViborka_Click(object sender, RoutedEventArgs e)
		{
			this.dictionary_1.Clear();
			if (this.ListBoxAllGames.SelectedIndex == -1 && this.ListBoxAllInventary.SelectedIndex == -1 && this.ListBoxAllItems.SelectedIndex == -1)
			{
				System.Windows.MessageBox.Show("Сначала выберити критерии отбора!", "Ошибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (this.CheckBoxDota.IsChecked == true)
			{
				this.method_1();
				return;
			}
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			foreach (object obj in this.ListBoxAllGames.SelectedItems)
			{
				if (!string.IsNullOrEmpty(obj.ToString()))
				{
					list.Add(obj.ToString());
				}
			}
			foreach (object obj2 in this.ListBoxAllInventary.SelectedItems)
			{
				if (!string.IsNullOrEmpty(obj2.ToString()))
				{
					list2.Add(obj2.ToString());
				}
			}
			if (list.Count == 0 && list2.Count == 0)
			{
				System.Windows.MessageBox.Show("Нету аккаунтов с заданными критериями!", "Ошибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair in this.dictionary_0)
			{
				string text = keyValuePair.Value.method_2();
				string key = keyValuePair.Key;
				if (!string.IsNullOrEmpty(text))
				{
					foreach (string value in list)
					{
						if (text.Contains(value) && !this.dictionary_1.ContainsKey(key))
						{
							this.dictionary_1.Add(keyValuePair.Key, keyValuePair.Value);
						}
					}
					foreach (string value2 in list2)
					{
						if (text.Contains(value2) && !this.dictionary_1.ContainsKey(key))
						{
							this.dictionary_1.Add(keyValuePair.Key, keyValuePair.Value);
						}
					}
				}
			}
			if (this.dictionary_1.Count == 0)
			{
				System.Windows.MessageBox.Show("Нету аккаунтов с заданными критериями!", "Ошибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			this.ListBoxLog.Items.Clear();
			foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair2 in this.dictionary_1)
			{
				this.ListBoxLog.Items.Add(keyValuePair2.Key);
			}
			this.labelAllAccsCountLog.Content = this.dictionary_1.Count;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000A0D8 File Offset: 0x000082D8
		private void LabelSetTextFiltr_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.dictionary_1.Clear();
			if (string.IsNullOrEmpty(this.textBoxFiltrText.Text))
			{
				System.Windows.MessageBox.Show("Сначала введите текст для фильтрации!", "Ошибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair in this.dictionary_0)
			{
				string text = keyValuePair.Value.method_2();
				string key = keyValuePair.Key;
				if (!string.IsNullOrEmpty(text) && text.Contains(this.textBoxFiltrText.Text) && !this.dictionary_1.ContainsKey(key))
				{
					this.dictionary_1.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
			if (this.dictionary_1.Count == 0)
			{
				System.Windows.MessageBox.Show("Нету аккаунтов с заданными критериями!", "Ошибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			this.ListBoxLog.Items.Clear();
			foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair2 in this.dictionary_1)
			{
				this.ListBoxLog.Items.Add(keyValuePair2.Key);
			}
			this.labelAllAccsCountLog.Content = this.dictionary_1.Count;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000A250 File Offset: 0x00008450
		private void method_1()
		{
			this.dictionary_1.Clear();
			List<string> list = new List<string>();
			foreach (object obj in this.ListBoxAllItems.SelectedItems)
			{
				if (!string.IsNullOrEmpty(obj.ToString()))
				{
					list.Add(obj.ToString());
				}
			}
			if (list.Count == 0)
			{
				System.Windows.MessageBox.Show("Нету аккаунтов с заданными критериями!", "Ошибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair in this.dictionary_0)
			{
				string text = keyValuePair.Value.method_3();
				string key = keyValuePair.Key;
				if (!string.IsNullOrEmpty(text))
				{
					foreach (string value in list)
					{
						if (text.Contains(value) && !this.dictionary_1.ContainsKey(key))
						{
							this.dictionary_1.Add(keyValuePair.Key, keyValuePair.Value);
						}
					}
				}
			}
			if (this.dictionary_1.Count == 0)
			{
				System.Windows.MessageBox.Show("Нету аккаунтов с заданными критериями!", "Ошибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			this.ListBoxLog.Items.Clear();
			foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair2 in this.dictionary_1)
			{
				this.ListBoxLog.Items.Add(keyValuePair2.Key);
			}
			this.labelAllAccsCountLog.Content = this.dictionary_1.Count;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00002AE1 File Offset: 0x00000CE1
		private void NickProfileLink_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (!this.NickProfileLink.Content.ToString().Contains("id||profiles/XXXXXXXXXXXXXXXXXXXX"))
			{
				Process.Start(this.NickProfileLink.Content.ToString());
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0000A460 File Offset: 0x00008660
		private void SaveAllAccs_Click(object sender, RoutedEventArgs e)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			if (this.dictionary_1.Count > 0)
			{
				using (Dictionary<string, LogViewer.Class3>.Enumerator enumerator = this.dictionary_1.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, LogViewer.Class3> keyValuePair = enumerator.Current;
						if (this.CheckBoxSaveAllAccsDota.IsChecked.Value)
						{
							string text = null;
							if (keyValuePair.Value.method_5().Count > 0)
							{
								if (!keyValuePair.Value.method_2().Contains("\n"))
								{
									text = "\r\nИнформация по инвентарю игры DOTA:\r\n";
								}
								else
								{
									text = "Информация по инвентарю игры DOTA:\r\n";
								}
								foreach (LogViewer.DotaItemClas dotaItemClas in keyValuePair.Value.method_5())
								{
									text = text + "\t" + dotaItemClas.name + "\r\n";
								}
							}
							list.Add(keyValuePair.Value.method_2() + text + "\r\n");
						}
						else if (!keyValuePair.Value.method_2().Contains("\n"))
						{
							list.Add(keyValuePair.Value.method_2() + "\r\n");
						}
						else
						{
							list.Add(keyValuePair.Value.method_2());
						}
						list2.Add(keyValuePair.Key);
					}
					goto IL_2CE;
				}
			}
			foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair2 in this.dictionary_0)
			{
				if (this.CheckBoxSaveAllAccsDota.IsChecked.Value)
				{
					string text2 = null;
					if (keyValuePair2.Value.method_5().Count > 0)
					{
						if (!keyValuePair2.Value.method_2().Contains("\n"))
						{
							text2 = "\r\nИнформация по инвентарю игры DOTA:\r\n";
						}
						else
						{
							text2 = "Информация по инвентарю игры DOTA:\r\n";
						}
						foreach (LogViewer.DotaItemClas dotaItemClas2 in keyValuePair2.Value.method_5())
						{
							text2 = text2 + "\t" + dotaItemClas2.name + "\r\n";
						}
					}
					list.Add(keyValuePair2.Value.method_2() + text2 + "\r\n");
				}
				else if (!keyValuePair2.Value.method_2().Contains("\n"))
				{
					list.Add(keyValuePair2.Value.method_2() + "\r\n");
				}
				else
				{
					list.Add(keyValuePair2.Value.method_2());
				}
				list2.Add(keyValuePair2.Key);
			}
			IL_2CE:
			string text3 = null;
			foreach (string str in list)
			{
				text3 += str;
			}
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			saveFileDialog.Filter = "text files|*.txt";
			if (saveFileDialog.ShowDialog() == true)
			{
				string fileName = saveFileDialog.FileName;
				File.WriteAllText(fileName, text3);
				if (System.Windows.MessageBox.Show("Все аккаунты сохранены!\r\n ХОТИТЕ УДАЛИТЬ ИХ ИЗ ВХОДНЫХ ДАННЫХ???", "Good save!", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
				{
					foreach (string key in list2)
					{
						if (this.dictionary_0.ContainsKey(key))
						{
							this.dictionary_0.Remove(key);
						}
						if (this.dictionary_1.Count > 0 && this.dictionary_1.ContainsKey(key))
						{
							this.dictionary_0.Remove(key);
						}
					}
					this.dictionary_1.Clear();
					this.ListBoxLog.Items.Clear();
					foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair3 in this.dictionary_0)
					{
						this.ListBoxLog.Items.Add(keyValuePair3.Key);
					}
					this.labelAllAccsCountLog.Content = this.dictionary_0.Count;
					try
					{
						this.NickProfileLink.Content = "http://steamcommunity.com/id||profiles/XXXXXXXXXXXXXXXXXXXX";
						this.SteamID.Content = "SteamID: STEAM_x:c:xxxxxxxx [x]";
						this.LabelBanStatus.Content = "BAN status: -> OK";
						this.LabelTradeStatus.Content = "TRADE status: -> OK";
						this.LabelHideStatus.Content = "Profile status: -> Доступен";
						this.LabelGameCount.Content = "Список игр: -> 0";
						this.LabelInventaryCount.Content = "Инвентарь: -> 0/0";
						this.textBoxInfo.Text = "";
						this.list_0.Clear();
						this.list_2.Clear();
						this.ListBoxAllInventary.Items.Clear();
						this.ListBoxAllGames.Items.Clear();
						foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair4 in this.dictionary_0)
						{
							string input = keyValuePair4.Value.method_0();
							MatchCollection matchCollection = Regex.Matches(input, this.string_0);
							foreach (object obj in matchCollection)
							{
								Match match = (Match)obj;
								string text4 = Regex.Replace(match.Value, this.string_0, "$1");
								if (!string.IsNullOrEmpty(text4))
								{
									if (text4.Contains('\t'))
									{
										text4 = text4.Split(new char[]
										{
											'\t'
										})[0].Trim();
									}
									text4 = text4.Trim();
									if (!string.IsNullOrEmpty(text4) && !this.list_0.Contains(text4))
									{
										this.list_0.Add(text4);
									}
								}
							}
							MatchCollection matchCollection2 = Regex.Matches(input, this.string_1);
							foreach (object obj2 in matchCollection2)
							{
								Match match2 = (Match)obj2;
								string text5 = Regex.Replace(match2.Value, this.string_1, "$1");
								if (!string.IsNullOrEmpty(text5))
								{
									text5 = text5.Trim();
									if (!string.IsNullOrEmpty(text5) && !this.list_2.Contains(text5))
									{
										this.list_2.Add(text5);
									}
								}
							}
						}
						this.list_0.Sort();
						foreach (string newItem in this.list_0)
						{
							this.ListBoxAllGames.Items.Add(newItem);
						}
						this.list_2.Sort();
						foreach (string newItem2 in this.list_2)
						{
							this.ListBoxAllInventary.Items.Add(newItem2);
						}
					}
					catch (Exception)
					{
						return;
					}
					if (System.Windows.MessageBox.Show("Перезаписать входной файл остатком??????", "Good save!", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
					{
						try
						{
							list.Clear();
							foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair5 in this.dictionary_0)
							{
								list.Add(keyValuePair5.Value.method_2());
							}
							text3 = null;
							foreach (string str2 in list)
							{
								text3 += str2;
							}
							File.WriteAllText(this.string_2, text3);
						}
						catch (Exception ex)
						{
							System.Windows.MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Hand);
						}
					}
				}
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000AE24 File Offset: 0x00009024
		private void SaveSellerLog_Click(object sender, RoutedEventArgs e)
		{
			List<string> list = new List<string>();
			if (this.dictionary_1.Count > 0)
			{
				using (Dictionary<string, LogViewer.Class3>.Enumerator enumerator = this.dictionary_1.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<string, LogViewer.Class3> keyValuePair = enumerator.Current;
						string str = null;
						string text = Regex.Match(keyValuePair.Value.method_2(), this.string_4).Value;
						if (!string.IsNullOrEmpty(text))
						{
							text = text.Replace("\t", "");
							text = text.Replace("\r", "");
							str = str + text + "\t";
							string text2 = Regex.Match(keyValuePair.Value.method_2(), this.string_5).Value;
							if (!string.IsNullOrEmpty(text2))
							{
								text2 = text2.Replace("\t", "");
								text2 = text2.Replace("\r", "");
								str = str + text2 + "\t";
							}
							string text3 = Regex.Match(keyValuePair.Value.method_2(), this.string_8).Value;
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = text3.Replace("\t", "");
								text3 = text3.Replace("\r", "");
								str = str + text3 + "\t";
							}
							string text4 = Regex.Match(keyValuePair.Value.method_2(), this.string_6).Value;
							if (!string.IsNullOrEmpty(text4))
							{
								text4 = text4.Replace("\t", "");
								text4 = text4.Replace("\r", "");
								str = str + text4 + "\t";
							}
							MatchCollection matchCollection = Regex.Matches(keyValuePair.Value.method_2(), this.string_7);
							foreach (object obj in matchCollection)
							{
								Match match = (Match)obj;
								if (!string.IsNullOrEmpty(match.Value))
								{
									string str2 = match.Value.Replace("\t", "").Replace("\r", "");
									str = str + str2 + "\t";
								}
							}
							list.Add(str + "\r\n");
						}
					}
					goto IL_4D2;
				}
			}
			foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair2 in this.dictionary_0)
			{
				string str3 = null;
				string text5 = Regex.Match(keyValuePair2.Value.method_2(), this.string_4).Value;
				if (!string.IsNullOrEmpty(text5))
				{
					text5 = text5.Replace("\t", "");
					text5 = text5.Replace("\r", "");
					str3 = str3 + text5 + "\t";
					string text6 = Regex.Match(keyValuePair2.Value.method_2(), this.string_5).Value;
					if (!string.IsNullOrEmpty(text6))
					{
						text6 = text6.Replace("\t", "");
						text6 = text6.Replace("\r", "");
						str3 = str3 + text6 + "\t";
					}
					string text7 = Regex.Match(keyValuePair2.Value.method_2(), this.string_8).Value;
					if (!string.IsNullOrEmpty(text7))
					{
						text7 = text7.Replace("\t", "");
						text7 = text7.Replace("\r", "");
						str3 = str3 + text7 + "\t";
					}
					string text8 = Regex.Match(keyValuePair2.Value.method_2(), this.string_6).Value;
					if (!string.IsNullOrEmpty(text8))
					{
						text8 = text8.Replace("\t", "");
						text8 = text8.Replace("\r", "");
						str3 = str3 + text8 + "\t";
					}
					MatchCollection matchCollection2 = Regex.Matches(keyValuePair2.Value.method_2(), this.string_7);
					foreach (object obj2 in matchCollection2)
					{
						Match match2 = (Match)obj2;
						if (!string.IsNullOrEmpty(match2.Value))
						{
							string str4 = match2.Value.Replace("\t", "").Replace("\r", "");
							str3 = str3 + str4 + "\t";
						}
					}
					list.Add(str3 + "\r\n");
				}
			}
			IL_4D2:
			string text9 = null;
			foreach (string str5 in list)
			{
				text9 += str5;
			}
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			saveFileDialog.Filter = "text files|*.txt";
			if (saveFileDialog.ShowDialog() == true)
			{
				string fileName = saveFileDialog.FileName;
				File.WriteAllText(fileName, text9.Replace("=======================================================", ""));
				System.Windows.MessageBox.Show("Все аккаунты сохранены!", "Good save!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000B424 File Offset: 0x00009624
		private void SaveOneAccs_Click(object sender, RoutedEventArgs e)
		{
			string text = null;
			try
			{
				text = this.ListBoxLog.SelectedItem.ToString();
			}
			catch (Exception)
			{
				System.Windows.MessageBox.Show("Сначала выберите аккаунт", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = this.dictionary_0[text].method_2();
				List<string> list = new List<string>();
				if (this.CheckBoxSaveOneAccsDota.IsChecked.Value)
				{
					string text3 = null;
					if (this.dictionary_0[text].method_5().Count > 0)
					{
						if (!this.dictionary_0[text].method_2().Contains("\n"))
						{
							text3 = "\r\nИнформация по инвентарю игры DOTA:\r\n";
						}
						else
						{
							text3 = "Информация по инвентарю игры DOTA:\r\n";
						}
						foreach (LogViewer.DotaItemClas dotaItemClas in this.dictionary_0[text].method_5())
						{
							text3 = text3 + "\t" + dotaItemClas.name + "\r\n";
						}
					}
					list.Add(text2 + text3 + "\r\n");
				}
				else
				{
					list.Add(text2);
				}
				Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
				saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
				saveFileDialog.Filter = "text files|*.txt";
				if (saveFileDialog.ShowDialog() == true)
				{
					string fileName = saveFileDialog.FileName;
					File.WriteAllLines(fileName, list);
					if (System.Windows.MessageBox.Show("Aккаунт сохранен!\r\n ХОТИТЕ УДАЛИТЬ ЕГО ИХ ИЗ ВХОДНЫХ ДАННЫХ???", "Good save!", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
					{
						if (this.dictionary_0.ContainsKey(text))
						{
							this.dictionary_0.Remove(text);
						}
						if (this.dictionary_1.Count > 0 && this.dictionary_1.ContainsKey(text))
						{
							this.dictionary_0.Remove(text);
						}
						this.dictionary_1.Clear();
						this.ListBoxLog.Items.Clear();
						foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair in this.dictionary_0)
						{
							this.ListBoxLog.Items.Add(keyValuePair.Key);
						}
						this.labelAllAccsCountLog.Content = this.dictionary_0.Count;
						try
						{
							this.NickProfileLink.Content = "http://steamcommunity.com/id||profiles/XXXXXXXXXXXXXXXXXXXX";
							this.SteamID.Content = "SteamID: STEAM_x:c:xxxxxxxx [x]";
							this.LabelBanStatus.Content = "BAN status: -> OK";
							this.LabelTradeStatus.Content = "TRADE status: -> OK";
							this.LabelHideStatus.Content = "Profile status: -> Доступен";
							this.LabelGameCount.Content = "Список игр: -> 0";
							this.LabelInventaryCount.Content = "Инвентарь: -> 0/0";
							this.textBoxInfo.Text = "";
							this.list_0.Clear();
							this.list_2.Clear();
							this.ListBoxAllInventary.Items.Clear();
							this.ListBoxAllGames.Items.Clear();
							foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair2 in this.dictionary_0)
							{
								string input = keyValuePair2.Value.method_3();
								MatchCollection matchCollection = Regex.Matches(input, this.string_0);
								foreach (object obj in matchCollection)
								{
									Match match = (Match)obj;
									string text4 = Regex.Replace(match.Value, this.string_0, "$1");
									if (!string.IsNullOrEmpty(text4))
									{
										if (text4.Contains('\t'))
										{
											text4 = text4.Split(new char[]
											{
												'\t'
											})[0].Trim();
										}
										text4 = text4.Trim();
										if (!string.IsNullOrEmpty(text4) && !this.list_0.Contains(text4))
										{
											this.list_0.Add(text4);
										}
									}
								}
								MatchCollection matchCollection2 = Regex.Matches(input, this.string_1);
								foreach (object obj2 in matchCollection2)
								{
									Match match2 = (Match)obj2;
									string text5 = Regex.Replace(match2.Value, this.string_1, "$1");
									if (!string.IsNullOrEmpty(text5))
									{
										text5 = text5.Trim();
										if (!string.IsNullOrEmpty(text5) && !this.list_2.Contains(text5))
										{
											this.list_2.Add(text5);
										}
									}
								}
							}
							this.list_0.Sort();
							foreach (string newItem in this.list_0)
							{
								this.ListBoxAllGames.Items.Add(newItem);
							}
							this.list_2.Sort();
							foreach (string newItem2 in this.list_2)
							{
								this.ListBoxAllInventary.Items.Add(newItem2);
							}
							goto IL_56B;
						}
						catch (Exception)
						{
						}
						return;
						IL_56B:
						if (System.Windows.MessageBox.Show("Перезаписать входной файл остатком??????", "Good save!", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
						{
							try
							{
								list.Clear();
								foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair3 in this.dictionary_0)
								{
									list.Add(keyValuePair3.Value.method_2());
								}
								string text6 = null;
								foreach (string str in list)
								{
									text6 += str;
								}
								File.WriteAllText(this.string_2, text6);
							}
							catch (Exception ex)
							{
								System.Windows.MessageBox.Show(ex.Message, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Hand);
							}
						}
					}
				}
				return;
			}
			System.Windows.MessageBox.Show("Сначала выберите аккаунт", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000BB8C File Offset: 0x00009D8C
		private void CopyToClipboard_Click(object sender, RoutedEventArgs e)
		{
			string text = null;
			try
			{
				text = this.ListBoxLog.SelectedItem.ToString();
			}
			catch (Exception)
			{
				System.Windows.MessageBox.Show("Сначала выберите аккаунт", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (string.IsNullOrEmpty(text))
			{
				System.Windows.MessageBox.Show("Сначала выберите аккаунт", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			else
			{
				string text2 = this.dictionary_0[text].method_2();
				if (this.CheckBoxCopyAccsDota.IsChecked.Value)
				{
					string text3 = null;
					if (this.dictionary_0[text].method_5().Count > 0)
					{
						if (!this.dictionary_0[text].method_2().Contains("\n"))
						{
							text3 = "\r\nИнформация по инвентарю игры DOTA:\r\n";
						}
						else
						{
							text3 = "Информация по инвентарю игры DOTA:\r\n";
						}
						foreach (LogViewer.DotaItemClas dotaItemClas in this.dictionary_0[text].method_5())
						{
							text3 = text3 + "\t" + dotaItemClas.name + "\r\n";
						}
					}
					System.Windows.Clipboard.SetText(text2 + text3 + "\r\n");
					return;
				}
				System.Windows.Clipboard.SetText(text2);
				return;
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0000BCDC File Offset: 0x00009EDC
		private void comboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.comboBoxSort.SelectedIndex == -1)
			{
				return;
			}
			try
			{
				this.NickProfileLink.Content = "http://steamcommunity.com/id||profiles/XXXXXXXXXXXXXXXXXXXX";
				this.SteamID.Content = "SteamID: STEAM_x:c:xxxxxxxx [x]";
				this.LabelBanStatus.Content = "BAN status: -> OK";
				this.LabelTradeStatus.Content = "TRADE status: -> OK";
				this.LabelHideStatus.Content = "Profile status: -> Доступен";
				this.LabelGameCount.Content = "Список игр: -> 0";
				this.LabelInventaryCount.Content = "Инвентарь: -> 0/0";
				this.textBoxInfo.Text = "";
			}
			catch (Exception)
			{
				return;
			}
			if (this.comboBoxSort.SelectedIndex != 0)
			{
				this.dictionary_1.Clear();
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				if (this.comboBoxSort.SelectedIndex == 1)
				{
					foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair in this.dictionary_0)
					{
						string key = keyValuePair.Key;
						string input = keyValuePair.Value.method_2();
						if (Regex.IsMatch(input, this.string_0))
						{
							MatchCollection matchCollection = Regex.Matches(input, this.string_0);
							dictionary.Add(key, matchCollection.Count);
						}
						else
						{
							dictionary.Add(key, 0);
						}
					}
					IEnumerable<KeyValuePair<string, int>> source = dictionary;
					if (LogViewer.func_0 == null)
					{
						LogViewer.func_0 = new Func<KeyValuePair<string, int>, int>(LogViewer.smethod_0);
					}
					IOrderedEnumerable<KeyValuePair<string, int>> orderedEnumerable = source.OrderByDescending(LogViewer.func_0);
					foreach (KeyValuePair<string, int> keyValuePair2 in orderedEnumerable)
					{
						this.dictionary_1.Add(keyValuePair2.Key, this.dictionary_0[keyValuePair2.Key]);
					}
					this.ListBoxLog.Items.Clear();
					foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair3 in this.dictionary_1)
					{
						this.ListBoxLog.Items.Add(keyValuePair3.Key);
					}
					this.labelAllAccsCountLog.Content = this.ListBoxLog.Items.Count;
				}
				if (this.comboBoxSort.SelectedIndex == 2)
				{
					foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair4 in this.dictionary_0)
					{
						string key2 = keyValuePair4.Key;
						string input2 = keyValuePair4.Value.method_2();
						if (Regex.IsMatch(input2, this.string_9))
						{
							MatchCollection matchCollection2 = Regex.Matches(input2, this.string_9);
							int num = 0;
							foreach (object obj in matchCollection2)
							{
								Match match = (Match)obj;
								string s = Regex.Replace(match.Value, this.string_9, "$2").Trim();
								int num2 = 0;
								if (int.TryParse(s, out num2))
								{
									num += num2;
								}
							}
							dictionary.Add(key2, num);
						}
						else
						{
							dictionary.Add(key2, 0);
						}
					}
					IEnumerable<KeyValuePair<string, int>> source2 = dictionary;
					if (LogViewer.func_1 == null)
					{
						LogViewer.func_1 = new Func<KeyValuePair<string, int>, int>(LogViewer.smethod_1);
					}
					IOrderedEnumerable<KeyValuePair<string, int>> orderedEnumerable2 = source2.OrderByDescending(LogViewer.func_1);
					foreach (KeyValuePair<string, int> keyValuePair5 in orderedEnumerable2)
					{
						this.dictionary_1.Add(keyValuePair5.Key, this.dictionary_0[keyValuePair5.Key]);
					}
					this.ListBoxLog.Items.Clear();
					foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair6 in this.dictionary_1)
					{
						this.ListBoxLog.Items.Add(keyValuePair6.Key);
					}
					this.labelAllAccsCountLog.Content = this.ListBoxLog.Items.Count;
				}
				if (this.comboBoxSort.SelectedIndex == 3)
				{
					foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair7 in this.dictionary_0)
					{
						string key3 = keyValuePair7.Key;
						string input3 = keyValuePair7.Value.method_2();
						if (Regex.IsMatch(input3, this.string_10))
						{
							MatchCollection matchCollection3 = Regex.Matches(input3, this.string_10);
							int num3 = 0;
							foreach (object obj2 in matchCollection3)
							{
								Match match2 = (Match)obj2;
								string s2 = Regex.Replace(match2.Value, this.string_10, "$3").Trim();
								int num4 = 0;
								if (int.TryParse(s2, out num4))
								{
									num3 += num4;
								}
							}
							dictionary.Add(key3, num3);
						}
						else
						{
							dictionary.Add(key3, 0);
						}
					}
					IEnumerable<KeyValuePair<string, int>> source3 = dictionary;
					if (LogViewer.func_2 == null)
					{
						LogViewer.func_2 = new Func<KeyValuePair<string, int>, int>(LogViewer.smethod_2);
					}
					IEnumerable<KeyValuePair<string, int>> enumerable = source3.OrderByDescending(LogViewer.func_2).Reverse<KeyValuePair<string, int>>();
					foreach (KeyValuePair<string, int> keyValuePair8 in enumerable)
					{
						this.dictionary_1.Add(keyValuePair8.Key, this.dictionary_0[keyValuePair8.Key]);
					}
					this.ListBoxLog.Items.Clear();
					foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair9 in this.dictionary_1)
					{
						this.ListBoxLog.Items.Add(keyValuePair9.Key);
					}
					this.labelAllAccsCountLog.Content = this.ListBoxLog.Items.Count;
				}
				return;
			}
			if (this.dictionary_1.Count > 0)
			{
				this.dictionary_1.Clear();
				this.ListBoxLog.Items.Clear();
				foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair10 in this.dictionary_0)
				{
					this.ListBoxLog.Items.Add(keyValuePair10.Key);
				}
				this.labelAllAccsCountLog.Content = this.dictionary_0.Count;
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0000C448 File Offset: 0x0000A648
		private void dataGridDota_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				if (this.LoadImages.IsChecked == true)
				{
					string text = null;
					try
					{
						text = this.ListBoxLog.SelectedItem.ToString();
					}
					catch (Exception)
					{
						System.Windows.MessageBox.Show("Сначала выберите аккаунт", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
						return;
					}
					LogViewer.DotaDataClas dotaDataClas = (LogViewer.DotaDataClas)this.dataGridDota.SelectedItem;
					if (string.IsNullOrEmpty(text))
					{
						System.Windows.MessageBox.Show("Сначала выберите аккаунт", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
					}
					else
					{
						List<LogViewer.DotaItemClas> list = this.dictionary_0[text].method_5();
						string text2 = null;
						foreach (LogViewer.DotaItemClas dotaItemClas in list)
						{
							if (dotaItemClas.name == dotaDataClas.name)
							{
								text2 = dotaItemClas.icon_url + "158x73";
								break;
							}
						}
						if (!string.IsNullOrEmpty(text2))
						{
							byte[] array = null;
							try
							{
								using (WebClient webClient = new WebClient())
								{
									array = webClient.DownloadData(text2);
								}
							}
							catch (Exception)
							{
							}
							if (array != null)
							{
								BitmapImage bitmapImage = new BitmapImage();
								bitmapImage.BeginInit();
								bitmapImage.StreamSource = new MemoryStream(array);
								bitmapImage.EndInit();
								this.ImageItem.Source = bitmapImage;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000C638 File Offset: 0x0000A838
		private void QualityStandard_Click(object sender, RoutedEventArgs e)
		{
			if (this.CheckBoxAllAccsFiltr.IsChecked == true)
			{
				this.CheckBoxAllAccsFiltr_Click(null, null);
				return;
			}
			bool value = this.RarityCommon.IsChecked.Value;
			bool value2 = this.RarityLegendary.IsChecked.Value;
			bool value3 = this.RarityMythical.IsChecked.Value;
			bool value4 = this.RarityRare.IsChecked.Value;
			bool value5 = this.RarityUncommon.IsChecked.Value;
			bool value6 = this.QualityAuspicious.IsChecked.Value;
			bool value7 = this.QualityCursed.IsChecked.Value;
			bool value8 = this.QualityFrozen.IsChecked.Value;
			bool value9 = this.QualityGenuine.IsChecked.Value;
			bool value10 = this.QualityInscribed.IsChecked.Value;
			bool value11 = this.QualityStandard.IsChecked.Value;
			this.dataGridDota.Items.Clear();
			string key = null;
			try
			{
				key = this.ListBoxLog.SelectedItem.ToString();
			}
			catch (Exception)
			{
				System.Windows.MessageBox.Show("Сначала выберите аккаунт", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				this.checkBoxUnselect_Click(null, null);
				return;
			}
			List<LogViewer.DotaItemClas> list = this.dictionary_0[key].method_5();
			if (value || value2 || value3 || value4 || value5 || value6 || value7 || value8 || value9 || value10 || value11)
			{
				List<LogViewer.DotaDataClas> list2 = new List<LogViewer.DotaDataClas>();
				foreach (LogViewer.DotaItemClas dotaItemClas in list)
				{
					if (value && dotaItemClas.rarityName == "Common")
					{
						LogViewer.DotaDataClas dotaDataClas = new LogViewer.DotaDataClas();
						dotaDataClas.name = dotaItemClas.name;
						dotaDataClas.rarityName = dotaItemClas.rarityName;
						dotaDataClas.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas))
						{
							list2.Add(dotaDataClas);
						}
					}
					if (value2 && dotaItemClas.rarityName == "Legendary")
					{
						LogViewer.DotaDataClas dotaDataClas2 = new LogViewer.DotaDataClas();
						dotaDataClas2.name = dotaItemClas.name;
						dotaDataClas2.rarityName = dotaItemClas.rarityName;
						dotaDataClas2.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas2))
						{
							list2.Add(dotaDataClas2);
						}
					}
					if (value3 && dotaItemClas.rarityName == "Mythical")
					{
						LogViewer.DotaDataClas dotaDataClas3 = new LogViewer.DotaDataClas();
						dotaDataClas3.name = dotaItemClas.name;
						dotaDataClas3.rarityName = dotaItemClas.rarityName;
						dotaDataClas3.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas3))
						{
							list2.Add(dotaDataClas3);
						}
					}
					if (value4 && dotaItemClas.rarityName == "Rare")
					{
						LogViewer.DotaDataClas dotaDataClas4 = new LogViewer.DotaDataClas();
						dotaDataClas4.name = dotaItemClas.name;
						dotaDataClas4.rarityName = dotaItemClas.rarityName;
						dotaDataClas4.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas4))
						{
							list2.Add(dotaDataClas4);
						}
					}
					if (value5 && dotaItemClas.rarityName == "Uncommon")
					{
						LogViewer.DotaDataClas dotaDataClas5 = new LogViewer.DotaDataClas();
						dotaDataClas5.name = dotaItemClas.name;
						dotaDataClas5.rarityName = dotaItemClas.rarityName;
						dotaDataClas5.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas5))
						{
							list2.Add(dotaDataClas5);
						}
					}
					if (value6 && dotaItemClas.qualityName == "Auspicious")
					{
						LogViewer.DotaDataClas dotaDataClas6 = new LogViewer.DotaDataClas();
						dotaDataClas6.name = dotaItemClas.name;
						dotaDataClas6.rarityName = dotaItemClas.rarityName;
						dotaDataClas6.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas6))
						{
							list2.Add(dotaDataClas6);
						}
					}
					if (value7 && dotaItemClas.qualityName == "Cursed")
					{
						LogViewer.DotaDataClas dotaDataClas7 = new LogViewer.DotaDataClas();
						dotaDataClas7.name = dotaItemClas.name;
						dotaDataClas7.rarityName = dotaItemClas.rarityName;
						dotaDataClas7.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas7))
						{
							list2.Add(dotaDataClas7);
						}
					}
					if (value8 && dotaItemClas.qualityName == "Frozen")
					{
						LogViewer.DotaDataClas dotaDataClas8 = new LogViewer.DotaDataClas();
						dotaDataClas8.name = dotaItemClas.name;
						dotaDataClas8.rarityName = dotaItemClas.rarityName;
						dotaDataClas8.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas8))
						{
							list2.Add(dotaDataClas8);
						}
					}
					if (value9 && dotaItemClas.qualityName == "Genuine")
					{
						LogViewer.DotaDataClas dotaDataClas9 = new LogViewer.DotaDataClas();
						dotaDataClas9.name = dotaItemClas.name;
						dotaDataClas9.rarityName = dotaItemClas.rarityName;
						dotaDataClas9.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas9))
						{
							list2.Add(dotaDataClas9);
						}
					}
					if (value10 && dotaItemClas.qualityName == "Inscribed")
					{
						LogViewer.DotaDataClas dotaDataClas10 = new LogViewer.DotaDataClas();
						dotaDataClas10.name = dotaItemClas.name;
						dotaDataClas10.rarityName = dotaItemClas.rarityName;
						dotaDataClas10.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas10))
						{
							list2.Add(dotaDataClas10);
						}
					}
					if (value11 && dotaItemClas.qualityName == "Standard")
					{
						LogViewer.DotaDataClas dotaDataClas11 = new LogViewer.DotaDataClas();
						dotaDataClas11.name = dotaItemClas.name;
						dotaDataClas11.rarityName = dotaItemClas.rarityName;
						dotaDataClas11.qualityName = dotaItemClas.qualityName;
						if (!list2.Contains(dotaDataClas11))
						{
							list2.Add(dotaDataClas11);
						}
					}
				}
				if (list2.Any<LogViewer.DotaDataClas>())
				{
					foreach (LogViewer.DotaDataClas newItem in list2)
					{
						this.dataGridDota.Items.Add(newItem);
					}
				}
				return;
			}
			this.dataGridDota.Items.Clear();
			foreach (LogViewer.DotaItemClas dotaItemClas2 in list)
			{
				LogViewer.DotaDataClas dotaDataClas12 = new LogViewer.DotaDataClas();
				dotaDataClas12.name = dotaItemClas2.name;
				dotaDataClas12.rarityName = dotaItemClas2.rarityName;
				dotaDataClas12.qualityName = dotaItemClas2.qualityName;
				this.dataGridDota.Items.Add(dotaDataClas12);
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0000CD64 File Offset: 0x0000AF64
		private void checkBoxUnselect_Click(object sender, RoutedEventArgs e)
		{
			if (this.checkBoxUnselect.IsChecked == true)
			{
				this.dataGridDota.Items.Clear();
				this.RarityCommon.IsChecked = new bool?(false);
				this.RarityLegendary.IsChecked = new bool?(false);
				this.RarityMythical.IsChecked = new bool?(false);
				this.RarityRare.IsChecked = new bool?(false);
				this.RarityUncommon.IsChecked = new bool?(false);
				this.QualityAuspicious.IsChecked = new bool?(false);
				this.QualityCursed.IsChecked = new bool?(false);
				this.QualityFrozen.IsChecked = new bool?(false);
				this.QualityGenuine.IsChecked = new bool?(false);
				this.QualityInscribed.IsChecked = new bool?(false);
				this.QualityStandard.IsChecked = new bool?(false);
				this.TextBoxItemSearch.Text = "";
				string key = null;
				try
				{
					key = this.ListBoxLog.SelectedItem.ToString();
				}
				catch (Exception)
				{
					return;
				}
				List<LogViewer.DotaItemClas> list = this.dictionary_0[key].method_5();
				foreach (LogViewer.DotaItemClas dotaItemClas in list)
				{
					LogViewer.DotaDataClas dotaDataClas = new LogViewer.DotaDataClas();
					dotaDataClas.name = dotaItemClas.name;
					dotaDataClas.rarityName = dotaItemClas.rarityName;
					dotaDataClas.qualityName = dotaItemClas.qualityName;
					this.dataGridDota.Items.Add(dotaDataClas);
				}
				this.checkBoxUnselect.IsChecked = new bool?(false);
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0000CF3C File Offset: 0x0000B13C
		private void CheckBoxAllAccsFiltr_Click(object sender, RoutedEventArgs e)
		{
			bool value = this.RarityCommon.IsChecked.Value;
			bool value2 = this.RarityLegendary.IsChecked.Value;
			bool value3 = this.RarityMythical.IsChecked.Value;
			bool value4 = this.RarityRare.IsChecked.Value;
			bool value5 = this.RarityUncommon.IsChecked.Value;
			bool value6 = this.QualityAuspicious.IsChecked.Value;
			bool value7 = this.QualityCursed.IsChecked.Value;
			bool value8 = this.QualityFrozen.IsChecked.Value;
			bool value9 = this.QualityGenuine.IsChecked.Value;
			bool value10 = this.QualityInscribed.IsChecked.Value;
			bool value11 = this.QualityStandard.IsChecked.Value;
			if (this.CheckBoxAllAccsFiltr.IsChecked == true)
			{
				if (this.dataGridDota.Items.Count == 0 && !value && !value2 && !value3 && !value4 && !value5 && !value6 && !value7 && !value8 && !value9 && !value10 && !value11)
				{
					List<LogViewer.DotaDataClas> list = new List<LogViewer.DotaDataClas>();
					foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair in this.dictionary_0)
					{
						List<LogViewer.DotaItemClas> list2 = keyValuePair.Value.method_5();
						foreach (LogViewer.DotaItemClas dotaItemClas in list2)
						{
							LogViewer.DotaDataClas dotaDataClas = new LogViewer.DotaDataClas();
							dotaDataClas.name = dotaItemClas.name;
							dotaDataClas.rarityName = dotaItemClas.rarityName;
							dotaDataClas.qualityName = dotaItemClas.qualityName;
							if (!list.Contains(dotaDataClas))
							{
								list.Add(dotaDataClas);
							}
						}
					}
					if (list.Any<LogViewer.DotaDataClas>())
					{
						this.dataGridDota.Items.Clear();
						foreach (LogViewer.DotaDataClas newItem in list)
						{
							this.dataGridDota.Items.Add(newItem);
						}
					}
					return;
				}
				this.dataGridDota.Items.Clear();
				List<LogViewer.DotaDataClas> list3 = new List<LogViewer.DotaDataClas>();
				this.dictionary_1.Clear();
				foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair2 in this.dictionary_0)
				{
					if (keyValuePair2.Value.method_5().Any<LogViewer.DotaItemClas>())
					{
						List<LogViewer.DotaItemClas> list4 = keyValuePair2.Value.method_5();
						foreach (LogViewer.DotaItemClas dotaItemClas2 in list4)
						{
							if (value && dotaItemClas2.rarityName == "Common")
							{
								LogViewer.DotaDataClas dotaDataClas2 = new LogViewer.DotaDataClas();
								dotaDataClas2.name = dotaItemClas2.name;
								dotaDataClas2.rarityName = dotaItemClas2.rarityName;
								dotaDataClas2.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas2))
								{
									list3.Add(dotaDataClas2);
								}
							}
							if (value2 && dotaItemClas2.rarityName == "Legendary")
							{
								LogViewer.DotaDataClas dotaDataClas3 = new LogViewer.DotaDataClas();
								dotaDataClas3.name = dotaItemClas2.name;
								dotaDataClas3.rarityName = dotaItemClas2.rarityName;
								dotaDataClas3.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas3))
								{
									list3.Add(dotaDataClas3);
								}
							}
							if (value3 && dotaItemClas2.rarityName == "Mythical")
							{
								LogViewer.DotaDataClas dotaDataClas4 = new LogViewer.DotaDataClas();
								dotaDataClas4.name = dotaItemClas2.name;
								dotaDataClas4.rarityName = dotaItemClas2.rarityName;
								dotaDataClas4.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas4))
								{
									list3.Add(dotaDataClas4);
								}
							}
							if (value4 && dotaItemClas2.rarityName == "Rare")
							{
								LogViewer.DotaDataClas dotaDataClas5 = new LogViewer.DotaDataClas();
								dotaDataClas5.name = dotaItemClas2.name;
								dotaDataClas5.rarityName = dotaItemClas2.rarityName;
								dotaDataClas5.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas5))
								{
									list3.Add(dotaDataClas5);
								}
							}
							if (value5 && dotaItemClas2.rarityName == "Uncommon")
							{
								LogViewer.DotaDataClas dotaDataClas6 = new LogViewer.DotaDataClas();
								dotaDataClas6.name = dotaItemClas2.name;
								dotaDataClas6.rarityName = dotaItemClas2.rarityName;
								dotaDataClas6.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas6))
								{
									list3.Add(dotaDataClas6);
								}
							}
							if (value6 && dotaItemClas2.qualityName == "Auspicious")
							{
								LogViewer.DotaDataClas dotaDataClas7 = new LogViewer.DotaDataClas();
								dotaDataClas7.name = dotaItemClas2.name;
								dotaDataClas7.rarityName = dotaItemClas2.rarityName;
								dotaDataClas7.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas7))
								{
									list3.Add(dotaDataClas7);
								}
							}
							if (value7 && dotaItemClas2.qualityName == "Cursed")
							{
								LogViewer.DotaDataClas dotaDataClas8 = new LogViewer.DotaDataClas();
								dotaDataClas8.name = dotaItemClas2.name;
								dotaDataClas8.rarityName = dotaItemClas2.rarityName;
								dotaDataClas8.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas8))
								{
									list3.Add(dotaDataClas8);
								}
							}
							if (value8 && dotaItemClas2.qualityName == "Frozen")
							{
								LogViewer.DotaDataClas dotaDataClas9 = new LogViewer.DotaDataClas();
								dotaDataClas9.name = dotaItemClas2.name;
								dotaDataClas9.rarityName = dotaItemClas2.rarityName;
								dotaDataClas9.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas9))
								{
									list3.Add(dotaDataClas9);
								}
							}
							if (value9 && dotaItemClas2.qualityName == "Genuine")
							{
								LogViewer.DotaDataClas dotaDataClas10 = new LogViewer.DotaDataClas();
								dotaDataClas10.name = dotaItemClas2.name;
								dotaDataClas10.rarityName = dotaItemClas2.rarityName;
								dotaDataClas10.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas10))
								{
									list3.Add(dotaDataClas10);
								}
							}
							if (value10 && dotaItemClas2.qualityName == "Inscribed")
							{
								LogViewer.DotaDataClas dotaDataClas11 = new LogViewer.DotaDataClas();
								dotaDataClas11.name = dotaItemClas2.name;
								dotaDataClas11.rarityName = dotaItemClas2.rarityName;
								dotaDataClas11.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas11))
								{
									list3.Add(dotaDataClas11);
								}
							}
							if (value11 && dotaItemClas2.qualityName == "Standard")
							{
								LogViewer.DotaDataClas dotaDataClas12 = new LogViewer.DotaDataClas();
								dotaDataClas12.name = dotaItemClas2.name;
								dotaDataClas12.rarityName = dotaItemClas2.rarityName;
								dotaDataClas12.qualityName = dotaItemClas2.qualityName;
								if (!list3.Contains(dotaDataClas12))
								{
									list3.Add(dotaDataClas12);
								}
							}
						}
						LogViewer.Class3 @class = new LogViewer.Class3();
						@class.method_1(keyValuePair2.Value.method_0());
						@class.nvuQtwFoxe(keyValuePair2.Value.method_2());
						this.dictionary_1.Add(keyValuePair2.Value.method_0(), @class);
					}
				}
				if (this.dictionary_1.Count == 0)
				{
					System.Windows.MessageBox.Show("Нету аккаунтов с заданными критериями!", "Ошибочка!", MessageBoxButton.OK, MessageBoxImage.Hand);
					return;
				}
				this.ListBoxLog.Items.Clear();
				foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair3 in this.dictionary_1)
				{
					this.ListBoxLog.Items.Add(keyValuePair3.Key);
				}
				this.labelAllAccsCountLog.Content = this.dictionary_1.Count;
				if (list3.Any<LogViewer.DotaDataClas>())
				{
					foreach (LogViewer.DotaDataClas newItem2 in list3)
					{
						this.dataGridDota.Items.Add(newItem2);
					}
				}
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000D850 File Offset: 0x0000BA50
		private void TextBoxItemSearch_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(this.TextBoxItemSearch.Text))
				{
					if (this.CheckBoxAllAccsFiltr.IsChecked == true)
					{
						this.method_2();
					}
					else
					{
						try
						{
							string key = this.ListBoxLog.SelectedItem.ToString();
							List<LogViewer.DotaItemClas> list = this.dictionary_0[key].method_5();
							List<LogViewer.DotaDataClas> list2 = new List<LogViewer.DotaDataClas>();
							foreach (LogViewer.DotaItemClas dotaItemClas in list)
							{
								if (dotaItemClas.name.Contains(this.TextBoxItemSearch.Text))
								{
									LogViewer.DotaDataClas dotaDataClas = new LogViewer.DotaDataClas();
									dotaDataClas.name = dotaItemClas.name;
									dotaDataClas.rarityName = dotaItemClas.rarityName;
									dotaDataClas.qualityName = dotaItemClas.qualityName;
									if (!list2.Contains(dotaDataClas))
									{
										list2.Add(dotaDataClas);
									}
								}
							}
							if (list2.Any<LogViewer.DotaDataClas>())
							{
								this.dataGridDota.Items.Clear();
								foreach (LogViewer.DotaDataClas newItem in list2)
								{
									this.dataGridDota.Items.Add(newItem);
								}
							}
						}
						catch (Exception)
						{
							System.Windows.MessageBox.Show("Сначала выберите аккаунт", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000DA2C File Offset: 0x0000BC2C
		private void method_2()
		{
			try
			{
				if (!string.IsNullOrEmpty(this.TextBoxItemSearch.Text))
				{
					try
					{
						List<LogViewer.DotaDataClas> list = new List<LogViewer.DotaDataClas>();
						foreach (KeyValuePair<string, LogViewer.Class3> keyValuePair in this.dictionary_0)
						{
							List<LogViewer.DotaItemClas> list2 = keyValuePair.Value.method_5();
							foreach (LogViewer.DotaItemClas dotaItemClas in list2)
							{
								if (dotaItemClas.name.Contains(this.TextBoxItemSearch.Text))
								{
									LogViewer.DotaDataClas dotaDataClas = new LogViewer.DotaDataClas();
									dotaDataClas.name = dotaItemClas.name;
									dotaDataClas.rarityName = dotaItemClas.rarityName;
									dotaDataClas.qualityName = dotaItemClas.qualityName;
									if (!list.Contains(dotaDataClas))
									{
										list.Add(dotaDataClas);
									}
								}
							}
						}
						if (list.Any<LogViewer.DotaDataClas>())
						{
							this.dataGridDota.Items.Clear();
							foreach (LogViewer.DotaDataClas newItem in list)
							{
								this.dataGridDota.Items.Add(newItem);
							}
						}
					}
					catch (Exception)
					{
						System.Windows.MessageBox.Show("Сначала выберите аккаунт", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000DC14 File Offset: 0x0000BE14
		private void CheckBoxDota_Click(object sender, RoutedEventArgs e)
		{
			if (this.CheckBoxDota.IsChecked == true)
			{
				this.groupBoxInfo.Margin = new Thickness(0.0, 999.0, 999.0, 40.0);
				return;
			}
			this.groupBoxInfo.Margin = new Thickness(0.0, 0.0, 0.0, 0.0);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000DCAC File Offset: 0x0000BEAC
		private void method_3(object sender, RoutedEventArgs e)
		{
			this.int_0 = 1050 - Screen.PrimaryScreen.WorkingArea.Height;
			if (this.int_0 > 0)
			{
				this.ListBoxLog.Height = 396.0;
				this.groupButomBox.Margin = new Thickness(0.0, -120.0, 0.0, 0.0);
				this.groupBoxInfo.Height = 361.0;
				this.textBoxInfo.Height = 290.0;
				this.LabelextFiltr.Margin = new Thickness(0.0, -210.0, 0.0, 0.0);
				this.textBoxFiltrText.Margin = new Thickness(0.0, -210.0, 0.0, 0.0);
				this.LabelSetTextFiltr.Margin = new Thickness(0.0, -210.0, 0.0, 0.0);
				this.gridViborka.Margin = new Thickness(0.0, -210.0, 0.0, 0.0);
				this.gridViborLll.Margin = new Thickness(0.0, -120.0, 0.0, 0.0);
				this.dataGridDota.Height = 199.0;
				this.gridDotaItem.Margin = new Thickness(0.0, -120.0, 0.0, 0.0);
				base.Height = 733.0;
				base.MinHeight = 733.0;
				base.MaxHeight = 733.0;
				double fullPrimaryScreenHeight = SystemParameters.FullPrimaryScreenHeight;
				double fullPrimaryScreenWidth = SystemParameters.FullPrimaryScreenWidth;
				base.Top = (fullPrimaryScreenHeight - base.Height) / 2.0;
				base.Left = (fullPrimaryScreenWidth - base.Width) / 2.0;
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0000DF08 File Offset: 0x0000C108
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			Uri resourceLocator = new Uri("/SteamCheCkeR v4.5.1;component/windows/logviewer.xaml", UriKind.Relative);
			System.Windows.Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000DF38 File Offset: 0x0000C138
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((LogViewer)target).Loaded += this.method_3;
				return;
			case 2:
				this.comboBoxSort = (System.Windows.Controls.ComboBox)target;
				this.comboBoxSort.SelectionChanged += this.comboBoxSort_SelectionChanged;
				return;
			case 3:
				this.labelAllAccsCountLog = (System.Windows.Controls.Label)target;
				return;
			case 4:
				this.NickProfileLink = (System.Windows.Controls.Label)target;
				this.NickProfileLink.MouseDoubleClick += this.NickProfileLink_MouseDoubleClick;
				return;
			case 5:
				this.SteamID = (System.Windows.Controls.Label)target;
				return;
			case 6:
				this.LabelGameCount = (System.Windows.Controls.Label)target;
				return;
			case 7:
				this.LabelBanStatus = (System.Windows.Controls.Label)target;
				return;
			case 8:
				this.LabelTradeStatus = (System.Windows.Controls.Label)target;
				return;
			case 9:
				this.LabelHideStatus = (System.Windows.Controls.Label)target;
				return;
			case 10:
				this.LabelInventaryCount = (System.Windows.Controls.Label)target;
				return;
			case 11:
				this.TextBoxItemSearch = (System.Windows.Controls.TextBox)target;
				this.TextBoxItemSearch.TextChanged += this.TextBoxItemSearch_TextChanged;
				return;
			case 12:
				this.ButonAddAccsLog = (System.Windows.Controls.Button)target;
				this.ButonAddAccsLog.Click += this.ButonAddAccsLog_Click;
				return;
			case 13:
				this.ButonAddDotaLog = (System.Windows.Controls.Button)target;
				this.ButonAddDotaLog.Click += this.ButonAddDotaLog_Click;
				return;
			case 14:
				this.groupButomBox = (Grid)target;
				return;
			case 15:
				this.SaveAllAccs = (System.Windows.Controls.Button)target;
				this.SaveAllAccs.Click += this.SaveAllAccs_Click;
				return;
			case 16:
				this.SaveSellerLog = (System.Windows.Controls.Button)target;
				this.SaveSellerLog.Click += this.SaveSellerLog_Click;
				return;
			case 17:
				this.SaveOneAccs = (System.Windows.Controls.Button)target;
				this.SaveOneAccs.Click += this.SaveOneAccs_Click;
				return;
			case 18:
				this.CopyToClipboard = (System.Windows.Controls.Button)target;
				this.CopyToClipboard.Click += this.CopyToClipboard_Click;
				return;
			case 19:
				this.CheckBoxSaveAllAccsDota = (System.Windows.Controls.CheckBox)target;
				return;
			case 20:
				this.CheckBoxSaveOneAccsDota = (System.Windows.Controls.CheckBox)target;
				return;
			case 21:
				this.CheckBoxCopyAccsDota = (System.Windows.Controls.CheckBox)target;
				return;
			case 22:
				this.ListBoxLog = (System.Windows.Controls.ListBox)target;
				this.ListBoxLog.SelectionChanged += this.ListBoxLog_SelectionChanged;
				return;
			case 23:
				this.gridViborka = (Grid)target;
				return;
			case 24:
				this.ButtonViborka = (System.Windows.Controls.Button)target;
				this.ButtonViborka.Click += this.ButtonViborka_Click;
				return;
			case 25:
				this.ButtonSbros = (System.Windows.Controls.Button)target;
				this.ButtonSbros.Click += this.ButtonSbros_Click;
				return;
			case 26:
				this.CheckBoxDota = (System.Windows.Controls.CheckBox)target;
				this.CheckBoxDota.Click += this.CheckBoxDota_Click;
				return;
			case 27:
				this.LoadImages = (System.Windows.Controls.CheckBox)target;
				return;
			case 28:
				this.CheckBoxAllAccsFiltr = (System.Windows.Controls.CheckBox)target;
				this.CheckBoxAllAccsFiltr.Click += this.CheckBoxAllAccsFiltr_Click;
				return;
			case 29:
				this.checkBoxUnselect = (System.Windows.Controls.CheckBox)target;
				this.checkBoxUnselect.Click += this.checkBoxUnselect_Click;
				return;
			case 30:
				this.RarityCommon = (System.Windows.Controls.CheckBox)target;
				this.RarityCommon.Click += this.QualityStandard_Click;
				return;
			case 31:
				this.RarityLegendary = (System.Windows.Controls.CheckBox)target;
				this.RarityLegendary.Click += this.QualityStandard_Click;
				return;
			case 32:
				this.RarityMythical = (System.Windows.Controls.CheckBox)target;
				this.RarityMythical.Click += this.QualityStandard_Click;
				return;
			case 33:
				this.RarityRare = (System.Windows.Controls.CheckBox)target;
				this.RarityRare.Click += this.QualityStandard_Click;
				return;
			case 34:
				this.RarityUncommon = (System.Windows.Controls.CheckBox)target;
				this.RarityUncommon.Click += this.QualityStandard_Click;
				return;
			case 35:
				this.QualityAuspicious = (System.Windows.Controls.CheckBox)target;
				this.QualityAuspicious.Click += this.QualityStandard_Click;
				return;
			case 36:
				this.QualityCursed = (System.Windows.Controls.CheckBox)target;
				this.QualityCursed.Click += this.QualityStandard_Click;
				return;
			case 37:
				this.QualityFrozen = (System.Windows.Controls.CheckBox)target;
				this.QualityFrozen.Click += this.QualityStandard_Click;
				return;
			case 38:
				this.QualityGenuine = (System.Windows.Controls.CheckBox)target;
				this.QualityGenuine.Click += this.QualityStandard_Click;
				return;
			case 39:
				this.QualityInscribed = (System.Windows.Controls.CheckBox)target;
				this.QualityInscribed.Click += this.QualityStandard_Click;
				return;
			case 40:
				this.QualityStandard = (System.Windows.Controls.CheckBox)target;
				this.QualityStandard.Click += this.QualityStandard_Click;
				return;
			case 41:
				this.dataGridDota = (System.Windows.Controls.DataGrid)target;
				this.dataGridDota.SelectionChanged += this.dataGridDota_SelectionChanged;
				return;
			case 42:
				this.ImageItem = (Image)target;
				return;
			case 43:
				this.gridDotaItem = (Grid)target;
				return;
			case 44:
				this.ListBoxAllItems = (System.Windows.Controls.ListBox)target;
				return;
			case 45:
				this.groupBoxInfo = (Canvas)target;
				return;
			case 46:
				this.gridViborLll = (Grid)target;
				return;
			case 47:
				this.ListBoxAllGames = (System.Windows.Controls.ListBox)target;
				return;
			case 48:
				this.ListBoxAllInventary = (System.Windows.Controls.ListBox)target;
				return;
			case 49:
				this.textBoxInfo = (System.Windows.Controls.TextBox)target;
				return;
			case 50:
				this.LabelextFiltr = (System.Windows.Controls.Label)target;
				return;
			case 51:
				this.textBoxFiltrText = (System.Windows.Controls.TextBox)target;
				return;
			case 52:
				this.LabelSetTextFiltr = (System.Windows.Controls.Label)target;
				this.LabelSetTextFiltr.MouseDown += this.LabelSetTextFiltr_MouseDown;
				return;
			default:
				this.bool_0 = true;
				return;
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00002B15 File Offset: 0x00000D15
		[CompilerGenerated]
		private static int smethod_0(KeyValuePair<string, int> x)
		{
			return x.Value;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00002B15 File Offset: 0x00000D15
		[CompilerGenerated]
		private static int smethod_1(KeyValuePair<string, int> x)
		{
			return x.Value;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00002B15 File Offset: 0x00000D15
		[CompilerGenerated]
		private static int smethod_2(KeyValuePair<string, int> x)
		{
			return x.Value;
		}

		// Token: 0x040000B4 RID: 180
		private Dictionary<string, LogViewer.Class3> dictionary_0;

		// Token: 0x040000B5 RID: 181
		private Dictionary<string, LogViewer.Class3> dictionary_1;

		// Token: 0x040000B6 RID: 182
		private List<string> list_0;

		// Token: 0x040000B7 RID: 183
		private List<string> list_1;

		// Token: 0x040000B8 RID: 184
		private List<string> list_2;

		// Token: 0x040000B9 RID: 185
		private string string_0;

		// Token: 0x040000BA RID: 186
		private string string_1;

		// Token: 0x040000BB RID: 187
		private string string_2;

		// Token: 0x040000BC RID: 188
		private string string_3;

		// Token: 0x040000BD RID: 189
		private string string_4;

		// Token: 0x040000BE RID: 190
		private string string_5;

		// Token: 0x040000BF RID: 191
		private string string_6;

		// Token: 0x040000C0 RID: 192
		private string string_7;

		// Token: 0x040000C1 RID: 193
		private string string_8;

		// Token: 0x040000C2 RID: 194
		private string string_9;

		// Token: 0x040000C3 RID: 195
		private string string_10;

		// Token: 0x040000C4 RID: 196
		private int int_0;

		// Token: 0x040000C5 RID: 197
		internal System.Windows.Controls.ComboBox comboBoxSort;

		// Token: 0x040000C6 RID: 198
		internal System.Windows.Controls.Label labelAllAccsCountLog;

		// Token: 0x040000C7 RID: 199
		internal System.Windows.Controls.Label NickProfileLink;

		// Token: 0x040000C8 RID: 200
		internal System.Windows.Controls.Label SteamID;

		// Token: 0x040000C9 RID: 201
		internal System.Windows.Controls.Label LabelGameCount;

		// Token: 0x040000CA RID: 202
		internal System.Windows.Controls.Label LabelBanStatus;

		// Token: 0x040000CB RID: 203
		internal System.Windows.Controls.Label LabelTradeStatus;

		// Token: 0x040000CC RID: 204
		internal System.Windows.Controls.Label LabelHideStatus;

		// Token: 0x040000CD RID: 205
		internal System.Windows.Controls.Label LabelInventaryCount;

		// Token: 0x040000CE RID: 206
		internal System.Windows.Controls.TextBox TextBoxItemSearch;

		// Token: 0x040000CF RID: 207
		internal System.Windows.Controls.Button ButonAddAccsLog;

		// Token: 0x040000D0 RID: 208
		internal System.Windows.Controls.Button ButonAddDotaLog;

		// Token: 0x040000D1 RID: 209
		internal Grid groupButomBox;

		// Token: 0x040000D2 RID: 210
		internal System.Windows.Controls.Button SaveAllAccs;

		// Token: 0x040000D3 RID: 211
		internal System.Windows.Controls.Button SaveSellerLog;

		// Token: 0x040000D4 RID: 212
		internal System.Windows.Controls.Button SaveOneAccs;

		// Token: 0x040000D5 RID: 213
		internal System.Windows.Controls.Button CopyToClipboard;

		// Token: 0x040000D6 RID: 214
		internal System.Windows.Controls.CheckBox CheckBoxSaveAllAccsDota;

		// Token: 0x040000D7 RID: 215
		internal System.Windows.Controls.CheckBox CheckBoxSaveOneAccsDota;

		// Token: 0x040000D8 RID: 216
		internal System.Windows.Controls.CheckBox CheckBoxCopyAccsDota;

		// Token: 0x040000D9 RID: 217
		internal System.Windows.Controls.ListBox ListBoxLog;

		// Token: 0x040000DA RID: 218
		internal Grid gridViborka;

		// Token: 0x040000DB RID: 219
		internal System.Windows.Controls.Button ButtonViborka;

		// Token: 0x040000DC RID: 220
		internal System.Windows.Controls.Button ButtonSbros;

		// Token: 0x040000DD RID: 221
		internal System.Windows.Controls.CheckBox CheckBoxDota;

		// Token: 0x040000DE RID: 222
		internal System.Windows.Controls.CheckBox LoadImages;

		// Token: 0x040000DF RID: 223
		internal System.Windows.Controls.CheckBox CheckBoxAllAccsFiltr;

		// Token: 0x040000E0 RID: 224
		internal System.Windows.Controls.CheckBox checkBoxUnselect;

		// Token: 0x040000E1 RID: 225
		internal System.Windows.Controls.CheckBox RarityCommon;

		// Token: 0x040000E2 RID: 226
		internal System.Windows.Controls.CheckBox RarityLegendary;

		// Token: 0x040000E3 RID: 227
		internal System.Windows.Controls.CheckBox RarityMythical;

		// Token: 0x040000E4 RID: 228
		internal System.Windows.Controls.CheckBox RarityRare;

		// Token: 0x040000E5 RID: 229
		internal System.Windows.Controls.CheckBox RarityUncommon;

		// Token: 0x040000E6 RID: 230
		internal System.Windows.Controls.CheckBox QualityAuspicious;

		// Token: 0x040000E7 RID: 231
		internal System.Windows.Controls.CheckBox QualityCursed;

		// Token: 0x040000E8 RID: 232
		internal System.Windows.Controls.CheckBox QualityFrozen;

		// Token: 0x040000E9 RID: 233
		internal System.Windows.Controls.CheckBox QualityGenuine;

		// Token: 0x040000EA RID: 234
		internal System.Windows.Controls.CheckBox QualityInscribed;

		// Token: 0x040000EB RID: 235
		internal System.Windows.Controls.CheckBox QualityStandard;

		// Token: 0x040000EC RID: 236
		internal System.Windows.Controls.DataGrid dataGridDota;

		// Token: 0x040000ED RID: 237
		internal Image ImageItem;

		// Token: 0x040000EE RID: 238
		internal Grid gridDotaItem;

		// Token: 0x040000EF RID: 239
		internal System.Windows.Controls.ListBox ListBoxAllItems;

		// Token: 0x040000F0 RID: 240
		internal Canvas groupBoxInfo;

		// Token: 0x040000F1 RID: 241
		internal Grid gridViborLll;

		// Token: 0x040000F2 RID: 242
		internal System.Windows.Controls.ListBox ListBoxAllGames;

		// Token: 0x040000F3 RID: 243
		internal System.Windows.Controls.ListBox ListBoxAllInventary;

		// Token: 0x040000F4 RID: 244
		internal System.Windows.Controls.TextBox textBoxInfo;

		// Token: 0x040000F5 RID: 245
		internal System.Windows.Controls.Label LabelextFiltr;

		// Token: 0x040000F6 RID: 246
		internal System.Windows.Controls.TextBox textBoxFiltrText;

		// Token: 0x040000F7 RID: 247
		internal System.Windows.Controls.Label LabelSetTextFiltr;

		// Token: 0x040000F8 RID: 248
		private bool bool_0;

		// Token: 0x040000F9 RID: 249
		[CompilerGenerated]
		private static Func<KeyValuePair<string, int>, int> func_0;

		// Token: 0x040000FA RID: 250
		[CompilerGenerated]
		private static Func<KeyValuePair<string, int>, int> func_1;

		// Token: 0x040000FB RID: 251
		[CompilerGenerated]
		private static Func<KeyValuePair<string, int>, int> func_2;

		// Token: 0x02000013 RID: 19
		private class Class3
		{
			// Token: 0x06000118 RID: 280 RVA: 0x00002B1E File Offset: 0x00000D1E
			[CompilerGenerated]
			public string method_0()
			{
				return this.string_0;
			}

			// Token: 0x06000119 RID: 281 RVA: 0x00002B26 File Offset: 0x00000D26
			[CompilerGenerated]
			public void method_1(string string_3)
			{
				this.string_0 = string_3;
			}

			// Token: 0x0600011A RID: 282 RVA: 0x00002B2F File Offset: 0x00000D2F
			[CompilerGenerated]
			public string method_2()
			{
				return this.string_1;
			}

			// Token: 0x0600011B RID: 283 RVA: 0x00002B37 File Offset: 0x00000D37
			[CompilerGenerated]
			public void nvuQtwFoxe(string string_3)
			{
				this.string_1 = string_3;
			}

			// Token: 0x0600011C RID: 284 RVA: 0x00002B40 File Offset: 0x00000D40
			[CompilerGenerated]
			public string method_3()
			{
				return this.string_2;
			}

			// Token: 0x0600011D RID: 285 RVA: 0x00002B48 File Offset: 0x00000D48
			[CompilerGenerated]
			public void method_4(string string_3)
			{
				this.string_2 = string_3;
			}

			// Token: 0x0600011E RID: 286 RVA: 0x00002B51 File Offset: 0x00000D51
			public List<LogViewer.DotaItemClas> method_5()
			{
				return this.list_0;
			}

			// Token: 0x0600011F RID: 287 RVA: 0x00002B59 File Offset: 0x00000D59
			public void method_6(List<LogViewer.DotaItemClas> value)
			{
				this.list_0 = value;
			}

			// Token: 0x06000120 RID: 288 RVA: 0x00002B62 File Offset: 0x00000D62
			public Class3()
			{
				Class8.ah6VSoGzeNXX5();
				this.list_0 = new List<LogViewer.DotaItemClas>();
				base..ctor();
			}

			// Token: 0x040000FC RID: 252
			private List<LogViewer.DotaItemClas> list_0;

			// Token: 0x040000FD RID: 253
			[CompilerGenerated]
			private string string_0;

			// Token: 0x040000FE RID: 254
			[CompilerGenerated]
			private string string_1;

			// Token: 0x040000FF RID: 255
			[CompilerGenerated]
			private string string_2;
		}

		// Token: 0x02000014 RID: 20
		public class DotaItemClas
		{
			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000121 RID: 289 RVA: 0x00002B7A File Offset: 0x00000D7A
			// (set) Token: 0x06000122 RID: 290 RVA: 0x00002B82 File Offset: 0x00000D82
			public string name { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000123 RID: 291 RVA: 0x00002B8B File Offset: 0x00000D8B
			// (set) Token: 0x06000124 RID: 292 RVA: 0x00002B93 File Offset: 0x00000D93
			public string nameColor { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000125 RID: 293 RVA: 0x00002B9C File Offset: 0x00000D9C
			// (set) Token: 0x06000126 RID: 294 RVA: 0x00002BA4 File Offset: 0x00000DA4
			public string icon_url { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000127 RID: 295 RVA: 0x00002BAD File Offset: 0x00000DAD
			// (set) Token: 0x06000128 RID: 296 RVA: 0x00002BB5 File Offset: 0x00000DB5
			public string qualityName { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000129 RID: 297 RVA: 0x00002BBE File Offset: 0x00000DBE
			// (set) Token: 0x0600012A RID: 298 RVA: 0x00002BC6 File Offset: 0x00000DC6
			public string qualityColor { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600012B RID: 299 RVA: 0x00002BCF File Offset: 0x00000DCF
			// (set) Token: 0x0600012C RID: 300 RVA: 0x00002BD7 File Offset: 0x00000DD7
			public string rarityName { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600012D RID: 301 RVA: 0x00002BE0 File Offset: 0x00000DE0
			// (set) Token: 0x0600012E RID: 302 RVA: 0x00002BE8 File Offset: 0x00000DE8
			public string rarityColor { get; set; }

			// Token: 0x0600012F RID: 303 RVA: 0x00002402 File Offset: 0x00000602
			public DotaItemClas()
			{
				Class8.ah6VSoGzeNXX5();
				base..ctor();
			}

			// Token: 0x04000100 RID: 256
			[CompilerGenerated]
			private string string_0;

			// Token: 0x04000101 RID: 257
			[CompilerGenerated]
			private string string_1;

			// Token: 0x04000102 RID: 258
			[CompilerGenerated]
			private string string_2;

			// Token: 0x04000103 RID: 259
			[CompilerGenerated]
			private string string_3;

			// Token: 0x04000104 RID: 260
			[CompilerGenerated]
			private string string_4;

			// Token: 0x04000105 RID: 261
			[CompilerGenerated]
			private string string_5;

			// Token: 0x04000106 RID: 262
			[CompilerGenerated]
			private string string_6;
		}

		// Token: 0x02000015 RID: 21
		public class DotaDataClas
		{
			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000130 RID: 304 RVA: 0x00002BF1 File Offset: 0x00000DF1
			// (set) Token: 0x06000131 RID: 305 RVA: 0x00002BF9 File Offset: 0x00000DF9
			public string name { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000132 RID: 306 RVA: 0x00002C02 File Offset: 0x00000E02
			// (set) Token: 0x06000133 RID: 307 RVA: 0x00002C0A File Offset: 0x00000E0A
			public string qualityName { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000134 RID: 308 RVA: 0x00002C13 File Offset: 0x00000E13
			// (set) Token: 0x06000135 RID: 309 RVA: 0x00002C1B File Offset: 0x00000E1B
			public string rarityName { get; set; }

			// Token: 0x06000136 RID: 310 RVA: 0x00002402 File Offset: 0x00000602
			public DotaDataClas()
			{
				Class8.ah6VSoGzeNXX5();
				base..ctor();
			}

			// Token: 0x04000107 RID: 263
			[CompilerGenerated]
			private string string_0;

			// Token: 0x04000108 RID: 264
			[CompilerGenerated]
			private string string_1;

			// Token: 0x04000109 RID: 265
			[CompilerGenerated]
			private string string_2;
		}
	}
}
