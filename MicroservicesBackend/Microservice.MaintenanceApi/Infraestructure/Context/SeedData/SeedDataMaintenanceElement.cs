using Microservice.IoC.Utils;
using Microservice.MaintenanceApi.Core.Constants;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Context.SeedData
{
	public class SeedDataMaintenanceElement
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MaintenanceElement>().HasData(new MaintenanceElement
			{
				Id = 1,
				Name = AppConstants.MAINTENANCE_ELEMENT_FRONT_WHEEL_NAME,
				Description = AppConstants.MAINTENANCE_ELEMENT_FRONT_WHEEL_DESCRIPTION,
				Master = true,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceElement>().HasData(new MaintenanceElement
			{
				Id = 2,
				Name = AppConstants.MAINTENANCE_ELEMENT_BACK_WHEEL_NAME,
				Description = AppConstants.MAINTENANCE_ELEMENT_BACK_WHEEL_DESCRIPTION,
				Master = true,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceElement>().HasData(new MaintenanceElement
			{
				Id = 3,
				Name = AppConstants.MAINTENANCE_ELEMENT_ENGINE_OIL_NAME,
				Description = AppConstants.MAINTENANCE_ELEMENT_ENGINE_OIL_DESCRIPTION,
				Master = true,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
		}
	}
}
