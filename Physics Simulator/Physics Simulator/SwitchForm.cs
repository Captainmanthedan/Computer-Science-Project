using System.Windows.Forms;

namespace Physics_Simulator
{
	//This class allows me to switch between forms without repeating lots of code
	class SwitchForm
	{
		//This function hides the current form, displays the selected form and makes it so it cannot be resized
		private void show(Form form)
		{
			//This hides the form currently being used
			Form.ActiveForm.Hide();

			//This displays the selected form
			form.Show();

			//This stops the user from being able to resize the form
			form.FormBorderStyle = FormBorderStyle.FixedSingle;

			//This removes the maximise box from the form
			form.MaximizeBox = false;
		}

		//This opens the selected form in a pop-up window, that cannot be resized
		private void show_dialog(Form form)
		{
			//This stops the user from being able to resize the form
			form.FormBorderStyle = FormBorderStyle.FixedSingle;

			//This opens the selected form in a pop-up window
			form.ShowDialog();
		}

		//This creates an instance of the Form StartScreen
		public void StartScreen()
		{
			StartScreen form = new StartScreen();
			show(form);
		}

		//This creates an instance of the Form SignUp
		public void SignUp()
		{
			SignUp form = new SignUp();
			show(form);
		}

		//This creates an instance of the Form Login
		public void Login()
		{
			Login form = new Login();
			show(form);
		}

		//This creates an instance of the Form HomePage
		public void HomePage(string username, int UserID)
		{
			HomePage form = new HomePage(username, UserID);
			show(form);
		}

		//This creates an instance of the Form HomePage
		public void SimulationForm(string name, string Type, string username, int UserID, bool New)
		{
			SimulationForm form = new SimulationForm(name, Type, username, UserID, New);
			show(form);
		}

		//This creates an instance of the Form Open
		public void Open(string username, int UserID)
		{
			Open form = new Open(username, UserID);
			show(form);
		}
		
		public void SaveAs(SimulationForm Active_SimulationForm, string Type, int UserID)
		{
			SaveAs form = new SaveAs(Active_SimulationForm, Type, UserID);
			show_dialog(form);
		}
		
	}
}
