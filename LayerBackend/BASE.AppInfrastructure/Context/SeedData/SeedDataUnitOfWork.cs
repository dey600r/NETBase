using Microsoft.EntityFrameworkCore;

namespace BASE.AppInfrastructure.Context.SeedData
{
	public static class SeedDataUnitOfWork
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			SeedDataVehicleType.Seed(modelBuilder);
			SeedDataOperationType.Seed(modelBuilder);
			SeedDataMaintenanceFreq.Seed(modelBuilder);
			SeedDataMaintenanceElement.Seed(modelBuilder);
			SeedDataConfiguration.Seed(modelBuilder);
			SeedDataMaintenance.Seed(modelBuilder);
			SeedDataConfigurationMaintenance.Seed(modelBuilder);
			SeedDataMaintenanceMaintenanceElement.Seed(modelBuilder);
			SeedDataRole.Seed(modelBuilder);
		}
	}
}
