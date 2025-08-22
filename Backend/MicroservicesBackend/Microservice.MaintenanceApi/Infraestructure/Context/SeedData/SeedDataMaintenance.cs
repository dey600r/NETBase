using Microservice.IoC.Utils;
using Microservice.MaintenanceApi.Core.Constants;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Context.SeedData
{
	public class SeedDataMaintenance
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Maintenance>().HasData(new Maintenance
			{
				Id = 1,
				Description = AppConstants.MAINTENANCE_FIRST_REVIEW_DESCRIPTION,
				MaintenanceFreqId = 1,
				Km = 1000,
				Time = 6,
				Init = true,
				Wear = false,
				FromKm = 0,
				ToKm = 0,
				Master = true,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
			modelBuilder.Entity<Maintenance>().HasData(new Maintenance
			{
				Id = 2,
				Description = AppConstants.MAINTENANCE_CHANGE_WHEEL_DESCRIPTION,
				MaintenanceFreqId = 2,
				Km = 30000,
				Time = 36,
				Init = false,
				Wear = true,
				FromKm = 0,
				ToKm = 0,
				Master = true,
				CreatedUser = SecurityConstants.USER_UNKNOWN_AUDIT,
				CreatedDate = SecurityConstants.DATE_AUDIT
			});
		}
	}
}
