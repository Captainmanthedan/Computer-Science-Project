﻿using System;
using System.Windows.Forms;

namespace sine_graph_1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//When the button is pressed it uses a sine equation to generate corrdinates for a sine graph
		private void button1_Click(object sender, EventArgs e)
		{
			//this set the starting x corrdinate to zero
			int x_corrdinate = 0;

			//this stores the y_corrdinate and is a double because when the y corrdinate is generated it could be a decimal point
			double y_corrdinate;

			//this stores the x corrdinate in radians and is a double because it needs to store a decimal number
			double x_rad;

			//this sets the text box to NULL so that I can add to it later
			textBox1.Text = "";

			//this while loop iterates through from x = 0 to x = 1440, adding 90 to x on each iteration
			while (0 <= x_corrdinate && x_corrdinate <= 1440)
			{
				//this connverts the x corrdinate from degrees to radians so that it can be used to calculate the y corrdinate
				x_rad = x_corrdinate * (Math.PI / 180);

				//this sine equation generates the y corrdinate by using sine on the current x corrdinate in radians
				y_corrdinate = Math.Sin(x_rad);

				//this rouns the y corrdinate to a whole number
				y_corrdinate = Math.Round(y_corrdinate);

				//this adds the next x corrdinate (in degrees) and y corrdinate to the text box
				textBox1.Text = textBox1.Text + "(" + x_corrdinate + ", " + y_corrdinate + ")";
				//this adds a new line to the text box
				textBox1.AppendText(Environment.NewLine);

				//this adds 90 degrees to the x corrdinate
				x_corrdinate = x_corrdinate + 90;
			}
		}
	}
}
