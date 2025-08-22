﻿using BASE.AppCore.Services.Security;
using BASE.Common.Dtos.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BASE.WebApi.Controllers.Security
{
	public class SecurityController : BaseController
	{
		private readonly ISecurityService _securityService;

		public SecurityController(ILogger<BaseController> logger, ISecurityService securityService, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor)
		{
			_securityService = securityService;
		}

		[HttpPost("signup")]
		public async Task<ActionResult<UserModel>> Signup(UserSignupModel newUser)
		{
			return await _securityService.SignupUser(newUser);
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserModel>> Login(UserLoginModel user)
		{
			return await _securityService.Login(user);
		}

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<UserModel>> GetCurrentUser()
		{
			return await _securityService.GetCurrentUser();
		}
	}
}
