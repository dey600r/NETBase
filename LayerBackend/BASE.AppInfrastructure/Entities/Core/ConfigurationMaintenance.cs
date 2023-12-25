namespace BASE.AppInfrastructure.Entities.Core
{
	public class ConfigurationMaintenance : BaseEntity<int>
	{
		public int ConfigurationId { get; set; }
		public int MaintenanceId { get; set; }

		public virtual Configuration Configuration { get; set; }
		public virtual Maintenance Maintenance { get; set; }
	}
}
