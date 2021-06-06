using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFComSelfhostedServer.Data.Database
{
    /// <summary>
    /// An entity for table Session.
    /// </summary>
    [Table("Session")]
    public class SessionTable
    {
        /// <summary>
        /// Foreign key to table User.
        /// </summary>
        [ForeignKey("UserTable"), Column(Order = 1)]
        public Guid UserID { get; set; }

        /// <summary>
        /// A token of session.
        /// </summary>
        [Key]
        public Guid Token { get; set; }

        /// <summary>
        /// An expiration datetime of session.
        /// </summary>
        public DateTime Expire { get; set; }
    }
}
