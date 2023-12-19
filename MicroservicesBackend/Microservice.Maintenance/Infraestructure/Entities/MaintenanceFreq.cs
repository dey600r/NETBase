using Microservice.MaintenanceApi.Infraestructure.Entities.Base;

namespace Microservice.MaintenanceApi.Infraestructure.Entities
{
	public class MaintenanceFreq : BaseEntity<int>
	{
		public string Code { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Maintenance> Maintenances { get; set; }
	}
}
