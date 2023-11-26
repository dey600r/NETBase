using BASE.AppCore.Services.Base;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
    public interface IVehicleTypeService : IBaseReaderService<VehicleTypeModel, VehicleType, int>
	{
	}
}
