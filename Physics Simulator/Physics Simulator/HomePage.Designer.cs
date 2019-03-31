namespace Physics_Simulator
{
	partial class HomePage
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
			this.Menu_Simulation = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_New = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Wave = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Reflection = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Refraction = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// Menu
			// 
			this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Username,
            this.Menu_Simulation,
            this.logoutToolStripMenuItem});
			this.Menu.Location = new System.Drawing.Point(0, 0);
			this.Menu.Name = "Menu";
			this.Menu.Size = new System.Drawing.Size(800, 24);
			this.Menu.TabIndex = 0;
			this.Menu.Text = "menuStrip1";
			// 
			// Menu_Username
			// 
			this.Menu_Username.Name = "Menu_Username";
			this.Menu_Username.Size = new System.Drawing.Size(72, 20);
			this.Menu_Username.Text = "Username";
			// 
			// Menu_Simulation
			// 
			this.Menu_Simulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_New,
            this.Menu_Open});
			this.Menu_Simulation.Name = "Menu_Simulation";
			this.Menu_Simulation.Size = new System.Drawing.Size(76, 20);
			this.Menu_Simulation.Text = "Simulation";
			// 
			// Menu_New
			// 
			this.Menu_New.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Wave,
            this.Menu_Reflection,
            this.Menu_Refraction});
			this.Menu_New.Name = "Menu_New";
			this.Menu_New.Size = new System.Drawing.Size(180, 22);
			this.Menu_New.Text = "New";
			// 
			// Menu_Wave
			// 
			this.Menu_Wave.Name = "Menu_Wave";
			this.Menu_Wave.Size = new System.Drawing.Size(180, 22);
			this.Menu_Wave.Text = "Wave";
			this.Menu_Wave.Click += new System.EventHandler(this.Menu_Wave_Click);
			// 
			// Menu_Reflection
			// 
			this.Menu_Reflection.Name = "Menu_Reflection";
			this.Menu_Reflection.Size = new System.Drawing.Size(180, 22);
			this.Menu_Reflection.Text = "Reflection";
			this.Menu_Reflection.Click += new System.EventHandler(this.Menu_Reflection_Click);
			// 
			// Menu_Refraction
			// 
			this.Menu_Refraction.Name = "Menu_Refraction";
			this.Menu_Refraction.Size = new System.Drawing.Size(180, 22);
			this.Menu_Refraction.Text = "Refraction";
			this.Menu_Refraction.Click += new System.EventHandler(this.Menu_Refraction_Click);
			// 
			// Menu_Open
			// 
			this.Menu_Open.Name = "Menu_Open";
			this.Menu_Open.Size = new System.Drawing.Size(180, 22);
			this.Menu_Open.Text = "Open";
			this.Menu_Open.Click += new System.EventHandler(this.Menu_Open_Click);
			// 
			// logoutToolStripMenuItem
			// 
			this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
			this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.logoutToolStripMenuItem.Text = "Logout";
			this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
			// 
			// HomePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Menu);
			this.MainMenuStrip = this.Menu;
			this.Name = "HomePage";
			this.Text = "HomePage";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomePage_FormClosing);
			this.Menu.ResumeLayout(false);
			this.Menu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip Menu;
		private System.Windows.Forms.ToolStripMenuItem Menu_Username;
		private System.Windows.Forms.ToolStripMenuItem Menu_Simulation;
		private System.Windows.Forms.ToolStripMenuItem Menu_New;
		private System.Windows.Forms.ToolStripMenuItem Menu_Wave;
		private System.Windows.Forms.ToolStripMenuItem Menu_Reflection;
		private System.Windows.Forms.ToolStripMenuItem Menu_Refraction;
		private System.Windows.Forms.ToolStripMenuItem Menu_Open;
		private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
	}
}

