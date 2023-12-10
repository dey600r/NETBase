using Microservice.VehicleApi.Infraestructure.Context;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        public VehicleRepository(DBContext dbContext)
        {
        }
    }
}
