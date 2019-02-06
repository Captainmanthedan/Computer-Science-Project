using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_class
{
	class program
	{
		static void Main(string[] args)
		{
			bool wave = true;
			bool reflection = false;
			bool refraction = false;

			if (wave == true)
			{
				Wave wave1 = new Wave();

				DateTime time = DateTime.Now;

				wave1.name = "Wave";
				wave1.SignUpDate = time.ToString("yyyy-MM-dd hh:mm:ss");
				wave1.UserID = 1;
				wave1.Amplitude = 5;
				wave1.WaveLength = 20;
			}
			else if (reflection == true)
			{

			}
			else if (refraction == true)
			{

			}
		}
	}

	class Simulation
	{
		public string name;
		public string SignUpDate;
		public int UserID;
	}

	//Derived sub class from Simulation class
	class Wave : Simulation
	{
		public int Amplitude;
		public int WaveLength;
		public int WaveSpeed;
		public int Frequency;
		public int Period;
	}

	//Dervied subclass from Simulation class
	class Light: Simulation
	{
		public int IncidenceAngle;
		public int RefAngle;
	}

	//Dervied subclass from Light subclass
	class Reflection: Light
	{

	}

	//Dervied subclass from Light subclass
	class Refraction: Light
	{
		public int RefractiveIndex1;
		public int RefractiveIndex2;
		public int CriticalAngle;
	}
}
