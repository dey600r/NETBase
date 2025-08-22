using BASE.AppInfrastructure.Entities.Core;
using BASE.Common.Constants;
using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public class SeedDataMaintenanceElement
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MaintenanceElement>().HasData(new MaintenanceElement
			{
				Id = 1,
				Name = ConstantsApp.MAINTENANCE_ELEMENT_FRONT_WHEEL_NAME,
				Description = ConstantsApp.MAINTENANCE_ELEMENT_FRONT_WHEEL_DESCRIPTION,
				Master = true,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceElement>().HasData(new MaintenanceElement
			{
				Id = 2,
				Name = ConstantsApp.MAINTENANCE_ELEMENT_BACK_WHEEL_NAME,
				Description = ConstantsApp.MAINTENANCE_ELEMENT_BACK_WHEEL_DESCRIPTION,
				Master = true,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
			modelBuilder.Entity<MaintenanceElement>().HasData(new MaintenanceElement
			{
				Id = 3,
				Name = ConstantsApp.MAINTENANCE_ELEMENT_ENGINE_OIL_NAME,
				Description = ConstantsApp.MAINTENANCE_ELEMENT_ENGINE_OIL_DESCRIPTION,
				Master = true,
				CreatedUser = ConstantsSecurity.USER_UNKNOWN_AUDIT,
				CreatedDate = ConstantsSecurity.DATE_AUDIT
			});
		}
	}
}
