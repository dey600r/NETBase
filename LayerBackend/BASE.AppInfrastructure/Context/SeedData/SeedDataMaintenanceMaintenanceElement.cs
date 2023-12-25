using BASE.AppInfrastructure.Entities.Core;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
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
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceMaintenanceElement>().HasData(new MaintenanceMaintenanceElement
			{
				Id = 2,
				MaintenanceId = 2,
				MaintenanceElementId = 1,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceMaintenanceElement>().HasData(new MaintenanceMaintenanceElement
			{
				Id = 3,
				MaintenanceId = 2,
				MaintenanceElementId = 3,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
		}
	}
}
