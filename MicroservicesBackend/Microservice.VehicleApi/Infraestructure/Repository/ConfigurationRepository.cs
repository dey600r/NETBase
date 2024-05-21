using AutoMapper;
using MassTransit;
using Microservice.Core.Events;
using Microservice.IoC.Helper;
using Microservice.VehicleApi.Core.Dtos;
using Microservice.VehicleApi.Infraestructure.Context;
using Microservice.VehicleApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
	public class ConfigurationRepository : IConfigurationRepository
	{
		private readonly DBContext _dbContext;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IPublishEndpoint _publishEndpoint;

		public ConfigurationRepository(DBContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor, 
			IBusControl busControl, IPublishEndpoint publishEndpoint)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_publishEndpoint = publishEndpoint;
		}

		public IEnumerable<ConfigurationModel> GetAll()
		{
			return _dbContext.Configurations.AsNoTracking().Select(x => _mapper.Map<ConfigurationModel>(x)).ToList();
		}

		public ConfigurationModel Add(ConfigurationModel entity) => Add(new List<ConfigurationModel>() { entity }).FirstOrDefault();

		public IEnumerable<ConfigurationModel> Add(IEnumerable<ConfigurationModel> entities)
		{
			try
			{
				if (entities == null || !entities.Any())
					throw new Exception("No data to add configuration");

				List<Configuration> results = new List<Configuration>();
				foreach (ConfigurationModel item in entities)
				{
					var itemMapped = _mapper.Map<Configuration>(item);
					itemMapped.CreatedUser = CommonHelper.GetUserSesion(_httpContextAccessor);
					itemMapped.CreatedDate = DateTime.UtcNow;
					_dbContext.Entry(itemMapped).State = EntityState.Added;
					results.Add(_dbContext.Set<Configuration>().Add(itemMapped).Entity);
					_publishEndpoint.Publish(_mapper.Map<MessageConfigurationEvent>(itemMapped));
				}
				_dbContext.SaveChanges();

				return results.Select(item => _mapper.Map<ConfigurationModel>(item));
			}
			catch (Exception ex)
			{
				throw new Exception("AddingConfiguration", ex);
			}
		}

		public MaintenanceElementModel Add(MaintenanceElement entity) => Add(new List<MaintenanceElement>() { entity }).FirstOrDefault();

		public IEnumerable<MaintenanceElementModel> Add(IEnumerable<MaintenanceElement> entities)
		{
			try
			{
				if (entities == null || !entities.Any())
					throw new Exception("No data to add configuration");

				List<MaintenanceElement> results = new List<MaintenanceElement>();
				foreach (MaintenanceElement item in entities)
				{
					var itemMapped = _mapper.Map<MaintenanceElement>(item);
					if (string.IsNullOrEmpty(itemMapped.CreatedUser))
						itemMapped.CreatedUser = CommonHelper.GetUserSesion(_httpContextAccessor);
					itemMapped.CreatedDate = DateTime.UtcNow;
					_dbContext.Entry(itemMapped).State = EntityState.Added;
					results.Add(_dbContext.Set<MaintenanceElement>().Add(itemMapped).Entity);
				}
				_dbContext.SaveChanges();


				return results.Select(item => _mapper.Map<MaintenanceElementModel>(item));
			}
			catch (Exception ex)
			{
				throw new Exception("AddingConfiguration", ex);
			}
		}
	}
}
