using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities.Core;
using Microsoft.AspNetCore.Http;

namespace BASE.AppInfrastructure.Repository
{
    public class VehicleRepository : BaseRepository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(DBContext dbContext, IHttpContextAccessor httpContext) : base(dbContext, httpContext)
        {
        }
    }
}
