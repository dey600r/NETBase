using BASE.AppInfrastructure.Entities;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BASE.AppInfrastructure.Context.Configurations
{
	public class ConfigurationBase<TEntity>: IEntityTypeConfiguration<TEntity> where TEntity : class, IBaseEntity<int>
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.CreatedUser).IsRequired().HasDefaultValue(ConstantsSecurity.USER_UNKNOWN_AUDIT);
			builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(ConstantsSecurity.DATE_AUDIT);
		}
	}
}
