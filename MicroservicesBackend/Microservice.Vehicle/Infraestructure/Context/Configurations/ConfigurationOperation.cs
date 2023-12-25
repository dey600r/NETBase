using Microservice.VehicleApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.VehicleApi.Infraestructure.Context.Configurations
{
	public class ConfigurationOperation : ConfigurationBase<Operation>
	{
		public override void Configure(EntityTypeBuilder<Operation> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Description).IsRequired();
			builder.Property(b => b.Details).IsRequired();
			builder.Property(b => b.Km).IsRequired();
			builder.Property(b => b.Date).IsRequired();
			builder.Property(b => b.Location).IsRequired();
			builder.Property(b => b.Owner).IsRequired();
			builder.Property(b => b.Price).IsRequired();

			builder.HasOne(b => b.OperationType).WithMany(b => b.Operations).HasForeignKey(b => b.OperationTypeId).IsRequired();
			builder.HasOne(b => b.Vehicle).WithMany(b => b.Operations).HasForeignKey(b => b.VehicleId).IsRequired();
		}
	}
}
