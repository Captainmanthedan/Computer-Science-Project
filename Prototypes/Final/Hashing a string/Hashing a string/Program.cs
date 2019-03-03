using System;
using System.Text;
//this allows crytographic services, that enablesthe hashing of the entered string [gsuberland, 2017]
using System.Security.Cryptography;

namespace Hashing_a_string
{
	class Program
	{
		static void Main(string[] args)
		{
			//Displays the following text in the console 
			Console.Write("Enter the string you would like to hash: ");
			//This variable stores the users input, as a string called String
			string String = Console.ReadLine();

			////this calls a function that hashes the entered string
			string Hashed_String = StringHash(String);

			//Displays the following text in the console 
			Console.Write("Hashed string: " + Hashed_String);
			Console.ReadKey();
		}

		//This runs first when the StringHash functions is first called, it sends the entered string and the encoding to be used to hash the string to the second StringHash function [gsuberland, 2017]
		static string StringHash(string String)
		{
			//Sends the string and the encoding that will be used to the other StringHash function below
			return StringHash(String, Encoding.UTF8);   //UTF8 can encode all Unicode characters
		}

		//This function hashes the entered string using the encoding sent from the function above [gsuberland, 2017]
		static string StringHash(string String, Encoding textEncoding)
		{
			//Below the byte arrays StringBytes aand hash are defined, with StringBytes set as the encoded string
			byte[] StringBytes = textEncoding.GetBytes(String);     //StringBytes stores all the encoded characters in string, using UTF8, into a sequence of bytes
			byte[] hash;

			//this was orginally set as var but I changed it to SHA1, as it was being set to equal the method SHA1.Create(), which creates an instance of SHA1
			using (SHA1 sha1 = SHA1.Create())
			{
				//This computes a random hash for byte array StringBytes that stores the encoded entered string
				hash = sha1.ComputeHash(StringBytes);
				//This computes a second random hash for the hash of the encoded encrypted entered string, so it is securely encrypted
				hash = sha1.ComputeHash(hash);
			}

			/*This creates a new StringBuilder with the name of sb
			(this was set to var but I changed it to StringBuilder, as it was being set to be a new StringBuilder)*/
			StringBuilder sb = new StringBuilder();

			//Append adds what the user wants to add to the end of StringBuilder, in this case it adds * (which because sb is empty is the first item)
			sb.Append("*");

			//this "For" loop runs until the integer i is greater than or equal to the length of the byte array named hash
			for (int i = 0; i < hash.Length; i++)
			{
				//writes first value in the byte array hash (which is just one value i) as hexadecimal on the end of the String Builder called sb, and must be at least 2 digits long
				sb.AppendFormat("{0:X2}", hash[i]);
			}

			//this returns the generated hashed string stored in sb as a string variable
			return sb.ToString();
		}
	}
}
/*
References - these are references for parts of code that I have copied. I copied them because I need them to make my program work but where not part the main focus of my project
	gsuberland, 2017. Any quick way to convert strings to mysql hashes? : csharp - Reddit.com
		Available at: https://www.reddit.com/r/csharp/comments/5k2kba/any_quick_way_to_convert_strings_to_mysql_hashes/dbkw3er/

*/
