using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities.Core;

namespace BASE.AppInfrastructure.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(DBContext dbContext) : base(dbContext)
        {
        }
    }
}
