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
				Code = Constants.MAINTENANCE_FREQ_ONCE_CODE,
				Description = Constants.MAINTENANCE_FREQ_ONCE_DESC,
				CreatedUser = Constants.USER_UNKNOWN_AUDIT,
				CreatedDate = Constants.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceFreq>().HasData(new MaintenanceFreq
			{
				Id = 2,
				Code = Constants.MAINTENANCE_FREQ_CALENDAR_CODE,
				Description = Constants.MAINTENANCE_FREQ_CALENDAR_DESC,
				CreatedUser = Constants.USER_UNKNOWN_AUDIT,
				CreatedDate = Constants.DATE_AUDIT
			});
		}
	}
}
