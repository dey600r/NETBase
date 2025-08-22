﻿using BASE.AppCore.Services.Security;
using BASE.Common.Constants;
using BASE.Common.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BASE.WebApi.Controllers
{
	//[Authorize(Policy = ConstantsSecurity.SUPER_ADMIN_POLICY)]
	public class UtilsController : BaseController
    {
		public UtilsController(ILogger<BaseController> logger, IHttpContextAccessor httpContextAccessor) : base(logger, httpContextAccessor)
		{
		}

		[HttpGet]
		[Route("encript")]
		public ActionResult<string> Encript(string text)
		{
			try
			{
				return Ok(CommonHelper.Encrypt(text, ConstantsSecurity.ENCRIPT_KEY));
			}
			catch (Exception ex)
			{
				Log(ex.Message, LogLevel.Error);
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("decript")]
		public ActionResult<string> Decript(string text)
		{
			try
			{
				return Ok(CommonHelper.Decrypt(text, ConstantsSecurity.ENCRIPT_KEY));
			}
			catch (Exception ex)
			{
				Log(ex.Message, LogLevel.Error);
				return BadRequest(ex.Message);
			}
		}
	}
}
