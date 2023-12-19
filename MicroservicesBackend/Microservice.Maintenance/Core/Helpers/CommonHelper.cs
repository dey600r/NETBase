
using Microsoft.AspNetCore.Identity;

namespace Microservice.MaintenanceApi.Core.Helpers
{
	public static class CommonHelper
	{
		public static string GetUserSesion(IHttpContextAccessor httpContextAccessor)
		{
			var userName = httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == nameof(IdentityUser.UserName));
			return (userName == null ? Constants.Constants.USER_UNKNOWN_AUDIT : userName.Value);
		}
	}
}
