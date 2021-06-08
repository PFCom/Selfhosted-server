using Microsoft.AspNetCore.Mvc;
using PFComSelfhostedServer.Areas.Auth.Models.ReqModels;
using PFComSelfhostedServer.Areas.Auth.Models.ResModels;
using PFComSelfhostedServer.Services.Users;

namespace PFComSelfhostedServer.Areas.Auth.Controllers
{
    /// <summary>
    /// A controller that provides registration function.
    /// </summary>
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Auth")]
    public class RegisterController : ControllerBase
    {
        /// <summary>
        /// A service for registering users.
        /// </summary>
        private UserRegisterer userRegisterer;

        /// <summary>
        /// A service for checking nickname.
        /// </summary>
        private UserNameValidator nickValidator;

        public RegisterController(UserRegisterer userRegisterer, UserNameValidator nickValidator)
        {
            this.userRegisterer = userRegisterer; // Injects a dependency.
            this.nickValidator = nickValidator; // Injects a dependency.
        }

        /// <summary>
        /// The action.
        /// </summary>
        /// <param name="req">Body of a request</param>
        /// <returns>Registration response model with the ID.</returns>
        [HttpPost]
        public object Post(RegisterReqModel req)
        {
            if(!this.nickValidator.IsValid(req.Nickname))
            {
                return BadRequest("An user with the nickname already exists.");
            }

            return new RegisterResModel()
            {
                ID = this.userRegisterer.Register(req.Nickname, req.Password)
            };
        }
    }
}
