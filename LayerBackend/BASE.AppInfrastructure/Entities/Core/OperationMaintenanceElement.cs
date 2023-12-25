namespace BASE.AppInfrastructure.Entities.Core
{
	public class OperationMaintenanceElement : BaseEntity<int>
	{
		public int OperationId { get; set; }
		public int MaintenanceElementId { get; set; }
		public int Price { get; set; }

		public virtual Operation Operation { get; set; }
		public virtual MaintenanceElement MaintenanceElement { get; set; }
	}
}
