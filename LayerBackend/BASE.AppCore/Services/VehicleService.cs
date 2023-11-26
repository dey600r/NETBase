using AutoMapper;
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

		public IEnumerable<VehicleTypeModel> GetAll()
		{
			return _vehicleRepository.GetAll().Select(x => _mapper.Map<VehicleTypeModel>(x));
		}

		public VehicleTypeModel Add(VehicleTypeModel vehicleType)
		{
			return _mapper.Map<VehicleTypeModel>(_vehicleRepository.Add(_mapper.Map<VehicleType>(vehicleType)));
		}

		public VehicleTypeModel Update(VehicleTypeModel vehicleType)
		{
			return _mapper.Map<VehicleTypeModel>(_vehicleRepository.Update(_mapper.Map<VehicleType>(vehicleType)));
		}

		public bool Delete(int id)
		{
			return _vehicleRepository.Delete(id);
		}

	}
}
