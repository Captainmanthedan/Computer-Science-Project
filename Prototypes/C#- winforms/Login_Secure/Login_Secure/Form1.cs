using System;
using System.Text;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Login_Secure
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//When the user clicks on the login button the following function checks if the username exists and if the entered password is correct. If true the user will be signed in
		private void LoginButton_Click(object sender, EventArgs e)
		{
			//These store the username and password entered by the user into the text boxes, and stores them as variables
			string username = UsernameBox.Text;
			string pass = PassBox.Text;

			//this hashes the entered password and stores it as a string, so that it can be used latter to see if the entered password matches the hashed verson stored on the datbase
			string Hash_pass = PasswordHash(pass);

			//this stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";

			//This creates a query that searches for the username in login database table using username entered, and then selects the password relating to that username [Delgado, 2017]
			string Login_query = "SELECT (Password) FROM LOGIN_TEST_SECURE WHERE Username = '" + username + "'";


			// This prepares the connection to the database [Delgado, 2017]
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(Login_query, databaseConnection);
			commandDatabase.CommandTimeout = 60;
			MySqlDataReader reader;     //the result of the query will be stored in the MySQLReader named reader

			// Opens the connection to the database [Delgado, 2017]
			databaseConnection.Open();

			// This executes the query explained above [Delgado, 2017]
			reader = commandDatabase.ExecuteReader();

			//this checks if the query returns a result from the database (i.e. it checks if the username entered exists, and there is a password stored in the same column) [Delgado, 2017]
			if (reader.HasRows)     // the following code runs if the query returns result (i.e. the username exists)
			{
				// this reads the result of the query sent from the database [Delgado, 2017]
				reader.Read();

				//sets the password stored in the database table to a string variable [Delgado, 2017]
				string checkPass = (string)reader[0]; //this stores the first piece of data recieved from the query (in this case the only data, the password)

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


		//hashes password
		string PasswordHash(string password)
		{
			return PasswordHash(password, Encoding.UTF8);
		}

		string PasswordHash(string password, Encoding textEncoding)
		{
			byte[] passBytes = textEncoding.GetBytes(password);
			byte[] hash;

			//this was set to var but I changed it to SHA1, as it made no sense as it was being set to create a SHA1
			using (SHA1 sha1 = SHA1.Create())
			{
				hash = sha1.ComputeHash(passBytes);
				hash = sha1.ComputeHash(hash);
			}

			//this was set to var but I changed it to StringBuilder, as it made no sense to be a varabile when it was being set to be a new StringBuilder
			StringBuilder sb = new StringBuilder();
			sb.Append("*");
			for (int i = 0; i < hash.Length; i++)
				sb.AppendFormat("{0:X2}", hash[i]);

			return sb.ToString();
		}
	}
}
/*
References - these are references for parts of code that I have copyed. I copyed them because i need them to make my program work but where not part the main focus of my project
	Delgado, 19/4/2017 - How to connect to MySQL with C# Winforms and XAMPP - Our Code World
*/
