using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reflection2
{
	public partial class Form1 : Form
	{
		Bitmap Draw;
		public Form1()
		{
			InitializeComponent();

			this.AutoSize = true;

			Box.Width = 600;
			Box.Height = 340;

			Box.Image = Draw;

			Box.BackColor = Color.White;
			Box.Show();

			Draw = new Bitmap(Box.Size.Width, Box.Size.Height);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			int y_Start = 10;
			int y_End = 320;
			int LineStart = 50;
			int LineEnd = 550;
			int LineLength = LineEnd - LineStart;
			int LineMiddle = LineStart + (LineLength / 2);

			Graphics g;
			g = Graphics.FromImage(Draw);


			Pen BlackPen = new Pen(Color.Black, 8);
			g.DrawLine(BlackPen, LineStart, y_End, LineEnd, y_End);
		}
	}
}
