using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFComSelfhostedServer.Data.Database
{
    /// <summary>
    /// An entity for table User.
    /// </summary>
    [Table("User")]
    public class UserTable
    {
        /// <summary>
        /// Pripary key as GUID.
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Nickname, an unique key that's used when logging in.
        /// </summary>
        [MinLength(3), MaxLength(128)]
        public string Nickname { get; set; }

        /// <summary>
        /// DisplayName is a name, that isn't unique.
        /// </summary>
        [MinLength(3), MaxLength(128)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Type of user, specific like "Local user" or "Centralized user" - this will be used when will be implemented authentication via a centralized server.
        /// </summary>
        public UserType Type { get; set; }

        /// <summary>
        /// Types of user.
        /// </summary>
        public enum UserType
        {
            LocalUser
        }
    }
}
