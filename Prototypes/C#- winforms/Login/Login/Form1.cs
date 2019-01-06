using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Login
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void LoginButton_Click(object sender, EventArgs e)
		{
			string username = UsernameBox.Text;
			string pass = PassBox.Text;

			string Hash_pass = PasswordHash(pass);

			//connection to database
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";

			//Searches for username and password in login database table using username entered
			string Login_query = "SELECT (Password) FROM LOGIN_TEST_SECURE WHERE Username = '" + username + "'";


			// Prepare the connection
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(Login_query, databaseConnection);
			commandDatabase.CommandTimeout = 60;
			MySqlDataReader reader;

			// Open the database
			databaseConnection.Open();

			// Execute the query
			reader = commandDatabase.ExecuteReader();

			//this checks if the username entered exists
			if (reader.HasRows)
			{
				reader.Read();

				//sets the password stored in the database table to a string variable
				string checkPass = (string)reader[0];

				//checks if the password stored matches the password entered
				if (Hash_pass == checkPass)
				{
					//this tells the user they have successfully signed in, in a pop up window
					MessageBox.Show("You have signed into your account");
				}
				else
				{
					//this tells the user the information they have entered is wrong, in a pop up window
					MessageBox.Show("Your username or password is inncorrect");
				}
			}
			else
			{
				//this tells the user the information they have entered is wrong, in a pop up window
				MessageBox.Show("Your username or password is inncorrect");
			}

			// Close the database
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
			using (var sha1 = SHA1.Create())
			{
				hash = sha1.ComputeHash(passBytes);
				hash = sha1.ComputeHash(hash);
			}

			var sb = new StringBuilder();
			sb.Append("*");
			for (int i = 0; i < hash.Length; i++)
				sb.AppendFormat("{0:X2}", hash[i]);

			return sb.ToString();
		}
	}
}
