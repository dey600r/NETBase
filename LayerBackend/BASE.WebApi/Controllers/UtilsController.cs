using BASE.Common.Constants;
using BASE.Common.Dtos;
using BASE.Common.Helper;
using Microsoft.AspNetCore.Mvc;

namespace BASE.WebApi.Controllers
{
	public class UtilsController : BaseController
	{
		public UtilsController(ILogger<BaseController> logger) : base(logger)
		{
		}

		[HttpGet]
		[Route("encript")]
		public ActionResult<string> Encript(string text)
		{
			try
			{
				return Ok(CommonHelper.Encrypt(text, Constants.ENCRIPT_KEY));
			}
			catch (Exception ex)
			{
				Log(ex.Message, LogLevel.Error);
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("/decript")]
		public ActionResult<string> Decript(string text)
		{
			try
			{
				return Ok(CommonHelper.Decrypt(text, Constants.ENCRIPT_KEY));
			}
			catch (Exception ex)
			{
				Log(ex.Message, LogLevel.Error);
				return BadRequest(ex.Message);
			}
		}
	}
}
