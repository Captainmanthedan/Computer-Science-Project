using System;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;

namespace Physics_Simulator
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();

			//This calls the function SetUp
			SetUp();
		}

		//This sets the length of maximum character length of the textbox as well as hiding what is entered in the PassBox and ConfirmPassBox
		private void SetUp()
		{
			//This sets the maximum size of the textboxes
			UsernameBox.MaxLength = 50;
			PassBox.MaxLength = 50;

			//This makes text typed in PassBox appear as dots
			PassBox.UseSystemPasswordChar = true;
		}

		//This creates an instance of the class SwitchForm, that allows the user to change between forms
		private SwitchForm switchForm = new SwitchForm();

		//When the user clicks on the login button the following function checks if the username exists and if the entered password is correct. If true the user will be signed in
		private void LoginButton_Click(object sender, EventArgs e)
		{
			//These store the username and password entered by the user into the text boxes, and stores them as variables
			string username = UsernameBox.Text;
			string pass = PassBox.Text;

			/*This calls a function that hashes the entered password
			this is so that it can be used later to see if the entered password matches the hashed verson stored on the database.
			It then stores it as a string variable [gsuberland, 2017] */
			Hashing hashing = new Hashing();
			string Hash_pass = hashing.PasswordHash(pass);

			//This stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=PhysicsSimulator;";

			//This creates a query that searches for the username in login database table using username entered, and then selects the password and user id relating to that username [Delgado, 2017]
			string Login_query = "SELECT Password, UserID FROM Account WHERE Username = '" + username + "'";


			//This prepares the connection to the database [Delgado, 2017]
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //This creates a new connection to the MySql database (using the connectionString) called databaseConnection
			MySqlCommand Login_Command = new MySqlCommand(Login_query, databaseConnection);     //This stores the MySql query Login_query as a new command that can be executed by Sql called Login_Command
			MySqlDataReader reader;     //The result of the query will be stored in the MySQLReader called reader

			//Opens the connection to the database [Delgado, 2017]
			databaseConnection.Open();

			//This executes the query explained above [Delgado, 2017]
			reader = Login_Command.ExecuteReader();

			//This checks if the query returns a result from the database (i.e. it checks if the username entered exists, and there is a password stored in the same column) [Delgado, 2017]
			if (reader.HasRows)     //The following code runs if the query returns result (i.e. the username exists)
			{
				//This reads the result of the query sent from the database [Delgado, 2017]
				reader.Read();

				//Sets the password stored in the database table to a string variable [Delgado, 2017]
				string checkPass = reader.GetString(0);     //This stores the first piece of data recieved from the query (in this case password)

				//This compares the hashed version of password entered by the user, with the password received from the database
				if (Hash_pass == checkPass)
				{
					//If the password entered matches the password stored on the database, this tells the user they have successfully signed in, in a pop up window
					MessageBox.Show("You have signed into your account");

					//Sets the user id stored in the database table to an integer variable [Delgado, 2017]
					int UserID = reader.GetInt32(1);

					//This calls the method HomePage from the class SwitchForm (passing string username and integer UserID), which closes this form and displays HomePage form
					switchForm.HomePage(username, UserID);
				}
				else    //The following code happens if the password entered does not match the stored password
				{
					//This displays to the user the information they have entered is wrong, in a pop up window
					MessageBox.Show("Your username or password is inncorrect");
				}
			}
			else    //The following runs if the query returns no result (i.e. username does not exist) [Delgado, 2017]
			{
				//This tells the user the information they have entered is wrong, in a pop up window
				MessageBox.Show("Your username or password is inncorrect");
			}

			//Closes the connection to the database [Delgado, 2017]
			databaseConnection.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			//This calls the method StartScreen from the class SwitchForm, which closes this form and displays StartScreen form
			switchForm.StartScreen();
		}

		private void Login_FormClosing(object sender, FormClosingEventArgs e)
		{
			//This calls the method StartScreen from the class SwitchForm, which closes this form and displays StartScreen form
			switchForm.StartScreen();
		}
	}
}
/*
References - these are references for parts of code that I have copied. I copied them because I need them to make my program work but where not part the main focus of my project
	Delgado, 19/4/2017 - How to connect to MySQL with C# Winforms and XAMPP - Our Code World
		Available at: https://ourcodeworld.com/articles/read/218/how-to-connect-to-mysql-with-c-sharp-winforms-and-xampp
*/
