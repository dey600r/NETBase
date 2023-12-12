using AutoMapper;
using Microservice.VehicleApi.Core.Dtos;
using Microservice.VehicleApi.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
	public class ConfigurationRepository : IConfigurationRepository
	{
		private readonly DBContext _dbContext;
		private readonly IMapper _mapper;

		public ConfigurationRepository(DBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public IEnumerable<ConfigurationModel> GetAll()
		{
			return _dbContext.Configurations.AsNoTracking().Select(x => _mapper.Map<ConfigurationModel>(x)).ToList();
		}
	}
}
