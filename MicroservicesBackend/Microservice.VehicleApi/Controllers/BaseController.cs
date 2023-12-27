using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.VehicleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class BaseController : ControllerBase
	{

		public BaseController() { 
		}
	}
}
