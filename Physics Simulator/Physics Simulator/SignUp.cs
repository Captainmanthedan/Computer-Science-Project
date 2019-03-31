using System;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;

namespace Physics_Simulator
{
	public partial class SignUp : Form
	{
		public SignUp()
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
			FirstNameBox.MaxLength = 50;
			LastNameBox.MaxLength = 50;
			PassBox.MaxLength = 50;
			ConfirmPassBox.MaxLength = 50;

			//This makes text typed in PassBox and ConfirmPassBox appear as dots
			PassBox.UseSystemPasswordChar = true;
			ConfirmPassBox.UseSystemPasswordChar = true;
		}

		//This creates an instance of the class SwitchForm, that allows the user to change between forms
		private SwitchForm switchForm = new SwitchForm();

		//When the user clicks on the Register button the following function checks if the username exists, and if it does not the users account is created.
		private void RegisterButton_Click(object sender, EventArgs e)
		{
			//These variables store the values entered in the boxes, stored as strings
			string username = UsernameBox.Text;
			string FirstName = FirstNameBox.Text;
			string LastName = LastNameBox.Text;
			string pass = PassBox.Text;
			string confirmPass = ConfirmPassBox.Text;

			//This checks if both the entered passwords match
			if (pass != confirmPass)	//This runs if the passwords don't match
			{
				//These displays to the user that the passwords do not match
				MessageBox.Show("Passwords do not match");
			}
			else if (pass == confirmPass)  //This runs if the passwords do match
			{
				/*This calls a function that hashes the entered password and then stores it as a string variable
				this is so that it can be used later to be securely stored as a hashed verson stored on the database. [gsuberland, 2017] */
				Hashing hashing = new Hashing();
				string Hash_pass = hashing.PasswordHash(pass);

				//this stores the current time which is when the user clicked the Register button
				DateTime date_time = DateTime.Now;

				//this uses the DateTime structure (date_time) and puts it in a form that can be understood by MySQL [abatishchev, 2013]
				string SignUpDate = date_time.ToString("yyyy-MM-dd HH:mm:ss");

				//This creates a query that searches for the username in login database table using username entered, to see if the username entered already exists [Delgado, 2017]
				string UsernameCheck_query = "SELECT * FROM Account WHERE USERNAME = '" + username + "'";
				//This string variable stores the SQL query that will upload the users entered details to the database table [Delgado, 2017]
				string SignUp_query = "INSERT INTO Account (Username, Firstname, Lastname, Password, SignUpDate) VALUES('" + username + "', '" + FirstName + "', '" + LastName + "', '" + Hash_pass + "', '" + SignUpDate + "')";

				//This stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
				string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=PhysicsSimulator;";

				//This prepares the connection to the database [Delgado, 2017]
				MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //This creates a new connection to the MySql database (using the connectionString) called databaseConnection
				MySqlCommand UsernameCheck_Command = new MySqlCommand(UsernameCheck_query, databaseConnection);     //This stores the MySql query UsernameCheck_query as a new command that can be executed by Sql called UsernameCheck_Command
				MySqlCommand SignUp_Command = new MySqlCommand(SignUp_query, databaseConnection);       //This stores the MySql query SignUp_query as a new command that can be executed by Sql called SignUp_Command
				MySqlDataReader reader;     //The result of the query will be stored in the MySQLReader called reader

				//Opens the connection to the database [Delgado, 2017]
				databaseConnection.Open();

				//This executes the query UsernameCheck_query explained above [Delgado, 2017]
				reader = UsernameCheck_Command.ExecuteReader();

				//This checks if the entered username already exists, if it is not anccount is created using the SignUp query
				if (reader.HasRows)     //The following code runs if the query returns result (i.e. the username exists)
				{
					//Closes the connection to the database [Delgado, 2017]
					databaseConnection.Close();

					//This tells the user the usernamed entered is alreay registered to annacount on the database, in a pop up window
					MessageBox.Show("Username entered already exists");
				}
				else
				{
					//This closes the reader so that it can be used to run another query
					reader.Close();

					//This executes the query SignUp_query explained above [Delgado, 2017]
					reader = SignUp_Command.ExecuteReader();

					//Closes the connection to the database [Delgado, 2017]
					databaseConnection.Close();

					//This tells the user the user that they have created an account, in a pop up window
					MessageBox.Show("You have created an account successfully");

					//This calls the method StartScreen from the class SwitchForm, which closes this form and displays StartScreen form
					switchForm.StartScreen();
				}
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			//This calls the method StartScreen from the class SwitchForm, which closes this form and displays StartScreen form
			switchForm.StartScreen();
		}

		private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
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
	abatishchev, 2013. Convert DateTime for MySQL using C# - Stack Overflow
		Available at: https://stackoverflow.com/a/3633356
*/

