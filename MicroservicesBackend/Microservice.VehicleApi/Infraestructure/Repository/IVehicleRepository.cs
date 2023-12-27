using Microservice.VehicleApi.Core.Dtos;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
    public interface IVehicleRepository
    {
		public IEnumerable<VehicleModel> GetAll();

	}
}
