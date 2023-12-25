using BASE.AppInfrastructure.Entities.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BASE.AppInfrastructure.Context.Configurations
{
	public class ConfigurationMaintenancenMaintenanceElement : ConfigurationBase<MaintenanceMaintenanceElement>
	{
		public override void Configure(EntityTypeBuilder<MaintenanceMaintenanceElement> builder)
		{
			base.Configure(builder);

			builder.HasOne(b => b.Maintenance).WithMany(b => b.MaintenanceMaintenanceElements).HasForeignKey(b => b.MaintenanceId).IsRequired();
			builder.HasOne(b => b.MaintenanceElement).WithMany(b => b.MaintenanceMaintenanceElements).HasForeignKey(b => b.MaintenanceElementId).IsRequired();
		}
	}
}
