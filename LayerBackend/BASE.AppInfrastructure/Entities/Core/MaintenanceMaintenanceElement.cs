namespace BASE.AppInfrastructure.Entities.Core
{
	public class MaintenanceMaintenanceElement : BaseEntity<int>
	{
		public int MaintenanceId { get; set; }
		public int MaintenanceElementId { get; set; }

		public virtual Maintenance Maintenance { get; set; }
		public virtual MaintenanceElement MaintenanceElement { get; set; }
	}
}
