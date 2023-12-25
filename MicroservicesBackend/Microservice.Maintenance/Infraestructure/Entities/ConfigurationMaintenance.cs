using Microservice.MaintenanceApi.Infraestructure.Entities.Base;

namespace Microservice.MaintenanceApi.Infraestructure.Entities
{
	public class ConfigurationMaintenance : BaseEntity<int>
	{
		public int ConfigurationId { get; set; }
		public int MaintenanceId { get; set; }

		public virtual Configuration Configuration { get; set; }
		public virtual Maintenance Maintenance { get; set; }
	}
}
