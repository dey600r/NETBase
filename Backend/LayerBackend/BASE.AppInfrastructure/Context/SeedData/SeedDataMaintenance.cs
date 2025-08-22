using BASE.AppInfrastructure.Entities.Core;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public class SeedDataMaintenance
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Maintenance>().HasData(new Maintenance
			{
				Id = 1,
				Description = ConstantsApp.MAINTENANCE_FIRST_REVIEW_DESCRIPTION,
				MaintenanceFreqId = 1,
				Km = 1000,
				Time = 6,
				Init = true,
				Wear = false,
				FromKm = 0,
				ToKm = 0,
				Master = true,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<Maintenance>().HasData(new Maintenance
			{
				Id = 2,
				Description = ConstantsApp.MAINTENANCE_CHANGE_WHEEL_DESCRIPTION,
				MaintenanceFreqId = 2,
				Km = 30000,
				Time = 36,
				Init = false,
				Wear = true,
				FromKm = 0,
				ToKm = 0,
				Master = true,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
		}
	}
}
