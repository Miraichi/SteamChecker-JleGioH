using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ns0
{
	// Token: 0x0200005A RID: 90
	internal partial class rFohpatkdxsVcxLfJKhM7 : Form
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x00003ED9 File Offset: 0x000020D9
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x00003EE6 File Offset: 0x000020E6
		public string Snag_Caption
		{
			get
			{
				return this.label1.Text;
			}
			set
			{
				this.label1.Text = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00003ED9 File Offset: 0x000020D9
		// (set) Token: 0x060003BB RID: 955 RVA: 0x00003EE6 File Offset: 0x000020E6
		public string MessageBoxCaption
		{
			get
			{
				return this.label1.Text;
			}
			set
			{
				this.label1.Text = value;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060003BC RID: 956 RVA: 0x00003EF4 File Offset: 0x000020F4
		// (set) Token: 0x060003BD RID: 957 RVA: 0x00003F01 File Offset: 0x00002101
		public string Snag_Text
		{
			get
			{
				return this.label2.Text;
			}
			set
			{
				this.label2.Text = value;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060003BE RID: 958 RVA: 0x00003EF4 File Offset: 0x000020F4
		// (set) Token: 0x060003BF RID: 959 RVA: 0x00003F01 File Offset: 0x00002101
		public string MessageBoxText
		{
			get
			{
				return this.label2.Text;
			}
			set
			{
				this.label2.Text = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x00003F0F File Offset: 0x0000210F
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x00003F1C File Offset: 0x0000211C
		public Color Gradient_Begin
		{
			get
			{
				return this.panel1.method_0();
			}
			set
			{
				this.panel1.method_1(value);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x00003F0F File Offset: 0x0000210F
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x00003F1C File Offset: 0x0000211C
		public Color MessageBoxGradientBegin
		{
			get
			{
				return this.panel1.method_0();
			}
			set
			{
				this.panel1.method_1(value);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x00003F2A File Offset: 0x0000212A
		// (set) Token: 0x060003C5 RID: 965 RVA: 0x00003F37 File Offset: 0x00002137
		public Color MessageBoxGradientEnd
		{
			get
			{
				return this.panel1.method_11();
			}
			set
			{
				this.panel1.method_12(value);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x00003F2A File Offset: 0x0000212A
		// (set) Token: 0x060003C7 RID: 967 RVA: 0x00003F37 File Offset: 0x00002137
		public Color Gradient_End
		{
			get
			{
				return this.panel1.method_11();
			}
			set
			{
				this.panel1.method_12(value);
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00003F45 File Offset: 0x00002145
		public rFohpatkdxsVcxLfJKhM7()
		{
			Class8.ah6VSoGzeNXX5();
			base..ctor();
			this.InitializeComponent();
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00003F77 File Offset: 0x00002177
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0200005B RID: 91
		internal class Class36 : Panel
		{
			// Token: 0x060003CC RID: 972 RVA: 0x00003F7F File Offset: 0x0000217F
			public Color method_0()
			{
				return this.color_0;
			}

			// Token: 0x060003CD RID: 973 RVA: 0x00003F87 File Offset: 0x00002187
			public void method_1(Color color_2)
			{
				this.color_0 = color_2;
				base.Invalidate();
			}

			// Token: 0x060003CE RID: 974 RVA: 0x00003F96 File Offset: 0x00002196
			public bool method_2()
			{
				return this.bool_4;
			}

			// Token: 0x060003CF RID: 975 RVA: 0x00003F9E File Offset: 0x0000219E
			public void TuLsjpOvKB(bool bool_5)
			{
				this.bool_4 = bool_5;
				base.Invalidate();
			}

			// Token: 0x060003D0 RID: 976 RVA: 0x00003FAD File Offset: 0x000021AD
			public bool method_3()
			{
				return this.bool_0;
			}

			// Token: 0x060003D1 RID: 977 RVA: 0x00003FB5 File Offset: 0x000021B5
			public void method_4(bool bool_5)
			{
				this.bool_0 = bool_5;
				base.Invalidate();
			}

			// Token: 0x060003D2 RID: 978 RVA: 0x00003FC4 File Offset: 0x000021C4
			public bool method_5()
			{
				return this.bool_2;
			}

			// Token: 0x060003D3 RID: 979 RVA: 0x00003FCC File Offset: 0x000021CC
			public void method_6(bool bool_5)
			{
				this.bool_2 = bool_5;
				base.Invalidate();
			}

			// Token: 0x060003D4 RID: 980 RVA: 0x00003FDB File Offset: 0x000021DB
			public bool method_7()
			{
				return this.bool_3;
			}

			// Token: 0x060003D5 RID: 981 RVA: 0x00003FE3 File Offset: 0x000021E3
			public void method_8(bool bool_5)
			{
				this.bool_3 = bool_5;
				base.Invalidate();
			}

			// Token: 0x060003D6 RID: 982 RVA: 0x00003FF2 File Offset: 0x000021F2
			public bool method_9()
			{
				return this.bool_1;
			}

			// Token: 0x060003D7 RID: 983 RVA: 0x00003FFA File Offset: 0x000021FA
			public void method_10(bool bool_5)
			{
				this.bool_1 = bool_5;
				base.Invalidate();
			}

			// Token: 0x060003D8 RID: 984 RVA: 0x00004009 File Offset: 0x00002209
			public Color method_11()
			{
				return this.color_1;
			}

			// Token: 0x060003D9 RID: 985 RVA: 0x00004011 File Offset: 0x00002211
			public void method_12(Color color_2)
			{
				this.color_1 = color_2;
				base.Invalidate();
			}

			// Token: 0x060003DA RID: 986 RVA: 0x0002B164 File Offset: 0x00029364
			public Class36()
			{
				Class8.ah6VSoGzeNXX5();
				base..ctor();
				base.SetStyle(ControlStyles.ResizeRedraw, true);
				base.SetStyle(ControlStyles.DoubleBuffer, true);
				base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
				base.SetStyle(ControlStyles.UserPaint, true);
				base.SetStyle(ControlStyles.ContainerControl, true);
				this.color_0 = SystemColors.ActiveCaption;
				this.color_1 = SystemColors.Control;
				this.bool_0 = true;
				this.bool_1 = true;
				this.bool_2 = false;
				this.bool_4 = false;
				this.bool_3 = true;
			}

			// Token: 0x060003DB RID: 987 RVA: 0x0002B1E8 File Offset: 0x000293E8
			protected override void OnPaint(PaintEventArgs e)
			{
				Color color = this.color_0;
				Color color2 = this.color_1;
				LinearGradientMode linearGradientMode;
				if (this.bool_0)
				{
					linearGradientMode = LinearGradientMode.Horizontal;
				}
				else
				{
					linearGradientMode = LinearGradientMode.Vertical;
				}
				if (!this.bool_1)
				{
					color = this.color_1;
					color2 = this.color_0;
				}
				if (this.bool_2)
				{
					if (this.bool_3)
					{
						linearGradientMode = LinearGradientMode.ForwardDiagonal;
					}
					else
					{
						linearGradientMode = LinearGradientMode.BackwardDiagonal;
					}
				}
				if (base.Width > 0 && base.Height > 0)
				{
					Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
					LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, color, color2, linearGradientMode);
					if (!this.bool_4)
					{
						e.Graphics.FillRectangle(linearGradientBrush, rect);
					}
					else
					{
						linearGradientBrush.SetSigmaBellShape(0.7f);
						e.Graphics.FillRectangle(linearGradientBrush, rect);
					}
					new SolidBrush(this.ForeColor);
				}
			}

			// Token: 0x040002D5 RID: 725
			private Color color_0;

			// Token: 0x040002D6 RID: 726
			private Color color_1;

			// Token: 0x040002D7 RID: 727
			private bool bool_0;

			// Token: 0x040002D8 RID: 728
			private bool bool_1;

			// Token: 0x040002D9 RID: 729
			private bool bool_2;

			// Token: 0x040002DA RID: 730
			private bool bool_3;

			// Token: 0x040002DB RID: 731
			private bool bool_4;
		}
	}
}
