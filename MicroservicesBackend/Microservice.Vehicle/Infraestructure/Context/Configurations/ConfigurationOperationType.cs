using Microservice.VehicleApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.VehicleApi.Infraestructure.Context.Configurations
{
	public class ConfigurationOperationType : ConfigurationBase<OperationType>
	{
		public override void Configure(EntityTypeBuilder<OperationType> builder)
		{
			base.Configure(builder);

			builder.Property(b => b.Code).IsRequired();
			builder.Property(b => b.Description).IsRequired();
		}
	}
}
