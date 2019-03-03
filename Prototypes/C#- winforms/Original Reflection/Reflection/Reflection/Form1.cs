using System;
using System.Drawing;
using System.Windows.Forms;

namespace Reflection
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			SetUp();
		}

		private void SetUp()
		{
			Input_angle.Minimum = 0;
			Input_angle.Maximum = 90;
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			//This sets the length of the line as an integer
			double length = 250;

			//Converts the value inputed in the NumericUpDown Input_angle to an integer
			int InputAngle = (int)Input_angle.Value;

			//The entered angle is subtracted from 270, so that the line is drawn from the correct postion
			int angle_degree = 270 - InputAngle;
			int angle_degree2 = 270 + InputAngle;

			//Converts the angle in degrees to radians
			double angle_rad = (Math.PI / 180.0) * angle_degree;
			double angle_rad2 = (Math.PI / 180.0) * angle_degree2;

			//Start corrodinate
			Point startPoint = Reflection_and_Normal_Line(e);

			int Start_X_Coordinate = startPoint.X;
			int Start_Y_Coordinate = startPoint.Y;

			//Calculates the start corrodinates for the incedent ray and converts them to an integer
			int End_X_Coordinate = Convert.ToInt32(Start_X_Coordinate + (Math.Cos(angle_rad) * length));
			int End_Y_Coordinate = Convert.ToInt32(Start_Y_Coordinate + (Math.Sin(angle_rad) * length));
			int x = Convert.ToInt32(Start_X_Coordinate + (Math.Cos(angle_rad2) * length));
			int y = Convert.ToInt32(Start_Y_Coordinate + (Math.Sin(angle_rad2) * length));

			Point endPoint = new Point(End_X_Coordinate, End_Y_Coordinate);
			Point endPoint2 = new Point(x, y);

			// Create sweep angle for the angle arc.
			int sweepAngle = (int)Input_angle.Value;

			// Create rectangle to bound ellipse.
			Rectangle rect1 = new Rectangle(Start_X_Coordinate - 50, Start_Y_Coordinate - 50, 100, 100);
			Rectangle rect2 = new Rectangle(Start_X_Coordinate - 50, Start_Y_Coordinate - 50, 100, 100);

			//Creates a pen that is red
			Pen redPen = new Pen(Color.Red, 5);
			//Creates a pen that is purple
			Pen purplePen = new Pen(Color.Purple, 5);
			//Creates a pen that is green
			Pen greenPen = new Pen(Color.Green, 3);
			//Creates a pen that is orange
			Pen orangePen = new Pen(Color.Orange, 3);

			//This creates a Graphic called ray using PaintEventArgs
			Graphics ray = e.Graphics;

			//This draws a red line a ste angle from the horizontal blue line
			ray.DrawLine(redPen, startPoint, endPoint);
			ray.DrawLine(purplePen, startPoint, endPoint2);

			//Dr
			e.Graphics.DrawArc(greenPen, rect1, angle_degree, sweepAngle);
			e.Graphics.DrawArc(orangePen, rect2, 270, sweepAngle);

			//This displays in the lable angle the angle in degrees
			angle.Text = InputAngle + "°";
		}

		Point Reflection_and_Normal_Line(PaintEventArgs e)
		{
			//These integers store different x and y coordinates
			int y_coordinate = 350;
			int y_LineTop = 10;
			int x_LineStart = 50;
			int x_LineEnd = 550;

			//This fins the length of the reflection line and sets it equal to the integer LineLngth
			int LineLength = x_LineEnd - x_LineStart;
			//this calculates the x coordinate
			int x_LineMiddle = x_LineStart + (LineLength / 2);

			//This creates a point that stores the start point for the bottom line
			Point LineStart = new Point(x_LineStart, y_coordinate);
			////This creates a point that stores the end point for the bottom line
			Point LineEnd = new Point(x_LineEnd, y_coordinate);

			//this stores the middle point of the line as a Point
			Point LineMiddle = new Point(x_LineMiddle, y_coordinate);

			//This creates a point that stores the start point for vertical line
			Point LineTop = new Point(x_LineMiddle, y_LineTop);

			//This creates a Graphic called diagram using PaintEventArgs
			Graphics diagram = e.Graphics;

			//Creates a pen that is black
			Pen blackPen = new Pen(Color.Black, 6);
			//Creates a pen that is blue
			Pen bluePen = new Pen(Color.Blue, 3);

			//Create a custom dash pattern.
			bluePen.DashPattern = new float[] {4, 2};

			//This draws the horizontal black reflection line at the bottom of the form
			diagram.DrawLine(blackPen, LineStart, LineEnd);

			//This draws the normal blue going upwards from the centre of the reflection line
			diagram.DrawLine(bluePen, LineTop, LineMiddle);

			//This returns the LineMidddle point to Form1_Paint
			return LineMiddle;
		}

		private void Input_angle_ValueChanged(object sender, EventArgs e)
		{
			//This clears the graphics so that the previous line does not stay along with the new line
			Invalidate();
		}
	}
}