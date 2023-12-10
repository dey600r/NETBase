using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.VehicleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConfigurationController : ControllerBase
	{
		public ConfigurationController() { }

		[HttpGet]
		public ActionResult<string> Get()
		{
			return Ok("hola");
		}
	}
}
