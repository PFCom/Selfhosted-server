using Microsoft.AspNetCore.Mvc;
using PFComSelfhostedServer.Areas.Auth.Models.ReqModels;
using PFComSelfhostedServer.Areas.Auth.Models.ResModels;
using PFComSelfhostedServer.Services.Users;

namespace PFComSelfhostedServer.Areas.Auth.Controllers
{
    /// <summary>
    /// A controller that provides function of logging in (creating sessions).
    /// </summary>
    [Route("api/[area]/[controller]")]
    [Area("Auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// A service for logging in users.
        /// </summary>
        private UserLoginer loginer;

        public LoginController(UserLoginer loginer)
        {
            this.loginer = loginer; // Injects a dependency.
        }

        /// <summary>
        /// The action.
        /// </summary>
        /// <param name="req">Body of a request</param>
        /// <returns>Login res model with a token and expiration datetime</returns>
        [HttpPost]
        public object Post(LoginReqModel req)
        {
            var session = this.loginer.Login(req.Nickname, req.Password);

            if(session == null)
            {
                return this.Unauthorized();
            }

            return this.Ok(new LoginResModel()
            {
                Token = session.Token,
                Expire = session.Expire
            });
        }
    }
}
