namespace Microservice.IoC.Settings
{
	public class KeycloakSettings
	{
		public string Authority { get; set; }
		public string AuthorizationUrl { get; set; }
		public string TokenUrl { get; set; }
		public string Audience { get; set; }
		public string Realm { get; set; }
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
	}
}
