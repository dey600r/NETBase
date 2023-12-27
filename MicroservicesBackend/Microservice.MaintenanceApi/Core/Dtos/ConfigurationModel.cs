using Microservice.MaintenanceApi.Core.Dtos.Base;

namespace Microservice.MaintenanceApi.Core.Dtos
{
	public class ConfigurationModel : BaseModel<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Master { get; set; }
	}
}
