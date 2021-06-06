namespace PFComSelfhostedServer.Areas.Auth.Models.ReqModels
{
    /// <summary>
    /// The login controller request model.
    /// </summary>
    public class LoginReqModel
    {
        /// <summary>
        /// Nickname of user.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Password of user.
        /// </summary>
        public string Password { get; set; }
    }
}
