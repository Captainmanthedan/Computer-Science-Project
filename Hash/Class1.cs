using System.Text;
//this allows crytographic services, that enablesthe hashing of the entered password [gsuberland, 2017]
using System.Security.Cryptography;

namespace Encryption
{
	public static class Hash
	{
		//This runs first when the PasswordHash functions is first called, it sends the entered password and the encoding to be used to hash the password to the second PasswordHash function [gsuberland, 2017]
		public static string MySql(this string password)
		{
			//Sends the password and the encoding that will be used to the other PasswordHash function below
			return MySql(password, Encoding.UTF8);   //UTF8 can encode all Unicode characters
		}

		//This function hashes the entered password using the encoding sent from the function above [gsuberland, 2017]
		public static string MySql(this string password, Encoding textEncoding)
		{
			//Below the byte arrays passBytes aand hash are defined, with passBytes set as the encoded password
			byte[] passBytes = textEncoding.GetBytes(password);     //passBytes stores all the encoded characters in password, using UTF8, into a sequence of bytes
			byte[] hash;

			//this was orginally set as var but I changed it to SHA1, as it was being set to equal the method SHA1.Create(), which creates an instance of SHA1
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

			//this "For" loop runs until the integer i is greater than or equal to the length of the byte array named hash
			for (int i = 0; i < hash.Length; i++)
			{
				//writes first value in the byte array hash (which is just one value i) as hexadecimal on the end of the String Builder called sb, and must be at least 2 digits long
				sb.AppendFormat("{0:X2}", hash[i]);
			}

			//this returns the generated hashed password stored in sb as a string
			return sb.ToString();
		}
	}
}