using Microservice.MaintenanceApi.Core.Dtos;
using Microservice.MaintenanceApi.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.MaintenanceApi.Controllers
{
	public class MaintenanceController : BaseController
	{
		private readonly IConfigurationRepository _configurationRepository;
		private readonly IMaintenanceRepository _maintenanceRepository;

		public MaintenanceController(IConfigurationRepository configurationRepository, IMaintenanceRepository maintenanceRepository)
		{
			_configurationRepository = configurationRepository;
			_maintenanceRepository = maintenanceRepository;
		}

		[HttpGet("configuration")]
		public ActionResult<IEnumerable<ConfigurationModel>> GetAllConfigurations()
		{
			return Ok(_configurationRepository.GetAll());
		}

		[HttpGet("maintenance-element")]
		public ActionResult<IEnumerable<MaintenanceElementModel>> GetAllMaintenanceElement()
		{
			return Ok(_maintenanceRepository.GetAll());
		}

		[HttpPost("maintenance-element")]
		public ActionResult<IEnumerable<MaintenanceElementModel>> AddMaintenanceElement(MaintenanceElementModel entity)
		{
			return Ok(_maintenanceRepository.Add(entity));
		}

	}
}
