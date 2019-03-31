using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace Physics_Simulator
{
	//This creates an abstract class called Simulation (abstract means it cannot be instantiated)
	public abstract class Simulation
	{
		//The following function runs when an instance of a subclass, inherited the class Simualtion, is created
		public Simulation(string name)
		{
			//This sets the variable name passed when the form is created equal to the Simulation.Name property
			Name = name;
		}

		//This stores the Name as a public variable so it can be accessed and changed in the form
		public string Name;

		//This creates a public GroupBox called GroupBox
		public GroupBox GroupBox;

		//This sets the properties for GroupBox
		public virtual GroupBox SetUp_GroupBox()
		{
			//This creates a new GroupBox called GroupBox
			GroupBox GroupBox = new GroupBox();

			//This sets the text for the groupbox
			GroupBox.Text = Name;

			//This sets the location for GroupBox equal to the point Location
			GroupBox.Location = new Point(12, 27);

			//This returns GroupBox
			return GroupBox;
		}
	}

	//Derived sub class from Simulation class
	public class Wave : Simulation
	{
		//The following function runs when an instance of the class wave is created
		public Wave(string name) : base(name)
		{
			//These call each call a function that sets their properties
			GroupBox = SetUp_GroupBox();
			AmplitudeLabel = SetUp_AmplitudeLabel();
			WavelengthLabel = SetUp_WavelengthLabel();
			WaveSpeedLabel = SetUp_WaveSpeedLabel();
			FrequencyLabel = SetUp_FrequencyLabel();
			PeriodLabel = SetUp_PeriodLabel();
			AmplitudeBox = SetUp_AmplitudeBox();
			WavelengthBox = SetUp_WavelengthBox();
			WaveSpeedBox = SetUp_WaveSpeedBox();
			FrequencyBox = SetUp_FrequencyBox();
			PeriodBox = SetUp_PeriodBox();
			Zoom_Plus = SetUp_Zoom_Plus();
			Zoom_Minus = SetUp_Zoom_Minus();
			Amplitude_Decimal_RadioButton = SetUp_Amplitude_Decimal_RadioButton();
			Amplitude_Integer_RadioButton = SetUp_Amplitude_Integer_RadioButton();
			Movement_checkBox = SetUp_Movement_checkBox();
			ChartGrid_checkBox = SetUp_ChartGrid_checkBox();
			WaveChart = SetUp_WaveChart();
			MovementGroupBox = SetUp_MovementGroupBox();

			//These add the controls for WaveSpeedLabel, FrequencyLabel, PeriodLabel, WaveSpeedBox, FrequencyBox and PeriodBox to MovementGroupBox
			MovementGroupBox.Controls.Add(WaveSpeedLabel);
			MovementGroupBox.Controls.Add(FrequencyLabel);
			MovementGroupBox.Controls.Add(PeriodLabel);
			MovementGroupBox.Controls.Add(WaveSpeedBox);
			MovementGroupBox.Controls.Add(FrequencyBox);
			MovementGroupBox.Controls.Add(PeriodBox);

			/*These add the controls for AmplitudeLabel, WavelengthLabel, AmplitudeBox, WavelengthBox, Zoom_Plus, Zoom_Minus, Amplitude_Decimal_RadioButton,
			Amplitude_Integer_RadioButton, Movement_checkBox, ChartGrid_checkBox, WaveChart and MovementGroupBox to GroupBox*/
			GroupBox.Controls.Add(AmplitudeLabel);
			GroupBox.Controls.Add(WavelengthLabel);
			GroupBox.Controls.Add(AmplitudeBox);
			GroupBox.Controls.Add(WavelengthBox);
			GroupBox.Controls.Add(Zoom_Plus);
			GroupBox.Controls.Add(Zoom_Minus);
			GroupBox.Controls.Add(Amplitude_Decimal_RadioButton);
			GroupBox.Controls.Add(Amplitude_Integer_RadioButton);
			GroupBox.Controls.Add(Movement_checkBox);
			GroupBox.Controls.Add(ChartGrid_checkBox);
			GroupBox.Controls.Add(WaveChart);
			GroupBox.Controls.Add(MovementGroupBox);
		}

		//This public variables store values for the wave used in the mathimatical equations, and are public so their values can be uploaded to the database when the wave is saved
		public double Amplitude;
		public int Wavelength;
		public double WaveSpeed;
		public double Frequency;
		public double Period;

		//These create private labels called AmplitudeLabel, WavelengthLabel, WaveSpeedLabel, FrequencyLabel and PeriodLabel
		private Label AmplitudeLabel;
		private Label WavelengthLabel;
		private Label WaveSpeedLabel;
		private Label FrequencyLabel;
		private Label PeriodLabel;


		//These create public NumericUpDowns called AmplitudeBox, WavelengthBox, WaveSpeedBox, FrequencyBox and PeriodBox
		public NumericUpDown AmplitudeBox;
		public NumericUpDown WavelengthBox;
		public NumericUpDown WaveSpeedBox;
		public NumericUpDown FrequencyBox;
		public NumericUpDown PeriodBox;

		//These create private buttons called Zoom_Plus and Zoom_Minus
		private Button Zoom_Plus;
		private Button Zoom_Minus;

		//These create private radio buttons called Amplitude_Decimal_RadioButton and Amplitude_Integer_RadioButton
		private RadioButton Amplitude_Decimal_RadioButton;
		private RadioButton Amplitude_Integer_RadioButton;

		//These create private checkboxs called Movement_checkBox and ChartGrid_checkBox
		private CheckBox Movement_checkBox;
		private CheckBox ChartGrid_checkBox;

		//This creates a private Chart called WaveChart
		private Chart WaveChart;

		//This creates a public GroupBox called MovementGroupBox
		public GroupBox MovementGroupBox;

		//This sets the properties for AmplitudeLabel
		private Label SetUp_AmplitudeLabel()
		{
			//This creates a new label called AmplitudeLabel
			Label AmplitudeLabel = new Label();

			//This sets the location for AmplitudeLabel
			AmplitudeLabel.Location = new Point(871, 189);

			//This automaticly sets the size of the lable AmplitudeLabel to fit the text inside it
			AmplitudeLabel.AutoSize = true;

			//This sets the text displayed by AmplitudeLabel
			AmplitudeLabel.Text = "Amplitude";

			//This returns AmplitudeLabel
			return AmplitudeLabel;
		}

		//This sets the properties for WavelengthLabel
		private Label SetUp_WavelengthLabel()
		{
			//This creates a new label called WavelengthLabel
			Label WavelengthLabel = new Label();

			//This sets the location for WavelengthLabel
			WavelengthLabel.Location = new Point(871, 215);

			//This automaticly sets the size of the lable WavelengthLabel to fit the text inside it
			WavelengthLabel.AutoSize = true;

			//This sets the text displayed by WavelengthLabel
			WavelengthLabel.Text = "Wavelength";

			//This returns WavelengthLabel
			return WavelengthLabel;
		}

		//This sets the properties for WaveSpeedLabel
		private Label SetUp_WaveSpeedLabel()
		{
			//This creates a new label called WaveSpeedLabel
			Label WaveSpeedLabel = new Label();

			//This sets the location for WaveSpeedLabel
			WaveSpeedLabel.Location = new Point(6, 73);

			//This automaticly sets the size of the lable WaveSpeedLabel to fit the text inside it
			WaveSpeedLabel.AutoSize = true;

			//This sets the text displayed by WaveSpeedLabel
			WaveSpeedLabel.Text = "WaveSpeed";

			//This returns WaveSpeedLabel
			return WaveSpeedLabel;
		}

		//This sets the properties for FrequencyLabel
		private Label SetUp_FrequencyLabel()
		{
			//This creates a new label called FrequencyLabel
			Label FrequencyLabel = new Label();

			//This sets the location for FrequencyLabel
			FrequencyLabel.Location = new Point(19, 21);

			//This automaticly sets the size of the lable FrequencyLabel to fit the text inside it
			FrequencyLabel.AutoSize = true;

			//This sets the text displayed by FrequencyLabel
			FrequencyLabel.Text = "Frequency";

			//This returns FrequencyLabel
			return FrequencyLabel;
		}

		//This sets the properties for PeriodLabel
		private Label SetUp_PeriodLabel()
		{
			//This creates a new label called PeriodLabel
			Label PeriodLabel = new Label();

			//This sets the location for PeriodLabel
			PeriodLabel.Location = new Point(39, 47);

			//This automaticly sets the size of the lable PeriodLabel to fit the text inside it
			PeriodLabel.AutoSize = true;

			//This sets the text displayed by PeriodLabel
			PeriodLabel.Text = "Period";

			//This returns PeriodLabel
			return PeriodLabel;
		}

		//This sets the properties for AmplitudeBox
		private NumericUpDown SetUp_AmplitudeBox()
		{
			//This creates a new NumericUpDown called AmplitudeBox
			NumericUpDown AmplitudeBox = new NumericUpDown();

			//This sets the location for AmplitudeBox
			AmplitudeBox.Location = new Point(940, 187);

			//This sets the size of AmplitudeBox
			AmplitudeBox.Size = new Size(61, 20);

			//These set the maximum and minimum values for AmplitudeBox
			AmplitudeBox.Minimum = 1;
			AmplitudeBox.Maximum = 10;

			//This returns AmplitudeBox
			return AmplitudeBox;
		}

		//This sets the properties for WavelengthBox
		private NumericUpDown SetUp_WavelengthBox()
		{
			//This creates a new NumericUpDown called WavelengthBox
			NumericUpDown WavelengthBox = new NumericUpDown();

			//This sets the location for WavelengthBox
			WavelengthBox.Location = new Point(940, 213);

			//This sets the size of WavelengthBox
			WavelengthBox.Size = new Size(61, 20);

			//These set the maximum and minimum values for WavelengthBox
			WavelengthBox.Minimum = 30;
			WavelengthBox.Maximum = 1440;

			//This sets the increment value for WavelengthBox
			WavelengthBox.Increment = 30;

			//This returns WavelengthBox
			return WavelengthBox;
		}

		//This sets the properties for WaveSpeedBox
		private NumericUpDown SetUp_WaveSpeedBox()
		{
			//This creates a new NumericUpDown called WaveSpeedBox
			NumericUpDown WaveSpeedBox = new NumericUpDown();

			//This sets the location for WaveSpeedBox
			WaveSpeedBox.Location = new Point(82, 71);

			//This sets the size of WaveSpeedBox
			WaveSpeedBox.Size = new Size(61, 20);

			//These set the maximum and minimum values for WaveSpeedBox
			WaveSpeedBox.Minimum = 0.3m;
			WaveSpeedBox.Maximum = 144000;

			//This sets WaveSpeedBox to increase by an increment of 0.1
			WaveSpeedBox.Increment = 0.1m;

			//This sets the starting value for WaveSpeedBox
			WaveSpeedBox.Value = 30;

			//This sets the number of decimal places for WaveSpeedBox
			WaveSpeedBox.DecimalPlaces = 1;

			//This returns WaveSpeedBox
			return WaveSpeedBox;
		}

		//This sets the properties for FrequencyBox
		private NumericUpDown SetUp_FrequencyBox()
		{
			//This creates a new NumericUpDown called FrequencyBox
			NumericUpDown FrequencyBox = new NumericUpDown();

			//This sets the location for FrequencyBox
			FrequencyBox.Location = new Point(82, 19);

			//This sets the size of FrequencyBox
			FrequencyBox.Size = new Size(61, 20);

			//These set the maximum and minimum values for FrequencyBox
			FrequencyBox.Minimum = 0.01m;
			FrequencyBox.Maximum = 100;

			//This sets FrequencyBox to increase by an increment of 0.1
			FrequencyBox.Increment = 0.01m;

			//This sets the starting value for FrequencyBox
			FrequencyBox.Value = 1;

			//This sets the number of decimal places for FrequencyBox
			FrequencyBox.DecimalPlaces = 2;

			//This returns FrequencyBox
			return FrequencyBox;
		}

		//This sets the properties for PeriodBox
		private NumericUpDown SetUp_PeriodBox()
		{
			//This creates a new NumericUpDown called PeriodBox
			NumericUpDown PeriodBox = new NumericUpDown();

			//This sets the location for PeriodBox
			PeriodBox.Location = new Point(82, 45);

			//This sets the size of PeriodBox
			PeriodBox.Size = new Size(61, 20);

			//These set the maximum and minimum values for PeriodBox
			PeriodBox.Minimum = 0.01m;
			PeriodBox.Maximum = 100;

			//This sets PeriodBox to increase by an increment of 0.1
			PeriodBox.Increment = 0.01m;

			//This sets the starting value for PeriodBox
			PeriodBox.Value = 1;

			//This sets the number of decimal places for PeriodBox
			PeriodBox.DecimalPlaces = 2;

			//This returns PeriodBox
			return PeriodBox;
		}

		//This sets the properties for Zoom_Plus
		private Button SetUp_Zoom_Plus()
		{
			//This creates a new Button called Zoom_Plus
			Button Zoom_Plus = new Button();

			//This sets the location for Zoom_Plus
			Zoom_Plus.Location = new Point(71, 548);

			//This sets the size of Zoom_Plus
			Zoom_Plus.Size = new Size(35, 35);

			//This sets Zoom_Plus display the a plus symbol
			Zoom_Plus.Text = "+";

			//This returns Zoom_Plus
			return Zoom_Plus;
		}

		//This sets the properties for Zoom_Minus
		private Button SetUp_Zoom_Minus()
		{
			//This creates a new Button called Zoom_Minus
			Button Zoom_Minus = new Button();

			//This sets the location for Zoom_Minus
			Zoom_Minus.Location = new Point(29, 548);

			//This sets the size of Zoom_Minus
			Zoom_Minus.Size = new Size(35, 35);

			//This sets Zoom_Minus display the a minus symbol
			Zoom_Minus.Text = "-";

			//This sets the button Zoom_Minus to gray
			Zoom_Minus.ForeColor = Color.Gray;

			//This disallows (stops) the user to press the button Zoom_Minus
			Zoom_Minus.Enabled = false;

			//This returns Zoom_Minus
			return Zoom_Minus;
		}

		//This sets the properties for Amplitude_Decimal_RadioButton
		private RadioButton SetUp_Amplitude_Decimal_RadioButton()
		{
			//This creates a new RadioButton called Amplitude_Decimal_RadioButton
			RadioButton Amplitude_Decimal_RadioButton = new RadioButton();

			//This sets the location for Amplitude_Decimal_RadioButton
			Amplitude_Decimal_RadioButton.Location = new Point(897, 255);

			//This sets the size of Amplitude_Decimal_RadioButton
			Amplitude_Decimal_RadioButton.Size = new Size(107, 17);

			//This sets the text displayed by Amplitude_Decimal_RadioButton
			Amplitude_Decimal_RadioButton.Text = "0 < Amplitude < 1";

			//This returns Amplitude_Decimal_RadioButton
			return Amplitude_Decimal_RadioButton;
		}

		//This sets the properties for Amplitude_Integer_RadioButton
		private RadioButton SetUp_Amplitude_Integer_RadioButton()
		{
			//This creates a new RadioButton called Amplitude_Integer_RadioButton
			RadioButton Amplitude_Integer_RadioButton = new RadioButton();

			//This sets the location for Amplitude_Integer_RadioButton
			Amplitude_Integer_RadioButton.Location = new Point(897, 277);

			//This sets the size of Amplitude_Integer_RadioButton
			Amplitude_Integer_RadioButton.Size = new Size(89, 17);

			//This sets the text displayed by Amplitude_Integer_RadioButton
			Amplitude_Integer_RadioButton.Text = "Amplitude > 1";

			//This sets sets the radiobutton Amplitude_Integer_RadioButton checked
			Amplitude_Integer_RadioButton.Checked = true;

			//This returns Amplitude_Integer_RadioButton
			return Amplitude_Integer_RadioButton;
		}

		//This sets the properties for Movement_checkBox
		private CheckBox SetUp_Movement_checkBox()
		{
			//This creates a new CheckBox called Movement_checkBox
			CheckBox Movement_checkBox = new CheckBox();

			//This sets the location for Movement_checkBox
			Movement_checkBox.Location = new Point(928, 335);

			//This sets the size of Movement_checkBox
			Movement_checkBox.Size = new Size(76, 17);

			//This sets the text displayed by Movement_checkBox
			Movement_checkBox.Text = "Movement";

			//This returns Movement_checkBox
			return Movement_checkBox;
		}

		//This sets the properties for ChartGrid_checkBox
		private CheckBox SetUp_ChartGrid_checkBox()
		{
			//This creates a new CheckBox called ChartGrid_checkBox
			CheckBox ChartGrid_checkBox = new CheckBox();

			//This sets the location for ChartGrid_checkBox
			ChartGrid_checkBox.Location = new Point(928, 312);

			//This sets the size of ChartGrid_checkBox
			ChartGrid_checkBox.Size = new Size(45, 17);

			//This sets the text displayed by ChartGrid_checkBox
			ChartGrid_checkBox.Text = "Grid";

			//This sets the checkbox to display a cross
			ChartGrid_checkBox.Checked = true;

			//This returns ChartGrid_checkBox
			return ChartGrid_checkBox;
		}

		//This sets the properties for WaveChart
		private Chart SetUp_WaveChart()
		{
			//This creates a new Chart called WaveChart
			Chart WaveChart = new Chart();

			//This sets the location for WaveChart
			WaveChart.Location = new Point(30, 30);

			//This sets the size of WaveChart
			WaveChart.Size = new Size(800, 500);

			//This creates a ChartArea called WaveChartArea
			ChartArea WaveChartArea = new ChartArea();

			//This adds the ChartArea WaveChartArea to WaveChart
			WaveChart.ChartAreas.Add(WaveChartArea);

			//This creates a series called WaveSeries
			Series WaveSeries = new Series();

			//This makes the series WaveSeries be a Spline graph which is a line chart but each line between points is curved not straight
			WaveSeries.ChartType = SeriesChartType.Spline;

			//This adds the series WaveSeries to WaveChart
			WaveChart.Series.Add(WaveSeries);

			//This returns ChartGrid_checkBox
			return WaveChart;
		}

		//This sets the properties for MovementGroupBox
		private GroupBox SetUp_MovementGroupBox()
		{
			//This creates a new GroupBox called MovementGroupBox
			GroupBox MovementGroupBox = new GroupBox();

			//This sets the text for the MovementGroupBox
			MovementGroupBox.Text = Name;

			//This sets the location for MovementGroupBox
			MovementGroupBox.Location = new Point(865, 370);

			//This sets the size for MovementGroupBox
			MovementGroupBox.Size = new Size(160, 100);

			//This disallows (stops) the user from being able to interact with the groupbox
			MovementGroupBox.Enabled = false;

			//This returns MovementGroupBox
			return MovementGroupBox;
		}

		//This displays a wave to the user
		public void Display()
		{
			//This sets the size of GroupBox
			GroupBox.Size = new Size(1048, 608);


			ChartSize = 4;

			Change_Chart_Axis_Size();

			//This allows scrolling to be detected
			WaveChart.MouseWheel += WaveChart_MouseWheel;

			AmplitudeBox.ValueChanged += new EventHandler(AmplitudeBox_ValueChanged);
			WavelengthBox.ValueChanged += new EventHandler(WavelengthBox_ValueChanged);
			WaveSpeedBox.ValueChanged += new EventHandler(WaveSpeedBox_ValueChanged);
			FrequencyBox.ValueChanged += new EventHandler(FrequencyBox_ValueChanged);
			PeriodBox.ValueChanged += new EventHandler(PeriodBox_ValueChanged);

			Zoom_Plus.Click += new EventHandler(Zoom_Plus_Click);
			Zoom_Minus.Click += new EventHandler(Zoom_Minus_Click);

			Amplitude_Decimal_RadioButton.CheckedChanged += new EventHandler(Amplitude_Decimal_RadioButton_CheckedChanged);

			Movement_checkBox.CheckedChanged += new EventHandler(Movement_checkBox_CheckedChanged);
			ChartGrid_checkBox.CheckedChanged += new EventHandler(ChartGrid_checkBox_CheckedChanged);

			int c = 0;

			SineWave(c);
		}

		//When this function is called it uses a sine equation to generate a sine wave in the chart
		private void SineWave(int c)
		{
			try     //This only runs only when their is an instance of WaveChart
			{

				//this clears the current data points so that if the user changes the chart it plots a new one
				WaveChart.Series[0].Points.Clear();

				//these store the values entered in the textboxes that enables the sine chart to be manipulated
				//A stores the amplitude and is a double because it can either be a positve whole number greater than zero or
				//a decimal number greater than zero and less than 1

				Amplitude = Convert.ToDouble(AmplitudeBox.Value);
				Period = Convert.ToDouble(PeriodBox.Value);
				Frequency = Convert.ToDouble(FrequencyBox.Value);
				WaveSpeed = Convert.ToDouble(WaveSpeedBox.Value);

				Wavelength = Convert.ToInt32(WavelengthBox.Value);

				//This stores the Wavelength of the wave in radians
				double λ = Wavelength * (Math.PI / 180);

				//This stores the y_corrdinate and is a double because when the y corrdinate is generated it could be a decimal point
				double y_corrdinate = 0;

				//This stores the x corrdinate in radians and is a double because it needs to store a decimal number
				double x_corrdinate_rad;

				double c_rad;

				//
				c_rad = c * (Math.PI / 180);

				double Period_rad = Period * (Math.PI / 180);

				//This for loop iterates through from the starting integer x_corrdinate_degree (of 0) to 1440, adding 1 degree to the x corrdinate on each iteration
				for (int x_corrdinate_degree = 0; 0 <= x_corrdinate_degree && x_corrdinate_degree <= 1440; x_corrdinate_degree++)
				{
					//This connverts the x corrdinate from degrees to radians so that it can be used to calculate the y corrdinate
					x_corrdinate_rad = x_corrdinate_degree * (Math.PI / 180);

					//This sine equation generates the y corrdinate by using sine on the current x corrdinate in radians
					y_corrdinate = ((Amplitude * (Math.Sin((((2 * Math.PI) / λ) * x_corrdinate_rad - c) - (((2 * Math.PI) / Period_rad) * c_rad)))));

					//This adds a data point on the chart at the x corrdinate (in degrees) and the y corrdinate
					WaveChart.Series[0].Points.Add(new DataPoint(x_corrdinate_degree, y_corrdinate));
				}
			}
			catch (Exception)   //This runs when the program tries to exit to stop the Application.DoEvents
			{
				Movement_checkBox.Checked = false;
			}
		}

		//When the folowing NumericUpDown values are changed thay calls the function to generate the wave
		private void AmplitudeBox_ValueChanged(object sender, EventArgs e)
		{

			int c = 0;

			//This calls the function SineWave
			SineWave(c);
		}

		private void WavelengthBox_ValueChanged(object sender, EventArgs e)
		{

			if (Movement_checkBox.Checked == true)
			{
				WaveSpeed = Frequency * Wavelength;

				WaveSpeed = Math.Round(WaveSpeed, 1);

				WaveSpeedBox.Value = Convert.ToDecimal(WaveSpeed);
			}

			int c = 0;

			//This calls the function SineWave
			SineWave(c);
		}

		private void FrequencyBox_ValueChanged(object sender, EventArgs e)
		{
			if (Form.ActiveForm.ActiveControl == FrequencyBox)
			{
				Frequency = Convert.ToDouble(FrequencyBox.Value);

				WaveSpeed = Frequency * Wavelength;

				Period = 1 / Frequency;

				WaveSpeed = Math.Round(WaveSpeed, 1);
				Period = Math.Round(Period, 2);

				WaveSpeedBox.Value = Convert.ToDecimal(WaveSpeed);

				PeriodBox.Value = Convert.ToDecimal(Period);


				int c = 0;

				SineWave(c);
			}
		}

		private void PeriodBox_ValueChanged(object sender, EventArgs e)
		{
			if (Form.ActiveForm.ActiveControl == PeriodBox)
			{
				Period = Convert.ToDouble(PeriodBox.Value);

				Frequency = 1 / Period;

				WaveSpeed = Frequency * Wavelength;

				Frequency = Math.Round(Frequency, 2);
				WaveSpeed = Math.Round(WaveSpeed, 1);

				FrequencyBox.Value = Convert.ToDecimal(Frequency);

				WaveSpeedBox.Value = Convert.ToDecimal(WaveSpeed);

				int c = 0;

				SineWave(c);
			}
		}

		private void WaveSpeedBox_ValueChanged(object sender, EventArgs e)
		{
			if (Form.ActiveForm.ActiveControl == WaveSpeedBox)
			{
				WaveSpeed = Convert.ToDouble(WaveSpeedBox.Value);

				Frequency = WaveSpeed / Wavelength;

				Period = 1 / Frequency;

				Frequency = Math.Round(Frequency, 2);
				Period = Math.Round(Period, 2);

				FrequencyBox.Value = Convert.ToDecimal(Frequency);

				PeriodBox.Value = Convert.ToDecimal(Period);

				int c = 0;

				SineWave(c);
			}
		}

		//This sets the chart axis numbering
		#region Chart Grid Axis

		public int ChartSize;

		//This checks if the scrol wheel was scrolled up or down over the chart. If it was scrolled down it calls the Zoom_out function and if up the Zoom_in function.
		private void WaveChart_MouseWheel(object sender, MouseEventArgs e)
		{
			//This checks if the mouse wheel was scrolled up or down
			if (e.Delta < 0)    //This runs if the mouse wheel was scrolled down
			{
				//When the mouse is scrolled down clicked this calls a function that zooms the chart out
				Zoom_out();
			}
			else if (e.Delta > 0)   //This runs if the mouse wheel was scrolled up
			{
				//When the mouse is scrolled up clicked this calls a function that zooms the chart in
				Zoom_in();
			}
		}

		//When the zoom plus button is clicked this calls a function that zooms the chart in
		private void Zoom_Plus_Click(object sender, EventArgs e)
		{
			Zoom_in();
		}

		//When the zoom minus button is clicked this calls a function that zooms the chart out
		private void Zoom_Minus_Click(object sender, EventArgs e)
		{
			Zoom_out();
		}

		//Zooms the chart in
		private void Zoom_in()
		{
			ChartSize -= 1;
			Change_Chart_Axis_Size();
		}

		//Zooms the chart out
		private void Zoom_out()
		{
			ChartSize += 1;
			Change_Chart_Axis_Size();
		}

		private void Change_Chart_Axis_Size()
		{
			if (ChartSize == 1)
			{
				//sets the max and min x and y axis grid lines
				WaveChart.ChartAreas[0].AxisY.Maximum = 1;
				WaveChart.ChartAreas[0].AxisY.Minimum = -1;
				WaveChart.ChartAreas[0].AxisX.Maximum = 360;
				WaveChart.ChartAreas[0].AxisX.Minimum = 0;

				//This sets the line intervals for the x-axis and y-axis
				WaveChart.ChartAreas[0].AxisX.Interval = 30;
				WaveChart.ChartAreas[0].AxisY.Interval = 0.2;

				//This sets the button Zoom_Plus to gray
				Zoom_Plus.ForeColor = Color.Gray;

				//This disallows (stops) the user to press the button Zoom_Plus
				Zoom_Plus.Enabled = false;
			}
			else if (ChartSize == 2)
			{
				//sets the max and min x and y axis grid lines
				WaveChart.ChartAreas[0].AxisY.Maximum = 2;
				WaveChart.ChartAreas[0].AxisY.Minimum = -2;
				WaveChart.ChartAreas[0].AxisX.Maximum = 720;
				WaveChart.ChartAreas[0].AxisX.Minimum = 0;

				//This sets the line intervals for the x-axis and y-axis
				WaveChart.ChartAreas[0].AxisX.Interval = 45;
				WaveChart.ChartAreas[0].AxisY.Interval = 0.4;

				//This sets the button Zoom_Plus to the default button colour
				Zoom_Plus.ForeColor = SystemColors.ControlText;

				//This allows the user to press the button Zoom_Plus
				Zoom_Plus.Enabled = true;
			}
			else if (ChartSize == 3)
			{
				//sets the max and min x and y axis grid lines
				WaveChart.ChartAreas[0].AxisY.Maximum = 5;
				WaveChart.ChartAreas[0].AxisY.Minimum = -5;
				WaveChart.ChartAreas[0].AxisX.Maximum = 1080;
				WaveChart.ChartAreas[0].AxisX.Minimum = 0;

				//This sets the line intervals for the x-axis and y-axis
				WaveChart.ChartAreas[0].AxisX.Interval = 90;
				WaveChart.ChartAreas[0].AxisY.Interval = 1;

				//This sets the button Zoom_Minus to the default button colour
				Zoom_Minus.ForeColor = SystemColors.ControlText;

				//This allows the user to press the button Zoom_Minus
				Zoom_Minus.Enabled = true;
			}
			else if (ChartSize == 4)
			{
				//sets the max and min x and y axis grid lines
				WaveChart.ChartAreas[0].AxisY.Maximum = 10;
				WaveChart.ChartAreas[0].AxisY.Minimum = -10;
				WaveChart.ChartAreas[0].AxisX.Maximum = 1440;
				WaveChart.ChartAreas[0].AxisX.Minimum = 0;

				//This sets the line intervals for the x-axis and y-axis
				WaveChart.ChartAreas[0].AxisX.Interval = 180;
				WaveChart.ChartAreas[0].AxisY.Interval = 2;

				//This sets the button Zoom_Minus to gray
				Zoom_Minus.ForeColor = Color.Gray;

				//This disallows (stops) the user to press the button Zoom_Minus
				Zoom_Minus.Enabled = false;
			}
		}
		#endregion

		//This switches amplitude from being 1-10 to 0.1 to 0.9, or vice versa
		private void Amplitude_Decimal_RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (Amplitude_Decimal_RadioButton.Checked == true)
			{
				//This sets the number of decimal places for AmplitudeBox
				AmplitudeBox.DecimalPlaces = 1;

				//These set the maximum and minimum values for AmplitudeBox
				AmplitudeBox.Minimum = 0.1m;
				AmplitudeBox.Maximum = 0.9m;

				//This sets AmplitudeBox to increase by and increment of 0.1
				AmplitudeBox.Increment = 0.1m;

				//Sets the defult value equal to 0.1
				AmplitudeBox.Value = 0.1m;
			}
			else
			{
				//This sets the number of decimal places for AmplitudeBox
				AmplitudeBox.DecimalPlaces = 0;

				//These set the maximum and minimum values for AmplitudeBox
				AmplitudeBox.Minimum = 1;
				AmplitudeBox.Maximum = 10;

				//This sets AmplitudeBox to increase by and increment of 1
				AmplitudeBox.Increment = 1;

				//Sets the defult value equal to 1
				AmplitudeBox.Value = 1;
			}
		}

		//When this box is ticked it will start moving the wave
		private void Movement_checkBox_CheckedChanged(object sender, EventArgs e)
		{

			int c = 0;

			//SineWave(c);

			Period = Period * (10 ^ 3);

			while (Movement_checkBox.Checked == true)
			{
				MovementGroupBox.Enabled = true;

				Application.DoEvents();

				Thread.Sleep((int)Period);

				c += 1;
				SineWave(c);
			}

			if (Movement_checkBox.Checked == false)
			{
				MovementGroupBox.Enabled = false;
			}
		}

		//When the grid checkbox is changed the following will run
		private void ChartGrid_checkBox_CheckedChanged(object sender, EventArgs e)
		{
			//If the check box is not ticked the chart grid will be hidden
			if (ChartGrid_checkBox.Checked == false)
			{
				//This hides the grid lines from the chart
				WaveChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
				WaveChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

				//This hides the x and y axis lines
				WaveChart.ChartAreas[0].AxisX.LineColor = WaveChart.BackColor;
				WaveChart.ChartAreas[0].AxisY.LineColor = WaveChart.BackColor;

				//This removes number scale from the x and y axis of the chart
				WaveChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
				WaveChart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;

				//This removes the x and y axis scale lines
				WaveChart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;
				WaveChart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;

			}
			//If the check box is not ticked the chart grid will be displayed
			else if (ChartGrid_checkBox.Checked == true)
			{
				//This dsiplays the grid lines from the chart
				WaveChart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
				WaveChart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;

				//This hides the x and y axis lines
				WaveChart.ChartAreas[0].AxisX.LineColor = Color.Black;
				WaveChart.ChartAreas[0].AxisY.LineColor = Color.Black;

				//This removes number scale from the x and y axis of the chart
				WaveChart.ChartAreas[0].AxisX.LabelStyle.Enabled = true;
				WaveChart.ChartAreas[0].AxisY.LabelStyle.Enabled = true;

				//This removes the x and y axis scale lines
				WaveChart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
			}
		}
	}

	//Dervied abstract subclass from Simulation class (abstract means it cannot be instantiated)
	public abstract class Ref : Simulation
	{
		//The following function runs when an instance of a subclass, inherited the class Ref, is created
		public Ref(string name) : base(name)
		{
			//These call each call a function that sets their properties
			GroupBox = SetUp_GroupBox();
			IncidentAngle = SetUp_IncidentAngle();
			RefAngle = SetUp_RefAngle();
			AngleLabel = SetUp_AngleLabel();
			InputBoxAngle = SetUp_InputBoxAngle();

			//These add the controls for IncidentAngle, RefAngle, AngleLabel and InputAngle to GroupBox
			GroupBox.Controls.Add(IncidentAngle);
			GroupBox.Controls.Add(RefAngle);
			GroupBox.Controls.Add(AngleLabel);
			GroupBox.Controls.Add(InputBoxAngle);
		}

		//These create public labels called IncidentAngle and RefAngle
		public Label IncidentAngle;
		public Label RefAngle;

		//This creates a private label called AngleLabel
		private Label AngleLabel;

		//This creates a public NumericUpDown called InputBoxAngle
		public NumericUpDown InputBoxAngle;

		//This sets the properties for IncidentAngle
		public Label SetUp_IncidentAngle()
		{
			//This creates a new label called IncidentAngle
			Label IncidentAngle = new Label();

			//This sets the location for IncidentAngle
			IncidentAngle.Location = new Point(275, 315);

			//This automaticly sets the size of the lable IncidentAngle to fit the text inside it
			IncidentAngle.AutoSize = true;

			//This returns IncidentAngle
			return IncidentAngle;
		}

		//This sets the properties for RefAngle
		public Label SetUp_RefAngle()
		{
			//This creates a new label called RefAngle
			Label RefAngle = new Label();

			//This sets the location for RefAngle
			RefAngle.Location = new Point(305, 315);

			//This automaticly sets the size of the lable RefAngle to fit the text inside it
			RefAngle.AutoSize = true;

			//This returns RefAngle
			return RefAngle;
		}

		//This sets the properties for AngleLabel
		public Label SetUp_AngleLabel()
		{
			//This creates a new label called AngleLabel
			Label AngleLabel = new Label();

			//This sets the location for AngleLabel
			AngleLabel.Location = new Point(460, 385);

			//This sets the size of AngleLabel
			AngleLabel.Size = new Size(44, 17);

			//This sets AngleLabel's font and text size
			AngleLabel.Font = new Font("Microsoft Sans Serif", 10F);

			//This sets the text displayed by AngleLabel
			AngleLabel.Text = "Angle";

			//This returns AngleLabel
			return AngleLabel;
		}

		//This sets the properties for InputBoxAngle
		public NumericUpDown SetUp_InputBoxAngle()
		{
			//This creates a new NumericUpDown called InputBoxAngle
			NumericUpDown InputBoxAngle = new NumericUpDown();

			//This sets the location for InputBoxAngle
			InputBoxAngle.Location = new Point(510, 385);

			//This sets the size of InputBoxAngle
			InputBoxAngle.Size = new Size(45, 20);

			//These set the maximum and minimum values for InputBoxAngle
			InputBoxAngle.Minimum = 0;
			InputBoxAngle.Maximum = 90;

			//This sets InputBoxAngle to increase by an increment of 0.1
			InputBoxAngle.Increment = 0.1m;

			//This sets the number of decimal places for InputBoxAngle
			InputBoxAngle.DecimalPlaces = 1;

			//This returns InputBoxAngle
			return InputBoxAngle;
		}

		//This displays the line that the incident ray reflects off, or refracts through
		public virtual Point Ref_Line(PaintEventArgs e)
		{
			//These integers store different x and y coordinates
			int y_coordinate = 350;
			int x_LineStart = 50;
			int x_LineEnd = 550;

			//This finds the length of the reflection line and sets it equal to the integer LineLength
			int LineLength = x_LineEnd - x_LineStart;
			//This calculates the x coordinate
			int x_LineMiddle = x_LineStart + (LineLength / 2);

			//This creates a point that stores the start point for the bottom line
			Point LineStart = new Point(x_LineStart, y_coordinate);
			////This creates a point that stores the end point for the bottom line
			Point LineEnd = new Point(x_LineEnd, y_coordinate);

			//this stores the middle point of the line as a Point
			Point LineMiddle = new Point(x_LineMiddle, y_coordinate);

			//This creates a Graphic called diagram using PaintEventArgs
			Graphics diagram = e.Graphics;

			//Creates a pen that is black
			Pen blackPen = new Pen(Color.Black, 6);

			//This draws the horizontal black reflection line at the bottom of the form
			diagram.DrawLine(blackPen, LineStart, LineEnd);

			//This returns the LineMidddle point to Reflection_Paint
			return LineMiddle;
		}

		//This displays a dotted vertical line dividing the incident ray and the reflected or refracted ray
		public virtual void Normal_Line(PaintEventArgs e, int x_coordinate, int y_LineStart)
		{
			//This integer stores the y coordinate for the line end point
			int y_LineEnd = 50;

			Point LineStart = new Point(x_coordinate, y_LineStart);

			//This creates a point that stores the end point for vertical line
			Point LineEnd = new Point(x_coordinate, y_LineEnd);

			//This creates a Graphic called diagram using PaintEventArgs
			Graphics diagram = e.Graphics;

			//Creates a pen that is blue
			Pen bluePen = new Pen(Color.Blue, 3);

			//This creates a dash pattern so that the bluePen draws a dached line
			bluePen.DashPattern = new float[] { 4, 2 };

			//This draws the normal blue going upwards from the centre of the reflection line
			diagram.DrawLine(bluePen, LineStart, LineEnd);
		}

		//This sets the properties for the incident ray and then calls the function Display_ray
		public virtual void IncidentRay(PaintEventArgs e, Point LineStart, int length, double InputAngle)
		{
			//The entered angle is subtracted from 270, so that the line is drawn from the correct postion
			double IncidentAngle_degree = 270 - InputAngle;

			//Creates a pen that is red
			Pen redPen = new Pen(Color.Red, 5);
			//Creates a pen that is green
			Pen greenPen = new Pen(Color.Green, 3);

			//This displays in the InputAngle in the lable IncidentAngle
			IncidentAngle.Text = InputAngle + "°";

			//This sets the size of the angle for the arc equal to IncidentAngle_degree
			double ArcAngle = IncidentAngle_degree;

			//This calls the function that will display the ray using the values inputed
			Display_ray(e, LineStart, length, ArcAngle, InputAngle, IncidentAngle_degree, redPen, greenPen);
		}

		//This sets the properties for the reflected of refracted ray and then calls the function Display_ray
		public virtual void RefRay(PaintEventArgs e, Point LineStart, int length, int ArcAngle, double InputAngle, double RefAngle_Degree)
		{
			//Creates a pen that is purple
			Pen purplePen = new Pen(Color.Purple, 5);
			//Creates a pen that is orange
			Pen orangePen = new Pen(Color.Orange, 3);

			//This displays in the InputAngle in the lable RefAngle
			RefAngle.Text = InputAngle + "°";

			//This calls the function that will display the ray using the values inputed
			Display_ray(e, LineStart, length, ArcAngle, InputAngle, RefAngle_Degree, purplePen, orangePen);
		}

		//This calculates the end ponits for either the incident, reflected or refracted ray, and then dispays the ray to the user
		private void Display_ray(PaintEventArgs e, Point LineStart, int length, double ArcAngle, double InputAngle, double Angle_degree, Pen LinePen, Pen ArcPen)
		{
			//Converts the angle from degrees to radians
			double Angle_rad = (Math.PI / 180.0) * Angle_degree;

			//This seperates the startPoint into two integers, one for each X and Y value
			int Start_X_Coordinate = LineStart.X;
			int Start_Y_Coordinate = LineStart.Y;

			//Calculates the end coorodinates for the incedent ray and converts them to an integer
			int End_X_Coordinate = Convert.ToInt32(Start_X_Coordinate + (Math.Cos(Angle_rad) * length));
			int End_Y_Coordinate = Convert.ToInt32(Start_Y_Coordinate + (Math.Sin(Angle_rad) * length));

			//This creates a new point that stores the end point for the incident ray
			Point Ray_EndPoint = new Point(End_X_Coordinate, End_Y_Coordinate);

			//Creates a rectangle called Rectangle to contain the drawn incident angle
			Rectangle Rectangle = new Rectangle(Start_X_Coordinate - 50, Start_Y_Coordinate - 50, 100, 100);

			//This creates a Graphic called ray using PaintEventArgs
			Graphics ray = e.Graphics;

			//This draws a red line at incedent angle from the normal
			ray.DrawLine(LinePen, LineStart, Ray_EndPoint);

			//This draws the incedent angle graphically
			ray.DrawArc(ArcPen, Rectangle, (float)ArcAngle, (float)InputAngle);
		}
	}


	//Dervied subclass from Ref class
	public class Reflection : Ref
	{
		public Reflection(string name) : base(name) { }

		//This displays a reflection to the user
		public void Display()
		{
			//This sets the size of GroupBox
			GroupBox.Size = new Size(600, 500);

			//This adds the PaintEventHandler, called GroupBox_Paint, to GroupBox.Paint property
			GroupBox.Paint += new PaintEventHandler(GroupBox_Paint);

			//This adds the EventHandler, called InputAngle_ValueChanged, to InputAngle.ValueChanged property
			InputBoxAngle.ValueChanged += new EventHandler(InputBoxAngle_ValueChanged);
		}

		//This draws the reflection in GroupBox
		private void GroupBox_Paint(object sender, PaintEventArgs e)
		{
			//This sets the length of the line as an integer
			int length = 250;

			//Converts the value inputed in the NumericUpDown InputBoxAngle to a double
			double InputAngle = (double)InputBoxAngle.Value;

			//This creates a new Point called startPoint, that holds the start corrodinate for both incedent ray and reflected ray
			Point LineStart = Ref_Line(e);

			//This sets the x and y corrdinates of the point LineStart, equal to two integers for x and y corrdinates of the rays start corrdinates
			int x_coordinate = LineStart.X;
			int y_LineEnd = LineStart.Y;

			//This creates a new Point called startPoint, that holds the start corrodinate for both incedent ray and reflected ray
			Normal_Line(e, x_coordinate, y_LineEnd);

			//This calls the function IncidentRay
			IncidentRay(e, LineStart, length, InputAngle);

			//This calls the function ReflectedRay
			ReflectedRay(e, LineStart, length, InputAngle);
		}

		//This sets the corrdinates for the reflected ray
		private void ReflectedRay(PaintEventArgs e, Point LineStart, int length, double InputAngle)
		{
			//The reflected angle is equal to the input angle plus 270, so that the line is drawn from the correct postion
			double ReflectedAngle_degree = 270 + InputAngle;

			//This sets ArcAngle equal to 270
			int ArcAngle = 270;

			//This calls the function RefRay
			RefRay(e, LineStart, length, ArcAngle, InputAngle, ReflectedAngle_degree);
		}

		//This clears the graphics in groupbox so that new incident and reflected lines can be drawn
		private void InputBoxAngle_ValueChanged(object sender, EventArgs e)
		{
			GroupBox.Invalidate();
		}
	}


	//Dervied subclass from Ref subclass
	public class Refraction : Ref
	{
		//The following function runs when an instance of a subclass, inherited the class Ref, is created
		public Refraction(string name) : base(name)
		{
			//These call each call a function that sets their properties
			n1Label = SetUp_n1Label();
			n2Label = SetUp_n2Label();
			n1Box = SetUp_n1Box();
			n2Box = SetUp_n2Box();
			CriticalAngle_Label = SetUp_CriticalAngle_Label();

			//These add the controls for n1Label, n2Label, n1Box, n2Box and CriticalAngle_Label to GroupBox
			GroupBox.Controls.Add(n1Label);
			GroupBox.Controls.Add(n2Label);
			GroupBox.Controls.Add(n1Box);
			GroupBox.Controls.Add(n2Box);
			GroupBox.Controls.Add(CriticalAngle_Label);
		}

		//These create private labels called n1Label, n2Label
		private Label n1Label;
		private Label n2Label;

		//This creates a public label called CriticalAngle_Label
		public Label CriticalAngle_Label;

		//This creates a private NumericUpDown called n1Box
		public NumericUpDown n1Box;

		//This creates a private NumericUpDown called n2Box
		public NumericUpDown n2Box;

		//This sets the properties for n1Label
		private Label SetUp_n1Label()
		{
			//This creates a new label called n1Label
			Label n1Label = new Label();

			//This sets the location for n1Label
			n1Label.Location = new Point(383, 297);

			//This sets the size of n1Label
			n1Label.Size = new Size(121, 17);

			//This sets n1Label's font and text size
			n1Label.Font = new Font("Microsoft Sans Serif", 10F);

			//This sets the text displayed by n1Label
			n1Label.Text = "Refractive Index 1";

			//This returns n1Label
			return n1Label;
		}

		//This sets the properties for n2Label
		private Label SetUp_n2Label()
		{
			//This creates a new label called n2Label
			Label n2Label = new Label();

			//This sets the location for n2Label
			n2Label.Location = new Point(383, 427);

			//This sets the size of n2Label
			n2Label.Size = new Size(121, 17);

			//This sets n2Label's font and text size
			n2Label.Font = new Font("Microsoft Sans Serif", 10F);

			//This sets the text displayed by n2Label
			n2Label.Text = "Refractive Index 2";

			//This returns n2Label
			return n2Label;
		}

		//This sets the properties for CriticalAngle_Label
		private Label SetUp_CriticalAngle_Label()
		{
			//This creates a new label called n2Label
			Label CriticalAngle_Label = new Label();

			//This sets the location for CriticalAngle_Label
			CriticalAngle_Label.Location = new Point(406, 468);

			//This automaticly sets the size of the lable CriticalAngle_Label to fit the text inside it
			CriticalAngle_Label.AutoSize = true;

			//This sets CriticalAngle_Label's font and text size
			CriticalAngle_Label.Font = new Font("Microsoft Sans Serif", 10F);

			//This returns CriticalAngle_Label
			return CriticalAngle_Label;
		}

		//This sets the properties for n1
		private NumericUpDown SetUp_n1Box()
		{
			//This creates a new NumericUpDown called n1Box
			NumericUpDown n1Box = new NumericUpDown();

			//This sets the location for n1Box
			n1Box.Location = new Point(510, 297);

			//This sets the size of n1Box
			n1Box.Size = new Size(45, 20);

			//These set the maximum and minimum values for n1Box
			n1Box.Minimum = 1;
			n1Box.Maximum = 5;

			//This sets the number of decimal places for n1Box
			n1Box.DecimalPlaces = 2;

			//This sets n1Box to increase by an increment of 0.01
			n1Box.Increment = 0.01m;

			//This returns n1Box
			return n1Box;
		}

		//This sets the properties for n2Box
		private NumericUpDown SetUp_n2Box()
		{
			//This creates a new NumericUpDown called n2Box
			NumericUpDown n2Box = new NumericUpDown();

			//This sets the location for n2Box
			n2Box.Location = new Point(510, 427);

			//This sets the size of n2Box
			n2Box.Size = new Size(45, 20);

			//These set the maximum and minimum values for n2Box
			n2Box.Minimum = 1;
			n2Box.Maximum = 5;

			//This sets the number of decimal places for n2Box
			n2Box.DecimalPlaces = 2;

			//This sets n2Box to increase by an increment of 0.01
			n2Box.Increment = 0.01m;

			//Sets the defult value equal to 3
			n2Box.Value = 3;

			//This returns n2Box
			return n2Box;
		}

		//This displays a refraction to the user
		public void Display()
		{
			//This sets the size of GroupBox
			GroupBox.Size = new Size(600, 680);

			//This adds the PaintEventHandler, called GroupBox_Paint, to GroupBox.Paint property
			GroupBox.Paint += new PaintEventHandler(GroupBox_Paint);

			//This adds the EventHandler, called InputAngle_ValueChanged, to InputAngle.ValueChanged property
			InputBoxAngle.ValueChanged += new EventHandler(InputBoxAngle_ValueChanged);

			//This adds the EventHandler, called n1Box_ValueChanged, to n1Box.ValueChanged property
			n1Box.ValueChanged += new EventHandler(n1Box_ValueChanged);

			//This adds the EventHandler, called n2Box_ValueChanged, to n2Box.ValueChanged property
			n2Box.ValueChanged += new EventHandler(n2Box_ValueChanged);
		}

		//This clears the graphics in groupbox so that new incident and reflected lines can be drawn
		private void GroupBox_Paint(object sender, PaintEventArgs e)
		{
			//This sets the length of the line as an integer
			int length = 250;

			//Converts the value inputed in the NumericUpDown InputBoxAngle to a double
			double InputAngle = (double)InputBoxAngle.Value;

			//This creates a new Point called startPoint, that holds the start corrodinate for both incedent ray and reflected ray
			Point LineStart = Ref_Line(e);

			//This sets the x of the point LineStart equal to the an integer that stores for  rays starting x corrdinate
			int x_coordinate = LineStart.X;

			//This sets the integer for the start of the rays as 650
			int y_LineStart = 650;

			//This creates a new Point called startPoint, that holds the start corrodinate for both incedent ray and reflected ray
			Normal_Line(e, x_coordinate, y_LineStart);

			//This calls the function IncidentRay
			IncidentRay(e, LineStart, length, InputAngle);

			//This calls the function RefractedRay
			RefractedRay(e, LineStart, length, InputAngle);
		}

		//This sets the corrdinates for the refracted ray
		private void RefractedRay(PaintEventArgs e, Point LineStart, int length, double InputAngle)
		{
			//Converts the value inputed in the NumericUpDown n1 to a double
			double n1 = (double)n1Box.Value;

			//Converts the value inputed in the NumericUpDown n2 to a double
			double n2 = (double)n2Box.Value;

			//Converts the angle from degrees to radians
			double InputAngle_rad = (Math.PI / 180.0) * InputAngle;

			//Calculates the refracted angle using the inputed angle, refractive index 1 and refractive index 2
			double Input_RefractedAngle_rad = Math.Asin((n1 * Math.Sin(InputAngle_rad)) / n2);

			//Converts the angle from radians to degrees
			double Input_RefractedAngle_degree = (Input_RefractedAngle_rad * 180) / Math.PI;

			//This creates a double that will store the critical angle in degrees
			double CriticalAngle_degree;

			//This checks if the second refracted index is greater than or equal to the first refractive index
			if (n2 >= n1)
			{
				//This makes the critical angle equal zero
				CriticalAngle_degree = 0;

				//This hides the critical angle from the user
				CriticalAngle_Label.Visible = false;
			}
			else
			{
				//This creates a double that will store the critical angle in radians
				double CriticalAngle_rad;

				//This calculates the critical value
				CriticalAngle_rad = Math.Asin(n2 / n1);

				//This rounds CriticalAngle_rad to 2 decimal places
				CriticalAngle_rad = Math.Round(CriticalAngle_rad, 2);

				//Converts the CriticalAngle_rad from radians to degrees
				CriticalAngle_degree = (CriticalAngle_rad * 180) / Math.PI;

				//This rounds CriticalAngle_degree to 2 decimal places
				CriticalAngle_degree = Math.Round(CriticalAngle_degree, 1);

				//This sets the text displayed by CriticalAngle_Label
				CriticalAngle_Label.Text = "CriticalAngle: " + Convert.ToString(CriticalAngle_degree);

				//This displays the critical angle to the user
				CriticalAngle_Label.Visible = true;
			}

			//This stores the refracted angle
			double RefractedAngle_degree;

			//This int is use to store the starting angle for the refraction angle arc
			int ArcAngle;

			//This rounds InputAngle_rad to 2 decimal places
			InputAngle_rad = Math.Round(InputAngle_rad, 2);

			if (InputAngle == 90)
			{
				//This sets the location for RefAngle
				RefAngle.Location = new Point(305, 315);

				//This sets arc length equal to 270
				ArcAngle = 270;

				//RefractedAngle_degree is set equal to 0 as the critical angle is equal to 0, or the inputed angle equals 90 degrees
				RefractedAngle_degree = 0;

				//This sets Input_RefractedAngle_degree equal to 90 degrees
				Input_RefractedAngle_degree = 90;
			}
			else if (CriticalAngle_degree != 0 && InputAngle > CriticalAngle_degree)
			{
				//This sets the location for RefAngle
				RefAngle.Location = new Point(305, 315);

				//This sets arc length equal to 270
				ArcAngle = 270;

				//The refracted angle is subtracted from 270, so that the line is drawn from the correct postion
				RefractedAngle_degree = 270 + InputAngle;

				//This sets Input_RefractedAngle_degree equal to the inputed angle
				Input_RefractedAngle_degree = InputAngle;
			}
			else if (CriticalAngle_degree != 0 && InputAngle == CriticalAngle_degree)
			{
				//This sets the location for RefAngle
				RefAngle.Location = new Point(305, 315);

				//This sets arc length equal to 270
				ArcAngle = 270;

				//RefractedAngle_degree is set equal to 0 as the critical angle is equal to 0, or the inputed angle equals 90 degrees
				RefractedAngle_degree = 0;

				//This sets Input_RefractedAngle_degree equal to 90 degrees
				Input_RefractedAngle_degree = 90;
			}
			else
			{
				//The refracted angle is subtracted from 90, so that the line is drawn from the correct postion
				RefractedAngle_degree = 90 - Input_RefractedAngle_degree;

				//This sets the location for RefAngle
				RefAngle.Location = new Point(306, 370);

				//This sets ArcStartAngle the float of RefractedAngle_degree
				ArcAngle = (int)RefractedAngle_degree;
			}

			//This rounds Input_RefractedAngle to 2 decimal places
			InputAngle = Math.Round(Input_RefractedAngle_degree, 2);

			//
			RefRay(e, LineStart, length, ArcAngle, InputAngle, RefractedAngle_degree);
		}

		//This clears the graphics in groupbox so that new incident and refracted lines can be drawn
		public void InputBoxAngle_ValueChanged(object sender, EventArgs e)
		{
			GroupBox.Invalidate();
		}

		//This clears the graphics in groupbox so that new incident and refracted lines can be drawn
		public void n1Box_ValueChanged(object sender, EventArgs e)
		{
			GroupBox.Invalidate();
		}

		//This clears the graphics in groupbox so that new incident and refracted lines can be drawn
		public void n2Box_ValueChanged(object sender, EventArgs e)
		{
			GroupBox.Invalidate();
		}
	}
}
