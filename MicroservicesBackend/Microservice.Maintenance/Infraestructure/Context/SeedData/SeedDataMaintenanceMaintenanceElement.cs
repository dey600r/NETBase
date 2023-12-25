using Microservice.MaintenanceApi.Core.Constants;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Context.SeedData
{
	public class SeedDataMaintenanceMaintenanceElement
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MaintenanceMaintenanceElement>().HasData(new MaintenanceMaintenanceElement
			{
				Id = 1,
				MaintenanceId = 1,
				MaintenanceElementId = 3,
				CreatedUser = AppConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = AppConstants.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceMaintenanceElement>().HasData(new MaintenanceMaintenanceElement
			{
				Id = 2,
				MaintenanceId = 2,
				MaintenanceElementId = 1,
				CreatedUser = AppConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = AppConstants.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceMaintenanceElement>().HasData(new MaintenanceMaintenanceElement
			{
				Id = 3,
				MaintenanceId = 2,
				MaintenanceElementId = 3,
				CreatedUser = AppConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = AppConstants.DATE_AUDIT
			});
		}
	}
}
