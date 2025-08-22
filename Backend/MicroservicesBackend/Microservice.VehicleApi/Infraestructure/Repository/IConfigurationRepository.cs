using Microservice.VehicleApi.Core.Dtos;
using Microservice.VehicleApi.Infraestructure.Entities;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
	public interface IConfigurationRepository
	{
		public IEnumerable<ConfigurationModel> GetAll();
		public ConfigurationModel Add(ConfigurationModel entity);
		public IEnumerable<ConfigurationModel> Add(IEnumerable<ConfigurationModel> entities);
		public MaintenanceElementModel Add(MaintenanceElement entity);
		public IEnumerable<MaintenanceElementModel> Add(IEnumerable<MaintenanceElement> entities);

	}
}
