using System;
//This is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;

namespace Upload__receive_data_from_database
{
	class Program
	{
		static void Main(string[] args)
		{
			//Displays the following text in the console 
			Console.WriteLine("1 - Upload data");
			Console.WriteLine("2 - Retrieve data");
			//This variable stores the users input, as a integer called input
			int input = Convert.ToInt16(Console.ReadLine());

			switch (input)
			{
				case 1:
					Upload();
					break;
				case 2:
					Retrieve();
					break;
			}
		}
		static void Upload()
		{
			//Displays the following text in the console 
			Console.Write("Enter first name: ");
			//This variable stores the users input, as a string called FirstName
			string FirstName = Console.ReadLine();

			//Displays the following text in the console 
			Console.Write("Enter last name: ");
			//This variable stores the users input, as a string called LastName
			string LastName = Console.ReadLine();

			//This string variable stores the SQL query that will upload the entered first and last name to the database table [Delgado, 2017]
			string query = "INSERT INTO Test (FirstName, LastName) VALUES ('" + FirstName + "', '" + LastName + "');";

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

			//This displays to the user the program has uploaded their data to the database
			Console.WriteLine("Data uploaded");
			Console.ReadKey();
		}

		static void Retrieve()
		{
			//Displays the following text in the console 
			Console.Write("Enter last name: ");
			//This variable stores the users input, as a string called LastName
			string LastName = Console.ReadLine();

			//This creates a query that searches for the last name entered in test database table, and then selects the fist name relating to that lastname [Delgado, 2017]
			string query = "SELECT (FirstName) FROM Test WHERE LastName = '" + LastName + "';";

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

			//this checks if the query returns a result from the database (i.e. it checks if the last name entered exists) [Delgado, 2017]
			if (reader.HasRows)     // the following code runs if the query returns result (i.e. the last name exists)
			{
				// this reads the result of the query sent from the database [Delgado, 2017]
				reader.Read();

				//sets the firts name stored in the database table to a string variable [Delgado, 2017]
				string FirstName = (string)reader[0];   //this stores the first piece of data recieved from the query (in this case the only data, first name)

				//Closes the connection to the database [Delgado, 2017]
				databaseConnection.Close();

				//This displays to the user their first name
				Console.WriteLine("First Name is " + FirstName);
				Console.ReadKey();
			}
			else    // the following runs if the query returns no result (i.e. last name does not exist) [Delgado, 2017]
			{
				//Closes the connection to the database [Delgado, 2017]
				databaseConnection.Close();

				//this tells the user the last name does not exist
				Console.WriteLine("The lastname entered does not exist");
				Console.ReadKey();
			}
		}

	}
}
/*
References - these are references for parts of code that I have copied. I copied them because I need them to make my program work but where not part the main focus of my project
	Delgado, 19/4/2017 - How to connect to MySQL with C# Winforms and XAMPP - Our Code World
		Available at: https://ourcodeworld.com/articles/read/218/how-to-connect-to-mysql-with-c-sharp-winforms-and-xampp
*/
