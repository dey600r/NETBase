using Microservice.VehicleApi.Core.Dtos;
using Microservice.VehicleApi.Infraestructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.VehicleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class VehicleController : ControllerBase
	{
		private readonly IVehicleTypeRepository _vehicleTypeRepository;

		public VehicleController(IVehicleTypeRepository vehicleTypeRepository) 
		{ 
			_vehicleTypeRepository = vehicleTypeRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<VehicleTypeModel>> Get()
		{
			return Ok(_vehicleTypeRepository.GetAll());
		}
	}
}
