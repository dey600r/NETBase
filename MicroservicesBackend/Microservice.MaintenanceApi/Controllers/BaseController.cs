using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.MaintenanceApi.Controllers
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
