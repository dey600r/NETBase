using AutoMapper;
using BASE.AppInfrastructure.Entities.Core;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
    public class VehicleTypeService : BaseReaderService<VehicleTypeModel, VehicleType, int>, IVehicleTypeService
	{
		public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper) : base(mapper, vehicleTypeRepository)
		{
		}
	}
}
