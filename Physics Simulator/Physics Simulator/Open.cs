using System;
//this allows the creation of a queue
using System.Collections;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;

namespace Physics_Simulator
{
	public partial class Open : Form
	{
		public Open()
		{
			InitializeComponent();

			//This calls the function FileExplorer
			FileExplorer();
		}

		private Tuple<int, Queue> AddRows(MySqlDataReader reader, string Type, int Number_of_Rows, Queue TableValues)
		{
			//This creates a string used to store the Name stored on the database
			string Name;
			string PreviousName = "";

			DateTime DateSaved;

			while (reader.HasRows)
			{
				reader.Read();

				Name = (string)reader[0];
				DateSaved = (DateTime)reader[1];

				if (Name == PreviousName)
				{
					//
					break;
				}

				TableValues.Enqueue(Name);
				TableValues.Enqueue(Type);
				TableValues.Enqueue(DateSaved);

				PreviousName = Name;
				Number_of_Rows++;
			}

			return Tuple.Create(Number_of_Rows, TableValues);
		}

		private void FileExplorer()
		{
			//This sets the DataGridView called Explorer, column properties
			int Number_of_Columns = 3;	//This sets the integer used to store the number of columns to 3
			Explorer.ColumnCount = Number_of_Columns;   //This tells exploer to create the number of columns specifed by the integer Number_of_Columns
			Explorer.Columns[0].Name = "Name";	//This sets the first column header's text to Name
			Explorer.Columns[1].Name = "Type";  //This sets the first column header's text to Type
			Explorer.Columns[2].Name = "Date Saved";    //This sets the first column header's text to Date Saved

			//defult value is set to one as indexing always starts at zero and this will be used later
			int Number_of_Rows = 0;

			//This creates a queue that will store all the value removed from the database
			Queue TableValues = new Queue();


			//This creates a query that searches for all data in wave database table [Delgado, 2017]
			string Select_Wave_query = "SELECT SavedWaveName, DateSaved FROM WAVE_TEST";
			string Select_Reflection_query = "SELECT SavedReflectionName, DateSaved FROM REFLECTION_TEST";
			string Select_Refraction_query = "SELECT SavedRefractionName, DateSaved FROM REFRACTION_TEST";

			//this stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";

			// This prepares the connection to the database [Delgado, 2017]
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //this creates a new connection to the MySql database (using the connectionString) called databaseConnection
			MySqlCommand Select_Wave = new MySqlCommand(Select_Wave_query, databaseConnection);     //this stores the MySql query Select_Wave_query as a new command that can be executed by Sql called Select_Wave
			MySqlCommand Select_Reflection = new MySqlCommand(Select_Reflection_query, databaseConnection);     //this stores the MySql query Select_Reflection_query as a new command that can be executed by Sql called Select_Reflection
			MySqlCommand Select_Refraction = new MySqlCommand(Select_Refraction_query, databaseConnection);     //this stores the MySql query Select_Refraction_query as a new command that can be executed by Sql called Select_Refraction
			Select_Wave.CommandTimeout = 60;      //this is how long in seconds the queries will attempt to run before stopping and generating an error
			Select_Reflection.CommandTimeout = 60;
			Select_Refraction.CommandTimeout = 60;
			MySqlDataReader reader;     //the result of the query will be stored in the MySQLReader called reader

			// Opens the connection to the database [Delgado, 2017]
			databaseConnection.Open();

			for (int i = 1; i <= Number_of_Columns; i++)
			{
				Tuple<int, Queue> returned;
				switch (i)
				{
					case 1:
						//This executes the query Select_Wave_query explained above [Delgado, 2017]
						reader = Select_Wave.ExecuteReader();

						//This tells the user that the simulation is a wave
						Type = "Wave";

						returned = AddRows(reader, Type, Number_of_Rows, TableValues);

						Number_of_Rows = returned.Item1;
						//TableValues = returned.Item2;

						reader.Close();
						break;

					case 2:
						//This executes the query Select_Reflection_query explained above [Delgado, 2017]
						reader = Select_Reflection.ExecuteReader();

						//this tells the user that the simulation is a reflection
						Type = "Reflection";

						returned = AddRows(reader, Type, Number_of_Rows, TableValues);

						Number_of_Rows = returned.Item1;
						//TableValues = returned.Item2;

						reader.Close();
						break;

					case 3:
						//This executes the query Select_Refraction_query explained above [Delgado, 2017]
						reader = Select_Refraction.ExecuteReader();

						//this tells the user that the simulation is a refraction
						Type = "Refraction";

						returned = AddRows(reader, Type, Number_of_Rows, TableValues);

						Number_of_Rows = returned.Item1;
						//TableValues = returned.Item2;

						reader.Close();
						break;
				}
			}

			// Closes the connection to the database [Delgado, 2017]
			databaseConnection.Close();

			if (Number_of_Rows == 0)
			{
				MessageBox.Show("You currently don't have any saved simulations");
			}

			//this sets the number of rows to be displayed in Explorer, which is the number of rows of information added plus one because their is one extra row
			Explorer.RowCount = Number_of_Rows + 1;

			//this adds the data retrieved from the database to different rows on Explorer
			for (int j = 0; j < Number_of_Rows; j++)
			{
				//
				Name = (string)TableValues.Dequeue();
				Type = (string)TableValues.Dequeue();
				DateSaved = (DateTime)TableValues.Dequeue();

				//this changes the saved date and time from a form it has to be to be stored on the MySql database to a form the user read easily
				string Time_and_Date = DateSaved.ToString("HH:mm dd-MM-yyyy");

				//this adds the values to datagridrow1 so they can be seen by the user
				Explorer.Rows[j].Cells[0].Value = Name;
				Explorer.Rows[j].Cells[1].Value = Type;
				Explorer.Rows[j].Cells[2].Value = Time_and_Date;
			}

			//this makes sure all of cells display their data to the user
			for (int j = 0; j < Number_of_Columns; j++)
			{
				Explorer.Columns[j].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}


			Explorer.RowHeadersVisible = false;

			//This removes the last empty extra row
			Explorer.AllowUserToAddRows = false;

			//This means the user can only highlight one row at a time
			Explorer.MultiSelect = false;

			//This makes the user only able to select a full row and not a single cell
			Explorer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			//This tops the user from being able to change any of the values in the DataGridView Explorer
			Explorer.ReadOnly = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int row = Explorer.SelectedRows[0].Index;

			string Name = Convert.ToString(Explorer.Rows[row].Cells[0].Value);

			DialogResult dialog = MessageBox.Show("Do you want to open " + Name + "?", "Open", MessageBoxButtons.YesNo);

			if (dialog == DialogResult.Yes)
			{
				MessageBox.Show("Opening " + Name);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Hide();
		}
	}
}
/*
References - these are references for parts of code that I have copied. I copied them because I need them to make my program work but where not part the main focus of my project
	Delgado, 19/4/2017 - How to connect to MySQL with C# Winforms and XAMPP - Our Code World
		Available at: https://ourcodeworld.com/articles/read/218/how-to-connect-to-mysql-with-c-sharp-winforms-and-xampp

*/
