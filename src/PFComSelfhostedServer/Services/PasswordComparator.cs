namespace PFComSelfhostedServer.Services
{
    /// <summary>
    /// A service to compare a password with a hashed password.
    /// </summary>
    public class PasswordComparator
    {
        /// <summary>
        /// A service for hashing.
        /// </summary>
        private PasswordHashService hasher;

        public PasswordComparator(PasswordHashService hasher)
        {
            this.hasher = hasher; // Injects a dependency.
        }

        /// <summary>
        /// Converts the password into a hash and compares the values.
        /// </summary>
        /// <param name="password">The password</param>
        /// <param name="hashedPassword">The hashed password</param>
        /// <returns></returns>
        public bool EqualPasswords(string password, string hashedPassword)
        {
            return (this.hasher.HashPassword(password) == hashedPassword); // Hashes the password and compares it with the hashed.
        }
    }
}
