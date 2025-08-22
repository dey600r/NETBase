using Microservice.MaintenanceApi.Core.Dtos;
using Microservice.MaintenanceApi.Infraestructure.Entities;

namespace Microservice.MaintenanceApi.Infraestructure.Repository
{
	public interface IConfigurationRepository
	{
		public IEnumerable<ConfigurationModel> GetAll();
		public ConfigurationModel Add(Configuration entity);
		public IEnumerable<ConfigurationModel> Add(IEnumerable<Configuration> entities);

	}
}
