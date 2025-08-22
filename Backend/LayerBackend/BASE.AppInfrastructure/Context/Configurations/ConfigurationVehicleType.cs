using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BASE.AppInfrastructure.Entities.Core;

namespace BASE.AppInfrastructure.Context.Configurations
{
    public class ConfigurationVehicleType : ConfigurationBase<VehicleType>
	{
		public override void Configure(EntityTypeBuilder<VehicleType> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Code).IsRequired();
			builder.Property(b => b.Description).IsRequired();

			//builder.HasMany(b => b.Vehicles).WithOne(b => b.VehicleType).HasForeignKey(b => b.IdVehicleType).IsRequired();
		}
	}
}
