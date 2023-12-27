using Microservice.VehicleApi.Core.Dtos;
using Microservice.VehicleApi.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.VehicleApi.Controllers
{
	public class VehicleController : BaseController
	{
		private readonly IVehicleTypeRepository _vehicleTypeRepository;
		private readonly IVehicleRepository _vehicleRepository;

		public VehicleController(IVehicleTypeRepository vehicleTypeRepository, IVehicleRepository vehicleRepository)
		{
			_vehicleTypeRepository = vehicleTypeRepository;
			_vehicleRepository = vehicleRepository;
		}

		[HttpGet("type")]
		public ActionResult<IEnumerable<VehicleTypeModel>> GetAllVehicleTypes()
		{
			return Ok(_vehicleTypeRepository.GetAll());
		}

		[HttpGet()]
		public ActionResult<IEnumerable<VehicleTypeModel>> GetAllVehicles()
		{
			return Ok(_vehicleRepository.GetAll());
		}
	}
}
