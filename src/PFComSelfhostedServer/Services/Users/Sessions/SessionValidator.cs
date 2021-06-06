using PFComSelfhostedServer.Data.Database;
using System;
using System.Linq;

namespace PFComSelfhostedServer.Services.Users.Sessions
{
    /// <summary>
    /// A service that validates a token.
    /// </summary>
    public class SessionValidator
    {
        /// <summary>
        /// An access to a database.
        /// </summary>
        private DataContext db;

        public SessionValidator(DataContext db)
        {
            this.db = db; // Injects a dependency.
        }

        /// <summary>
        /// Checks if a token is valid.
        /// </summary>
        /// <param name="token">The token</param>
        /// <returns>Some informations about the session</returns>
        public SessionValidatorRes IsValidToken(Guid token)
        {
            var sessions = this.db.Sessions.Where(x => x.Token == token); // Tries to find all sessions with the token.
            
            if(sessions.Count() == 0) // If it has not found any session.
            {
                return new SessionValidatorRes() // Returns as the token isn't valid.
                {
                    IsValid = false,
                    UserID = Guid.Empty
                };
            }

            var session = sessions.FirstOrDefault(); // Gets a session row from the database.

            if(session.Expire < DateTime.UtcNow) // If the expiration date already was.
            {
                this.db.Sessions.Remove(session); // Removes the row from the database.

                this.db.SaveChanges(); // Saves the removation.

                return new SessionValidatorRes() // Returns as the token isn't valid.
                {
                    IsValid = false,
                    UserID = Guid.Empty
                };
            }

            return new SessionValidatorRes() // Returns as the token is valid.
            {
                IsValid = true,
                UserID = session.UserID
            };
        }

        /// <summary>
        /// A result wrapper for the function.
        /// </summary>
        public class SessionValidatorRes
        {
            public bool IsValid { get; set; }

            public Guid UserID { get; set; }
        }
    }
}