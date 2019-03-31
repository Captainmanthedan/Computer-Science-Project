using System;
//this allows the creation of a queue
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
//this is used to enable the connection to the MySQl database [Delgado, 2017]
using MySql.Data.MySqlClient;

namespace Physics_Simulator
{
	public partial class Open : Form
	{
		public Open(string Passed_username, int Passed_UserID)
		{
			InitializeComponent();

			//This calls the function SetUp
			SetUp(Passed_username, Passed_UserID);
		}

		//This creates an instance of the class SwitchForm, that allows the user to change between forms
		private SwitchForm switchForm = new SwitchForm();

		//This stores the users username as a private variable
		private string username;

		//This stores the users user ID
		private int UserID;

		//This sets the DataGridView called Tables properties, rows and columns
		private void SetUp(string Passed_username, int Passed_UserID)
		{
			//This stores the users username as a private variable
			username = Passed_username;

			//This sets the user id of the users account (passed from another form) equal to the Private variable UserID
			UserID = Passed_UserID;

			//This sets the integer used to store the number of columns to 3
			int Number_of_Columns = 3;

			//This tells exploer to create the number of columns specifed by the integer Number_of_Columns
			Table.ColumnCount = Number_of_Columns;

			//This calls the function CollectData passing the integer Number_of_Columns, and sets the returned value it equal to a new Tuple called returnedValues
			Tuple<int, Queue> returnedValues = CollectData(Number_of_Columns);

			//This calls the function AddRows, passing the Tuple returnedValues
			AddRows_Table(returnedValues);

			//This calls the function TableProperties passing the integer Number_of_Columns
			TableProperties(Number_of_Columns);
		}

		//This Tuple function connects to the database table specified in the calling function and collects all the simulation Names and DateSaved  for the table and adds then to the queue TableValues
		private Tuple<int, Queue> CollectData(int Number_of_Columns)
		{
			//defult value is set to one as indexing always starts at zero and this will be used later
			int Number_of_Rows = 0;

			//This creates a queue that will store all the value removed from the database
			Queue TableValues = new Queue();

			//This string stores the type of simulation (e.g. Wave)
			string Type;

			//This string will be used to hold the query of the type of simulation that will be saved
			string Select_query = "";

			//this stores the connection that is used to access the MySQL database through XAMPP on phpMyAdmin [Delgado, 2017]
			string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=PhysicsSimulator;";

			//This prepares the connection to the database [Delgado, 2017]
			MySqlConnection databaseConnection = new MySqlConnection(connectionString);     //This creates a new connection to the MySql database (using the connectionString) called databaseConnection
			//MySqlCommand Select = new MySqlCommand(Select_query, databaseConnection);     //This stores the MySql query Select_query as a new command that can be executed by Sql called Select
			MySqlDataReader reader;     //The result of the query will be stored in the MySQLReader called reader

			//Opens the connection to the database [Delgado, 2017]
			databaseConnection.Open();

			//This loop connects to the database and collects all the simualtion Names and DateSaved and adds then to the queue, loop runs until i is greater Number_of_Columns.
			for (int i = 1; i <= Number_of_Columns; i++)
			{
				if (i == 1)
				{
					//This tells the user that the simulation is a wave
					Type = "Wave";
				}
				else if (i == 2)
				{
					//this tells the user that the simulation is a reflection
					Type = "Reflection";
				}
				else
				{
					//this tells the user that the simulation is a refraction
					Type = "Refraction";
				}

				//This creates a queries that search for all data in the database tables Wave, Reflection and Refraction belonging to the user [Delgado, 2017]
				Select_query = "SELECT SavedName, DateSaved FROM " + Type + " WHERE UserID = '" + UserID + "'";

				MySqlCommand Select = new MySqlCommand(Select_query, databaseConnection);     //This stores the MySql query Select_query as a new command that can be executed by Sql called Select

				//This executes the query Select_query explained above [Delgado, 2017]
				reader = Select.ExecuteReader();

				//This calls the function AddRows_Queue passing the reader, Type, Number_of_Rows and TableValues, and sets the returned value it equal to a new Tuple called returnedValues
				Tuple<int, Queue> returnedValues = AddRows_Queue(reader, Type, Number_of_Rows, TableValues);

				//This sets Number_of_Rows equal to the Tuple returnedValues first item
				Number_of_Rows = returnedValues.Item1;
				//This sets TableValues equal to the Tuple returnedValues second item
				TableValues = returnedValues.Item2;

				//This closes the reader so that it can be used to run another query
				reader.Close();
			}

			//Closes the connection to the database [Delgado, 2017]
			databaseConnection.Close();

			//This returns a new Tuple object containing the integer Number_of_Rows and Queue TableValues
			return Tuple.Create(Number_of_Rows, TableValues);
		}

		//This Tuple function adds the rows of collected data from the database to DataGridView, using the queue TableValues
		private Tuple<int, Queue> AddRows_Queue(MySqlDataReader reader, string Type, int Number_of_Rows, Queue TableValues)		//This is a Tuple so I can return more than one datatype
		{
			//This creates a string used to store the name stored on the database
			string Name;
			//This creates a string that will be used to store the previous name that was recieved from the database, and sets it equal to NULL
			string PreviousName = "";

			//This creates a DateTime called DateSaved to store the date and time stored on the database
			DateTime DateSaved;

			//This checks if the query returns a result from the database (i.e. there are saved simulations) [Delgado, 2017]
			while (reader.HasRows)
			{
				//This reads one line at a time, from the MySqlDataReader reader
				reader.Read();

				//Sets the password stored in the database table to a string variable [Delgado, 2017]
				Name = (string)reader[0];   //This stores the first piece of data recieved from the query
				DateSaved = (DateTime)reader[1];   //This stores the second piece of data recieved from the query

				//This checks if the current Name of the saved simualtion equals the same as the one before, this is because when the reader reaches the end it keeps rereading the last line
				if (Name == PreviousName)
				{
					//This forces the while to stop running and to be exited
					break;
				}

				//This adds the simulation Name, Type and DateSaved to the queue TableValues
				TableValues.Enqueue(Name);
				TableValues.Enqueue(Type);
				TableValues.Enqueue(DateSaved);

				//This sets PreviousName equal to Name
				PreviousName = Name;

				//This adds 1 to the number of rows
				Number_of_Rows++;
			}

			//This returns a new Tuple object containing the integer Number_of_Rows and Queue TableValues
			return Tuple.Create(Number_of_Rows, TableValues);
		}

		//This adds the data recieved from the database to the datagridview Table
		private void AddRows_Table(Tuple<int, Queue> returnedValues)
		{
			//This creates an integer called Number_of_Rows and set it equal to the Tuple returnedValues first item
			int Number_of_Rows = returnedValues.Item1;
			//This creates an queue called TableValues and set it equal to the Tuple returnedValues second item
			Queue TableValues = returnedValues.Item2;

			//This checks if rows have been added to Table
			if (Number_of_Rows == 0)
			{
				//This displays to the user that they don't have any saved simulations
				MessageBox.Show("You currently don't have any saved simulations");

				//This hides this form (Open) from the user
				Hide();
			}

			//This sets the number of rows to be displayed in Table, which is the number of rows of information added, plus one because it didn.t work otherwise
			Table.RowCount = Number_of_Rows + 1;

			//This adds the data retrieved from the database to different rows on Table
			for (int j = 0; j < Number_of_Rows; j++)
			{
				//This dequeues a value from TableValues and sets it equal to the string Name
				string Name = (string)TableValues.Dequeue();
				//This dequeues a value from TableValues and sets it equal to the string Type
				string Type = (string)TableValues.Dequeue();
				//This dequeues a value from TableValues and sets it equal to the DateTime DateSaved
				DateTime DateSaved = (DateTime)TableValues.Dequeue();

				//This changes the DateSaved from a form it has to be to be stored on the MySql database to a form the user read easily
				string Time_and_Date = DateSaved.ToString("HH:mm dd-MM-yyyy");

				//This adds the values to Table so they can be viewed by the user
				Table.Rows[j].Cells[0].Value = Name;
				Table.Rows[j].Cells[1].Value = Type;
				Table.Rows[j].Cells[2].Value = Time_and_Date;
			}
		}

		//This sets the properties for the table
		private void TableProperties(int Number_of_Columns)
		{
			//This sets the first column header's text to Name
			Table.Columns[0].Name = "Name";

			//This sets the second column header's text to Type
			Table.Columns[1].Name = "Type";

			//This sets the third column header's text to Date Saved
			Table.Columns[2].Name = "Date Saved";

			//This sets all the cells width to 100
			for (int i = 0; i < Number_of_Columns; i++)
			{
				Table.Columns[i].Width = 100;
			}

			//This hides the blank row headers
			Table.RowHeadersVisible = false;

			//This sets any blank space in Table to be the same colour as the form background colour, so that it is invisiable
			Table.BackgroundColor = SystemColors.Control;

			//This removes the last empty extra row
			Table.AllowUserToAddRows = false;

			//This means the user can only highlight one row at a time
			Table.MultiSelect = false;

			//This makes the user only able to select a full row and not a single cell
			Table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			//This tops the user from being able to change any of the values in the DataGridView Table
			Table.ReadOnly = true;
		}

		//When the button OpenButton is pressed it opens the selected simualtion
		private void OpenButton_Click(object sender, EventArgs e)
		{
			//This stores the row number of the simulation the user selected to open
			int row = Table.SelectedRows[0].Index;

			//This stores the name of the simualtion the user selected to open
			string name = Convert.ToString(Table.Rows[row].Cells[0].Value);

			//This stores the type of simualtion the user selected to open
			string Type = Convert.ToString(Table.Rows[row].Cells[1].Value);
			
			//This asks the user if they want to open the selected simualtion, in a pop-up window
			DialogResult dialog = MessageBox.Show("Do you want to open " + name + "?", "Open", MessageBoxButtons.YesNo);

			//The following runs if the user confirms they want to open the selected simualtion
			if (dialog == DialogResult.Yes)
			{
				//This displays to the user the simualtion is being opened
				MessageBox.Show("Opening " + name);

				//This tells the program the simulation to be displayed is a new simualtion
				bool New = false;

				//This calls the method SimulationForm from the class SwitchForm, which closes this form and displays SimulationForm form
				switchForm.SimulationForm(name, Type, username, UserID, New);
			}
		}

		//When the button CancelButton is pressed it closes this form
		private void CancelButton_Click(object sender, EventArgs e)
		{
			//This hides this form (Open) from the user
			Hide();
		}
	}
}
/*
References - these are references for parts of code that I have copied. I copied them because I need them to make my program work but where not part the main focus of my project
	Delgado, 19/4/2017 - How to connect to MySQL with C# Winforms and XAMPP - Our Code World
		Available at: https://ourcodeworld.com/articles/read/218/how-to-connect-to-mysql-with-c-sharp-winforms-and-xampp
*/
