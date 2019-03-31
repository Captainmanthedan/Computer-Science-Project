using System;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;

namespace Physics_Simulator
{
	public partial class SaveAs : Form
	{
		public SaveAs(SimulationForm Active_SimulationForm, string Passed_Type, int Passed_UserID)
		{
			InitializeComponent();

			SimulationForm = Active_SimulationForm;

			//This sets the maximum size of the textbox
			Name_Box.MaxLength = 30;
			
			Type = Passed_Type;

			UserID = Passed_UserID;

			Name_Label.Text = "Enter the name you would like to save the " + Type + " as:";
		}

		SimulationForm SimulationForm;

		//This stores the Type of simualtion as a private variable so it can be used when saving a simualtion
		private string Type;

		//This stores the users user ID that is used when saving a simualtion
		private int UserID;

		private void SaveButton_Click(object sender, EventArgs e)
		{

			SimulationForm.name = Name_Box.Text;

			Close();

			
			//This stores the defult name given to each new simualtion
			string DefaultName = "new " + Type + "";

			string name = Name_Box.Text;

			//
			if (name == DefaultName)
			{

				MessageBox.Show("Invalid name, please enter another name");
			}
			else
			{
				//this stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
				string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=PhysicsSimulator;";

				//This creates a query that searches for the everything in the simulation database table using the name entered and the UserID [Delgado, 2017]
				string CheckEnteredName_query = "SELECT * FROM " + Type + " WHERE SavedName = '" + name + "' AND UserID = '" + UserID + "';";


				//This prepares the connection to the database [Delgado, 2017]
				MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //This creates a new connection to the MySql database (using the connectionString) called databaseConnection
				MySqlCommand CheckEnteredName = new MySqlCommand(CheckEnteredName_query, databaseConnection);       //This stores the MySql query CheckEnteredName_query as a new command that can be executed by Sql called CheckEnteredName
				MySqlDataReader reader;		//The result of the query will be stored in the MySQLReader called reader

				//Opens the connection to the database [Delgado, 2017]
				databaseConnection.Open();

				//This executes the query explained above [Delgado, 2017]
				reader = CheckEnteredName.ExecuteReader();

				//This checks if the query returns a result from the database [Delgado, 2017]
				if (reader.HasRows)     //The following code runs if the query returns result
				{
					//This asks the user if they want to open the selected simualtion, in a pop-up window
					DialogResult dialog = MessageBox.Show("" + name + ", type " + Type + " ,already exists. Do you want to replace it", "Confirm Save As" + Type, MessageBoxButtons.YesNo);

					//The following runs if the user confirms they want to open the selected simualtion
					if (dialog == DialogResult.Yes)
					{
						//Closes the connection to the database [Delgado, 2017]
						databaseConnection.Close();

						//This calls the function wave to update the properties saved under the entered simulation name
						SimulationForm.Save();

						//This hides this form (Open) from the user
						Hide();
					}
				}
				else    //The following runs if the query returns no result [Delgado, 2017]
				{
					//Closes the connection to the database [Delgado, 2017]
					databaseConnection.Close();

					//This hides this form (Open) from the user
					Hide();
				}
			}
		}

		//When the button CancelButton is pressed it closes this form
		private void CancelButton_Click(object sender, EventArgs e)
		{
			//This stops the simualtion being saved when the user presses cancel
			SimulationForm.Save_Cancel = true;

			//This hides this form (Open) from the user
			Hide();
		}

		//This stops the simualtion being saved when the user closes the form
		private void SaveAs_FormClosing(object sender, FormClosingEventArgs e)
		{
			//SimulationForm.Save_Cancel = true;
		}
	}
}
/*
References - these are references for parts of code that I have copied. I copied them because I need them to make my program work but where not part the main focus of my project
	Delgado, 19/4/2017 - How to connect to MySQL with C# Winforms and XAMPP - Our Code World
		Available at: https://ourcodeworld.com/articles/read/218/how-to-connect-to-mysql-with-c-sharp-winforms-and-xampp
*/