namespace Microservice.MaintenanceApi.Core.Dtos.Base
{
	public class BaseModel<TId> : IBaseModel<TId> where TId : struct
	{
		public TId Id { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}
