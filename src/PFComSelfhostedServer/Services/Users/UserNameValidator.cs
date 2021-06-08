using PFComSelfhostedServer.Data.Database;
using System.Linq;

namespace PFComSelfhostedServer.Services.Users
{
    /// <summary>
    /// A service that checks in a database if a nickname is unique.
    /// </summary>
    public class UserNameValidator
    {
        /// <summary>
        /// An access to database.
        /// </summary>
        private DataContext db;

        public UserNameValidator(DataContext db)
        {
            this.db = db; // Injects a dependency.
        }

        /// <summary>
        /// Checks if there's no user in database with same nickname.
        /// </summary>
        /// <param name="nickname">The nickname to check</param>
        /// <returns></returns>
        public bool IsValid(string nickname)
        {
            return !(this.db.Users.Where(x => x.Nickname == nickname).Count() > 0); // Selects all users with the nickname and checks the count. If the count is greater than 0 it will return false.
        }
    }
}
