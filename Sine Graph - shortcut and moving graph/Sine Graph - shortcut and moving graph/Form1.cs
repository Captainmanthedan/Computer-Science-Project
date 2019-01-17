using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace Sine_Graph___shortcut_and_moving_graph
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			chart1.Series[0].IsVisibleInLegend = false;

			KeyPreview = true;
			KeyUp += new System.Windows.Forms.KeyEventHandler(KeyEvent);
		}

		//When the button is pressed it uses a sine equation to generate a sine graph without a grid
		private void SineGraph()
		{
			//this clears the current data points so that if the user changes the graph it plots a new one
			chart1.Series[0].Points.Clear();

			int a = Convert.ToInt32(BoxA.Value);
			int b = Convert.ToInt32(BoxB.Value);
			int c = Convert.ToInt32(BoxC.Value);
			int d = Convert.ToInt32(BoxD.Value);

			//this set the starting x corrdinate to zero
			int x_corrdinate = 0;

			//this stores the y_corrdinate and is a double because when the y corrdinate is generated it could be a decimal point
			double y_corrdinate;

			//this stores the x corrdinate in radians and is a double because it needs to store a decimal number
			double x_rad;

			//this makes the chart be a Spline which is a line graph but each line is curved not straight.
			chart1.Series[0].ChartType = SeriesChartType.Spline;

			//this hides the grid lines from the graph
			chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
			chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

			//this hides the x and y axis lines
			chart1.ChartAreas[0].AxisX.LineColor = chart1.BackColor;
			chart1.ChartAreas[0].AxisY.LineColor = chart1.BackColor;

			//removes number scale from the x and y axis of the graph
			chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
			chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

			//this removes the x and y axis scale lines
			chart1.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
			chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;

			//this while loop iterates through from x = 0 to x = 1440, adding 90 to x on each iteration
			while (0 <= x_corrdinate && x_corrdinate <= 1440)
			{
				//this connverts the x corrdinate from degrees to radians so that it can be used to calculate the y corrdinate
				x_rad = (x_corrdinate) * (Math.PI / 180);

				//this sine equation generates the y corrdinate by using sine on the current x corrdinate in radians
				y_corrdinate = a * (Math.Sin((c * x_rad) + d)) + b;

				//this rouns the y corrdinate to a whole number
				y_corrdinate = Math.Round(y_corrdinate);

				//this adds a data point on the graph at the x corrdinate (in degrees) and the y corrdinate
				chart1.Series[0].Points.Add(new DataPoint((x_corrdinate), y_corrdinate));

				//this adds 90 degrees to the x corrdinate
				x_corrdinate = x_corrdinate + 90;
			}

			d = 0;

			update(d);

			int Period = 500;

			while (Esc != true)
			{
				chart1.Update();

				Application.DoEvents();

				Thread.Sleep(Period);

				d += 90;
				/*
				if (d > 360)
				{
					d = 0;
				}
				*/
				update(d);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Esc = false;
			SineGraph();
		}

		private void KeyEvent(object sender, KeyEventArgs e) //Keyup Event 
		{
			if (e.KeyCode == Keys.F5)
			{
				Esc = false;
				SineGraph();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				Esc = true;
			}
			else if (e.KeyCode == Keys.Control && e.KeyCode == Keys.X)
			{
				Esc = false;

				this.Close();
			}
		}

		volatile bool Esc = false;

		private void update(int d)
		{
			//this clears the current data points so that if the user changes the graph it plots a new one
			chart1.Series[0].Points.Clear();

			int a = Convert.ToInt32(BoxA.Value);
			int b = Convert.ToInt32(BoxB.Value);
			int c = Convert.ToInt32(BoxC.Value);

			//this set the starting x corrdinate to zero
			int x_corrdinate = 0;

			//this stores the y_corrdinate and is a double because when the y corrdinate is generated it could be a decimal point
			double y_corrdinate;

			//this stores the x corrdinate in radians and is a double because it needs to store a decimal number
			double x_rad;

			double d_rad;

			//this while loop iterates through from x = 0 to x = 1440, adding 90 to x on each iteration
			while (0 <= x_corrdinate && x_corrdinate <= 1440)
			{
				//this connverts the x corrdinate from degrees to radians so that it can be used to calculate the y corrdinate
				x_rad = (x_corrdinate) * (Math.PI / 180);

				//
				d_rad = d * (Math.PI / 180);

				//this sine equation generates the y corrdinate by using sine on the current x corrdinate in radians
				y_corrdinate = a * (Math.Sin((c * x_rad) + d_rad)) + b;

				//this rouns the y corrdinate to a whole number
				y_corrdinate = Math.Round(y_corrdinate);

				//this adds a data point on the graph at the x corrdinate (in degrees) and the y corrdinate
				chart1.Series[0].Points.Add(new DataPoint((x_corrdinate + b), y_corrdinate));

				//this adds 90 degrees to the x corrdinate
				x_corrdinate = x_corrdinate + 90;
			}
		}
	}
}