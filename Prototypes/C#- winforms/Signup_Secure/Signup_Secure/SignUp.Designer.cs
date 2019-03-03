namespace Signup_Secure
{
	partial class SignUp
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Register = new System.Windows.Forms.Button();
			this.UsernameBox = new System.Windows.Forms.TextBox();
			this.FirstNameBox = new System.Windows.Forms.TextBox();
			this.LastNameBox = new System.Windows.Forms.TextBox();
			this.PassBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(77, 144);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Username";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(77, 171);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "First name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(77, 197);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Last name";
			// 
			// Register
			// 
			this.Register.Location = new System.Drawing.Point(232, 254);
			this.Register.Name = "Register";
			this.Register.Size = new System.Drawing.Size(75, 23);
			this.Register.TabIndex = 7;
			this.Register.Text = "Register";
			this.Register.UseVisualStyleBackColor = true;
			this.Register.Click += new System.EventHandler(this.Register_Click);
			// 
			// UsernameBox
			// 
			this.UsernameBox.Location = new System.Drawing.Point(171, 137);
			this.UsernameBox.Name = "UsernameBox";
			this.UsernameBox.Size = new System.Drawing.Size(136, 20);
			this.UsernameBox.TabIndex = 8;
			this.UsernameBox.TextChanged += new System.EventHandler(this.UsernameBox_TextChanged);
			// 
			// FirstNameBox
			// 
			this.FirstNameBox.Location = new System.Drawing.Point(171, 164);
			this.FirstNameBox.Name = "FirstNameBox";
			this.FirstNameBox.Size = new System.Drawing.Size(136, 20);
			this.FirstNameBox.TabIndex = 9;
			// 
			// LastNameBox
			// 
			this.LastNameBox.Location = new System.Drawing.Point(171, 190);
			this.LastNameBox.Name = "LastNameBox";
			this.LastNameBox.Size = new System.Drawing.Size(136, 20);
			this.LastNameBox.TabIndex = 10;
			// 
			// PassBox
			// 
			this.PassBox.Location = new System.Drawing.Point(171, 216);
			this.PassBox.Name = "PassBox";
			this.PassBox.Size = new System.Drawing.Size(136, 20);
			this.PassBox.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(77, 223);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Password";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(142, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Register for an Account";
			// 
			// SignUp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 340);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.PassBox);
			this.Controls.Add(this.LastNameBox);
			this.Controls.Add(this.FirstNameBox);
			this.Controls.Add(this.UsernameBox);
			this.Controls.Add(this.Register);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "SignUp";
			this.Text = "SignUp";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button Register;
		private System.Windows.Forms.TextBox UsernameBox;
		private System.Windows.Forms.TextBox FirstNameBox;
		private System.Windows.Forms.TextBox LastNameBox;
		private System.Windows.Forms.TextBox PassBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}

