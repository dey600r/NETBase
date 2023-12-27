using Microservice.MaintenanceApi.Infraestructure.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microservice.MaintenanceApi.Core.Constants;

namespace Microservice.MaintenanceApi.Infraestructure.Context.Configurations
{
	public class ConfigurationBase<TEntity>: IEntityTypeConfiguration<TEntity> where TEntity : class, IBaseEntity<int>
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.CreatedUser).IsRequired().HasDefaultValue(AppConstants.USER_UNKNOWN_AUDIT);
			builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(AppConstants.DATE_AUDIT);
		}
	}
}
