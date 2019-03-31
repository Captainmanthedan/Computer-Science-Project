namespace Physics_Simulator
{
	partial class SaveAs
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
			this.Name_Box = new System.Windows.Forms.TextBox();
			this.Name_Label = new System.Windows.Forms.Label();
			this.CancelButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Name_Box
			// 
			this.Name_Box.Location = new System.Drawing.Point(51, 107);
			this.Name_Box.Name = "Name_Box";
			this.Name_Box.Size = new System.Drawing.Size(265, 20);
			this.Name_Box.TabIndex = 0;
			// 
			// Name_Label
			// 
			this.Name_Label.AutoSize = true;
			this.Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
			this.Name_Label.Location = new System.Drawing.Point(12, 55);
			this.Name_Label.Name = "Name_Label";
			this.Name_Label.Size = new System.Drawing.Size(45, 16);
			this.Name_Label.TabIndex = 1;
			this.Name_Label.Text = "label1";
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(51, 155);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 3;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(241, 155);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 4;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// SaveAs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 202);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.Name_Label);
			this.Controls.Add(this.Name_Box);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveAs";
			this.Text = "Save As";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveAs_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox Name_Box;
		private System.Windows.Forms.Label Name_Label;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button SaveButton;
	}
}