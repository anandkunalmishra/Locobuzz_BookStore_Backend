using System;
using BC = BCrypt.Net.BCrypt;
namespace Common_Layer.Encrypt
{
	public class Encrypt
	{
		public string generateHash(string Password)
		{
			Random rand = new Random();
			int saltLength = rand.Next(10, 13);
			string generatedSalt = BC.GenerateSalt(saltLength);

			string generatedHassPassword = BC.HashPassword(Password, generatedSalt);
			return generatedHassPassword;
		}

		public bool matchPassword(string Password, string HashPassword)
		{
			return BC.Verify(Password, HashPassword);
		}
	}
}

