using System;
using System.Windows.Forms;

namespace Physics_Simulator
{
	public partial class HomePage : Form
	{
		public HomePage(string username)
		{
			InitializeComponent();

			SetUp(username);
		}

		private void SetUp(string username)
		{
			Menu_Username.Text = username;
		}

		//This creates an instance of the class I created called SwitchForm that allows me to change between forms
		SwitchForm switchForm = new SwitchForm();

		private void Menu_Open_Click (object sender, EventArgs e)
		{
			//This calls the function SignUp from SwitchForm class, which displays Open form as a pop-up window
			switchForm.Open();
		}
	}
}
