using AutoMapper;
using BASE.AppInfrastructure.Repository;

namespace BASE.AppCore.Services
{
    public class AppVehicleTypeService : VehicleTypeService, IAppVehicleTypeService
    {
        //private readonly IVehicleService _vehicleService;

        //public AppVehicleService(IVehicleService vehicleService)
        //{
        //    _vehicleService = vehicleService;
        //}
        public AppVehicleTypeService(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper) : base(vehicleTypeRepository, mapper)
        {
        }
    }
}
