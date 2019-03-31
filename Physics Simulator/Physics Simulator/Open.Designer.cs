namespace Physics_Simulator
{
	partial class Open
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
			this.Table = new System.Windows.Forms.DataGridView();
			this.OpenButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
			this.SuspendLayout();
			// 
			// Table
			// 
			this.Table.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Table.Location = new System.Drawing.Point(32, 31);
			this.Table.Name = "Table";
			this.Table.Size = new System.Drawing.Size(318, 150);
			this.Table.TabIndex = 0;
			// 
			// OpenButton
			// 
			this.OpenButton.Location = new System.Drawing.Point(275, 198);
			this.OpenButton.Name = "OpenButton";
			this.OpenButton.Size = new System.Drawing.Size(75, 23);
			this.OpenButton.TabIndex = 1;
			this.OpenButton.Text = "Open";
			this.OpenButton.UseVisualStyleBackColor = true;
			this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(32, 198);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 2;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// Open
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(380, 235);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OpenButton);
			this.Controls.Add(this.Table);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Open";
			this.Text = "Open";
			((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView Table;
		private System.Windows.Forms.Button OpenButton;
		private System.Windows.Forms.Button CancelButton;
	}
}