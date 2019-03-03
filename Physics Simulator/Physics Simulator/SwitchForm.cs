using System.Windows.Forms;

namespace Physics_Simulator
{
	//This class allows me to switch between forms without repeating lots of code
	class SwitchForm
	{
		//This hides the current form and opens the selected form
		public void show(Form form)
		{
			Form.ActiveForm.Hide();

			//This stops the user from being able to resize the form
			form.FormBorderStyle = FormBorderStyle.FixedSingle;
			form.MaximizeBox = false;

			form.Show();
		}

		//This opens the selected form in a pop-up window
		public void show_dialog(Form form)
		{
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
		public void HomePage(string username)
		{
			HomePage form = new HomePage(username);
			show(form);
		}

		//This creates an instance of the Form Open
		public void Open()
		{
			Open form = new Open();
			show_dialog(form);
		}
	}
}
