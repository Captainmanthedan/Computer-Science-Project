namespace Physics_Simulator
{
	partial class StartScreen
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
			this.SignUp_Button = new System.Windows.Forms.Button();
			this.Login_Button = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// SignUp_Button
			// 
			this.SignUp_Button.Location = new System.Drawing.Point(12, 229);
			this.SignUp_Button.Name = "SignUp_Button";
			this.SignUp_Button.Size = new System.Drawing.Size(75, 23);
			this.SignUp_Button.TabIndex = 0;
			this.SignUp_Button.Text = "Sign Up";
			this.SignUp_Button.UseVisualStyleBackColor = true;
			this.SignUp_Button.Click += new System.EventHandler(this.SignUp_Button_Click);
			// 
			// Login_Button
			// 
			this.Login_Button.Location = new System.Drawing.Point(297, 229);
			this.Login_Button.Name = "Login_Button";
			this.Login_Button.Size = new System.Drawing.Size(75, 23);
			this.Login_Button.TabIndex = 1;
			this.Login_Button.Text = "Login";
			this.Login_Button.UseVisualStyleBackColor = true;
			this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(41, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 146);
			this.label1.TabIndex = 2;
			this.label1.Text = "Physics\r\nSimulator";
			// 
			// StartScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 261);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Login_Button);
			this.Controls.Add(this.SignUp_Button);
			this.Name = "StartScreen";
			this.Text = "Physics Simulator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartScreen_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button SignUp_Button;
		private System.Windows.Forms.Button Login_Button;
		private System.Windows.Forms.Label label1;
	}
}

