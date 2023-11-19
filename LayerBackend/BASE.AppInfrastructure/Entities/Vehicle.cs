

namespace BASE.AppInfrastructure.Entities
{
	public class Vehicle : BaseEntity
	{
		public string Model { get; set; }
		public string Brand { get; set; }
		public int Year { get; set; }
		public int Km { get; set; }
		//public Guid IdConfiguration { get; set; }
		public Guid IdVehicleType { get; set; }
		public int KmsPerMonth { get; set; }
		public DateTime DateKms { get; set; }
		public DateTime DatePurchase { get; set; }
		public bool Active { get; set; }

		public virtual VehicleType VehicleType { get; set; }
	}
}
