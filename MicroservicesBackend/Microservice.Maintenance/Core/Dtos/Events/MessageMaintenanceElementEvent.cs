namespace Microservice.VehicleApi.Core.Dtos.Events
{
	public class MessageMaintenanceElementEvent
	{
		public int Id { get; set; }
		public string CreatedUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Master { get; set; }
	}
}
