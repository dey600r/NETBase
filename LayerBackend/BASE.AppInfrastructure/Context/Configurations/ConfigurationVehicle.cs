using BASE.AppInfrastructure.Entities.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BASE.AppInfrastructure.Context.Configurations
{
    public class ConfigurationVehicle : ConfigurationBase<Vehicle>
	{
		public override void Configure(EntityTypeBuilder<Vehicle> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Model).IsRequired();
			builder.Property(b => b.Brand).IsRequired();
			builder.Property(b => b.Km).IsRequired();
			builder.Property(b => b.KmsPerMonth).IsRequired();
			builder.Property(b => b.DateKms).IsRequired();
			builder.Property(b => b.DateKms).IsRequired();
			builder.Property(b => b.Active).IsRequired();

			builder.HasOne(b => b.Configuration).WithMany(b => b.Vehicles).HasForeignKey(b => b.ConfigurationId).IsRequired();
			builder.HasOne(b => b.VehicleType).WithMany(b => b.Vehicles).HasForeignKey(b => b.VehicleTypeId).IsRequired();
		}
	}
}
