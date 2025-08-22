using BASE.AppInfrastructure.Entities.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BASE.AppInfrastructure.Context.Configurations
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
