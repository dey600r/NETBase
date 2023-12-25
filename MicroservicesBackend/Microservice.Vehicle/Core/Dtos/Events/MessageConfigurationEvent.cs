namespace Microservice.Core.Events
{
	public class MessageConfigurationEvent
	{
		public int Id { get; set; }
		public string CreatedUser { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Master { get; set; }
	}
}
