using Microservice.MaintenanceApi.Core.Constants;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Context.SeedData
{
    public static class SeedDataConfiguration
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Configuration>().HasData(new Configuration
			{ 
				Id = 1, 
				Name = AppConstants.CONFIGURATION_NAME_PRODUCTION, 
				Description = AppConstants.CONFIGURATION_DESCRIPTION_PRODUCTION,
				Master = true,
				CreatedUser = AppConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = AppConstants.DATE_AUDIT
			});
		}
	}
}
