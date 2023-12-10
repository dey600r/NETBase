using Microservice.VehicleApi.Core.Dtos.Base;

namespace Microservice.VehicleApi.Core.Dtos
{
    public class VehicleModel : BaseModel<int>
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public int Km { get; set; }
        public int ConfigurationId { get; set; }
        public int VehicleTypeId { get; set; }
        public int KmsPerMonth { get; set; }
        public DateTime DateKms { get; set; }
        public DateTime DatePurchase { get; set; }
        public bool Active { get; set; }
    }
}
