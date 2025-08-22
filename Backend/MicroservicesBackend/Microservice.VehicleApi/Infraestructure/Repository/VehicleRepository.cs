using AutoMapper;
using Microservice.VehicleApi.Core.Dtos;
using Microservice.VehicleApi.Infraestructure.Context;
using Microservice.VehicleApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
		private readonly DBContext _dbContext;
		private readonly IMapper _mapper;

		public VehicleRepository(DBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public IEnumerable<VehicleModel> GetAll()
		{
			return _dbContext.Vehicles.AsNoTracking().Select(x => _mapper.Map<VehicleModel>(x)).ToList();
		}

		public IEnumerable<MaintenanceElementModel> GetAllMaintenanceElement()
		{
			return _dbContext.MaintenanceElement.AsNoTracking().Select(x => _mapper.Map<MaintenanceElementModel>(x)).ToList();
		}
	}
}
