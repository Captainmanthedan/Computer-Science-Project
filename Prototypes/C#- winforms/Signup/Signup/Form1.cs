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

namespace Signup
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//These variables store the values entered in the boxes, stored as strings
			string username = UsernameBox.Text;
			string FirstName = FirstNameBox.Text;
			string LastName = LastNameBox.Text;
			string pass = PassBox.Text;

			//this stores the time when the user clicked register
			var time = DateTime.Now;
			//this uses the time variable and puts it in a form that can be understood by MySQL
			string SignUpDate = time.ToString("yyyy-MM-dd hh:mm:ss");

			//This string variable stores the SQL query that will upload the users entered data to the database table
			string query = "INSERT INTO LOGIN_TEST (Username, Firstname, Lastname, Password, SignUpDate) VALUES('" + username + "', '" + FirstName + "', '" + LastName + "', '" + pass + "', '" + SignUpDate + "')";

			//This string variable stores the location of the MySQl database I want to connect to
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";

			//Prepares the connection to the MySQl database
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);
			MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
			commandDatabase.CommandTimeout = 60;
			MySqlDataReader reader;

			//Opens the connection to the database
			databaseConnection.Open();

			//Executes the SQL query
			reader = commandDatabase.ExecuteReader();

			//Closes the Connection
			databaseConnection.Close();
		}
	}
}
