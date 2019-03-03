using System;
//This is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;

namespace Upload_date_and_time_to_MySQL
{
	class Program
	{
		static void Main(string[] args)
		{
			//Displays the following text in the console
			Console.Write("Press Enter to Upload the Current Date and Time to the Database");
			Console.ReadLine();

			//this stores the current time which is when the user presses enter
			DateTime date_time = DateTime.Now;

			//Displays the current date and time to the user
			Console.Write("The current date and time is: " + date_time);
			Console.ReadLine();

			//this uses the DateTime structure (date_time) and puts it in a form that can be understood by MySQL [abatishchev, 2013]
			string SignUpDate = date_time.ToString("yyyy-MM-dd HH:mm:ss");

			//Displays the current date and time in the format for MySql to the user
			Console.Write("The current date and time in MySql format: " + SignUpDate);
			Console.ReadLine();

			//This string variable stores the SQL query that will upload the entered first and last name to the database table [Delgado, 2017]
			string query = "INSERT INTO DateTime_Test VALUES ('" + SignUpDate + "');";

			//This stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=prototype;";

			//This prepares the connection to the database [Delgado, 2017]
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //this creates a new connection to the MySql database (using the connectionString) called databaseConnection
			MySqlCommand Command = new MySqlCommand(query, databaseConnection);       //this stores the MySql query query as a new command that can be executed by Sql called Command
			Command.CommandTimeout = 60;      //this is how long in seconds the query will attempt to run before stopping and generating an error
			MySqlDataReader reader;     //the result of the query will be stored in the MySQLReader called reader

			//Opens the connection to the database [Delgado, 2017]
			databaseConnection.Open();

			//This executes the query explained above [Delgado, 2017]
			reader = Command.ExecuteReader();

			//Closes the connection to the database [Delgado, 2017]
			databaseConnection.Close();

			//This displays to the user the program has uploaded the current date and time to the database
			Console.WriteLine("Date And Time uploaded");
			Console.ReadKey();
		}
	}
}
/*
References - these are references for parts of code that I have copied. I copied them because I need them to make my program work but where not part the main focus of my project
	abatishchev, 2013. Convert DateTime for MySQL using C# - Stack Overflow
		Available at: https://stackoverflow.com/a/3633356
*/
