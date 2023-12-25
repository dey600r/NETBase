using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.MaintenanceApi.Infraestructure.Context.Configurations
{
	public class ConfigurationMaintenanceElement : ConfigurationBase<MaintenanceElement>
	{
		public override void Configure(EntityTypeBuilder<MaintenanceElement> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Name).IsRequired();
			builder.Property(b => b.Description).IsRequired();
			builder.Property(b => b.Master).IsRequired();
		}
	}
}
