using Microservice.VehicleApi.Core.Dtos;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
	public interface IConfigurationRepository
	{
		public IEnumerable<ConfigurationModel> GetAll();
	}
}
