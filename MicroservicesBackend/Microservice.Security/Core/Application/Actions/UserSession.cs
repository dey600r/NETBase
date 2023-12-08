using Microservice.Security.Core.Application.Utils;
using Microservice.Security.Core.Persistence.Entities;

namespace Microservice.Security.Core.Application.Actions
{
	public class UserSession : IUserSession
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserSession(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public string GetUserSession()
		{
			var user = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == nameof(User.UserName));
			return (user == null ? Constants.USER_UNKNOWN_AUDIT : user.Value);
		}
	}
}
