
using BASE.AppCore.Services.Security;
using Microsoft.AspNetCore.Authorization;

namespace BASE.WebApi.Controllers
{
	//[Authorize]
	public class BaseAuthorizeController : BaseController
	{
		public BaseAuthorizeController(ILogger<BaseController> logger, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor)
		{
		}
	}
}
