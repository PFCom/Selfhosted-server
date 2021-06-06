using System.Security.Cryptography;
using System.Text;

namespace PFComSelfhostedServer.Services
{
    /// <summary>
    /// A service that provides the hashing function.
    /// </summary>
    public class PasswordHashService
    {
        /// <summary>
        /// A hashing algorithm
        /// </summary>
        private SHA512 hash;

        public PasswordHashService()
        {
            this.hash = SHA512.Create(); // Initializes the algorithm.
        }

        /// <summary>
        /// Calculates and returns the hash.
        /// </summary>
        /// <param name="password">A string to hash</param>
        /// <returns>The hash</returns>
        public string HashPassword(string password)
        {
            password = "ufhioahahrthewythtyuuabfudhasyuig4y327859y23479hyuhfyuah" + password + "y47832y58342h53hyuhfyufghy7t6732t734hfyah"; // Adds the seed to a password.

            return this.calculateHash(password); // Returns the hash.
        }

        /// <summary>
        /// Internally calculates the hash.
        /// </summary>
        /// <param name="str">A string to hash</param>
        /// <returns>The hash</returns>
        private string calculateHash(string str)
        {
            byte[] data = this.hash.ComputeHash(Encoding.UTF8.GetBytes(str)); // Converts a string to a bytes array and calculates hash of the array.

            var sBuilder = new StringBuilder(); // Initializes a string builder.

            for(int i = 0; i < data.Length; i++) // A loop for converting the hash array into a string.
            {
                sBuilder.Append(data[i].ToString("x2")); // Adds a character into the string builder.
            }

            return sBuilder.ToString(); // Returns result of the string builder.
        }
    }
}
