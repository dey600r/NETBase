namespace Microservice.VehicleApi.Infraestructure.Entities.Base
{
	public interface IBaseEntity<TId> where TId : struct
	{
		public TId Id { get; set; }
		public string CreatedUser { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
