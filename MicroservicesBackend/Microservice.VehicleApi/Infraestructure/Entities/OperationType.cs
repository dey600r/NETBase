using Microservice.VehicleApi.Infraestructure.Entities.Base;

namespace Microservice.VehicleApi.Infraestructure.Entities
{
	public class OperationType : BaseEntity<int>
	{
		public string Code { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Operation> Operations { get; set; }
	}
}
