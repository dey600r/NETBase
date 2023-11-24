using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BASE.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : Controller
	{
		private readonly ILogger<BaseController> _logger;
		
		public BaseController(ILogger<BaseController> logger) { 
			_logger = logger;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			_logger.LogError($"Autolog - {context.Controller.ToString()}");
			base.OnActionExecuting(context);
		}

		protected void LogInfo(string message)
		{
			_logger?.LogInformation(message);
		}

		protected void LogWarn(string message)
		{
			_logger?.LogWarning(message);
		}

		protected void LogError(string message)
		{
			_logger?.LogError(message);
		}
	}
}
