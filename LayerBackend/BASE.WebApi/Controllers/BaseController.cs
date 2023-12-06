using BASE.AppCore.Services.Security;
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
		private readonly IJwtGenerator _jwtGenerator;
		
		public BaseController(ILogger<BaseController> logger, IJwtGenerator jwtGenerator) { 
			_logger = logger;
			_jwtGenerator = jwtGenerator;
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
			return $"{method?.ReflectedType?.Name} / {method?.Name} - {_jwtGenerator.GetUserSesion()} - {message}";
		}
	}
}
