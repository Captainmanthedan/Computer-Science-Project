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

			int i = 0;

			int x_corrdinate = 0;
			double y_corrdinate;

<<<<<<< HEAD
			double x;
=======
			double[] points = new double[17];
>>>>>>> f527bc559252d57d26c36c518a3782445d098ea1

			textBox1.Text = "";

			while (0 <= x_corrdinate && x_corrdinate <= 1440)
			{
				x = x_corrdinate * (Math.PI / 180);

<<<<<<< HEAD
				y_corrdinate = Math.Sin(x);

				y_corrdinate = Math.Round(y_corrdinate);
=======
				y = Math.Round(y);

				points[i] = y;
>>>>>>> f527bc559252d57d26c36c518a3782445d098ea1

				textBox1.Text = textBox1.Text + "(" + x_corrdinate + ", " + y_corrdinate + ")";
				textBox1.AppendText(Environment.NewLine);

				x_corrdinate = x_corrdinate + 90;
				i++;
			}
<<<<<<< HEAD
=======

			MessageBox.Show(s);

			i = 0;
			x = 0;

			while (0 <= x && x <= 1440)
			{
				y = points[i];

				chart1.Series[0].Points.Add(new DataPoint(x, y));

				x = x + 90;
				i++;
			}

>>>>>>> f527bc559252d57d26c36c518a3782445d098ea1
		}
	}
}
