using PFComSelfhostedServer.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFComSelfhostedServer.Services.Users.Sessions.LocalSessions
{
    /// <summary>
    /// A service for registering a local session.
    /// </summary>
    public class LocalSessionRegisterer
    {
        /// <summary>
        /// An access to a database.
        /// </summary>
        private DataContext db;

        public LocalSessionRegisterer(DataContext db)
        {
            this.db = db; // Injects a dependency.
        }

        /// <summary>
        /// Registers a new local session.
        /// </summary>
        /// <param name="user">A GUID of an user</param>
        /// <returns>Returns an expire datetime and a token.</returns>
        public LocalSessionData Register(Guid user)
        {
            Guid token = Guid.NewGuid(); // Generates a new GUID as a token.
            DateTime expire = DateTime.UtcNow.AddDays(1); // Generates an expire datetime.

            this.db.Add(new SessionTable() // Inserts a row into table Session.
            {
                UserID = user,
                Token = token,
                Expire = expire
            });

            this.db.SaveChanges(); // Saves the row.

            return new LocalSessionData() // Returns data about the session.
            {
                Token = token,
                Expire = expire
            };
        }

        /// <summary>
        /// A wrapper for result of the function.
        /// </summary>
        public class LocalSessionData
        {
            public Guid Token { get; set; }

            public DateTime Expire { get; set; }
        }
    }
}
