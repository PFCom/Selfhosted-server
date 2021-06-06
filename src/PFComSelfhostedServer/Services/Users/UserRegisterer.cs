using PFComSelfhostedServer.Data.Database;
using System;

namespace PFComSelfhostedServer.Services.Users
{
    /// <summary>
    /// A service for registering new local users.
    /// </summary>
    public class UserRegisterer
    {
        /// <summary>
        /// An access to a database.
        /// </summary>
        private DataContext db;

        /// <summary>
        /// A service for hashing a password.
        /// </summary>
        private PasswordHashService hasher;

        public UserRegisterer(DataContext db, PasswordHashService hasher)
        {
            this.db = db; // Injects a dependency.
            this.hasher = hasher; // Injects a dependency.
        }

        /// <summary>
        /// The function that registers an user.
        /// </summary>
        /// <param name="nickname">A nickname for the user</param>
        /// <param name="password">A password for the user</param>
        /// <returns></returns>
        public Guid Register(string nickname, string password)
        {
            Guid id = Guid.NewGuid(); // Generates a new GUID as an ID for the user.

            this.db.Add(new UserTable() // Inserts a new row into table User
            {
                ID = id,
                Nickname = nickname,
                DisplayName = nickname,
                Type = UserTable.UserType.LocalUser
            });

            this.db.Add(new LocalUserTable() // Inserts a new row into table LocalUser
            {
                ID = id,
                Password = this.hasher.HashPassword(password) // Hashes the password and then inserting with other values.
            });

            this.db.SaveChanges(); // Saves the rows into the database.

            return id; // Returns the user's ID.
        }
    }
}
