using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reflection
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			int y_Start = 10;
			int y_End = 320;
			int LineStart = 50;
			int LineEnd = 540;
			int LineLength = LineEnd - LineStart;
			int LineMiddle = LineStart + (LineLength / 2);

			Graphics draw = e.Graphics;
			Pen BlackPen = new Pen(Color.Black, 8);
			draw.DrawLine(BlackPen, LineStart, y_End, LineEnd, y_End);

			Pen BluePen = new Pen(Color.Blue, 8);
			/*draw.DrawLine(BluePen, LineStart, y_Start, LineMiddle, y_End);
			draw.DrawLine(BluePen, LineMiddle, y_End, LineEnd, y_Start);*/
			double angle = 90;
			double angle_rad = angle * (Math.PI / 180);

			int LengthX = LineMiddle - LineStart;
			int LengthY = y_End - y_Start;

			double RayLength = (LengthX^2) + (LengthY^2);

			//Point point = new Point(LineStart + Math.Cos(angle_rad) * RayLength, y_Start + Math.Sin(angle_rad) * RayLength);

			int x = Convert.ToInt32(LineStart + Math.Cos(angle_rad) * RayLength);
			int y = Convert.ToInt32(y_Start + Math.Cos(angle_rad) * RayLength);

			Point IncedentRayStartPoint = new Point(x, y);
			Point IncedentRayEndPoint = new Point(LineMiddle, y_End);

			//Point RefelectedRayStartPoint = new Point(LineMiddle, y_End);
			//Point ReflectedRayEndPoint = new Point(LineEnd, y);

			double result = (90 * (Math.PI / 180));
			MessageBox.Show(Convert.ToString(result));

			var endPoint = new Point();
			if (angle_rad <= 45)
			{
				endPoint.X = y_End;
				endPoint.Y = (int)(y_End - y_End * Math.Tan(angle_rad));
			}
			else
			{
				endPoint.Y = LineStart;
				endPoint.X = (int)(y_End * Math.Tan(result - angle_rad));
			}

			if (endPoint.Y > 461)
			{
				endPoint.Y = 461;
			}

			if (endPoint.X > 584)
			{
				endPoint.X = 584;
			}

			draw.DrawLine(BluePen, LineMiddle, y_End, endPoint.X, endPoint.Y);

		}
	}
}
