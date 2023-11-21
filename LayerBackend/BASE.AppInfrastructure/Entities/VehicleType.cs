namespace BASE.AppInfrastructure.Entities
{
	public class VehicleType : BaseEntity<int>
	{
		public string Code { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Vehicle> Vehicles { get; set; }
	}
}
