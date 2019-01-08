using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

			double[] points = new double[25];

			Tuple<int, int> t = Tuple.Create(0, 1);

			while (0 <= x && x <= 360)
			{
				y = a * (Math.Sin((c * x) + d)) + b;

				points[i] = y;

				chart1.Series[0].Points.Add(new DataPoint(i, t.Item1));
				t = Tuple.Create(t.Item2, t.Item1 + t.Item2);

				x = x + 15;
				i++;
			}

			i = 0;
			x = 0;

			while (0 <= x && x <= 360)
			{
				y = points[i];

				x = x + 15;
				i++;
			}

		}
	}
}
