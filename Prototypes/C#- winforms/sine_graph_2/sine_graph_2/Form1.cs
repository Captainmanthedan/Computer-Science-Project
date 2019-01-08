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

			double[] points = new double[17];

			chart1.Series[0].ChartType = SeriesChartType.Spline;
			chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
			chart1.Series[0].LegendText = "Sign Graph";
			//Tuple<int, int> t = Tuple.Create(0, 1);
			chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
			chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

			string s = "";

			while (0 <= x && x <= 1440)
			{
				y = a * (Math.Sin((c * x) + d)) + b;

				y = Math.Round(y);

				points[i] = y;

				s = s + i + "(" + x + ", " + y + ")";
				//chart1.Series[0].Points.Add(new DataPoint(x, y));

				x = x + 90;
				i++;
			}

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

		}
	}
}
