namespace PFComSelfhostedServer.Areas.Auth.Models.ReqModels
{
    /// <summary>
    /// The register controller reqest model.
    /// </summary>
    public class RegisterReqModel
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
