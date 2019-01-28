namespace Sign_Graph___Zoom
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.button1 = new System.Windows.Forms.Button();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.BoxB = new System.Windows.Forms.NumericUpDown();
			this.BoxD = new System.Windows.Forms.NumericUpDown();
			this.BoxC = new System.Windows.Forms.NumericUpDown();
			this.BoxA = new System.Windows.Forms.NumericUpDown();
			this.AmpDEC = new System.Windows.Forms.RadioButton();
			this.AmpINT = new System.Windows.Forms.RadioButton();
			this.Zoom_Plus = new System.Windows.Forms.Button();
			this.Zoom_Minus = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxC)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxA)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1396, 652);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 28);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(40, 14);
			this.chart1.Margin = new System.Windows.Forms.Padding(4);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(1267, 654);
			this.chart1.TabIndex = 2;
			this.chart1.Text = "chart1";
			// 
			// BoxB
			// 
			this.BoxB.Location = new System.Drawing.Point(1415, 229);
			this.BoxB.Margin = new System.Windows.Forms.Padding(4);
			this.BoxB.Minimum = new decimal(new int[] {
			100,
			0,
			0,
			-2147483648});
			this.BoxB.Name = "BoxB";
			this.BoxB.Size = new System.Drawing.Size(81, 22);
			this.BoxB.TabIndex = 7;
			// 
			// BoxD
			// 
			this.BoxD.Location = new System.Drawing.Point(1415, 293);
			this.BoxD.Margin = new System.Windows.Forms.Padding(4);
			this.BoxD.Minimum = new decimal(new int[] {
			100,
			0,
			0,
			-2147483648});
			this.BoxD.Name = "BoxD";
			this.BoxD.Size = new System.Drawing.Size(81, 22);
			this.BoxD.TabIndex = 8;
			// 
			// BoxC
			// 
			this.BoxC.Increment = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.BoxC.Location = new System.Drawing.Point(1415, 261);
			this.BoxC.Margin = new System.Windows.Forms.Padding(4);
			this.BoxC.Maximum = new decimal(new int[] {
			21,
			0,
			0,
			0});
			this.BoxC.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.BoxC.Name = "BoxC";
			this.BoxC.Size = new System.Drawing.Size(81, 22);
			this.BoxC.TabIndex = 9;
			this.BoxC.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// BoxA
			// 
			this.BoxA.Location = new System.Drawing.Point(1415, 197);
			this.BoxA.Margin = new System.Windows.Forms.Padding(4);
			this.BoxA.Maximum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.BoxA.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.BoxA.Name = "BoxA";
			this.BoxA.Size = new System.Drawing.Size(81, 22);
			this.BoxA.TabIndex = 10;
			this.BoxA.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// AmpDEC
			// 
			this.AmpDEC.AutoSize = true;
			this.AmpDEC.Location = new System.Drawing.Point(1357, 345);
			this.AmpDEC.Name = "AmpDEC";
			this.AmpDEC.Size = new System.Drawing.Size(139, 21);
			this.AmpDEC.TabIndex = 11;
			this.AmpDEC.Text = "0 < Amplitude < 1";
			this.AmpDEC.UseVisualStyleBackColor = true;
			this.AmpDEC.CheckedChanged += new System.EventHandler(this.AmpDEC_CheckedChanged);
			// 
			// AmpINT
			// 
			this.AmpINT.AutoSize = true;
			this.AmpINT.Checked = true;
			this.AmpINT.Location = new System.Drawing.Point(1357, 372);
			this.AmpINT.Name = "AmpINT";
			this.AmpINT.Size = new System.Drawing.Size(115, 21);
			this.AmpINT.TabIndex = 12;
			this.AmpINT.TabStop = true;
			this.AmpINT.Text = "Amplitude > 1";
			this.AmpINT.UseVisualStyleBackColor = true;
			// 
			// Zoom_Plus
			// 
			this.Zoom_Plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Zoom_Plus.Location = new System.Drawing.Point(121, 665);
			this.Zoom_Plus.Name = "Zoom_Plus";
			this.Zoom_Plus.Size = new System.Drawing.Size(35, 35);
			this.Zoom_Plus.TabIndex = 14;
			this.Zoom_Plus.Text = "+";
			this.Zoom_Plus.UseVisualStyleBackColor = true;
			this.Zoom_Plus.Click += new System.EventHandler(this.Zoom_Plus_Click);
			// 
			// Zoom_Minus
			// 
			this.Zoom_Minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Zoom_Minus.Location = new System.Drawing.Point(79, 665);
			this.Zoom_Minus.Name = "Zoom_Minus";
			this.Zoom_Minus.Size = new System.Drawing.Size(35, 35);
			this.Zoom_Minus.TabIndex = 15;
			this.Zoom_Minus.Text = "-";
			this.Zoom_Minus.UseVisualStyleBackColor = true;
			this.Zoom_Minus.Click += new System.EventHandler(this.Zoom_Minus_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1516, 700);
			this.Controls.Add(this.Zoom_Minus);
			this.Controls.Add(this.Zoom_Plus);
			this.Controls.Add(this.AmpINT);
			this.Controls.Add(this.AmpDEC);
			this.Controls.Add(this.BoxA);
			this.Controls.Add(this.BoxC);
			this.Controls.Add(this.BoxD);
			this.Controls.Add(this.BoxB);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.button1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxC)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxA)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.NumericUpDown BoxB;
		private System.Windows.Forms.NumericUpDown BoxD;
		private System.Windows.Forms.NumericUpDown BoxC;
		private System.Windows.Forms.NumericUpDown BoxA;
		private System.Windows.Forms.RadioButton AmpDEC;
		private System.Windows.Forms.RadioButton AmpINT;
		private System.Windows.Forms.Button Zoom_Plus;
		private System.Windows.Forms.Button Zoom_Minus;
	}
}

