using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reflection
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			int y_corrdinate = 320;
			int LineStart = 50;
			int LineEnd = 540;
			int LineLength = LineEnd - LineStart;
			int x_LineMiddle = LineStart + (LineLength / 2);

			Graphics l = e.Graphics;
			Pen p = new Pen(Color.Black, 8);
			l.DrawLine(p, LineStart, y_corrdinate, LineEnd, y_corrdinate);
			//l.Dispose();

			Array LineMiddle = new Array[LineLength / 2, y_corrdinate];

			Pen q = new Pen(Color.Blue, 8);
			l.DrawLine(q, LineStart, 0, x_LineMiddle, y_corrdinate);
		}
	}
}
