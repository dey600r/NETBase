namespace BASE.AppInfrastructure.Entities.Core
{
    public class Vehicle : BaseEntity<int>
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

        public virtual Configuration Configuration { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
