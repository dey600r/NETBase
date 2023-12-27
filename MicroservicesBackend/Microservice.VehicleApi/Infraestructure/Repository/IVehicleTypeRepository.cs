using Microservice.VehicleApi.Core.Dtos;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
    public interface IVehicleTypeRepository
    {
		public IEnumerable<VehicleTypeModel> GetAll();

	}
}
