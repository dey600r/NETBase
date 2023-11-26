using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;

namespace BASE.AppInfrastructure.Repository
{
	public class VehicleTypeRepository : BaseRepository<VehicleType, int>, IVehicleTypeRepository
	{
		public VehicleTypeRepository(DBContext dbContext) : base(dbContext)
		{
		}
	}
}
