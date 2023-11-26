using AutoMapper;
using BASE.AppCore.Services.Base;
using BASE.AppInfrastructure.Entities;
using BASE.AppInfrastructure.Repository.Vehicle;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
    public class VehicleService : BaseService<VehicleModel, VehicleType, int>, IVehicleService
    {
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper) : base(mapper, vehicleRepository)
        {
        }
    }
}
