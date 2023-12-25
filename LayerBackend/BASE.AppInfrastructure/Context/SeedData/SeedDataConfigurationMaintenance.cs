using BASE.AppInfrastructure.Entities.Core;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public class SeedDataConfigurationMaintenance
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ConfigurationMaintenance>().HasData(new ConfigurationMaintenance
			{
				Id = 1,
				ConfigurationId = 1,
				MaintenanceId = 1,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<ConfigurationMaintenance>().HasData(new ConfigurationMaintenance
			{
				Id = 2,
				ConfigurationId = 1,
				MaintenanceId = 2,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
		}
	}
}
