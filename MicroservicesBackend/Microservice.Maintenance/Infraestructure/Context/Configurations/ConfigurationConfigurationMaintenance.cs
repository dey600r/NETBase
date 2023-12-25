using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.MaintenanceApi.Infraestructure.Context.Configurations
{
	public class ConfigurationConfigurationMaintenance : ConfigurationBase<Microservice.MaintenanceApi.Infraestructure.Entities.ConfigurationMaintenance>
	{
		public override void Configure(EntityTypeBuilder<Microservice.MaintenanceApi.Infraestructure.Entities.ConfigurationMaintenance> builder)
		{
			base.Configure(builder);

			builder.HasOne(b => b.Configuration).WithMany(b => b.ConfigurationMaintenances).HasForeignKey(b => b.ConfigurationId).IsRequired();
			builder.HasOne(b => b.Maintenance).WithMany(b => b.ConfigurationMaintenances).HasForeignKey(b => b.MaintenanceId).IsRequired();
		}
	}
}
