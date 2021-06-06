using System;

namespace PFComSelfhostedServer.Areas.Auth.Models.ResModels
{
    /// <summary>
    /// The login controller response model.
    /// </summary>
    public class LoginResModel
    {
        /// <summary>
        /// Token of session.
        /// </summary>
        public Guid Token { get; set; }

        /// <summary>
        /// Expiration datetime of session.
        /// </summary>
        public DateTime Expire { get; set; }
    }
}
