using System;
using System.Windows.Forms;

namespace Physics_Simulator
{
	public partial class HomePage : Form
	{
		public HomePage(string Passed_username, int Passed_UserID)
		{
			InitializeComponent();

			//This stores the users username as a private variable
			username = Passed_username;

			//This displays the users username
			Menu_Username.Text = username;

			//This sets the user id of the users account (passed from another form) equal to the Private variable UserID
			UserID = Passed_UserID;
		}

		//This creates an instance of the class SwitchForm, that allows the user to change between forms
		private SwitchForm switchForm = new SwitchForm();

		//This stores the users username as a private variable
		private string username;

		//This stores the users user ID
		private int UserID;

		private void Menu_Wave_Click(object sender, EventArgs e)
		{
			string Type = "Wave";
			string name = "New Wave";

			//This tells the program the simulation to be displayed is a new simualtion
			bool New = true;

			//This calls the method SimulationForm from the class SwitchForm, which closes this form and displays SimulationForm form
			switchForm.SimulationForm(name, Type, username, UserID, New);
		}

		private void Menu_Reflection_Click(object sender, EventArgs e)
		{
			string Type = "Reflection";
			string name = "New Reflection";

			//This tells the program the simulation to be displayed is a new simualtion
			bool New = true;

			//This calls the method SimulationForm from the class SwitchForm, which closes this form and displays SimulationForm form
			switchForm.SimulationForm(name, Type, username, UserID, New);
		}

		private void Menu_Refraction_Click(object sender, EventArgs e)
		{
			string Type = "Refraction";
			string name = "New Refraction";

			//This tells the program the simulation to be displayed is a new simualtion
			bool New = true;

			//This calls the method SimulationForm from the class SwitchForm, which closes this form and displays SimulationForm form
			switchForm.SimulationForm(name, Type, username, UserID, New);
		}


		private void Menu_Open_Click(object sender, EventArgs e)
		{
			//This calls the function Open from SwitchForm class, which displays Open form
			switchForm.Open(username, UserID);
		}

		//This sends the user back to the startscreen
		private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			switchForm.StartScreen();
		}

		private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
		{
			switchForm.StartScreen();
		}
	}
}
