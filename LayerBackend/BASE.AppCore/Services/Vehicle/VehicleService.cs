using AutoMapper;
using BASE.AppCore.Services.Base;
using BASE.AppInfrastructure.Entities;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
    public class VehicleService : BaseService<VehicleModel, Vehicle, int>, IVehicleService
    {
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper) : base(mapper, vehicleRepository)
        {
        }
    }
}
