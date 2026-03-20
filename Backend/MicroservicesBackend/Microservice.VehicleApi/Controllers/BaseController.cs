using Microservice.IoC.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.VehicleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Policy = SecurityConstants.SUPER_ADMIN_POLICY)]
	public class BaseController : ControllerBase
	{

		public BaseController() { 
		}
	}
}
