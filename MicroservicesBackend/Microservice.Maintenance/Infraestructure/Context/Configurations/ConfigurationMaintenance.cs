using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.MaintenanceApi.Infraestructure.Context.Configurations
{
	public class ConfigurationMaintenance : ConfigurationBase<Maintenance>
	{
		public override void Configure(EntityTypeBuilder<Maintenance> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Description).IsRequired();
			builder.Property(b => b.Init).IsRequired();
			builder.Property(b => b.Wear).IsRequired();
			builder.Property(b => b.Km).IsRequired();
			builder.Property(b => b.FromKm).IsRequired();
			builder.Property(b => b.ToKm).IsRequired();
			builder.Property(b => b.Master).IsRequired().HasDefaultValue(false);

			builder.HasOne(b => b.MaintenanceFreq).WithMany(b => b.Maintenances).HasForeignKey(b => b.MaintenanceFrecId).IsRequired();
		}
	}
}
