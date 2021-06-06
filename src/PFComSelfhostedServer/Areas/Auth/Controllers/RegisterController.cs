using Microsoft.AspNetCore.Mvc;
using PFComSelfhostedServer.Areas.Auth.Models.ReqModels;
using PFComSelfhostedServer.Areas.Auth.Models.ResModels;
using PFComSelfhostedServer.Data.Database;
using PFComSelfhostedServer.Services.Users;
using System;

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

        public RegisterController(UserRegisterer userRegisterer)
        {
            this.userRegisterer = userRegisterer; // Injects a dependency.
        }

        /// <summary>
        /// The action.
        /// </summary>
        /// <param name="req">Body of a request</param>
        /// <returns>Registration response model with the ID.</returns>
        [HttpPost]
        public object Post(RegisterReqModel req)
        {
            return new RegisterResModel()
            {
                ID = this.userRegisterer.Register(req.Nickname, req.Password)
            };
        }
    }
}
