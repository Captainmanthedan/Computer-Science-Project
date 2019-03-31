using System;
using System.Drawing;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;

namespace Physics_Simulator
{
	public partial class SimulationForm : Form
	{
		public SimulationForm(string Passedname, string Passed_Type, string Passed_username, int Passed_UserID, bool New)
		{
			InitializeComponent();

			SetUp(Passedname, Passed_Type, Passed_username, Passed_UserID);

			//The following if statement determines if the simualtion is new or not
			if (New == true)    //This runs if the simulation is new
			{
				//This determines what type of simulation is to be opened
				if (Type == "Wave")
				{
					//This calls the function Wave
					Wave();
				}
				else if (Type == "Reflection")
				{
					//This calls the function Reflection
					Reflection();
				}
				else if (Type == "Refraction")
				{
					//This calls the function Refraction
					Refraction();
				}
			}
			else if (New == false)    //This runs if the simulation is not new and is to be opened
			{
				//This calls the function Open
				Open();
			}
		}

		//This stores the Type of simualtion as a private variable so it can be used when saving a simualtion
		private string Type;

		//This stores the users username as a private variable
		private string username;

		//This stores the users user ID that is used when saving a simualtion
		private int UserID;

		//This public string stores the name of the current simulation, and is public so it can be called in the form SaveAs
		public string name;

		//This public boolean stores whre or not the user decided to cancel saving a simulation in the form SaveAs, and is public so it can be called in the form SaveAs
		public bool Save_Cancel;

		//
		private void SetUp(string Passedname, string Passed_Type, string Passed_username, int Passed_UserID)
		{
			//This sets the type of simualtion (passed from another form) equal to the Private variable Type
			Type = Passed_Type;

			//This sets the name of the simualtion (passed from another form) equal to the Private variable name
			name = Passedname;

			//This stores the users username as a private variable
			username = Passed_username;

			//This displays the users username
			Menu_Username.Text = username;

			//This sets the user id of the users account (passed from another form) equal to the Private variable UserID
			UserID = Passed_UserID;

		}

		//This are used to store the simualtion when it is opened
		private Wave Wave_Simulation;
		private Reflection Reflection_Simulation;
		private Refraction Refraction_Simulation;

		//This creates an instance of the class SwitchForm, that allows the user to change between forms
		private SwitchForm switchForm = new SwitchForm();

		//This function displays a wave simulation by creating a new instantiation of the class Wave
		private void Wave()
		{
			//This creates an instance of the class called Wave
			Wave_Simulation = new Wave(name);

			//This sets the forms size
			Size = new Size(1090, 680);

			//This adds the controls for GroupBox to the current form
			Controls.Add(Wave_Simulation.GroupBox);

			//This calls a function in the class Refraction that displays the wave
			Wave_Simulation.Display();
		}

		//This function displays a reflection simulation by creating a new instantiation of the class Reflection
		private void Reflection()
		{
			//This creates an instance of the class called Reflection
			Reflection_Simulation = new Reflection(name);

			//This sets the forms size
			Size = new Size(638, 575);

			//This adds the controls for GroupBox to the current form
			Controls.Add(Reflection_Simulation.GroupBox);

			//This calls a function in the class Reflection that displays the reflection
			Reflection_Simulation.Display();
		}

		//This function displays a refraction simulation by creating a new instantiation of the class Refraction
		private void Refraction()
		{
			//This creates an instance of the class called Refraction
			Refraction_Simulation = new Refraction(name);

			//This sets the forms size
			Size = new Size(640, 750);

			//This adds the controls for GroupBox to the current form
			Controls.Add(Refraction_Simulation.GroupBox);

			//This calls a function in the class Refraction that displays the refraction
			Refraction_Simulation.Display();
		}

		//This function saves the currently open simulation. It updates the values on the database stored under the name of the simulation, or if the simulation name does not exist it calls the function SaveAs
		public void Save()
		{
			//This stores the defult name given to each new simualtion
			string DefaultName = "New " + Type + "";

			//
			if (name == DefaultName)
			{
				//This calls the function SaveAs
				SaveAs();
			}
			else
			{
				//this stores the current time which is when the user clicked the Register button
				DateTime date_time = DateTime.Now;

				//this uses the DateTime structure (DateSaved) and puts it in a form that can be understood by MySQL [abatishchev, 2013]
				string DateSaved = date_time.ToString("yyyy-MM-dd HH:mm:ss");

				//this stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
				string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=PhysicsSimulator;";

				//This string will be used to hold the query of the type of simulation that will be updated (e.g. Wave)
				string UpdateSimulaion_query;

				//This selects the correct query for the type of simualtion that is being saved
				if (Type == "Wave")
				{
					//This creates a queries that updates the data in database table Wave [Delgado, 2017]
					UpdateSimulaion_query = "UPDATE Wave SET Amplitude = '" + Wave_Simulation.Amplitude + "', Wavelength = '" + Wave_Simulation.Wavelength + "', WaveSpeed = '" + Wave_Simulation.WaveSpeed + "', Frequency = '" + Wave_Simulation.Frequency + "', Period = '" + Wave_Simulation.Period + "', DateSaved = '" + DateSaved + "' WHERE SavedName = '" + name + "' AND UserID = '" + UserID + "'";
				}
				else if (Type == "Reflection")
				{
					//This creates a queries that updates the data in database table Reflection [Delgado, 2017]
					UpdateSimulaion_query = "UPDATE Reflection SET Angle = '" + Reflection_Simulation.InputBoxAngle.Value + "', DateSaved = '" + DateSaved + "' WHERE SavedName = '" + name + "' AND UserID = '" + UserID + "'";
				}
				else
				{
					//This creates a queries that updates the data in database table Refraction [Delgado, 2017]
					UpdateSimulaion_query = "UPDATE Refraction SET IncidentAngle = '" + Refraction_Simulation.InputBoxAngle.Value + "', RefractedAngle = '" + Refraction_Simulation.RefAngle.Text + "', RefractiveIndex1 = '" + Refraction_Simulation.n1Box.Value + "', RefractiveIndex2 = '" + Refraction_Simulation.n2Box.Value + "', CriticalAngle = '" + Refraction_Simulation.CriticalAngle_Label.Text + "', DateSaved = '" + DateSaved + "' WHERE SavedName = '" + name + "' AND UserID = '" + UserID + "'";
				}

				//This prepares the connection to the database [Delgado, 2017]
				MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //This creates a new connection to the MySql database (using the connectionString) called databaseConnection
				MySqlCommand UpdateSimulaion = new MySqlCommand(UpdateSimulaion_query, databaseConnection);     //This stores the MySql query UpdateSimulaion_query as a new command that can be executed by Sql called UpdateSimulaion
				MySqlDataReader reader;     //The result of the query will be stored in the MySQLReader called reader

				//Opens the connection to the database [Delgado, 2017]
				databaseConnection.Open();

				//This executes the query explained above [Delgado, 2017]
				reader = UpdateSimulaion.ExecuteReader();

				//Closes the connection to the database [Delgado, 2017]
				databaseConnection.Close();

				//This tells the user that the simulation has been saved
				MessageBox.Show("Saved " + name);
			}
		}

		//This gets the user to enter the name that they would like to save the simualtion as
		private void SaveAs()
		{
			switchForm.SaveAs(this, Type, UserID);

			if (Save_Cancel == false)
			{
				//this stores the current time which is when the user clicked the Register button
				DateTime date_time = DateTime.Now;

				//this uses the DateTime structure (DateSaved) and puts it in a form that can be understood by MySQL [abatishchev, 2013]
				string DateSaved = date_time.ToString("yyyy-MM-dd HH:mm:ss");

				//this stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
				string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=PhysicsSimulator;";

				//This string will be used to hold the query of the type of simulation that will be saved (e.g. Wave)
				string SaveSimulaion_query;

				//This selects the correct query for the type of simualtion that is being saved
				if (Type == "Wave")
				{
					//This creates a queries that adds data of the current wave to the database table Wave [Delgado, 2017]
					SaveSimulaion_query = "INSERT INTO Wave (UserID , SavedName, Amplitude, Wavelength, WaveSpeed, Frequency, Period, DateSaved) VALUES('" + UserID + "', '" + name + "', '" + Wave_Simulation.Amplitude + "', '" + Wave_Simulation.Wavelength + "', '" + Wave_Simulation.WaveSpeed + "', '" + Wave_Simulation.Frequency + "', '" + Wave_Simulation.Period + "', '" + DateSaved + "')";
				}
				else if (Type == "Reflection")
				{
					//This creates a queries that adds data of the current reflection to the database table Reflection [Delgado, 2017]
					SaveSimulaion_query = "INSERT INTO Reflection(UserID , SavedName, Angle, DateSaved) VALUES('" + UserID + "', '" + name + "', '" + Reflection_Simulation.InputBoxAngle.Value + "', '" + DateSaved + "')";
				}
				else
				{
					//This creates a queries that adds data of the current refraction to the database table Refraction [Delgado, 2017]
					SaveSimulaion_query = "INSERT INTO Refraction(UserID , SavedName, IncidentAngle, RefractedAngle, RefractiveIndex1, RefractiveIndex2, CriticalAngle, DateSaved) VALUES('" + UserID + "', '" + name + "', '" + Refraction_Simulation.InputBoxAngle.Value + "', '" + Refraction_Simulation.RefAngle.Text + "', '" + Refraction_Simulation.n1Box.Value + "', '" + Refraction_Simulation.n2Box.Value + "', '" + Refraction_Simulation.CriticalAngle_Label.Text + "', '" + DateSaved + "')";
				}

				//This prepares the connection to the database [Delgado, 2017]
				MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //This creates a new connection to the MySql database (using the connectionString) called databaseConnection
				MySqlCommand SaveSimulaion = new MySqlCommand(SaveSimulaion_query, databaseConnection);     //This stores the MySql query SaveSimulaion_query as a new command that can be executed by Sql called SaveSimulaion
				MySqlDataReader reader;     //The result of the query will be stored in the MySQLReader called reader

				//Opens the connection to the database [Delgado, 2017]
				databaseConnection.Open();

				//This executes the query explained above [Delgado, 2017]
				reader = SaveSimulaion.ExecuteReader();

				//Closes the connection to the database [Delgado, 2017]
				databaseConnection.Close();

				//This tells the user that the simulation has been saved
				MessageBox.Show("Saved " + name);
			}
		}

		//This function opens the simulation selected by the user
		private void Open()
		{
			//this stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=PhysicsSimulator;";

			//This string will be used to hold the query of the type of simulation that will be opened
			string OpenSimulaion_query;

			//This selects the correct query for the type of simualtion that is being opened
			if (Type == "Wave")
			{
				//This creates a query that updates the data in database table Wave [Delgado, 2017]
				OpenSimulaion_query = "SELECT Amplitude, Wavelength, WaveSpeed, Frequency, Period FROM Wave WHERE SavedName = '" + name + "' AND UserID = '" + UserID + "'";
			}
			else if (Type == "Reflection")
			{
				//This creates a query that updates the data in database table Reflection [Delgado, 2017]
				OpenSimulaion_query = "SELECT Angle FROM Reflection WHERE SavedName = '" + name + "' AND UserID = '" + UserID + "'";
			}
			else
			{
				//This creates a query that updates the data in database table Refraction [Delgado, 2017]
				OpenSimulaion_query = "SELECT IncidentAngle, RefractedAngle, RefractiveIndex1, RefractiveIndex2, CriticalAngle FROM Refraction WHERE SavedName = '" + name + "' AND UserID = '" + UserID + "'";
			}

			//This prepares the connection to the database [Delgado, 2017]
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //This creates a new connection to the MySql database (using the connectionString) called databaseConnection
			MySqlCommand OpenSimulaion = new MySqlCommand(OpenSimulaion_query, databaseConnection);     //This stores the MySql query OpenSimulaion_query as a new command that can be executed by Sql called OpenSimulaion
			MySqlDataReader reader;     //The result of the query will be stored in the MySQLReader called reader

			//This determines what type of simulation is to be opened
			if (Type == "Wave")
			{
				//This calls the function Wave that creates the wave
				Wave();

				//Opens the connection to the database [Delgado, 2017]
				databaseConnection.Open();

				//This executes the query explained above [Delgado, 2017]
				reader = OpenSimulaion.ExecuteReader();

				//This reads the result of the query sent from the database [Delgado, 2017]
				reader.Read();

				//These set the properties of the Wave equal to the values stored on the database
				Wave_Simulation.Name = name;
				Wave_Simulation.AmplitudeBox.Value = reader.GetDecimal(0);
				Wave_Simulation.WavelengthBox.Value = reader.GetInt32(1);
				Wave_Simulation.WaveSpeedBox.Value = reader.GetDecimal(2);
				Wave_Simulation.FrequencyBox.Value = reader.GetDecimal(3);
				Wave_Simulation.PeriodBox.Value = reader.GetDecimal(4);
			}
			else if (Type == "Reflection")
			{
				//This calls the function Reflection
				Reflection();

				//Opens the connection to the database [Delgado, 2017]
				databaseConnection.Open();

				//This executes the query explained above [Delgado, 2017]
				reader = OpenSimulaion.ExecuteReader();

				//This reads the result of the query sent from the database [Delgado, 2017]
				reader.Read();

				//These set the properties of the Reflection equal to the values stored on the database
				Reflection_Simulation.Name = name;
				Reflection_Simulation.InputBoxAngle.Value = reader.GetDecimal(0);
				Reflection_Simulation.IncidentAngle.Text = reader.GetString(0);
				Reflection_Simulation.RefAngle.Text = reader.GetString(0);
			}
			else if (Type == "Refraction")
			{
				//This calls the function Refraction
				Refraction();

				//Opens the connection to the database [Delgado, 2017]
				databaseConnection.Open();

				//This executes the query explained above [Delgado, 2017]
				reader = OpenSimulaion.ExecuteReader();

				//This reads the result of the query sent from the database [Delgado, 2017]
				reader.Read();

				//These set the properties of the Refraction equal to the values stored on the database
				Refraction_Simulation.Name = name;
				Refraction_Simulation.InputBoxAngle.Value = reader.GetDecimal(0);
				Refraction_Simulation.IncidentAngle.Text = reader.GetString(0);
				Refraction_Simulation.RefAngle.Text = reader.GetString(1);
				Refraction_Simulation.n1Box.Value = reader.GetDecimal(2);
				Refraction_Simulation.n2Box.Value = reader.GetDecimal(3);
				Refraction_Simulation.CriticalAngle_Label.Text = reader.GetString(4);
			}

			//Closes the connection to the database [Delgado, 2017]
			databaseConnection.Close();
		}

		//When the Home button on the menu is clicked it takes the user back to HomePage form
		private void Menu_Home_Click(object sender, EventArgs e)
		{
			//This askes the user if they would like to exit the simulation without saving, with the opitions yes, no or cancel
			DialogResult dialog = MessageBox.Show("Do you want to exit the simulation without saving?", "Exit", MessageBoxButtons.YesNoCancel);

			//This checks which button the user pressed and then applies the correct procedure assossiated with it
			if (dialog == DialogResult.Yes)     //If the uses presses the yes button the current simulation is not saved and the user is taken to the form HomePage
			{
				//This calls the method HomePage from the class SwitchForm (passing string username), which closes this form and displays HomePage form
				switchForm.HomePage(Menu_Username.Text, UserID);
			}
			else if (dialog == DialogResult.No)     //If the uses presses the no button the current simulation is saved and the user is taken to the form HomePage
			{
				//This saves the current simualtion for the user
				Save();

				//This tells the user that the simulation has been saved
				MessageBox.Show("Saved");

				//This calls the method HomePage from the class SwitchForm (passing string username), which closes this form and displays HomePage form
				switchForm.HomePage(Menu_Username.Text, UserID);
			}
		}

		private void Menu_File_New_Wave_Click(object sender, EventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Do you want to exit and open a new simulation without saving?", "New", MessageBoxButtons.YesNoCancel);

			if (dialog == DialogResult.Cancel) { }
			else if (dialog == DialogResult.No)
			{
				//This calls the function Save that saves the simulation
				Save();
			}

			string Type = "Wave";
			string name = "New Wave";

			//This tells the program the the simulation to be displayed is a new simualtion
			bool New = true;

			//This calls the method SimulationForm from the class SwitchForm, which closes this form and displays SimulationForm form
			switchForm.SimulationForm(name, Type, username, UserID, New);
		}

		private void Menu_File_New_Reflection_Click(object sender, EventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Do you want to exit and open a new simulation without saving?", "New", MessageBoxButtons.YesNoCancel);

			if (dialog == DialogResult.Cancel) { }
			else if (dialog == DialogResult.No)
			{
				//This calls the function Save that saves the simulation
				Save();
			}

			string Type = "Reflection";
			string name = "New Reflection";

			//This tells the program the the simulation to be displayed is a new simualtion
			bool New = true;

			//This calls the method SimulationForm from the class SwitchForm, which closes this form and displays SimulationForm form
			switchForm.SimulationForm(name, Type, username, UserID, New);
		}

		private void Menu_File_New_Refraction_Click(object sender, EventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Do you want to exit and open a new simulation without saving?", "New", MessageBoxButtons.YesNoCancel);

			if (dialog == DialogResult.Cancel) { }
			else if (dialog == DialogResult.No)
			{
				//This calls the function Save that saves the simulation
				Save();
			}

			string Type = "Refraction";
			string name = "New Refraction";

			//This tells the program the the simulation to be displayed is a new simualtion
			bool New = true;

			//This calls the method SimulationForm from the class SwitchForm, which closes this form and displays SimulationForm form
			switchForm.SimulationForm(name, Type, username, UserID, New);
		}

		private void Menu_File_Open_Click(object sender, EventArgs e)
		{
			//This calls the function SignUp from SwitchForm class, which displays Open form
			switchForm.Open(username, UserID);
		}

		//When the save button is pressed, it calls the function Save that saves the simulation
		private void Menu_File_Save_Click(object sender, EventArgs e)
		{
			Save();
		}

		//When the save button is pressed, it calls the function SaveAs that saves the simulation with a new name ented by the user
		private void Menu_File_SaveAs_Click(object sender, EventArgs e)
		{
			SaveAs();
		}

		private void SimulationForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Do you want to exit the simulation without saving?", "Exit", MessageBoxButtons.YesNoCancel);

			if (dialog == DialogResult.Cancel)
			{
				return;
			}
			else if (dialog == DialogResult.No)
			{
				//This calls the function Save that saves the simulation
				Save();
			}

			//This calls the method HomePage from the class SwitchForm, which closes this form and displays HomePage form
			switchForm.HomePage(username, UserID);
		}
	}
}
/*
References - these are references for parts of code that I have copied. I copied them because I need them to make my program work but where not part the main focus of my project
	Delgado, 19/4/2017 - How to connect to MySQL with C# Winforms and XAMPP - Our Code World
		Available at: https://ourcodeworld.com/articles/read/218/how-to-connect-to-mysql-with-c-sharp-winforms-and-xampp
*/