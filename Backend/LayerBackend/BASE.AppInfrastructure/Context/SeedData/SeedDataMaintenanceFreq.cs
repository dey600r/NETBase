using BASE.AppInfrastructure.Entities.Core;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public class SeedDataMaintenanceFreq
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MaintenanceFreq>().HasData(new MaintenanceFreq
			{
				Id = 1,
				Code = ConstantsApp.MAINTENANCE_FREQ_ONCE_CODE,
				Description = ConstantsApp.MAINTENANCE_FREQ_ONCE_DESC,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceFreq>().HasData(new MaintenanceFreq
			{
				Id = 2,
				Code = ConstantsApp.MAINTENANCE_FREQ_CALENDAR_CODE,
				Description = ConstantsApp.MAINTENANCE_FREQ_CALENDAR_DESC,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
		}
	}
}
