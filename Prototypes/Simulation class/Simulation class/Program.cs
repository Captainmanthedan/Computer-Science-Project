﻿using System;
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

			DateTime time = DateTime.Now;

			if (wave == true)
			{
				Wave wave1 = new Wave();

				wave1.name = "Wave";
				wave1.SavedDate = time.ToString("yyyy-MM-dd hh:mm:ss");
				wave1.UserID = 1;
				wave1.Amplitude = 5;
				wave1.WaveLength = 20;
				wave1.WaveSpeed = 3;
				wave1.Frequency = 5;
				wave1.Period = 1;

				Console.WriteLine("Name: " + wave1.name);
				Console.WriteLine("Saved Date: " + wave1.SavedDate);
				Console.WriteLine("UserID: " + wave1.UserID);
				Console.WriteLine("Amplitude: " + wave1.Amplitude);
				Console.WriteLine("Wave Length: " + wave1.WaveLength);
				Console.WriteLine("Wave Speed: " + wave1.WaveSpeed);
				Console.WriteLine("Frequency: " + wave1.Frequency);
				Console.WriteLine("Period: " + wave1.Period);
			}
			else if (reflection == true)
			{

			}
			else if (refraction == true)
			{

			}
			Console.ReadKey();
		}
	}

	class Simulation
	{
		public string name;
		public string SavedDate;
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
