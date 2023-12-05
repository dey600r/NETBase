using BASE.AppInfrastructure.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BASE.AppInfrastructure.Context.Configurations
{
    public class ConfigurationConfiguration : ConfigurationBase<Configuration>
	{
		public override void Configure(EntityTypeBuilder<Configuration> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Name).IsRequired();
			builder.Property(b => b.Description).IsRequired();
			builder.Property(b => b.Master).IsRequired().HasDefaultValue(false);

			//builder.HasMany(b => b.Vehicles).WithOne(b => b.Configuration).HasForeignKey(b => b.IdConfiguration).IsRequired();
		}
	}
}
