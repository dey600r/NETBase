using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.MaintenanceApi.Infraestructure.Context.Configurations
{
	public class ConfigurationMaintenanceFreq : ConfigurationBase<MaintenanceFreq>
	{
		public override void Configure(EntityTypeBuilder<MaintenanceFreq> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Code).IsRequired();
			builder.Property(b => b.Description).IsRequired();
		}
	}
}
