using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics_Simulator
{
	public partial class StartScreen : Form
	{
		public StartScreen()
		{
			InitializeComponent();
		}

		//This creates an instance of the class I created called SwitchForm that allows me to change between forms
		SwitchForm switchForm = new SwitchForm();

		private void SignUp_Button_Click(object sender, EventArgs e)
		{
			//This calls the method SignUp from the class SwitchForm, which closes this form and displays SignUp form
			//switchForm.SignUp();
			switchForm.Open();
		}

		private void Login_Button_Click(object sender, EventArgs e)
		{
			//This calls the method Login from the class SwitchForm, which closes this form and displays Login form
			switchForm.Login();
		}

		private void StartScreen_FormClosing(object sender, FormClosingEventArgs e)
		{
			//This stops the appliction when the form closes
			Application.ExitThread();
		}
	}
}
