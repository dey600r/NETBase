namespace BASE.AppInfrastructure.Entities.Core
{
    public class VehicleType : BaseEntity<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
