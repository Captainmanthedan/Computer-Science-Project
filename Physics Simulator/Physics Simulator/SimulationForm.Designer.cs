namespace Physics_Simulator
{
	partial class SimulationForm
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
			this.Menu = new System.Windows.Forms.MenuStrip();
			this.Menu_Username = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Home = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File_New = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File_New_Wave = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File_New_Reflection = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File_New_Refraction = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// Menu
			// 
			this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Username,
            this.Menu_Home,
            this.Menu_File});
			this.Menu.Location = new System.Drawing.Point(0, 0);
			this.Menu.Name = "Menu";
			this.Menu.Size = new System.Drawing.Size(624, 24);
			this.Menu.TabIndex = 5;
			this.Menu.Text = "menuStrip1";
			// 
			// Menu_Username
			// 
			this.Menu_Username.Name = "Menu_Username";
			this.Menu_Username.Size = new System.Drawing.Size(72, 20);
			this.Menu_Username.Text = "Username";
			// 
			// Menu_Home
			// 
			this.Menu_Home.Name = "Menu_Home";
			this.Menu_Home.Size = new System.Drawing.Size(52, 20);
			this.Menu_Home.Text = "Home";
			this.Menu_Home.Click += new System.EventHandler(this.Menu_Home_Click);
			// 
			// Menu_File
			// 
			this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File_New,
            this.Menu_File_Open,
            this.Menu_File_Save,
            this.Menu_File_SaveAs});
			this.Menu_File.Name = "Menu_File";
			this.Menu_File.Size = new System.Drawing.Size(37, 20);
			this.Menu_File.Text = "File";
			// 
			// Menu_File_New
			// 
			this.Menu_File_New.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File_New_Wave,
            this.Menu_File_New_Reflection,
            this.Menu_File_New_Refraction});
			this.Menu_File_New.Name = "Menu_File_New";
			this.Menu_File_New.Size = new System.Drawing.Size(114, 22);
			this.Menu_File_New.Text = "New";
			// 
			// Menu_File_New_Wave
			// 
			this.Menu_File_New_Wave.Name = "Menu_File_New_Wave";
			this.Menu_File_New_Wave.Size = new System.Drawing.Size(128, 22);
			this.Menu_File_New_Wave.Text = "Wave";
			this.Menu_File_New_Wave.Click += new System.EventHandler(this.Menu_File_New_Wave_Click);
			// 
			// Menu_File_New_Reflection
			// 
			this.Menu_File_New_Reflection.Name = "Menu_File_New_Reflection";
			this.Menu_File_New_Reflection.Size = new System.Drawing.Size(128, 22);
			this.Menu_File_New_Reflection.Text = "Reflection";
			this.Menu_File_New_Reflection.Click += new System.EventHandler(this.Menu_File_New_Reflection_Click);
			// 
			// Menu_File_New_Refraction
			// 
			this.Menu_File_New_Refraction.Name = "Menu_File_New_Refraction";
			this.Menu_File_New_Refraction.Size = new System.Drawing.Size(128, 22);
			this.Menu_File_New_Refraction.Text = "Refraction";
			this.Menu_File_New_Refraction.Click += new System.EventHandler(this.Menu_File_New_Refraction_Click);
			// 
			// Menu_File_Open
			// 
			this.Menu_File_Open.Name = "Menu_File_Open";
			this.Menu_File_Open.Size = new System.Drawing.Size(114, 22);
			this.Menu_File_Open.Text = "Open";
			this.Menu_File_Open.Click += new System.EventHandler(this.Menu_File_Open_Click);
			// 
			// Menu_File_Save
			// 
			this.Menu_File_Save.Name = "Menu_File_Save";
			this.Menu_File_Save.Size = new System.Drawing.Size(114, 22);
			this.Menu_File_Save.Text = "Save";
			this.Menu_File_Save.Click += new System.EventHandler(this.Menu_File_Save_Click);
			// 
			// Menu_File_SaveAs
			// 
			this.Menu_File_SaveAs.Name = "Menu_File_SaveAs";
			this.Menu_File_SaveAs.Size = new System.Drawing.Size(114, 22);
			this.Menu_File_SaveAs.Text = "Save As";
			this.Menu_File_SaveAs.Click += new System.EventHandler(this.Menu_File_SaveAs_Click);
			// 
			// SimulationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 536);
			this.Controls.Add(this.Menu);
			this.MainMenuStrip = this.Menu;
			this.Name = "SimulationForm";
			this.Text = "Simulation";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimulationForm_FormClosing);
			this.Menu.ResumeLayout(false);
			this.Menu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip Menu;
		private System.Windows.Forms.ToolStripMenuItem Menu_File;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_New;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_Open;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_Save;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_SaveAs;
		private System.Windows.Forms.ToolStripMenuItem Menu_Home;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_New_Wave;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_New_Reflection;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_New_Refraction;
		private System.Windows.Forms.ToolStripMenuItem Menu_Username;
	}
}

