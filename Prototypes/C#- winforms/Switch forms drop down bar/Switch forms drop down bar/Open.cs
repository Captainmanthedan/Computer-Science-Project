using System;
//this allows the creation of a queue
using System.Collections;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;

namespace Switch_forms_drop_down_bar
{
	public partial class Open : Form
	{
		public Open()
		{
			InitializeComponent();

			FileExplorer();
		}

		public void FileExplorer()
		{
			int Number_of_Columns = 3;

			Explorer.AutoGenerateColumns = false;
			Explorer.ColumnCount = Number_of_Columns;
			Explorer.Columns[0].Name = "Name";
			Explorer.Columns[1].Name = "Type";
			Explorer.Columns[2].Name = "Date Saved";

			string Name;
			string Type;
			DateTime DateSaved;

			string PreviousName = "";

			int i = 0;

			//defult value is set to one as indexing always starts at zero and this will be used later
			int Number_of_Rows = 0;

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

			// This executes the query Select_Wave_query explained above [Delgado, 2017]
			reader = Select_Wave.ExecuteReader();

			//this tells the user that the simulation is a wave
			Type = "Wave";

			while (reader.HasRows)
			{
				reader.Read();

				Name = (string)reader[0];
				DateSaved = (DateTime)reader[1];

				if (Name == PreviousName)
				{
					//
					reader.Close();

					//
					Number_of_Rows += i;

					//this sets the value of PreviousName to NULL and i to zero so they can be used again below
					PreviousName = "";
					i = 0;

					//this forces that while to stop running and to be exited
					break;
				}

				TableValues.Enqueue(Name);
				TableValues.Enqueue(Type);
				TableValues.Enqueue(DateSaved);

				PreviousName = Name;
				i++;
			}

			// This executes the query Select_Reflection_query explained above [Delgado, 2017]
			reader = Select_Reflection.ExecuteReader();

			//this tells the user that the simulation is a reflection
			Type = "Reflection";

			while (reader.HasRows)
			{
				reader.Read();

				Name = (string)reader[0];
				DateSaved = (DateTime)reader[1];

				if (Name == PreviousName)
				{
					//
					reader.Close();

					//
					Number_of_Rows += i;

					//this sets the value of PreviousName to NULL and i to zero so they can be used again below
					PreviousName = "";
					i = 0;

					//this forces that while to stop running and to be exited
					break;
				}
				TableValues.Enqueue(Name);
				TableValues.Enqueue(Type);
				TableValues.Enqueue(DateSaved);

				PreviousName = Name;
				i++;
			}

			// This executes the query Select_Refraction_query explained above [Delgado, 2017]
			reader = Select_Refraction.ExecuteReader();

			//this tells the user that the simulation is a refraction
			Type = "Refraction";

			while (reader.HasRows)
			{
				reader.Read();

				Name = (string)reader[0];
				DateSaved = (DateTime)reader[1];

				if (Name == PreviousName)
				{
					//
					reader.Close();

					//
					Number_of_Rows += i;

					//this forces that while to stop running and to be exited
					break;
				}

				TableValues.Enqueue(Name);
				TableValues.Enqueue(Type);
				TableValues.Enqueue(DateSaved);

				PreviousName = Name;
				i++;
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

			Explorer.AllowUserToAddRows = false; //removes last(Extra) row

			Explorer.MultiSelect = false; //this means the user can only highlight one row at a time

			Explorer.SelectionMode = DataGridViewSelectionMode.FullRowSelect; //this means that the user can only select a whole row

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
			this.Hide();
		}
	}
}
