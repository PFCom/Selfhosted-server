using PFComSelfhostedServer.Data.Database;
using PFComSelfhostedServer.Services.Users.Sessions.LocalSessions;
using System.Linq;

namespace PFComSelfhostedServer.Services.Users
{
    /// <summary>
    /// A service for logging in an user.
    /// </summary>
    public class UserLoginer
    {
        /// <summary>
        /// An access to a database.
        /// </summary>
        private DataContext db;

        /// <summary>
        /// A service for comparing passwords.
        /// </summary>
        private PasswordComparator psswdComp;

        /// <summary>
        /// A service for registering a new session.
        /// </summary>
        private LocalSessionRegisterer sessionRegisterer;

        public UserLoginer(DataContext db, PasswordComparator psswdComp, LocalSessionRegisterer sessionRegisterer)
        {
            this.db = db; // Injects a dependency.
            this.psswdComp = psswdComp; // Injects a dependency.
            this.sessionRegisterer = sessionRegisterer; 
        }

        /// <summary>
        /// Tries to authenticate an user.
        /// </summary>
        /// <param name="nickname">Nickname of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns></returns>
        public LocalSessionRegisterer.LocalSessionData Login(string nickname, string password)
        {
            var user = this.db.Users.Where(x => x.Nickname == nickname && x.Type == UserTable.UserType.LocalUser).FirstOrDefault(); // Tries to find an user in the database which has the nickname and is a local user.

            if(user == null) // If it doesn't find an user.
            {
                return null; // Returns as it haven't found an user with the nickname.
            }

            var lu = this.db.LocalUsers.Single(x => x.ID == user.ID); // Finds the user in table LocalUser.

            if(!this.psswdComp.EqualPasswords(password, lu.Password)) // If the passwords don't match.
            {
                return null; // Returns as it can't authenticate the user.
            }

            return this.sessionRegisterer.Register(user.ID); // Registers a new session and returns it's value.
        }
    }
}
