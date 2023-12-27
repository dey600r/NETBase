using Microservice.VehicleApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.VehicleApi.Infraestructure.Context.Configurations
{
	public class ConfigurationOperationMaintenanceElement : ConfigurationBase<OperationMaintenanceElement>
	{
		public override void Configure(EntityTypeBuilder<OperationMaintenanceElement> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Price).IsRequired();

			builder.HasOne(b => b.Operation).WithMany(b => b.OperationMaintenanceElements).HasForeignKey(b => b.OperationId).IsRequired();
			builder.HasOne(b => b.MaintenanceElement).WithMany(b => b.OperationMaintenanceElements).HasForeignKey(b => b.MaintenanceElementId).IsRequired();
		}
	}
}
