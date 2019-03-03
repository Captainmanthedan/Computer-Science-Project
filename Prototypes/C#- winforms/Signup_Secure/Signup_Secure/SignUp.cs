using System;
using System.Text;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;
//this allows crytographic services, that enablesthe hashing of the entered password [gsuberland, 2017]
using System.Security.Cryptography;

namespace Signup_Secure
{
	public partial class SignUp : Form
	{
		public SignUp()
		{
			InitializeComponent();
		}

		//When the user clicks on the Register button the following function checks if the username exists, and if it does not the users account is created.
		private void Register_Click(object sender, EventArgs e)
		{
			//These variables store the values entered in the boxes, stored as strings
			string username = UsernameBox.Text;
			string FirstName = FirstNameBox.Text;
			string LastName = LastNameBox.Text;
			string pass = PassBox.Text;

			/*this calls a function that hashes the entered password and then stores it as a string variable
			This is so that it can be used later to be securely stored as a hashed verson stored on the database. [gsuberland, 2017] */
			string Hash_pass = PasswordHash(pass);

			//this stores the current time which is when the user clicked the Register button
			DateTime date_time = DateTime.Now;

			//this uses the DateTime variable (date_time) and puts it in a form that can be understood by MySQL [abatishchev, 2013]
			string SignUpDate = date_time.ToString("yyyy-MM-dd HH:mm:ss");

			//This creates a query that searches for the username in login database table using username entered, to see if the username entered already exists [Delgado, 2017]
			string UsernameCheck_query = "SELECT * FROM LOGIN_TEST_SECURE WHERE USERNAME = '" + username + "'";
			//This string variable stores the SQL query that will upload the users entered details to the database table [Delgado, 2017]
			string SignUp_query = "INSERT INTO LOGIN_TEST_SECURE (Username, Firstname, Lastname, Password, SignUpDate) VALUES('" + username + "', '" + FirstName + "', '" + LastName + "', '" + Hash_pass + "', '" + SignUpDate + "')";

			//this stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";

			// This prepares the connection to the database [Delgado, 2017]
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //this creates a new connection to the MySql database (using the connectionString) called databaseConnection
			MySqlCommand UsernameCheck_Command = new MySqlCommand(UsernameCheck_query, databaseConnection);     //this stores the MySql query UsernameCheck_query as a new command that can be executed by Sql called UsernameCheck_Command
			MySqlCommand SignUp_Command = new MySqlCommand(SignUp_query, databaseConnection);       //this stores the MySql query SignUp_query as a new command that can be executed by Sql called SignUp_Command
			UsernameCheck_Command.CommandTimeout = 60;      //this is how long in seconds the query will attempt to run before stopping and generating an error
			SignUp_Command.CommandTimeout = 60;
			MySqlDataReader reader;     //the result of the query will be stored in the MySQLReader called reader

			// Opens the connection to the database [Delgado, 2017]
			databaseConnection.Open();

			// This executes the query UsernameCheck_query explained above [Delgado, 2017]
			reader = UsernameCheck_Command.ExecuteReader();

			//this checks if the entered username already exists, if it is not anccount is created using the SignUp query
			if (reader.HasRows)     // the following code runs if the query returns result (i.e. the username exists)
			{
				// Closes the connection to the database [Delgado, 2017]
				databaseConnection.Close();

				//this tells the user the usernamed entered is alreay registered to annacount on the database, in a pop up window
				MessageBox.Show("Username entered already exists");
			}
			else
			{
				//this closes the reader so that we can use it to run another query
				reader.Close();

				// This executes the query SignUp_query explained above [Delgado, 2017]
				reader = SignUp_Command.ExecuteReader();

				// Closes the connection to the database [Delgado, 2017]
				databaseConnection.Close();

				//this tells the user the user that they have created an account, in a pop up window
				MessageBox.Show("You have created an account successfully");
			}
		}

		//This runs first when the PasswordHash functions is first called, it sends the entered password and the encoding to be used to hash the password to the second PasswordHash function [gsuberland, 2017]
		string PasswordHash(string password)
		{
			//Sends the password and the encoding that will be used to the other PasswordHash function below
			return PasswordHash(password, Encoding.UTF8);   //UTF8 can encode all Unicode characters
		}

		//This function hashes the entered password using the encoding sent from the function above [gsuberland, 2017]
		string PasswordHash(string password, Encoding textEncoding)
		{
			//Below the byte arrays passBytes aand hash are defined, with passBytes set as the encoded password
			byte[] passBytes = textEncoding.GetBytes(password);     //passBytes stores all the encoded characters in password, using UTF8, into a sequence of bytes
			byte[] hash;

			//this was orginally set as var but I changed it to SHA1, as it was being set to equal the method SHA1.Create(), which creates an instance of SHA1
			using (SHA1 sha1 = SHA1.Create())
			{
				//This computes a random hash for byte array passBytes that stores the encoded entered password
				hash = sha1.ComputeHash(passBytes);
				//This computes a second random hash for the hash of the encoded encrypted entered password, so it is securely encrypted
				hash = sha1.ComputeHash(hash);
			}

			/*This creates a new StringBuilder with the name of sb
			(this was set to var but I changed it to StringBuilder, as it was being set to be a new StringBuilder)*/
			StringBuilder sb = new StringBuilder();

			//Append adds what the user wants to add to the end of StringBuilder, in this case it adds * (which because sb is empty is the first item)
			sb.Append("*");

			//this "For" loop runs until the integer i is greater than or equal to the length of the byte array named hash
			for (int i = 0; i < hash.Length; i++)
			{
				//writes first value in the byte array hash (which is just one value i) as hexadecimal on the end of the String Builder called sb, and must be at least 2 digits long
				sb.AppendFormat("{0:X2}", hash[i]);
			}

			//this returns the generated hashed password stored in sb as a string
			return sb.ToString();
		}
	}
}
/*
References - these are references for parts of code that I have copyed. I copyed them because i need them to make my program work but where not part the main focus of my project
	Delgado, 19/4/2017 - How to connect to MySQL with C# Winforms and XAMPP - Our Code World
		Available at: https://ourcodeworld.com/articles/read/218/how-to-connect-to-mysql-with-c-sharp-winforms-and-xampp
	gsuberland, 2017. Any quick way to convert passwords to mysql hashes? : csharp - Reddit.com
		Available at: https://www.reddit.com/r/csharp/comments/5k2kba/any_quick_way_to_convert_passwords_to_mysql_hashes/dbkw3er/
	abatishchev, 2013. Convert DateTime for MySQL using C# - Stack Overflow
		Available at: https://stackoverflow.com/a/3633356
*/

