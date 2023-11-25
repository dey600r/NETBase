using AutoMapper;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
	public  class VehicleService : IVehicleService
	{
		private readonly IVehicleRepository _vehicleRepository;
		private readonly IMapper _mapper;

		public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper) {
			_vehicleRepository = vehicleRepository;
			_mapper = mapper;
		}

		public VehicleTypeModel Add(VehicleTypeModel vehicleType)
		{
			return _mapper.Map<VehicleTypeModel>(_vehicleRepository.Add(new VehicleType()
			{
				Code = vehicleType.Code,
				Description = vehicleType.Code
			}));
		}

		public IEnumerable<VehicleTypeModel> GetAll()
		{
			_vehicleRepository.GetAll().Select(x => _mapper.Map<VehicleTypeModel>(x));
			return _vehicleRepository.GetAll().Select(x => _mapper.Map<VehicleTypeModel>(x));
		}
	}
}
