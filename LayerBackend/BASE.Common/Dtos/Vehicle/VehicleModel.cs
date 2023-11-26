namespace BASE.Common.Dtos
{
	public class VehicleModel : BaseModel<int>
	{
		public string Model { get; set; }
		public string Brand { get; set; }
		public int Year { get; set; }
		public int Km { get; set; }
		public int IdConfiguration { get; set; }
		public int IdVehicleType { get; set; }
		public int KmsPerMonth { get; set; }
		public DateTime DateKms { get; set; }
		public DateTime DatePurchase { get; set; }
		public bool Active { get; set; }
	}
}
