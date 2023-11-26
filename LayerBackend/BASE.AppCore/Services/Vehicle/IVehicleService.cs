using BASE.AppCore.Services.Base;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
    public interface IVehicleService : IBaseService<VehicleModel, VehicleType, int>
    {
    }
}
