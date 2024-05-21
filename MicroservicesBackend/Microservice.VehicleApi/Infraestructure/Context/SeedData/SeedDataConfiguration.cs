using Microservice.IoC.Utils;
using Microservice.VehicleApi.Core.Constants;
using Microservice.VehicleApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.VehicleApi.Infraestructure.Context.SeedData
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
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
		}
	}
}
