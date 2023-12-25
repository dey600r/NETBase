namespace Microservice.MaintenanceApi.Core.Dtos.Utils
{
	public class RabbitMQSettings
	{
		public string Host { get; init; }
		public string ServiceName { get; init; }
		public int Port { get; init; }
		public string VHost { get; init; }
		public string User { get; init; }
		public string Pwd { get; init; }
	}
}
