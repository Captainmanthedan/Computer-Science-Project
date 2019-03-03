namespace Reflection
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
			this.Input_angle = new System.Windows.Forms.NumericUpDown();
			this.angle = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Input_angle)).BeginInit();
			this.SuspendLayout();
			// 
			// Input_angle
			// 
			this.Input_angle.Location = new System.Drawing.Point(510, 385);
			this.Input_angle.Name = "Input_angle";
			this.Input_angle.Size = new System.Drawing.Size(41, 20);
			this.Input_angle.TabIndex = 2;
			this.Input_angle.ValueChanged += new System.EventHandler(this.Input_angle_ValueChanged);
			// 
			// angle
			// 
			this.angle.AutoSize = true;
			this.angle.BackColor = System.Drawing.SystemColors.Control;
			this.angle.Location = new System.Drawing.Point(275, 315);
			this.angle.Name = "angle";
			this.angle.Size = new System.Drawing.Size(35, 13);
			this.angle.TabIndex = 3;
			this.angle.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 461);
			this.Controls.Add(this.angle);
			this.Controls.Add(this.Input_angle);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			((System.ComponentModel.ISupportInitialize)(this.Input_angle)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.NumericUpDown Input_angle;
		private System.Windows.Forms.Label angle;
	}
}

