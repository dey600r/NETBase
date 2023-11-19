using BASE.AppInfrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BASE.AppInfrastructure.Context.Configurations
{
	public class ConfigurationVehicle : IEntityTypeConfiguration<Vehicle>
	{
		public void Configure(EntityTypeBuilder<Vehicle> builder)
		{
			builder.Property(b => b.Model).IsRequired();
			builder.Property(b => b.Brand).IsRequired();
			builder.Property(b => b.Km).IsRequired();
			builder.Property(b => b.KmsPerMonth).IsRequired();
			builder.Property(b => b.DateKms).IsRequired();
			builder.Property(b => b.DateKms).IsRequired();
			builder.Property(b => b.Active).IsRequired();

			builder.HasOne(b => b.VehicleType).WithMany(b => b.Vehicles).HasForeignKey(b => b.IdVehicleType).IsRequired();
		}
	}
}
