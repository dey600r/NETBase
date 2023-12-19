using Microservice.MaintenanceApi.Core.Dtos;

namespace Microservice.MaintenanceApi.Infraestructure.Repository
{
	public interface IConfigurationRepository
	{
		public IEnumerable<ConfigurationModel> GetAll();
		public ConfigurationModel Add(ConfigurationModel entity);
		public IEnumerable<ConfigurationModel> Add(IEnumerable<ConfigurationModel> entities);

	}
}
