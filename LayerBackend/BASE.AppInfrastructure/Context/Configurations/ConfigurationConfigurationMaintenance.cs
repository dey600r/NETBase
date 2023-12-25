using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BASE.AppInfrastructure.Context.Configurations
{
	public class ConfigurationConfigurationMaintenance : ConfigurationBase<BASE.AppInfrastructure.Entities.Core.ConfigurationMaintenance>
	{
		public override void Configure(EntityTypeBuilder<BASE.AppInfrastructure.Entities.Core.ConfigurationMaintenance> builder)
		{
			base.Configure(builder);

			builder.HasOne(b => b.Configuration).WithMany(b => b.ConfigurationMaintenances).HasForeignKey(b => b.ConfigurationId).IsRequired();
			builder.HasOne(b => b.Maintenance).WithMany(b => b.ConfigurationMaintenances).HasForeignKey(b => b.MaintenanceId).IsRequired();
		}
	}
}
