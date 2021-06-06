using Microsoft.AspNetCore.Mvc;
using PFComSelfhostedServer.Helpers;

namespace PFComSelfhostedServer.Areas.Auth.Controllers
{
    /// <summary>
    /// A controller for testing validating of a session.
    /// </summary>
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Auth")]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Just for testing via SwaggerUI and OpenAPI.
        /// </summary>
        [FromHeader(Name = "token")]
        public string TokenHeader { get; set; }

        /// <summary>
        /// The action.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [RequireToken]
        public bool Get()
        {
            return true;
        }
    }
}
