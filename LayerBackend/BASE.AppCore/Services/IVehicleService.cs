using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
	public interface IVehicleService
	{
		public VehicleTypeModel Add(VehicleTypeModel vehicleType);
		public IEnumerable<VehicleTypeModel> GetAll();
	}
}
