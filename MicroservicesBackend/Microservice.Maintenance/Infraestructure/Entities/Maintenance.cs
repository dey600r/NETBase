using Microservice.MaintenanceApi.Infraestructure.Entities.Base;

namespace Microservice.MaintenanceApi.Infraestructure.Entities
{
	public class Maintenance : BaseEntity<int>
	{
		public string Description { get; set; }
		public int MaintenanceFreqId { get; set; }
		public int Km {  get; set; }
		public int? Time { get; set; }
		public bool Init { get; set; }
		public bool Wear { get; set; }
		public int FromKm { get; set; }
		public int ToKm  { get; set; }
		public bool Master { get; set; }

		public virtual MaintenanceFreq MaintenanceFreq { get; set; }

		public virtual ICollection<ConfigurationMaintenance> ConfigurationMaintenances { get; set; }
		public virtual ICollection<MaintenanceMaintenanceElement> MaintenanceMaintenanceElements { get; set; }
	}
}
