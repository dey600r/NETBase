using Microservice.IoC.Utils;
using Microservice.MaintenanceApi.Core.Constants;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Context.SeedData
{
	public class SeedDataMaintenanceFreq
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MaintenanceFreq>().HasData(new MaintenanceFreq
			{
				Id = 1,
				Code = AppConstants.MAINTENANCE_FREQ_ONCE_CODE,
				Description = AppConstants.MAINTENANCE_FREQ_ONCE_DESC,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceFreq>().HasData(new MaintenanceFreq
			{
				Id = 2,
				Code = AppConstants.MAINTENANCE_FREQ_CALENDAR_CODE,
				Description = AppConstants.MAINTENANCE_FREQ_CALENDAR_DESC,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
		}
	}
}
