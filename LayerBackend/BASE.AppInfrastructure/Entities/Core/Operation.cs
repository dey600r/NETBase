namespace BASE.AppInfrastructure.Entities.Core
{
	public class Operation : BaseEntity<int>
	{
		public string Description { get; set; }
		public string Details { get; set; }
		public int OperationTypeId { get; set; }
		public int VehicleId { get; set; }
		public int Km { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }
		public string Owner { get; set; }
		public int Price { get; set; }

		public virtual OperationType OperationType { get; set; }
		public virtual Vehicle Vehicle { get; set; }

		public virtual ICollection<OperationMaintenanceElement> OperationMaintenanceElements { get; set; }
	}
}
