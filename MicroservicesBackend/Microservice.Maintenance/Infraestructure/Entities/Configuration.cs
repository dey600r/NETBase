using Microservice.MaintenanceApi.Infraestructure.Entities.Base;

namespace Microservice.MaintenanceApi.Infraestructure.Entities
{
    public class Configuration : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Master { get; set; }

        public virtual ICollection<ConfigurationMaintenance> ConfigurationMaintenances { get; set; }

    }
}
