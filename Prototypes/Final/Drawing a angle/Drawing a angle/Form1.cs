using System;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_a_angle
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			//These integers store different x and y coordinates
			int y_corrdinate = 280;
			int y_LineTop = 50;
			int x_LineStart = 100;
			int x_LineEnd = 350;

			//This sets the length of the line as an integer
			int length = 200;

			//Converts the value inputed in the NumericUpDown Input_angle to an integer
			int InputAngle = (int)Input_angle.Value;

			//The entered angle is subtracted from 270, so that the line is drawn from the correct postion
			int angle_degree = /*270*/ 90 - InputAngle;

			//Converts the angle in degrees to radians
			double angle_rad = (Math.PI / 180.0) * angle_degree;

			//Calculates the start corrodinates for the incedent ray and converts them to an integer
			int x = Convert.ToInt32(x_LineEnd + (Math.Cos(angle_rad) * length));
			int y = Convert.ToInt32(y_corrdinate + (Math.Sin(angle_rad) * length));

			Point StartPoint = new Point(x, y);

			//This creates a point that stores the start point for the bottom line
			Point LineStart = new Point(x_LineStart, y_corrdinate);
			////This creates a point that stores the end point for the bottom line
			Point LineEnd = new Point(x_LineEnd, y_corrdinate);

			//This creates a point that stores the start point for vertical  line
			Point LineTop = new Point(x_LineEnd, y_LineTop);

			//Creates a pen that is red
			Pen redPen = new Pen(Color.Red, 5);
			//Creates a pen that is black
			Pen blackPen = new Pen(Color.Black, 6);

			//This creates a Graphic called diagram using PaintEventArgs
			Graphics diagram = e.Graphics;

			//This draws a horizontal black line at the bottom of the form
			diagram.DrawLine(blackPen, LineStart, LineEnd);

			//This draws a vertical  black line on the right of the form
			diagram.DrawLine(blackPen, LineTop, LineEnd);

			//This draws a red line a set angle from the vertical  blue line
			diagram.DrawLine(redPen, StartPoint, LineEnd);
		}

		private void Input_angle_ValueChanged(object sender, EventArgs e)
		{
			//This clears the graphics so that the previous line does not stay along with the new line
			Invalidate();
		}
	}
}
