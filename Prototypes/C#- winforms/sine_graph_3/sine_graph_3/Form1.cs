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

namespace sine_graph_3
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			chart1.Series[0].IsVisibleInLegend = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int a = 1;
			int b = 0;
			int c = 1;
			int d = 0;

			int i = 0;

			int x_corrdinate = 0;
			double y_corrdinate;

			double x_rad;

			chart1.Series[0].ChartType = SeriesChartType.Spline;

			chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
			chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

			chart1.ChartAreas[0].AxisX.LineColor = chart1.BackColor;
			chart1.ChartAreas[0].AxisY.LineColor = chart1.BackColor;

			//removes number scale from the x and y axis of the graph
			chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
			chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

			chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
			chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;

			while (0 <= x_corrdinate && x_corrdinate <= 1440)
			{
				x_rad = x_corrdinate * (Math.PI / 180);

				y_corrdinate = a * (Math.Sin((c * x_rad) + d)) + b;

				chart1.Series[0].Points.Add(new DataPoint(x_corrdinate, y_corrdinate));

				x_corrdinate = x_corrdinate + 90;
				i++;
			}
		}
	}
}
