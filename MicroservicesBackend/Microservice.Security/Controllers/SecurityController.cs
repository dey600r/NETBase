using MediatR;
using Microservice.Security.Core.Application.Dto;
using Microservice.Security.Core.Application.Mediator.Command;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Security.Controllers
{
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
		public async Task<ActionResult<UserDto>> Registrar(SignUpCommandHandler.UserSignUp parmeters)
		{
			return await _mediator.Send(parmeters);
		}
	}
}
