using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
	public interface IVehicleService
	{
		public VehicleTypeModel Add(VehicleTypeModel vehicleType);
		public VehicleTypeModel Update(VehicleTypeModel vehicleType);
		public IEnumerable<VehicleTypeModel> GetAll();
		public bool Delete(int id);
	}
}
