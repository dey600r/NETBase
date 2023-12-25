namespace BASE.AppInfrastructure.Entities.Core
{
	public class MaintenanceFreq : BaseEntity<int>
	{
		public string Code { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Maintenance> Maintenances { get; set; }
	}
}
