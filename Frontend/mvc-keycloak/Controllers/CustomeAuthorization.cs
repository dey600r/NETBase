using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace mvc_keycloak.Controllers
{
    public class CustomeAuthorization : AuthorizeAttribute, IAuthorizationFilter
    {

        private readonly string[] allowedroles;
        public CustomeAuthorization(params string[] roles)
        {
            this.allowedroles = roles;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var userId = Convert.ToString(context.HttpContext.User);
            Console.WriteLine(context.HttpContext.User.Claims.Where(x => x.Type == "name"));

            if(allowedroles.Contains("hola"))
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

        }
    }
}