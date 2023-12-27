namespace Microservice.VehicleApi.Core.Dtos.Base
{
    public interface IBaseModel<TId> where TId : struct
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
