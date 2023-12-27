using Microservice.MaintenanceApi.Core.Dtos;

namespace Microservice.MaintenanceApi.Infraestructure.Repository
{
	public interface IMaintenanceRepository
	{
		public IEnumerable<MaintenanceElementModel> GetAll();
		public MaintenanceElementModel Add(MaintenanceElementModel entity);
		public IEnumerable<MaintenanceElementModel> Add(IEnumerable<MaintenanceElementModel> entities);
	}
}
