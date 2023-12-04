using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
    public interface IVehicleService : IBaseService<VehicleModel, Vehicle, int>
    {
		public IEnumerable<VehicleModel> GetVehicles();

	}
}
