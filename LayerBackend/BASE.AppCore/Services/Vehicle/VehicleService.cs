using AutoMapper;
using BASE.AppInfrastructure.Entities.Core;
using BASE.AppInfrastructure.Repository;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
    public class VehicleService : BaseService<VehicleModel, Vehicle, int>, IVehicleService
    {
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper) : base(mapper, vehicleRepository)
        {
        }

		public IEnumerable<VehicleModel> GetVehicles()
		{
			_baseRepository.Add(new List<Vehicle>()
			{
				new Vehicle
				{
					Brand = "Honda",
					Model = "CBR",
					Km = 50000,
					Year = 2008,
					DateKms = DateTime.UtcNow,
					KmsPerMonth = 100,
					Active = true,
					IdVehicleType = 1,
					VehicleType = new VehicleType() { Id = 1 },
					IdConfiguration = 1,
					Configuration = new Configuration() { Id = 1 }
				},
				new Vehicle
				{
					Brand = "Triumph",
					Model = "Tiger 1200",
					Km = 10000,
					Year = 2021,
					DateKms = DateTime.UtcNow,
					KmsPerMonth = 200,
					Active = true,
					IdVehicleType = 1,
					VehicleType = new VehicleType() { Id = 1 },
					IdConfiguration = 1,
					Configuration = new Configuration() { Id = 1 }
				}
			});

			return _baseRepository.GetAll(x => x.KmsPerMonth >= 100).Select(x => _mapper.Map<VehicleModel>(x)).ToList();
		}
	}
}
