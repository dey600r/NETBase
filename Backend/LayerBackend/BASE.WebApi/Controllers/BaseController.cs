using BASE.AppCore.Services.Security;
using BASE.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace BASE.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : Controller
	{
		private readonly ILogger<BaseController> _logger;
		private readonly IHttpContextAccessor _httpContextAccessor;
		
		public BaseController(ILogger<BaseController> logger, IHttpContextAccessor httpContextAccessor) { 
			_logger = logger;
			_httpContextAccessor = httpContextAccessor;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			Log($"Autolog - {context.Controller}");
			base.OnActionExecuting(context);
		}

		protected void Log(string message, LogLevel level = LogLevel.Information)
		{
			string showMessage = GetMessage(message);
			switch (level)
			{
				case LogLevel.Information: _logger.LogInformation(showMessage); break;
				case LogLevel.Warning: _logger.LogWarning(showMessage); break;
				case LogLevel.Error: _logger.LogError(showMessage); break;
				default: _logger.LogCritical(showMessage); break;
			}
		}

		private string GetMessage(string message)
		{
			MethodBase method = MethodBase.GetCurrentMethod();
			return $"{method?.ReflectedType?.Name} / {method?.Name} - {CommonHelper.GetUserSesion(_httpContextAccessor)} - {message}";
		}
	}
}
