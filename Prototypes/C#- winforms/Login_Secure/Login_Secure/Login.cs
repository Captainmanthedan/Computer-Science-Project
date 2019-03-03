using System;
using System.Text;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;
//this allows crytographic services, that enablesthe hashing of the entered password [gsuberland, 2017]
using System.Security.Cryptography;

namespace Login_Secure
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}

		//When the user clicks on the login button the following function checks if the username exists and if the entered password is correct. If true the user will be signed in
		private void LoginButton_Click(object sender, EventArgs e)
		{
			//These store the username and password entered by the user into the text boxes, and stores them as variables
			string username = UsernameBox.Text;
			string pass = PassBox.Text;

			/*this calls a function that hashes the entered password
			This is so that it can be used later to see if the entered password matches the hashed verson stored on the database.
			It then stores it as a string variable [gsuberland, 2017] */
			string Hash_pass = PasswordHash(pass);

			//this stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";

			//This creates a query that searches for the username in login database table using username entered, and then selects the password relating to that username [Delgado, 2017]
			string Login_query = "SELECT (Password) FROM LOGIN_TEST_SECURE WHERE Username = '" + username + "'";


			// This prepares the connection to the database [Delgado, 2017]
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //this creates a new connection to the MySql database (using the connectionString) called databaseConnection
			MySqlCommand Login_Command = new MySqlCommand(Login_query, databaseConnection);     //this stores the MySql query Login_query as a new command that can be executed by Sql called Login_Command
			Login_Command.CommandTimeout = 60;		//this is how long in seconds the query will attempt to run before stopping and generating an error
			MySqlDataReader reader;     //the result of the query will be stored in the MySQLReader called reader

			// Opens the connection to the database [Delgado, 2017]
			databaseConnection.Open();

			// This executes the query explained above [Delgado, 2017]
			reader = Login_Command.ExecuteReader();

			//this checks if the query returns a result from the database (i.e. it checks if the username entered exists, and there is a password stored in the same column) [Delgado, 2017]
			if (reader.HasRows)     // the following code runs if the query returns result (i.e. the username exists)
			{
				// this reads the result of the query sent from the database [Delgado, 2017]
				reader.Read();

				//sets the password stored in the database table to a string variable [Delgado, 2017]
				string checkPass = (string)reader[0];	//this stores the first piece of data recieved from the query (in this case the only data, password)

				//this compares the hashed version of password entered by the user, with the password received from the database
				if (Hash_pass == checkPass)
				{
					//If the password entered matches the password stored on the database, this tells the user they have successfully signed in, in a pop up window
					MessageBox.Show("You have signed into your account");
				}
				else    //the preceding code happens if the password entered does not match the stored password
				{
					//this tells the user the information they have entered is wrong, in a pop up window
					MessageBox.Show("Your username or password is inncorrect");
				}
			}
			else    // the following runs if the query returns no result (i.e. username does not exist) [Delgado, 2017]
			{
				//this tells the user the information they have entered is wrong, in a pop up window
				MessageBox.Show("Your username or password is inncorrect");
			}

			// Closes the connection to the database [Delgado, 2017]
			databaseConnection.Close();
		}


		//This runs first when the PasswordHash functions is first called, it sends the entered password and the encoding to be used to hash the password to the second PasswordHash function [gsuberland, 2017]
		string PasswordHash(string password)
		{
			//Sends the password and the encoding that will be used to the other PasswordHash function below
			return PasswordHash(password, Encoding.UTF8);	//UTF8 can encode all Unicode characters
		}

		//This function hashes the entered password using the encoding sent from the function above [gsuberland, 2017]
		string PasswordHash(string password, Encoding textEncoding)
		{
			//Below the byte arrays passBytes aand hash are defined, with passBytes set as the encoded password
			byte[] passBytes = textEncoding.GetBytes(password);		//passBytes stores all the encoded characters in password, using UTF8, into a sequence of bytes
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

*/
