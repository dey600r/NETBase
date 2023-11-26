using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BASE.AppInfrastructure.Entities;

namespace BASE.AppInfrastructure.Context.Configurations
{
	public class ConfigurationVehicleType : ConfigurationBase<VehicleType>
	{
		public override void Configure(EntityTypeBuilder<VehicleType> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Code).IsRequired();
			builder.Property(b => b.Description).IsRequired();
		}
	}
}
