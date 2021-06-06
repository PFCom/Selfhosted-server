using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PFComSelfhostedServer.Services.Users.Sessions;
using System;
using System.Linq;

namespace PFComSelfhostedServer.Helpers
{
    /// <summary>
    /// An attribute that should be applied to a controller or an action.
    /// If this attribute is applied to a method or to a controller requires that an user needs to authenticate and validate via a token.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequireTokenAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// A method that's called when the application is trying to authorize the user.
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!context.HttpContext.Request.Headers.ContainsKey("token")) // Checks if the request contains a header called "token".
            {
                this.unauthorized(context); // Returns HTTP Status 401.
                return;
            }
            
            var sessionValidator = (SessionValidator)context.HttpContext.RequestServices.GetService(typeof(SessionValidator)); // Resolves a dependency for the service SessionValidator.

            Guid token = Guid.Empty; // Initializes a variable for the token.

            if(!Guid.TryParse(context.HttpContext.Request.Headers["token"].First(), out token)) // This is trying to parse the header into a token.
            {
                this.unauthorized(context); // Returns HTTP Status 401.
                return;
            }

            var isValid = sessionValidator.IsValidToken(token); // Resolves informations about the token.

            if(!isValid.IsValid) // If the token isn't valid.
            {
                this.unauthorized(context); // Returns HTTP Status 401.
                return;
            }
        }

        /// <summary>
        /// Returns the HTTP Status 401.
        /// </summary>
        /// <param name="context"></param>
        protected void unauthorized(AuthorizationFilterContext context)
        {
            context.Result = new UnauthorizedResult(); // Sets as the result the HTTP Status 401.
        }
    }
}