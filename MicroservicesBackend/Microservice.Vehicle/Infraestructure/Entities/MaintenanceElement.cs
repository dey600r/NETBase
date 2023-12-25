using Microservice.VehicleApi.Infraestructure.Entities.Base;

namespace Microservice.VehicleApi.Infraestructure.Entities
{
	public class MaintenanceElement : BaseEntity<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Master { get; set; }

		public virtual ICollection<OperationMaintenanceElement> OperationMaintenanceElements { get; set; }
	}
}
