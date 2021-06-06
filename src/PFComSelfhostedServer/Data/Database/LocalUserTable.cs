using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFComSelfhostedServer.Data.Database
{
    /// <summary>
    /// An entity for table LocalUser.
    /// </summary>
    [Table("LocalUser")]
    public class LocalUserTable
    {
        /// <summary>
        /// A foreign key to table User.
        /// </summary>
        [ForeignKey("UserTable"), Key]
        public Guid ID { get; set; }

        /// <summary>
        /// A password for user.
        /// </summary>
        [MinLength(256), MaxLength(256)]
        public string Password { get; set; }
    }
}
