using Microservice.VehicleApi.Core.Dtos.Base;

namespace Microservice.VehicleApi.Core.Dtos
{
    public class VehicleTypeModel : BaseModel<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
