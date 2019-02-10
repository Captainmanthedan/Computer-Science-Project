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
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(30, 11);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
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
			this.BoxC.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.BoxC.Location = new System.Drawing.Point(1061, 212);
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
			// AmpDEC
			// 
			this.AmpDEC.AutoSize = true;
			this.AmpDEC.Location = new System.Drawing.Point(1018, 280);
			this.AmpDEC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.AmpDEC.Name = "AmpDEC";
			this.AmpDEC.Size = new System.Drawing.Size(107, 17);
			this.AmpDEC.TabIndex = 11;
			this.AmpDEC.Text = "0 < Amplitude < 1";
			this.AmpDEC.UseVisualStyleBackColor = true;
			this.AmpDEC.CheckedChanged += new System.EventHandler(this.AmpDEC_CheckedChanged);
			// 
			// AmpINT
			// 
			this.AmpINT.AutoSize = true;
			this.AmpINT.Checked = true;
			this.AmpINT.Location = new System.Drawing.Point(1018, 302);
			this.AmpINT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.AmpINT.Name = "AmpINT";
			this.AmpINT.Size = new System.Drawing.Size(89, 17);
			this.AmpINT.TabIndex = 12;
			this.AmpINT.TabStop = true;
			this.AmpINT.Text = "Amplitude > 1";
			this.AmpINT.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1137, 569);
			this.Controls.Add(this.AmpINT);
			this.Controls.Add(this.AmpDEC);
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
	}
}

