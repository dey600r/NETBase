using MediatR;
using Microservice.Security.Core.Application.Mapping.Dto;
using Microservice.Security.Core.Application.Mediator.Command;
using Microservice.Security.Core.Application.Mediator.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Security.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class SecurityController : Controller
	{

		private readonly ILogger<SecurityController> _logger;
		private readonly IMediator _mediator;

		public SecurityController(ILogger<SecurityController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpPost("signup")]
		[AllowAnonymous]
		public async Task<ActionResult<UserDto>> SignUp(SignUpCommandHandler.UserSignUp parameters)
		{
			_logger.LogInformation($"CALLING TO: {nameof(SecurityController.SignIn)}: {parameters.UserName}");
			return await _mediator.Send(parameters);
		}

		[HttpPost("login")]
		[AllowAnonymous]
		public async Task<ActionResult<UserDto>> Login(LoginQueryHandler.UserLogin parameters)
		{
			_logger.LogInformation($"CALLING TO: {nameof(SecurityController.Login)}: {parameters.Email}");
			return await _mediator.Send(parameters);
		}

		[HttpGet]
		public async Task<ActionResult<UserDto>> GetCurrentUser()
		{
			_logger.LogInformation($"CALLING TO: {nameof(SecurityController.GetCurrentUser)}");
			return await _mediator.Send(new CurrentUserQueryHandler.CurrentUser());
		}
	}
}
