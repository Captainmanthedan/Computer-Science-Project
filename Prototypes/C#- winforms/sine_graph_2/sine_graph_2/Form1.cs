using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sine_graph_2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int a = 1;
			int b = 0;
			int c = 1;
			int d = 0;

			int i = 0;

			double y;
			int x = 0;

			double[,] points = new double[0,24];

			while (0 <= x && x <= 360)
			{
				y = a * (Math.Sin((c * x) + d)) + b;

				points[0,i] = y;

				MessageBox.Show(Convert.ToString(x));

				x = x + 15;
				i++;
			}

			i = 0;

			while (0 <= x && x <= 360)
			{
				y = points[x, i];

				textBox1.Text = textBox1.Text + "Point (" + x + "," + y + ")";

				x = x + 15;
				i++;
			}

		}
	}
}
