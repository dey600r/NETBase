using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities.Core;

namespace BASE.AppInfrastructure.Repository
{
    public class VehicleTypeRepository : BaseReaderRepository<VehicleType, int>, IVehicleTypeRepository
	{
		public VehicleTypeRepository(DBContext dbContext) : base(dbContext)
		{
		}
	}
}
