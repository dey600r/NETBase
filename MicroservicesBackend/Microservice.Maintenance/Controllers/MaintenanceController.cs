using Microservice.MaintenanceApi.Core.Dtos;
using Microservice.MaintenanceApi.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.MaintenanceApi.Controllers
{
	public class MaintenanceController : BaseController
	{
		private readonly IConfigurationRepository _configurationRepository;

		public MaintenanceController(IConfigurationRepository configurationRepository)
		{
			_configurationRepository = configurationRepository;
		}

		[HttpGet()]
		public ActionResult<IEnumerable<ConfigurationModel>> GetAllConfigurations()
		{
			return Ok(_configurationRepository.GetAll());
		}

		[HttpPost]
		public ActionResult<IEnumerable<ConfigurationModel>> AddConfiguration(ConfigurationModel entity)
		{
			return Ok(_configurationRepository.Add(entity));
		}
	}
}
