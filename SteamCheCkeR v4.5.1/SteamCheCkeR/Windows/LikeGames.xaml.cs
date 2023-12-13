using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace SteamCheCkeR.Windows
{
	// Token: 0x02000010 RID: 16
	public partial class LikeGames : Window
	{
		// Token: 0x060000EE RID: 238 RVA: 0x00002A57 File Offset: 0x00000C57
		public LikeGames()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
			this.InitializeComponent();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00002A6A File Offset: 0x00000C6A
		private void listBoxLike_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Delete && this.listBoxLike.SelectedItems.Count > 0)
			{
				this.ButonDelBlack_Click(null, null);
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000087AC File Offset: 0x000069AC
		private void ButonAddUrlProxy_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(this.textBoxBlack.Text))
			{
				MessageBox.Show("Пустая информация!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			if (Class1.list_3.Contains(this.textBoxBlack.Text))
			{
				MessageBox.Show("Ссылка уже есть в списке!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			Class1.list_3.Add(this.textBoxBlack.Text);
			this.listBoxLike.Items.Clear();
			foreach (string newItem in Class1.list_3)
			{
				this.listBoxLike.Items.Add(newItem);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00008880 File Offset: 0x00006A80
		private void ButonDelBlack_Click(object sender, RoutedEventArgs e)
		{
			if (this.listBoxLike.SelectedItems.Count == 0)
			{
				MessageBox.Show("Выберите что удалять!", "Error!", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			foreach (object obj in this.listBoxLike.SelectedItems)
			{
				Class1.list_3.Remove(obj.ToString());
			}
			this.listBoxLike.Items.Clear();
			foreach (string newItem in Class1.list_3)
			{
				this.listBoxLike.Items.Add(newItem);
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00002A91 File Offset: 0x00000C91
		private void buttonStart_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000896C File Offset: 0x00006B6C
		private void method_0(object sender, RoutedEventArgs e)
		{
			foreach (string newItem in Class1.list_3)
			{
				this.listBoxLike.Items.Add(newItem);
			}
		}
	}
}
