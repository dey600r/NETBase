namespace BASE.AppInfrastructure.Entities.Core
{
	public class MaintenanceElement : BaseEntity<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Master { get; set; }

		public virtual ICollection<MaintenanceMaintenanceElement> MaintenanceMaintenanceElements { get; set; }
		public virtual ICollection<OperationMaintenanceElement> OperationMaintenanceElements { get; set; }
	}
}
