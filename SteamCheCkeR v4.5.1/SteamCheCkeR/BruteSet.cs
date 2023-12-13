using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using JLeGNet;
using Microsoft.Win32;

namespace SteamCheCkeR
{
	// Token: 0x02000005 RID: 5
	public class BruteSet : Window, IComponentConnector
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002427 File Offset: 0x00000627
		// (set) Token: 0x06000027 RID: 39 RVA: 0x0000242E File Offset: 0x0000062E
		public static bool _BruteCheckGame { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002436 File Offset: 0x00000636
		// (set) Token: 0x06000029 RID: 41 RVA: 0x0000243D File Offset: 0x0000063D
		public static bool _BruteCheckDota { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002445 File Offset: 0x00000645
		// (set) Token: 0x0600002B RID: 43 RVA: 0x0000244C File Offset: 0x0000064C
		public static bool _BruteNoGameBAD { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002454 File Offset: 0x00000654
		// (set) Token: 0x0600002D RID: 45 RVA: 0x0000245B File Offset: 0x0000065B
		public static bool _BruteCheckSteamId { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002463 File Offset: 0x00000663
		// (set) Token: 0x0600002F RID: 47 RVA: 0x0000246A File Offset: 0x0000066A
		public static bool _BruteBlak { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002472 File Offset: 0x00000672
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002479 File Offset: 0x00000679
		public static bool _BruteChekFullInfo { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002481 File Offset: 0x00000681
		// (set) Token: 0x06000033 RID: 51 RVA: 0x00002488 File Offset: 0x00000688
		public static bool _BruteVacBad { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002490 File Offset: 0x00000690
		// (set) Token: 0x06000035 RID: 53 RVA: 0x00002497 File Offset: 0x00000697
		public static bool _BruteCheckInventar { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000249F File Offset: 0x0000069F
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000024A6 File Offset: 0x000006A6
		public static bool _BruteBanBad { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000024AE File Offset: 0x000006AE
		// (set) Token: 0x06000039 RID: 57 RVA: 0x000024B5 File Offset: 0x000006B5
		public static bool _Brute0LvlBad { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003A RID: 58 RVA: 0x000024BD File Offset: 0x000006BD
		// (set) Token: 0x0600003B RID: 59 RVA: 0x000024C4 File Offset: 0x000006C4
		public static bool _BruteCheckPrice { get; set; }

		// Token: 0x0600003C RID: 60 RVA: 0x000024CC File Offset: 0x000006CC
		public BruteSet()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
			this.InitializeComponent();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000596C File Offset: 0x00003B6C
		private void CheckBoxBlackList_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.CheckBoxCheckDota.IsChecked.Value)
				{
					BruteSet._BruteCheckDota = true;
				}
				else
				{
					BruteSet._BruteCheckDota = false;
				}
				if (this.CheckBoxCheckGame.IsChecked.Value)
				{
					BruteSet._BruteCheckGame = true;
				}
				else
				{
					BruteSet._BruteCheckGame = false;
				}
				if (this.CheckBoxCheckInventar.IsChecked.Value)
				{
					BruteSet._BruteCheckInventar = true;
				}
				else
				{
					BruteSet._BruteCheckInventar = false;
				}
				if (this.CheckBoxNoGameBad.IsChecked.Value)
				{
					BruteSet._BruteNoGameBAD = true;
				}
				else
				{
					BruteSet._BruteNoGameBAD = false;
				}
				if (this.CheckBoxCheckBanBad.IsChecked.Value)
				{
					BruteSet._BruteBanBad = true;
				}
				else
				{
					BruteSet._BruteBanBad = false;
				}
				if (this.CheckBoxCheckLvlBad.IsChecked.Value)
				{
					BruteSet._Brute0LvlBad = true;
				}
				else
				{
					BruteSet._Brute0LvlBad = false;
				}
				if (this.CheckBoxCheckPrice.IsChecked.Value)
				{
					BruteSet._BruteCheckPrice = true;
				}
				else
				{
					BruteSet._BruteCheckPrice = false;
				}
				if (this.CheckBoxCheckSteamId.IsChecked.Value)
				{
					BruteSet._BruteCheckSteamId = true;
				}
				else
				{
					BruteSet._BruteCheckSteamId = false;
				}
				if (this.CheckBoxCheckFullInfo.IsChecked.Value)
				{
					BruteSet._BruteChekFullInfo = true;
				}
				else
				{
					BruteSet._BruteChekFullInfo = false;
				}
				if (this.CheckBoxCheckVacBad.IsChecked.Value)
				{
					BruteSet._BruteVacBad = true;
				}
				else
				{
					BruteSet._BruteVacBad = false;
				}
				if (this.CheckBoxBlackList.IsChecked.Value)
				{
					BruteSet._BruteBlak = true;
				}
				else
				{
					BruteSet._BruteBlak = false;
				}
				this.method_0();
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005B2C File Offset: 0x00003D2C
		private void method_0()
		{
			try
			{
				this.CheckBoxCheckGame.IsEnabled = true;
				this.CheckBoxCheckFullInfo.IsEnabled = true;
				this.CheckBoxCheckSteamId.IsEnabled = true;
				this.CheckBoxCheckInventar.IsEnabled = true;
				if (BruteSet.bool_4)
				{
					this.CheckBoxCheckSteamId.IsChecked = new bool?(true);
				}
				if (BruteSet.bool_8)
				{
					this.CheckBoxCheckInventar.IsChecked = new bool?(true);
					this.CheckBoxCheckDota.IsEnabled = true;
					if (BruteSet.bool_2)
					{
						this.CheckBoxCheckDota.IsChecked = new bool?(true);
					}
				}
				else
				{
					this.CheckBoxCheckDota.IsEnabled = false;
					this.CheckBoxCheckDota.IsChecked = new bool?(false);
				}
				if (BruteSet.bool_1)
				{
					this.CheckBoxCheckGame.IsChecked = new bool?(true);
					this.CheckBoxNoGameBad.IsEnabled = true;
					this.CheckBoxBlackList.IsEnabled = true;
					this.CheckBoxCheckPrice.IsEnabled = true;
					if (BruteSet.bool_3)
					{
						this.CheckBoxNoGameBad.IsChecked = new bool?(true);
					}
					if (BruteSet.bool_11)
					{
						this.CheckBoxCheckPrice.IsChecked = new bool?(true);
					}
					if (BruteSet.bool_5)
					{
						this.CheckBoxBlackList.IsChecked = new bool?(true);
						this.textBoxBlack.IsEnabled = true;
						this.listBoxBlack.IsEnabled = true;
						this.ButonAddUrlProxy.IsEnabled = true;
						this.ButonDelBlack.IsEnabled = true;
					}
				}
				else
				{
					this.CheckBoxNoGameBad.IsEnabled = false;
					this.CheckBoxNoGameBad.IsChecked = new bool?(false);
					this.CheckBoxBlackList.IsEnabled = false;
					this.CheckBoxBlackList.IsChecked = new bool?(false);
					this.CheckBoxCheckPrice.IsChecked = new bool?(false);
					this.CheckBoxCheckPrice.IsEnabled = false;
					this.textBoxBlack.IsEnabled = false;
					this.listBoxBlack.IsEnabled = false;
					this.ButonAddUrlProxy.IsEnabled = false;
					this.ButonDelBlack.IsEnabled = false;
				}
				if (BruteSet.bool_6)
				{
					this.CheckBoxCheckFullInfo.IsChecked = new bool?(true);
					this.CheckBoxCheckVacBad.IsEnabled = true;
					this.CheckBoxCheckBanBad.IsEnabled = true;
					this.CheckBoxCheckLvlBad.IsEnabled = true;
					if (BruteSet.bool_7)
					{
						this.CheckBoxCheckVacBad.IsChecked = new bool?(true);
					}
					if (BruteSet.bool_9)
					{
						this.CheckBoxCheckBanBad.IsChecked = new bool?(true);
					}
					if (BruteSet.bool_10)
					{
						this.CheckBoxCheckLvlBad.IsChecked = new bool?(true);
					}
				}
				else
				{
					this.CheckBoxCheckVacBad.IsEnabled = false;
					this.CheckBoxCheckVacBad.IsChecked = new bool?(false);
					this.CheckBoxCheckBanBad.IsEnabled = false;
					this.CheckBoxCheckBanBad.IsChecked = new bool?(false);
					this.CheckBoxCheckLvlBad.IsEnabled = false;
					this.CheckBoxCheckLvlBad.IsChecked = new bool?(false);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00005E24 File Offset: 0x00004024
		private void method_1(object sender, RoutedEventArgs e)
		{
			BruteSet._BruteNoGameBAD = Class1.smethod_30();
			BruteSet._BruteBanBad = Class1.smethod_40();
			BruteSet._Brute0LvlBad = Class1.kGatfvmMh4();
			BruteSet._BruteCheckPrice = Class1.smethod_45();
			BruteSet._BruteCheckSteamId = Class1.smethod_32();
			BruteSet._BruteBlak = Class1.smethod_34();
			BruteSet._BruteCheckGame = Class1.pyMtamktSp();
			BruteSet._BruteCheckDota = Class1.smethod_23();
			BruteSet._BruteCheckInventar = Class1.smethod_43();
			BruteSet._BruteChekFullInfo = Class1.smethod_36();
			BruteSet._BruteVacBad = Class1.smethod_38();
			if (Class1.CheckBoxRecoveryAcc)
			{
				this.CheckBoxRecoveryAcc.IsChecked = new bool?(true);
				this.CheckBoxUseAntigate.IsEnabled = true;
				this.CheckBoxRecoveryLogins.IsEnabled = true;
				if (Class1.CheckBoxUseAntigate)
				{
					this.CheckBoxUseAntigate.IsChecked = new bool?(true);
					this.TextBoxAntigateKey.IsReadOnly = false;
					this.LabelAntigateBalance.IsEnabled = true;
				}
				else
				{
					this.CheckBoxUseAntigate.IsChecked = new bool?(false);
					this.TextBoxAntigateKey.IsReadOnly = true;
					this.LabelAntigateBalance.IsEnabled = false;
				}
				if (Class1.CheckBoxRecoveryLogins)
				{
					this.CheckBoxRecoveryLogins.IsChecked = new bool?(true);
				}
				else
				{
					this.CheckBoxRecoveryLogins.IsChecked = new bool?(false);
				}
			}
			else
			{
				this.CheckBoxUseAntigate.IsEnabled = false;
				this.CheckBoxUseAntigate.IsChecked = new bool?(false);
				this.CheckBoxRecoveryLogins.IsEnabled = false;
				this.CheckBoxRecoveryLogins.IsChecked = new bool?(false);
				this.TextBoxAntigateKey.IsReadOnly = true;
				this.LabelAntigateBalance.IsEnabled = false;
				this.CheckBoxRecoveryAcc.IsChecked = new bool?(false);
			}
			if (Class1.CheckBoxFindAcc)
			{
				this.CheckBoxFindAcc.IsChecked = new bool?(true);
				this.CheckBoxFindAccSearch.IsEnabled = true;
				if (Class1.CheckBoxFindAccSearch)
				{
					this.CheckBoxFindAccSearch.IsChecked = new bool?(true);
				}
				else
				{
					this.CheckBoxFindAccSearch.IsChecked = new bool?(false);
				}
			}
			else
			{
				this.CheckBoxFindAcc.IsChecked = new bool?(false);
				this.CheckBoxFindAccSearch.IsChecked = new bool?(false);
				this.CheckBoxFindAccSearch.IsEnabled = false;
			}
			this.TextBoxAntigateKey.Text = Class1.smethod_2();
			foreach (string newItem in Class1.list_2)
			{
				this.listBoxBlack.Items.Add(newItem);
			}
			this.method_0();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000060A4 File Offset: 0x000042A4
		private void method_2(object sender, EventArgs e)
		{
			Class1.smethod_31(BruteSet.bool_3);
			Class1.smethod_41(BruteSet.bool_9);
			Class1.smethod_42(BruteSet.bool_10);
			Class1.smethod_46(BruteSet.bool_11);
			Class1.smethod_33(BruteSet.bool_4);
			Class1.smethod_35(BruteSet.bool_5);
			Class1.smethod_29(BruteSet.bool_1);
			Class1.smethod_24(BruteSet.bool_2);
			Class1.smethod_44(BruteSet.bool_8);
			Class1.smethod_37(BruteSet.bool_6);
			Class1.smethod_39(BruteSet.bool_7);
			BruteSet._BruteChekFullInfo = Class1.smethod_36();
			BruteSet._BruteVacBad = Class1.smethod_38();
			Class1.smethod_3(this.TextBoxAntigateKey.Text);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000024DF File Offset: 0x000006DF
		private void listBoxBlack_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Delete && this.listBoxBlack.SelectedItems.Count > 0)
			{
				this.ButonDelBlack_Click(null, null);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00006144 File Offset: 0x00004344
		private void ButonAddUrlProxy_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.textBoxBlack.Text))
			{
				MessageBox.Show("Пустая информация!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (Class1.list_2.Contains(this.textBoxBlack.Text))
			{
				MessageBox.Show("Ссылка уже есть в списке!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			Class1.list_2.Add(this.textBoxBlack.Text);
			this.listBoxBlack.Items.Clear();
			foreach (string newItem in Class1.list_2)
			{
				this.listBoxBlack.Items.Add(newItem);
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00006218 File Offset: 0x00004418
		private void ButonDelBlack_Click(object sender, RoutedEventArgs e)
		{
			if (this.listBoxBlack.SelectedItems.Count == 0)
			{
				MessageBox.Show("Выберите что удалять!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			foreach (object obj in this.listBoxBlack.SelectedItems)
			{
				Class1.list_2.Remove(obj.ToString());
			}
			this.listBoxBlack.Items.Clear();
			foreach (string newItem in Class1.list_2)
			{
				this.listBoxBlack.Items.Add(newItem);
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002506 File Offset: 0x00000706
		private void buttonStart_Click(object sender, RoutedEventArgs e)
		{
			this.method_2(null, null);
			base.Close();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00006304 File Offset: 0x00004504
		private void LabellogViewer_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (MessageBox.Show("Загрузить общий список бесплатных Игр?", "Вопросик!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				foreach (string item in MainWindow._FreeGameList)
				{
					if (!Class1.list_2.Contains(item))
					{
						Class1.list_2.Add(item);
					}
				}
				this.listBoxBlack.Items.Clear();
				foreach (string newItem in Class1.list_2)
				{
					this.listBoxBlack.Items.Add(newItem);
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000063E0 File Offset: 0x000045E0
		private void LabelAntigateBalance_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (!string.IsNullOrEmpty(this.TextBoxAntigateKey.Text) && !(this.TextBoxAntigateKey.Text == ""))
			{
				try
				{
					string text = null;
					AntiCaptcha antiCaptcha = new AntiCaptcha(this.TextBoxAntigateKey.Text);
					string balance = antiCaptcha.GetBalance(ref text);
					if (!string.IsNullOrEmpty(text))
					{
						MessageBox.Show(text, "Error Antigate", MessageBoxButton.OK, MessageBoxImage.Exclamation);
					}
					else if (balance.Contains("ERROR"))
					{
						MessageBox.Show(balance, "Error Antigate", MessageBoxButton.OK, MessageBoxImage.Exclamation);
					}
					else
					{
						MessageBox.Show("Ваш баланс: " + balance.ToString(), "Antigate Balance", MessageBoxButton.OK, MessageBoxImage.Asterisk);
					}
				}
				catch (Exception)
				{
				}
				return;
			}
			MessageBox.Show("Недопустимое значение! Пустой ключ!", "Error Antigate", MessageBoxButton.OK, MessageBoxImage.Exclamation);
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000064B4 File Offset: 0x000046B4
		private void CheckBoxRecoveryAcc_Click(object sender, RoutedEventArgs e)
		{
			if (this.CheckBoxRecoveryAcc.IsChecked == true)
			{
				this.CheckBoxUseAntigate.IsEnabled = true;
				this.CheckBoxRecoveryLogins.IsEnabled = true;
				Class1.CheckBoxRecoveryAcc = true;
				return;
			}
			Class1.CheckBoxRecoveryAcc = false;
			this.CheckBoxUseAntigate.IsEnabled = false;
			this.CheckBoxUseAntigate.IsChecked = new bool?(false);
			this.CheckBoxRecoveryLogins.IsEnabled = false;
			this.CheckBoxRecoveryLogins.IsChecked = new bool?(false);
			this.TextBoxAntigateKey.IsReadOnly = true;
			this.LabelAntigateBalance.IsEnabled = false;
			this.CheckBoxRecoveryAcc.IsChecked = new bool?(false);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x0000656C File Offset: 0x0000476C
		private void CheckBoxFindAcc_Click(object sender, RoutedEventArgs e)
		{
			if (!(this.CheckBoxFindAcc.IsChecked == true))
			{
				Class1.CheckBoxFindAcc = false;
				this.CheckBoxFindAccSearch.IsEnabled = false;
				this.CheckBoxFindAccSearch.IsChecked = new bool?(false);
				Class1.CheckBoxFindAccSearch = false;
				return;
			}
			Class1.CheckBoxFindAcc = true;
			this.CheckBoxFindAccSearch.IsEnabled = true;
			if (Class1.CheckBoxFindAccSearch)
			{
				this.CheckBoxFindAccSearch.IsChecked = new bool?(true);
				return;
			}
			this.CheckBoxFindAccSearch.IsChecked = new bool?(false);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00006600 File Offset: 0x00004800
		private void CheckBoxUseAntigate_Click(object sender, RoutedEventArgs e)
		{
			if (this.CheckBoxUseAntigate.IsChecked == true)
			{
				Class1.CheckBoxUseAntigate = true;
				this.TextBoxAntigateKey.IsReadOnly = false;
				this.LabelAntigateBalance.IsEnabled = true;
				return;
			}
			Class1.CheckBoxUseAntigate = false;
			this.TextBoxAntigateKey.IsReadOnly = true;
			this.LabelAntigateBalance.IsEnabled = false;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000666C File Offset: 0x0000486C
		private void CheckBoxFindAccSearch_Click(object sender, RoutedEventArgs e)
		{
			if (this.CheckBoxUseAntigate.IsChecked == false)
			{
				Class1.CheckBoxFindAccSearch = false;
				return;
			}
			try
			{
				if (Class1.list_1.Any<string>() && MessageBox.Show("В конфигурации уже присутсвует база валиндных аккаунтов: " + Class1.list_1.Count.ToString() + "\r\nПодгрузить их?", "Вопросик...", MessageBoxButton.YesNo, MessageBoxImage.Hand) == MessageBoxResult.Yes)
				{
					Class1.CheckBoxFindAccSearch = true;
				}
				else if (MessageBox.Show("Для активации данной опции нужно указать базу валидных Аккаунтов!", "Указать базу аккаунтов...", MessageBoxButton.YesNo, MessageBoxImage.Hand) == MessageBoxResult.Yes)
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
					openFileDialog.Filter = "text files|*.txt";
					if (openFileDialog.ShowDialog() == true)
					{
						Class1.list_1.Clear();
						foreach (string text in File.ReadAllLines(openFileDialog.FileName).Distinct<string>())
						{
							if (!string.IsNullOrEmpty(text) && text.Length > 7)
							{
								Class1.list_1.Add(text);
							}
						}
						if (!Class1.list_1.Any<string>())
						{
							MessageBox.Show("Вы указали пустой файл аккаунтов!", "Ошибка...", MessageBoxButton.OK, MessageBoxImage.Hand);
							this.CheckBoxFindAccSearch.IsChecked = new bool?(false);
							Class1.CheckBoxFindAccSearch = false;
						}
						else
						{
							if (Class1.string_2 != null)
							{
								File.WriteAllLines(Class1.string_2, Class1.list_1);
							}
							Class1.CheckBoxFindAccSearch = true;
						}
					}
					else
					{
						this.CheckBoxFindAccSearch.IsChecked = new bool?(false);
						Class1.CheckBoxFindAccSearch = false;
					}
				}
				else
				{
					this.CheckBoxFindAccSearch.IsChecked = new bool?(false);
					Class1.CheckBoxFindAccSearch = false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка...", MessageBoxButton.OK, MessageBoxImage.Hand);
				Class1.CheckBoxFindAccSearch = false;
				this.CheckBoxFindAccSearch.IsChecked = new bool?(false);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00006890 File Offset: 0x00004A90
		private void CheckBoxRecoveryLogins_Click(object sender, RoutedEventArgs e)
		{
			if (this.CheckBoxRecoveryLogins.IsChecked == true)
			{
				Class1.CheckBoxRecoveryLogins = true;
				return;
			}
			Class1.CheckBoxRecoveryLogins = false;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000068CC File Offset: 0x00004ACC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			Uri resourceLocator = new Uri("/SteamCheCkeR v4.5.1;component/windows/bruteset.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000068FC File Offset: 0x00004AFC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				((BruteSet)target).Loaded += this.method_1;
				((BruteSet)target).Closed += this.method_2;
				return;
			case 2:
				this.CheckBoxRecoveryAcc = (CheckBox)target;
				this.CheckBoxRecoveryAcc.Click += this.CheckBoxRecoveryAcc_Click;
				return;
			case 3:
				this.CheckBoxRecoveryLogins = (CheckBox)target;
				this.CheckBoxRecoveryLogins.Click += this.CheckBoxRecoveryLogins_Click;
				return;
			case 4:
				this.CheckBoxUseAntigate = (CheckBox)target;
				this.CheckBoxUseAntigate.Click += this.CheckBoxUseAntigate_Click;
				return;
			case 5:
				this.LabelAntigateBalance = (Label)target;
				this.LabelAntigateBalance.MouseDown += this.LabelAntigateBalance_MouseDown;
				return;
			case 6:
				this.TextBoxAntigateKey = (TextBox)target;
				return;
			case 7:
				this.CheckBoxFindAcc = (CheckBox)target;
				this.CheckBoxFindAcc.Click += this.CheckBoxFindAcc_Click;
				return;
			case 8:
				this.CheckBoxFindAccSearch = (CheckBox)target;
				this.CheckBoxFindAccSearch.Click += this.CheckBoxFindAccSearch_Click;
				return;
			case 9:
				this.CheckBoxCheckGame = (CheckBox)target;
				this.CheckBoxCheckGame.Click += this.CheckBoxBlackList_Click;
				return;
			case 10:
				this.CheckBoxNoGameBad = (CheckBox)target;
				this.CheckBoxNoGameBad.Click += this.CheckBoxBlackList_Click;
				return;
			case 11:
				this.CheckBoxCheckPrice = (CheckBox)target;
				this.CheckBoxCheckPrice.Click += this.CheckBoxBlackList_Click;
				return;
			case 12:
				this.CheckBoxCheckSteamId = (CheckBox)target;
				this.CheckBoxCheckSteamId.Click += this.CheckBoxBlackList_Click;
				return;
			case 13:
				this.CheckBoxCheckFullInfo = (CheckBox)target;
				this.CheckBoxCheckFullInfo.Click += this.CheckBoxBlackList_Click;
				return;
			case 14:
				this.CheckBoxCheckVacBad = (CheckBox)target;
				this.CheckBoxCheckVacBad.Click += this.CheckBoxBlackList_Click;
				return;
			case 15:
				this.CheckBoxCheckBanBad = (CheckBox)target;
				this.CheckBoxCheckBanBad.Click += this.CheckBoxBlackList_Click;
				return;
			case 16:
				this.CheckBoxCheckLvlBad = (CheckBox)target;
				this.CheckBoxCheckLvlBad.Click += this.CheckBoxBlackList_Click;
				return;
			case 17:
				this.CheckBoxCheckInventar = (CheckBox)target;
				this.CheckBoxCheckInventar.Click += this.CheckBoxBlackList_Click;
				return;
			case 18:
				this.CheckBoxCheckDota = (CheckBox)target;
				this.CheckBoxCheckDota.Click += this.CheckBoxBlackList_Click;
				return;
			case 19:
				this.CheckBoxBlackList = (CheckBox)target;
				this.CheckBoxBlackList.Click += this.CheckBoxBlackList_Click;
				return;
			case 20:
				this.LabellogViewer = (Label)target;
				this.LabellogViewer.MouseDown += this.LabellogViewer_MouseDown;
				return;
			case 21:
				this.listBoxBlack = (ListBox)target;
				this.listBoxBlack.KeyDown += this.listBoxBlack_KeyDown;
				return;
			case 22:
				this.textBoxBlack = (TextBox)target;
				return;
			case 23:
				this.ButonDelBlack = (Button)target;
				this.ButonDelBlack.Click += this.ButonDelBlack_Click;
				return;
			case 24:
				this.ButonAddUrlProxy = (Button)target;
				this.ButonAddUrlProxy.Click += this.ButonAddUrlProxy_Click;
				return;
			case 25:
				this.buttonStart = (Button)target;
				this.buttonStart.Click += this.buttonStart_Click;
				return;
			default:
				this.bool_0 = true;
				return;
			}
		}

		// Token: 0x04000029 RID: 41
		internal CheckBox CheckBoxRecoveryAcc;

		// Token: 0x0400002A RID: 42
		internal CheckBox CheckBoxRecoveryLogins;

		// Token: 0x0400002B RID: 43
		internal CheckBox CheckBoxUseAntigate;

		// Token: 0x0400002C RID: 44
		internal Label LabelAntigateBalance;

		// Token: 0x0400002D RID: 45
		internal TextBox TextBoxAntigateKey;

		// Token: 0x0400002E RID: 46
		internal CheckBox CheckBoxFindAcc;

		// Token: 0x0400002F RID: 47
		internal CheckBox CheckBoxFindAccSearch;

		// Token: 0x04000030 RID: 48
		internal CheckBox CheckBoxCheckGame;

		// Token: 0x04000031 RID: 49
		internal CheckBox CheckBoxNoGameBad;

		// Token: 0x04000032 RID: 50
		internal CheckBox CheckBoxCheckPrice;

		// Token: 0x04000033 RID: 51
		internal CheckBox CheckBoxCheckSteamId;

		// Token: 0x04000034 RID: 52
		internal CheckBox CheckBoxCheckFullInfo;

		// Token: 0x04000035 RID: 53
		internal CheckBox CheckBoxCheckVacBad;

		// Token: 0x04000036 RID: 54
		internal CheckBox CheckBoxCheckBanBad;

		// Token: 0x04000037 RID: 55
		internal CheckBox CheckBoxCheckLvlBad;

		// Token: 0x04000038 RID: 56
		internal CheckBox CheckBoxCheckInventar;

		// Token: 0x04000039 RID: 57
		internal CheckBox CheckBoxCheckDota;

		// Token: 0x0400003A RID: 58
		internal CheckBox CheckBoxBlackList;

		// Token: 0x0400003B RID: 59
		internal Label LabellogViewer;

		// Token: 0x0400003C RID: 60
		internal ListBox listBoxBlack;

		// Token: 0x0400003D RID: 61
		internal TextBox textBoxBlack;

		// Token: 0x0400003E RID: 62
		internal Button ButonDelBlack;

		// Token: 0x0400003F RID: 63
		internal Button ButonAddUrlProxy;

		// Token: 0x04000040 RID: 64
		internal Button buttonStart;

		// Token: 0x04000041 RID: 65
		private bool bool_0;

		// Token: 0x04000042 RID: 66
		[CompilerGenerated]
		private static bool bool_1;

		// Token: 0x04000043 RID: 67
		[CompilerGenerated]
		private static bool bool_2;

		// Token: 0x04000044 RID: 68
		[CompilerGenerated]
		private static bool bool_3;

		// Token: 0x04000045 RID: 69
		[CompilerGenerated]
		private static bool bool_4;

		// Token: 0x04000046 RID: 70
		[CompilerGenerated]
		private static bool bool_5;

		// Token: 0x04000047 RID: 71
		[CompilerGenerated]
		private static bool bool_6;

		// Token: 0x04000048 RID: 72
		[CompilerGenerated]
		private static bool bool_7;

		// Token: 0x04000049 RID: 73
		[CompilerGenerated]
		private static bool bool_8;

		// Token: 0x0400004A RID: 74
		[CompilerGenerated]
		private static bool bool_9;

		// Token: 0x0400004B RID: 75
		[CompilerGenerated]
		private static bool bool_10;

		// Token: 0x0400004C RID: 76
		[CompilerGenerated]
		private static bool bool_11;
	}
}
