using AutoMapper;
using MassTransit;
using Microservice.IoC.Helper;
using Microservice.MaintenanceApi.Core.Dtos;
using Microservice.MaintenanceApi.Infraestructure.Context;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microservice.VehicleApi.Core.Dtos.Events;
using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Repository
{
	public class MaintenanceRepository : IMaintenanceRepository
	{
		private readonly DBContext _dbContext;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IPublishEndpoint _publishEndpoint;

		public MaintenanceRepository(DBContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor, IPublishEndpoint publishEndpoint)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_publishEndpoint = publishEndpoint;
		}

		public IEnumerable<MaintenanceElementModel> GetAll()
		{
			return _dbContext.MaintenanceElement.AsNoTracking().Select(x => _mapper.Map<MaintenanceElementModel>(x)).ToList();
		}

		public MaintenanceElementModel Add(MaintenanceElementModel entity) => Add(new List<MaintenanceElementModel>() { entity }).FirstOrDefault();

		public IEnumerable<MaintenanceElementModel> Add(IEnumerable<MaintenanceElementModel> entities)
		{
			try
			{
				if (entities == null || !entities.Any())
					throw new Exception("No data to add configuration");

				List<MaintenanceElement> results = new List<MaintenanceElement>();
				foreach (MaintenanceElementModel item in entities)
				{
					var itemMapped = _mapper.Map<MaintenanceElement>(item);
					itemMapped.CreatedUser = CommonHelper.GetUserSesion(_httpContextAccessor);
					itemMapped.CreatedDate = DateTime.UtcNow;
					_dbContext.Entry(itemMapped).State = EntityState.Added;
					results.Add(_dbContext.Set<MaintenanceElement>().Add(itemMapped).Entity);
					_publishEndpoint.Publish(_mapper.Map<MessageMaintenanceElementEvent>(itemMapped));
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
