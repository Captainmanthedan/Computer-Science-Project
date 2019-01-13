namespace sine_graph_4
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.button1 = new System.Windows.Forms.Button();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.BoxB = new System.Windows.Forms.NumericUpDown();
			this.BoxD = new System.Windows.Forms.NumericUpDown();
			this.BoxC = new System.Windows.Forms.NumericUpDown();
			this.BoxA = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxC)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxA)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1047, 530);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// chart1
			// 
			chartArea6.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea6);
			legend6.Name = "Legend1";
			this.chart1.Legends.Add(legend6);
			this.chart1.Location = new System.Drawing.Point(30, 11);
			this.chart1.Name = "chart1";
			series6.ChartArea = "ChartArea1";
			series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series6.Legend = "Legend1";
			series6.Name = "Series1";
			this.chart1.Series.Add(series6);
			this.chart1.Size = new System.Drawing.Size(950, 531);
			this.chart1.TabIndex = 2;
			this.chart1.Text = "chart1";
			// 
			// BoxB
			// 
			this.BoxB.Location = new System.Drawing.Point(1061, 186);
			this.BoxB.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.BoxB.Name = "BoxB";
			this.BoxB.Size = new System.Drawing.Size(61, 20);
			this.BoxB.TabIndex = 7;
			// 
			// BoxD
			// 
			this.BoxD.Location = new System.Drawing.Point(1061, 238);
			this.BoxD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.BoxD.Name = "BoxD";
			this.BoxD.Size = new System.Drawing.Size(61, 20);
			this.BoxD.TabIndex = 8;
			// 
			// BoxC
			// 
			this.BoxC.Location = new System.Drawing.Point(1061, 212);
			this.BoxC.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.BoxC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.BoxC.Name = "BoxC";
			this.BoxC.Size = new System.Drawing.Size(61, 20);
			this.BoxC.TabIndex = 9;
			this.BoxC.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// BoxA
			// 
			this.BoxA.Location = new System.Drawing.Point(1061, 160);
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
			this.BoxA.Size = new System.Drawing.Size(61, 20);
			this.BoxA.TabIndex = 10;
			this.BoxA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1137, 569);
			this.Controls.Add(this.BoxA);
			this.Controls.Add(this.BoxC);
			this.Controls.Add(this.BoxD);
			this.Controls.Add(this.BoxB);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxC)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxA)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.NumericUpDown BoxB;
		private System.Windows.Forms.NumericUpDown BoxD;
		private System.Windows.Forms.NumericUpDown BoxC;
		private System.Windows.Forms.NumericUpDown BoxA;
	}
}

