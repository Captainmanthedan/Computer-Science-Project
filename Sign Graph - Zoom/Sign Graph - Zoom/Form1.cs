using System;
using System.Windows.Forms;

//this allows me to plot a graph
using System.Windows.Forms.DataVisualization.Charting;

//
using System.Drawing;

namespace Sign_Graph___Zoom
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			//this hides the series lable when the program runs
			chart1.Series[0].IsVisibleInLegend = false;
		}

		//When the button is pressed it uses a sine equation to generate a sine graph without a grid
		private void button1_Click(object sender, EventArgs e)
		{
			//this clears the current data points so that if the user changes the graph it plots a new one
			chart1.Series[0].Points.Clear();

			//these store the values entered in the textboxes that enables the sine grapg to be manipulated

			//amplitude is double because it can either be a positve whole number greater than zero or
			//a decimal number greater than zero and less than 1
			double amplitude = Convert.ToDouble(BoxA.Value);
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
			/*
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
			*/
			//
			chart1.ChartAreas[0].AxisY.Maximum = 10;
			chart1.ChartAreas[0].AxisY.Minimum = -10;

			//
			chart1.ChartAreas[0].AxisX.Maximum = 1440;
			chart1.ChartAreas[0].AxisX.Minimum = 0;

			//
			chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
			chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

			chart1.MouseWheel += chart1_MouseWheel;

			//this while loop iterates through from x = 0 to x = 1440, adding 90 to x on each iteration
			while (0 <= x_corrdinate && x_corrdinate <= 1440)
			{
				//this connverts the x corrdinate from degrees to radians so that it can be used to calculate the y corrdinate
				x_rad = (x_corrdinate) * (Math.PI / 180);

				//this sine equation generates the y corrdinate by using sine on the current x corrdinate in radians
				y_corrdinate = amplitude * (Math.Sin((c * x_rad) + d)) + b;

				//this rouns the y corrdinate to a whole number
				//y_corrdinate = Math.Round(y_corrdinate);

				//this adds a data point on the graph at the x corrdinate (in degrees) and the y corrdinate
				chart1.Series[0].Points.Add(new DataPoint((x_corrdinate), y_corrdinate));

				//this adds 90 degrees to the x corrdinate
				x_corrdinate = x_corrdinate + 90;
			}
		}


		private void AmpDEC_CheckedChanged(object sender, EventArgs e)
		{
			if (AmpDEC.Checked == true)
			{
				BoxA.DecimalPlaces = 1;
				BoxA.Minimum = 0.1M;
				BoxA.Maximum = 0.9M;
				BoxA.Increment = 0.1M;
				BoxA.Value = 0.1M;
			}
			else
			{
				BoxA.DecimalPlaces = 0;
				BoxA.Minimum = 1;
				BoxA.Maximum = 10;
				BoxA.Increment = 1;
				BoxA.Value = 1;
			}
		}

		private void chart1_MouseWheel(object sender, MouseEventArgs e)
		{
			var chart = (Chart)sender;
			var xAxis = chart.ChartAreas[0].AxisX;
			var yAxis = chart.ChartAreas[0].AxisY;

			try
			{
				if (e.Delta < 0) // Scrolled down.
				{
					if (chart1.ChartAreas[0].AxisY.Maximum == 1)
					{
						//
						chart1.ChartAreas[0].AxisY.Maximum = 2;
						chart1.ChartAreas[0].AxisY.Minimum = -2;

						//
						Zoom_Plus.ForeColor = SystemColors.ControlText;

						//
						Zoom_Plus.Enabled = true;
					}
					else if (chart1.ChartAreas[0].AxisY.Maximum == 2)
					{
						//
						chart1.ChartAreas[0].AxisY.Maximum = 5;
						chart1.ChartAreas[0].AxisY.Minimum = -5;
					}
					else if (chart1.ChartAreas[0].AxisY.Maximum == 5)
					{
						//
						chart1.ChartAreas[0].AxisY.Maximum = 10;
						chart1.ChartAreas[0].AxisY.Minimum = -10;

						//
						Zoom_Minus.ForeColor = SystemColors.ControlDark;

						//
						Zoom_Minus.Enabled = false;
					}
				}
				else if (e.Delta > 0) // Scrolled up.
				{
					if (chart1.ChartAreas[0].AxisY.Maximum == 10)
					{
						//
						chart1.ChartAreas[0].AxisY.Maximum = 5;
						chart1.ChartAreas[0].AxisY.Minimum = -5;

						//
						Zoom_Minus.ForeColor = SystemColors.ControlText;

						//
						Zoom_Minus.Enabled = true;
					}
					else if (chart1.ChartAreas[0].AxisY.Maximum == 5)
					{
						//
						chart1.ChartAreas[0].AxisY.Maximum = 2;
						chart1.ChartAreas[0].AxisY.Minimum = -2;
					}
					else if (chart1.ChartAreas[0].AxisY.Maximum == 2)
					{
						//
						chart1.ChartAreas[0].AxisY.Maximum = 1;
						chart1.ChartAreas[0].AxisY.Minimum = -1;

						//
						Zoom_Plus.ForeColor = Color.Gray;

						//
						Zoom_Plus.Enabled = false;
					}
				}
			}
			catch { }
		}

		private void Zoom_Minus_Click(object sender, EventArgs e)
		{
			if (chart1.ChartAreas[0].AxisY.Maximum == 1)
			{
				//
				chart1.ChartAreas[0].AxisY.Maximum = 2;
				chart1.ChartAreas[0].AxisY.Minimum = -2;

				//
				Zoom_Plus.ForeColor = SystemColors.ControlText;

				//
				Zoom_Plus.Enabled = true;
			}
			else if (chart1.ChartAreas[0].AxisY.Maximum == 2)
			{
				//
				chart1.ChartAreas[0].AxisY.Maximum = 5;
				chart1.ChartAreas[0].AxisY.Minimum = -5;
			}
			else if (chart1.ChartAreas[0].AxisY.Maximum == 5)
			{
				//
				chart1.ChartAreas[0].AxisY.Maximum = 10;
				chart1.ChartAreas[0].AxisY.Minimum = -10;

				//
				Zoom_Minus.ForeColor = SystemColors.ControlDark;

				//
				Zoom_Minus.Enabled = false;
			}
		}

		private void Zoom_Plus_Click(object sender, EventArgs e)
		{
			if (chart1.ChartAreas[0].AxisY.Maximum == 10)
			{
				//
				chart1.ChartAreas[0].AxisY.Maximum = 5;
				chart1.ChartAreas[0].AxisY.Minimum = -5;

				//
				Zoom_Minus.ForeColor = SystemColors.ControlText;

				//
				Zoom_Minus.Enabled = true;
			}
			else if (chart1.ChartAreas[0].AxisY.Maximum == 5)
			{
				//
				chart1.ChartAreas[0].AxisY.Maximum = 2;
				chart1.ChartAreas[0].AxisY.Minimum = -2;
			}
			else if (chart1.ChartAreas[0].AxisY.Maximum == 2)
			{
				//
				chart1.ChartAreas[0].AxisY.Maximum = 1;
				chart1.ChartAreas[0].AxisY.Minimum = -1;

				//
				Zoom_Plus.ForeColor = Color.Gray;

				//
				Zoom_Plus.Enabled = false;
			}
		}
	}
}