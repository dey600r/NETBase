using AutoMapper;
using BASE.AppInfrastructure.Context;
using BASE.AppInfrastructure.Entities;
using BASE.Common.Dtos;

namespace BASE.AppCore.Services
{
	public  class VehicleService : IVehicleService
	{
		private readonly DBContext _dbContext;
		private readonly IMapper _mapper;

		public VehicleService(DBContext context, IMapper mapper) { 
			_dbContext = context;
			_mapper = mapper;
		}

		public VehicleTypeModel Add(VehicleTypeModel vehicleType)
		{
			var result = _dbContext.Add(new VehicleType()
			{
				Code = vehicleType.Code,
				Description = vehicleType.Code				
			});

			_dbContext.SaveChanges();
			return _mapper.Map<VehicleTypeModel>(result.Entity);
		}

		public IEnumerable<VehicleTypeModel> GetAll()
		{
			return _dbContext.Set<VehicleType>().ToList().Select(x => _mapper.Map<VehicleTypeModel>(x));
		}
	}
}
