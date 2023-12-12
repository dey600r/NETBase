using Microservice.VehicleApi.Core.Dtos;
using Microservice.VehicleApi.Infraestructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.VehicleApi.Controllers
{
	public class ConfigurationController : BaseController
	{
		private readonly IConfigurationRepository _configurationRepository;

		public ConfigurationController(IConfigurationRepository configurationRepository)
		{
			_configurationRepository = configurationRepository;
		}

		[HttpGet()]
		public ActionResult<IEnumerable<ConfigurationModel>> GetAllVehicles()
		{
			return Ok(_configurationRepository.GetAll());
		}
	}
}
