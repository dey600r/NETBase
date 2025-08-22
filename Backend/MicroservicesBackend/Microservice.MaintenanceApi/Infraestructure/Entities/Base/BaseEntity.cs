namespace Microservice.MaintenanceApi.Infraestructure.Entities.Base
{
	public class BaseEntity<TId> : IBaseEntity<TId> where TId : struct
	{
		//[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public TId Id { get; set; }
		public string CreatedUser { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
