﻿using System.Text;
//This allows crytographic services, that enablesthe hashing of the entered password [gsuberland, 2017]
using System.Security.Cryptography;

namespace Physics_Simulator
{
	//I used code that I found online and created this class Hashing to contain and so I could call it in multiple forms
	class Hashing
	{
		//This runs first when the PasswordHash functions is first called, it sends the entered password and the encoding to be used to hash the password to the second PasswordHash function [gsuberland, 2017]
		public string PasswordHash(string password)		//This is public so that it can be called from another class
		{
			//Sends the password and the encoding that will be used to the other PasswordHash function below
			return PasswordHash(password, Encoding.UTF8);   //UTF8 can encode all Unicode characters
		}

		//This function hashes the entered password using the encoding sent from the function above [gsuberland, 2017]
		private string PasswordHash(string password, Encoding textEncoding)
		{
			//Below the byte arrays passBytes aand hash are defined, with passBytes set as the encoded password
			byte[] passBytes = textEncoding.GetBytes(password);     //passBytes stores all the encoded characters in password, using UTF8, into a sequence of bytes
			byte[] hash;

			//This was orginally set as var but I changed it to SHA1, as it was being set to equal the method SHA1.Create(), which creates an instance of SHA1
			using (SHA1 sha1 = SHA1.Create())
			{
				//This computes a random hash for byte array passBytes that stores the encoded entered password
				hash = sha1.ComputeHash(passBytes);
				//This computes a second random hash for the hash of the encoded encrypted entered password, so it is securely encrypted
				hash = sha1.ComputeHash(hash);
			}

			/*This creates a new StringBuilder with the name of sb
			(this was set to var but I changed it to StringBuilder, as it was being set to be a new StringBuilder)*/
			StringBuilder sb = new StringBuilder();

			//Append adds what the user wants to add to the end of StringBuilder, in this case it adds * (which because sb is empty is the first item)
			sb.Append("*");

			//This "For" loop runs until the integer i is greater than or equal to the length of the byte array named hash
			for (int i = 0; i < hash.Length; i++)
			{
				//Writes first value in the byte array hash (which is just one value i) as hexadecimal on the end of the String Builder called sb, and must be at least 2 digits long
				sb.AppendFormat("{0:X2}", hash[i]);
			}

			//This returns the generated hashed password stored in sb as a string
			return sb.ToString();
		}
	}
}
/*
References - these are references for parts of code that I have copied. I copied them because I need them to make my program work but where not part the main focus of my project
	gsuberland, 2017. Any quick way to convert passwords to mysql hashes? : csharp - Reddit.com
		Available at: https://www.reddit.com/r/csharp/comments/5k2kba/any_quick_way_to_convert_passwords_to_mysql_hashes/dbkw3er/

*/
