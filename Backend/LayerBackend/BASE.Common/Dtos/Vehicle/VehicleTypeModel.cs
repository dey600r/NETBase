namespace BASE.Common.Dtos
{
    public class VehicleTypeModel : BaseModel<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
