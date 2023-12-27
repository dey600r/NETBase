using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.MaintenanceApi.Infraestructure.Context.Configurations
{
    public class ConfigurationConfiguration : ConfigurationBase<Configuration>
	{
		public override void Configure(EntityTypeBuilder<Configuration> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Name).IsRequired();
			builder.Property(b => b.Description).IsRequired();
			builder.Property(b => b.Master).IsRequired().HasDefaultValue(false);

		}
	}
}
