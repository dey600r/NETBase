using Microservice.IoC.Utils;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Context.SeedData
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
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<ConfigurationMaintenance>().HasData(new ConfigurationMaintenance
			{
				Id = 2,
				ConfigurationId = 1,
				MaintenanceId = 2,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
		}
	}
}
